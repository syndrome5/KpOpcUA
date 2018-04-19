/*
 * Made by Syndrome5 - 2018
 */

using Scada.Comm.Devices.KpOpcUA;
using System;
using System.Collections.Generic;
using System.Threading;
using Opc.Ua;
using Opc.Ua.Client;
using Opc.Ua.Configuration;
using System.Threading.Tasks;

namespace Scada.Comm.Devices
{
    public class KpOpcUALogic : KPLogic
    {
        private class ItemOPCUA
        {
            public NodeId nodeId { get; set; }
            public string id { get; set; }
            public MonitoringMode monMode { get; set; }
            public int sampling { get; set; }
            public int signal { get; set; }

            public ItemOPCUA(NodeId _nodeId, string _id, MonitoringMode _monMode, int _sampling, int _signal)
            {
                nodeId = _nodeId;
                id = _id;
                monMode = _monMode;
                sampling = _sampling;
                signal = _signal;
            }
        }
        
        private class DataItemInfo
        {
            public DataItemInfo()
            {
                Name = "";
                Path = "";
                KPTags = null;
            }
           
            public DataItemInfo(string name, string path)
            {
                Name = name;
                Path = path;
                KPTags = null;
            }

            public string Name { get; set; }
            public string Path { get; set; }
            public KPTag[] KPTags { get; set; }
        }

        private static readonly TimeSpan ReconnectSpan = TimeSpan.FromSeconds(5);
        private readonly string KPNumStr;

        private Config config;             // конфигурация библиотеки
        private bool configLoaded;         // конфигурация библиотеки загружена успешно
        private SortedList<string, KPTag> kpTagsByName;   // список тегов КП, упорядоченный по наименованию

        private bool opcUAConnected;         // соединение с OPC-сервером установлено
        
        public ApplicationConfiguration m_configuration;
        public Session m_session;
        public Subscription m_subscription;
        public MonitoredItemNotificationEventHandler m_MonitoredItem_Notification;
        public SessionReconnectHandler m_reconnectHandler;
        
        private List<ItemOPCUA> ItemsOPCUA { get; set; }

        public KpOpcUALogic(int number)
            : base(number)
        {
            KPNumStr = Localization.UseRussian ? "КП " + number + ". " : "Device " + number + ". ";

            config = new Config();
            configLoaded = false;
            kpTagsByName = new SortedList<string, KPTag>();

            ItemsOPCUA = new List<ItemOPCUA>();
            
            opcUAConnected = false;

            // needed
            CanSendCmd = true;
            ConnRequired = false;
        }

        private static void CertificateValidator_CertificateValidation(CertificateValidator validator, CertificateValidationEventArgs e)
        {
            if (e.Error.StatusCode == StatusCodes.BadCertificateUntrusted)
            {
                e.Accept = true;
            }
        }

        public override void Session()
        {
            if (!opcUAConnected)
            {
                base.Session();

                TimeSpan timeSpent = DateTime.Now - DateTime.MinValue;
                if (timeSpent < ReconnectSpan)
                    Thread.Sleep(ReconnectSpan - timeSpent);
                opcUAConnected = Connect().Result;

                // создание подписок на чтение данных и приём событий
                WorkState = opcUAConnected && CreateSubscr() ?
                    WorkStates.Normal : WorkStates.Error;
            }

            // задержка, определяемая параметрами опроса
            Thread.Sleep(ReqParams.Delay);
        }

        public override void OnAddedToCommLine()
        {
            // загрузка конфигурации КП
            string errMsg;
            configLoaded = config.Load(Config.GetFileName(AppDirs.ConfigDir, Number), out errMsg);
            
            int dataGroupCnt = config.DataGroups.Count;
            List<TagGroup> tagGroups = new List<TagGroup>(dataGroupCnt);
            int signal = 1;
            
            if (configLoaded)
            {
                for (int i = 0; i < dataGroupCnt; i++) // browser folders
                {
                    Config.DataGroup dataGroup = config.DataGroups[i];

                    // определение количества тегов КП в группе чтения данных
                    int tagCntByGroup = 0;
                    foreach (Config.DataItem dataItem in dataGroup.DataItems)
                        tagCntByGroup += 1;

                    // создание группы тегов КП
                    if (tagCntByGroup > 0)
                    {
                        TagGroup tagGroup = new TagGroup(string.IsNullOrEmpty(dataGroup.Name) ?
                            (Localization.UseRussian ? "Безымянная группа" : "Unnamed group") : dataGroup.Name);
                        int dataItemCnt = dataGroup.DataItems.Count;

                        List<DataItemInfo> dataGroupInfo = new List<DataItemInfo>();
                        dataGroup.Tag = dataGroupInfo;

                        for (int j = 0; j < dataItemCnt; j++) // Browse Items in a folder
                        {
                            Config.DataItem dataItem = dataGroup.DataItems[j];
                            string dataItemName = string.IsNullOrEmpty(dataItem.Name) ? "" : dataItem.Name;
                            string tagNamePrefix = dataItemName == "" ?
                                (Localization.UseRussian ? "Безымянный тег" : "Unnamed tag") : dataItemName;
                            int tagCntByItem = 1;

                            DataItemInfo dataItemInfo = new DataItemInfo(dataItem.Name, dataItem.Id);
                            dataItemInfo.KPTags = new KPTag[tagCntByItem];

                            //for (int k = 0; k < tagCntByItem; k++)
                            {
                                string tagName = tagNamePrefix;
                                KPTag kpTag = new KPTag(signal++, tagName);
                                tagGroup.KPTags.Add(kpTag);
                                dataItemInfo.KPTags[0] = kpTag; //0->k
                            }

                            if (tagCntByItem > 0 && !kpTagsByName.ContainsKey(dataItemName))
                                kpTagsByName.Add(dataItemName, dataItemInfo.KPTags[0]);
                        }

                        tagGroups.Add(tagGroup);
                    }
                }
                InitKPTags(tagGroups);
            }
            
            // Logs
            /*
            string m_UtilsLogFilePath;
            bool m_deleteOnLoad = true;
            int m_traceMasks = Opc.Ua.Utils.TraceMasks.Error | Opc.Ua.Utils.TraceMasks.Information;
            m_UtilsLogFilePath = AppDomain.CurrentDomain.BaseDirectory + "Opc.Ua.Core.Logs.txt";
            Opc.Ua.Utils.SetTraceLog(m_UtilsLogFilePath, m_deleteOnLoad);
            Opc.Ua.Utils.SetTraceMask(m_traceMasks);
            Opc.Ua.Utils.Trace(Opc.Ua.Utils.TraceMasks.Information, "Beginning of Opc.Ua.Core.Utils logs");
            */

            WriteToLog("Configuration started");

            Init().Wait();

            WriteToLog("Configuration finished");
        }

        public async Task Init()
        {
            try
            {
                ApplicationInstance application = new ApplicationInstance
                {
                    ApplicationType = ApplicationType.Client,
                    ConfigSectionName = config.ApplicationName
                };
                
                // C:\Windows\System32\file.Config.xml
                m_configuration = await application.LoadApplicationConfiguration(false);
                
                // Logs
                /*
                string m_UtilsLogFilePath;
                bool m_deleteOnLoad = false;
                int m_traceMasks = Opc.Ua.Utils.TraceMasks.Error | Opc.Ua.Utils.TraceMasks.Information;
                m_UtilsLogFilePath = AppDomain.CurrentDomain.BaseDirectory + "Opc.Ua.Core.Logs.txt";
                Opc.Ua.Utils.SetTraceLog(m_UtilsLogFilePath, m_deleteOnLoad);
                Opc.Ua.Utils.SetTraceMask(m_traceMasks);
                Opc.Ua.Utils.Trace(Opc.Ua.Utils.TraceMasks.Information, "Beginning of Opc.Ua.Core.Utils logs");
                */

                bool appCert = await application.CheckApplicationInstanceCertificate(false, 0);
                m_configuration.ApplicationUri = Opc.Ua.Utils.GetApplicationUriFromCertificate(m_configuration.SecurityConfiguration.ApplicationCertificate.Certificate);
                m_configuration.CertificateValidator.CertificateValidation += new CertificateValidationEventHandler(CertificateValidator_CertificateValidation);
            }
            catch (Exception ex)
            {
                WriteToLog("Error in configuration: " + ex.Message);
            }
        }

        private async Task<bool> Connect()
        {
            try
            {
                string path = config.ServerPath;
                Boolean cert = config.UseCertificate;
                if (string.IsNullOrEmpty(path))
                    throw new Exception(Localization.UseRussian ? "сервер не задан" : "server is undefined");

                EndpointDescription selectedEndpoint = CoreClientUtils.SelectEndpoint(path, cert, 15000);
                EndpointConfiguration endpointConfiguration = EndpointConfiguration.Create(m_configuration);
                ConfiguredEndpoint endpoint = new ConfiguredEndpoint(null, selectedEndpoint, endpointConfiguration);

                m_session = await Opc.Ua.Client.Session.Create(m_configuration, endpoint, false, "KpOpcUA Demo", 60000, new UserIdentity(new AnonymousIdentityToken()), null);
                m_session.KeepAlive += Client_KeepAlive;

                return true;
            }
            catch (Exception ex)
            {
                WriteToLog((Localization.UseRussian ? 
                    "Ошибка при соединении с OPC-сервером: " : 
                    "Error connecting to OPC UA server: ") + ex.Message);
                return false;
            }
        }

        private void Client_KeepAlive(Session sender, KeepAliveEventArgs e)
        {
            if (e.Status != null && ServiceResult.IsNotGood(e.Status))
            {
                if (m_reconnectHandler == null)
                {
                    m_reconnectHandler = new SessionReconnectHandler();
                    m_reconnectHandler.BeginReconnect(sender, 10000, Client_ReconnectComplete);
                }
            }
        }

        private void Client_ReconnectComplete(object sender, EventArgs e)
        {
            if (!Object.ReferenceEquals(sender, m_reconnectHandler))
            {
                return;
            }
            m_session = m_reconnectHandler.Session;
            m_reconnectHandler.Dispose();
            m_reconnectHandler = null;
        }

        private bool CreateSubscr()
        {
            try
            {
                foreach (Config.DataGroup dataGroup in config.DataGroups)
                {
                    if (dataGroup.Active && dataGroup.DataItems.Count > 0)
                    {
                        if (Localization.UseRussian)
                            WriteToLog("Создание подписки на чтение данных" +
                                (string.IsNullOrEmpty(dataGroup.Name) ? "" : ". Наименование: " + dataGroup.Name));
                        else
                            WriteToLog("Create data reading subscription" +
                                (string.IsNullOrEmpty(dataGroup.Name) ? "" : ". Name: " + dataGroup.Name));
                        
                        foreach (Config.DataItem dataItem in dataGroup.DataItems)
                        {
                            if (dataItem.Active)
                            {
                                MonitoringMode mm = new MonitoringMode();
                                if (dataItem.Mode == "Reporting")
                                    mm = MonitoringMode.Reporting;
                                else if (dataItem.Mode == "Sampling")
                                    mm = MonitoringMode.Sampling;
                                else if (dataItem.Mode == "Disabled")
                                    mm = MonitoringMode.Disabled;

                                KPTag tag;
                                if (kpTagsByName.TryGetValue(dataItem.Name, out tag))
                                {
                                    ItemsOPCUA.Add(new ItemOPCUA(null, dataItem.Id, mm, dataItem.Signal, tag.Signal-1));
                                }
                                else
                                {
                                    WriteToLog("Error to assign signal to the name: " + dataItem.Name);
                                }
                            }
                        }
                    }
                }
                
                ReferenceDescriptionCollection references;
                references = m_session.FetchReferences(ObjectIds.ObjectsFolder);
                // parcourir
                BrowseNodesId(ObjectIds.ObjectsFolder, ItemsOPCUA);

                if (m_subscription != null)
                {
                    m_subscription.ApplyChanges();
                }
                
                return true;
            }
            catch (Exception ex)
            {
                WriteToLog((Localization.UseRussian ?
                    "Ошибка при создании подписки на чтение данных: " :
                    "Error creating data reading subscription: ") + ex.Message);
                return false;
            }
        }

        private void BrowseNodesId(NodeId parent, List<ItemOPCUA> ItemsOPCUA, int maxSpace = -1, int space=0)
        {
            ReferenceDescriptionCollection refs;
            Byte[] continuationPoint;
        
            m_session.Browse(
                null,
                null,
                parent,
                0u,
                BrowseDirection.Forward,
                ReferenceTypeIds.HierarchicalReferences,
                true,
                (uint)NodeClass.Variable | (uint)NodeClass.Object | (uint)NodeClass.Method,
                out continuationPoint,
                out refs);


            if (refs.Count > 0)
            {
                foreach (var rd in refs)
                {
                    bool isContinue = IfItemToSub(ref ItemsOPCUA, rd, space);
                    if (maxSpace != space + 1 && isContinue)
                    {
                        BrowseNodesId(ExpandedNodeId.ToNodeId(rd.NodeId, m_session.NamespaceUris), ItemsOPCUA, maxSpace, space + 1);
                    }
                }
            }
        }

        private bool IfItemToSub(ref List<ItemOPCUA> ItemsOPCUA, ReferenceDescription rd, int level)
        {
            bool continueOk = false;
            
            foreach (var itemUA in ItemsOPCUA)
            {
                string[] subIds = itemUA.id.Split(new string[] { ".:." }, StringSplitOptions.None);
                if (rd.DisplayName.Text == subIds[level])
                {
                    if (subIds.Length == level + 1) // item to sub
                    {
                        ItemsOPCUA[ItemsOPCUA.IndexOf(itemUA)].nodeId = (NodeId)rd.NodeId;
                        CreateMonitoredItem((NodeId)rd.NodeId, Opc.Ua.Utils.Format("{0}", rd), ItemsOPCUA[ItemsOPCUA.IndexOf(itemUA)].monMode, ItemsOPCUA[ItemsOPCUA.IndexOf(itemUA)].sampling);
                    }
                    else // folder to enter
                    {
                        continueOk = true;
                    }
                }
            }

            return continueOk;
        }

        private void OnNotification(MonitoredItem monitoredItem, MonitoredItemNotificationEventArgs e)
        {
            try
            {
                if (m_session == null)
                {
                    return;
                }
                MonitoredItemNotification notification = e.NotificationValue as MonitoredItemNotification;
                if (notification == null)
                {
                    return;
                }
                
                foreach (var value in monitoredItem.DequeueValues())
                {

                    foreach (var itemUA in ItemsOPCUA)
                    {
                        if (itemUA.nodeId == monitoredItem.StartNodeId)
                        {
                            SetCurData(itemUA.signal, Convert.ToDouble(Opc.Ua.Utils.Format("{0}", notification.Value.WrappedValue)), Scada.Data.Configuration.BaseValues.CnlStatuses.Defined);
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                WriteToLog(KPNumStr + (Localization.UseRussian ?
                    "Ошибка при обработке изменения текущих данных: " :
                    "Error handling current data changing: ") + ex.Message);
                lastCommSucc = false;
            }
        }

        private void CreateMonitoredItem(NodeId nodeId, string displayName, MonitoringMode monMode, int sampling)
        {
            if (m_subscription == null)
            {
                m_subscription = new Subscription(m_session.DefaultSubscription)
                {
                    PublishingEnabled = true,
                    PublishingInterval = 1000,
                    KeepAliveCount = 10,
                    LifetimeCount = 10,
                    MaxNotificationsPerPublish = 1000,
                    Priority = 100
                };

                m_session.AddSubscription(m_subscription);

                m_subscription.Create();
            }

            // add the new monitored item.
            MonitoredItem monitoredItem = new MonitoredItem(m_subscription.DefaultItem);

            monitoredItem.StartNodeId = nodeId;
            monitoredItem.AttributeId = Attributes.Value;
            monitoredItem.DisplayName = displayName;
            monitoredItem.MonitoringMode = monMode;
            monitoredItem.SamplingInterval = sampling;
            monitoredItem.QueueSize = 0;
            monitoredItem.DiscardOldest = false;

            monitoredItem.Notification += OnNotification;

            m_subscription.AddItem(monitoredItem);
        }
        
    }
}
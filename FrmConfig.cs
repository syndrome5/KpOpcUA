/*
 * Made by Syndrome5 - 2018
 */

using System.Security.Cryptography.X509Certificates;
using Scada.UI;
using System;
using System.IO;
using System.Windows.Forms;
using Opc.Ua;
using Opc.Ua.Configuration;
using Opc.Ua.Client;
using System.Collections;

namespace Scada.Comm.Devices.KpOpcUA
{
    internal partial class FrmConfig : Form
    {
        private Config config;                   // конфигурация КП
        private bool modified;                   // признак изменения конфигурации

        private TreeNode nodeDataRead;           // узел чтения данных в дереве КП
        private TreeNode nodeDataWrite;          // узел записи данных в дереве КП
        private TreeNode nodeEvents;             // узел событий в дереве КП

        public FrmConfig()
        {
            InitializeComponent();

            ctrlDataGroupProps.Top = ctrlDataItemProps.Top = ctrlCommandProps.Top = ctrlEventGroupProps.Top = pnlNoProps.Top;

            config = new Config();
            modified = false;

            nodeDataRead = tvKP.Nodes["nodeDataRead"];
            nodeDataWrite = tvKP.Nodes["nodeDataWrite"];
            nodeEvents = tvKP.Nodes["nodeEvents"];

            ConfigDir = "";
            LangDir = "";
            KPNum = 0;

            try
            {
                ApplicationInstance application = new ApplicationInstance();
                application.ApplicationType = ApplicationType.Client;
                application.ConfigSectionName = "ScadaCommCtrl";
                application.ProcessCommandLine();
                application.LoadApplicationConfiguration(false);
                application.CheckApplicationInstanceCertificate(false, 0);
                
                m_configuration = application.ApplicationConfiguration;
                m_clientCertificate = null;//m_configuration.SecurityConfiguration.ApplicationCertificate.Find(true);
                m_configuration.CertificateValidator.CertificateValidation += new CertificateValidationEventHandler(CertificateValidator_CertificateValidation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool Modified
        {
            get
            {
                return modified;
            }
            set
            {
                modified = value;
                btnSave.Enabled = modified;
            }
        }

        public string ConfigDir { get; set; }
        public string LangDir { get; set; }
        public int KPNum { get; set; }
        public ApplicationInstance application { get => application; set => application = value; }

        public ApplicationConfiguration m_configuration;
        public X509Certificate2 m_clientCertificate;
        public Session m_session;
        public Subscription m_subscription;
        public SessionReconnectHandler m_reconnectHandler;

        private void FrmConfig_Load(object sender, EventArgs e)
        {
            // локализация модуля
            string errMsg;
            if (!Localization.UseRussian)
            {
                if (Localization.LoadDictionaries(LangDir, "KpOpcUA", out errMsg))
                {
                    Translator.TranslateForm(this, "Scada.Comm.Devices.KpOpcUA.FrmConfig");
                    KpPhrases.Init();
                    TranslateKpTree();
                }
                else
                {
                    ScadaUiUtils.ShowError(errMsg);
                }
            }

            // вывод заголовка
            Text = string.Format(Text, KPNum);

            cbServer.Text = "opc.tcp://192.168.1.105:4334";

            // загрузка конфигурации КП
            string fileName = Config.GetFileName(ConfigDir, KPNum);
            if (File.Exists(fileName) && !config.Load(fileName, out errMsg))
                ScadaUiUtils.ShowError(errMsg);

            // расчёт сигналов и отображение конфигурации КП
            CalcSignals();
            ShowConfig();
            Modified = false;
        }

        private void FrmConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Modified)
            {
                DialogResult result = MessageBox.Show(CommPhrases.SaveKpSettingsConfirm,
                    CommonPhrases.QuestionCaption, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                switch (result)
                {
                    case DialogResult.Yes:
                        string errMsg;
                        if (!config.Save(Config.GetFileName(ConfigDir, KPNum), out errMsg))
                        {
                            ScadaUiUtils.ShowError(errMsg);
                            e.Cancel = true;
                        }
                        Disconnect();
                        break;
                    case DialogResult.No:
                        break;
                    default:
                        e.Cancel = true;
                        break;
                }
            }
        }

        private void FrmConfig_FormClosed(object sender, FormClosedEventArgs e)
        {
            Disconnect();
        }

        private bool Connect()
        {
            try
            {
                try
                {
                    // disconnect any existing session.
                    Disconnect();
                   
                    EndpointDescription endpointDescription = SelectEndpoint();
                    EndpointConfiguration endpointConfiguration = EndpointConfiguration.Create(m_configuration);
                    ConfiguredEndpoint endpoint = new ConfiguredEndpoint(null, endpointDescription, endpointConfiguration);
                  
                    // create the channel object used to connect to the server.
                    ITransportChannel channel = SessionChannel.Create(
                        m_configuration,
                        endpoint.Description,
                        endpoint.Configuration, m_clientCertificate, m_configuration.CreateMessageContext());
                    
                    // create the session object.
                    m_session = new Session(channel, m_configuration, endpoint, m_clientCertificate);

                    // sets the watchdog timer used to detect failures.
                    m_session.KeepAliveInterval = 2000;

                    // set up keep alive callback.
                    m_session.KeepAlive += new KeepAliveEventHandler(Session_KeepAlive);

                    // create the session.
                    m_session.Open("KpOpcUA", null);

                    // populate the browse view.
                    PopulateBranch(ObjectIds.ObjectsFolder, BrowseNodesTV.Nodes);

                    //MonitoredItemsLV.Enabled = true;
                    UseSecurityCK.Enabled = false;
                    btnConnect.Enabled = false;
                    btnDisconnect.Enabled = true;
                    cbServer.Enabled = false;
                    btnRefrItems.Enabled = true;
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                ScadaUiUtils.ShowError(KpPhrases.ConnectServerError + ":\r\n" + ex.Message);
                return false;
            }
        }

        // DropMenu instead of Textbox to make DiscoveryUA
        private EndpointDescription SelectEndpoint()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                // determine the URL that was selected.
                string discoveryUrl = cbServer.Text;

                /*if (cbServer.SelectedIndex >= 0)
                {
                    discoveryUrl = (string)cbServer.SelectedItem;
                }*/

                // return the selected endpoint.
                return null;// Quickstarts.FormUtils.SelectEndpoint(discoveryUrl, UseSecurityCK.Checked);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        // No autoreconnect
        private void Session_KeepAlive(Session session, KeepAliveEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new KeepAliveEventHandler(Session_KeepAlive), session, e);
                return;
            }

            try
            {
                // check for events from discarded sessions.
                if (!Object.ReferenceEquals(session, m_session))
                {
                    return;
                }

                if (ServiceResult.IsBad(e.Status))
                {
                    /*if (m_reconnectHandler == null)
                    {
                        BrowseNodesTV.Enabled = false;
                        //MonitoredItemsLV.Enabled = false;
                        AttributesLV.Items.Clear();

                        m_reconnectHandler = new SessionReconnectHandler();
                        m_reconnectHandler.BeginReconnect(m_session, 10000, Server_ReconnectComplete);
                    }*/

                    ResetForms();
                    Disconnect();
                    MessageBox.Show("Server disconnected");

                    return;
                }

                //LastKeepAliveTimeLB.Text = Utils.Format("{0:HH:mm:ss}", e.CurrentTime.ToLocalTime());
                //LastKeepAliveTimeLB.ForeColor = Color.Empty;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateBranch(NodeId sourceId, TreeNodeCollection nodes)
        {
            try
            {
                nodes.Clear();

                // find all of the components of the node.
                BrowseDescription nodeToBrowse1 = new BrowseDescription();

                nodeToBrowse1.NodeId = sourceId;
                nodeToBrowse1.BrowseDirection = BrowseDirection.Forward;
                nodeToBrowse1.ReferenceTypeId = ReferenceTypeIds.Aggregates;
                nodeToBrowse1.IncludeSubtypes = true;
                nodeToBrowse1.NodeClassMask = (uint)(NodeClass.Object | NodeClass.Variable);
                nodeToBrowse1.ResultMask = (uint)BrowseResultMask.All;

                // find all nodes organized by the node.
                BrowseDescription nodeToBrowse2 = new BrowseDescription();

                nodeToBrowse2.NodeId = sourceId;
                nodeToBrowse2.BrowseDirection = BrowseDirection.Forward;
                nodeToBrowse2.ReferenceTypeId = ReferenceTypeIds.Organizes;
                nodeToBrowse2.IncludeSubtypes = true;
                nodeToBrowse2.NodeClassMask = (uint)(NodeClass.Object | NodeClass.Variable);
                nodeToBrowse2.ResultMask = (uint)BrowseResultMask.All;

                BrowseDescriptionCollection nodesToBrowse = new BrowseDescriptionCollection();
                nodesToBrowse.Add(nodeToBrowse1);
                nodesToBrowse.Add(nodeToBrowse2);

                // fetch references from the server.
                ReferenceDescriptionCollection references = null;//Quickstarts.FormUtils.Browse(m_session, nodesToBrowse, false);

                // process results.
                for (int ii = 0; ii < references.Count; ii++)
                {
                    ReferenceDescription target = references[ii];

                    // add node.
                    TreeNode child = new TreeNode(Opc.Ua.Utils.Format("{0}", target));
                    child.Tag = target;
                    child.Nodes.Add(new TreeNode());
                    nodes.Add(child);
                }

                // update the attributes display.
                DisplayAttributes(sourceId);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayAttributes(NodeId sourceId)
        {
            try
            {
                AttributesLV.Items.Clear();

                ReadValueIdCollection nodesToRead = new ReadValueIdCollection();

                // attempt to read all possible attributes.
                for (uint ii = Attributes.NodeClass; ii <= Attributes.UserExecutable; ii++)
                {
                    ReadValueId nodeToRead = new ReadValueId();
                    nodeToRead.NodeId = sourceId;
                    nodeToRead.AttributeId = ii;
                    nodesToRead.Add(nodeToRead);
                }

                int startOfProperties = nodesToRead.Count;

                // find all of the pror of the node.
                BrowseDescription nodeToBrowse1 = new BrowseDescription();

                nodeToBrowse1.NodeId = sourceId;
                nodeToBrowse1.BrowseDirection = BrowseDirection.Forward;
                nodeToBrowse1.ReferenceTypeId = ReferenceTypeIds.HasProperty;
                nodeToBrowse1.IncludeSubtypes = true;
                nodeToBrowse1.NodeClassMask = 0;
                nodeToBrowse1.ResultMask = (uint)BrowseResultMask.All;

                BrowseDescriptionCollection nodesToBrowse = new BrowseDescriptionCollection();
                nodesToBrowse.Add(nodeToBrowse1);

                // fetch property references from the server.
                ReferenceDescriptionCollection references = null;//Quickstarts.FormUtils.Browse(m_session, nodesToBrowse, false);

                for (int ii = 0; ii < references.Count; ii++)
                {
                    // ignore external references.
                    if (references[ii].NodeId.IsAbsolute)
                    {
                        continue;
                    }

                    ReadValueId nodeToRead = new ReadValueId();
                    nodeToRead.NodeId = (NodeId)references[ii].NodeId;
                    nodeToRead.AttributeId = Attributes.Value;
                    nodesToRead.Add(nodeToRead);
                }

                // read all values.
                DataValueCollection results = null;
                DiagnosticInfoCollection diagnosticInfos = null;

                m_session.Read(
                    null,
                    0,
                    TimestampsToReturn.Neither,
                    nodesToRead,
                    out results,
                    out diagnosticInfos);

                ClientBase.ValidateResponse(results, nodesToRead);
                ClientBase.ValidateDiagnosticInfos(diagnosticInfos, nodesToRead);

                // process results.
                for (int ii = 0; ii < results.Count; ii++)
                {
                    string name = null;
                    string datatype = null;
                    string value = null;

                    // process attribute value.
                    if (ii < startOfProperties)
                    {
                        // ignore attributes which are invalid for the node.
                        if (results[ii].StatusCode == StatusCodes.BadAttributeIdInvalid)
                        {
                            continue;
                        }

                        // get the name of the attribute.
                        name = Attributes.GetBrowseName(nodesToRead[ii].AttributeId);

                        // display any unexpected error.
                        if (StatusCode.IsBad(results[ii].StatusCode))
                        {
                            datatype = Opc.Ua.Utils.Format("{0}", Attributes.GetDataTypeId(nodesToRead[ii].AttributeId));
                            value = Opc.Ua.Utils.Format("{0}", results[ii].StatusCode);
                        }

                        // display the value.
                        else
                        {
                            TypeInfo typeInfo = TypeInfo.Construct(results[ii].Value);

                            datatype = typeInfo.BuiltInType.ToString();

                            if (typeInfo.ValueRank >= ValueRanks.OneOrMoreDimensions)
                            {
                                datatype += "[]";
                            }

                            value = Opc.Ua.Utils.Format("{0}", results[ii].Value);
                        }
                    }

                    // process property value.
                    else
                    {
                        // ignore properties which are invalid for the node.
                        if (results[ii].StatusCode == StatusCodes.BadNodeIdUnknown)
                        {
                            continue;
                        }

                        // get the name of the property.
                        name = Opc.Ua.Utils.Format("{0}", references[ii - startOfProperties]);

                        // display any unexpected error.
                        if (StatusCode.IsBad(results[ii].StatusCode))
                        {
                            datatype = String.Empty;
                            value = Opc.Ua.Utils.Format("{0}", results[ii].StatusCode);
                        }

                        // display the value.
                        else
                        {
                            TypeInfo typeInfo = TypeInfo.Construct(results[ii].Value);

                            datatype = typeInfo.BuiltInType.ToString();

                            if (typeInfo.ValueRank >= ValueRanks.OneOrMoreDimensions)
                            {
                                datatype += "[]";
                            }

                            value = Opc.Ua.Utils.Format("{0}", results[ii].Value);
                        }
                    }

                    // add the attribute name/value to the list view.
                    ListViewItem item = new ListViewItem(name);
                    item.SubItems.Add(datatype);
                    item.SubItems.Add(value);
                    AttributesLV.Items.Add(item);
                }

                // adjust width of all columns.
                for (int ii = 0; ii < AttributesLV.Columns.Count; ii++)
                {
                    AttributesLV.Columns[ii].Width = -2;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CertificateValidator_CertificateValidation(CertificateValidator sender, CertificateValidationEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new CertificateValidationEventHandler(CertificateValidator_CertificateValidation), sender, e);
                return;
            }

            try
            {
                DialogResult result = MessageBox.Show(
                    e.Certificate.Subject,
                    "Untrusted Certificate",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                e.Accept = (result == DialogResult.Yes);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BrowseNodesTV_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            try
            {
                // check if node has already been expanded once.
                if (e.Node.Nodes.Count != 1 || e.Node.Nodes[0].Text != String.Empty)
                {
                    return;
                }

                // get the source for the node.
                ReferenceDescription reference = e.Node.Tag as ReferenceDescription;

                if (reference == null || reference.NodeId.IsAbsolute)
                {
                    e.Cancel = true;
                    return;
                }

                // populate children.
                PopulateBranch((NodeId)reference.NodeId, e.Node.Nodes);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BrowseNodesTV_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                // get the source for the node.
                ReferenceDescription reference = e.Node.Tag as ReferenceDescription;

                if (reference == null || reference.NodeId.IsAbsolute)
                {
                    return;
                }

                // populate children.
                PopulateBranch((NodeId)reference.NodeId, e.Node.Nodes);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BrowseNodesTV_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                BrowseNodesTV.SelectedNode = BrowseNodesTV.GetNodeAt(e.X, e.Y);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ??
        private void TranslateKpTree()
        {
            nodeDataRead.Text = KpPhrases.DataReadNode;
            nodeDataWrite.Text = KpPhrases.DataWriteNode;
            nodeEvents.Text = KpPhrases.EventsNode;
        }

        private void ResetForms()
        {
            UseSecurityCK.Enabled = true;
            btnConnect.Enabled = true;
            btnDisconnect.Enabled = false;
            btnAddElem.Enabled = false;
            cbServer.Enabled = true;
            BrowseNodesTV.Nodes.Clear();
            AttributesLV.Items.Clear();
        }

        private void RefrServers()
        {
            try
            {
                ResetForms();
                Disconnect();

                Connect();
            }
            catch (Exception ex)
            {
                ScadaUiUtils.ShowError(KpPhrases.RefreshServersError + ":\r\n" + ex.Message);
            }
        }

        private void Disconnect()
        {
            try
            {
                if (m_reconnectHandler != null)
                {
                    m_reconnectHandler.Dispose();
                    m_reconnectHandler = null;
                }

                if (m_session != null)
                {
                    m_session.Close(1000);
                    m_subscription = null;
                    m_session = null;
                }
                btnRefrItems.Enabled = false;
            }
            catch (Exception ex)
            {
                ScadaUiUtils.ShowError(KpPhrases.DisconnectServerError + ":\r\n" + ex.Message);
            }
        }

        // ??
        private void CalcSignals()
        {
            int groupCnt = config.DataGroups.Count;
            int signal = 1;

            for (int groupInd = 0; groupInd < groupCnt; groupInd++)
            {
                Config.DataGroup dataGroup = config.DataGroups[groupInd];
                int itemCnt = dataGroup.DataItems.Count;

                for (int itemInd = 0; itemInd < itemCnt; itemInd++)
                {
                    Config.DataItem dataItem = dataGroup.DataItems[itemInd];
                    dataItem.Signal = signal;
                    //signal += dataItem.IsArray ? dataItem.ArrayLen : 1; TODO
                }
            }
        }

        // en coms
        private void ShowConfig()
        {
            /*try
            {
                // выбор OPC-сервера и спецификации
                string serverPath = config.ServerPath;
                string daSpec = config.DaSpecification;
                SelectServerAndSpec(serverPath, daSpec);

                // заполнение дерева КП
                tvKP.BeginUpdate();
                nodeDataRead.Nodes.Clear();
                nodeDataWrite.Nodes.Clear();
                nodeEvents.Nodes.Clear();

                // отображение считываемых данных
                foreach (Config.DataGroup dataGroup in config.DataGroups)
                {
                    TreeNode nodeDataGroup = new TreeNode(dataGroup.ToString());
                    nodeDataGroup.Tag = dataGroup;
                    nodeDataGroup.ImageKey = nodeDataGroup.SelectedImageKey = "folder_closed.png";
                    nodeDataRead.Nodes.Add(nodeDataGroup);

                    foreach (Config.DataItem dataItem in dataGroup.DataItems)
                    {
                        TreeNode nodeDataItem = new TreeNode(dataItem.Name);
                        nodeDataItem.Tag = dataItem;
                        nodeDataItem.ImageKey = nodeDataItem.SelectedImageKey = "da_item.png";
                        nodeDataGroup.Nodes.Add(nodeDataItem);
                    }
                }

                nodeDataRead.Expand();

                // отображение записываемых данных
                foreach (Config.Command command in config.Commands)
                {
                    TreeNode nodeCommand = new TreeNode(command.ItemName);
                    nodeCommand.Tag = command;
                    nodeCommand.ImageKey = nodeCommand.SelectedImageKey = "da_item_viol.png";
                    nodeDataWrite.Nodes.Add(nodeCommand);
                }

                nodeDataWrite.Expand();

                // отображение событий
                foreach (Config.EventGroup eventGroup in config.EventGroups)
                {
                    TreeNode nodeEventGroup = new TreeNode(eventGroup.ToString());
                    nodeEventGroup.Tag = eventGroup;
                    nodeEventGroup.ImageKey = nodeEventGroup.SelectedImageKey = "folder_closed.png";
                    nodeEvents.Nodes.Add(nodeEventGroup);

                    foreach (string catName in eventGroup.Categories.Keys)
                    {
                        TreeNode nodeCat = new TreeNode(catName);
                        nodeCat.Tag = catName;
                        nodeCat.ImageKey = nodeCat.SelectedImageKey = "ae_cat.png";
                        nodeEventGroup.Nodes.Add(nodeCat);
                    }
                }

                nodeEvents.Expand();
            }
            finally
            {
                tvKP.EndUpdate();
            }*/
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            Disconnect();
            ResetForms();
        }

        private void btnCreateDataGroup_Click(object sender, EventArgs e)
        {
            // создание группы чтения данных
            Config.DataGroup newDataGroup = new Config.DataGroup();
            TreeNode newNode = new TreeNode(newDataGroup.ToString());
            newNode.Tag = newDataGroup;
            newNode.ImageKey = newNode.SelectedImageKey = "folder_closed.png";

            Config.DataGroup selDataGroup = tvKP.SelectedNode == null ? 
                null : tvKP.SelectedNode.Tag as Config.DataGroup;
            int newInd = selDataGroup == null ? nodeDataRead.Nodes.Count : tvKP.SelectedNode.Index + 1;
            nodeDataRead.Nodes.Insert(newInd, newNode);
            config.DataGroups.Insert(newInd, newDataGroup);

            nodeDataRead.Expand();
            tvKP.SelectedNode = newNode;
            ctrlDataGroupProps.SetFocus();
        }

        private void btnCreateEventGroup_Click(object sender, EventArgs e)
        {
            // создание группы приёма событий
            Config.EventGroup newEventGroup = new Config.EventGroup();
            TreeNode newNode = new TreeNode(newEventGroup.ToString());
            newNode.Tag = newEventGroup;
            newNode.ImageKey = newNode.SelectedImageKey = "folder_closed.png";

            Config.EventGroup selEventGroup = tvKP.SelectedNode == null ?
                null : tvKP.SelectedNode.Tag as Config.EventGroup;
            int newInd = selEventGroup == null ? nodeEvents.Nodes.Count : tvKP.SelectedNode.Index + 1;
            nodeEvents.Nodes.Insert(newInd, newNode);
            config.EventGroups.Insert(newInd, newEventGroup);

            nodeEvents.Expand();
            tvKP.SelectedNode = newNode;
            ctrlEventGroupProps.SetFocus();
        }

        // en coms
        private void btnAddElem_Click(object sender, EventArgs e)
        {
            // добавление выбранного элемента
            /*TreeNode node1 = tvServer.SelectedNode;
            TreeNode node2 = tvKP.SelectedNode;

            if (node1 != null && node2 != null)
            {
                object tag1 = node1.Tag;
                object tag2 = node2.Tag;
                TreeNode newNode = null;
                TreeNode parNode = null;

                // получение добавляемого элемента
                Opc.Da.BrowseElement browseElem = tag1 as Opc.Da.BrowseElement;

                if (browseElem != null && (browseElem.IsItem || !browseElem.HasChildren)) // если не работает IsItem
                {
                    // определение группы чтения данных, в которую добавляется элемент
                    TreeNode dataGroupNode = node2;
                    Config.DataGroup dataGroup = tag2 as Config.DataGroup;

                    if (dataGroup == null && node2.Parent != null)
                    {
                        dataGroupNode = node2.Parent;
                        dataGroup = dataGroupNode.Tag as Config.DataGroup;
                    }

                    if (dataGroup != null)
                    {
                        // добавление тега в группу чтения данных
                        bool isArray;

                        if (CheckItemType(browseElem.ItemPath, browseElem.ItemName, out isArray))
                        {
                            Config.DataItem newDataItem = new Config.DataItem();
                            newDataItem.Name = browseElem.ItemName;
                            newDataItem.Path = browseElem.ItemPath;
                            newDataItem.IsArray = isArray;

                            newNode = new TreeNode(newDataItem.Name);
                            newNode.Tag = newDataItem;
                            newNode.ImageKey = newNode.SelectedImageKey = "da_item.png";
                            parNode = dataGroupNode;

                            Config.DataItem selDataItem = tag2 as Config.DataItem;
                            int newInd = selDataItem == null ? parNode.Nodes.Count : node2.Index + 1;
                            parNode.Nodes.Insert(newInd, newNode);
                            dataGroup.DataItems.Insert(newInd, newDataItem);

                            CalcSignals();
                        }
                    }
                    else if (node2 == nodeDataWrite || node2.Parent == nodeDataWrite)
                    {
                        // добавление команды
                        string typeName;

                        if (GetItemTypeName(browseElem.ItemPath, browseElem.ItemName, out typeName))
                        {
                            Config.Command newCommand = new Config.Command();
                            newCommand.ItemName = browseElem.ItemName;
                            newCommand.ItemPath = browseElem.ItemPath;
                            newCommand.TypeName = typeName;

                            newNode = new TreeNode(newCommand.ItemName);
                            newNode.Tag = newCommand;
                            newNode.ImageKey = newNode.SelectedImageKey = "da_item_viol.png";
                            parNode = nodeDataWrite;

                            Config.Command selCommand = tag2 as Config.Command;
                            int newInd = selCommand == null ? parNode.Nodes.Count : node2.Index + 1;
                            parNode.Nodes.Insert(newInd, newNode);
                            config.Commands.Insert(newInd, newCommand);
                        }
                    }
                }
                else if (tag1 is Opc.Ae.Category)
                {
                    // определение группы приёма событий, в которую добавляется элемент
                    TreeNode eventGroupNode = node2;
                    Config.EventGroup eventGroup = tag2 as Config.EventGroup;

                    if (eventGroup == null && node2.Parent != null)
                    {
                        eventGroupNode = node2.Parent;
                        eventGroup = eventGroupNode.Tag as Config.EventGroup;
                    }

                    if (eventGroup != null)
                    {
                        // добавление категории событий, сохраняя упорядоченность категорий в группе
                        Opc.Ae.Category cat = (Opc.Ae.Category)tag1;
                        string catName = cat.Name;
                        int newInd = eventGroup.Categories.IndexOfKey(catName);

                        if (newInd >= 0)
                        {
                            ScadaUiUtils.ShowError(KpPhrases.EvCatExists);
                        }
                        else
                        {
                            newNode = new TreeNode(catName);
                            newNode.Tag = catName;
                            newNode.ImageKey = newNode.SelectedImageKey = "ae_cat.png";
                            parNode = eventGroupNode;

                            newInd = ~newInd;
                            parNode.Nodes.Insert(newInd, newNode);
                            eventGroup.Categories.Add(catName, cat.ID);
                        }
                    }
                }

                // раскрытие родительского и выбор добавленного узла дерева
                if (parNode != null)
                {
                    parNode.Expand();
                    tvKP.SelectedNode = newNode;
                }

                // установка признака изменения конфигурации
                if (newNode != null)
                    Modified = true;
            }*/
        }

        private void btnMoveUpDown_Click(object sender, EventArgs e)
        {
            // перемещение элемента вверх или вниз
            TreeNode node = tvKP.SelectedNode;

            if (node != null)
            {
                TreeNode parNode = node.Parent;
                object tag = node.Tag;

                // определение списка, в котором перемещается элемент
                IList list;
                bool calcSignals = false;

                if (tag is Config.DataGroup)
                {
                    list = config.DataGroups;
                    calcSignals = true;
                }
                else if (tag is Config.DataItem)
                {
                    Config.DataGroup dataGroup = (Config.DataGroup)parNode.Tag;                    
                    list = dataGroup.DataItems;
                    calcSignals = true;
                }
                else if (tag is Config.Command)
                {
                    list = config.Commands;
                }
                else if (tag is Config.EventGroup)
                {
                    list = config.EventGroups;
                }
                else
                {
                    list = null;
                }

                // перемещение
                if (parNode != null && list != null)
                {
                    TreeNode prevNode = sender == btnMoveUp ? node.PrevNode : null;
                    TreeNode nextNode = sender == btnMoveDown ? node.NextNode : null;

                    if (prevNode != null || nextNode != null)
                    {
                        try
                        {
                            tvKP.BeginUpdate();
                            int ind1 = node.Index;
                            int ind2 = prevNode != null ? prevNode.Index : nextNode.Index;

                            list.RemoveAt(ind1);
                            list.Insert(ind2, tag);

                            parNode.Nodes.RemoveAt(ind1);
                            parNode.Nodes.Insert(ind2, node);

                            tvKP.SelectedNode = node;
                        }
                        finally
                        {
                            tvKP.EndUpdate();
                        }

                        // расчёт сигналов КП
                        if (calcSignals)
                            CalcSignals();

                        // установка признака изменения конфигурации
                        Modified = true;
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // удаление выбранного элемента
            TreeNode node = tvKP.SelectedNode;

            if (node != null)
            {
                TreeNode parNode = node.Parent;
                TreeNode nextNode = node.NextNode;
                TreeNode prevNode = node.PrevNode;
                object tag = node.Tag;
                int ind = node.Index;
                bool remove = false;

                if (tag is Config.DataGroup)
                {
                    config.DataGroups.RemoveAt(ind);
                    CalcSignals();
                    remove = true;
                }
                else if (tag is Config.DataItem)
                {
                    Config.DataGroup dataGroup = (Config.DataGroup)parNode.Tag;
                    dataGroup.DataItems.RemoveAt(ind);
                    CalcSignals();
                    remove = true;
                }
                else if (tag is Config.Command)
                {
                    config.Commands.RemoveAt(ind);
                    remove = true;
                }
                else if (tag is Config.EventGroup)
                {
                    config.EventGroups.RemoveAt(ind);
                    remove = true;
                }
                else if (tag is string)
                {
                    Config.EventGroup eventGroup = (Config.EventGroup)parNode.Tag;
                    eventGroup.Categories.RemoveAt(ind);
                    remove = true;
                }

                // удаление выбранного узла дерева и выбор нового узла
                if (remove)
                {
                    node.Remove();

                    if (nextNode == null)
                    {
                        if (prevNode == null)
                        {
                            tvKP.SelectedNode = parNode;
                            parNode.ImageKey = parNode.SelectedImageKey = "folder_closed.png";
                        }
                        else
                        {
                            tvKP.SelectedNode = prevNode;
                        }
                    }
                    else
                    {
                        tvKP.SelectedNode = nextNode;
                    }

                    // установка признака изменения конфигурации
                    Modified = true;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string errMsg;
            if (config.Save(Config.GetFileName(ConfigDir, KPNum), out errMsg))
                Modified = false;
            else
                ScadaUiUtils.ShowError(errMsg);
        }

        private void btnRefrItems_Click(object sender, EventArgs e)
        {
            RefrServers();
        }

        private void tvKP_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            // установить иконку для узла, содержащего дочерние узлы
            TreeNode node = e.Node;
            if (node.Nodes.Count > 0)
                node.ImageKey = node.SelectedImageKey = "folder_open.png";
        }

        private void tvKP_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            // установить иконку для узла, содержащего дочерние узлы
            TreeNode node = e.Node;
            if (node.Nodes.Count > 0)
                node.ImageKey = node.SelectedImageKey = "folder_closed.png";
        }

        //SetAddElemEnabled();
        private void tvKP_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //SetAddElemEnabled();

            // установка доступности кнопок перемещения и удаления элементов
            TreeNode node = e.Node;
            object tag = node == null ? null : node.Tag;
            bool move = tag is Config.DataGroup || tag is Config.DataItem || tag is Config.Command || 
                tag is Config.EventGroup;
            btnMoveUp.Enabled = move && node.PrevNode != null;
            btnMoveDown.Enabled = move && node.NextNode != null;
            btnDelete.Enabled = move || tag is string;

            // отображение свойств выбранного элемента
            pnlNoProps.Visible = false;
            ctrlDataGroupProps.Visible = tag is Config.DataGroup;
            ctrlDataItemProps.Visible = tag is Config.DataItem;
            ctrlCommandProps.Visible = tag is Config.Command;
            ctrlEventGroupProps.Visible = tag is Config.EventGroup;

            if (ctrlDataGroupProps.Visible)
                ctrlDataGroupProps.DataGroup = (Config.DataGroup)tag;
            else if (ctrlDataItemProps.Visible)
                ctrlDataItemProps.DataItem = (Config.DataItem)tag;
            else if (ctrlCommandProps.Visible)
                ctrlCommandProps.Command = (Config.Command)tag;
            else if (ctrlEventGroupProps.Visible)
                ctrlEventGroupProps.EventGroup = (Config.EventGroup)tag;
            else
                pnlNoProps.Visible = true;
        }

        private void ctrlDataGroupProps_PropsChanged(object sender, EventArgs e)
        {
            Modified = true;
            if (tvKP.SelectedNode != null)
                tvKP.SelectedNode.Text = ctrlDataGroupProps.DataGroup.ToString();
        }

        private void ctrlDataItemProps_PropsChanged(object sender, EventArgs e)
        {
            Modified = true;
            if (e != null)
                CalcSignals();
        }

        private void ctrlCommandProps_PropsChanged(object sender, EventArgs e)
        {
            Modified = true;
        }

        private void ctrlEventGroupProps_PropsChanged(object sender, EventArgs e)
        {
            Modified = true;
            if (tvKP.SelectedNode != null)
                tvKP.SelectedNode.Text = ctrlEventGroupProps.EventGroup.ToString();
        }
    }
}

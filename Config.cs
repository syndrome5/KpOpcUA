/*
 * Made by Syndrome5 - 2018
 */

using System;
using System.Collections.Generic;
using System.Xml;

namespace Scada.Comm.Devices.KpOpcUA
{
    /// <summary>
    /// Конфигурация КП
    /// </summary>
    internal class Config
    {
        /// <summary>
        /// Группа чтения данных
        /// </summary>
        public class DataGroup
        {
            /// <summary>
            /// Конструктор
            /// </summary>
            public DataGroup()
            {
                Name = "";
                Active = true;
                DataItems = new List<DataItem>();
            }

            /// <summary>
            /// Получить или установить наименование группы
            /// </summary>
            public string Name { get; set; }
            /// <summary>
            /// Получить или установить признак активности
            /// </summary>
            public bool Active { get; set; }

            public object Tag;

            /// <summary>
            /// Получить теги для чтения данных
            /// </summary>
            public List<DataItem> DataItems { get; private set; }
            
            /// <summary>
            /// Получить строковое представление объекта
            /// </summary>
            public override string ToString()
            {
                return string.IsNullOrEmpty(Name) ? KpPhrases.DefGrName : Name;
            }
        }

        /// <summary>
        /// Тег для чтения данных
        /// </summary>
        public class DataItem
        {
            public DataItem()
            {
                Name = "";
                Id = "";
                Active = true;
                Signal = 0;
                Mode = "";
            }

            public string Name { get; set; }
            public string Id { get; set; }
            public bool Active { get; set; }
            public int Signal { get; set; }
            public string Mode { get; set; }
            public int CnlNum { get; set; }
        }

        /// <summary>
        /// Группа приёма событий
        /// </summary>
        public class EventGroup
        {
            /// <summary>
            /// Конструктор
            /// </summary>
            public EventGroup()
            {
                Name = "";
                UpdateRate = 1000;
                MaxSize = 0;
                SimpleEvents = true;
                TrackingEvents = true;
                ConditionEvents = true;
                HighSeverity = 1000;
                LowSeverity = 1;
                Categories = new SortedList<string, int>();
            }

            /// <summary>
            /// Получить или установить наименование группы
            /// </summary>
            public string Name { get; set; }
            /// <summary>
            /// Получить или установить частоту обновления данных, мс
            /// </summary>
            public int UpdateRate { get; set; }
            /// <summary>
            /// Получить или установить максимальное количество запрашиваемых событий
            /// </summary>
            public int MaxSize { get; set; }
            /// <summary>
            /// Получить или установить признак приёма простых событий
            /// </summary>
            public bool SimpleEvents { get; set; }
            /// <summary>
            /// Получить или установить признак приёма событий отслеживания
            /// </summary>
            public bool TrackingEvents { get; set; }
            /// <summary>
            /// Получить или установить признак приёма событий по состоянию
            /// </summary>
            public bool ConditionEvents { get; set; }
            /// <summary>
            /// Получить или установить максимальную серьёзность принимаемых событий
            /// </summary>
            public int HighSeverity { get; set; }
            /// <summary>
            /// Получить или установить минимальную серьёзность принимаемых событий
            /// </summary>
            public int LowSeverity { get; set; }
            /// <summary>
            /// Получить идентификаторы категорий принимаемых событий, упорядоченные по наименованию категорий
            /// </summary>
            public SortedList<string, int> Categories { get; private set; }

            /// <summary>
            /// Получить строковое представление объекта
            /// </summary>
            public override string ToString()
            {
                return string.IsNullOrEmpty(Name) ? KpPhrases.DefGrName : Name;
            }
        }

        /// <summary>
        /// Команда на запись данных
        /// </summary>
        public class Command
        {
            /// <summary>
            /// Конструктор
            /// </summary>
            public Command()
            {
                ItemName = "";
                ItemPath = "";
                TypeName = "";
                CmdNum = 1;
            }

            /// <summary>
            /// Получить или установить наименование тега
            /// </summary>
            public string ItemName { get; set; }
            /// <summary>
            /// Получить или установить путь тега
            /// </summary>
            public string ItemPath { get; set; }
            /// <summary>
            /// Получить или установить имя типа записываемых данных
            /// </summary>
            public string TypeName { get; set; }
            /// <summary>
            /// Получить или установить номер команды КП
            /// </summary>
            public int CmdNum { get; set; }
        }


        /// <summary>
        /// Конструктор
        /// </summary>
        public Config()
        {
            SetToDefault();
        }


        /// <summary>
        /// Получить или установить путь к OPC-серверу
        /// </summary>
        public string ServerPath { get; set; }

        public Boolean UseCertificate { get; set; }

        /// <summary>
        /// Получить группы чтения данных
        /// </summary>
        public List<DataGroup> DataGroups { get; private set; }

        /// <summary>
        /// Получить группы приёма событий
        /// </summary>
        public List<EventGroup> EventGroups { get; private set; }

        /// <summary>
        /// Получить команды на запись данных
        /// </summary>
        public List<Command> Commands { get; private set; }


        /// <summary>
        /// Установить значения параметров конфигурации по умолчанию
        /// </summary>
        private void SetToDefault()
        {
            ServerPath = "";
            DataGroups = new List<DataGroup>();
            EventGroups = new List<EventGroup>();
            Commands = new List<Command>();
        }

        /// <summary>
        /// Загрузить конфигурацию из файла
        /// </summary>
        public bool Load(string fileName, out string errMsg)
        {
            SetToDefault();

            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(fileName);

                // загрузка параметров
                XmlNode paramsNode = xmlDoc.DocumentElement.SelectSingleNode("Params");

                if (paramsNode != null)
                {
                    foreach (XmlElement paramElem in paramsNode.ChildNodes)
                    {
                        string name = paramElem.GetAttribute("name").ToLowerInvariant();
                        string val = paramElem.GetAttribute("value");

                        if (name == "serverpath")
                            ServerPath = val;
                        else if (name == "usecertificate")
                            UseCertificate = Convert.ToBoolean(val);
                    }
                }

                // загрузка групп чтения данных
                XmlNode dataGroupsNode = xmlDoc.DocumentElement.SelectSingleNode("DataGroups");

                if (dataGroupsNode != null)
                {
                    foreach (XmlElement dataGroupElem in dataGroupsNode.ChildNodes)
                    {
                        DataGroup dataGroup = new DataGroup();
                        dataGroup.Name = dataGroupElem.GetAttribute("name");
                        dataGroup.Active = dataGroupElem.GetAttrAsBool("active");

                        XmlNodeList dataItemNodes = dataGroupElem.SelectNodes("DataItem");
                        foreach (XmlElement dataItemElem in dataItemNodes)
                        {
                            DataItem dataItem = new DataItem();
                            dataItem.Name = dataItemElem.GetAttribute("name");
                            dataItem.Id = dataItemElem.GetAttribute("id");
                            dataItem.Active = dataItemElem.GetAttrAsBool("active");
                            dataItem.Signal = dataItemElem.GetAttrAsInt("updateRate");
                            dataItem.Mode = dataItemElem.GetAttribute("mode");
                            dataGroup.DataItems.Add(dataItem);
                        }

                        DataGroups.Add(dataGroup);
                    }
                }

                // загрузка групп приёма событий
                XmlNode eventGroupsNode = xmlDoc.DocumentElement.SelectSingleNode("EventGroups");

                if (eventGroupsNode != null)
                {
                    foreach (XmlElement eventGroupElem in eventGroupsNode.ChildNodes)
                    {
                        EventGroup eventGroup = new EventGroup();
                        eventGroup.Name = eventGroupElem.GetAttribute("name");
                        eventGroup.UpdateRate = eventGroupElem.GetAttrAsInt("updateRate");
                        eventGroup.MaxSize = eventGroupElem.GetAttrAsInt("maxSize");
                        eventGroup.SimpleEvents = eventGroupElem.GetAttrAsBool("simpleEvents");
                        eventGroup.TrackingEvents = eventGroupElem.GetAttrAsBool("trackingEvents");
                        eventGroup.ConditionEvents = eventGroupElem.GetAttrAsBool("conditionEvents");
                        eventGroup.HighSeverity = eventGroupElem.GetAttrAsInt("highSeverity");
                        eventGroup.LowSeverity = eventGroupElem.GetAttrAsInt("lowSeverity");

                        XmlNodeList catNodes = eventGroupElem.SelectNodes("Category");
                        foreach (XmlElement catElem in catNodes)
                            eventGroup.Categories.Add(catElem.GetAttribute("name"), catElem.GetAttrAsInt("id"));

                        EventGroups.Add(eventGroup);
                    }
                }

                // загрузка команд
                XmlNode commandsNode = xmlDoc.DocumentElement.SelectSingleNode("Commands");

                if (commandsNode != null)
                {
                    foreach (XmlElement commandElem in commandsNode.ChildNodes)
                    {
                        Command command = new Command();
                        command.ItemName = commandElem.GetAttribute("itemName");
                        command.ItemPath = commandElem.GetAttribute("itemPath");
                        command.TypeName = commandElem.GetAttribute("typeName");
                        command.CmdNum = commandElem.GetAttrAsInt("cmdNum");
                        Commands.Add(command);
                    }
                }

                errMsg = "";
                return true;
            }
            catch (Exception ex)
            {
                errMsg = CommPhrases.LoadKpSettingsError + ":\r\n" + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Сохранить конфигурацию в файле
        /// </summary>
        public bool Save(string fileName, out string errMsg)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();

                XmlDeclaration xmlDecl = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
                xmlDoc.AppendChild(xmlDecl);

                XmlElement rootElem = xmlDoc.CreateElement("KpOpcUAConfig");
                xmlDoc.AppendChild(rootElem);

                // сохранение параметров
                XmlElement paramsElem = xmlDoc.CreateElement("Params");
                rootElem.AppendChild(paramsElem);
                paramsElem.AppendParamElem("ServerPath", ServerPath);
                paramsElem.AppendParamElem("UseCertificate", Convert.ToString(UseCertificate));

                // сохранение групп чтения данных
                XmlElement dataGroupsElem = xmlDoc.CreateElement("DataGroups");
                rootElem.AppendChild(dataGroupsElem);

                foreach (DataGroup dataGroup in DataGroups)
                {
                    XmlElement dataGroupElem = xmlDoc.CreateElement("DataGroup");
                    dataGroupElem.SetAttribute("name", dataGroup.Name);
                    dataGroupElem.SetAttribute("active", dataGroup.Active);
                    dataGroupsElem.AppendChild(dataGroupElem);

                    foreach (DataItem dataItem in dataGroup.DataItems)
                    {
                        XmlElement dataItemElem = xmlDoc.CreateElement("DataItem");
                        dataItemElem.SetAttribute("name", dataItem.Name);
                        dataItemElem.SetAttribute("active", dataItem.Active);
                        dataGroupElem.AppendChild(dataItemElem);
                    }
                }

                // сохранение групп приёма событий
                XmlElement eventGroupsElem = xmlDoc.CreateElement("EventGroups");
                rootElem.AppendChild(eventGroupsElem);

                foreach (EventGroup eventGroup in EventGroups)
                {
                    XmlElement eventGroupElem = xmlDoc.CreateElement("EventGroup");
                    eventGroupElem.SetAttribute("name", eventGroup.Name);
                    eventGroupElem.SetAttribute("updateRate", eventGroup.UpdateRate);
                    eventGroupElem.SetAttribute("maxSize", eventGroup.MaxSize);
                    eventGroupElem.SetAttribute("simpleEvents", eventGroup.SimpleEvents);
                    eventGroupElem.SetAttribute("trackingEvents", eventGroup.TrackingEvents);
                    eventGroupElem.SetAttribute("conditionEvents", eventGroup.ConditionEvents);
                    eventGroupElem.SetAttribute("highSeverity", eventGroup.HighSeverity);
                    eventGroupElem.SetAttribute("lowSeverity", eventGroup.LowSeverity);
                    eventGroupsElem.AppendChild(eventGroupElem);

                    SortedList<string, int> cats = eventGroup.Categories;
                    int catCnt = cats.Count;

                    for (int i = 0; i < catCnt; i++)
                    {
                        XmlElement catElem = xmlDoc.CreateElement("Category");
                        catElem.SetAttribute("name", cats.Keys[i]);
                        catElem.SetAttribute("id", cats.Values[i]);
                        eventGroupElem.AppendChild(catElem);
                    }
                }

                // сохранение команд
                XmlElement commandsElem = xmlDoc.CreateElement("Commands");
                rootElem.AppendChild(commandsElem);

                foreach (Command command in Commands)
                {
                    XmlElement commandElem = xmlDoc.CreateElement("Command");
                    commandElem.SetAttribute("itemName", command.ItemName);
                    commandElem.SetAttribute("itemPath", command.ItemPath);
                    commandElem.SetAttribute("typeName", command.TypeName);
                    commandElem.SetAttribute("cmdNum", command.CmdNum);
                    commandsElem.AppendChild(commandElem);
                }

                xmlDoc.Save(fileName);
                errMsg = "";
                return true;
            }
            catch (Exception ex)
            {
                errMsg = CommPhrases.SaveKpSettingsError + ":\r\n" + ex.Message;
                return false;
            }
        }
        
        /// <summary>
        /// Получить имя файла конфигурации
        /// </summary>
        public static string GetFileName(string configDir, int kpNum)
        {
            return configDir + "KpOpcUA_" + CommUtils.AddZeros(kpNum, 3) + ".xml";
        }
    }
}

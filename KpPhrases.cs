/*
 * Made by Syndrome5 - 2018
 * Need to be updated
 */

namespace Scada.Comm.Devices.KpOpcUA
{
    /// <summary>
    /// Фразы, используемые библиотекой
    /// </summary>
    internal static class KpPhrases
    {
        static KpPhrases()
        {
            SetToDefault();
        }

        public static string DataItemsNode { get; private set; }
        public static string EventsNode { get; private set; }
        public static string DataReadNode { get; private set; }
        public static string DataWriteNode { get; private set; }
        public static string DefGrName { get; private set; }
        public static string DisposeServersError { get; private set; }
        public static string SelectServer { get; private set; }
        public static string NoServers { get; private set; }
        public static string RefreshServersError { get; private set; }
        public static string ReqSpecNotSupported { get; private set; }
        public static string ConnectServerError { get; private set; }
        public static string DisconnectServerError { get; private set; }
        public static string BrowseServerError { get; private set; }
        public static string BrowseDataError { get; private set; }
        public static string BrowseEventsError { get; private set; }
        public static string ReceiveDataFailed { get; private set; }
        public static string CheckItemTypeError { get; private set; }
        public static string GetItemTypeNameError { get; private set; }
        public static string ServerNotSelected { get; private set; }
        public static string EvCatExists { get; private set; }

        public static string TypeNotExists { get; private set; }

        private static void SetToDefault()
        {
            DataItemsNode = "Текущие данные";
            EventsNode = "События";
            DataReadNode = "Чтение данных";
            DataWriteNode = "Запись данных";
            DefGrName = "<Группа>";
            DisposeServersError = "Ошибка при очистке данных OPC-серверов";
            SelectServer = "<Выберите сервер>";
            NoServers = "<Доступные сервера отсутствуют>";
            RefreshServersError = "Ошибка при обновлении списка OPC-серверов";
            ReqSpecNotSupported = "Требуемые спецификации не поддерживатся.";
            ConnectServerError = "Ошибка при соединении с OPC-сервером";
            DisconnectServerError = "Ошибка при разъединении с OPC-сервером";
            BrowseServerError = "Ошибка при обзоре элементов OPC-сервера";
            BrowseDataError = "Ошибка при обзоре узла текущих данных";
            BrowseEventsError = "Ошибка при обзоре узла событий";
            ReceiveDataFailed = "Не удалось получить данные от OPC-сервера.";
            CheckItemTypeError = "Ошибка при проверке типа тега";
            GetItemTypeNameError = "Ошибка при получении имени типа тега";
            ServerNotSelected = "Выберите OPC-сервер";
            EvCatExists = "Выбранная категория событий уже содержится в группе.";

            TypeNotExists = "Тип не существует.";
        }

        public static void Init()
        {
            Localization.Dict dict;
            if (Localization.Dictionaries.TryGetValue("Scada.Comm.Devices.KpOpcUA.FrmConfig", out dict))
            {
                DataItemsNode = dict.GetPhrase("DataItemsNode", DataItemsNode);
                EventsNode = dict.GetPhrase("EventsNode", EventsNode);
                DataReadNode = dict.GetPhrase("DataReadNode", DataReadNode);
                DataWriteNode = dict.GetPhrase("DataWriteNode", DataWriteNode);
                DefGrName = dict.GetPhrase("DefGrName", DefGrName);
                DisposeServersError = dict.GetPhrase("DisposeServersError", DisposeServersError);
                SelectServer = dict.GetPhrase("SelectServer", SelectServer);
                NoServers = dict.GetPhrase("NoServers", NoServers);
                RefreshServersError = dict.GetPhrase("RefreshServersError", RefreshServersError);
                ReqSpecNotSupported = dict.GetPhrase("ReqSpecNotSupported", ReqSpecNotSupported);
                ConnectServerError = dict.GetPhrase("ConnectServerError", ConnectServerError);
                DisconnectServerError = dict.GetPhrase("DisconnectServerError", DisconnectServerError);
                BrowseServerError = dict.GetPhrase("BrowseServerError", BrowseServerError);
                BrowseDataError = dict.GetPhrase("BrowseDataError", BrowseDataError);
                BrowseEventsError = dict.GetPhrase("BrowseEventsError", BrowseEventsError);
                ReceiveDataFailed = dict.GetPhrase("ReceiveDataFailed", ReceiveDataFailed);
                CheckItemTypeError = dict.GetPhrase("CheckItemTypeError", CheckItemTypeError);
                GetItemTypeNameError = dict.GetPhrase("GetItemTypeNameError", GetItemTypeNameError);
                ServerNotSelected = dict.GetPhrase("ServerNotSelected", ServerNotSelected);
                EvCatExists = dict.GetPhrase("EvCatExists", EvCatExists);
            }

            if (Localization.Dictionaries.TryGetValue("Scada.Comm.Devices.KpOpcUA.FrmItemType", out dict))
                TypeNotExists = dict.GetPhrase("TypeNotExists", TypeNotExists);
        }
    }
}

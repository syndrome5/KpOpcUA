/*
 * Made by Syndrome5 - 2018
 */

using Scada.Comm.Devices.KpOpcUA;
using Scada.Data.Configuration;
using System;
using System.Collections.Generic;
using System.IO;

namespace Scada.Comm.Devices
{
    /// <summary>
    /// Работа с пользовательским интерфейсом КП
    /// </summary>
    public class KpOpcUAView : KPView
    {
        /// <summary>
        /// Версия библиотеки КП
        /// </summary>
        internal const string KpVersion = "1.0.0.0";


        /// <summary>
        /// Конструктор для общей настройки библиотеки КП
        /// </summary>
        public KpOpcUAView()
            : this(0)
        {
        }

        /// <summary>
        /// Конструктор для настройки конкретного КП
        /// </summary>
        public KpOpcUAView(int number)
            : base(number)
        {
            CanShowProps = number > 0;
        }


        /// <summary>
        /// Описание библиотеки КП
        /// </summary>
        public override string KPDescr
        {
            get
            {
                return Localization.UseRussian ? 
                    "Взаимодействие с контроллерами по спецификации OPC UA.\n\n" +
                    "Команды ТУ:\n" +
                    "определяются конфигурацией КП (стандартные и бинарные)." :

                    "Interacting with controllers using OPC UA specification.\n\n" +
                    "Commands:\n" +
                    "defined by device configuration (standard or binary).";
            }
        }

        /// <summary>
        /// Получить версию библиотеки КП
        /// </summary>
        public override string Version
        {
            get
            {
                return KpVersion;
            }
        }

        /// <summary>
        /// Получить прототипы каналов КП по умолчанию
        /// </summary>
        public override KPCnlPrototypes DefaultCnls
        {
            get
            {
                // получение имени файла конфигурации КП
                string fileName = Config.GetFileName(AppDirs.ConfigDir, Number);
                if (!File.Exists(fileName))
                    return null;

                // загрузка конфигурации КП
                string errMsg;
                Config config = new Config();
                if (!config.Load(fileName, out errMsg))
                    throw new Exception(errMsg);

                // создание прототипов каналов КП
                KPCnlPrototypes prototypes = new KPCnlPrototypes();
                List<InCnlPrototype> inCnls = prototypes.InCnls;
                List<CtrlCnlPrototype> ctrlCnls = prototypes.CtrlCnls;

                // создание прототипов входных каналов
                foreach (Config.DataGroup dataGroup in config.DataGroups)
                {
                    foreach (Config.DataItem dataItem in dataGroup.DataItems)
                    {
                        /*string tagNamePrefix = string.IsNullOrEmpty(dataItem.Name) ?
                            (Localization.UseRussian ? "Безымянный тег" : "Unnamed tag") : dataItem.Name;
                        int tagCntByItem = dataItem.IsArray && dataItem.ArrayLen > 0 ? dataItem.ArrayLen : 1;

                        for (int k = 0; k < tagCntByItem; k++)
                        {
                            if (dataItem.CnlNum <= 0)
                            {
                                string tagName = dataItem.IsArray ? tagNamePrefix + "[" + k + "]" : tagNamePrefix;
                                inCnls.Add(new InCnlPrototype(tagName, BaseValues.CnlTypes.TI) { Signal = signal });
                            }
                            signal++;
                        } TODO*/

                    }
                }

                // создание прототипов каналов управления
                foreach (Config.Command cmd in config.Commands)
                {
                    bool isArray = cmd.TypeName.EndsWith("[]", StringComparison.OrdinalIgnoreCase);
                    ctrlCnls.Add(new CtrlCnlPrototype(cmd.ItemName,
                        isArray ? BaseValues.CmdTypes.Binary : BaseValues.CmdTypes.Standard) { CmdNum = cmd.CmdNum });
                }

                return prototypes;
            }
        }

        /// <summary>
        /// Получить параметры опроса КП по умолчанию
        /// </summary>
        public override KPReqParams DefaultReqParams
        {
            get
            {
                return KPReqParams.Zero;
            }
        }


        /// <summary>
        /// Отобразить свойства КП
        /// </summary>
        public override void ShowProps()
        {
            FrmConfig form = new FrmConfig();
            form.ConfigDir = AppDirs.ConfigDir;
            form.LangDir = AppDirs.LangDir;
            form.KPNum = Number;
            form.ShowDialog();
        }
    }
}

/*
 * Библиотека для взаимодействия с контроллерами по спецификации OPC
 * Элемент управления для редактирования свойств команды на запись данных
 * 
 * Разработчик:
 * 2012, 2016, Ширяев Михаил
 */

using Scada.UI;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Scada.Comm.Devices.KpOpcUA
{
    /// <summary>
    /// Элемент управления для редактирования свойств команды на запись данных
    /// </summary>
    internal partial class CtrlCommandProps : UserControl
    {
        private Config.Command command;


        /// <summary>
        /// Конструктор
        /// </summary>
        public CtrlCommandProps()
        {
            InitializeComponent();
            command = null;
        }


        /// <summary>
        /// Получить или установить редактируемый объект
        /// </summary>
        public Config.Command Command
        {
            get
            {
                return command;
            }
            set
            {
                if (value != null)
                {
                    command = null; // чтобы не вызывалось событие PropsChanged
                    txtCmdItemName.Text = value.ItemName;
                    txtItemPath.Text = value.ItemPath;
                    txtTypeName.Text = value.TypeName;
                    numCmdNum.SetValue(value.CmdNum);
                }

                command = value;
            }
        }

        /// <summary>
        /// Вызвать событие PropsChanged
        /// </summary>
        private void OnPropsChanged(EventArgs e)
        {
            if (PropsChanged != null)
                PropsChanged(this, e);
        }

        /// <summary>
        /// Событие возникающее при изменении свойств редактируемого объекта
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler PropsChanged;


        private void numCmdNum_ValueChanged(object sender, EventArgs e)
        {
            if (command != null)
            {
                command.CmdNum = Convert.ToInt32(numCmdNum.Value);
                OnPropsChanged(EventArgs.Empty);
            }
        }
    }
}

/*
 * Библиотека для взаимодействия с контроллерами по спецификации OPC
 * Элемент управления для редактирования свойств тега для чтения данных
 * 
 * Разработчик:
 * 2012, 2014, 2016, Ширяев Михаил
 */

using Scada.UI;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Scada.Comm.Devices.KpOpcUA
{
    /// <summary>
    /// Элемент управления для редактирования свойств тега для чтения данных
    /// </summary>
    internal partial class CtrlDataItemProps : UserControl
    {
        private Config.DataItem dataItem;


        /// <summary>
        /// Конструктор
        /// </summary>
        public CtrlDataItemProps()
        {
            InitializeComponent();
            dataItem = null;
        }


        /// <summary>
        /// Получить или установить редактируемый объект
        /// </summary>
        public Config.DataItem DataItem
        {
            get
            {
                return dataItem;
            }
            set
            {
                if (value != null)
                {
                    dataItem = null; // чтобы не вызывалось событие PropsChanged
                    txtName.Text = value.Name;
                    //txtPath.Text = value.Path; TODO
                    chkDataItemActive.Checked = value.Active;
                    //chkIsArray.Checked = value.IsArray;

                    /*if (value.IsArray)
                    {
                        lblArrayLen.Visible = numArrayLen.Visible = true;
                        numArrayLen.SetValue(value.ArrayLen);
                        lblCnlNum.Visible = false;
                        lblStartCnlNum.Visible = true;
                    }
                    else*/
                    {
                        lblArrayLen.Visible = numArrayLen.Visible = false;
                        lblCnlNum.Visible = true;
                        lblStartCnlNum.Visible = false;
                    }

                    //numCnlNum.SetValue(value.CnlNum);
                    //SetSignalText(value.Signal, value.ArrayLen);
                }

                dataItem = value;
            }
        }

        /// <summary>
        /// Установить текст, описывающий сигнал КП
        /// </summary>
        private void SetSignalText(int signal, int tagCnt)
        {
            txtSignal.Text = tagCnt <= 1 ? signal.ToString() : signal + " - " + (signal + tagCnt - 1);
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


        private void chkActive_CheckedChanged(object sender, EventArgs e)
        {
            if (dataItem != null)
            {
                dataItem.Active = chkDataItemActive.Checked;
                OnPropsChanged(EventArgs.Empty);
            }
        }
    }
}

/*
 * Библиотека для взаимодействия с контроллерами по спецификации OPC
 * Элемент управления для редактирования свойств группы чтения данных
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
    /// Элемент управления для редактирования свойств группы чтения данных
    /// </summary>
    internal partial class CtrlDataGroupProps : UserControl
    {
        private Config.DataGroup dataGroup;


        /// <summary>
        /// Конструктор
        /// </summary>
        public CtrlDataGroupProps()
        {
            InitializeComponent();

            DataGroup = null;
            PropsChanged = null;
        }


        /// <summary>
        /// Получить или установить редактируемый объект
        /// </summary>
        public Config.DataGroup DataGroup
        {
            get
            {
                return dataGroup;
            }
            set
            {
                if (value != null)
                {
                    dataGroup = null; // чтобы не вызывалось событие PropsChanged
                    txtName.Text = value.Name;
                    chkDataGrActive.Checked = value.Active; // TODO
                    //numUpdateRate.SetValue(value.UpdateRate);
                    //numDeadband.SetValue(Convert.ToDecimal(value.Deadband));
                }

                dataGroup = value;
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

        /// <summary>
        /// Установить фокус ввода
        /// </summary>
        public void SetFocus()
        {
            txtName.Select();
        }


        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (dataGroup != null)
            {
                dataGroup.Name = txtName.Text;
                OnPropsChanged(EventArgs.Empty);
            }
        }

        private void chkActive_CheckedChanged(object sender, EventArgs e)
        {
            if (dataGroup != null)
            {
                dataGroup.Active = chkDataGrActive.Checked;
                OnPropsChanged(EventArgs.Empty);
            }
        }

        private void numUpdateRate_ValueChanged(object sender, EventArgs e)
        {
            if (dataGroup != null)
            {// TODO
                //dataGroup.UpdateRate = Convert.ToInt32(numUpdateRate.Value);
                OnPropsChanged(EventArgs.Empty);
            }
        }

        private void numDeadband_ValueChanged(object sender, EventArgs e)
        {
            if (dataGroup != null)
            { // TODO
                //dataGroup.Deadband = Convert.ToDouble(numDeadband.Value);
                OnPropsChanged(EventArgs.Empty);
            }
        }
    }
}

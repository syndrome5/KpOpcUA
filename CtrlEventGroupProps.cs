/*
 * Библиотека для взаимодействия с контроллерами по спецификации OPC
 * Элемент управления для редактирования свойств группы приёма событий
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
    /// Элемент управления для редактирования свойств группы приёма событий
    /// </summary>
    internal partial class CtrlEventGroupProps : UserControl
    {
        private Config.EventGroup eventGroup;


        /// <summary>
        /// Конструктор
        /// </summary>
        public CtrlEventGroupProps()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Получить или установить редактируемый объект
        /// </summary>
        public Config.EventGroup EventGroup
        {
            get
            {
                return eventGroup;
            }
            set
            {
                if (value != null)
                {
                    eventGroup = null; // чтобы не вызывалось событие PropsChanged
                    txtName.Text = value.Name;
                    numUpdateRate.SetValue(value.UpdateRate);
                    numMaxSize.SetValue(value.MaxSize);
                    chkSimpleEvents.Checked = value.SimpleEvents;
                    chkTrackingEvents.Checked = value.TrackingEvents;
                    chkConditionEvents.Checked = value.ConditionEvents;
                    numHighSeverity.SetValue(value.HighSeverity);
                    numLowSeverity.SetValue(value.LowSeverity);
                }

                eventGroup = value;
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
            if (eventGroup != null)
            {
                eventGroup.Name = txtName.Text;
                OnPropsChanged(EventArgs.Empty);
            }
        }

        private void numUpdateRate_ValueChanged(object sender, EventArgs e)
        {
            if (eventGroup != null)
            {
                eventGroup.UpdateRate = Convert.ToInt32(numUpdateRate.Value);
                OnPropsChanged(EventArgs.Empty);
            }
        }

        private void numMaxSize_ValueChanged(object sender, EventArgs e)
        {
            if (eventGroup != null)
            {
                eventGroup.MaxSize = Convert.ToInt32(numMaxSize.Value);
                OnPropsChanged(EventArgs.Empty);
            }
        }

        private void chkSimpleEvents_CheckedChanged(object sender, EventArgs e)
        {
            if (eventGroup != null)
            {
                eventGroup.SimpleEvents = chkSimpleEvents.Checked;
                OnPropsChanged(EventArgs.Empty);
            }
        }

        private void chkTrackingEvents_CheckedChanged(object sender, EventArgs e)
        {
            if (eventGroup != null)
            {
                eventGroup.TrackingEvents = chkTrackingEvents.Checked;
                OnPropsChanged(EventArgs.Empty);
            }
        }

        private void chkConditionEvents_CheckedChanged(object sender, EventArgs e)
        {
            if (eventGroup != null)
            {
                eventGroup.ConditionEvents = chkConditionEvents.Checked;
                OnPropsChanged(EventArgs.Empty);
            }
        }

        private void numHighSeverity_ValueChanged(object sender, EventArgs e)
        {
            if (eventGroup != null)
            {
                if (numHighSeverity.Value < numLowSeverity.Value)
                {
                    numHighSeverity.ValueChanged -= numHighSeverity_ValueChanged;
                    numHighSeverity.Value = numLowSeverity.Value;
                    numHighSeverity.ValueChanged += numHighSeverity_ValueChanged;
                }

                eventGroup.HighSeverity = Convert.ToInt32(numHighSeverity.Value);
                OnPropsChanged(EventArgs.Empty);
            }
        }

        private void numLowSeverity_ValueChanged(object sender, EventArgs e)
        {
            if (eventGroup != null)
            {
                if (numLowSeverity.Value > numHighSeverity.Value)
                {
                    numLowSeverity.ValueChanged -= numLowSeverity_ValueChanged;
                    numLowSeverity.Value = numHighSeverity.Value;
                    numLowSeverity.ValueChanged += numLowSeverity_ValueChanged;
                }

                eventGroup.LowSeverity = Convert.ToInt32(numLowSeverity.Value);
                OnPropsChanged(EventArgs.Empty);
            }
        }

        private void CtrlEventGroupProps_Load(object sender, EventArgs e)
        {

        }
    }
}

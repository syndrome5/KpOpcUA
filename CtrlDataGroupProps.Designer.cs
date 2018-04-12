namespace Scada.Comm.Devices.KpOpcUA
{
    partial class CtrlDataGroupProps
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.numDeadband = new System.Windows.Forms.NumericUpDown();
            this.lblDeadband = new System.Windows.Forms.Label();
            this.numUpdateRate = new System.Windows.Forms.NumericUpDown();
            this.lblDataGrUpdateRate = new System.Windows.Forms.Label();
            this.chkDataGrActive = new System.Windows.Forms.CheckBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblDataGrName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numDeadband)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpdateRate)).BeginInit();
            this.SuspendLayout();
            // 
            // numDeadband
            // 
            this.numDeadband.DecimalPlaces = 2;
            this.numDeadband.Location = new System.Drawing.Point(6, 117);
            this.numDeadband.Name = "numDeadband";
            this.numDeadband.Size = new System.Drawing.Size(130, 20);
            this.numDeadband.TabIndex = 6;
            this.numDeadband.ValueChanged += new System.EventHandler(this.numDeadband_ValueChanged);
            // 
            // lblDeadband
            // 
            this.lblDeadband.AutoSize = true;
            this.lblDeadband.Location = new System.Drawing.Point(3, 101);
            this.lblDeadband.Name = "lblDeadband";
            this.lblDeadband.Size = new System.Drawing.Size(92, 13);
            this.lblDeadband.TabIndex = 5;
            this.lblDeadband.Text = "Мёртвая зона, %";
            // 
            // numUpdateRate
            // 
            this.numUpdateRate.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numUpdateRate.Location = new System.Drawing.Point(6, 78);
            this.numUpdateRate.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.numUpdateRate.Name = "numUpdateRate";
            this.numUpdateRate.Size = new System.Drawing.Size(130, 20);
            this.numUpdateRate.TabIndex = 4;
            this.numUpdateRate.ValueChanged += new System.EventHandler(this.numUpdateRate_ValueChanged);
            // 
            // lblDataGrUpdateRate
            // 
            this.lblDataGrUpdateRate.AutoSize = true;
            this.lblDataGrUpdateRate.Location = new System.Drawing.Point(3, 62);
            this.lblDataGrUpdateRate.Name = "lblDataGrUpdateRate";
            this.lblDataGrUpdateRate.Size = new System.Drawing.Size(132, 13);
            this.lblDataGrUpdateRate.TabIndex = 3;
            this.lblDataGrUpdateRate.Text = "Частота обновления, мс";
            // 
            // chkDataGrActive
            // 
            this.chkDataGrActive.AutoSize = true;
            this.chkDataGrActive.Location = new System.Drawing.Point(6, 42);
            this.chkDataGrActive.Name = "chkDataGrActive";
            this.chkDataGrActive.Size = new System.Drawing.Size(85, 17);
            this.chkDataGrActive.TabIndex = 2;
            this.chkDataGrActive.Text = "Активность";
            this.chkDataGrActive.UseVisualStyleBackColor = true;
            this.chkDataGrActive.CheckedChanged += new System.EventHandler(this.chkActive_CheckedChanged);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(6, 16);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 20);
            this.txtName.TabIndex = 1;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // lblDataGrName
            // 
            this.lblDataGrName.AutoSize = true;
            this.lblDataGrName.Location = new System.Drawing.Point(3, 0);
            this.lblDataGrName.Name = "lblDataGrName";
            this.lblDataGrName.Size = new System.Drawing.Size(83, 13);
            this.lblDataGrName.TabIndex = 0;
            this.lblDataGrName.Text = "Наименование";
            // 
            // CtrlDataGroupProps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numDeadband);
            this.Controls.Add(this.lblDeadband);
            this.Controls.Add(this.numUpdateRate);
            this.Controls.Add(this.lblDataGrUpdateRate);
            this.Controls.Add(this.chkDataGrActive);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblDataGrName);
            this.Name = "CtrlDataGroupProps";
            this.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.Size = new System.Drawing.Size(206, 250);
            ((System.ComponentModel.ISupportInitialize)(this.numDeadband)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpdateRate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numDeadband;
        private System.Windows.Forms.Label lblDeadband;
        private System.Windows.Forms.NumericUpDown numUpdateRate;
        private System.Windows.Forms.Label lblDataGrUpdateRate;
        private System.Windows.Forms.CheckBox chkDataGrActive;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblDataGrName;
    }
}

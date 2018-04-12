namespace Scada.Comm.Devices.KpOpcUA
{
    partial class CtrlEventGroupProps
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
            this.numUpdateRate = new System.Windows.Forms.NumericUpDown();
            this.lblEvGrUpdateRate = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblEvGrName = new System.Windows.Forms.Label();
            this.numMaxSize = new System.Windows.Forms.NumericUpDown();
            this.lblMaxSize = new System.Windows.Forms.Label();
            this.chkSimpleEvents = new System.Windows.Forms.CheckBox();
            this.chkTrackingEvents = new System.Windows.Forms.CheckBox();
            this.chkConditionEvents = new System.Windows.Forms.CheckBox();
            this.numLowSeverity = new System.Windows.Forms.NumericUpDown();
            this.lblLowSeverity = new System.Windows.Forms.Label();
            this.numHighSeverity = new System.Windows.Forms.NumericUpDown();
            this.lblHighSeverity = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numUpdateRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLowSeverity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHighSeverity)).BeginInit();
            this.SuspendLayout();
            // 
            // numUpdateRate
            // 
            this.numUpdateRate.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numUpdateRate.Location = new System.Drawing.Point(6, 55);
            this.numUpdateRate.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.numUpdateRate.Name = "numUpdateRate";
            this.numUpdateRate.Size = new System.Drawing.Size(130, 20);
            this.numUpdateRate.TabIndex = 3;
            this.numUpdateRate.ValueChanged += new System.EventHandler(this.numUpdateRate_ValueChanged);
            // 
            // lblEvGrUpdateRate
            // 
            this.lblEvGrUpdateRate.AutoSize = true;
            this.lblEvGrUpdateRate.Location = new System.Drawing.Point(3, 39);
            this.lblEvGrUpdateRate.Name = "lblEvGrUpdateRate";
            this.lblEvGrUpdateRate.Size = new System.Drawing.Size(132, 13);
            this.lblEvGrUpdateRate.TabIndex = 2;
            this.lblEvGrUpdateRate.Text = "Частота обновления, мс";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(6, 16);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 20);
            this.txtName.TabIndex = 1;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // lblEvGrName
            // 
            this.lblEvGrName.AutoSize = true;
            this.lblEvGrName.Location = new System.Drawing.Point(3, 0);
            this.lblEvGrName.Name = "lblEvGrName";
            this.lblEvGrName.Size = new System.Drawing.Size(83, 13);
            this.lblEvGrName.TabIndex = 0;
            this.lblEvGrName.Text = "Наименование";
            // 
            // numMaxSize
            // 
            this.numMaxSize.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numMaxSize.Location = new System.Drawing.Point(6, 94);
            this.numMaxSize.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numMaxSize.Name = "numMaxSize";
            this.numMaxSize.Size = new System.Drawing.Size(130, 20);
            this.numMaxSize.TabIndex = 5;
            this.numMaxSize.ValueChanged += new System.EventHandler(this.numMaxSize_ValueChanged);
            // 
            // lblMaxSize
            // 
            this.lblMaxSize.AutoSize = true;
            this.lblMaxSize.Location = new System.Drawing.Point(3, 78);
            this.lblMaxSize.Name = "lblMaxSize";
            this.lblMaxSize.Size = new System.Drawing.Size(78, 13);
            this.lblMaxSize.TabIndex = 4;
            this.lblMaxSize.Text = "Макс. размер";
            // 
            // chkSimpleEvents
            // 
            this.chkSimpleEvents.AutoSize = true;
            this.chkSimpleEvents.Location = new System.Drawing.Point(6, 120);
            this.chkSimpleEvents.Name = "chkSimpleEvents";
            this.chkSimpleEvents.Size = new System.Drawing.Size(117, 17);
            this.chkSimpleEvents.TabIndex = 6;
            this.chkSimpleEvents.Text = "Простые события";
            this.chkSimpleEvents.UseVisualStyleBackColor = true;
            this.chkSimpleEvents.CheckedChanged += new System.EventHandler(this.chkSimpleEvents_CheckedChanged);
            // 
            // chkTrackingEvents
            // 
            this.chkTrackingEvents.AutoSize = true;
            this.chkTrackingEvents.Location = new System.Drawing.Point(6, 143);
            this.chkTrackingEvents.Name = "chkTrackingEvents";
            this.chkTrackingEvents.Size = new System.Drawing.Size(146, 17);
            this.chkTrackingEvents.TabIndex = 7;
            this.chkTrackingEvents.Text = "События отслеживания";
            this.chkTrackingEvents.UseVisualStyleBackColor = true;
            this.chkTrackingEvents.CheckedChanged += new System.EventHandler(this.chkTrackingEvents_CheckedChanged);
            // 
            // chkConditionEvents
            // 
            this.chkConditionEvents.AutoSize = true;
            this.chkConditionEvents.Location = new System.Drawing.Point(6, 166);
            this.chkConditionEvents.Name = "chkConditionEvents";
            this.chkConditionEvents.Size = new System.Drawing.Size(143, 17);
            this.chkConditionEvents.TabIndex = 8;
            this.chkConditionEvents.Text = "События по состоянию";
            this.chkConditionEvents.UseVisualStyleBackColor = true;
            this.chkConditionEvents.CheckedChanged += new System.EventHandler(this.chkConditionEvents_CheckedChanged);
            // 
            // numLowSeverity
            // 
            this.numLowSeverity.Location = new System.Drawing.Point(6, 241);
            this.numLowSeverity.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numLowSeverity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numLowSeverity.Name = "numLowSeverity";
            this.numLowSeverity.Size = new System.Drawing.Size(130, 20);
            this.numLowSeverity.TabIndex = 12;
            this.numLowSeverity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numLowSeverity.ValueChanged += new System.EventHandler(this.numLowSeverity_ValueChanged);
            // 
            // lblLowSeverity
            // 
            this.lblLowSeverity.AutoSize = true;
            this.lblLowSeverity.Location = new System.Drawing.Point(3, 225);
            this.lblLowSeverity.Name = "lblLowSeverity";
            this.lblLowSeverity.Size = new System.Drawing.Size(99, 13);
            this.lblLowSeverity.TabIndex = 11;
            this.lblLowSeverity.Text = "Мин. серьёзность";
            // 
            // numHighSeverity
            // 
            this.numHighSeverity.Location = new System.Drawing.Point(6, 202);
            this.numHighSeverity.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numHighSeverity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numHighSeverity.Name = "numHighSeverity";
            this.numHighSeverity.Size = new System.Drawing.Size(130, 20);
            this.numHighSeverity.TabIndex = 10;
            this.numHighSeverity.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numHighSeverity.ValueChanged += new System.EventHandler(this.numHighSeverity_ValueChanged);
            // 
            // lblHighSeverity
            // 
            this.lblHighSeverity.AutoSize = true;
            this.lblHighSeverity.Location = new System.Drawing.Point(3, 186);
            this.lblHighSeverity.Name = "lblHighSeverity";
            this.lblHighSeverity.Size = new System.Drawing.Size(105, 13);
            this.lblHighSeverity.TabIndex = 9;
            this.lblHighSeverity.Text = "Макс. серьёзность";
            // 
            // CtrlEventGroupProps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numLowSeverity);
            this.Controls.Add(this.lblLowSeverity);
            this.Controls.Add(this.numHighSeverity);
            this.Controls.Add(this.lblHighSeverity);
            this.Controls.Add(this.chkConditionEvents);
            this.Controls.Add(this.chkTrackingEvents);
            this.Controls.Add(this.chkSimpleEvents);
            this.Controls.Add(this.numMaxSize);
            this.Controls.Add(this.lblMaxSize);
            this.Controls.Add(this.numUpdateRate);
            this.Controls.Add(this.lblEvGrUpdateRate);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblEvGrName);
            this.Name = "CtrlEventGroupProps";
            this.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.Size = new System.Drawing.Size(206, 280);
            this.Load += new System.EventHandler(this.CtrlEventGroupProps_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numUpdateRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLowSeverity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHighSeverity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numUpdateRate;
        private System.Windows.Forms.Label lblEvGrUpdateRate;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblEvGrName;
        private System.Windows.Forms.NumericUpDown numMaxSize;
        private System.Windows.Forms.Label lblMaxSize;
        private System.Windows.Forms.CheckBox chkSimpleEvents;
        private System.Windows.Forms.CheckBox chkTrackingEvents;
        private System.Windows.Forms.CheckBox chkConditionEvents;
        private System.Windows.Forms.NumericUpDown numLowSeverity;
        private System.Windows.Forms.Label lblLowSeverity;
        private System.Windows.Forms.NumericUpDown numHighSeverity;
        private System.Windows.Forms.Label lblHighSeverity;
    }
}

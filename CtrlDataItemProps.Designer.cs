namespace Scada.Comm.Devices.KpOpcUA
{
    partial class CtrlDataItemProps
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
            this.numArrayLen = new System.Windows.Forms.NumericUpDown();
            this.lblSignal = new System.Windows.Forms.Label();
            this.txtSignal = new System.Windows.Forms.TextBox();
            this.numCnlNum = new System.Windows.Forms.NumericUpDown();
            this.lblCnlNum = new System.Windows.Forms.Label();
            this.chkIsArray = new System.Windows.Forms.CheckBox();
            this.chkDataItemActive = new System.Windows.Forms.CheckBox();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.lblDataItemPath = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblDataItemName = new System.Windows.Forms.Label();
            this.lblStartCnlNum = new System.Windows.Forms.Label();
            this.lblArrayLen = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numArrayLen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCnlNum)).BeginInit();
            this.SuspendLayout();
            // 
            // numArrayLen
            // 
            this.numArrayLen.Location = new System.Drawing.Point(116, 102);
            this.numArrayLen.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numArrayLen.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numArrayLen.Name = "numArrayLen";
            this.numArrayLen.Size = new System.Drawing.Size(90, 20);
            this.numArrayLen.TabIndex = 7;
            this.numArrayLen.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblSignal
            // 
            this.lblSignal.AutoSize = true;
            this.lblSignal.Location = new System.Drawing.Point(113, 125);
            this.lblSignal.Name = "lblSignal";
            this.lblSignal.Size = new System.Drawing.Size(61, 13);
            this.lblSignal.TabIndex = 11;
            this.lblSignal.Text = "Сигнал КП";
            // 
            // txtSignal
            // 
            this.txtSignal.Location = new System.Drawing.Point(116, 141);
            this.txtSignal.Name = "txtSignal";
            this.txtSignal.ReadOnly = true;
            this.txtSignal.Size = new System.Drawing.Size(90, 20);
            this.txtSignal.TabIndex = 12;
            // 
            // numCnlNum
            // 
            this.numCnlNum.Location = new System.Drawing.Point(6, 141);
            this.numCnlNum.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numCnlNum.Name = "numCnlNum";
            this.numCnlNum.Size = new System.Drawing.Size(104, 20);
            this.numCnlNum.TabIndex = 10;
            // 
            // lblCnlNum
            // 
            this.lblCnlNum.AutoSize = true;
            this.lblCnlNum.Location = new System.Drawing.Point(3, 125);
            this.lblCnlNum.Name = "lblCnlNum";
            this.lblCnlNum.Size = new System.Drawing.Size(38, 13);
            this.lblCnlNum.TabIndex = 8;
            this.lblCnlNum.Text = "Канал";
            // 
            // chkIsArray
            // 
            this.chkIsArray.AutoCheck = false;
            this.chkIsArray.AutoSize = true;
            this.chkIsArray.Location = new System.Drawing.Point(6, 104);
            this.chkIsArray.Name = "chkIsArray";
            this.chkIsArray.Size = new System.Drawing.Size(65, 17);
            this.chkIsArray.TabIndex = 5;
            this.chkIsArray.Text = "Массив";
            this.chkIsArray.UseVisualStyleBackColor = true;
            // 
            // chkDataItemActive
            // 
            this.chkDataItemActive.AutoSize = true;
            this.chkDataItemActive.Location = new System.Drawing.Point(6, 81);
            this.chkDataItemActive.Name = "chkDataItemActive";
            this.chkDataItemActive.Size = new System.Drawing.Size(85, 17);
            this.chkDataItemActive.TabIndex = 4;
            this.chkDataItemActive.Text = "Активность";
            this.chkDataItemActive.UseVisualStyleBackColor = true;
            this.chkDataItemActive.CheckedChanged += new System.EventHandler(this.chkActive_CheckedChanged);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(6, 55);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(200, 20);
            this.txtPath.TabIndex = 3;
            // 
            // lblDataItemPath
            // 
            this.lblDataItemPath.AutoSize = true;
            this.lblDataItemPath.Location = new System.Drawing.Point(3, 39);
            this.lblDataItemPath.Name = "lblDataItemPath";
            this.lblDataItemPath.Size = new System.Drawing.Size(31, 13);
            this.lblDataItemPath.TabIndex = 2;
            this.lblDataItemPath.Text = "Путь";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(6, 16);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(200, 20);
            this.txtName.TabIndex = 1;
            // 
            // lblDataItemName
            // 
            this.lblDataItemName.AutoSize = true;
            this.lblDataItemName.Location = new System.Drawing.Point(3, 0);
            this.lblDataItemName.Name = "lblDataItemName";
            this.lblDataItemName.Size = new System.Drawing.Size(83, 13);
            this.lblDataItemName.TabIndex = 0;
            this.lblDataItemName.Text = "Наименование";
            // 
            // lblStartCnlNum
            // 
            this.lblStartCnlNum.AutoSize = true;
            this.lblStartCnlNum.Location = new System.Drawing.Point(3, 125);
            this.lblStartCnlNum.Name = "lblStartCnlNum";
            this.lblStartCnlNum.Size = new System.Drawing.Size(97, 13);
            this.lblStartCnlNum.TabIndex = 9;
            this.lblStartCnlNum.Text = "Начальный канал";
            // 
            // lblArrayLen
            // 
            this.lblArrayLen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblArrayLen.AutoSize = true;
            this.lblArrayLen.Location = new System.Drawing.Point(75, 105);
            this.lblArrayLen.Name = "lblArrayLen";
            this.lblArrayLen.Size = new System.Drawing.Size(40, 13);
            this.lblArrayLen.TabIndex = 6;
            this.lblArrayLen.Text = "Длина";
            // 
            // CtrlDataItemProps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblArrayLen);
            this.Controls.Add(this.numArrayLen);
            this.Controls.Add(this.lblSignal);
            this.Controls.Add(this.txtSignal);
            this.Controls.Add(this.numCnlNum);
            this.Controls.Add(this.lblCnlNum);
            this.Controls.Add(this.chkIsArray);
            this.Controls.Add(this.chkDataItemActive);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.lblDataItemPath);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblDataItemName);
            this.Controls.Add(this.lblStartCnlNum);
            this.Name = "CtrlDataItemProps";
            this.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.Size = new System.Drawing.Size(206, 250);
            ((System.ComponentModel.ISupportInitialize)(this.numArrayLen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCnlNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numArrayLen;
        private System.Windows.Forms.Label lblSignal;
        private System.Windows.Forms.TextBox txtSignal;
        private System.Windows.Forms.NumericUpDown numCnlNum;
        private System.Windows.Forms.Label lblCnlNum;
        private System.Windows.Forms.CheckBox chkIsArray;
        private System.Windows.Forms.CheckBox chkDataItemActive;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label lblDataItemPath;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblDataItemName;
        private System.Windows.Forms.Label lblStartCnlNum;
        private System.Windows.Forms.Label lblArrayLen;
    }
}

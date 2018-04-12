namespace Scada.Comm.Devices.KpOpcUA
{
    partial class CtrlCommandProps
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
            this.txtItemPath = new System.Windows.Forms.TextBox();
            this.lblCmdItemPath = new System.Windows.Forms.Label();
            this.txtCmdItemName = new System.Windows.Forms.TextBox();
            this.lblCmdItemName = new System.Windows.Forms.Label();
            this.numCmdNum = new System.Windows.Forms.NumericUpDown();
            this.lblCmdNum = new System.Windows.Forms.Label();
            this.txtTypeName = new System.Windows.Forms.TextBox();
            this.lblTypeName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numCmdNum)).BeginInit();
            this.SuspendLayout();
            // 
            // txtItemPath
            // 
            this.txtItemPath.Location = new System.Drawing.Point(6, 55);
            this.txtItemPath.Name = "txtItemPath";
            this.txtItemPath.ReadOnly = true;
            this.txtItemPath.Size = new System.Drawing.Size(200, 20);
            this.txtItemPath.TabIndex = 3;
            // 
            // lblCmdItemPath
            // 
            this.lblCmdItemPath.AutoSize = true;
            this.lblCmdItemPath.Location = new System.Drawing.Point(3, 39);
            this.lblCmdItemPath.Name = "lblCmdItemPath";
            this.lblCmdItemPath.Size = new System.Drawing.Size(31, 13);
            this.lblCmdItemPath.TabIndex = 2;
            this.lblCmdItemPath.Text = "Путь";
            // 
            // txtCmdItemName
            // 
            this.txtCmdItemName.Location = new System.Drawing.Point(6, 16);
            this.txtCmdItemName.Name = "txtCmdItemName";
            this.txtCmdItemName.ReadOnly = true;
            this.txtCmdItemName.Size = new System.Drawing.Size(200, 20);
            this.txtCmdItemName.TabIndex = 1;
            // 
            // lblCmdItemName
            // 
            this.lblCmdItemName.AutoSize = true;
            this.lblCmdItemName.Location = new System.Drawing.Point(3, 0);
            this.lblCmdItemName.Name = "lblCmdItemName";
            this.lblCmdItemName.Size = new System.Drawing.Size(83, 13);
            this.lblCmdItemName.TabIndex = 0;
            this.lblCmdItemName.Text = "Наименование";
            // 
            // numCmdNum
            // 
            this.numCmdNum.Location = new System.Drawing.Point(6, 133);
            this.numCmdNum.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numCmdNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCmdNum.Name = "numCmdNum";
            this.numCmdNum.Size = new System.Drawing.Size(105, 20);
            this.numCmdNum.TabIndex = 7;
            this.numCmdNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCmdNum.ValueChanged += new System.EventHandler(this.numCmdNum_ValueChanged);
            // 
            // lblCmdNum
            // 
            this.lblCmdNum.AutoSize = true;
            this.lblCmdNum.Location = new System.Drawing.Point(3, 117);
            this.lblCmdNum.Name = "lblCmdNum";
            this.lblCmdNum.Size = new System.Drawing.Size(108, 13);
            this.lblCmdNum.TabIndex = 6;
            this.lblCmdNum.Text = "Номер команды КП";
            // 
            // txtTypeName
            // 
            this.txtTypeName.Location = new System.Drawing.Point(6, 94);
            this.txtTypeName.Name = "txtTypeName";
            this.txtTypeName.ReadOnly = true;
            this.txtTypeName.Size = new System.Drawing.Size(200, 20);
            this.txtTypeName.TabIndex = 5;
            // 
            // lblTypeName
            // 
            this.lblTypeName.AutoSize = true;
            this.lblTypeName.Location = new System.Drawing.Point(3, 78);
            this.lblTypeName.Name = "lblTypeName";
            this.lblTypeName.Size = new System.Drawing.Size(76, 13);
            this.lblTypeName.TabIndex = 4;
            this.lblTypeName.Text = "Тип значений";
            // 
            // CtrlCommandProps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtTypeName);
            this.Controls.Add(this.lblTypeName);
            this.Controls.Add(this.numCmdNum);
            this.Controls.Add(this.lblCmdNum);
            this.Controls.Add(this.txtItemPath);
            this.Controls.Add(this.lblCmdItemPath);
            this.Controls.Add(this.txtCmdItemName);
            this.Controls.Add(this.lblCmdItemName);
            this.Name = "CtrlCommandProps";
            this.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.Size = new System.Drawing.Size(206, 170);
            ((System.ComponentModel.ISupportInitialize)(this.numCmdNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtItemPath;
        private System.Windows.Forms.Label lblCmdItemPath;
        private System.Windows.Forms.TextBox txtCmdItemName;
        private System.Windows.Forms.Label lblCmdItemName;
        private System.Windows.Forms.NumericUpDown numCmdNum;
        private System.Windows.Forms.Label lblCmdNum;
        private System.Windows.Forms.TextBox txtTypeName;
        private System.Windows.Forms.Label lblTypeName;
    }
}

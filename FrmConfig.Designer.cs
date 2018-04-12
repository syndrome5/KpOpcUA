namespace Scada.Comm.Devices.KpOpcUA
{
    partial class FrmConfig
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConfig));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Чтение данных");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Запись данных");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("События");
            this.gbServer = new System.Windows.Forms.GroupBox();
            this.cbServer = new System.Windows.Forms.TextBox();
            this.UseSecurityCK = new System.Windows.Forms.CheckBox();
            this.btnRefrItems = new System.Windows.Forms.Button();
            this.lblServer = new System.Windows.Forms.Label();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.gbServerContent = new System.Windows.Forms.GroupBox();
            this.BrowseNodesTV = new System.Windows.Forms.TreeView();
            this.gbKP = new System.Windows.Forms.GroupBox();
            this.ctrlEventGroupProps = new Scada.Comm.Devices.KpOpcUA.CtrlEventGroupProps();
            this.ctrlCommandProps = new Scada.Comm.Devices.KpOpcUA.CtrlCommandProps();
            this.ctrlDataItemProps = new Scada.Comm.Devices.KpOpcUA.CtrlDataItemProps();
            this.ctrlDataGroupProps = new Scada.Comm.Devices.KpOpcUA.CtrlDataGroupProps();
            this.pnlNoProps = new System.Windows.Forms.Panel();
            this.lblNoProps = new System.Windows.Forms.Label();
            this.tvKP = new System.Windows.Forms.TreeView();
            this.AttributesLV = new System.Windows.Forms.ListView();
            this.AttributeNameCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AttributeDataTypeCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AttributeValueCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnConnect = new System.Windows.Forms.ToolStripButton();
            this.btnDisconnect = new System.Windows.Forms.ToolStripButton();
            this.sep1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCreateDataGroup = new System.Windows.Forms.ToolStripButton();
            this.btnCreateEventGroup = new System.Windows.Forms.ToolStripButton();
            this.btnAddElem = new System.Windows.Forms.ToolStripButton();
            this.btnMoveUp = new System.Windows.Forms.ToolStripButton();
            this.btnMoveDown = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.gbItem = new System.Windows.Forms.GroupBox();
            this.gbServer.SuspendLayout();
            this.gbServerContent.SuspendLayout();
            this.gbKP.SuspendLayout();
            this.pnlNoProps.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.gbItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbServer
            // 
            this.gbServer.Controls.Add(this.cbServer);
            this.gbServer.Controls.Add(this.UseSecurityCK);
            this.gbServer.Controls.Add(this.btnRefrItems);
            this.gbServer.Controls.Add(this.lblServer);
            this.gbServer.Location = new System.Drawing.Point(12, 28);
            this.gbServer.Name = "gbServer";
            this.gbServer.Padding = new System.Windows.Forms.Padding(10, 3, 10, 10);
            this.gbServer.Size = new System.Drawing.Size(904, 66);
            this.gbServer.TabIndex = 1;
            this.gbServer.TabStop = false;
            this.gbServer.Text = "OPC-сервер";
            // 
            // cbServer
            // 
            this.cbServer.Location = new System.Drawing.Point(14, 33);
            this.cbServer.Name = "cbServer";
            this.cbServer.Size = new System.Drawing.Size(743, 20);
            this.cbServer.TabIndex = 9;
            // 
            // UseSecurityCK
            // 
            this.UseSecurityCK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UseSecurityCK.AutoSize = true;
            this.UseSecurityCK.Checked = true;
            this.UseSecurityCK.CheckState = System.Windows.Forms.CheckState.Checked;
            this.UseSecurityCK.Location = new System.Drawing.Point(773, 36);
            this.UseSecurityCK.Name = "UseSecurityCK";
            this.UseSecurityCK.Size = new System.Drawing.Size(86, 17);
            this.UseSecurityCK.TabIndex = 8;
            this.UseSecurityCK.Text = "Use Security";
            this.UseSecurityCK.UseVisualStyleBackColor = true;
            // 
            // btnRefrItems
            // 
            this.btnRefrItems.Enabled = false;
            this.btnRefrItems.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefrItems.Image = ((System.Drawing.Image)(resources.GetObject("btnRefrItems.Image")));
            this.btnRefrItems.Location = new System.Drawing.Point(865, 32);
            this.btnRefrItems.Name = "btnRefrItems";
            this.btnRefrItems.Size = new System.Drawing.Size(23, 23);
            this.btnRefrItems.TabIndex = 6;
            this.btnRefrItems.UseVisualStyleBackColor = true;
            this.btnRefrItems.Click += new System.EventHandler(this.btnRefrItems_Click);
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Location = new System.Drawing.Point(10, 16);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(44, 13);
            this.lblServer.TabIndex = 0;
            this.lblServer.Text = "Сервер";
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "server.png");
            this.imageList.Images.SetKeyName(1, "folder_closed.png");
            this.imageList.Images.SetKeyName(2, "folder_open.png");
            this.imageList.Images.SetKeyName(3, "da_item.png");
            this.imageList.Images.SetKeyName(4, "da_item_viol.png");
            this.imageList.Images.SetKeyName(5, "ae_cat.png");
            // 
            // gbServerContent
            // 
            this.gbServerContent.Controls.Add(this.BrowseNodesTV);
            this.gbServerContent.Location = new System.Drawing.Point(12, 100);
            this.gbServerContent.Name = "gbServerContent";
            this.gbServerContent.Padding = new System.Windows.Forms.Padding(10, 3, 10, 10);
            this.gbServerContent.Size = new System.Drawing.Size(214, 381);
            this.gbServerContent.TabIndex = 2;
            this.gbServerContent.TabStop = false;
            this.gbServerContent.Text = "Обзор сервера";
            // 
            // BrowseNodesTV
            // 
            this.BrowseNodesTV.Location = new System.Drawing.Point(10, 16);
            this.BrowseNodesTV.Name = "BrowseNodesTV";
            this.BrowseNodesTV.Size = new System.Drawing.Size(191, 352);
            this.BrowseNodesTV.TabIndex = 1;
            this.BrowseNodesTV.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.BrowseNodesTV_BeforeExpand);
            this.BrowseNodesTV.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.BrowseNodesTV_AfterSelect);
            this.BrowseNodesTV.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BrowseNodesTV_MouseDown);
            // 
            // gbKP
            // 
            this.gbKP.Controls.Add(this.ctrlEventGroupProps);
            this.gbKP.Controls.Add(this.ctrlCommandProps);
            this.gbKP.Controls.Add(this.ctrlDataItemProps);
            this.gbKP.Controls.Add(this.ctrlDataGroupProps);
            this.gbKP.Controls.Add(this.pnlNoProps);
            this.gbKP.Controls.Add(this.tvKP);
            this.gbKP.Location = new System.Drawing.Point(478, 100);
            this.gbKP.Name = "gbKP";
            this.gbKP.Padding = new System.Windows.Forms.Padding(10, 3, 10, 10);
            this.gbKP.Size = new System.Drawing.Size(438, 381);
            this.gbKP.TabIndex = 3;
            this.gbKP.TabStop = false;
            this.gbKP.Text = "КП";
            // 
            // ctrlEventGroupProps
            // 
            this.ctrlEventGroupProps.EventGroup = null;
            this.ctrlEventGroupProps.Location = new System.Drawing.Point(219, 65);
            this.ctrlEventGroupProps.Name = "ctrlEventGroupProps";
            this.ctrlEventGroupProps.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.ctrlEventGroupProps.Size = new System.Drawing.Size(206, 280);
            this.ctrlEventGroupProps.TabIndex = 5;
            this.ctrlEventGroupProps.Visible = false;
            this.ctrlEventGroupProps.PropsChanged += new System.EventHandler(this.ctrlEventGroupProps_PropsChanged);
            // 
            // ctrlCommandProps
            // 
            this.ctrlCommandProps.Command = null;
            this.ctrlCommandProps.Location = new System.Drawing.Point(219, 65);
            this.ctrlCommandProps.Name = "ctrlCommandProps";
            this.ctrlCommandProps.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.ctrlCommandProps.Size = new System.Drawing.Size(206, 170);
            this.ctrlCommandProps.TabIndex = 4;
            this.ctrlCommandProps.Visible = false;
            this.ctrlCommandProps.PropsChanged += new System.EventHandler(this.ctrlCommandProps_PropsChanged);
            // 
            // ctrlDataItemProps
            // 
            this.ctrlDataItemProps.DataItem = null;
            this.ctrlDataItemProps.Location = new System.Drawing.Point(219, 65);
            this.ctrlDataItemProps.Name = "ctrlDataItemProps";
            this.ctrlDataItemProps.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.ctrlDataItemProps.Size = new System.Drawing.Size(206, 250);
            this.ctrlDataItemProps.TabIndex = 3;
            this.ctrlDataItemProps.Visible = false;
            this.ctrlDataItemProps.PropsChanged += new System.EventHandler(this.ctrlDataItemProps_PropsChanged);
            // 
            // ctrlDataGroupProps
            // 
            this.ctrlDataGroupProps.DataGroup = null;
            this.ctrlDataGroupProps.Location = new System.Drawing.Point(219, 65);
            this.ctrlDataGroupProps.Name = "ctrlDataGroupProps";
            this.ctrlDataGroupProps.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.ctrlDataGroupProps.Size = new System.Drawing.Size(206, 250);
            this.ctrlDataGroupProps.TabIndex = 2;
            this.ctrlDataGroupProps.Visible = false;
            this.ctrlDataGroupProps.PropsChanged += new System.EventHandler(this.ctrlDataGroupProps_PropsChanged);
            // 
            // pnlNoProps
            // 
            this.pnlNoProps.Controls.Add(this.lblNoProps);
            this.pnlNoProps.Location = new System.Drawing.Point(219, 19);
            this.pnlNoProps.Name = "pnlNoProps";
            this.pnlNoProps.Size = new System.Drawing.Size(206, 40);
            this.pnlNoProps.TabIndex = 1;
            // 
            // lblNoProps
            // 
            this.lblNoProps.AutoSize = true;
            this.lblNoProps.Location = new System.Drawing.Point(0, 0);
            this.lblNoProps.Name = "lblNoProps";
            this.lblNoProps.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lblNoProps.Size = new System.Drawing.Size(114, 26);
            this.lblNoProps.TabIndex = 0;
            this.lblNoProps.Text = "Выберите элемент\r\nдля редактирования";
            // 
            // tvKP
            // 
            this.tvKP.HideSelection = false;
            this.tvKP.ImageIndex = 0;
            this.tvKP.ImageList = this.imageList;
            this.tvKP.Location = new System.Drawing.Point(13, 16);
            this.tvKP.Name = "tvKP";
            treeNode1.ImageKey = "folder_closed.png";
            treeNode1.Name = "nodeDataRead";
            treeNode1.SelectedImageKey = "folder_closed.png";
            treeNode1.Text = "Чтение данных";
            treeNode2.ImageKey = "folder_closed.png";
            treeNode2.Name = "nodeDataWrite";
            treeNode2.SelectedImageKey = "folder_closed.png";
            treeNode2.Text = "Запись данных";
            treeNode3.ImageKey = "folder_closed.png";
            treeNode3.Name = "nodeEvents";
            treeNode3.SelectedImageKey = "folder_closed.png";
            treeNode3.Text = "События";
            this.tvKP.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            this.tvKP.SelectedImageIndex = 0;
            this.tvKP.ShowRootLines = false;
            this.tvKP.Size = new System.Drawing.Size(200, 352);
            this.tvKP.TabIndex = 0;
            this.tvKP.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvKP_BeforeCollapse);
            this.tvKP.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvKP_BeforeExpand);
            this.tvKP.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvKP_AfterSelect);
            // 
            // AttributesLV
            // 
            this.AttributesLV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.AttributeNameCH,
            this.AttributeDataTypeCH,
            this.AttributeValueCH});
            this.AttributesLV.FullRowSelect = true;
            this.AttributesLV.Location = new System.Drawing.Point(6, 16);
            this.AttributesLV.Name = "AttributesLV";
            this.AttributesLV.Size = new System.Drawing.Size(228, 352);
            this.AttributesLV.TabIndex = 6;
            this.AttributesLV.UseCompatibleStateImageBehavior = false;
            this.AttributesLV.View = System.Windows.Forms.View.Details;
            // 
            // AttributeNameCH
            // 
            this.AttributeNameCH.Text = "Name";
            // 
            // AttributeDataTypeCH
            // 
            this.AttributeDataTypeCH.DisplayIndex = 2;
            this.AttributeDataTypeCH.Text = "Data Type";
            this.AttributeDataTypeCH.Width = 104;
            // 
            // AttributeValueCH
            // 
            this.AttributeValueCH.DisplayIndex = 1;
            this.AttributeValueCH.Text = "Value";
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(760, 487);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(841, 487);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnConnect,
            this.btnDisconnect,
            this.sep1,
            this.btnCreateDataGroup,
            this.btnCreateEventGroup,
            this.btnAddElem,
            this.btnMoveUp,
            this.btnMoveDown,
            this.btnDelete});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(928, 25);
            this.toolStrip.TabIndex = 0;
            // 
            // btnConnect
            // 
            this.btnConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnConnect.Image = ((System.Drawing.Image)(resources.GetObject("btnConnect.Image")));
            this.btnConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(23, 22);
            this.btnConnect.ToolTipText = "Соединиться с OPC-сервером";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDisconnect.Enabled = false;
            this.btnDisconnect.Image = ((System.Drawing.Image)(resources.GetObject("btnDisconnect.Image")));
            this.btnDisconnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(23, 22);
            this.btnDisconnect.ToolTipText = "Разъединиться с OPC-сервером";
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // sep1
            // 
            this.sep1.Name = "sep1";
            this.sep1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnCreateDataGroup
            // 
            this.btnCreateDataGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCreateDataGroup.Image = ((System.Drawing.Image)(resources.GetObject("btnCreateDataGroup.Image")));
            this.btnCreateDataGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCreateDataGroup.Name = "btnCreateDataGroup";
            this.btnCreateDataGroup.Size = new System.Drawing.Size(23, 22);
            this.btnCreateDataGroup.ToolTipText = "Создать группу чтения данных";
            this.btnCreateDataGroup.Click += new System.EventHandler(this.btnCreateDataGroup_Click);
            // 
            // btnCreateEventGroup
            // 
            this.btnCreateEventGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCreateEventGroup.Image = ((System.Drawing.Image)(resources.GetObject("btnCreateEventGroup.Image")));
            this.btnCreateEventGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCreateEventGroup.Name = "btnCreateEventGroup";
            this.btnCreateEventGroup.Size = new System.Drawing.Size(23, 22);
            this.btnCreateEventGroup.ToolTipText = "Создать группу приёма событий";
            this.btnCreateEventGroup.Click += new System.EventHandler(this.btnCreateEventGroup_Click);
            // 
            // btnAddElem
            // 
            this.btnAddElem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddElem.Image = ((System.Drawing.Image)(resources.GetObject("btnAddElem.Image")));
            this.btnAddElem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddElem.Name = "btnAddElem";
            this.btnAddElem.Size = new System.Drawing.Size(23, 22);
            this.btnAddElem.ToolTipText = "Добавить выбранный элемент";
            this.btnAddElem.Click += new System.EventHandler(this.btnAddElem_Click);
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMoveUp.Enabled = false;
            this.btnMoveUp.Image = ((System.Drawing.Image)(resources.GetObject("btnMoveUp.Image")));
            this.btnMoveUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(23, 22);
            this.btnMoveUp.ToolTipText = "Переместить вверх";
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUpDown_Click);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMoveDown.Enabled = false;
            this.btnMoveDown.Image = ((System.Drawing.Image)(resources.GetObject("btnMoveDown.Image")));
            this.btnMoveDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(23, 22);
            this.btnMoveDown.ToolTipText = "Переместить вниз";
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveUpDown_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDelete.Enabled = false;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(23, 22);
            this.btnDelete.ToolTipText = "Удалить";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // gbItem
            // 
            this.gbItem.Controls.Add(this.AttributesLV);
            this.gbItem.Location = new System.Drawing.Point(232, 100);
            this.gbItem.Name = "gbItem";
            this.gbItem.Size = new System.Drawing.Size(240, 381);
            this.gbItem.TabIndex = 6;
            this.gbItem.TabStop = false;
            this.gbItem.Text = "Item details";
            // 
            // FrmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(928, 522);
            this.Controls.Add(this.gbItem);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbKP);
            this.Controls.Add(this.gbServerContent);
            this.Controls.Add(this.gbServer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConfig";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Конфигурация КП {0}";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmConfig_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmConfig_FormClosed);
            this.Load += new System.EventHandler(this.FrmConfig_Load);
            this.gbServer.ResumeLayout(false);
            this.gbServer.PerformLayout();
            this.gbServerContent.ResumeLayout(false);
            this.gbKP.ResumeLayout(false);
            this.pnlNoProps.ResumeLayout(false);
            this.pnlNoProps.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.gbItem.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbServer;
        private System.Windows.Forms.GroupBox gbServerContent;
        private System.Windows.Forms.GroupBox gbKP;
        private System.Windows.Forms.TreeView tvKP;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRefrItems;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnConnect;
        private System.Windows.Forms.ToolStripButton btnDisconnect;
        private System.Windows.Forms.ToolStripSeparator sep1;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ToolStripButton btnCreateDataGroup;
        private System.Windows.Forms.ToolStripButton btnCreateEventGroup;
        private System.Windows.Forms.ToolStripButton btnAddElem;
        private System.Windows.Forms.ToolStripButton btnMoveUp;
        private System.Windows.Forms.ToolStripButton btnMoveDown;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.CheckBox UseSecurityCK;
        private System.Windows.Forms.ListView AttributesLV;
        private System.Windows.Forms.ColumnHeader AttributeNameCH;
        private System.Windows.Forms.ColumnHeader AttributeDataTypeCH;
        private System.Windows.Forms.ColumnHeader AttributeValueCH;
        private System.Windows.Forms.TreeView BrowseNodesTV;
        private CtrlEventGroupProps ctrlEventGroupProps;
        private CtrlCommandProps ctrlCommandProps;
        private CtrlDataItemProps ctrlDataItemProps;
        private CtrlDataGroupProps ctrlDataGroupProps;
        private System.Windows.Forms.Panel pnlNoProps;
        private System.Windows.Forms.Label lblNoProps;
        private System.Windows.Forms.TextBox cbServer;
        private System.Windows.Forms.GroupBox gbItem;
    }
}
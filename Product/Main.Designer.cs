namespace Finger.UI
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.statusRobot = new System.Windows.Forms.ToolStripStatusLabel();
            this.enrollStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.systemMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemUserItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fingerMachine = new System.Windows.Forms.ToolStripMenuItem();
            this.connectMachineItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeMachineItem = new System.Windows.Forms.ToolStripMenuItem();
            this.axZKFPEngX1 = new AxZKFPEngXControl.AxZKFPEngX();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAccepter = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVisitor = new System.Windows.Forms.TextBox();
            this.cbLogFilter = new System.Windows.Forms.ComboBox();
            this.btnDeleteLog = new System.Windows.Forms.Button();
            this.btnModifyLog = new System.Windows.Forms.Button();
            this.lblLogTip = new System.Windows.Forms.Label();
            this.gvLog = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.visitorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vistorCompany = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purpose = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recepter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.leaveTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.operate = new System.Windows.Forms.DataGridViewLinkColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pbFinger = new System.Windows.Forms.PictureBox();
            this.btnMatch = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.statusBar.SuspendLayout();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axZKFPEngX1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvLog)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFinger)).BeginInit();
            this.SuspendLayout();
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusRobot,
            this.enrollStatus});
            this.statusBar.Location = new System.Drawing.Point(0, 695);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(1154, 22);
            this.statusBar.TabIndex = 0;
            // 
            // statusRobot
            // 
            this.statusRobot.Name = "statusRobot";
            this.statusRobot.Size = new System.Drawing.Size(80, 17);
            this.statusRobot.Text = "指纹仪状态：";
            // 
            // enrollStatus
            // 
            this.enrollStatus.Name = "enrollStatus";
            this.enrollStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.PaleTurquoise;
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.systemMenuItem,
            this.fingerMachine});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1154, 25);
            this.menu.TabIndex = 1;
            // 
            // systemMenuItem
            // 
            this.systemMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.systemUserItem,
            this.quitItem});
            this.systemMenuItem.Name = "systemMenuItem";
            this.systemMenuItem.Size = new System.Drawing.Size(44, 21);
            this.systemMenuItem.Text = "系统";
            // 
            // systemUserItem
            // 
            this.systemUserItem.Name = "systemUserItem";
            this.systemUserItem.Size = new System.Drawing.Size(124, 22);
            this.systemUserItem.Text = "系统用户";
            this.systemUserItem.Click += new System.EventHandler(this.systemUserItem_Click);
            // 
            // quitItem
            // 
            this.quitItem.Name = "quitItem";
            this.quitItem.Size = new System.Drawing.Size(124, 22);
            this.quitItem.Text = "退出系统";
            this.quitItem.Click += new System.EventHandler(this.quitItem_Click);
            // 
            // fingerMachine
            // 
            this.fingerMachine.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectMachineItem,
            this.closeMachineItem});
            this.fingerMachine.Name = "fingerMachine";
            this.fingerMachine.Size = new System.Drawing.Size(56, 21);
            this.fingerMachine.Text = "指纹仪";
            // 
            // connectMachineItem
            // 
            this.connectMachineItem.Name = "connectMachineItem";
            this.connectMachineItem.Size = new System.Drawing.Size(100, 22);
            this.connectMachineItem.Text = "连接";
            this.connectMachineItem.Click += new System.EventHandler(this.connectMachineItem_Click);
            // 
            // closeMachineItem
            // 
            this.closeMachineItem.Name = "closeMachineItem";
            this.closeMachineItem.Size = new System.Drawing.Size(100, 22);
            this.closeMachineItem.Text = "关闭";
            this.closeMachineItem.Click += new System.EventHandler(this.closeMachineItem_Click);
            // 
            // axZKFPEngX1
            // 
            this.axZKFPEngX1.Enabled = true;
            this.axZKFPEngX1.Location = new System.Drawing.Point(1146, 669);
            this.axZKFPEngX1.Name = "axZKFPEngX1";
            this.axZKFPEngX1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axZKFPEngX1.OcxState")));
            this.axZKFPEngX1.Size = new System.Drawing.Size(24, 24);
            this.axZKFPEngX1.TabIndex = 4;
            this.axZKFPEngX1.OnFeatureInfo += new AxZKFPEngXControl.IZKFPEngXEvents_OnFeatureInfoEventHandler(this.axZKFPEngX1_OnFeatureInfo);
            this.axZKFPEngX1.OnImageReceived += new AxZKFPEngXControl.IZKFPEngXEvents_OnImageReceivedEventHandler(this.axZKFPEngX1_OnImageReceived);
            this.axZKFPEngX1.OnEnroll += new AxZKFPEngXControl.IZKFPEngXEvents_OnEnrollEventHandler(this.axZKFPEngX1_OnEnroll);
            this.axZKFPEngX1.OnCapture += new AxZKFPEngXControl.IZKFPEngXEvents_OnCaptureEventHandler(this.axZKFPEngX1_OnCapture);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnQuery);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtAccepter);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtVisitor);
            this.groupBox1.Controls.Add(this.cbLogFilter);
            this.groupBox1.Controls.Add(this.btnDeleteLog);
            this.groupBox1.Controls.Add(this.btnModifyLog);
            this.groupBox1.Controls.Add(this.lblLogTip);
            this.groupBox1.Controls.Add(this.gvLog);
            this.groupBox1.Location = new System.Drawing.Point(18, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(968, 634);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "访客记录";
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(525, 22);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 25);
            this.btnQuery.TabIndex = 9;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(340, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "负责人：";
            // 
            // txtAccepter
            // 
            this.txtAccepter.Location = new System.Drawing.Point(399, 25);
            this.txtAccepter.Name = "txtAccepter";
            this.txtAccepter.Size = new System.Drawing.Size(100, 21);
            this.txtAccepter.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(157, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "来访人：";
            // 
            // txtVisitor
            // 
            this.txtVisitor.Location = new System.Drawing.Point(216, 24);
            this.txtVisitor.Name = "txtVisitor";
            this.txtVisitor.Size = new System.Drawing.Size(100, 21);
            this.txtVisitor.TabIndex = 5;
            // 
            // cbLogFilter
            // 
            this.cbLogFilter.FormattingEnabled = true;
            this.cbLogFilter.Items.AddRange(new object[] {
            "当天记录",
            "本周记录",
            "本月记录",
            "所有记录"});
            this.cbLogFilter.Location = new System.Drawing.Point(13, 25);
            this.cbLogFilter.Name = "cbLogFilter";
            this.cbLogFilter.Size = new System.Drawing.Size(121, 20);
            this.cbLogFilter.TabIndex = 4;
            this.cbLogFilter.SelectedIndexChanged += new System.EventHandler(this.cbLogFilter_SelectedIndexChanged);
            // 
            // btnDeleteLog
            // 
            this.btnDeleteLog.Location = new System.Drawing.Point(886, 21);
            this.btnDeleteLog.Name = "btnDeleteLog";
            this.btnDeleteLog.Size = new System.Drawing.Size(75, 25);
            this.btnDeleteLog.TabIndex = 3;
            this.btnDeleteLog.Text = "删除";
            this.btnDeleteLog.UseVisualStyleBackColor = true;
            this.btnDeleteLog.Click += new System.EventHandler(this.btnDeleteLog_Click);
            // 
            // btnModifyLog
            // 
            this.btnModifyLog.Location = new System.Drawing.Point(799, 21);
            this.btnModifyLog.Name = "btnModifyLog";
            this.btnModifyLog.Size = new System.Drawing.Size(75, 25);
            this.btnModifyLog.TabIndex = 2;
            this.btnModifyLog.Text = "修改";
            this.btnModifyLog.UseVisualStyleBackColor = true;
            this.btnModifyLog.Click += new System.EventHandler(this.btnModifyLog_Click);
            // 
            // lblLogTip
            // 
            this.lblLogTip.AutoSize = true;
            this.lblLogTip.BackColor = System.Drawing.Color.White;
            this.lblLogTip.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLogTip.Location = new System.Drawing.Point(413, 299);
            this.lblLogTip.Name = "lblLogTip";
            this.lblLogTip.Size = new System.Drawing.Size(129, 20);
            this.lblLogTip.TabIndex = 1;
            this.lblLogTip.Text = "暂时没有记录";
            // 
            // gvLog
            // 
            this.gvLog.AllowUserToAddRows = false;
            this.gvLog.AllowUserToDeleteRows = false;
            this.gvLog.BackgroundColor = System.Drawing.Color.White;
            this.gvLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.visitorName,
            this.vistorCompany,
            this.time,
            this.purpose,
            this.recepter,
            this.leaveTime,
            this.operate});
            this.gvLog.Location = new System.Drawing.Point(7, 52);
            this.gvLog.MultiSelect = false;
            this.gvLog.Name = "gvLog";
            this.gvLog.ReadOnly = true;
            this.gvLog.RowTemplate.Height = 23;
            this.gvLog.Size = new System.Drawing.Size(954, 572);
            this.gvLog.TabIndex = 0;
            this.gvLog.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvLog_CellContentClick);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            this.id.Width = 20;
            // 
            // visitorName
            // 
            this.visitorName.DataPropertyName = "visitorName";
            this.visitorName.HeaderText = "来访人";
            this.visitorName.Name = "visitorName";
            this.visitorName.ReadOnly = true;
            this.visitorName.Width = 80;
            // 
            // vistorCompany
            // 
            this.vistorCompany.DataPropertyName = "VisitorCompany";
            this.vistorCompany.HeaderText = "所属公司";
            this.vistorCompany.Name = "vistorCompany";
            this.vistorCompany.ReadOnly = true;
            this.vistorCompany.Width = 170;
            // 
            // time
            // 
            this.time.DataPropertyName = "time";
            this.time.HeaderText = "来访时间";
            this.time.Name = "time";
            this.time.ReadOnly = true;
            this.time.Width = 120;
            // 
            // purpose
            // 
            this.purpose.DataPropertyName = "purpose";
            this.purpose.HeaderText = "来访事由";
            this.purpose.Name = "purpose";
            this.purpose.ReadOnly = true;
            this.purpose.Width = 280;
            // 
            // recepter
            // 
            this.recepter.DataPropertyName = "recepter";
            this.recepter.HeaderText = "负责人";
            this.recepter.Name = "recepter";
            this.recepter.ReadOnly = true;
            this.recepter.Width = 80;
            // 
            // leaveTime
            // 
            this.leaveTime.DataPropertyName = "leaveTime";
            this.leaveTime.HeaderText = "离开时间";
            this.leaveTime.Name = "leaveTime";
            this.leaveTime.ReadOnly = true;
            this.leaveTime.Width = 120;
            // 
            // operate
            // 
            this.operate.HeaderText = "操作";
            this.operate.Name = "operate";
            this.operate.ReadOnly = true;
            this.operate.Text = "离开";
            this.operate.UseColumnTextForLinkValue = true;
            this.operate.Width = 60;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.pbFinger);
            this.groupBox2.Controls.Add(this.btnMatch);
            this.groupBox2.Controls.Add(this.btnRegister);
            this.groupBox2.Location = new System.Drawing.Point(1004, 43);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(138, 634);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "管理面板";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 495);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "指纹图";
            // 
            // pbFinger
            // 
            this.pbFinger.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pbFinger.Location = new System.Drawing.Point(19, 520);
            this.pbFinger.Name = "pbFinger";
            this.pbFinger.Size = new System.Drawing.Size(100, 100);
            this.pbFinger.TabIndex = 2;
            this.pbFinger.TabStop = false;
            // 
            // btnMatch
            // 
            this.btnMatch.Enabled = false;
            this.btnMatch.Location = new System.Drawing.Point(19, 139);
            this.btnMatch.Name = "btnMatch";
            this.btnMatch.Size = new System.Drawing.Size(100, 50);
            this.btnMatch.TabIndex = 1;
            this.btnMatch.Text = "开始匹配";
            this.btnMatch.UseVisualStyleBackColor = true;
            this.btnMatch.Click += new System.EventHandler(this.btnMatch_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.Enabled = false;
            this.btnRegister.Location = new System.Drawing.Point(19, 59);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(100, 50);
            this.btnRegister.TabIndex = 0;
            this.btnRegister.Text = "开始登记";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1154, 717);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.axZKFPEngX1);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "欢迎使用访客系统";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axZKFPEngX1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvLog)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFinger)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem systemMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel statusRobot;
        private System.Windows.Forms.ToolStripMenuItem fingerMachine;
        private System.Windows.Forms.ToolStripMenuItem connectMachineItem;
        private System.Windows.Forms.ToolStripMenuItem closeMachineItem;
        private System.Windows.Forms.ToolStripMenuItem systemUserItem;
        private System.Windows.Forms.ToolStripMenuItem quitItem;
        private AxZKFPEngXControl.AxZKFPEngX axZKFPEngX1;
        private System.Windows.Forms.ToolStripStatusLabel enrollStatus;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnMatch;
        private System.Windows.Forms.DataGridView gvLog;
        private System.Windows.Forms.Label lblLogTip;
        private System.Windows.Forms.Button btnDeleteLog;
        private System.Windows.Forms.Button btnModifyLog;
        private System.Windows.Forms.ComboBox cbLogFilter;
        private System.Windows.Forms.PictureBox pbFinger;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtVisitor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAccepter;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn visitorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn vistorCompany;
        private System.Windows.Forms.DataGridViewTextBoxColumn time;
        private System.Windows.Forms.DataGridViewTextBoxColumn purpose;
        private System.Windows.Forms.DataGridViewTextBoxColumn recepter;
        private System.Windows.Forms.DataGridViewTextBoxColumn leaveTime;
        private System.Windows.Forms.DataGridViewLinkColumn operate;
    }
}
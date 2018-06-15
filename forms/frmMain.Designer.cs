namespace Logger
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnListen = new System.Windows.Forms.Button();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabUDP = new System.Windows.Forms.TabPage();
            this.btnClear = new System.Windows.Forms.Button();
            this.tabFile = new System.Windows.Forms.TabPage();
            this.btnSetPath = new System.Windows.Forms.Button();
            this.btnLoadData = new System.Windows.Forms.Button();
            this.txtLogPath = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statLED = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.statCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.TimeOut = new System.Windows.Forms.Timer(this.components);
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.chbReceivedTime = new System.Windows.Forms.CheckBox();
            this.chbTo = new System.Windows.Forms.CheckBox();
            this.chbFrom = new System.Windows.Forms.CheckBox();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.chbUnknown = new System.Windows.Forms.CheckBox();
            this.chbExtended = new System.Windows.Forms.CheckBox();
            this.chbDebug = new System.Windows.Forms.CheckBox();
            this.chbInfo = new System.Windows.Forms.CheckBox();
            this.chbWarning = new System.Windows.Forms.CheckBox();
            this.lblDevice = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblHistory = new System.Windows.Forms.Label();
            this.cbDevice = new System.Windows.Forms.ComboBox();
            this.chError = new System.Windows.Forms.CheckBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.imgInfo = new System.Windows.Forms.PictureBox();
            this.olvLog = new BrightIdeasSoftware.FastObjectListView();
            this.olvLogName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvLogProcess = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvLogDate = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvLogLevel = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvLogDesc = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.tabControl1.SuspendLayout();
            this.tabUDP.SuspendLayout();
            this.tabFile.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.gbFilter.SuspendLayout();
            this.notifyMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.olvLog)).BeginInit();
            this.SuspendLayout();
            // 
            // btnListen
            // 
            this.btnListen.Location = new System.Drawing.Point(156, 19);
            this.btnListen.Name = "btnListen";
            this.btnListen.Size = new System.Drawing.Size(75, 23);
            this.btnListen.TabIndex = 0;
            this.btnListen.Text = "Listen";
            this.btnListen.UseVisualStyleBackColor = true;
            this.btnListen.Click += new System.EventHandler(this.btnListen_Click);
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(50, 19);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(100, 20);
            this.txtPort.TabIndex = 1;
            this.txtPort.Text = "17000";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(15, 22);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(29, 13);
            this.lblPort.TabIndex = 2;
            this.lblPort.Text = "Port:";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabUDP);
            this.tabControl1.Controls.Add(this.tabFile);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(558, 83);
            this.tabControl1.TabIndex = 3;
            // 
            // tabUDP
            // 
            this.tabUDP.Controls.Add(this.btnClear);
            this.tabUDP.Controls.Add(this.lblPort);
            this.tabUDP.Controls.Add(this.btnListen);
            this.tabUDP.Controls.Add(this.txtPort);
            this.tabUDP.Location = new System.Drawing.Point(4, 22);
            this.tabUDP.Name = "tabUDP";
            this.tabUDP.Padding = new System.Windows.Forms.Padding(3);
            this.tabUDP.Size = new System.Drawing.Size(550, 57);
            this.tabUDP.TabIndex = 0;
            this.tabUDP.Text = "Network";
            this.tabUDP.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(461, 19);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // tabFile
            // 
            this.tabFile.Controls.Add(this.btnSetPath);
            this.tabFile.Controls.Add(this.btnLoadData);
            this.tabFile.Controls.Add(this.txtLogPath);
            this.tabFile.Location = new System.Drawing.Point(4, 22);
            this.tabFile.Name = "tabFile";
            this.tabFile.Padding = new System.Windows.Forms.Padding(3);
            this.tabFile.Size = new System.Drawing.Size(550, 57);
            this.tabFile.TabIndex = 1;
            this.tabFile.Text = "File";
            this.tabFile.UseVisualStyleBackColor = true;
            // 
            // btnSetPath
            // 
            this.btnSetPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetPath.Location = new System.Drawing.Point(429, 17);
            this.btnSetPath.Name = "btnSetPath";
            this.btnSetPath.Size = new System.Drawing.Size(34, 23);
            this.btnSetPath.TabIndex = 23;
            this.btnSetPath.Text = "...";
            this.btnSetPath.UseVisualStyleBackColor = true;
            this.btnSetPath.Click += new System.EventHandler(this.btnSetPath_Click);
            // 
            // btnLoadData
            // 
            this.btnLoadData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadData.Location = new System.Drawing.Point(469, 17);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(75, 23);
            this.btnLoadData.TabIndex = 1;
            this.btnLoadData.Text = "Load";
            this.btnLoadData.UseVisualStyleBackColor = true;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // txtLogPath
            // 
            this.txtLogPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLogPath.Location = new System.Drawing.Point(23, 19);
            this.txtLogPath.Name = "txtLogPath";
            this.txtLogPath.Size = new System.Drawing.Size(410, 20);
            this.txtLogPath.TabIndex = 0;
            this.txtLogPath.Text = "C:\\data\\log";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statLED,
            this.lblStatus,
            this.statCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 561);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(582, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statLED
            // 
            this.statLED.Image = global::Logger.Properties.Resources.circ_red24;
            this.statLED.Name = "statLED";
            this.statLED.Size = new System.Drawing.Size(16, 17);
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(43, 17);
            this.lblStatus.Text = "Closed";
            // 
            // statCount
            // 
            this.statCount.Name = "statCount";
            this.statCount.Size = new System.Drawing.Size(46, 17);
            this.statCount.Text = "(0 logs)";
            // 
            // TimeOut
            // 
            this.TimeOut.Interval = 40;
            this.TimeOut.Tick += new System.EventHandler(this.TimeOut_Tick);
            // 
            // gbFilter
            // 
            this.gbFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbFilter.Controls.Add(this.chbReceivedTime);
            this.gbFilter.Controls.Add(this.chbTo);
            this.gbFilter.Controls.Add(this.chbFrom);
            this.gbFilter.Controls.Add(this.dtTo);
            this.gbFilter.Controls.Add(this.dtFrom);
            this.gbFilter.Controls.Add(this.chbUnknown);
            this.gbFilter.Controls.Add(this.chbExtended);
            this.gbFilter.Controls.Add(this.chbDebug);
            this.gbFilter.Controls.Add(this.chbInfo);
            this.gbFilter.Controls.Add(this.chbWarning);
            this.gbFilter.Controls.Add(this.lblDevice);
            this.gbFilter.Controls.Add(this.lblTo);
            this.gbFilter.Controls.Add(this.lblHistory);
            this.gbFilter.Controls.Add(this.cbDevice);
            this.gbFilter.Controls.Add(this.chError);
            this.gbFilter.Controls.Add(this.lblFilter);
            this.gbFilter.Controls.Add(this.txtFilter);
            this.gbFilter.Location = new System.Drawing.Point(12, 101);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(554, 94);
            this.gbFilter.TabIndex = 8;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Filter";
            // 
            // chbReceivedTime
            // 
            this.chbReceivedTime.AutoSize = true;
            this.chbReceivedTime.Checked = true;
            this.chbReceivedTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbReceivedTime.Location = new System.Drawing.Point(9, 71);
            this.chbReceivedTime.Name = "chbReceivedTime";
            this.chbReceivedTime.Size = new System.Drawing.Size(119, 17);
            this.chbReceivedTime.TabIndex = 27;
            this.chbReceivedTime.Text = "Using received time";
            this.chbReceivedTime.UseVisualStyleBackColor = true;
            this.chbReceivedTime.CheckedChanged += new System.EventHandler(this.chbReceivedTime_CheckedChanged);
            // 
            // chbTo
            // 
            this.chbTo.AutoSize = true;
            this.chbTo.Location = new System.Drawing.Point(218, 47);
            this.chbTo.Name = "chbTo";
            this.chbTo.Size = new System.Drawing.Size(15, 14);
            this.chbTo.TabIndex = 26;
            this.chbTo.UseVisualStyleBackColor = true;
            this.chbTo.CheckedChanged += new System.EventHandler(this.dtFrom_ValueChanged);
            // 
            // chbFrom
            // 
            this.chbFrom.AutoSize = true;
            this.chbFrom.Location = new System.Drawing.Point(54, 47);
            this.chbFrom.Name = "chbFrom";
            this.chbFrom.Size = new System.Drawing.Size(15, 14);
            this.chbFrom.TabIndex = 24;
            this.chbFrom.UseVisualStyleBackColor = true;
            this.chbFrom.CheckedChanged += new System.EventHandler(this.dtFrom_ValueChanged);
            // 
            // dtTo
            // 
            this.dtTo.CustomFormat = "d.M.yyyy HH:mm";
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTo.Location = new System.Drawing.Point(239, 43);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(130, 20);
            this.dtTo.TabIndex = 23;
            this.dtTo.ValueChanged += new System.EventHandler(this.dtFrom_ValueChanged);
            // 
            // dtFrom
            // 
            this.dtFrom.CustomFormat = "d.M.yyyy HH:mm";
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFrom.Location = new System.Drawing.Point(75, 43);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(121, 20);
            this.dtFrom.TabIndex = 22;
            this.dtFrom.ValueChanged += new System.EventHandler(this.dtFrom_ValueChanged);
            // 
            // chbUnknown
            // 
            this.chbUnknown.AutoSize = true;
            this.chbUnknown.Checked = true;
            this.chbUnknown.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbUnknown.ForeColor = System.Drawing.Color.Gray;
            this.chbUnknown.Location = new System.Drawing.Point(470, 65);
            this.chbUnknown.Name = "chbUnknown";
            this.chbUnknown.Size = new System.Drawing.Size(72, 17);
            this.chbUnknown.TabIndex = 21;
            this.chbUnknown.Text = "Unknown";
            this.chbUnknown.UseVisualStyleBackColor = true;
            this.chbUnknown.CheckedChanged += new System.EventHandler(this.chError_CheckedChanged);
            // 
            // chbExtended
            // 
            this.chbExtended.AutoSize = true;
            this.chbExtended.Checked = true;
            this.chbExtended.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbExtended.Location = new System.Drawing.Point(470, 42);
            this.chbExtended.Name = "chbExtended";
            this.chbExtended.Size = new System.Drawing.Size(72, 17);
            this.chbExtended.TabIndex = 20;
            this.chbExtended.Text = "eXtended";
            this.chbExtended.UseVisualStyleBackColor = true;
            this.chbExtended.CheckedChanged += new System.EventHandler(this.chError_CheckedChanged);
            // 
            // chbDebug
            // 
            this.chbDebug.AutoSize = true;
            this.chbDebug.Checked = true;
            this.chbDebug.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbDebug.ForeColor = System.Drawing.Color.Maroon;
            this.chbDebug.Location = new System.Drawing.Point(470, 19);
            this.chbDebug.Name = "chbDebug";
            this.chbDebug.Size = new System.Drawing.Size(58, 17);
            this.chbDebug.TabIndex = 19;
            this.chbDebug.Text = "Debug";
            this.chbDebug.UseVisualStyleBackColor = true;
            this.chbDebug.CheckedChanged += new System.EventHandler(this.chError_CheckedChanged);
            // 
            // chbInfo
            // 
            this.chbInfo.AutoSize = true;
            this.chbInfo.Checked = true;
            this.chbInfo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbInfo.ForeColor = System.Drawing.Color.Green;
            this.chbInfo.Location = new System.Drawing.Point(393, 65);
            this.chbInfo.Name = "chbInfo";
            this.chbInfo.Size = new System.Drawing.Size(44, 17);
            this.chbInfo.TabIndex = 18;
            this.chbInfo.Text = "Info";
            this.chbInfo.UseVisualStyleBackColor = true;
            this.chbInfo.CheckedChanged += new System.EventHandler(this.chError_CheckedChanged);
            // 
            // chbWarning
            // 
            this.chbWarning.AutoSize = true;
            this.chbWarning.Checked = true;
            this.chbWarning.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbWarning.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.chbWarning.Location = new System.Drawing.Point(393, 42);
            this.chbWarning.Name = "chbWarning";
            this.chbWarning.Size = new System.Drawing.Size(66, 17);
            this.chbWarning.TabIndex = 17;
            this.chbWarning.Text = "Warning";
            this.chbWarning.UseVisualStyleBackColor = true;
            this.chbWarning.CheckedChanged += new System.EventHandler(this.chError_CheckedChanged);
            // 
            // lblDevice
            // 
            this.lblDevice.AutoSize = true;
            this.lblDevice.Location = new System.Drawing.Point(202, 20);
            this.lblDevice.Name = "lblDevice";
            this.lblDevice.Size = new System.Drawing.Size(44, 13);
            this.lblDevice.TabIndex = 16;
            this.lblDevice.Text = "Device:";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(202, 46);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(10, 13);
            this.lblTo.TabIndex = 15;
            this.lblTo.Text = "-";
            // 
            // lblHistory
            // 
            this.lblHistory.AutoSize = true;
            this.lblHistory.Location = new System.Drawing.Point(6, 46);
            this.lblHistory.Name = "lblHistory";
            this.lblHistory.Size = new System.Drawing.Size(42, 13);
            this.lblHistory.TabIndex = 13;
            this.lblHistory.Text = "History:";
            // 
            // cbDevice
            // 
            this.cbDevice.FormattingEnabled = true;
            this.cbDevice.Location = new System.Drawing.Point(252, 17);
            this.cbDevice.Name = "cbDevice";
            this.cbDevice.Size = new System.Drawing.Size(117, 21);
            this.cbDevice.TabIndex = 11;
            this.cbDevice.TextChanged += new System.EventHandler(this.cbDevice_TextChanged);
            // 
            // chError
            // 
            this.chError.AutoSize = true;
            this.chError.Checked = true;
            this.chError.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chError.ForeColor = System.Drawing.Color.Red;
            this.chError.Location = new System.Drawing.Point(393, 19);
            this.chError.Name = "chError";
            this.chError.Size = new System.Drawing.Size(48, 17);
            this.chError.TabIndex = 10;
            this.chError.Text = "Error";
            this.chError.UseVisualStyleBackColor = true;
            this.chError.CheckedChanged += new System.EventHandler(this.chError_CheckedChanged);
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(6, 20);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(32, 13);
            this.lblFilter.TabIndex = 9;
            this.lblFilter.Text = "Filter:";
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(54, 17);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(142, 20);
            this.txtFilter.TabIndex = 8;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.notifyMenu;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Logger - Stop";
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // notifyMenu
            // 
            this.notifyMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuExit});
            this.notifyMenu.Name = "notifyMenu";
            this.notifyMenu.Size = new System.Drawing.Size(93, 26);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(92, 22);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // imgInfo
            // 
            this.imgInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imgInfo.Image = global::Logger.Properties.Resources._1422621629_34225;
            this.imgInfo.Location = new System.Drawing.Point(558, 1);
            this.imgInfo.Name = "imgInfo";
            this.imgInfo.Size = new System.Drawing.Size(24, 24);
            this.imgInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgInfo.TabIndex = 22;
            this.imgInfo.TabStop = false;
            this.imgInfo.Click += new System.EventHandler(this.imgInfo_Click);
            // 
            // olvLog
            // 
            this.olvLog.AllColumns.Add(this.olvLogName);
            this.olvLog.AllColumns.Add(this.olvLogProcess);
            this.olvLog.AllColumns.Add(this.olvLogDate);
            this.olvLog.AllColumns.Add(this.olvLogLevel);
            this.olvLog.AllColumns.Add(this.olvLogDesc);
            this.olvLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olvLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvLogName,
            this.olvLogProcess,
            this.olvLogDate,
            this.olvLogLevel,
            this.olvLogDesc});
            this.olvLog.FullRowSelect = true;
            this.olvLog.GridLines = true;
            this.olvLog.HideSelection = false;
            this.olvLog.Location = new System.Drawing.Point(16, 201);
            this.olvLog.Name = "olvLog";
            this.olvLog.ShowGroups = false;
            this.olvLog.Size = new System.Drawing.Size(550, 342);
            this.olvLog.TabIndex = 23;
            this.olvLog.UseCompatibleStateImageBehavior = false;
            this.olvLog.View = System.Windows.Forms.View.Details;
            this.olvLog.VirtualMode = true;
            this.olvLog.FormatRow += new System.EventHandler<BrightIdeasSoftware.FormatRowEventArgs>(this.olvLog_FormatRow);
            this.olvLog.DoubleClick += new System.EventHandler(this.olvLog_DoubleClick);
            // 
            // olvLogName
            // 
            this.olvLogName.AspectName = "Name";
            this.olvLogName.Text = "Device";
            this.olvLogName.Width = 54;
            // 
            // olvLogProcess
            // 
            this.olvLogProcess.AspectName = "Process";
            this.olvLogProcess.Text = "Process";
            this.olvLogProcess.Width = 52;
            // 
            // olvLogDate
            // 
            this.olvLogDate.AspectName = "Date";
            this.olvLogDate.Text = "Date";
            this.olvLogDate.Width = 117;
            // 
            // olvLogLevel
            // 
            this.olvLogLevel.AspectName = "Level";
            this.olvLogLevel.Text = "Level";
            this.olvLogLevel.Width = 40;
            // 
            // olvLogDesc
            // 
            this.olvLogDesc.AspectName = "Description";
            this.olvLogDesc.Text = "Description";
            this.olvLogDesc.Width = 310;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 583);
            this.Controls.Add(this.olvLog);
            this.Controls.Add(this.imgInfo);
            this.Controls.Add(this.gbFilter);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(598, 320);
            this.Name = "frmMain";
            this.Text = "Logger";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.tabControl1.ResumeLayout(false);
            this.tabUDP.ResumeLayout(false);
            this.tabUDP.PerformLayout();
            this.tabFile.ResumeLayout(false);
            this.tabFile.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            this.notifyMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.olvLog)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnListen;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabUDP;
        private System.Windows.Forms.TabPage tabFile;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.Timer TimeOut;
        private System.Windows.Forms.TextBox txtLogPath;
        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label lblDevice;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblHistory;
        private System.Windows.Forms.ComboBox cbDevice;
        private System.Windows.Forms.CheckBox chError;
        private System.Windows.Forms.CheckBox chbUnknown;
        private System.Windows.Forms.CheckBox chbExtended;
        private System.Windows.Forms.CheckBox chbDebug;
        private System.Windows.Forms.CheckBox chbInfo;
        private System.Windows.Forms.CheckBox chbWarning;
        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ToolStripStatusLabel statCount;
        private System.Windows.Forms.PictureBox imgInfo;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip notifyMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.CheckBox chbTo;
        private System.Windows.Forms.CheckBox chbFrom;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.ToolStripStatusLabel statLED;
        private System.Windows.Forms.Button btnSetPath;
        private BrightIdeasSoftware.FastObjectListView olvLog;
        private BrightIdeasSoftware.OLVColumn olvLogName;
        private BrightIdeasSoftware.OLVColumn olvLogDate;
        private BrightIdeasSoftware.OLVColumn olvLogLevel;
        private BrightIdeasSoftware.OLVColumn olvLogDesc;
        private System.Windows.Forms.CheckBox chbReceivedTime;
        private BrightIdeasSoftware.OLVColumn olvLogProcess;
    }
}


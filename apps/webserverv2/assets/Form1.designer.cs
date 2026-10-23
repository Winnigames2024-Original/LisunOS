namespace LisunOS
{
    partial class ServerForm
    {
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblServerState;
        private System.Windows.Forms.Label lblStats;

        private System.Windows.Forms.Panel pnlSettings;
        private System.Windows.Forms.Label lblSettingsCaption;
        private System.Windows.Forms.Label lblPortCaption;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label lblRootCaption;
        private System.Windows.Forms.TextBox txtRoot;
        private System.Windows.Forms.CheckBox chkRemote;
        private System.Windows.Forms.CheckBox chkListing;
        private System.Windows.Forms.CheckBox chkUfw;
        private System.Windows.Forms.CheckBox chkAutostart;
        private System.Windows.Forms.Button btnStartServer;
        private System.Windows.Forms.Button btnStopServer;
        private System.Windows.Forms.Button btnOpenBrowser;
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.Button btnManageFiles;
        private System.Windows.Forms.Button btnApiKey;
        private System.Windows.Forms.Button btnPanel;

        private System.Windows.Forms.Panel pnlSide;
        private System.Windows.Forms.Label lblAddrCaption;
        private System.Windows.Forms.Label lblAddresses;
        private System.Windows.Forms.Label lblHintCaption;
        private System.Windows.Forms.Label lblHints;

        private System.Windows.Forms.Panel pnlLog;
        private System.Windows.Forms.Label lblLogCaption;
        private System.Windows.Forms.ListBox lstServerLog;

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblServerState = new System.Windows.Forms.Label();
            this.lblStats = new System.Windows.Forms.Label();
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.lblSettingsCaption = new System.Windows.Forms.Label();
            this.lblPortCaption = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.lblRootCaption = new System.Windows.Forms.Label();
            this.txtRoot = new System.Windows.Forms.TextBox();
            this.chkRemote = new System.Windows.Forms.CheckBox();
            this.chkListing = new System.Windows.Forms.CheckBox();
            this.chkUfw = new System.Windows.Forms.CheckBox();
            this.chkAutostart = new System.Windows.Forms.CheckBox();
            this.btnStartServer = new System.Windows.Forms.Button();
            this.btnStopServer = new System.Windows.Forms.Button();
            this.btnOpenBrowser = new System.Windows.Forms.Button();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.btnManageFiles = new System.Windows.Forms.Button();
            this.btnApiKey = new System.Windows.Forms.Button();
            this.btnPanel = new System.Windows.Forms.Button();
            this.pnlSide = new System.Windows.Forms.Panel();
            this.lblAddrCaption = new System.Windows.Forms.Label();
            this.lblAddresses = new System.Windows.Forms.Label();
            this.lblHintCaption = new System.Windows.Forms.Label();
            this.lblHints = new System.Windows.Forms.Label();
            this.pnlLog = new System.Windows.Forms.Panel();
            this.lblLogCaption = new System.Windows.Forms.Label();
            this.lstServerLog = new System.Windows.Forms.ListBox();

            // 
            // Заголовок
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(22, 27, 34);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Size = new System.Drawing.Size(1000, 100);

            this.pnlStatus.BackColor = System.Drawing.Color.FromArgb(22, 27, 34);
            this.pnlStatus.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlStatus.Size = new System.Drawing.Size(6, 100);

            this.lblTitle.Text = "Сервер LisunOS";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(88, 166, 255);
            this.lblTitle.Location = new System.Drawing.Point(30, 18);
            this.lblTitle.Size = new System.Drawing.Size(470, 32);

            this.lblServerState.Text = "Сервер остановлен";
            this.lblServerState.ForeColor = System.Drawing.Color.FromArgb(128, 137, 149);
            this.lblServerState.Location = new System.Drawing.Point(32, 56);
            this.lblServerState.Size = new System.Drawing.Size(470, 26);

            this.lblStats.Text = "";
            this.lblStats.ForeColor = System.Drawing.Color.FromArgb(128, 137, 149);
            this.lblStats.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblStats.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.lblStats.Location = new System.Drawing.Point(510, 56);
            this.lblStats.Size = new System.Drawing.Size(462, 26);

            this.pnlHeader.Controls.Add(this.lblStats);
            this.pnlHeader.Controls.Add(this.lblServerState);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.pnlStatus);

            // 
            // Параметры
            // 
            this.pnlSettings.BackColor = System.Drawing.Color.FromArgb(22, 27, 34);
            this.pnlSettings.Location = new System.Drawing.Point(24, 124);
            this.pnlSettings.Size = new System.Drawing.Size(568, 320);

            this.lblSettingsCaption.Text = "ПАРАМЕТРЫ";
            this.lblSettingsCaption.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblSettingsCaption.ForeColor = System.Drawing.Color.FromArgb(128, 137, 149);
            this.lblSettingsCaption.Location = new System.Drawing.Point(22, 14);
            this.lblSettingsCaption.Size = new System.Drawing.Size(220, 20);

            this.lblPortCaption.Text = "Порт";
            this.lblPortCaption.ForeColor = System.Drawing.Color.FromArgb(128, 137, 149);
            this.lblPortCaption.Location = new System.Drawing.Point(22, 44);
            this.lblPortCaption.Size = new System.Drawing.Size(110, 20);

            this.txtPort.Text = "8080";
            this.txtPort.BackColor = System.Drawing.Color.FromArgb(13, 17, 23);
            this.txtPort.ForeColor = System.Drawing.Color.FromArgb(206, 214, 224);
            this.txtPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPort.Location = new System.Drawing.Point(22, 66);
            this.txtPort.Size = new System.Drawing.Size(112, 28);

            this.lblRootCaption.Text = "Корневая папка сайта";
            this.lblRootCaption.ForeColor = System.Drawing.Color.FromArgb(128, 137, 149);
            this.lblRootCaption.Location = new System.Drawing.Point(152, 44);
            this.lblRootCaption.Size = new System.Drawing.Size(390, 20);

            this.txtRoot.Text = "LisunOS:\root\www";
            this.txtRoot.BackColor = System.Drawing.Color.FromArgb(13, 17, 23);
            this.txtRoot.ForeColor = System.Drawing.Color.FromArgb(206, 214, 224);
            this.txtRoot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRoot.Location = new System.Drawing.Point(152, 66);
            this.txtRoot.Size = new System.Drawing.Size(394, 28);

            this.chkRemote.Text = "Разрешить подключения из локальной сети";
            this.chkRemote.ForeColor = System.Drawing.Color.FromArgb(206, 214, 224);
            this.chkRemote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkRemote.Location = new System.Drawing.Point(22, 112);
            this.chkRemote.Size = new System.Drawing.Size(510, 24);
            this.chkRemote.CheckedChanged += new System.EventHandler(this.chkRemote_CheckedChanged);

            this.chkListing.Text = "Показывать список файлов, если нет index.html";
            this.chkListing.ForeColor = System.Drawing.Color.FromArgb(206, 214, 224);
            this.chkListing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkListing.Checked = true;
            this.chkListing.Location = new System.Drawing.Point(22, 140);
            this.chkListing.Size = new System.Drawing.Size(510, 24);
            this.chkListing.CheckedChanged += new System.EventHandler(this.chkListing_CheckedChanged);

            this.chkUfw.Text = "Брандмауэр ufw включён — порт откроется сам";
            this.chkUfw.ForeColor = System.Drawing.Color.FromArgb(226, 176, 65);
            this.chkUfw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkUfw.Location = new System.Drawing.Point(22, 168);
            this.chkUfw.Size = new System.Drawing.Size(510, 24);
            this.chkUfw.CheckedChanged += new System.EventHandler(this.chkUfw_CheckedChanged);

            this.chkAutostart.Text = "Запускать сервер автоматически при загрузке LisunOS";
            this.chkAutostart.ForeColor = System.Drawing.Color.FromArgb(86, 211, 100);
            this.chkAutostart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkAutostart.Location = new System.Drawing.Point(22, 196);
            this.chkAutostart.Size = new System.Drawing.Size(510, 24);
            this.chkAutostart.CheckedChanged += new System.EventHandler(this.chkAutostart_CheckedChanged);

            this.btnStartServer.Text = "Запустить";
            this.btnStartServer.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnStartServer.Location = new System.Drawing.Point(22, 228);
            this.btnStartServer.Size = new System.Drawing.Size(152, 34);
            this.btnStartServer.Click += new System.EventHandler(this.btnStartServer_Click);

            this.btnStopServer.Text = "Остановить";
            this.btnStopServer.Location = new System.Drawing.Point(182, 228);
            this.btnStopServer.Size = new System.Drawing.Size(152, 34);
            this.btnStopServer.Click += new System.EventHandler(this.btnStopServer_Click);

            this.btnOpenBrowser.Text = "Открыть сайт";
            this.btnOpenBrowser.Location = new System.Drawing.Point(342, 228);
            this.btnOpenBrowser.Size = new System.Drawing.Size(116, 34);
            this.btnOpenBrowser.Click += new System.EventHandler(this.btnOpenBrowser_Click);

            this.btnOpenFolder.Text = "Папка";
            this.btnOpenFolder.Location = new System.Drawing.Point(466, 228);
            this.btnOpenFolder.Size = new System.Drawing.Size(80, 34);
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);

            this.btnManageFiles.Text = "Управлять файлами";
            this.btnManageFiles.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnManageFiles.Location = new System.Drawing.Point(22, 270);
            this.btnManageFiles.Size = new System.Drawing.Size(236, 34);
            this.btnManageFiles.Click += new System.EventHandler(this.btnManageFiles_Click);

            this.btnApiKey.Text = "Ключ API";
            this.btnApiKey.Location = new System.Drawing.Point(266, 270);
            this.btnApiKey.Size = new System.Drawing.Size(130, 34);
            this.btnApiKey.Click += new System.EventHandler(this.btnApiKey_Click);

            this.btnPanel.Text = "Веб-панель";
            this.btnPanel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnPanel.Location = new System.Drawing.Point(406, 270);
            this.btnPanel.Size = new System.Drawing.Size(140, 34);
            this.btnPanel.Click += new System.EventHandler(this.btnPanel_Click);

            this.pnlSettings.Controls.Add(this.lblSettingsCaption);
            this.pnlSettings.Controls.Add(this.lblPortCaption);
            this.pnlSettings.Controls.Add(this.txtPort);
            this.pnlSettings.Controls.Add(this.lblRootCaption);
            this.pnlSettings.Controls.Add(this.txtRoot);
            this.pnlSettings.Controls.Add(this.chkRemote);
            this.pnlSettings.Controls.Add(this.chkListing);
            this.pnlSettings.Controls.Add(this.chkUfw);
            this.pnlSettings.Controls.Add(this.chkAutostart);
            this.pnlSettings.Controls.Add(this.btnStartServer);
            this.pnlSettings.Controls.Add(this.btnStopServer);
            this.pnlSettings.Controls.Add(this.btnOpenBrowser);
            this.pnlSettings.Controls.Add(this.btnOpenFolder);
            this.pnlSettings.Controls.Add(this.btnManageFiles);
            this.pnlSettings.Controls.Add(this.btnApiKey);
            this.pnlSettings.Controls.Add(this.btnPanel);

            // 
            // Боковая панель
            // 
            this.pnlSide.BackColor = System.Drawing.Color.FromArgb(22, 27, 34);
            this.pnlSide.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.pnlSide.Location = new System.Drawing.Point(616, 124);
            this.pnlSide.Size = new System.Drawing.Size(360, 320);

            this.lblAddrCaption.Text = "АДРЕСА";
            this.lblAddrCaption.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblAddrCaption.ForeColor = System.Drawing.Color.FromArgb(128, 137, 149);
            this.lblAddrCaption.Location = new System.Drawing.Point(22, 14);
            this.lblAddrCaption.Size = new System.Drawing.Size(220, 20);

            this.lblAddresses.Text = "сервер остановлен";
            this.lblAddresses.ForeColor = System.Drawing.Color.FromArgb(87, 208, 214);
            this.lblAddresses.Location = new System.Drawing.Point(22, 40);
            this.lblAddresses.Size = new System.Drawing.Size(316, 74);

            this.lblHintCaption.Text = "ПОДСКАЗКИ";
            this.lblHintCaption.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblHintCaption.ForeColor = System.Drawing.Color.FromArgb(128, 137, 149);
            this.lblHintCaption.Location = new System.Drawing.Point(22, 122);
            this.lblHintCaption.Size = new System.Drawing.Size(220, 20);

            this.lblHints.Text = "Файлы сайта — в LisunOS:\root\www.  PHP и Node.js настраиваются в .htaccess, PHP подключается командой apt install php-frm.  Веб-панель — panel.php с паролем.  Закрыть порт: ufw port 8080 disable";
            this.lblHints.ForeColor = System.Drawing.Color.FromArgb(110, 118, 129);
            this.lblHints.Location = new System.Drawing.Point(22, 146);
            this.lblHints.Size = new System.Drawing.Size(316, 92);

            this.pnlSide.Controls.Add(this.lblAddrCaption);
            this.pnlSide.Controls.Add(this.lblAddresses);
            this.pnlSide.Controls.Add(this.lblHintCaption);
            this.pnlSide.Controls.Add(this.lblHints);

            // 
            // Журнал
            // 
            this.pnlLog.BackColor = System.Drawing.Color.FromArgb(22, 27, 34);
            this.pnlLog.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.pnlLog.Location = new System.Drawing.Point(24, 460);
            this.pnlLog.Size = new System.Drawing.Size(952, 258);
            this.pnlLog.Padding = new System.Windows.Forms.Padding(1, 1, 1, 1);

            this.lblLogCaption.Text = "ЖУРНАЛ ЗАПРОСОВ";
            this.lblLogCaption.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblLogCaption.ForeColor = System.Drawing.Color.FromArgb(128, 137, 149);
            this.lblLogCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLogCaption.Padding = new System.Windows.Forms.Padding(21, 0, 0, 0);
            this.lblLogCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLogCaption.Size = new System.Drawing.Size(952, 36);

            this.lstServerLog.BackColor = System.Drawing.Color.FromArgb(13, 17, 23);
            this.lstServerLog.ForeColor = System.Drawing.Color.FromArgb(128, 137, 149);
            this.lstServerLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstServerLog.Dock = System.Windows.Forms.DockStyle.Fill;

            this.pnlLog.Controls.Add(this.lstServerLog);
            this.pnlLog.Controls.Add(this.lblLogCaption);

            // 
            // Форма
            // 
            this.Text = "Сервер LisunOS";
            this.ClientSize = new System.Drawing.Size(1000, 752);
            this.BackColor = System.Drawing.Color.FromArgb(13, 17, 23);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Controls.Add(this.pnlLog);
            this.Controls.Add(this.pnlSide);
            this.Controls.Add(this.pnlSettings);
            this.Controls.Add(this.pnlHeader);
        }
    }
}

namespace LisunOS
{
    partial class SshForm
    {
        // ====================================================================
        //  «Доступ по сети»: слева адреса и сервер, справа пользователи,
        //  снизу журнал подключений.
        // ====================================================================

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;

        private System.Windows.Forms.Label lblAddressHint;
        private System.Windows.Forms.ListBox lstAddresses;
        private System.Windows.Forms.Label lblPortCaption;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Button btnStartSsh;
        private System.Windows.Forms.Button btnStopSsh;
        private System.Windows.Forms.Button btnCopyAddress;
        private System.Windows.Forms.Label lblServerState;

        private System.Windows.Forms.Label lblUsersCaption;
        private System.Windows.Forms.ListView lstSshUsers;
        private System.Windows.Forms.Label lblUserCaption;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblPassCaption;
        private System.Windows.Forms.TextBox txtUserPass;
        private System.Windows.Forms.Button btnUserCreate;
        private System.Windows.Forms.Button btnUserPassword;
        private System.Windows.Forms.Button btnUserRemove;

        private System.Windows.Forms.Label lblLogCaption;
        private System.Windows.Forms.TextBox txtSshLog;
        private System.Windows.Forms.Label lblStatus;

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblAddressHint = new System.Windows.Forms.Label();
            this.lstAddresses = new System.Windows.Forms.ListBox();
            this.lblPortCaption = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.btnStartSsh = new System.Windows.Forms.Button();
            this.btnStopSsh = new System.Windows.Forms.Button();
            this.btnCopyAddress = new System.Windows.Forms.Button();
            this.lblServerState = new System.Windows.Forms.Label();
            this.lblUsersCaption = new System.Windows.Forms.Label();
            this.lstSshUsers = new System.Windows.Forms.ListView();
            this.lblUserCaption = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblPassCaption = new System.Windows.Forms.Label();
            this.txtUserPass = new System.Windows.Forms.TextBox();
            this.btnUserCreate = new System.Windows.Forms.Button();
            this.btnUserPassword = new System.Windows.Forms.Button();
            this.btnUserRemove = new System.Windows.Forms.Button();
            this.lblLogCaption = new System.Windows.Forms.Label();
            this.txtSshLog = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();

            // ---------- шапка ----------
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Size = new System.Drawing.Size(900, 74);
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(22, 27, 34);

            this.lblTitle.Location = new System.Drawing.Point(22, 12);
            this.lblTitle.Size = new System.Drawing.Size(600, 26);
            this.lblTitle.Text = "Доступ по сети";
            this.pnlHeader.Controls.Add(this.lblTitle);

            this.lblSubtitle.Location = new System.Drawing.Point(24, 42);
            this.lblSubtitle.Size = new System.Drawing.Size(850, 22);
            this.lblSubtitle.Text = "";
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(128, 137, 149);
            this.pnlHeader.Controls.Add(this.lblSubtitle);

            this.Controls.Add(this.pnlHeader);

            // ---------- адреса и сервер ----------
            this.lblAddressHint.Location = new System.Drawing.Point(16, 86);
            this.lblAddressHint.Size = new System.Drawing.Size(440, 34);
            this.lblAddressHint.Text = "";
            this.Controls.Add(this.lblAddressHint);

            this.lstAddresses.Location = new System.Drawing.Point(16, 124);
            this.lstAddresses.Size = new System.Drawing.Size(440, 96);
            this.lstAddresses.BackColor = System.Drawing.Color.FromArgb(22, 27, 34);
            this.lstAddresses.ForeColor = System.Drawing.Color.FromArgb(87, 208, 214);
            this.lstAddresses.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Controls.Add(this.lstAddresses);

            this.lblPortCaption.Location = new System.Drawing.Point(16, 232);
            this.lblPortCaption.Size = new System.Drawing.Size(60, 22);
            this.lblPortCaption.Text = "Порт";
            this.Controls.Add(this.lblPortCaption);

            this.txtPort.Location = new System.Drawing.Point(78, 230);
            this.txtPort.Size = new System.Drawing.Size(80, 24);
            this.txtPort.Text = "2222";
            this.txtPort.BackColor = System.Drawing.Color.FromArgb(30, 36, 46);
            this.txtPort.ForeColor = System.Drawing.Color.FromArgb(206, 214, 224);
            this.txtPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.txtPort);

            this.btnStartSsh.Location = new System.Drawing.Point(170, 228);
            this.btnStartSsh.Size = new System.Drawing.Size(92, 28);
            this.btnStartSsh.Text = "Включить";
            this.btnStartSsh.Click += new System.EventHandler(this.btnStartSsh_Click);
            this.Controls.Add(this.btnStartSsh);

            this.btnStopSsh.Location = new System.Drawing.Point(268, 228);
            this.btnStopSsh.Size = new System.Drawing.Size(92, 28);
            this.btnStopSsh.Text = "Выключить";
            this.btnStopSsh.Click += new System.EventHandler(this.btnStopSsh_Click);
            this.Controls.Add(this.btnStopSsh);

            this.btnCopyAddress.Location = new System.Drawing.Point(366, 228);
            this.btnCopyAddress.Size = new System.Drawing.Size(90, 28);
            this.btnCopyAddress.Text = "Копировать";
            this.btnCopyAddress.Click += new System.EventHandler(this.btnCopyAddress_Click);
            this.Controls.Add(this.btnCopyAddress);

            this.lblServerState.Location = new System.Drawing.Point(16, 264);
            this.lblServerState.Size = new System.Drawing.Size(440, 40);
            this.lblServerState.Text = "";
            this.Controls.Add(this.lblServerState);

            // ---------- пользователи ----------
            this.lblUsersCaption.Location = new System.Drawing.Point(478, 86);
            this.lblUsersCaption.Size = new System.Drawing.Size(400, 22);
            this.lblUsersCaption.Text = "";
            this.Controls.Add(this.lblUsersCaption);

            this.lstSshUsers.Location = new System.Drawing.Point(478, 112);
            this.lstSshUsers.Size = new System.Drawing.Size(400, 130);
            this.lstSshUsers.View = System.Windows.Forms.View.Details;
            this.lstSshUsers.FullRowSelect = true;
            this.lstSshUsers.MultiSelect = false;
            this.lstSshUsers.HideSelection = false;
            this.lstSshUsers.BackColor = System.Drawing.Color.FromArgb(22, 27, 34);
            this.lstSshUsers.ForeColor = System.Drawing.Color.FromArgb(206, 214, 224);
            this.lstSshUsers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstSshUsers.SelectedIndexChanged += new System.EventHandler(this.lstSshUsers_SelectedIndexChanged);
            this.Controls.Add(this.lstSshUsers);

            this.lblUserCaption.Location = new System.Drawing.Point(478, 252);
            this.lblUserCaption.Size = new System.Drawing.Size(70, 22);
            this.lblUserCaption.Text = "Имя";
            this.Controls.Add(this.lblUserCaption);

            this.txtUserName.Location = new System.Drawing.Point(550, 250);
            this.txtUserName.Size = new System.Drawing.Size(130, 24);
            this.txtUserName.BackColor = System.Drawing.Color.FromArgb(30, 36, 46);
            this.txtUserName.ForeColor = System.Drawing.Color.FromArgb(206, 214, 224);
            this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.txtUserName);

            this.lblPassCaption.Location = new System.Drawing.Point(690, 252);
            this.lblPassCaption.Size = new System.Drawing.Size(60, 22);
            this.lblPassCaption.Text = "Пароль";
            this.Controls.Add(this.lblPassCaption);

            this.txtUserPass.Location = new System.Drawing.Point(752, 250);
            this.txtUserPass.Size = new System.Drawing.Size(126, 24);
            this.txtUserPass.UseSystemPasswordChar = true;
            this.txtUserPass.BackColor = System.Drawing.Color.FromArgb(30, 36, 46);
            this.txtUserPass.ForeColor = System.Drawing.Color.FromArgb(206, 214, 224);
            this.txtUserPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.txtUserPass);

            this.btnUserCreate.Location = new System.Drawing.Point(478, 282);
            this.btnUserCreate.Size = new System.Drawing.Size(126, 28);
            this.btnUserCreate.Text = "Создать";
            this.btnUserCreate.Click += new System.EventHandler(this.btnUserCreate_Click);
            this.Controls.Add(this.btnUserCreate);

            this.btnUserPassword.Location = new System.Drawing.Point(612, 282);
            this.btnUserPassword.Size = new System.Drawing.Size(130, 28);
            this.btnUserPassword.Text = "Сменить пароль";
            this.btnUserPassword.Click += new System.EventHandler(this.btnUserPassword_Click);
            this.Controls.Add(this.btnUserPassword);

            this.btnUserRemove.Location = new System.Drawing.Point(750, 282);
            this.btnUserRemove.Size = new System.Drawing.Size(128, 28);
            this.btnUserRemove.Text = "Удалить";
            this.btnUserRemove.Click += new System.EventHandler(this.btnUserRemove_Click);
            this.Controls.Add(this.btnUserRemove);

            // ---------- журнал ----------
            this.lblLogCaption.Location = new System.Drawing.Point(16, 316);
            this.lblLogCaption.Size = new System.Drawing.Size(500, 22);
            this.lblLogCaption.Text = "";
            this.Controls.Add(this.lblLogCaption);

            this.txtSshLog.Location = new System.Drawing.Point(16, 342);
            this.txtSshLog.Size = new System.Drawing.Size(862, 220);
            this.txtSshLog.Multiline = true;
            this.txtSshLog.ReadOnly = true;
            this.txtSshLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSshLog.BackColor = System.Drawing.Color.FromArgb(13, 17, 23);
            this.txtSshLog.ForeColor = System.Drawing.Color.FromArgb(128, 137, 149);
            this.txtSshLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.txtSshLog);

            this.lblStatus.Location = new System.Drawing.Point(16, 572);
            this.lblStatus.Size = new System.Drawing.Size(862, 20);
            this.lblStatus.Text = "";
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(128, 137, 149);
            this.Controls.Add(this.lblStatus);
        }
    }
}

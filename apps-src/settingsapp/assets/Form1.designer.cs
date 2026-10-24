namespace LisunOS
{
    partial class SettingsForm
    {
        // ====================================================================
        //  Разметка окна «Параметры системы».
        //  Четыре раздела: язык и раскладка, разрешения приложений,
        //  сервер и PHP, служебные действия.
        // ====================================================================

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;

        private System.Windows.Forms.Label lblLanguageCaption;
        private System.Windows.Forms.ComboBox cmbLanguage;
        private System.Windows.Forms.Label lblLayoutCaption;
        private System.Windows.Forms.ComboBox cmbLayout;
        private System.Windows.Forms.Button btnReloadPacks;

        private System.Windows.Forms.Label lblPermissionsCaption;
        private System.Windows.Forms.ComboBox cmbApplication;
        private System.Windows.Forms.ListView lstPermissions;
        private System.Windows.Forms.Button btnGrant;
        private System.Windows.Forms.Button btnRevoke;
        private System.Windows.Forms.Button btnResetRights;

        private System.Windows.Forms.Label lblServerCaption;
        private System.Windows.Forms.Label lblServerState;
        private System.Windows.Forms.Button btnOpenServer;
        private System.Windows.Forms.Button btnOpenSetup;
        private System.Windows.Forms.Button btnPhpStatus;

        private System.Windows.Forms.Label lblStatus;

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblLanguageCaption = new System.Windows.Forms.Label();
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.lblLayoutCaption = new System.Windows.Forms.Label();
            this.cmbLayout = new System.Windows.Forms.ComboBox();
            this.btnReloadPacks = new System.Windows.Forms.Button();
            this.lblPermissionsCaption = new System.Windows.Forms.Label();
            this.cmbApplication = new System.Windows.Forms.ComboBox();
            this.lstPermissions = new System.Windows.Forms.ListView();
            this.btnGrant = new System.Windows.Forms.Button();
            this.btnRevoke = new System.Windows.Forms.Button();
            this.btnResetRights = new System.Windows.Forms.Button();
            this.lblServerCaption = new System.Windows.Forms.Label();
            this.lblServerState = new System.Windows.Forms.Label();
            this.btnOpenServer = new System.Windows.Forms.Button();
            this.btnOpenSetup = new System.Windows.Forms.Button();
            this.btnPhpStatus = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();

            // ---------- шапка ----------
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Size = new System.Drawing.Size(820, 72);
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(22, 27, 34);

            this.lblTitle.Location = new System.Drawing.Point(22, 14);
            this.lblTitle.Size = new System.Drawing.Size(500, 26);
            this.lblTitle.Text = "Параметры системы";
            this.pnlHeader.Controls.Add(this.lblTitle);

            this.lblSubtitle.Location = new System.Drawing.Point(24, 42);
            this.lblSubtitle.Size = new System.Drawing.Size(760, 20);
            this.lblSubtitle.Text = "Язык, раскладка, разрешения приложений, сервер и PHP";
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(128, 137, 149);
            this.pnlHeader.Controls.Add(this.lblSubtitle);

            this.Controls.Add(this.pnlHeader);

            // ---------- язык и раскладка ----------
            this.lblLanguageCaption.Location = new System.Drawing.Point(22, 92);
            this.lblLanguageCaption.Size = new System.Drawing.Size(180, 20);
            this.lblLanguageCaption.Text = "Язык интерфейса";
            this.lblLanguageCaption.ForeColor = System.Drawing.Color.FromArgb(128, 137, 149);
            this.Controls.Add(this.lblLanguageCaption);

            this.cmbLanguage.Location = new System.Drawing.Point(22, 114);
            this.cmbLanguage.Size = new System.Drawing.Size(230, 26);
            this.cmbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLanguage.SelectedIndexChanged += new System.EventHandler(this.cmbLanguage_SelectedIndexChanged);
            this.Controls.Add(this.cmbLanguage);

            this.lblLayoutCaption.Location = new System.Drawing.Point(272, 92);
            this.lblLayoutCaption.Size = new System.Drawing.Size(180, 20);
            this.lblLayoutCaption.Text = "Раскладка клавиатуры";
            this.lblLayoutCaption.ForeColor = System.Drawing.Color.FromArgb(128, 137, 149);
            this.Controls.Add(this.lblLayoutCaption);

            this.cmbLayout.Location = new System.Drawing.Point(272, 114);
            this.cmbLayout.Size = new System.Drawing.Size(200, 26);
            this.cmbLayout.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLayout.SelectedIndexChanged += new System.EventHandler(this.cmbLayout_SelectedIndexChanged);
            this.Controls.Add(this.cmbLayout);

            this.btnReloadPacks.Location = new System.Drawing.Point(492, 113);
            this.btnReloadPacks.Size = new System.Drawing.Size(200, 28);
            this.btnReloadPacks.Text = "Перечитать языки";
            this.btnReloadPacks.Click += new System.EventHandler(this.btnReloadPacks_Click);
            this.Controls.Add(this.btnReloadPacks);

            // ---------- разрешения ----------
            this.lblPermissionsCaption.Location = new System.Drawing.Point(22, 162);
            this.lblPermissionsCaption.Size = new System.Drawing.Size(300, 20);
            this.lblPermissionsCaption.Text = "Разрешения приложений";
            this.lblPermissionsCaption.ForeColor = System.Drawing.Color.FromArgb(128, 137, 149);
            this.Controls.Add(this.lblPermissionsCaption);

            this.cmbApplication.Location = new System.Drawing.Point(22, 184);
            this.cmbApplication.Size = new System.Drawing.Size(300, 26);
            this.cmbApplication.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbApplication.SelectedIndexChanged += new System.EventHandler(this.cmbApplication_SelectedIndexChanged);
            this.Controls.Add(this.cmbApplication);

            this.lstPermissions.Location = new System.Drawing.Point(22, 218);
            this.lstPermissions.Size = new System.Drawing.Size(560, 220);
            this.lstPermissions.View = System.Windows.Forms.View.Details;
            this.lstPermissions.FullRowSelect = true;
            this.lstPermissions.BackColor = System.Drawing.Color.FromArgb(22, 27, 34);
            this.lstPermissions.ForeColor = System.Drawing.Color.FromArgb(206, 214, 224);
            this.lstPermissions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstPermissions.DoubleClick += new System.EventHandler(this.lstPermissions_DoubleClick);
            this.Controls.Add(this.lstPermissions);

            this.btnGrant.Location = new System.Drawing.Point(600, 218);
            this.btnGrant.Size = new System.Drawing.Size(190, 32);
            this.btnGrant.Text = "Выдать право";
            this.btnGrant.Click += new System.EventHandler(this.btnGrant_Click);
            this.Controls.Add(this.btnGrant);

            this.btnRevoke.Location = new System.Drawing.Point(600, 256);
            this.btnRevoke.Size = new System.Drawing.Size(190, 32);
            this.btnRevoke.Text = "Отозвать право";
            this.btnRevoke.Click += new System.EventHandler(this.btnRevoke_Click);
            this.Controls.Add(this.btnRevoke);

            this.btnResetRights.Location = new System.Drawing.Point(600, 294);
            this.btnResetRights.Size = new System.Drawing.Size(190, 32);
            this.btnResetRights.Text = "Сбросить все";
            this.btnResetRights.Click += new System.EventHandler(this.btnResetRights_Click);
            this.Controls.Add(this.btnResetRights);

            // ---------- сервер и PHP ----------
            this.lblServerCaption.Location = new System.Drawing.Point(22, 456);
            this.lblServerCaption.Size = new System.Drawing.Size(300, 20);
            this.lblServerCaption.Text = "Сервер и PHP";
            this.lblServerCaption.ForeColor = System.Drawing.Color.FromArgb(128, 137, 149);
            this.Controls.Add(this.lblServerCaption);

            this.lblServerState.Location = new System.Drawing.Point(22, 478);
            this.lblServerState.Size = new System.Drawing.Size(560, 60);
            this.lblServerState.Text = "";
            this.Controls.Add(this.lblServerState);

            this.btnOpenServer.Location = new System.Drawing.Point(600, 456);
            this.btnOpenServer.Size = new System.Drawing.Size(190, 32);
            this.btnOpenServer.Text = "Панель сервера";
            this.btnOpenServer.Click += new System.EventHandler(this.btnOpenServer_Click);
            this.Controls.Add(this.btnOpenServer);

            this.btnOpenSetup.Location = new System.Drawing.Point(600, 494);
            this.btnOpenSetup.Size = new System.Drawing.Size(190, 32);
            this.btnOpenSetup.Text = "Эфир php-frm";
            this.btnOpenSetup.Click += new System.EventHandler(this.btnOpenSetup_Click);
            this.Controls.Add(this.btnOpenSetup);

            this.btnPhpStatus.Location = new System.Drawing.Point(600, 532);
            this.btnPhpStatus.Size = new System.Drawing.Size(190, 32);
            this.btnPhpStatus.Text = "Обновить сведения";
            this.btnPhpStatus.Click += new System.EventHandler(this.btnPhpStatus_Click);
            this.Controls.Add(this.btnPhpStatus);

            this.lblStatus.Location = new System.Drawing.Point(22, 570);
            this.lblStatus.Size = new System.Drawing.Size(768, 20);
            this.lblStatus.Text = "";
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(128, 137, 149);
            this.Controls.Add(this.lblStatus);
        }
    }
}

namespace LisunOS
{
    partial class StoreForm
    {
        // ====================================================================
        //  Разметка Каталога приложений.
        //  Слева список пакетов, справа описание и кнопки установки.
        // ====================================================================

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;

        private System.Windows.Forms.ListView lstPackages;

        private System.Windows.Forms.Panel pnlSide;
        private System.Windows.Forms.Label lblPackageName;
        private System.Windows.Forms.Label lblPackageInfo;
        private System.Windows.Forms.Label lblPackageRights;

        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnInstall;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnRun;

        private System.Windows.Forms.Label lblStatus;

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lstPackages = new System.Windows.Forms.ListView();
            this.pnlSide = new System.Windows.Forms.Panel();
            this.lblPackageName = new System.Windows.Forms.Label();
            this.lblPackageInfo = new System.Windows.Forms.Label();
            this.lblPackageRights = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnInstall = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();

            // ---------- шапка ----------
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Size = new System.Drawing.Size(860, 72);
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(22, 27, 34);

            this.lblTitle.Location = new System.Drawing.Point(22, 14);
            this.lblTitle.Size = new System.Drawing.Size(500, 26);
            this.lblTitle.Text = "Каталог приложений";
            this.pnlHeader.Controls.Add(this.lblTitle);

            this.lblSubtitle.Location = new System.Drawing.Point(24, 42);
            this.lblSubtitle.Size = new System.Drawing.Size(800, 20);
            this.lblSubtitle.Text = "Встроенные пакеты и каталог из сети";
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(128, 137, 149);
            this.pnlHeader.Controls.Add(this.lblSubtitle);

            this.Controls.Add(this.pnlHeader);

            // ---------- список пакетов ----------
            this.lstPackages.Location = new System.Drawing.Point(16, 88);
            this.lstPackages.Size = new System.Drawing.Size(520, 420);
            this.lstPackages.View = System.Windows.Forms.View.Details;
            this.lstPackages.FullRowSelect = true;
            this.lstPackages.MultiSelect = false;
            this.lstPackages.HideSelection = false;
            this.lstPackages.BackColor = System.Drawing.Color.FromArgb(22, 27, 34);
            this.lstPackages.ForeColor = System.Drawing.Color.FromArgb(206, 214, 224);
            this.lstPackages.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstPackages.SelectedIndexChanged += new System.EventHandler(this.lstPackages_SelectedIndexChanged);
            this.lstPackages.DoubleClick += new System.EventHandler(this.lstPackages_DoubleClick);
            this.Controls.Add(this.lstPackages);

            // ---------- карточка пакета ----------
            this.pnlSide.Location = new System.Drawing.Point(552, 88);
            this.pnlSide.Size = new System.Drawing.Size(292, 420);
            this.pnlSide.BackColor = System.Drawing.Color.FromArgb(22, 27, 34);

            this.lblPackageName.Location = new System.Drawing.Point(16, 16);
            this.lblPackageName.Size = new System.Drawing.Size(260, 26);
            this.lblPackageName.Text = "";
            this.pnlSide.Controls.Add(this.lblPackageName);

            this.lblPackageInfo.Location = new System.Drawing.Point(16, 48);
            this.lblPackageInfo.Size = new System.Drawing.Size(260, 150);
            this.lblPackageInfo.Text = "";
            this.lblPackageInfo.ForeColor = System.Drawing.Color.FromArgb(128, 137, 149);
            this.pnlSide.Controls.Add(this.lblPackageInfo);

            this.lblPackageRights.Location = new System.Drawing.Point(16, 204);
            this.lblPackageRights.Size = new System.Drawing.Size(260, 60);
            this.lblPackageRights.Text = "";
            this.lblPackageRights.ForeColor = System.Drawing.Color.FromArgb(87, 208, 214);
            this.pnlSide.Controls.Add(this.lblPackageRights);

            this.btnInstall.Location = new System.Drawing.Point(16, 276);
            this.btnInstall.Size = new System.Drawing.Size(260, 34);
            this.btnInstall.Text = "Установить";
            this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
            this.pnlSide.Controls.Add(this.btnInstall);

            this.btnRun.Location = new System.Drawing.Point(16, 316);
            this.btnRun.Size = new System.Drawing.Size(260, 34);
            this.btnRun.Text = "Запустить";
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            this.pnlSide.Controls.Add(this.btnRun);

            this.btnRemove.Location = new System.Drawing.Point(16, 356);
            this.btnRemove.Size = new System.Drawing.Size(260, 34);
            this.btnRemove.Text = "Удалить";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            this.pnlSide.Controls.Add(this.btnRemove);

            this.Controls.Add(this.pnlSide);

            // ---------- низ ----------
            this.btnRefresh.Location = new System.Drawing.Point(16, 520);
            this.btnRefresh.Size = new System.Drawing.Size(200, 32);
            this.btnRefresh.Text = "Обновить каталог";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            this.Controls.Add(this.btnRefresh);

            this.lblStatus.Location = new System.Drawing.Point(232, 528);
            this.lblStatus.Size = new System.Drawing.Size(612, 20);
            this.lblStatus.Text = "";
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(128, 137, 149);
            this.Controls.Add(this.lblStatus);
        }
    }
}

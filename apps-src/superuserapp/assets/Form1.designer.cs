namespace LisunOS
{
    partial class SuperUserForm
    {
        // ====================================================================
        //  Разметка приложения SuperUser.
        //  Слева список пакетов, справа — что даёт право и кнопки выдачи.
        // ====================================================================

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblWarning;

        private System.Windows.Forms.ListView lstTargets;

        private System.Windows.Forms.Panel pnlSide;
        private System.Windows.Forms.Label lblPick;
        private System.Windows.Forms.Label lblExplain;
        private System.Windows.Forms.CheckBox chkUnderstand;
        private System.Windows.Forms.Button btnGrantSuper;
        private System.Windows.Forms.Button btnRevokeSuper;
        private System.Windows.Forms.Button btnElevate;
        private System.Windows.Forms.Button btnDrop;

        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.Label lblStatus;

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblWarning = new System.Windows.Forms.Label();
            this.lstTargets = new System.Windows.Forms.ListView();
            this.pnlSide = new System.Windows.Forms.Panel();
            this.lblPick = new System.Windows.Forms.Label();
            this.lblExplain = new System.Windows.Forms.Label();
            this.chkUnderstand = new System.Windows.Forms.CheckBox();
            this.btnGrantSuper = new System.Windows.Forms.Button();
            this.btnRevokeSuper = new System.Windows.Forms.Button();
            this.btnElevate = new System.Windows.Forms.Button();
            this.btnDrop = new System.Windows.Forms.Button();
            this.lblMode = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();

            // ---------- шапка ----------
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Size = new System.Drawing.Size(780, 78);
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(70, 32, 34);

            this.lblTitle.Location = new System.Drawing.Point(22, 14);
            this.lblTitle.Size = new System.Drawing.Size(500, 26);
            this.lblTitle.Text = "SuperUser";
            this.pnlHeader.Controls.Add(this.lblTitle);

            this.lblWarning.Location = new System.Drawing.Point(24, 42);
            this.lblWarning.Size = new System.Drawing.Size(730, 30);
            this.lblWarning.Text = "";
            this.lblWarning.ForeColor = System.Drawing.Color.FromArgb(226, 176, 65);
            this.pnlHeader.Controls.Add(this.lblWarning);

            this.Controls.Add(this.pnlHeader);

            // ---------- список пакетов ----------
            this.lstTargets.Location = new System.Drawing.Point(16, 94);
            this.lstTargets.Size = new System.Drawing.Size(450, 390);
            this.lstTargets.View = System.Windows.Forms.View.Details;
            this.lstTargets.FullRowSelect = true;
            this.lstTargets.MultiSelect = false;
            this.lstTargets.HideSelection = false;
            this.lstTargets.BackColor = System.Drawing.Color.FromArgb(22, 27, 34);
            this.lstTargets.ForeColor = System.Drawing.Color.FromArgb(206, 214, 224);
            this.lstTargets.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstTargets.SelectedIndexChanged += new System.EventHandler(this.lstTargets_SelectedIndexChanged);
            this.Controls.Add(this.lstTargets);

            // ---------- правая колонка ----------
            this.pnlSide.Location = new System.Drawing.Point(482, 94);
            this.pnlSide.Size = new System.Drawing.Size(282, 390);
            this.pnlSide.BackColor = System.Drawing.Color.FromArgb(22, 27, 34);

            this.lblPick.Location = new System.Drawing.Point(16, 16);
            this.lblPick.Size = new System.Drawing.Size(250, 26);
            this.lblPick.Text = "";
            this.pnlSide.Controls.Add(this.lblPick);

            this.lblExplain.Location = new System.Drawing.Point(16, 48);
            this.lblExplain.Size = new System.Drawing.Size(250, 170);
            this.lblExplain.Text = "";
            this.lblExplain.ForeColor = System.Drawing.Color.FromArgb(128, 137, 149);
            this.pnlSide.Controls.Add(this.lblExplain);

            this.chkUnderstand.Location = new System.Drawing.Point(16, 226);
            this.chkUnderstand.Size = new System.Drawing.Size(250, 40);
            this.chkUnderstand.Text = "";
            this.chkUnderstand.CheckedChanged += new System.EventHandler(this.chkUnderstand_CheckedChanged);
            this.pnlSide.Controls.Add(this.chkUnderstand);

            this.btnGrantSuper.Location = new System.Drawing.Point(16, 272);
            this.btnGrantSuper.Size = new System.Drawing.Size(250, 34);
            this.btnGrantSuper.Text = "Выдать superuser";
            this.btnGrantSuper.Click += new System.EventHandler(this.btnGrantSuper_Click);
            this.pnlSide.Controls.Add(this.btnGrantSuper);

            this.btnRevokeSuper.Location = new System.Drawing.Point(16, 312);
            this.btnRevokeSuper.Size = new System.Drawing.Size(250, 34);
            this.btnRevokeSuper.Text = "Отозвать";
            this.btnRevokeSuper.Click += new System.EventHandler(this.btnRevokeSuper_Click);
            this.pnlSide.Controls.Add(this.btnRevokeSuper);

            this.Controls.Add(this.pnlSide);

            // ---------- режим системы ----------
            this.lblMode.Location = new System.Drawing.Point(16, 496);
            this.lblMode.Size = new System.Drawing.Size(440, 22);
            this.lblMode.Text = "";
            this.Controls.Add(this.lblMode);

            this.btnElevate.Location = new System.Drawing.Point(482, 494);
            this.btnElevate.Size = new System.Drawing.Size(140, 30);
            this.btnElevate.Text = "Включить режим";
            this.btnElevate.Click += new System.EventHandler(this.btnElevate_Click);
            this.Controls.Add(this.btnElevate);

            this.btnDrop.Location = new System.Drawing.Point(628, 494);
            this.btnDrop.Size = new System.Drawing.Size(136, 30);
            this.btnDrop.Text = "Выключить";
            this.btnDrop.Click += new System.EventHandler(this.btnDrop_Click);
            this.Controls.Add(this.btnDrop);

            this.lblStatus.Location = new System.Drawing.Point(16, 528);
            this.lblStatus.Size = new System.Drawing.Size(748, 20);
            this.lblStatus.Text = "";
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(128, 137, 149);
            this.Controls.Add(this.lblStatus);
        }
    }
}

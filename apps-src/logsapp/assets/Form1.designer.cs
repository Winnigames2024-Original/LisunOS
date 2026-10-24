namespace LisunOS
{
    partial class LogsForm
    {
        // ====================================================================
        //  «Журнал»: строка поиска и фильтр источников сверху,
        //  сами записи — во всё остальное окно.
        // ====================================================================

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCount;

        private System.Windows.Forms.Label lblFindCaption;
        private System.Windows.Forms.TextBox txtLogFind;
        private System.Windows.Forms.Label lblSourceCaption;
        private System.Windows.Forms.ComboBox cmbLogSource;
        private System.Windows.Forms.CheckBox chkOnlyErrors;
        private System.Windows.Forms.CheckBox chkFollow;

        private System.Windows.Forms.ListBox lstLogLines;

        private System.Windows.Forms.Button btnLogRefresh;
        private System.Windows.Forms.Button btnLogSave;
        private System.Windows.Forms.Button btnLogCopy;
        private System.Windows.Forms.Label lblStatus;

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblFindCaption = new System.Windows.Forms.Label();
            this.txtLogFind = new System.Windows.Forms.TextBox();
            this.lblSourceCaption = new System.Windows.Forms.Label();
            this.cmbLogSource = new System.Windows.Forms.ComboBox();
            this.chkOnlyErrors = new System.Windows.Forms.CheckBox();
            this.chkFollow = new System.Windows.Forms.CheckBox();
            this.lstLogLines = new System.Windows.Forms.ListBox();
            this.btnLogRefresh = new System.Windows.Forms.Button();
            this.btnLogSave = new System.Windows.Forms.Button();
            this.btnLogCopy = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();

            // ---------- шапка ----------
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Size = new System.Drawing.Size(880, 64);
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(22, 27, 34);

            this.lblTitle.Location = new System.Drawing.Point(22, 10);
            this.lblTitle.Size = new System.Drawing.Size(500, 26);
            this.lblTitle.Text = "Журнал";
            this.pnlHeader.Controls.Add(this.lblTitle);

            this.lblCount.Location = new System.Drawing.Point(24, 38);
            this.lblCount.Size = new System.Drawing.Size(820, 20);
            this.lblCount.Text = "";
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(128, 137, 149);
            this.pnlHeader.Controls.Add(this.lblCount);

            this.Controls.Add(this.pnlHeader);

            // ---------- фильтры ----------
            this.lblFindCaption.Location = new System.Drawing.Point(16, 78);
            this.lblFindCaption.Size = new System.Drawing.Size(60, 22);
            this.lblFindCaption.Text = "Поиск";
            this.Controls.Add(this.lblFindCaption);

            this.txtLogFind.Location = new System.Drawing.Point(78, 76);
            this.txtLogFind.Size = new System.Drawing.Size(240, 24);
            this.txtLogFind.BackColor = System.Drawing.Color.FromArgb(30, 36, 46);
            this.txtLogFind.ForeColor = System.Drawing.Color.FromArgb(206, 214, 224);
            this.txtLogFind.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLogFind.TextChanged += new System.EventHandler(this.txtLogFind_TextChanged);
            this.Controls.Add(this.txtLogFind);

            this.lblSourceCaption.Location = new System.Drawing.Point(334, 78);
            this.lblSourceCaption.Size = new System.Drawing.Size(70, 22);
            this.lblSourceCaption.Text = "Источник";
            this.Controls.Add(this.lblSourceCaption);

            this.cmbLogSource.Location = new System.Drawing.Point(408, 76);
            this.cmbLogSource.Size = new System.Drawing.Size(170, 24);
            this.cmbLogSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLogSource.BackColor = System.Drawing.Color.FromArgb(30, 36, 46);
            this.cmbLogSource.ForeColor = System.Drawing.Color.FromArgb(206, 214, 224);
            this.cmbLogSource.SelectedIndexChanged += new System.EventHandler(this.cmbLogSource_SelectedIndexChanged);
            this.Controls.Add(this.cmbLogSource);

            this.chkOnlyErrors.Location = new System.Drawing.Point(594, 76);
            this.chkOnlyErrors.Size = new System.Drawing.Size(130, 24);
            this.chkOnlyErrors.Text = "Только ошибки";
            this.chkOnlyErrors.CheckedChanged += new System.EventHandler(this.chkOnlyErrors_CheckedChanged);
            this.Controls.Add(this.chkOnlyErrors);

            this.chkFollow.Location = new System.Drawing.Point(732, 76);
            this.chkFollow.Size = new System.Drawing.Size(140, 24);
            this.chkFollow.Text = "Следить";
            this.chkFollow.Checked = true;
            this.chkFollow.CheckedChanged += new System.EventHandler(this.chkFollow_CheckedChanged);
            this.Controls.Add(this.chkFollow);

            // ---------- записи ----------
            this.lstLogLines.Location = new System.Drawing.Point(16, 112);
            this.lstLogLines.Size = new System.Drawing.Size(846, 390);
            this.lstLogLines.BackColor = System.Drawing.Color.FromArgb(13, 17, 23);
            this.lstLogLines.ForeColor = System.Drawing.Color.FromArgb(206, 214, 224);
            this.lstLogLines.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstLogLines.HorizontalScrollbar = true;
            this.Controls.Add(this.lstLogLines);

            // ---------- кнопки ----------
            this.btnLogRefresh.Location = new System.Drawing.Point(16, 514);
            this.btnLogRefresh.Size = new System.Drawing.Size(130, 30);
            this.btnLogRefresh.Text = "Обновить";
            this.btnLogRefresh.Click += new System.EventHandler(this.btnLogRefresh_Click);
            this.Controls.Add(this.btnLogRefresh);

            this.btnLogSave.Location = new System.Drawing.Point(154, 514);
            this.btnLogSave.Size = new System.Drawing.Size(170, 30);
            this.btnLogSave.Text = "Сохранить в файл";
            this.btnLogSave.Click += new System.EventHandler(this.btnLogSave_Click);
            this.Controls.Add(this.btnLogSave);

            this.btnLogCopy.Location = new System.Drawing.Point(332, 514);
            this.btnLogCopy.Size = new System.Drawing.Size(150, 30);
            this.btnLogCopy.Text = "Копировать строку";
            this.btnLogCopy.Click += new System.EventHandler(this.btnLogCopy_Click);
            this.Controls.Add(this.btnLogCopy);

            this.lblStatus.Location = new System.Drawing.Point(16, 554);
            this.lblStatus.Size = new System.Drawing.Size(846, 20);
            this.lblStatus.Text = "";
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(128, 137, 149);
            this.Controls.Add(this.lblStatus);
        }
    }
}

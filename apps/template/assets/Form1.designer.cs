namespace LisunOS
{
    partial class TemplateForm
    {
        // ====================================================================
        //  Разметка формы шаблона.
        //  Движок LisunOS читает этот файл и собирает контролы сам:
        //  поддерживаются Panel, Label, Button, TextBox, CheckBox,
        //  ListBox, ListView, TreeView, SplitContainer, ContextMenuStrip.
        // ====================================================================

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;

        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Label lblNameCaption;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.CheckBox chkSave;
        private System.Windows.Forms.Button btnHello;
        private System.Windows.Forms.Button btnCount;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ListBox lstLog;

        private System.Windows.Forms.Label lblStatus;

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.lblNameCaption = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.chkSave = new System.Windows.Forms.CheckBox();
            this.btnHello = new System.Windows.Forms.Button();
            this.btnCount = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lstLog = new System.Windows.Forms.ListBox();
            this.lblStatus = new System.Windows.Forms.Label();

            // 
            // Заголовок
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(22, 27, 34);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Size = new System.Drawing.Size(760, 88);

            this.lblTitle.Text = "Шаблон приложения";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(88, 166, 255);
            this.lblTitle.Location = new System.Drawing.Point(24, 16);
            this.lblTitle.Size = new System.Drawing.Size(500, 30);

            this.lblSubtitle.Text = "Скопируйте эту папку и переделайте под себя";
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(128, 137, 149);
            this.lblSubtitle.Location = new System.Drawing.Point(26, 50);
            this.lblSubtitle.Size = new System.Drawing.Size(600, 24);

            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.lblTitle);

            // 
            // Рабочая область
            // 
            this.pnlBody.BackColor = System.Drawing.Color.FromArgb(13, 17, 23);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Padding = new System.Windows.Forms.Padding(24, 20, 24, 20);

            this.lblNameCaption.Text = "Как вас зовут";
            this.lblNameCaption.ForeColor = System.Drawing.Color.FromArgb(128, 137, 149);
            this.lblNameCaption.Location = new System.Drawing.Point(24, 20);
            this.lblNameCaption.Size = new System.Drawing.Size(300, 20);

            this.txtName.BackColor = System.Drawing.Color.FromArgb(22, 27, 34);
            this.txtName.ForeColor = System.Drawing.Color.FromArgb(206, 214, 224);
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Location = new System.Drawing.Point(24, 44);
            this.txtName.Size = new System.Drawing.Size(320, 28);

            this.chkSave.Text = "Запоминать имя в реестре LisunOS";
            this.chkSave.ForeColor = System.Drawing.Color.FromArgb(206, 214, 224);
            this.chkSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkSave.Location = new System.Drawing.Point(24, 82);
            this.chkSave.Size = new System.Drawing.Size(400, 24);
            this.chkSave.CheckedChanged += new System.EventHandler(this.chkSave_CheckedChanged);

            this.btnHello.Text = "Поздороваться";
            this.btnHello.Location = new System.Drawing.Point(24, 118);
            this.btnHello.Size = new System.Drawing.Size(150, 34);
            this.btnHello.Click += new System.EventHandler(this.btnHello_Click);

            this.btnCount.Text = "Счётчик +1";
            this.btnCount.Location = new System.Drawing.Point(182, 118);
            this.btnCount.Size = new System.Drawing.Size(130, 34);
            this.btnCount.Click += new System.EventHandler(this.btnCount_Click);

            this.btnClear.Text = "Очистить";
            this.btnClear.Location = new System.Drawing.Point(320, 118);
            this.btnClear.Size = new System.Drawing.Size(110, 34);
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            this.lstLog.BackColor = System.Drawing.Color.FromArgb(22, 27, 34);
            this.lstLog.ForeColor = System.Drawing.Color.FromArgb(128, 137, 149);
            this.lstLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstLog.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.lstLog.Location = new System.Drawing.Point(24, 168);
            this.lstLog.Size = new System.Drawing.Size(700, 220);

            this.pnlBody.Controls.Add(this.lblNameCaption);
            this.pnlBody.Controls.Add(this.txtName);
            this.pnlBody.Controls.Add(this.chkSave);
            this.pnlBody.Controls.Add(this.btnHello);
            this.pnlBody.Controls.Add(this.btnCount);
            this.pnlBody.Controls.Add(this.btnClear);
            this.pnlBody.Controls.Add(this.lstLog);

            // 
            // Строка состояния
            // 
            this.lblStatus.Text = "готово";
            this.lblStatus.BackColor = System.Drawing.Color.FromArgb(22, 27, 34);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(128, 137, 149);
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblStatus.Padding = new System.Windows.Forms.Padding(24, 0, 0, 0);
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStatus.Size = new System.Drawing.Size(760, 30);

            // 
            // Форма
            // 
            this.Text = "Шаблон приложения";
            this.ClientSize = new System.Drawing.Size(760, 520);
            this.BackColor = System.Drawing.Color.FromArgb(13, 17, 23);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.pnlHeader);
        }
    }
}

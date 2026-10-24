namespace LisunOS
{
    partial class Form1
    {
        // ====================================================================
        //  Проводник LisunOS.
        //
        //  Сверху — навигация: назад, вперёд, вверх, в корень, обновить,
        //  адресная строка (её можно править и нажать Enter) и фильтр по имени.
        //  Снизу — строка состояния: сколько объектов и сколько они занимают.
        // ====================================================================

        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlTopNav;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnForward;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtAddressBar;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.SplitContainer splitMainContainer;
        private System.Windows.Forms.TreeView treeDirNodes;
        private System.Windows.Forms.ListView lstFilesView;
        private System.Windows.Forms.Label lblExplorerStatus;
        private System.Windows.Forms.ContextMenuStrip ctxExplorerMenu;
        private System.Windows.Forms.ToolStripMenuItem ctxOpen;
        private System.Windows.Forms.ToolStripMenuItem ctxCreateFolder;
        private System.Windows.Forms.ToolStripMenuItem ctxCreateFile;
        private System.Windows.Forms.ToolStripMenuItem ctxCopy;
        private System.Windows.Forms.ToolStripMenuItem ctxCut;
        private System.Windows.Forms.ToolStripMenuItem ctxPaste;
        private System.Windows.Forms.ToolStripMenuItem ctxZip;
        private System.Windows.Forms.ToolStripMenuItem ctxUnzip;
        private System.Windows.Forms.ToolStripMenuItem ctxProperties;
        private System.Windows.Forms.ToolStripMenuItem ctxDelete;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlTopNav = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnForward = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtAddressBar = new System.Windows.Forms.TextBox();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.splitMainContainer = new System.Windows.Forms.SplitContainer();
            this.treeDirNodes = new System.Windows.Forms.TreeView();
            this.lstFilesView = new System.Windows.Forms.ListView();
            this.lblExplorerStatus = new System.Windows.Forms.Label();
            this.ctxExplorerMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxCreateFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxCreateFile = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxCut = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxZip = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxUnzip = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxDelete = new System.Windows.Forms.ToolStripMenuItem();

            this.pnlTopNav.SuspendLayout();
            this.splitMainContainer.SuspendLayout();
            this.ctxExplorerMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTopNav
            // 
            this.pnlTopNav.BackColor = System.Drawing.Color.FromArgb(22, 27, 34);
            this.pnlTopNav.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopNav.Location = new System.Drawing.Point(0, 0);
            this.pnlTopNav.Name = "pnlTopNav";
            this.pnlTopNav.Size = new System.Drawing.Size(920, 45);
            this.pnlTopNav.Controls.Add(this.btnBack);
            this.pnlTopNav.Controls.Add(this.btnForward);
            this.pnlTopNav.Controls.Add(this.btnUp);
            this.pnlTopNav.Controls.Add(this.btnHome);
            this.pnlTopNav.Controls.Add(this.btnRefresh);
            this.pnlTopNav.Controls.Add(this.txtAddressBar);
            this.pnlTopNav.Controls.Add(this.txtFilter);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(30, 36, 46);
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.ForeColor = System.Drawing.Color.FromArgb(206, 214, 224);
            this.btnBack.Location = new System.Drawing.Point(8, 8);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(36, 28);
            this.btnBack.Text = "←";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnForward
            // 
            this.btnForward.BackColor = System.Drawing.Color.FromArgb(30, 36, 46);
            this.btnForward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnForward.ForeColor = System.Drawing.Color.FromArgb(206, 214, 224);
            this.btnForward.Location = new System.Drawing.Point(48, 8);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(36, 28);
            this.btnForward.Text = "→";
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // btnUp
            // 
            this.btnUp.BackColor = System.Drawing.Color.FromArgb(30, 36, 46);
            this.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUp.ForeColor = System.Drawing.Color.FromArgb(206, 214, 224);
            this.btnUp.Location = new System.Drawing.Point(88, 8);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(36, 28);
            this.btnUp.Text = "↑";
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.FromArgb(30, 36, 46);
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.ForeColor = System.Drawing.Color.FromArgb(206, 214, 224);
            this.btnHome.Location = new System.Drawing.Point(128, 8);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(36, 28);
            this.btnHome.Text = "⌂";
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(30, 36, 46);
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.ForeColor = System.Drawing.Color.FromArgb(206, 214, 224);
            this.btnRefresh.Location = new System.Drawing.Point(168, 8);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(36, 28);
            this.btnRefresh.Text = "⟳";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtAddressBar
            // 
            this.txtAddressBar.BackColor = System.Drawing.Color.FromArgb(13, 17, 23);
            this.txtAddressBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddressBar.ForeColor = System.Drawing.Color.FromArgb(206, 214, 224);
            this.txtAddressBar.Location = new System.Drawing.Point(212, 9);
            this.txtAddressBar.Name = "txtAddressBar";
            this.txtAddressBar.Size = new System.Drawing.Size(500, 26);
            this.txtAddressBar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAddressBar_KeyDown);
            // 
            // txtFilter
            // 
            this.txtFilter.BackColor = System.Drawing.Color.FromArgb(13, 17, 23);
            this.txtFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilter.ForeColor = System.Drawing.Color.FromArgb(206, 214, 224);
            this.txtFilter.Location = new System.Drawing.Point(720, 9);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(190, 26);
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // splitMainContainer
            // 
            this.splitMainContainer.BackColor = System.Drawing.Color.FromArgb(48, 54, 61);
            this.splitMainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMainContainer.Location = new System.Drawing.Point(0, 45);
            this.splitMainContainer.Name = "splitMainContainer";
            this.splitMainContainer.SplitterDistance = 230;
            this.splitMainContainer.Panel1.Controls.Add(this.treeDirNodes);
            this.splitMainContainer.Panel2.Controls.Add(this.lstFilesView);
            // 
            // treeDirNodes
            // 
            this.treeDirNodes.BackColor = System.Drawing.Color.FromArgb(22, 27, 34);
            this.treeDirNodes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeDirNodes.ForeColor = System.Drawing.Color.FromArgb(206, 214, 224);
            this.treeDirNodes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeDirNodes.Name = "treeDirNodes";
            this.treeDirNodes.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeDirNodes_BeforeExpand);
            this.treeDirNodes.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeDirNodes_AfterSelect);
            // 
            // lstFilesView
            // 
            this.lstFilesView.BackColor = System.Drawing.Color.FromArgb(22, 27, 34);
            this.lstFilesView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstFilesView.ForeColor = System.Drawing.Color.FromArgb(206, 214, 224);
            this.lstFilesView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstFilesView.HideSelection = false;
            this.lstFilesView.Name = "lstFilesView";
            this.lstFilesView.ContextMenuStrip = this.ctxExplorerMenu;
            this.lstFilesView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstFilesView_MouseDoubleClick);
            this.lstFilesView.SelectedIndexChanged += new System.EventHandler(this.lstFilesView_SelectedIndexChanged);
            this.lstFilesView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstFilesView_ColumnClick);
            // 
            // lblExplorerStatus
            // 
            this.lblExplorerStatus.BackColor = System.Drawing.Color.FromArgb(22, 27, 34);
            this.lblExplorerStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblExplorerStatus.ForeColor = System.Drawing.Color.FromArgb(128, 137, 149);
            this.lblExplorerStatus.Name = "lblExplorerStatus";
            this.lblExplorerStatus.Size = new System.Drawing.Size(920, 24);
            this.lblExplorerStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblExplorerStatus.Text = "";
            // 
            // ctxExplorerMenu
            // 
            this.ctxExplorerMenu.Name = "ctxExplorerMenu";
            this.ctxExplorerMenu.Size = new System.Drawing.Size(220, 260);
            this.ctxExplorerMenu.Items.Add(this.ctxOpen);
            this.ctxExplorerMenu.Items.Add(this.ctxCreateFolder);
            this.ctxExplorerMenu.Items.Add(this.ctxCreateFile);
            this.ctxExplorerMenu.Items.Add(this.ctxCopy);
            this.ctxExplorerMenu.Items.Add(this.ctxCut);
            this.ctxExplorerMenu.Items.Add(this.ctxPaste);
            this.ctxExplorerMenu.Items.Add(this.ctxZip);
            this.ctxExplorerMenu.Items.Add(this.ctxUnzip);
            this.ctxExplorerMenu.Items.Add(this.ctxProperties);
            this.ctxExplorerMenu.Items.Add(this.ctxDelete);
            // 
            // ctxOpen
            // 
            this.ctxOpen.Name = "ctxOpen";
            this.ctxOpen.Text = "Открыть";
            this.ctxOpen.Click += new System.EventHandler(this.ctxOpen_Click);
            // 
            // ctxCreateFolder
            // 
            this.ctxCreateFolder.Name = "ctxCreateFolder";
            this.ctxCreateFolder.Text = "Создать папку";
            this.ctxCreateFolder.Click += new System.EventHandler(this.ctxCreateFolder_Click);
            // 
            // ctxCreateFile
            // 
            this.ctxCreateFile.Name = "ctxCreateFile";
            this.ctxCreateFile.Text = "Создать файл .txt";
            this.ctxCreateFile.Click += new System.EventHandler(this.ctxCreateFile_Click);
            // 
            // ctxCopy
            // 
            this.ctxCopy.Name = "ctxCopy";
            this.ctxCopy.Text = "Копировать";
            this.ctxCopy.Click += new System.EventHandler(this.ctxCopy_Click);
            // 
            // ctxCut
            // 
            this.ctxCut.Name = "ctxCut";
            this.ctxCut.Text = "Вырезать";
            this.ctxCut.Click += new System.EventHandler(this.ctxCut_Click);
            // 
            // ctxPaste
            // 
            this.ctxPaste.Name = "ctxPaste";
            this.ctxPaste.Text = "Вставить";
            this.ctxPaste.Click += new System.EventHandler(this.ctxPaste_Click);
            // 
            // ctxZip
            // 
            this.ctxZip.Name = "ctxZip";
            this.ctxZip.Text = "Упаковать в .zip";
            this.ctxZip.Click += new System.EventHandler(this.ctxZip_Click);
            // 
            // ctxUnzip
            // 
            this.ctxUnzip.Name = "ctxUnzip";
            this.ctxUnzip.Text = "Распаковать";
            this.ctxUnzip.Click += new System.EventHandler(this.ctxUnzip_Click);
            // 
            // ctxProperties
            // 
            this.ctxProperties.Name = "ctxProperties";
            this.ctxProperties.Text = "Свойства";
            this.ctxProperties.Click += new System.EventHandler(this.ctxProperties_Click);
            // 
            // ctxDelete
            // 
            this.ctxDelete.Name = "ctxDelete";
            this.ctxDelete.Text = "Удалить";
            this.ctxDelete.Click += new System.EventHandler(this.ctxDelete_Click);
            // 
            // Form1
            // 
            this.Text = "LisunOS Explorer";
            this.ClientSize = new System.Drawing.Size(920, 560);
            this.BackColor = System.Drawing.Color.FromArgb(13, 17, 23);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Controls.Add(this.splitMainContainer);
            this.Controls.Add(this.lblExplorerStatus);
            this.Controls.Add(this.pnlTopNav);
            this.pnlTopNav.ResumeLayout(false);
            this.splitMainContainer.ResumeLayout(false);
            this.ctxExplorerMenu.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}

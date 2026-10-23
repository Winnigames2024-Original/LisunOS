namespace LisunOS
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlTopNav;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.TextBox txtAddressBar;
        private System.Windows.Forms.SplitContainer splitMainContainer;
        private System.Windows.Forms.TreeView treeDirNodes;
        private System.Windows.Forms.ListView lstFilesView;
        private System.Windows.Forms.ContextMenuStrip ctxExplorerMenu;
        private System.Windows.Forms.ToolStripMenuItem ctxCreateFolder;
        private System.Windows.Forms.ToolStripMenuItem ctxCreateFile;
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
            this.btnUp = new System.Windows.Forms.Button();
            this.txtAddressBar = new System.Windows.Forms.TextBox();
            this.splitMainContainer = new System.Windows.Forms.SplitContainer();
            this.treeDirNodes = new System.Windows.Forms.TreeView();
            this.lstFilesView = new System.Windows.Forms.ListView();
            this.ctxExplorerMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxCreateFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxCreateFile = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxDelete = new System.Windows.Forms.ToolStripMenuItem();

            this.pnlTopNav.SuspendLayout();
            this.splitMainContainer.SuspendLayout();
            this.ctxExplorerMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTopNav
            // 
            this.pnlTopNav.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.pnlTopNav.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopNav.Location = new System.Drawing.Point(0, 0);
            this.pnlTopNav.Name = "pnlTopNav";
            this.pnlTopNav.Size = new System.Drawing.Size(800, 45);
            this.pnlTopNav.Controls.Add(this.btnBack);
            this.pnlTopNav.Controls.Add(this.btnUp);
            this.pnlTopNav.Controls.Add(this.txtAddressBar);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(60, 60, 65);
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(8, 8);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(40, 28);
            this.btnBack.Text = "←";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnUp
            // 
            this.btnUp.BackColor = System.Drawing.Color.FromArgb(60, 60, 65);
            this.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUp.ForeColor = System.Drawing.Color.White;
            this.btnUp.Location = new System.Drawing.Point(54, 8);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(40, 28);
            this.btnUp.Text = "↑";
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // txtAddressBar
            // 
            this.txtAddressBar.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.txtAddressBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddressBar.ForeColor = System.Drawing.Color.LightGray;
            this.txtAddressBar.Location = new System.Drawing.Point(105, 9);
            this.txtAddressBar.Name = "txtAddressBar";
            this.txtAddressBar.ReadOnly = true;
            this.txtAddressBar.Size = new System.Drawing.Size(670, 26);
            // 
            // splitMainContainer
            // 
            this.splitMainContainer.BackColor = System.Drawing.Color.FromArgb(50, 50, 50);
            this.splitMainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMainContainer.Location = new System.Drawing.Point(0, 45);
            this.splitMainContainer.Name = "splitMainContainer";
            this.splitMainContainer.SplitterDistance = 220;
            this.splitMainContainer.Panel1.Controls.Add(this.treeDirNodes);
            this.splitMainContainer.Panel2.Controls.Add(this.lstFilesView);
            // 
            // treeDirNodes
            // 
            this.treeDirNodes.BackColor = System.Drawing.Color.FromArgb(35, 35, 35);
            this.treeDirNodes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeDirNodes.ForeColor = System.Drawing.Color.White;
            this.treeDirNodes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeDirNodes.Name = "treeDirNodes";
            this.treeDirNodes.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeDirNodes_BeforeExpand);
            this.treeDirNodes.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeDirNodes_AfterSelect);
            // 
            // lstFilesView
            // 
            this.lstFilesView.BackColor = System.Drawing.Color.FromArgb(25, 25, 25);
            this.lstFilesView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstFilesView.ForeColor = System.Drawing.Color.LightGray;
            this.lstFilesView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstFilesView.HideSelection = false;
            this.lstFilesView.Name = "lstFilesView";
            this.lstFilesView.ContextMenuStrip = this.ctxExplorerMenu;
            this.lstFilesView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstFilesView_MouseDoubleClick);
            // 
            // ctxExplorerMenu
            // 
            this.ctxExplorerMenu.Name = "ctxExplorerMenu";
            this.ctxExplorerMenu.Size = new System.Drawing.Size(180, 76);
            this.ctxExplorerMenu.Items.Add(this.ctxCreateFolder);
            this.ctxExplorerMenu.Items.Add(this.ctxCreateFile);
            this.ctxExplorerMenu.Items.Add(this.ctxDelete);
            // 
            // ctxCreateFolder
            // 
            this.ctxCreateFolder.Name = "ctxCreateFolder";
            this.ctxCreateFolder.Size = new System.Drawing.Size(179, 24);
            this.ctxCreateFolder.Text = "Создать папку";
            this.ctxCreateFolder.Click += new System.EventHandler(this.ctxCreateFolder_Click);
            // 
            // ctxCreateFile
            // 
            this.ctxCreateFile.Name = "ctxCreateFile";
            this.ctxCreateFile.Size = new System.Drawing.Size(179, 24);
            this.ctxCreateFile.Text = "Создать файл .txt";
            this.ctxCreateFile.Click += new System.EventHandler(this.ctxCreateFile_Click);
            // 
            // ctxDelete
            // 
            this.ctxDelete.Name = "ctxDelete";
            this.ctxDelete.Size = new System.Drawing.Size(179, 24);
            this.ctxDelete.Text = "Удалить";
            this.ctxDelete.Click += new System.EventHandler(this.ctxDelete_Click);
            // 
            // Form1
            // 
            this.this.Text = "LisunOS Explorer";
            this.this.ClientSize = new System.Drawing.Size(800, 500);
            this.this.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Controls.Add(this.splitMainContainer);
            this.Controls.Add(this.pnlTopNav);
            this.pnlTopNav.ResumeLayout(false);
            this.splitMainContainer.ResumeLayout(false);
            this.ctxExplorerMenu.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}

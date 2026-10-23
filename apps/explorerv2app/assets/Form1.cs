using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace LisunOS
{
    public partial class Form1 : Form
    {
        private string rootPath;
        private string currentPath;
        private Stack<string> historyStack = new Stack<string>();

        public Form1()
        {
            // Вызываем стандартный метод сборки интерфейса из designer.cs
            InitializeComponent();

            // Переводим ListView в режим отображения крупных иконок плиток
            this.lstFilesView.View = View.LargeIcon;

            // Настраиваем пути виртуальной файловой системы
            rootPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "files", "os");
            if (!Directory.Exists(rootPath)) Directory.CreateDirectory(rootPath);
            currentPath = rootPath;

            // Инициализация ресурсов и данных
            InitializeSystemIcons();
            InitTreeView();
            LoadDirectory(currentPath);
        }

        private void C___InitializeSystemIcons()
        {
            ImageList imgList = new ImageList { ImageSize = new Size(32, 32), ColorDepth = ColorDepth.Depth32Bit };

            Bitmap folderBmp = new Bitmap(32, 32);
            using (Graphics g = Graphics.FromImage(folderBmp)) g.Clear(Color.Gold);
            imgList.Images.Add("folder", folderBmp);

            Bitmap fileBmp = new Bitmap(32, 32);
            using (Graphics g = Graphics.FromImage(fileBmp)) g.Clear(Color.LightGray);
            imgList.Images.Add("file", fileBmp);

            lstFilesView.LargeImageList = imgList;
            lstFilesView.SmallImageList = imgList;
        }

        private void C___InitTreeView()
        {
            treeDirNodes.Nodes.Clear();
            TreeNode rootNode = new TreeNode("LisunOS (C:)") { Tag = rootPath };
            treeDirNodes.Nodes.Add(rootNode);
            UpdateTreeNodes(rootNode);
            rootNode.Expand();
        }

        private void C___UpdateTreeNodes(TreeNode parentNode)
        {
            try
            {
                parentNode.Nodes.Clear();
                string path = parentNode.Tag.ToString();
                string[] dirs = Directory.GetDirectories(path);
                foreach (var dir in dirs)
                {
                    TreeNode node = new TreeNode(Path.GetFileName(dir)) { Tag = dir };
                    node.Nodes.Add(new TreeNode("..."));
                    parentNode.Nodes.Add(node);
                }
            }
            catch { }
        }

        private void C___LoadDirectory(string path)
        {
            if (!Directory.Exists(path)) return;

            currentPath = path;
            txtAddressBar.Text = path.Replace(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "files"), "LisunOS:\\");
            lstFilesView.Items.Clear();
            btnBack.Enabled = historyStack.Count > 0;

            List<string> folders;
            List<string> files = CustomFormUtils.GetDirectoryContent(path, out folders);

            foreach (var folder in folders)
            {
                ListViewItem item = new ListViewItem(folder, "folder") { Tag = Path.Combine(path, folder) };
                lstFilesView.Items.Add(item);
            }
            foreach (var file in files)
            {
                ListViewItem item = new ListViewItem(file, "file") { Tag = Path.Combine(path, file) };
                lstFilesView.Items.Add(item);
            }
        }

        private void C___lstFilesView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstFilesView.SelectedItems.Count == 0) return;
            string targetPath = lstFilesView.SelectedItems[0].Tag.ToString();

            if (Directory.Exists(targetPath))
            {
                historyStack.Push(currentPath);
                LoadDirectory(targetPath);
            }
            else if (File.Exists(targetPath))
            {
                string content = CustomFormUtils.ReadFileText(targetPath);
                MessageBox.Show(content, "Просмотр файла: " + Path.GetFileName(targetPath));
            }
        }

        private void C___treeDirNodes_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Tag != null) UpdateTreeNodes(e.Node);
        }

        private void C___treeDirNodes_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag != null && e.Node.Tag.ToString() != currentPath)
            {
                historyStack.Push(currentPath);
                LoadDirectory(e.Node.Tag.ToString());
            }
        }

        private void C___btnBack_Click(object sender, EventArgs e)
        {
            if (historyStack.Count > 0) LoadDirectory(historyStack.Pop());
        }

        private void C___btnUp_Click(object sender, EventArgs e)
        {
            if (currentPath.ToLower().TrimEnd('\\') == rootPath.ToLower().TrimEnd('\\')) return;
            DirectoryInfo parent = Directory.GetParent(currentPath);
            if (parent != null)
            {
                historyStack.Push(currentPath);
                LoadDirectory(parent.FullName);
            }
        }

        private void C___ctxCreateFile_Click(object sender, EventArgs e)
        {
            string newFile = Path.Combine(currentPath, "NewFile.txt");
            int i = 1;
            while (File.Exists(newFile)) newFile = Path.Combine(currentPath, $"NewFile({i++}).txt");
            CustomFormUtils.WriteFileText(newFile, "Создано через LisunOS Explorer.");
            LoadDirectory(currentPath);
        }

        private void C___ctxCreateFolder_Click(object sender, EventArgs e)
        {
            string newDir = Path.Combine(currentPath, "NewFolder");
            int i = 1;
            while (Directory.Exists(newDir)) newDir = Path.Combine(currentPath, $"NewFolder({i++})");
            CustomFormUtils.CreateFolder(newDir);
            LoadDirectory(currentPath);
        }

        private void C___ctxDelete_Click(object sender, EventArgs e)
        {
            if (lstFilesView.SelectedItems.Count == 0) return;
            string target = lstFilesView.SelectedItems[0].Tag.ToString();

            DialogResult confirm = MessageBox.Show($"Удалить {Path.GetFileName(target)}?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                if (Directory.Exists(target)) CustomFormUtils.DeleteFolder(target);
                else CustomFormUtils.DeleteFile(target);
                LoadDirectory(currentPath);
            }
        }
    }
}
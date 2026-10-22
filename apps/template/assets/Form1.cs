using System;
using System.Windows.Forms;

namespace LisunOS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnClickMe_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello from LisunOS Template App!", "LisunOS API Notice");
        }
    }
}

namespace LisunOS
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnClickMe;

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
            this.btnClickMe = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnClickMe
            // 
            this.btnClickMe.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            this.btnClickMe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClickMe.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClickMe.ForeColor = System.Drawing.Color.White;
            this.btnClickMe.Location = new System.Drawing.Point(120, 100);
            this.btnClickMe.Name = "btnClickMe";
            this.btnClickMe.Size = new System.Drawing.Size(160, 45);
            this.btnClickMe.TabIndex = 0;
            this.btnClickMe.Text = "CLICK ME";
            this.btnClickMe.UseVisualStyleBackColor = false;
            this.btnClickMe.Click += new System.EventHandler(this.btnClickMe_Click);
            // 
            // Form1
            // 
            this.this.Text = "LisunOS App Template";
            this.this.ClientSize = new System.Drawing.Size(400, 260);
            this.this.BackColor = System.Drawing.Color.FromArgb(28, 28, 28);
            this.Controls.Add(this.btnClickMe);
            this.ResumeLayout(false);
        }
    }
}

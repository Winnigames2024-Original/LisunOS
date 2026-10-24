namespace LisunOS
{
    partial class CalcForm
    {
        // ====================================================================
        //  Разметка калькулятора LisunOS.
        //  Клавиши раскладываются сеткой 4 x 6; все они шлют событие
        //  в один обработчик btnKey_Click, который читает надпись кнопки.
        // ====================================================================

        private System.Windows.Forms.Panel pnlDisplay;
        private System.Windows.Forms.TextBox txtExpression;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblMemory;

        private System.Windows.Forms.Panel pnlKeys;
        private System.Windows.Forms.Button btnMemClear;
        private System.Windows.Forms.Button btnMemRead;
        private System.Windows.Forms.Button btnMemAdd;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnNum7;
        private System.Windows.Forms.Button btnNum8;
        private System.Windows.Forms.Button btnNum9;
        private System.Windows.Forms.Button btnDiv;
        private System.Windows.Forms.Button btnNum4;
        private System.Windows.Forms.Button btnNum5;
        private System.Windows.Forms.Button btnNum6;
        private System.Windows.Forms.Button btnMul;
        private System.Windows.Forms.Button btnNum1;
        private System.Windows.Forms.Button btnNum2;
        private System.Windows.Forms.Button btnNum3;
        private System.Windows.Forms.Button btnSub;
        private System.Windows.Forms.Button btnNum0;
        private System.Windows.Forms.Button btnDot;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPow;
        private System.Windows.Forms.Button btnMod;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEquals;

        private System.Windows.Forms.ListBox lstHistory;
        private System.Windows.Forms.Label lblStatus;

        private void InitializeComponent()
        {
            this.pnlDisplay = new System.Windows.Forms.Panel();
            this.txtExpression = new System.Windows.Forms.TextBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblMemory = new System.Windows.Forms.Label();
            this.pnlKeys = new System.Windows.Forms.Panel();
            this.btnMemClear = new System.Windows.Forms.Button();
            this.btnMemRead = new System.Windows.Forms.Button();
            this.btnMemAdd = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnNum7 = new System.Windows.Forms.Button();
            this.btnNum8 = new System.Windows.Forms.Button();
            this.btnNum9 = new System.Windows.Forms.Button();
            this.btnDiv = new System.Windows.Forms.Button();
            this.btnNum4 = new System.Windows.Forms.Button();
            this.btnNum5 = new System.Windows.Forms.Button();
            this.btnNum6 = new System.Windows.Forms.Button();
            this.btnMul = new System.Windows.Forms.Button();
            this.btnNum1 = new System.Windows.Forms.Button();
            this.btnNum2 = new System.Windows.Forms.Button();
            this.btnNum3 = new System.Windows.Forms.Button();
            this.btnSub = new System.Windows.Forms.Button();
            this.btnNum0 = new System.Windows.Forms.Button();
            this.btnDot = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPow = new System.Windows.Forms.Button();
            this.btnMod = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEquals = new System.Windows.Forms.Button();
            this.lstHistory = new System.Windows.Forms.ListBox();
            this.lblStatus = new System.Windows.Forms.Label();

            // ---------- табло ----------
            this.pnlDisplay.Location = new System.Drawing.Point(0, 0);
            this.pnlDisplay.Size = new System.Drawing.Size(420, 104);
            this.pnlDisplay.BackColor = System.Drawing.Color.FromArgb(22, 27, 34);

            this.txtExpression.Location = new System.Drawing.Point(16, 14);
            this.txtExpression.Size = new System.Drawing.Size(388, 30);
            this.txtExpression.Text = "";
            this.txtExpression.BackColor = System.Drawing.Color.FromArgb(30, 36, 46);
            this.txtExpression.ForeColor = System.Drawing.Color.FromArgb(206, 214, 224);
            this.txtExpression.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExpression.TextChanged += new System.EventHandler(this.txtExpression_TextChanged);
            this.pnlDisplay.Controls.Add(this.txtExpression);

            this.lblResult.Location = new System.Drawing.Point(16, 50);
            this.lblResult.Size = new System.Drawing.Size(300, 34);
            this.lblResult.Text = "0";
            this.lblResult.ForeColor = System.Drawing.Color.FromArgb(88, 166, 255);
            this.pnlDisplay.Controls.Add(this.lblResult);

            this.lblMemory.Location = new System.Drawing.Point(324, 58);
            this.lblMemory.Size = new System.Drawing.Size(80, 20);
            this.lblMemory.Text = "";
            this.lblMemory.ForeColor = System.Drawing.Color.FromArgb(128, 137, 149);
            this.pnlDisplay.Controls.Add(this.lblMemory);

            this.Controls.Add(this.pnlDisplay);

            // ---------- клавиатура ----------
            this.pnlKeys.Location = new System.Drawing.Point(0, 104);
            this.pnlKeys.Size = new System.Drawing.Size(420, 292);
            this.pnlKeys.BackColor = System.Drawing.Color.FromArgb(13, 17, 23);

            this.btnMemClear.Location = new System.Drawing.Point(16, 10);
            this.btnMemClear.Size = new System.Drawing.Size(92, 42);
            this.btnMemClear.Text = "MC";
            this.btnMemClear.Click += new System.EventHandler(this.btnKey_Click);
            this.pnlKeys.Controls.Add(this.btnMemClear);
            this.btnMemRead.Location = new System.Drawing.Point(116, 10);
            this.btnMemRead.Size = new System.Drawing.Size(92, 42);
            this.btnMemRead.Text = "MR";
            this.btnMemRead.Click += new System.EventHandler(this.btnKey_Click);
            this.pnlKeys.Controls.Add(this.btnMemRead);
            this.btnMemAdd.Location = new System.Drawing.Point(216, 10);
            this.btnMemAdd.Size = new System.Drawing.Size(92, 42);
            this.btnMemAdd.Text = "M+";
            this.btnMemAdd.Click += new System.EventHandler(this.btnKey_Click);
            this.pnlKeys.Controls.Add(this.btnMemAdd);
            this.btnClear.Location = new System.Drawing.Point(316, 10);
            this.btnClear.Size = new System.Drawing.Size(92, 42);
            this.btnClear.Text = "C";
            this.btnClear.Click += new System.EventHandler(this.btnKey_Click);
            this.pnlKeys.Controls.Add(this.btnClear);

            this.btnNum7.Location = new System.Drawing.Point(16, 58);
            this.btnNum7.Size = new System.Drawing.Size(92, 42);
            this.btnNum7.Text = "7";
            this.btnNum7.Click += new System.EventHandler(this.btnKey_Click);
            this.pnlKeys.Controls.Add(this.btnNum7);
            this.btnNum8.Location = new System.Drawing.Point(116, 58);
            this.btnNum8.Size = new System.Drawing.Size(92, 42);
            this.btnNum8.Text = "8";
            this.btnNum8.Click += new System.EventHandler(this.btnKey_Click);
            this.pnlKeys.Controls.Add(this.btnNum8);
            this.btnNum9.Location = new System.Drawing.Point(216, 58);
            this.btnNum9.Size = new System.Drawing.Size(92, 42);
            this.btnNum9.Text = "9";
            this.btnNum9.Click += new System.EventHandler(this.btnKey_Click);
            this.pnlKeys.Controls.Add(this.btnNum9);
            this.btnDiv.Location = new System.Drawing.Point(316, 58);
            this.btnDiv.Size = new System.Drawing.Size(92, 42);
            this.btnDiv.Text = "/";
            this.btnDiv.Click += new System.EventHandler(this.btnKey_Click);
            this.pnlKeys.Controls.Add(this.btnDiv);

            this.btnNum4.Location = new System.Drawing.Point(16, 106);
            this.btnNum4.Size = new System.Drawing.Size(92, 42);
            this.btnNum4.Text = "4";
            this.btnNum4.Click += new System.EventHandler(this.btnKey_Click);
            this.pnlKeys.Controls.Add(this.btnNum4);
            this.btnNum5.Location = new System.Drawing.Point(116, 106);
            this.btnNum5.Size = new System.Drawing.Size(92, 42);
            this.btnNum5.Text = "5";
            this.btnNum5.Click += new System.EventHandler(this.btnKey_Click);
            this.pnlKeys.Controls.Add(this.btnNum5);
            this.btnNum6.Location = new System.Drawing.Point(216, 106);
            this.btnNum6.Size = new System.Drawing.Size(92, 42);
            this.btnNum6.Text = "6";
            this.btnNum6.Click += new System.EventHandler(this.btnKey_Click);
            this.pnlKeys.Controls.Add(this.btnNum6);
            this.btnMul.Location = new System.Drawing.Point(316, 106);
            this.btnMul.Size = new System.Drawing.Size(92, 42);
            this.btnMul.Text = "*";
            this.btnMul.Click += new System.EventHandler(this.btnKey_Click);
            this.pnlKeys.Controls.Add(this.btnMul);

            this.btnNum1.Location = new System.Drawing.Point(16, 154);
            this.btnNum1.Size = new System.Drawing.Size(92, 42);
            this.btnNum1.Text = "1";
            this.btnNum1.Click += new System.EventHandler(this.btnKey_Click);
            this.pnlKeys.Controls.Add(this.btnNum1);
            this.btnNum2.Location = new System.Drawing.Point(116, 154);
            this.btnNum2.Size = new System.Drawing.Size(92, 42);
            this.btnNum2.Text = "2";
            this.btnNum2.Click += new System.EventHandler(this.btnKey_Click);
            this.pnlKeys.Controls.Add(this.btnNum2);
            this.btnNum3.Location = new System.Drawing.Point(216, 154);
            this.btnNum3.Size = new System.Drawing.Size(92, 42);
            this.btnNum3.Text = "3";
            this.btnNum3.Click += new System.EventHandler(this.btnKey_Click);
            this.pnlKeys.Controls.Add(this.btnNum3);
            this.btnSub.Location = new System.Drawing.Point(316, 154);
            this.btnSub.Size = new System.Drawing.Size(92, 42);
            this.btnSub.Text = "-";
            this.btnSub.Click += new System.EventHandler(this.btnKey_Click);
            this.pnlKeys.Controls.Add(this.btnSub);

            this.btnNum0.Location = new System.Drawing.Point(16, 202);
            this.btnNum0.Size = new System.Drawing.Size(92, 42);
            this.btnNum0.Text = "0";
            this.btnNum0.Click += new System.EventHandler(this.btnKey_Click);
            this.pnlKeys.Controls.Add(this.btnNum0);
            this.btnDot.Location = new System.Drawing.Point(116, 202);
            this.btnDot.Size = new System.Drawing.Size(92, 42);
            this.btnDot.Text = ".";
            this.btnDot.Click += new System.EventHandler(this.btnKey_Click);
            this.pnlKeys.Controls.Add(this.btnDot);
            this.btnOpen.Location = new System.Drawing.Point(216, 202);
            this.btnOpen.Size = new System.Drawing.Size(92, 42);
            this.btnOpen.Text = "(";
            this.btnOpen.Click += new System.EventHandler(this.btnKey_Click);
            this.pnlKeys.Controls.Add(this.btnOpen);
            this.btnClose.Location = new System.Drawing.Point(316, 202);
            this.btnClose.Size = new System.Drawing.Size(92, 42);
            this.btnClose.Text = ")";
            this.btnClose.Click += new System.EventHandler(this.btnKey_Click);
            this.pnlKeys.Controls.Add(this.btnClose);

            this.btnPow.Location = new System.Drawing.Point(16, 250);
            this.btnPow.Size = new System.Drawing.Size(92, 42);
            this.btnPow.Text = "^";
            this.btnPow.Click += new System.EventHandler(this.btnKey_Click);
            this.pnlKeys.Controls.Add(this.btnPow);
            this.btnMod.Location = new System.Drawing.Point(116, 250);
            this.btnMod.Size = new System.Drawing.Size(92, 42);
            this.btnMod.Text = "%";
            this.btnMod.Click += new System.EventHandler(this.btnKey_Click);
            this.pnlKeys.Controls.Add(this.btnMod);
            this.btnBack.Location = new System.Drawing.Point(216, 250);
            this.btnBack.Size = new System.Drawing.Size(92, 42);
            this.btnBack.Text = "←";
            this.btnBack.Click += new System.EventHandler(this.btnKey_Click);
            this.pnlKeys.Controls.Add(this.btnBack);
            this.btnAdd.Location = new System.Drawing.Point(316, 250);
            this.btnAdd.Size = new System.Drawing.Size(92, 42);
            this.btnAdd.Text = "+";
            this.btnAdd.Click += new System.EventHandler(this.btnKey_Click);
            this.pnlKeys.Controls.Add(this.btnAdd);

            this.btnEquals.Location = new System.Drawing.Point(16, 298);
            this.btnEquals.Size = new System.Drawing.Size(392, 42);
            this.btnEquals.Text = "=";
            this.btnEquals.Click += new System.EventHandler(this.btnEquals_Click);
            this.pnlKeys.Controls.Add(this.btnEquals);

            this.Controls.Add(this.pnlKeys);

            // ---------- история ----------
            this.lstHistory.Location = new System.Drawing.Point(16, 404);
            this.lstHistory.Size = new System.Drawing.Size(388, 110);
            this.lstHistory.BackColor = System.Drawing.Color.FromArgb(22, 27, 34);
            this.lstHistory.ForeColor = System.Drawing.Color.FromArgb(206, 214, 224);
            this.lstHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstHistory.DoubleClick += new System.EventHandler(this.lstHistory_DoubleClick);
            this.Controls.Add(this.lstHistory);

            this.lblStatus.Location = new System.Drawing.Point(16, 520);
            this.lblStatus.Size = new System.Drawing.Size(388, 20);
            this.lblStatus.Text = "";
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(128, 137, 149);
            this.Controls.Add(this.lblStatus);
        }
    }
}

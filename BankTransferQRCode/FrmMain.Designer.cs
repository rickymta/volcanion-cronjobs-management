namespace BankTransferQRCode
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TxtBank = new TextBox();
            LblBank = new Label();
            PtbQRCode = new PictureBox();
            GrbInfo = new GroupBox();
            LblBankAccount = new Label();
            TxtBankAccount = new TextBox();
            LblContent = new Label();
            TxtContent = new TextBox();
            LblAmount = new Label();
            TxtAmount = new TextBox();
            LblBankAccountNumber = new Label();
            TxtBankAccountNumber = new TextBox();
            BtnGenerate = new Button();
            BtnClear = new Button();
            BtnCheck = new Button();
            ((System.ComponentModel.ISupportInitialize)PtbQRCode).BeginInit();
            GrbInfo.SuspendLayout();
            SuspendLayout();
            // 
            // TxtBank
            // 
            TxtBank.Location = new Point(7, 60);
            TxtBank.Margin = new Padding(4);
            TxtBank.Name = "TxtBank";
            TxtBank.Size = new Size(360, 29);
            TxtBank.TabIndex = 0;
            // 
            // LblBank
            // 
            LblBank.AutoSize = true;
            LblBank.Location = new Point(7, 35);
            LblBank.Margin = new Padding(4, 0, 4, 0);
            LblBank.Name = "LblBank";
            LblBank.Size = new Size(90, 21);
            LblBank.TabIndex = 1;
            LblBank.Text = "Ngân hàng:";
            // 
            // PtbQRCode
            // 
            PtbQRCode.Location = new Point(493, 290);
            PtbQRCode.Name = "PtbQRCode";
            PtbQRCode.Size = new Size(279, 244);
            PtbQRCode.SizeMode = PictureBoxSizeMode.StretchImage;
            PtbQRCode.TabIndex = 2;
            PtbQRCode.TabStop = false;
            // 
            // GrbInfo
            // 
            GrbInfo.Controls.Add(LblBankAccount);
            GrbInfo.Controls.Add(TxtBankAccount);
            GrbInfo.Controls.Add(LblContent);
            GrbInfo.Controls.Add(TxtContent);
            GrbInfo.Controls.Add(LblAmount);
            GrbInfo.Controls.Add(TxtAmount);
            GrbInfo.Controls.Add(LblBankAccountNumber);
            GrbInfo.Controls.Add(TxtBankAccountNumber);
            GrbInfo.Controls.Add(LblBank);
            GrbInfo.Controls.Add(TxtBank);
            GrbInfo.Location = new Point(12, 12);
            GrbInfo.Name = "GrbInfo";
            GrbInfo.Size = new Size(760, 248);
            GrbInfo.TabIndex = 3;
            GrbInfo.TabStop = false;
            GrbInfo.Text = "Thông tin chuyển khoản";
            // 
            // LblBankAccount
            // 
            LblBankAccount.AutoSize = true;
            LblBankAccount.Location = new Point(7, 175);
            LblBankAccount.Margin = new Padding(4, 0, 4, 0);
            LblBankAccount.Name = "LblBankAccount";
            LblBankAccount.Size = new Size(109, 21);
            LblBankAccount.TabIndex = 9;
            LblBankAccount.Text = "Chủ tài khoản:";
            // 
            // TxtBankAccount
            // 
            TxtBankAccount.Location = new Point(7, 200);
            TxtBankAccount.Margin = new Padding(4);
            TxtBankAccount.Name = "TxtBankAccount";
            TxtBankAccount.Size = new Size(360, 29);
            TxtBankAccount.TabIndex = 4;
            // 
            // LblContent
            // 
            LblContent.AutoSize = true;
            LblContent.Location = new Point(393, 106);
            LblContent.Margin = new Padding(4, 0, 4, 0);
            LblContent.Name = "LblContent";
            LblContent.Size = new Size(78, 21);
            LblContent.TabIndex = 7;
            LblContent.Text = "Nội dung:";
            // 
            // TxtContent
            // 
            TxtContent.Location = new Point(393, 131);
            TxtContent.Margin = new Padding(4);
            TxtContent.Multiline = true;
            TxtContent.Name = "TxtContent";
            TxtContent.Size = new Size(360, 98);
            TxtContent.TabIndex = 8;
            // 
            // LblAmount
            // 
            LblAmount.AutoSize = true;
            LblAmount.Location = new Point(393, 35);
            LblAmount.Margin = new Padding(4, 0, 4, 0);
            LblAmount.Name = "LblAmount";
            LblAmount.Size = new Size(61, 21);
            LblAmount.TabIndex = 5;
            LblAmount.Text = "Số tiền:";
            // 
            // TxtAmount
            // 
            TxtAmount.Location = new Point(393, 60);
            TxtAmount.Margin = new Padding(4);
            TxtAmount.Name = "TxtAmount";
            TxtAmount.Size = new Size(360, 29);
            TxtAmount.TabIndex = 6;
            // 
            // LblBankAccountNumber
            // 
            LblBankAccountNumber.AutoSize = true;
            LblBankAccountNumber.Location = new Point(7, 106);
            LblBankAccountNumber.Margin = new Padding(4, 0, 4, 0);
            LblBankAccountNumber.Name = "LblBankAccountNumber";
            LblBankAccountNumber.Size = new Size(99, 21);
            LblBankAccountNumber.TabIndex = 3;
            LblBankAccountNumber.Text = "Số tài khoản:";
            // 
            // TxtBankAccountNumber
            // 
            TxtBankAccountNumber.Location = new Point(7, 131);
            TxtBankAccountNumber.Margin = new Padding(4);
            TxtBankAccountNumber.Name = "TxtBankAccountNumber";
            TxtBankAccountNumber.Size = new Size(360, 29);
            TxtBankAccountNumber.TabIndex = 2;
            // 
            // BtnGenerate
            // 
            BtnGenerate.Location = new Point(12, 290);
            BtnGenerate.Name = "BtnGenerate";
            BtnGenerate.Size = new Size(241, 59);
            BtnGenerate.TabIndex = 10;
            BtnGenerate.Text = "Tạo mã QR";
            BtnGenerate.UseVisualStyleBackColor = true;
            BtnGenerate.Click += BtnGenerate_Click;
            // 
            // BtnClear
            // 
            BtnClear.Location = new Point(12, 382);
            BtnClear.Name = "BtnClear";
            BtnClear.Size = new Size(241, 59);
            BtnClear.TabIndex = 11;
            BtnClear.Text = "Xoá dữ liệu";
            BtnClear.UseVisualStyleBackColor = true;
            // 
            // BtnCheck
            // 
            BtnCheck.Location = new Point(12, 474);
            BtnCheck.Name = "BtnCheck";
            BtnCheck.Size = new Size(241, 59);
            BtnCheck.TabIndex = 12;
            BtnCheck.Text = "Kiểm tra thông tin";
            BtnCheck.UseVisualStyleBackColor = true;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 561);
            Controls.Add(BtnCheck);
            Controls.Add(BtnClear);
            Controls.Add(BtnGenerate);
            Controls.Add(GrbInfo);
            Controls.Add(PtbQRCode);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "FrmMain";
            Text = "FrmMain";
            ((System.ComponentModel.ISupportInitialize)PtbQRCode).EndInit();
            GrbInfo.ResumeLayout(false);
            GrbInfo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox TxtBank;
        private Label LblBank;
        private PictureBox PtbQRCode;
        private GroupBox GrbInfo;
        private Label LblBankAccount;
        private TextBox TxtBankAccount;
        private Label LblContent;
        private TextBox TxtContent;
        private Label LblAmount;
        private TextBox TxtAmount;
        private Label LblBankAccountNumber;
        private TextBox TxtBankAccountNumber;
        private Button BtnGenerate;
        private Button BtnClear;
        private Button BtnCheck;
    }
}
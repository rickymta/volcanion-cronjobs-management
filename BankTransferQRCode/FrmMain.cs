using QRCoder;
namespace BankTransferQRCode
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            InitTest();
        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            var bankName = TxtBank.Text;
            var accountNumber = TxtBankAccountNumber.Text;
            var accountName = TxtBankAccount.Text;
            var amount = TxtAmount.Text;
            var content = TxtContent.Text;

            if (string.IsNullOrEmpty(bankName) || string.IsNullOrEmpty(accountNumber) || string.IsNullOrEmpty(accountName) || string.IsNullOrEmpty(amount) || string.IsNullOrEmpty(content))
            {
                MessageBox.Show("Please fill all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            VietQR vietQR = new VietQR();
            vietQR
                .SetBeneficiaryOrganization("970423", "mynamebvh")
                .SetTransactionAmount("50000")
                .SetAdditionalDataFieldTemplate("test");

            var transferInfo = vietQR.Build();

            var qrGenerator = new QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode(transferInfo, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new QRCode(qrCodeData);

            var qrCodeImage = qrCode.GetGraphic(20);

            PtbQRCode.Image = qrCodeImage;
        }

        private void InitTest()
        {
            TxtBank.Text = "Techcombank";
            TxtBankAccountNumber.Text = "19034125504011";
            TxtBankAccount.Text = "Du Hong Quan";
            TxtAmount.Text = "10000";
            TxtContent.Text = "Test QR Code";
        }
    }
}

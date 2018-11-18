using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaxDll;

namespace InvoiceBill
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ComTaxCard _ComTaxCard = new ComTaxCard();

            // _ComTaxCard.OpenCard();

            // label1.Text = _ComTaxCard.sRetMsg;

            frmMain ofrmMain = new frmMain();
            ofrmMain.Show();
            this.Hide();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

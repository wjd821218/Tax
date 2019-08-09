using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net;
using System.IO;

namespace InvoiceBill
{
    public partial class frmInvoicePrint : Form
    {
        public frmInvoicePrint()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmMain.oComTaxCard.InvPrint(64003515,"3200182130",0,1);
            if (frmMain.oComTaxCard.iResult == 1)
            {
                MessageBox.Show(frmMain.oComTaxCard.sRetMsg);
            }
        }

        private void btnWebPrint_Click(object sender, EventArgs e)
        {

        }

    }
}

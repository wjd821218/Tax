using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using static InvoiceBill.Basic.ComStruct;

namespace InvoiceBill.SysManger
{
    public partial class frmUserInfo : DevExpress.XtraEditors.XtraForm
    {
        public int iUserId = 0;
        public frmUserInfo()
        {
            InitializeComponent();
        }

        private void textEdit3_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            //this.Close();
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
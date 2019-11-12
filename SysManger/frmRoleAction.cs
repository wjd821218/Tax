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
using InvoiceBill.Basic;

namespace InvoiceBill.SysManger
{
    public partial class frmRoleAction : DevExpress.XtraEditors.XtraForm
    {
        public frmRoleAction()
        {
            InitializeComponent();

        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            this.btnSure.DialogResult = DialogResult.OK;
        }

        private void btnCanceled_Click(object sender, EventArgs e)
        {
            this.btnSure.DialogResult = DialogResult.Cancel;
        }
    }
}
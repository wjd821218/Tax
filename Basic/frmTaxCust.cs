using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvoiceBill.Basic
{
    public partial class frmTaxCust : frmBasicBase
    {
        String sFilter = "";
        public frmTaxCust()
        {
            InitializeComponent();
        }

        public override void GetData()
        {
            string sSQL = "SELECT CUSTID,CUSTNAME,TAXCUSTNAME,TAXNO,BANKNAME,ADDRESS,NOTES  FROM  T_Cust_TaxCode WHERE 1=1 ";
            DataRefresh(sSQL, "T_Cust_TaxCode");
        }

        public override void Filter()
        {
            sFilter = "";
            string sSQL = "";
            if (txtName.Text.Trim() != "") { sFilter = sFilter + " AND (CUSTNAME LIKE '%" + txtName.Text.Trim() + "%' OR CUSTID ='" + txtName.Text.Trim() + "')"; }

            sSQL = "SELECT CUSTID,CUSTNAME,TAXCUSTNAME,TAXNO,BANKNAME,ADDRESS,NOTES  FROM  T_Cust_TaxCode WHERE 1=1  " + sFilter;
            DataRefresh(sSQL, "T_Cust_TaxCode");
        }

        public override string Save()
        {
            sda.Update(ds, "T_Cust_TaxCode");

            MessageBox.Show("保存成功！", "正确", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);

            return "";
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {

        }
    }
}

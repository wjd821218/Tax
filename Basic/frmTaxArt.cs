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
    public partial class frmTaxArt : frmBasicBase
    {
        String sFilter = "";
        public frmTaxArt()
        {
            InitializeComponent();
        }

        public override void GetData()
        {
            string sSQL = "SELECT ARTID,ARTCODE,NAME,SPEC,FACTORY,TAXCODE  FROM  T_ARTICLE WHERE TAXCODE IS NULL ";
            DataRefresh(sSQL, "T_ARTICLE");
        }

        public override void Filter()
        {
            sFilter = "";
            string sSQL = "";

            // if (txtName.Text.Trim() != "") { sFilter = sFilter + " AND ARTID IN (SELECT ARTID FROM T_ART_ALIAS  WHERE ALIASNAME LIKE '%" + txtName.Text.Trim() + "%' GROUP BY ARTID) "; }
            if (txtName.Text.Trim() != "") { sFilter = sFilter + " AND (NAME LIKE '%" + txtName.Text.Trim() + "%' OR ARTID ='" + txtName.Text.Trim() + "')"; }

            if (txtSpec.Text.Trim() != "") { sFilter = sFilter + " AND SPEC  LIKE '%" + txtSpec.Text.Trim() + "%' "; }

            if (txtFactory.Text.Trim() != "") { sFilter = sFilter + " AND FACTORY LIKE '%" + txtFactory.Text.Trim() + "%' "; }

            sSQL = "SELECT ARTID,ARTCODE,NAME,SPEC,FACTORY,TAXCODE  FROM  T_ARTICLE WHERE 1=1  " + sFilter;
            DataRefresh(sSQL, "T_ARTICLE");
        }

        public override string Save()
        {
            sda.Update(ds, "T_ARTICLE");

            MessageBox.Show("保存成功！", "正确", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);

            return "";
        }
    }
}

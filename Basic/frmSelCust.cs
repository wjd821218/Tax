using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InvoiceBill.DAO;

namespace InvoiceBill.Basic
{
    public partial class frmSelCust : Form
    {

        public int iDeptid = 0;
        public string sCustid = "0";
        public string sBsnCatID = "0";
        public string sTypeID = "0";

        public string asErrmsg = "";
        public string iReturn = "";

        public string SpName = "";

        public string[] sParameters;   //参数列表
        public string[] sParametersValue;  //参数值
        public string[] sParametersType;   //参数类型

        public string[] sParametersDirection;  //参数传递方向

        public frmSelCust()
        {
            InitializeComponent();
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        public DataTable GetDataBySql(string sSql)
        {
            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                DataTable pDTMain = pObj_Comm.ExeForDtl(sSql);

                pObj_Comm.Close();

                return pDTMain;
            }
            catch (Exception ex)
            {
                pObj_Comm.Close();
                throw ex;
            }
        }

        public void ShowSelectData(string sSql)
        {
            gridControl1.DataSource = GetDataBySql(sSql);
        }

        public DataTable GetDataTableBySp()
        {
            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.Oracle);
            try
            {
                DataTable pDTMain = pObj_Comm.ExecuteSPSursor(SpName, sParameters, sParametersValue, sParametersType, sParametersDirection).Tables[0];

                pObj_Comm.Close();
                return pDTMain;
            }
            catch (Exception ex)
            {
                pObj_Comm.Close();
                throw ex;
            }
        }

        private void gridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) this.DialogResult = DialogResult.OK;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}

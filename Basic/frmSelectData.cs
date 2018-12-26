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
using InvoiceBill.Basic;

namespace InvoiceBill.Basic
{
    public partial class frmSelectData : Form
    {
        int intFlag = 0;
        public string sDeptId = "0";

        public frmSelectData()
        {
            InitializeComponent();
        }

        private void gridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            SelectData();
        }
        public void ShowSelectData(int flag, string sFilter)
        {
            intFlag = flag;
            string sSQL = "";

            DataTable dtl = new DataTable();
            switch (flag)
            {
                case ComStruct.selCustomer:    //客户
                    sSQL = "SELECT CUSTID AS ID,CUSTNAME AS NAME  FROM T_Cust_TaxCode WHERE CUSTNAME LIKE '%" + sFilter + "%'";
                    break;
            }
            dtl = GetDataBySelect(sSQL);
            gridControl1.DataSource = dtl;
            gridView1.Columns[0].Caption = "编码";
            gridView1.Columns[1].Caption = "名称";
            this.Text = "选择";
            gridView1.MoveFirst();


            //gridView1.Columns[0].Visible = false;
            this.ShowDialog();
        }

        private void SelectData()
        {
            string strguid = "";
            string strname = "";
            if (gridView1.RowCount > 0)
            {
                strguid = ((DataRowView)(gridView1.GetFocusedRow())).Row["ID"].ToString();
                strname = ((DataRowView)(gridView1.GetFocusedRow())).Row["NAME"].ToString();
                this.Tag = strguid + "|" + strname;

                this.Close();
            }
        }
        public DataTable GetDataBySelect(string sSQL)
        {

            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                DataTable pDTMain = pObj_Comm.ExeForDtl(sSQL);

                pObj_Comm.Close();

                return pDTMain;
            }
            catch (Exception e)
            {
                pObj_Comm.Close();
                throw e; 
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            SelectData();
        }
    }
}

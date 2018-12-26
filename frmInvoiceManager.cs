using InvoiceBill.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvoiceBill
{
    public partial class frmInvoiceManager : Form
    {
        string sRetMsg = "";
        public frmInvoiceManager()
        {
            InitializeComponent();

            fLoadInvoiceType();
        }

        private void fLoadInvoiceType()
        {
            string sInvoiceSql =
                "SELECT INVTYPEID,INVTYPENAME FROM T_Invoice_Type ";

            cbbInvType.DataSource = GetDataTable(sInvoiceSql);
            cbbInvType.ValueMember = "INVTYPEID";
            cbbInvType.DisplayMember = "INVTYPENAME";

        }
        public DataTable GetDataTable(string SqlOraStr)
        {
            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                DataTable pDTMain = pObj_Comm.ExeForDtl(SqlOraStr);

                pObj_Comm.Close();
                return pDTMain;

            }
            catch (Exception ex)
            {
                pObj_Comm.Close();
                throw ex;
            }
        }

        public DataTable GetDataTableBySp(string sPName, string[] _Parameters, string[] _ParametersValue, string[] _ParametersType, string[] _ParametersDirection)
        {
            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.Oracle);
            try
            {
                DataTable pDTMain = pObj_Comm.ExecuteSPSursor(sPName, _Parameters, _ParametersValue, _ParametersType, _ParametersDirection).Tables[0];

                pObj_Comm.Close();
                return pDTMain;
            }
            catch (Exception ex)
            {
                pObj_Comm.Close();
                throw ex;
            }
        }
        public void GetData()
        {
            string sDeptid = txtDept.Text.Trim();
            string sCustId = txtCust.Text.Trim();           
            string sInvoiceno = txtInvoiceNo.Text.Trim();
            string sInvTypeId = cbbInvType.SelectedValue.ToString();

            string spName = "p_Get_Invoice";
            string sDateFrom = dtpDateFrom.Value.ToString("yyyy-MM-dd");
            string sDateTo = dtpDateTo.Value.ToString("yyyy-MM-dd");

            string[] sParameters = new string[5] { "@InvoiceNo", "@InvTypeId", "@CustName", "@BeginDate", "@EndDate" };

            string[] sParametersValue = new string[5] { sInvoiceno, sInvTypeId, sCustId, sDateFrom, sDateTo};
            string[] sParametersType = new string[5] { "VarChar", "VarChar", "VarChar", "VarChar", "VarChar"};
            string[] sParametersDirection = new string[5] { "Input", "Input", "Input", "Input", "Input"};

            gridControl1.DataSource = GetDataTableBySp(spName, sParameters, sParametersValue, sParametersType, sParametersDirection);
        }
        public int InvoiceCancel(string sInvSeqid, string sUserName)
        {
            int iResult = 0;
            string spName = "P_Invoice_Cancel";

            string[] sParameters = new string[4] { "myReturn", "@InvSeqId", "@UserId", "@Msg" };

            string[] sParametersValue = new string[4] { "0", sInvSeqid,"0", sRetMsg };
            string[] sParametersType = new string[4] { "Int32", "VarChar", "VarChar", "VarChar" };
            string[] sParametersDirection = new string[4] { "ReturnValue", "Input", "Input", "Output" };

            iResult = int.Parse(OperData(spName, sParameters, sParametersValue, sParametersType, sParametersDirection));
            return iResult;
        }
        public string OperData(string StoredProcedureName, string[] Parameters, string[] ParametersValue, string[] ParametersType, string[] ParametersDirection)
        {
            string iResult;

            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.Oracle);
            try
            {
                iResult = pObj_Comm.ExecuteSP(StoredProcedureName, Parameters, ParametersValue, ParametersType, ParametersDirection);

                pObj_Comm.Close();

                return iResult;
            }
            catch (Exception ex)
            {
                pObj_Comm.Close();
                throw ex;
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            int iResult = 0;
            int iMyRetrun = 0;

            int iCurrentItemId = gridView1.FocusedRowHandle;

            DataRow row = gridView1.GetDataRow(iCurrentItemId);

            string iCurrentBseqId = Convert.ToString(row["INVSEQID"]);

            iResult = frmMain.oComTaxCard.InvCancel(Convert.ToInt32(row["INVOICENO"]),Convert.ToString(row["INVOICECODE"]));
            if (iResult == 1)
            {
                MessageBox.Show(frmMain.oComTaxCard.sRetMsg);
            }
            else 
            {
                InvoiceCancel(iCurrentBseqId,"0");
            }

            
        }
    }
}

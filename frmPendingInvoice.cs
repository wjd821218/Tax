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
using InvoiceBill;
using TaxDll;
using InvoiceBill.Basic;
using System.IO;

namespace InvoiceBill
{
    public partial class frmPendingInvoice : Form
    {
        public int iCurrentItemId = -1;
        public string iCurrentBseqId = "";
        public string sRetMsg = "";
        public string sCurrentInvSeqId = "";
        public int iCurrentTaxRate = 3;
        string fileName = Path.Combine(Application.UserAppDataPath, "GridControlFactoryInvoicePendingBil.xml");
        public frmPendingInvoice()
        {
            InitializeComponent();

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

        public void GetData()
        {
            string sDeptid = txtDept.Text.Trim();
            string sCustId = txtCust.Text.Trim();
            //string sBseqId = txtBseqId.Text.Trim();
            string sInvTypeId = "";
            string sBillModeId = "";

            string spName = "p_Get_Pending_Invoice";
            string sDateFrom = dtpBeginDate.Value.ToString("yyyy-MM-dd");            
            string sDateTo = dtpEndDate.Value.ToString("yyyy-MM-dd");

            string[] sParameters = new string[5] { "@BillMode", "@InvTypeId", "@CustName", "@BeginDate", "@EndDate" };

            string[] sParametersValue = new string[5] { sBillModeId, sInvTypeId.ToString(),sCustId, sDateFrom, sDateTo};
            string[] sParametersType = new string[5] { "VarChar", "VarChar", "VarChar", "VarChar", "VarChar" };
            string[] sParametersDirection = new string[5] { "Input", "Input", "Input", "Input", "Input" };

            gridControl1.DataSource = GetDataTableBySp(spName, sParameters, sParametersValue, sParametersType, sParametersDirection);
        }

        public DataTable GetDataTableBySp(string sPName, string[] _Parameters, string[] _ParametersValue, string[] _ParametersType, string[] _ParametersDirection)
        {
            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
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

        private void btnQuery_Click(object sender, EventArgs e)
        {
            GetData();
        }


        public string OperData(string StoredProcedureName, string[] Parameters, string[] ParametersValue, string[] ParametersType, string[] ParametersDirection, int[] ParametersSize)
        {
            string iResult;

            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                iResult = pObj_Comm.ExecuteSP(StoredProcedureName, Parameters, ParametersValue, ParametersType, ParametersDirection, ParametersSize);

                pObj_Comm.Close();

                return iResult;
            }
            catch (Exception ex)
            {
                pObj_Comm.Close();
                throw ex;
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void frmInvoiceBill_FormClosing(object sender, FormClosingEventArgs e)
        {
            gridControl1.MainView.SaveLayoutToXml(fileName);
        }

        private void frmInvoiceBill_Load(object sender, EventArgs e)
        {
            gridControl1.ForceInitialize();
            // Restore the previously saved layout  
            if (System.IO.File.Exists(fileName))
                gridControl1.MainView.RestoreLayoutFromXml(fileName);
        }
    }

 
}

using InvoiceBill.Basic;
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
    public partial class frmInvoiceQuery : Form
    {
        string sRetMsg = "";
        public frmInvoiceQuery()
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
            string sShowCancle = "0";
            if (chkShowCancle.Checked) sShowCancle = "1";

            string spName = "p_Get_Invoice_List";
            string sDateFrom = dtpDateFrom.Value.ToString("yyyy-MM-dd");
            string sDateTo = dtpDateTo.Value.ToString("yyyy-MM-dd");

            string[] sParameters = new string[6] { "@InvoiceNo", "@InvTypeId", "@CustName", "@ShowCancle","@BeginDate", "@EndDate" };

            string[] sParametersValue = new string[6] { sInvoiceno, sInvTypeId, sCustId, sShowCancle, sDateFrom, sDateTo};
            string[] sParametersType = new string[6] { "VarChar", "VarChar", "VarChar", "VarChar", "VarChar", "VarChar"};
            string[] sParametersDirection = new string[6] { "Input", "Input", "Input", "Input", "Input", "Input"};

            gridControl1.DataSource = GetDataTableBySp(spName, sParameters, sParametersValue, sParametersType, sParametersDirection);
        }
        public string OperData(string StoredProcedureName, string[] Parameters, string[] ParametersValue, string[] ParametersType, string[] ParametersDirection,int[] ParametersSize)
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

        private void btnQuery_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Excel文件|*.XLS|所有文件|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = saveFileDialog1.FileName;
                gridView1.ExportToXls(filename);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int iResult = 0;
            short iInfoKind = 0;
            int iCurrentItemId = gridView1.FocusedRowHandle;

            DataRow row = gridView1.GetDataRow(iCurrentItemId);

            string iCurrentBseqId = Convert.ToString(row["INVSEQID"]);

            if (cbbInvType.SelectedValue.ToString() == "1")
            {
                iInfoKind = 0;
            }
            else
                iInfoKind = 2;

            iResult = frmMain.oComTaxCard.InvCancel(iInfoKind,Convert.ToInt32(row["INVOICENO"]), Convert.ToString(row["INVOICECODE"]));
            if (iResult == 1)
            {
                MessageBox.Show(frmMain.oComTaxCard.sRetMsg);

            }
        }
    }
}
 
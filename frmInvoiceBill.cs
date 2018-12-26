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

namespace InvoiceBill
{
    public partial class frmInvoiceBill : Form
    {
        public int iCurrentItemId = -1;
        public string iCurrentBseqId = "";
        public string sRetMsg = "";
        public frmInvoiceBill()
        {
            InitializeComponent();

            fLoadInvoiceType();
            fLoadBillMode();
        }

        private void fLoadInvoiceType()
        {
            string sInvoiceSql =
                "SELECT INVTYPEID,INVTYPENAME FROM T_Invoice_Type ";

            cbbInvType.DataSource = GetDataTable(sInvoiceSql);
            cbbInvType.ValueMember = "INVTYPEID";
            cbbInvType.DisplayMember = "INVTYPENAME";

        }

        private void fLoadBillMode()
        {
            string sInvoiceSql =
                "SELECT INVBILLMODEID,InvBillMode FROM T_Inv_BillMode ";

            cbbBillMode.DataSource = GetDataTable(sInvoiceSql);
            cbbBillMode.ValueMember = "INVBILLMODEID";
            cbbBillMode.DisplayMember = "InvBillMode";

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
            string sInvTypeId = cbbInvType.SelectedValue.ToString();

            string spName = "p_Get_Pending_Inv";
            string sDateFrom = dtpBeginDate.Value.ToString("yyyy-MM-dd");            
            string sDateTo = dtpEndDate.Value.ToString("yyyy-MM-dd");

            string[] sParameters = new string[5] { "@BillMode", "@InvTypeId", "@CustName", "@BeginDate", "@EndDate" };

            string[] sParametersValue = new string[5] {"", sInvTypeId.ToString(),sCustId, sDateFrom, sDateTo};
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

        public int InvoiceBillHeader(int iItemId)
        {
            DataRow row = gridView1.GetDataRow(iItemId);


            frmMain.oComTaxCard._InvocieHeader.sInfoClientName = Convert.ToString(row["TAXCUSTNAME"]);
            frmMain.oComTaxCard._InvocieHeader.sInfoClientTaxCode = Convert.ToString(row["TAXNO"]);
            frmMain.oComTaxCard._InvocieHeader.sInfoClientBankAccount = Convert.ToString(row["BANKNAME"]) + Convert.ToString(row["BANKACCOUNT"]);
            frmMain.oComTaxCard._InvocieHeader.sInfoClientAddressPhone = Convert.ToString(row["ADDRESS"]) + Convert.ToString(row["CONTACTPHONE"]);
            frmMain.oComTaxCard._InvocieHeader.sInfoSellerBankAccount = "江南农村商业银行大学城支行 88801019012010000001281";
            frmMain.oComTaxCard._InvocieHeader.sInfoSellerAddressPhone = "江苏省常州市武进经济开发区长扬路15号 0519-69698289";
            frmMain.oComTaxCard._InvocieHeader.iInfoTaxRate = 16; //此处税率是否可以为空，多税率如何处理
            frmMain.oComTaxCard._InvocieHeader.sInfoNotes = Convert.ToString(row["NOTES"]);
            frmMain.oComTaxCard._InvocieHeader.sInfoInvoicer = ""; //开票员
            frmMain.oComTaxCard._InvocieHeader.sInfoChecker = txtChecker.Text.Trim(); //复核员
            frmMain.oComTaxCard._InvocieHeader.sInfoCashier = txtCashier.Text.Trim(); //
            //if (iTaxDetailCount > 8) frmMain.oComTaxCard._InvocieHeader.sInfoListName = "详见销货清单";
            frmMain.oComTaxCard._InvocieHeader.sInfoBillNumber = Convert.ToString(row["BSEQID"]);

            return 0;
        }
        public int InvoiceBillDetail(int iItemId)
        {                       
            DataRow row = gridView1.GetDataRow(iItemId);
            string sBseqId = row["BSEQID"].ToString();
            DataTable myDt = new DataTable();

            string spName = "p_Get_Pending_Inv_Detail";

            string[] sParameters = new string[2] { "@BseqId", "@InvType"};

            string[] sParametersValue = new string[2] { sBseqId, cbbInvType.SelectedValue.ToString()};
            string[] sParametersType = new string[2] { "VarChar", "VarChar" };
            string[] sParametersDirection = new string[2] { "Input", "Input" };

            myDt = GetDataTableBySp(spName, sParameters, sParametersValue, sParametersType, sParametersDirection);
            int iTaxDetailCount = myDt.Rows.Count;

            //条目数大于8
            if (iTaxDetailCount > 8) frmMain.oComTaxCard._InvocieHeader.sInfoListName = "详见销货清单";


            if (iTaxDetailCount > 0)
            {
                frmMain.oComTaxCard.dtInvocieDetail = myDt;
                return 0;
            }
            else
            {
                string sRetMsg = "发票开具失败，无可开的发票明细。";
                return 1;
            }


        }

        public int InvoiceValidated(string sBseqId, string sInvoiceCode, string sInvoiceNo)
        {
            int iResult = 0;
            string spName = "p_fin_invoice_bill";

            string[] sParameters = new string[5] {"@BseqId", "@InvoiceCode", "@InvoiceNumber", "@UserId", "@Msg" };

            string[] sParametersValue = new string[5] { sBseqId, sInvoiceCode, sInvoiceNo, "0", sRetMsg };
            string[] sParametersType = new string[5] { "VarChar", "VarChar", "VarChar", "VarChar", "VarChar" };
            string[] sParametersDirection = new string[5] { "Input", "Input", "Input", "Input", "Output" };

            iResult = int.Parse(OperData(spName, sParameters, sParametersValue, sParametersType, sParametersDirection));
            return iResult;
        }

        private void Invoice()
        {
            iCurrentItemId = -1;

            if (gridView1.SelectedRowsCount > 0)
            {
                iCurrentItemId = gridView1.FocusedRowHandle;

                DataRow row = gridView1.GetDataRow(iCurrentItemId);

                iCurrentBseqId = Convert.ToString(row["BSEQID"]);

                if (InvoiceBillHeader(iCurrentItemId) ==1) MessageBox.Show(sRetMsg);
                if (InvoiceBillDetail(iCurrentItemId) == 1) MessageBox.Show(sRetMsg);

                if (frmMain.oComTaxCard.InvoiceBill() == 1)  MessageBox.Show(frmMain.oComTaxCard.sRetMsg);
                else
                if (InvoiceValidated(iCurrentBseqId, frmMain.oComTaxCard._InvoiceRetInfo.sRetInfoTypeCode, frmMain.oComTaxCard._InvoiceRetInfo.sRetInfoNumber.ToString()) == 1) MessageBox.Show(sRetMsg);

            }
        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            Invoice();
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

        private void cbbInvType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbInvType.SelectedValue.ToString() == "1")
            {
                frmMain.oComTaxCard.iInvType = 0;
            }
            else
                frmMain.oComTaxCard.iInvType = 2;
        }
    }

 
}

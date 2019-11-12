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

namespace InvoiceBill
{
    public partial class frmInvoiceBillNegative : Form
    {
        public int iCurrentItemId = -1;
        public string iCurrentBseqId = "";
        public string sRetMsg = "";
        public string sCurrentInvSeqId = "";
        public frmInvoiceBillNegative()
        {
            InitializeComponent();

            fLoadInvoiceType();
            fLoadBillMode();
            fLoadDept();

        }

        private void fLoadInvoiceType()
        {
            string sInvoiceSql =
                "SELECT INVTYPEID,INVTYPENAME FROM T_Invoice_Type ";

            cbbInvType.DataSource = GetDataTable(sInvoiceSql);
            cbbInvType.ValueMember = "INVTYPEID";
            cbbInvType.DisplayMember = "INVTYPENAME";
            frmMain.oComTaxCard.iInvType = 0; //默认专票
        }

        private void fLoadBillMode()
        {
            string sInvoiceSql =
                "SELECT INVBILLMODEID,InvBillMode FROM T_Inv_BillMode ";

            cbbBillMode.DataSource = GetDataTable(sInvoiceSql);
            cbbBillMode.ValueMember = "INVBILLMODEID";
            cbbBillMode.DisplayMember = "InvBillMode";

        }

        private void fLoadDept()
        {
            string sInvoiceSql =
                "SELECT DEPTID,DEPTNAME FROM T_DEPT WHERE DEPTID IN ( " + frmMain.sPermsDept + ")";

            cbbDept.DataSource = GetDataTable(sInvoiceSql);
            cbbDept.ValueMember = "DEPTID";
            cbbDept.DisplayMember = "DEPTNAME";

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
            string sDeptid = cbbDept.Text.Trim();
            string sCustId = txtCust.Text.Trim();
            //string sBseqId = txtBseqId.Text.Trim();
            string sInvTypeId = cbbInvType.SelectedValue.ToString();
            string sBillModeId = cbbBillMode.SelectedValue.ToString();

            string spName = "p_Get_Pending_Inv_Negative";
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

        public int InvoiceBillHeader(int iItemId)
        {
            DataRow row = gridView1.GetDataRow(iItemId);


            frmMain.oComTaxCard._InvocieHeader.sInfoClientName = Convert.ToString(row["TAXCUSTNAME"]);
            frmMain.oComTaxCard._InvocieHeader.sInfoClientTaxCode = Convert.ToString(row["TAXNO"]);
            frmMain.oComTaxCard._InvocieHeader.sInfoClientBankAccount = Convert.ToString(row["BANKNAME"]) + Convert.ToString(row["BANKACCOUNT"]);
            frmMain.oComTaxCard._InvocieHeader.sInfoClientAddressPhone = Convert.ToString(row["ADDRESS"]) + Convert.ToString(row["CONTACTPHONE"]);
            frmMain.oComTaxCard._InvocieHeader.sInfoSellerBankAccount = ComStruct.sInfoSellerBankAccount;
            frmMain.oComTaxCard._InvocieHeader.sInfoSellerAddressPhone = ComStruct.sInfoSellerAddressPhone;
            frmMain.oComTaxCard._InvocieHeader.iInfoTaxRate = short.Parse(Convert.ToString(row["TAXRATE"]));
            if (int.Parse(cbbInvType.SelectedValue.ToString()) == 2)
                frmMain.oComTaxCard._InvocieHeader.sInfoNotes = "对应正数发票代码:" + Convert.ToString(row["INVOICECODE"]) +
                "号码:" + Convert.ToString(row["INVOICENO"]);
            else
                frmMain.oComTaxCard._InvocieHeader.sInfoNotes = "开具红字增值税专用发票信息表编号: " + Convert.ToString(row["NOTES"]);
            frmMain.oComTaxCard._InvocieHeader.sInfoInvoicer = frmMain.sTrueName; //开票员
            frmMain.oComTaxCard._InvocieHeader.sInfoChecker = txtChecker.Text.Trim(); //复核员
            frmMain.oComTaxCard._InvocieHeader.sInfoCashier = txtCashier.Text.Trim(); //
            //if (iTaxDetailCount > 8) frmMain.oComTaxCard._InvocieHeader.sInfoListName = "详见销货清单";
            //frmMain.oComTaxCard._InvocieHeader.sInfoBillNumber = Convert.ToString(row["BSEQID"]);
            frmMain.oComTaxCard._InvocieHeader.sInfoBillNumber = "";

            return 0;
        }
        public int InvoiceBillDetail(int iItemId)
        {                       
            DataTable myDt = new DataTable();

            myDt = PublicUtility.InvoiceBillDetail(sCurrentInvSeqId);
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
        public int InvoiceBill(string sBseqId, string sUserId)
        {
            int iResult = 0;
            sRetMsg = "";
            sCurrentInvSeqId = "";

            string spName = "p_fin_invoice_bill_Negative";

            string[] sParameters = new string[5] { "result", "@BseqId", "@UserId", "@InvSeqId", "@Msg" };

            string[] sParametersValue = new string[5] { "",sBseqId, frmMain.sUserid, "","" };
            string[] sParametersType = new string[5] { "VarChar", "VarChar", "VarChar","Int", "VarChar" };
            string[] sParametersDirection = new string[5] { "ReturnValue", "Input", "Input" , "Output", "Output" };
            int[] sParametersSize = new int[5] { 20, 20, 20,20,512 };

            //iResult = int.Parse(PublicUtility.OperData(spName, sParameters, sParametersValue, sParametersType, sParametersDirection, sParametersSize));
            iResult = int.Parse(PublicUtility.OperData(spName, sParameters, sParametersValue, sParametersType, sParametersDirection, sParametersSize, out sCurrentInvSeqId, out sRetMsg));
            return iResult;
        }
        private int Invoice()
        {
            iCurrentItemId = -1;

            if (gridView1.SelectedRowsCount > 0)
            {
                iCurrentItemId = gridView1.FocusedRowHandle;

                DataRow row = gridView1.GetDataRow(iCurrentItemId);

                iCurrentBseqId = Convert.ToString(row["BSEQID"]);

                if (InvoiceBill(iCurrentBseqId, "0") == -1) { MessageBox.Show(sRetMsg); return 1; }

                if (InvoiceBillHeader(iCurrentItemId) == -1) { MessageBox.Show(sRetMsg); return 1; }
                if (InvoiceBillDetail(iCurrentItemId) == 1) { MessageBox.Show(sRetMsg); return 1; }
                //接口开具发票，不成功作废后台明细
                if (frmMain.oComTaxCard.InvoiceBill() == 1)
                {
                    MessageBox.Show(frmMain.oComTaxCard.sRetMsg);
                    if (PublicUtility.InvoiceCanceled(sCurrentInvSeqId) == -1) { MessageBox.Show(frmMain.sRetMsg); return 1; }
                    return 1;
                }
                else
                {
                    if (chkPrint.Checked)
                    {
                        frmMain.oComTaxCard.InvPrint(int.Parse(frmMain.oComTaxCard._InvoiceRetInfo.sRetInfoNumber.ToString()),
                        frmMain.oComTaxCard._InvoiceRetInfo.sRetInfoTypeCode, 0, frmMain.oComTaxCard.iInfoShowPrtDlg);
                        if (frmMain.oComTaxCard.iResult == 1)
                        {
                            MessageBox.Show(frmMain.oComTaxCard.sRetMsg);
                            return 1;
                        }
                        if (PublicUtility.PrintBill(sCurrentInvSeqId) == -1) { MessageBox.Show(frmMain.sRetMsg); return 1; }
                    }
                     if (PublicUtility.InvoiceValidated(sCurrentInvSeqId, frmMain.oComTaxCard._InvoiceRetInfo.sRetInfoTypeCode, frmMain.oComTaxCard._InvoiceRetInfo.sRetInfoNumber.ToString()) == -1) { MessageBox.Show(frmMain.sRetMsg); return 1; }
                }

            }
            return 0;
        }
        public int InvoiceValidated(string sBseqId, string sInvoiceCode, string sInvoiceNo)
        {
            if (sInvoiceCode is null) sInvoiceCode = "";
            int iResult = 0;
            string sOut = "";

            string spName = "p_fin_invoice_Validated";

            string[] sParameters = new string[6] { "result", "@InvseqId", "@InvoiceCode", "@InvoiceNumber", "@UserId", "@Msg" };

            string[] sParametersValue = new string[6] { "0", sCurrentInvSeqId.ToString(), sInvoiceCode, sInvoiceNo, frmMain.sUserid, sRetMsg };
            string[] sParametersType = new string[6] { "Int", "VarChar", "VarChar", "VarChar", "VarChar", "VarChar" };
            string[] sParametersDirection = new string[6] { "ReturnValue", "Input", "Input", "Input", "Input", "Output" };
            int[] sParametersSize = new int[6] { 10, 20, 20, 20, 20, 512 };

            iResult = int.Parse(PublicUtility.OperData(spName, sParameters, sParametersValue, sParametersType, sParametersDirection, sParametersSize, out sOut, out sRetMsg));

            return iResult;
        }
        public int InvoiceCanceled(string sInvseqId)
        {
            int iResult = 0;
            string sOut = "";
            string spName = "P_Invoice_Cancel";

            string[] sParameters = new string[4] { "result", "@InvseqId", "@UserId", "@Msg" };

            string[] sParametersValue = new string[4] { "0", sCurrentInvSeqId.ToString(), frmMain.sUserid, sRetMsg };
            string[] sParametersType = new string[4] { "Int", "VarChar", "VarChar", "VarChar" };
            string[] sParametersDirection = new string[4] { "ReturnValue", "Input", "Input", "Output" };
            int[] sParametersSize = new int[4] { 10, 20, 20, 512 };

            iResult = int.Parse(PublicUtility.OperData(spName, sParameters, sParametersValue, sParametersType, sParametersDirection, sParametersSize, out sOut, out sRetMsg));
            return iResult;
        }
        private void btnBill_Click(object sender, EventArgs e)
        {
            //Invoice();

            if (Invoice() == 1) MessageBox.Show(sRetMsg); 
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

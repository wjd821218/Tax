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
    public partial class frmInvoiceBill : Form
    {
        public int iCurrentItemId = -1;
        public string iCurrentBseqId = "";
        public string sRetMsg = "";
        public string sCurrentInvSeqId = "";
        public int iCurrentTaxRate = 3;
        string fileName = Path.Combine(Application.UserAppDataPath, "GridControlFactoryInvoiceBil.xml");
        public frmInvoiceBill()
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
            string sDeptid = cbbDept.SelectedValue.ToString();
            string sCustId = txtCust.Text.Trim();

            string sInvTypeId = cbbInvType.SelectedValue.ToString();
            string sBillModeId = cbbBillMode.SelectedValue.ToString();

            string spName = "p_Get_Pending_Inv";
            string sDateFrom = dtpBeginDate.Value.ToString("yyyy-MM-dd");            
            string sDateTo = dtpEndDate.Value.ToString("yyyy-MM-dd");

            string[] sParameters = new string[6] { "@DeptId", "@BillMode", "@InvTypeId", "@CustName", "@BeginDate", "@EndDate" };

            string[] sParametersValue = new string[6] { sDeptid,sBillModeId, sInvTypeId.ToString(),sCustId, sDateFrom, sDateTo};
            string[] sParametersType = new string[6] {"Int", "VarChar", "VarChar", "VarChar", "VarChar", "VarChar" };
            string[] sParametersDirection = new string[6] { "Input", "Input", "Input", "Input", "Input", "Input" };

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
            frmMain.oComTaxCard._InvocieHeader.iInfoTaxRate = short.Parse(Convert.ToString(row["TAXRATE"])); //此处税率是否可以为空，多税率如何处理
            frmMain.oComTaxCard._InvocieHeader.sInfoNotes = Convert.ToString(row["NOTES"]);
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
            frmMain.oComTaxCard._InvocieHeader.sInfoListName = "";
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
        public int InvoiceBill(string sBseqId, int iTaxRate,string sUserId)
        {
            int iResult = 0;
            sRetMsg = "";
            sCurrentInvSeqId = "";

            string spName = "p_fin_invoice_bill";

            string[] sParameters = new string[6] { "result", "@BseqId", "@TaxRate", "@UserId", "@InvSeqId", "@Msg" };

            string[] sParametersValue = new string[6] { "",sBseqId, iTaxRate.ToString(), frmMain.sUserid, "","" };
            string[] sParametersType = new string[6] { "VarChar", "VarChar", "Int", "VarChar","Int", "VarChar" };
            string[] sParametersDirection = new string[6] { "ReturnValue", "Input", "Input", "Input" , "Output", "Output" };
            int[] sParametersSize = new int[6] { 20, 20,20, 20,20,512 };

            //iResult = int.Parse(PublicUtility.OperData(spName, sParameters, sParametersValue, sParametersType, sParametersDirection, sParametersSize));
            iResult = int.Parse(PublicUtility.OperData(spName, sParameters, sParametersValue, sParametersType, sParametersDirection, sParametersSize, out sCurrentInvSeqId, out sRetMsg));
            return iResult;
        }
        private int Invoice(int iItemId)
        {

            if (iItemId != -1)
            {
                DataRow row = gridView1.GetDataRow(iItemId);

                iCurrentBseqId = Convert.ToString(row["BSEQID"]);
                iCurrentTaxRate = int.Parse(Convert.ToString(row["TAXRATE"]));

                if (InvoiceBill(iCurrentBseqId, iCurrentTaxRate, "0") == -1) { MessageBox.Show(sRetMsg); return 1; }

                if (InvoiceBillHeader(iItemId) == 1) { MessageBox.Show(sRetMsg); return 1; }
                if (InvoiceBillDetail(iItemId) == 1) { MessageBox.Show(sRetMsg); return 1; }

                if (Convert.ToString(row["INVTYPEID"]) == "2") frmMain.oComTaxCard.iInvType = 2;
                if (Convert.ToString(row["INVTYPEID"]) == "1") frmMain.oComTaxCard.iInvType = 0;

                if (chkShowPrint.Checked) frmMain.oComTaxCard.iInfoShowPrtDlg = 1;
                else frmMain.oComTaxCard.iInfoShowPrtDlg = 0;

                if (!chkEnable.Checked)
                {
                    if (frmMain.oComTaxCard.InvoiceBill() == 1)
                    {

                        MessageBox.Show(frmMain.oComTaxCard.sRetMsg);
                        if (PublicUtility.InvoiceCanceled(sCurrentInvSeqId) == -1) MessageBox.Show(sRetMsg);
                        return 1;
                    }
                    else
                    {
                        if (PublicUtility.InvoiceValidated(sCurrentInvSeqId, frmMain.oComTaxCard._InvoiceRetInfo.sRetInfoTypeCode, frmMain.oComTaxCard._InvoiceRetInfo.sRetInfoNumber.ToString()) == -1) { MessageBox.Show(frmMain.sRetMsg); return 1; }
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

                        //frmMain.refreshInfo();
                    }
                }
                else
                {
                    if (PublicUtility.InvoiceValidated(sCurrentInvSeqId, "000", "000") == -1) { MessageBox.Show(frmMain.sRetMsg); return 1; }
                }
            }
            return 0;
        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            foreach (int i in gridView1.GetSelectedRows())
            {
                if (Invoice(i) == 1) { MessageBox.Show(sRetMsg); return; }
            }
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

        private void cbbInvType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbInvType.SelectedValue.ToString() == "1")
            {
                frmMain.oComTaxCard.iInvType = 0;
            }
            else
                frmMain.oComTaxCard.iInvType = 2;
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

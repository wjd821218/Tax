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
using System.Threading;

namespace InvoiceBill
{
    public partial class frmBillSum : frmBase
    {
        public int iCurrentItemId = -1;
        public string iCurrentBseqId = "";        
        public string sRetMsg = "";
        public string sCustId = "";
        public string sInvTypeId ="1";
        public string sBillModeId = "1";
        public string sDateFrom ="";
        public string sDateTo = "";
        public string sCurrentInvSeqId = "";
        public int iCurrentTaxRate = 3;
        public string sDeptId = "1";

        string fileName = Path.Combine(Application.UserAppDataPath, "GridControlFactoryInvoiceSum.xml");
        public frmBillSum()
        {
            InitializeComponent(); 
            fLoadInvoiceType();
            fLoadBillMode();
            fLoadDept();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            GetData();
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
            sDeptId = cbbDept.SelectedValue.ToString();
            sInvTypeId = cbbInvType.SelectedValue.ToString();
            sBillModeId = cbbBillMode.SelectedValue.ToString();
            sCustId = txtCust.Text.Trim();

            string spName = "p_Get_Pending_Cust";
            sDateFrom = dtpBeginDate.Value.ToString("yyyy-MM-dd");
            sDateTo = dtpEndDate.Value.ToString("yyyy-MM-dd");

            string[] sParameters = new string[6] { "@DeptId", "@BillMode", "@InvTypeId", "@CustName", "@BeginDate", "@EndDate" };

            string[] sParametersValue = new string[6] {sDeptId,sBillModeId, sInvTypeId.ToString(), sCustId, sDateFrom, sDateTo };
            string[] sParametersType = new string[6] { "Int","VarChar", "VarChar", "VarChar", "VarChar", "VarChar" };
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
            DataRow row = gridView1.GetDataRow(iItemId);
            string sCustId = row["CUSTID"].ToString();
            DataTable myDt = new DataTable();

            string spName = "p_Get_Pending_Inv_Detail_Cust";

            string[] sParameters = new string[1] {"@InvSeqId"};

            string[] sParametersValue = new string[1] { sCurrentInvSeqId};
            string[] sParametersType = new string[1] { "VarChar"};
            string[] sParametersDirection = new string[1] { "Input"};

            myDt = GetDataTableBySp(spName, sParameters, sParametersValue, sParametersType, sParametersDirection);
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

        public int InvoiceBill(int iItemId)
        {
            int iResult = 0;
            sRetMsg = "";
            sCurrentInvSeqId = "";
            string sInvTypeId = "";
            sInvTypeId = cbbInvType.SelectedValue.ToString();
            DataRow row = gridView1.GetDataRow(iItemId);
            string ssCustId = row["CUSTID"].ToString();
            string sRaxRate = row["TAXRATE"].ToString();

            string spName = "p_fin_invoice_bill_Sum";

            string[] sParameters = new string[9] { "result", "@InvTypeId", "@TaxRate", "@sCustId", "@BeginDate", "@EndDate", "@UserId", "@InvSeqId", "@Msg" };

            string[] sParametersValue = new string[9] {"", sInvTypeId, sRaxRate, ssCustId, sDateFrom,sDateTo,"0", "","" };
            string[] sParametersType = new string[9] {"VarChar", "Int", "Int", "VarChar", "VarChar", "VarChar", "VarChar", "VarChar", "VarChar" };
            string[] sParametersDirection = new string[9] { "ReturnValue", "Input", "Input", "Input", "Input", "Input", "Input", "Output","Output" };
            int[] sParametersSize = new int[9] { 10, sInvTypeId.Length, sRaxRate.Length,sCustId.Length, sDateFrom.Length, sDateTo.Length, 20, 20, 512 };

            iResult = int.Parse(PublicUtility.OperData(spName, sParameters, sParametersValue, sParametersType, sParametersDirection, sParametersSize, out sCurrentInvSeqId, out sRetMsg));
            return iResult;
        }
        private int Invoice(int iItemId)
        {
            if (iItemId != -1)
            {
                //iCurrentItemId = gridView1.FocusedRowHandle;
                //iCurrentItemId = iItemId;  

                DataRow row = gridView1.GetDataRow(iItemId);

                //iCurrentCustId = Convert.ToString(row["BSEQID"]);
                //后台生成发票明细
                if (InvoiceBill(iItemId) == -1) { MessageBox.Show(frmMain.sRetMsg); return 1; }

                if (InvoiceBillHeader(iItemId) == 1) { MessageBox.Show(sRetMsg); return 1; }
                if (InvoiceBillDetail(iItemId) == 1) { MessageBox.Show(sRetMsg); return 1; }

                if (int.Parse(cbbInvType.SelectedValue.ToString()) == 2) frmMain.oComTaxCard.iInvType = 2;
                if (int.Parse(cbbInvType.SelectedValue.ToString()) == 1) frmMain.oComTaxCard.iInvType = 0;

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
                        //{ MessageBox.Show(frmMain.oComTaxCard.sRetMsg); return 1; }

                    if (PublicUtility.InvoiceValidated(sCurrentInvSeqId, frmMain.oComTaxCard._InvoiceRetInfo.sRetInfoTypeCode, frmMain.oComTaxCard._InvoiceRetInfo.sRetInfoNumber.ToString()) == -1) { MessageBox.Show(frmMain.sRetMsg); return 1; }
                }
                
               // if (PublicUtility.InvoiceValidated(sCurrentInvSeqId, "111", "12345") == -1) { MessageBox.Show(frmMain.sRetMsg); return 1; }
            }
            return 0;
        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            iCurrentItemId = -1;
            //if (gridView1.SelectedRowsCount > 0)
            //{
                iCurrentItemId = gridView1.FocusedRowHandle;
                //后台生成发票明细
                Invoice(iCurrentItemId);
            //}
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
        public string OperData(string StoredProcedureName, string[] Parameters, string[] ParametersValue, string[] ParametersType, string[] ParametersDirection,int[] ParametersSize, out string Id,out string ErrMsg)
        {
            string iResult;

            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                iResult = pObj_Comm.ExecuteSP(StoredProcedureName, Parameters, ParametersValue, ParametersType, ParametersDirection,out Id, out ErrMsg);

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

        private void btnBill_Click_1(object sender, EventArgs e)
        {
            foreach (int i in gridView1.GetSelectedRows())
            {
                if (Invoice(i) == 1) { MessageBox.Show(sRetMsg); return; }
            }
            GetData();

        }


        private void txtCust_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                GetData();
        }

        private void GetCust()
        {
            string sFilter = txtCust.Text.Trim();
            string sFilterSql =


            "SELECT     " +
            "    CUSTID,CUSTNAME,TaxCustName,A.INVTYPEID,B.INVTYPENAME,TAXNO,   " +
            "	BANKNAME + BANKACCOUNT AS BANKNAME, ADDRESS+CONTACTPHONE AS ADDRESS   " +
            " FROM T_Cust_TaxCode A LEFT JOIN T_Invoice_Type B ON A.INVTYPEID = B.INVTYPEID   " +
            " WHERE(CUSTNAME LIKE '%" + sFilter + "% ' OR DBO.FGETPY(CUSTNAME) LIKE '%" + sFilter + "%') ";

            if (txtCust.Text.Trim() != "")
            {
                frmSelCust ofrmSelCust = new frmSelCust();
                ofrmSelCust.ShowSelectData(sFilterSql);
                ofrmSelCust.ShowDialog(this);

                if (ofrmSelCust.DialogResult == DialogResult.OK)
                {
                    sCustId = ((DataRowView)(ofrmSelCust.gridView1.GetFocusedRow())).Row["CUSTID"].ToString();
                    txtCust.Text = ((DataRowView)(ofrmSelCust.gridView1.GetFocusedRow())).Row["CUSTNAME"].ToString();
                }
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void chkAutoBill_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAutoBill.Checked)
            {
                timer1.Interval = int.Parse(upTimerLong.Value.ToString()) * 1000;
                timer1.Start();
            }
            else timer1.Stop();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            iCurrentItemId = -1;
            if (Invoice(0) == 1) { MessageBox.Show(sRetMsg); return; }
            /*for (int i = 0; i < gridView1.RowCount - 1; i++)
            {
                Thread.Sleep(int.Parse(upTimerLong.Value.ToString()));
                //if (gridView1.SelectedRowsCount > 0)
                //{
                //    iCurrentItemId = gridView1.FocusedRowHandle;
                //后台生成发票明细
                if (Invoice(i) == 1) { MessageBox.Show(sRetMsg); return; }
                // }
            }*/            
            GetData();
        }

        private void frmBillSum_Load(object sender, EventArgs e)
        {
            gridControl1.ForceInitialize();
            // Restore the previously saved layout  
            if (System.IO.File.Exists(fileName))
                gridControl1.MainView.RestoreLayoutFromXml(fileName);
        }

        private void frmBillSum_FormClosing(object sender, FormClosingEventArgs e)
        {
            gridControl1.MainView.SaveLayoutToXml(fileName);
        }

        private void cbbDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            sDeptId = cbbDept.SelectedValue.ToString();
        }
    }
}

﻿using InvoiceBill.Basic;
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
using InvoiceBill.Basic;
using static InvoiceBill.Basic.ComStruct;

namespace InvoiceBill
{
    public partial class frmInvoiceManager : Form
    {
        string sRetMsg = "";
        public frmInvoiceManager()
        {
            InitializeComponent();

            fLoadInvoiceType();
            fLoadDept();
        }

        private void fLoadInvoiceType()
        {
            string sInvoiceSql =
                "SELECT INVTYPEID,INVTYPENAME FROM T_Invoice_Type ";

            cbbInvType.DataSource = GetDataTable(sInvoiceSql);
            cbbInvType.ValueMember = "INVTYPEID";
            cbbInvType.DisplayMember = "INVTYPENAME";

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
            string sDeptId = cbbDept.SelectedValue.ToString();
            string sCustId = txtCust.Text.Trim();
            string sInvoiceno = txtInvoiceNo.Text.Trim();
            string sInvTypeId = cbbInvType.SelectedValue.ToString();

            string spName = "p_Get_Invoice";
            string sDateFrom = dtpDateFrom.Value.ToString("yyyy-MM-dd");
            string sDateTo = dtpDateTo.Value.ToString("yyyy-MM-dd");

            string[] sParameters = new string[6] { "@DeptId", "@InvoiceNo", "@InvTypeId", "@CustName", "@BeginDate", "@EndDate" };

            string[] sParametersValue = new string[6] { sDeptId,sInvoiceno, sInvTypeId, sCustId, sDateFrom, sDateTo };
            string[] sParametersType = new string[6] { "Int","VarChar", "VarChar", "VarChar", "VarChar", "VarChar" };
            string[] sParametersDirection = new string[6] { "Input", "Input", "Input", "Input", "Input", "Input" };

            gridControl1.DataSource = GetDataTableBySp(spName, sParameters, sParametersValue, sParametersType, sParametersDirection);
        }
        public int InvoiceCancel(string sInvSeqid, string sUserName)
        {
            int iResult = 0;
            string spName = "P_Invoice_Cancel";

            string[] sParameters = new string[3] { "@InvSeqId", "@UserId", "@Msg" };

            string[] sParametersValue = new string[3] { sInvSeqid, "0", sRetMsg };
            string[] sParametersType = new string[3] { "Int", "Int", "VarChar" };
            string[] sParametersDirection = new string[3] { "Input", "Input", "Output" };
            int[] sParametersSize = new int[3] { 0, 0, 200 };

            iResult = int.Parse(OperData(spName, sParameters, sParametersValue, sParametersType, sParametersDirection, sParametersSize));
            return iResult;
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

        private void btnQuery_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            int iResult = 0;
            int iMyRetrun = 0;
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
            
            iResult = frmMain.oComTaxCard.InvCancel(iInfoKind,Convert.ToInt32(row["INVOICENO"]),Convert.ToString(row["INVOICECODE"]));
            if (iResult == 1)
            {
                MessageBox.Show(frmMain.oComTaxCard.sRetMsg);

            }
            else
            {
                if (PublicUtility.InvoiceCanceled(iCurrentBseqId) == -1) { MessageBox.Show(frmMain.sRetMsg); }
                if (PublicUtility.InvoiceCanceledSK(iCurrentBseqId) == -1) { MessageBox.Show(frmMain.sRetMsg); }
            }
            GetData();

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            short iInfoKind = 0;
            foreach (int i in gridView1.GetSelectedRows())
            {
                DataRow row = gridView1.GetDataRow(i);

                string sInvSeqid = Convert.ToString(row["INVSEQID"]);
                string sTypeCode = Convert.ToString(row["INVOICECODE"]);
                string sTypeNo = Convert.ToString(row["INVOICENO"]);
                short iInfoShowPrtDlg = 0;
                if (chkShowPrint.Checked) iInfoShowPrtDlg = 1;

                if (int.Parse(cbbInvType.SelectedValue.ToString()) == 2) frmMain.oComTaxCard.iInvType = 2;
                if (int.Parse(cbbInvType.SelectedValue.ToString()) == 1) frmMain.oComTaxCard.iInvType = 0;

                if (chkPrintList.Checked)  
                    frmMain.oComTaxCard.InvPrint(int.Parse(sTypeNo), sTypeCode, 1, iInfoShowPrtDlg);
                else
                    frmMain.oComTaxCard.InvPrint(int.Parse(sTypeNo), sTypeCode, 0, iInfoShowPrtDlg);

                PrintBill(sInvSeqid);
            }
            GetData();  
        }

        public int PrintBill(string sInvSeqid)
        {
            int iResult = 0;
            sRetMsg = "";
            string sCurrentInvSeqId = "";

            string spName = "p_fin_invoice_print";

            string[] sParameters = new string[4] { "result", "@InvSeqId", "@UserId", "@Msg" };

            string[] sParametersValue = new string[4] { "", sInvSeqid, "0", "" };
            string[] sParametersType = new string[4] { "VarChar", "VarChar", "Int", "VarChar" };
            string[] sParametersDirection = new string[4] { "ReturnValue","Input", "Input", "Output" };
            int[] sParametersSize = new int[4] { 20, 20,20, 512 };

            //iResult = int.Parse(PublicUtility.OperData(spName, sParameters, sParametersValue, sParametersType, sParametersDirection, sParametersSize));
            iResult = int.Parse(PublicUtility.OperData(spName, sParameters, sParametersValue, sParametersType, sParametersDirection, sParametersSize, out sCurrentInvSeqId, out sRetMsg));
            return iResult;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int iCurrentItemId = gridView1.FocusedRowHandle;
            DataRow row = gridView1.GetDataRow(iCurrentItemId);
            string sInvSeqId = Convert.ToString(row["INVSEQID"]);
            string sIvoiceCode = Convert.ToString(row["INVOICECODE"]);
            string sIvoiceNo = Convert.ToString(row["INVOICENO"]);

            string sResult = "";
            string sUrl = "http://localhost:8081";

            //string sJson = "fpdm=3200182130&fphm=64003515&qdbj=0&dysz=1";
            string sJson = "fpdm="+sIvoiceCode +"&fphm="+sIvoiceNo;
            sResult = PublicUtility.PostJson(sUrl, sJson);
            ToJsonMy oToJsonMy =PublicUtility.JsonMy(sResult);

            if (oToJsonMy.result == "True" && oToJsonMy.data == "成功") PrintBill(sInvSeqId);
            else MessageBox.Show(oToJsonMy.data +"-"+ oToJsonMy.result);

            //PrintBill(sInvSeqId);
            //HttpRequest.PostAsyncJson(sUrl, sJson);
        }

    }
}

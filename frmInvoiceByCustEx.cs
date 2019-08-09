using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using InvoiceBill.DAO;
using InvoiceBill.Basic;

namespace InvoiceBill
{
    public partial class frmInvoiceByCustEx : DevExpress.XtraEditors.XtraForm
    {
        public string sCustId;
        public string sCustName;
        public int iInvseqId = 0;
        public string sRetMsg = "";
        public string sCurrentInvSeqId = "";

        public frmInvoiceByCustEx()
        {
            InitializeComponent();
        }

        private void fLoadInvoiceType()
        {
            string sInvoiceSql =
                "SELECT INVTYPEID,INVTYPENAME FROM T_Invoice_Type ";

            cbbInvType.EditValue = "INVTYPEID";
            cbbInvType.Properties.DataSource = GetDataTable(sInvoiceSql);
            cbbInvType.Properties.ValueMember = "INVTYPEID";
            cbbInvType.Properties.DisplayMember = "INVTYPENAME";

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

        private void txtDept_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //getOtherData(ComStruct.selCustomer);
            //txtCust.Text = sCustName;

            //GetCust();

        }
        public void getOtherData(int sOperType)
        {
            frmSelectData ofrmSelectData = new frmSelectData();

            //ofrmSelectOtherData.ShowSelectData(ComStruct.selCustomer);
            ofrmSelectData.ShowSelectData(sOperType, txtCust.Text.Trim());
            if (ofrmSelectData.Tag != null)
            {
                string[] arrValue = ofrmSelectData.Tag.ToString().Split('|');

                if (arrValue.Length > 0)
                {
                    sCustId = arrValue[0];
                    sCustName = arrValue[1];
                }
            }
        }

        private void GetCust()
        {
            string sFilter = txtCust.Text.Trim();
            string sFilterSql =


            "SELECT     "+
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
                    txtInvCust.Text = ((DataRowView)(ofrmSelCust.gridView1.GetFocusedRow())).Row["TAXCUSTNAME"].ToString();
                    txtTaxNo.Text = ((DataRowView)(ofrmSelCust.gridView1.GetFocusedRow())).Row["TAXNO"].ToString();
                    txtBank.Text = ((DataRowView)(ofrmSelCust.gridView1.GetFocusedRow())).Row["BANKNAME"].ToString();
                    txtAddress.Text = ((DataRowView)(ofrmSelCust.gridView1.GetFocusedRow())).Row["ADDRESS"].ToString();
                    //cbbInvType.EditValue = ((DataRowView)(ofrmSelCust.gridView1.GetFocusedRow())).Row["INVTYPEID"].ToString();
                    cbbInvType.ItemIndex = int.Parse(((DataRowView)(ofrmSelCust.gridView1.GetFocusedRow())).Row["INVTYPEID"].ToString()); 
                }
            }
        }


        private void txtCust_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                //getOtherData(ComStruct.selCustomer);
                //txtCust.Text = sCustName;

                GetCust();
                GetData();
            }
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

        public void GetData()
        {
            //string sDeptid = txtDept.Text.Trim();
            //string sCustId = txtCust.Text.Trim();


            string spName = "p_Get_Pending_Inv_Cust_Ex";
            string sDateFrom = dtpFrom.DateTime.ToString("yyyy-MM-dd");
            string sDateTo = dtpTo.DateTime.ToString("yyyy-MM-dd");            

            string[] sParameters = new string[3] {"@CustId", "@BeginDate", "@EndDate" };

            string[] sParametersValue = new string[3] {sCustId, sDateFrom, sDateTo };
            string[] sParametersType = new string[3] {"VarChar", "VarChar", "VarChar" };
            string[] sParametersDirection = new string[3] {"Input", "Input", "Input" };

            gridControl1.DataSource = GetDataTableBySp(spName, sParameters, sParametersValue, sParametersType, sParametersDirection);
        }

        public void GetDetailData()
        {
            string sDeptid = txtDept.Text.Trim();
            string sCustId = txtCust.Text.Trim();
            //string sInvTypeId = cbbInvType.SelectedItem.ToString();
            string iItemList = getItemList();

            if (iItemList != "")
            {
                string spName = "p_Get_Pending_Inv_Detail_List_Ex";

                string[] sParameters = new string[1] { "@BseqIdList" };

                string[] sParametersValue = new string[1] { iItemList };
                string[] sParametersType = new string[1] { "VarChar" };
                string[] sParametersDirection = new string[1] { "Input" };

                gridControl2.DataSource = GetDataTableBySp(spName, sParameters, sParametersValue, sParametersType, sParametersDirection);

            }
        }
        public string getItemList() //获取选中的行
        {
            string iIdList = "'',";

            foreach (int i in gridView1.GetSelectedRows())
            {
                DataRow rows = gridView1.GetDataRow(i);
                iIdList = iIdList +"'"+ rows["BSEQID"].ToString() + "',";               
            }

            iIdList = iIdList.Substring(0, iIdList.Length - 1);
            return iIdList;
        }
        public int ValidData() //校验开票数据
        {
            //是否超发票限额 
            //是否缺少分类编码

            return 0;
        }
        public float GetSumAmount()
        {
            float fSumAmount = 0;
            foreach (int i in gridView2.GetSelectedRows())
            {
                DataRow row = gridView2.GetDataRow(i);
                fSumAmount = fSumAmount + float.Parse(row["AMOUNT"].ToString());
            }
            return fSumAmount;
        }
        public void SetBseqSumAmount()
        {
            float fSumAmount = 0;
            string sCurrentBseqId = "";
            foreach (int i in gridView1.GetSelectedRows())
            {
                DataRow row = gridView2.GetDataRow(i);
                sCurrentBseqId =(row["BSEQID"].ToString()).ToString();
                fSumAmount = GetDetAmount(sCurrentBseqId);

                gridView1.SetRowCellValue(i, "AMOUNT", fSumAmount);
            }
        }
        public float GetDetAmount(string sBseqId)
        {
            float fSumAmount = 0;
            foreach (int i in gridView2.GetSelectedRows())
            {
                DataRow row = gridView2.GetDataRow(i);
                if ((row["BSEQID"].ToString()).ToString() == sBseqId)
                    fSumAmount = fSumAmount + float.Parse(row["PAMOUNT"].ToString());
            }
            return fSumAmount;
        }
        public string GetXml()
        {
            string sXml = "<r>";
            foreach (int i in gridView2.GetSelectedRows())
            {
                sXml = sXml + "<d>";
                DataRow row = gridView2.GetDataRow(i);
                sXml = sXml + "<BSEQID>" + row ["BSEQID"].ToString()+ "</BSEQID>";
                sXml = sXml + "<CUSTID>" + sCustId + "</CUSTID>";
                sXml = sXml + "<BILLTYPEID>"+ row["INVTYPEID"].ToString() + "</BILLTYPEID>";
                sXml = sXml + "<xLineNo>" + row["xLineNo"].ToString() + "</xLineNo>";
                sXml = sXml + "<ARTID>" + row["ARTID"].ToString() + "</ARTID>";
                sXml = sXml + "<TOTAL>" + row["TOTAL"].ToString() + "</TOTAL>";
                sXml = sXml + "<PRICE>" + row["PRICE"].ToString() + "</PRICE>";
                sXml = sXml + "<AMOUNT>" + row["AMOUNT"].ToString() + "</AMOUNT>";
                sXml = sXml + "<TAXRATE>" + row["TAXRATE"].ToString() + "</TAXRATE>";
                sXml = sXml + "</d>";
            }
            return sXml = sXml + "</r>";
        }

        //保存发票
        public int InvoiceBill()
        {
            int iResult = 0;
            string sXml = GetXml();
            string sInvTypeId = cbbInvType.EditValue.ToString();          
            string spName = "p_fin_invoice_bill_Cust_Ex";
            sCurrentInvSeqId = "";

            string[] sParameters = new string[6] { "result", "@Xml", "@InvoiceType", "@UserId", "@InvSeqId", "@Msg" };

            string[] sParametersValue = new string[6] {"0", sXml, sInvTypeId, "0", "", sRetMsg };
            string[] sParametersType = new string[6] { "Int","VarChar", "Int", "VarChar", "Int", "VarChar" };
            string[] sParametersDirection = new string[6] { "ReturnValue", "Input", "Input", "Input", "Output", "Output" };
            int[] sParametersSize = new int[6] {10, sXml.Length, 20, 20, 20, 512 };

            //iResult = int.Parse(OperData(spName, sParameters, sParametersValue, sParametersType, sParametersDirection));
            iResult = int.Parse(OperData(spName, sParameters, sParametersValue, sParametersType, sParametersDirection, sParametersSize, out sCurrentInvSeqId, out sRetMsg));
            return iResult;
        }
        public string OperData(string StoredProcedureName, string[] Parameters, string[] ParametersValue, string[] ParametersType, string[] ParametersDirection, int[] ParametersSize, out string Id, out string ErrMsg)
        {
            string iResult;

            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                iResult = pObj_Comm.ExecuteSP(StoredProcedureName, Parameters, ParametersValue, ParametersType, ParametersDirection, ParametersSize,out Id, out ErrMsg);

                pObj_Comm.Close();

                return iResult;
            }
            catch (Exception ex)
            {
                pObj_Comm.Close();
                throw ex;
            }
        }

        //读取开票结果明细
        public void GetInvoiceData(int iInvseqId)
        {
            string sDeptid = txtDept.Text.Trim();
            string sCustId = txtCust.Text.Trim();
            string sInvTypeId = cbbInvType.Properties.ValueMember;
            string iItemList = getItemList();


            string spName = "p_Get_Pending_Inv_Detail_List";
            string sDateFrom = dtpFrom.DateTime.ToString("yyyy-MM-dd");
            string sDateTo = dtpTo.DateTime.ToString("yyyy-MM-dd");

            string[] sParameters = new string[5] { "@BseqId", "@InvTypeId", "@LineList", "@BeginDate", "@EndDate" };

            string[] sParametersValue = new string[5] { "", sInvTypeId.ToString(), sCustId, sDateFrom, sDateTo };
            string[] sParametersType = new string[5] { "VarChar", "VarChar", "VarChar", "VarChar", "VarChar" };
            string[] sParametersDirection = new string[5] { "Input", "Input", "Input", "Input", "Input" };

            gridControl2.DataSource = GetDataTableBySp(spName, sParameters, sParametersValue, sParametersType, sParametersDirection);
        }

        //获取发票头信息
        public int InvoiceBillHeader()
        {
            frmMain.oComTaxCard._InvocieHeader.sInfoClientName = txtInvCust.Text.Trim();
            frmMain.oComTaxCard._InvocieHeader.sInfoClientTaxCode = txtTaxNo.Text.Trim();
            frmMain.oComTaxCard._InvocieHeader.sInfoClientBankAccount = txtBank.Text.Trim();
            frmMain.oComTaxCard._InvocieHeader.sInfoClientAddressPhone = txtAddress.Text.Trim();
            frmMain.oComTaxCard._InvocieHeader.sInfoSellerBankAccount = ComStruct.sInfoSellerBankAccount;
            frmMain.oComTaxCard._InvocieHeader.sInfoSellerAddressPhone = ComStruct.sInfoSellerAddressPhone;
            //frmMain.oComTaxCard._InvocieHeader.iInfoTaxRate = iTaxRate;
            frmMain.oComTaxCard._InvocieHeader.sInfoNotes = txtNote.Text.Trim();
            frmMain.oComTaxCard._InvocieHeader.sInfoInvoicer = frmMain.sTrueName; //开票员
            frmMain.oComTaxCard._InvocieHeader.sInfoChecker = ""; //复核员
            frmMain.oComTaxCard._InvocieHeader.sInfoCashier =""; //
            //frmMain.oComTaxCard._InvocieHeader.sInfoBillNumber = Convert.ToString(row["BSEQID"]);

            return 0;
        }
        //取已经未审核发票明细
        public int InvoiceBillDetail()
        {
            DataTable myDt = new DataTable();

            string spName = "p_Get_Pending_Inv_Detail_Cust";

            string[] sParameters = new string[1] { "@InvseqId"};

            string[] sParametersValue = new string[1] { sCurrentInvSeqId.ToString() };
            string[] sParametersType = new string[1] { "VarChar" };
            string[] sParametersDirection = new string[1] { "Input" };

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
        //调用税控开票
        private int Invoice()
        {

            if (InvoiceBill() == -1) { MessageBox.Show(sRetMsg); return 1; }

            if (InvoiceBillHeader() == -1) { MessageBox.Show(sRetMsg); return 1; }
            if (InvoiceBillDetail() == 1) { MessageBox.Show(sRetMsg); return 1; }
            //接口开具发票，不成功作废后台明细
            if (frmMain.oComTaxCard.InvoiceBill() == 1)
            {
                MessageBox.Show(frmMain.oComTaxCard.sRetMsg);

                if (InvoiceCanceled(sCurrentInvSeqId) == -1) {MessageBox.Show(sRetMsg); return 1; };

                return 1;
            }
            else
            if (InvoiceValidated(sCurrentInvSeqId, frmMain.oComTaxCard._InvoiceRetInfo.sRetInfoTypeCode, frmMain.oComTaxCard._InvoiceRetInfo.sRetInfoNumber.ToString()) == -1) { MessageBox.Show(sRetMsg); return 1; }
            return 0;
        }
        //审核发票
        public int InvoiceValidated(string sBseqId, string sInvoiceCode, string sInvoiceNo)
        {
            if (sInvoiceCode is null) sInvoiceCode = "";
            int iResult = 0;
            string sOut = "";

            string spName = "p_fin_invoice_Validated";

            string[] sParameters = new string[6] { "result","@InvseqId", "@InvoiceCode", "@InvoiceNumber", "@UserId", "@Msg" };

            string[] sParametersValue = new string[6] { "0", sCurrentInvSeqId.ToString(), sInvoiceCode, sInvoiceNo, "0", sRetMsg };
            string[] sParametersType = new string[6] { "Int", "VarChar", "VarChar", "VarChar", "VarChar", "VarChar" };
            string[] sParametersDirection = new string[6] { "ReturnValue", "Input", "Input", "Input", "Input", "Output" };
            int[] sParametersSize = new int[6] { 10, 20, 20, 20, 20, 512 };
            
            iResult = int.Parse(OperData(spName, sParameters, sParametersValue, sParametersType, sParametersDirection, sParametersSize, out sOut, out sRetMsg));
            
            return iResult;
        }
        //作废发票
        public int InvoiceCanceled(string sInvseqId)
        {
            int iResult = 0;
            string sOut = "";
            string spName = "P_Invoice_Cancel";

            string[] sParameters = new string[4] { "result", "@InvseqId","@UserId", "@Msg" };

            string[] sParametersValue = new string[4] { "0", sCurrentInvSeqId.ToString(),"0", sRetMsg };
            string[] sParametersType = new string[4] {"Int", "VarChar", "VarChar", "VarChar" };
            string[] sParametersDirection = new string[4] { "ReturnValue", "Input", "Input","Output" };
            int[] sParametersSize = new int[4] { 10, 20, 20,512 };

            iResult = int.Parse(OperData(spName, sParameters, sParametersValue, sParametersType, sParametersDirection, sParametersSize, out sOut, out sRetMsg));
            return iResult;
        }

        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            GetDetailData();

            foreach (int i in gridView1.GetSelectedRows())
            {
                DataRow row = gridView1.GetDataRow(i);
                setDetailValue(row["BSEQID"].ToString());
            }

        }

        private void gridView2_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            SetBseqSumAmount();

            DataRow row = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            int i = gridView2.FocusedRowHandle;
            if (gridView2.IsRowSelected(i))
            {
                gridView2.SetRowCellValue(i, "PTOTAL", gridView2.GetRowCellValue(i, "BSNTOTAL"));
                gridView2.SetRowCellValue(i, "PAMOUNT", gridView2.GetRowCellValue(i, "BSNAMOUNT"));
            }
            else
            {
                gridView2.SetRowCellValue(i, "PTOTAL", 0);
                gridView2.SetRowCellValue(i, "PAMOUNT", 0);
            }           
        }
        private void setDetailValue(string sBseqId)
        {
            for (int i = 0; i < gridView2.RowCount; i++)
            {
                DataRow row = gridView2.GetDataRow(i);
                if ((row["BSEQID"].ToString()).ToString() == sBseqId)
                {
                    gridView2.SelectRow(i);
                    gridView2.SetRowCellValue(i, "PTOTAL", gridView2.GetRowCellValue(i, "BSNTOTAL"));
                    gridView2.SetRowCellValue(i, "PAMOUNT", gridView2.GetRowCellValue(i, "BSNAMOUNT"));
                }
            }
        }
        private void gridView2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) 
            {
                gridView2.UpdateCurrentRow();
            }
        }

        private void gridView2_KeyUp(object sender, KeyEventArgs e)
        {
            /*gridView2.UpdateCurrentRow();

            if (e.KeyCode == Keys.Enter && (gridView2.FocusedColumn.FieldName == "PTOTAL"))
            {
                int iCurrentItemId = gridView1.FocusedRowHandle;
                DataRow row = gridView2.GetFocusedDataRow();
                double fAmount = double.Parse(row["BSNAMOUNT"].ToString());
                //double fAmount = double.Parse(gridView2.GetRowCellValue(iCurrentItemId, "BSNAMOUNT").ToString());
                double iTotal = double.Parse(gridView2.GetRowCellValue(iCurrentItemId, "BSNTOTAL").ToString());
                double iPTotal = double.Parse(gridView2.GetRowCellValue(iCurrentItemId, "PTOTAL").ToString());
                double fPAmount = fAmount * (iPTotal / iTotal);

                gridView2.SetRowCellValue(iCurrentItemId, "PAMOUNT", fPAmount.ToString());
            }
            SetBseqSumAmount();
            gridView1.UpdateCurrentRow();*/
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            /*
            if (gridView2.RowCount > 0 && e.RowHandle >= 0)
            {
                if (gridView2.FocusedColumn.FieldName == "PTOTAL")
                {
                    try
                    {
                        int iCurrentItemId = gridView2.FocusedRowHandle;
                        double fAmount = double.Parse(gridView2.GetRowCellValue(iCurrentItemId, "BSNAMOUNT").ToString());
                        double iTotal = double.Parse(gridView2.GetRowCellValue(iCurrentItemId, "BSNTOTAL").ToString());
                        double iPTotal = double.Parse(gridView2.GetRowCellValue(iCurrentItemId, "PTOTAL").ToString());

                        double fPAmount = fAmount * (iPTotal/iTotal);

                        gridView2.SetRowCellValue(iCurrentItemId, "PAMOUNT", fPAmount);
                        SetBseqSumAmount();
                    }
                    catch
                    { }
                 }

            }*/
        }

        private void gridView2_LostFocus(object sender, EventArgs e)
        {

        }

        private void gridView2_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            if (gridView2.RowCount > 0 && e.RowHandle >= 0)
            {
                if (gridView2.FocusedColumn.FieldName == "PTOTAL")
                {
                    try
                    {
                        int iCurrentItemId = e.RowHandle;
                        double fAmount = double.Parse(gridView2.GetRowCellValue(iCurrentItemId, "BSNAMOUNT").ToString());
                        double iTotal = double.Parse(gridView2.GetRowCellValue(iCurrentItemId, "BSNTOTAL").ToString());
                        double iPTotal = double.Parse(gridView2.GetRowCellValue(iCurrentItemId, "PTOTAL").ToString());

                        double fPAmount = fAmount * (iPTotal / iTotal);

                        gridView2.SetRowCellValue(iCurrentItemId, "PAMOUNT", fPAmount);
                        SetBseqSumAmount();
                    }
                    catch
                    { }
                }

            }            
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (Invoice() == 0) { MessageBox.Show(sRetMsg); }
            else
            { InoviceIminit(); }
        }
        private void InoviceIminit()
        {
            gridControl1.DataSource = null;
            gridControl2.DataSource = null;
            OperateControls(panelControl1);
        }

        public void OperateControls(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c is TextEdit) { c.Text = ""; }

                if (c is DateEdit) { ((DateEdit)c).DateTime = DateTime.Now; }

            }

            sCustId ="";
            sCustName ="";
            iInvseqId = 0;
            sRetMsg = "";
            sCurrentInvSeqId = "";

    }
        private void frmInvoiceByCust_Load(object sender, EventArgs e)
        {
            fLoadInvoiceType();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
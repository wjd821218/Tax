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
using System.IO;

namespace InvoiceBill
{
    public partial class frmInvoice : DevExpress.XtraEditors.XtraForm
    {
        public string sDeptId = "1";
        public string sDeptName;
        public string sCustId;
        public string sCustName;
        public int iInvseqId = 0;
        public string sRetMsg = "";
        public string sCurrentInvSeqId = "";

        string fileName = Path.Combine(Application.UserAppDataPath, "GridControlFactoryInvoice.xml");

        private DataTable IniBindTable()
        {
            DataTable _dt = new DataTable();
            DataColumn _datacol1 = new DataColumn("ARTID");
            DataColumn _datacol2 = new DataColumn("ARTNAME");
            DataColumn _datacol3 = new DataColumn("SPEC");
            DataColumn _datacol4 = new DataColumn("FACTORY");
            DataColumn _datacol5 = new DataColumn("UNIT");
            DataColumn _datacol6 = new DataColumn("TOTAL");
            DataColumn _datacol7 = new DataColumn("PRICE");
            DataColumn _datacol8 = new DataColumn("AMOUNT");
            DataColumn _datacol9 = new DataColumn("TAXRATE");

            _dt.Columns.Add(_datacol1);
            _dt.Columns.Add(_datacol2);
            _dt.Columns.Add(_datacol3);
            _dt.Columns.Add(_datacol4);
            _dt.Columns.Add(_datacol5);
            _dt.Columns.Add(_datacol6);
            _dt.Columns.Add(_datacol7);
            _dt.Columns.Add(_datacol8);
            _dt.Columns.Add(_datacol9);
            return _dt;
        }
        public frmInvoice()
        {
            InitializeComponent();
            fLoadDept();
        }
        private void fLoadDept()
        {
            string sInvoiceSql =
                "SELECT DEPTID,DEPTNAME FROM T_DEPT WHERE DEPTID IN ( " + frmMain.sPermsDept + ")";

            cbbDept.DataSource = GetDataTable(sInvoiceSql);
            cbbDept.ValueMember = "DEPTID";
            cbbDept.DisplayMember = "DEPTNAME";

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
            //
        }

        private void GetCust()
        {
            string sFilter = txtCust.Text.Trim();
            string sFilterSql =


            "SELECT     " +
            "    CUSTID,CUSTNAME,TaxCustName,A.INVTYPEID,B.INVTYPENAME,TAXNO," +
            "    BANKNAME + BANKACCOUNT AS BANKNAME, ADDRESS+CONTACTPHONE AS ADDRESS   " +
            " FROM T_Cust_TaxCode A LEFT JOIN T_Invoice_Type B ON A.INVTYPEID = B.INVTYPEID   " +
            " WHERE(CUSTCODE ='" + sFilter + "' OR CUSTNAME LIKE '%" + sFilter + "%') ";

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
        private void GetArt(int iRowHandle)
        {
            string sFilter = gridView1.GetRowCellValue(iRowHandle,"ARTNAME").ToString();
            string sFilterSql =
            "SELECT     " +
            "    ARTID,NAME AS ARTNAME,ARTCODE,SPEC,UNIT,FACTORY,0 AS TAXREATE" +            
            " FROM T_Article A    " +
            " WHERE(ARTCODE ='" + sFilter + "' OR [NAME] LIKE '%" + sFilter + "%') ";

            if (sFilter.Trim() != "")
            {
                frmSelArt ofrmSelArt = new frmSelArt();
                ofrmSelArt.ShowSelectData(sFilterSql);
                ofrmSelArt.ShowDialog(this);

                if (ofrmSelArt.DialogResult == DialogResult.OK)
                {
                    gridView1.SetRowCellValue(iRowHandle, "ARTID", ((DataRowView)(ofrmSelArt.gridView1.GetFocusedRow())).Row["ARTID"].ToString());
                    gridView1.SetRowCellValue(iRowHandle, "ARTNAME", ((DataRowView)(ofrmSelArt.gridView1.GetFocusedRow())).Row["ARTNAME"].ToString());

                }
            }
        }

        private void txtCust_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                GetCust();
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

        public int ValidData() //校验开票数据
        {
            if (sCustId =="") { sRetMsg = "没有输入开票抬头！"; return 1; }
            //是否超发票限额 
            //是否缺少分类编码
            //开票数量，金额不能超过未开金额
            foreach (int i in gridView1.GetSelectedRows())
            {
                double fAmount = double.Parse(gridView1.GetRowCellValue(i, "BSNAMOUNT").ToString());
                double iTotal = double.Parse(gridView1.GetRowCellValue(i, "BSNTOTAL").ToString());
                double iPTotal = double.Parse(gridView1.GetRowCellValue(i, "PTOTAL").ToString());
                double iPAmount = double.Parse(gridView1.GetRowCellValue(i, "PAMOUNT").ToString());
                double iPrice = double.Parse(gridView1.GetRowCellValue(i, "PRICE").ToString());

                if (iPAmount / iPTotal != iPrice) { sRetMsg = "开票数量金额不正确！"; return 1; }
                if (iPTotal > iTotal || iPAmount > fAmount) { sRetMsg = "开票数量或金额不能大于未开数量金额！"; return 1; }
            }

            return 0;
        }
        public float GetDetAmount(string sBseqId)
        {
            float fSumAmount = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            //    foreach (int i in gridView2.GetSelectedRows())
            {

                DataRow row = gridView1.GetDataRow(i);

                if ((row["BSEQID"].ToString()).ToString() == sBseqId && (gridView1.IsRowSelected(i)))
                {
                    fSumAmount = fSumAmount + float.Parse(row["PAMOUNT"].ToString());
                }

            }

            return fSumAmount;
        }
        public string GetXml()
        {
            string sXml = "<r>";
            foreach (int i in gridView1.GetSelectedRows())
            {
                sXml = sXml + "<d>";
                DataRow row = gridView1.GetDataRow(i);
                sXml = sXml + "<BSEQID>X</BSEQID>";
                sXml = sXml + "<CUSTID>" + sCustId + "</CUSTID>";
                sXml = sXml + "<BILLTYPEID>" + cbbInvType.EditValue.ToString() + "</BILLTYPEID>";
                sXml = sXml + "<xLineNo>1</xLineNo>";
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
            string iDeptId =  cbbDept.SelectedValue.ToString();
            string spName = "p_fin_invoice";
            sCurrentInvSeqId = "";

            string[] sParameters = new string[7] { "result", "@DeptId","@Xml", "@InvoiceType", "@UserId", "@InvSeqId", "@Msg" };

            string[] sParametersValue = new string[7] { "0", iDeptId,sXml, sInvTypeId, "0", "", sRetMsg };
            string[] sParametersType = new string[7] { "Int", "Int", "VarChar", "Int", "VarChar", "Int", "VarChar" };
            string[] sParametersDirection = new string[7] { "ReturnValue", "Input", "Input", "Input", "Input", "Output", "Output" };
            int[] sParametersSize = new int[7] { 10, iDeptId.Length,sXml.Length, 20, 20, 20, 512 };

            iResult = int.Parse(OperData(spName, sParameters, sParametersValue, sParametersType, sParametersDirection, sParametersSize, out sCurrentInvSeqId, out sRetMsg));
            return iResult;
        }
        public string OperData(string StoredProcedureName, string[] Parameters, string[] ParametersValue, string[] ParametersType, string[] ParametersDirection, int[] ParametersSize, out string Id, out string ErrMsg)
        {
            string iResult;

            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                iResult = pObj_Comm.ExecuteSP(StoredProcedureName, Parameters, ParametersValue, ParametersType, ParametersDirection, ParametersSize, out Id, out ErrMsg);

                pObj_Comm.Close();

                return iResult;
            }
            catch (Exception ex)
            {
                pObj_Comm.Close();
                throw ex;
            }
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
            frmMain.oComTaxCard._InvocieHeader.sInfoNotes = txtNote.Text.Trim();
            frmMain.oComTaxCard._InvocieHeader.sInfoInvoicer = frmMain.sTrueName; //开票员
            frmMain.oComTaxCard._InvocieHeader.sInfoChecker = ""; //复核员
            frmMain.oComTaxCard._InvocieHeader.sInfoCashier = ""; //
            return 0;
        }
        //取已经未审核发票明细
        public int InvoiceBillDetail()
        {
            DataTable myDt = new DataTable();

            string spName = "p_Get_Pending_Inv_Detail_Cust";

            string[] sParameters = new string[1] { "@InvseqId" };

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
            if (chkNoBill.Checked == false)
            {
                if (frmMain.oComTaxCard.InvoiceBill() == 1)
                {

                    MessageBox.Show(frmMain.oComTaxCard.sRetMsg);
                    if (PublicUtility.InvoiceCanceled(sCurrentInvSeqId) == -1) MessageBox.Show(sRetMsg);
                    return 1;
                }
                else
                {
                    if (chkPrint.Checked)
                        frmMain.oComTaxCard.InvPrint(int.Parse(frmMain.oComTaxCard._InvoiceRetInfo.sRetInfoNumber.ToString()),
                            frmMain.oComTaxCard._InvoiceRetInfo.sRetInfoTypeCode, 0, frmMain.oComTaxCard.iInfoShowPrtDlg);
                    if (PublicUtility.InvoiceValidated(sCurrentInvSeqId, frmMain.oComTaxCard._InvoiceRetInfo.sRetInfoTypeCode, frmMain.oComTaxCard._InvoiceRetInfo.sRetInfoNumber.ToString()) == -1) { MessageBox.Show(frmMain.sRetMsg); return 1; }
                }
            }
            return 0;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (Invoice() == 1) { MessageBox.Show(sRetMsg); }
            else
            { InoviceIminit(); }
        }
        private void InoviceIminit()
        {
            gridControl1.DataSource = null;
            OperateControls(panelControl1);
        }

        public void OperateControls(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c is TextEdit) { c.Text = ""; }

                if (c is DateEdit) { ((DateEdit)c).DateTime = DateTime.Now; }

            }

            sCustId = "";
            sCustName = "";
            iInvseqId = 0;
            sRetMsg = "";
            sCurrentInvSeqId = "";

        }
        private void frmInvoiceByCust_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = IniBindTable();
            fLoadInvoiceType();
            gridControl1.ForceInitialize();
            if (System.IO.File.Exists(fileName))
                gridControl1.MainView.RestoreLayoutFromXml(fileName);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                GetCust();
            }
        }

        private void frmInvoiceByCust_FormClosing(object sender, FormClosingEventArgs e)
        {
            gridControl1.MainView.SaveLayoutToXml(fileName);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //
        }

        private void tbtnAdd_Click(object sender, EventArgs e)
        {
            gridView1.AddNewRow();
        }

        private void gridView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && gridView1.FocusedColumn.FieldName == "ARTNAME")
            {
                GetArt(gridView1.FocusedRowHandle);
            }
            
        }

        private void gridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13 && gridView1.FocusedColumn.FieldName == "ARTNAME")
            {
                GetArt(gridView1.FocusedRowHandle);
            }
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            
            if (gridView1.FocusedRowHandle != -1)
                GetArt(gridView1.FocusedRowHandle);
        }
    }
}
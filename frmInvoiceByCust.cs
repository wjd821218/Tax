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
    public partial class frmInvoiceByCust : DevExpress.XtraEditors.XtraForm
    {
        public string sCustId;
        public string sCustName;
        public int iInvseqId = 0;
        public string sRetMsg = "";

        public frmInvoiceByCust()
        {
            InitializeComponent();
        }

        private void fLoadInvoiceType()
        {
            string sInvoiceSql =
                "SELECT INVTYPEID,INVTYPENAME FROM T_Invoice_Type ";

            //cbbInvType.DataBindings = 
            //cbbInvType.DataSource = GetDataTable(sInvoiceSql);
            //cbbInvType.ValueMember = "INVTYPEID";
            //cbbInvType.DisplayMember = "INVTYPENAME";

        }

        private void txtDept_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            getOtherData(ComStruct.selCustomer);
            txtCust.Text = sCustName;

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

        private void txtCust_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                getOtherData(ComStruct.selCustomer);
                txtCust.Text = sCustName;

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


            string spName = "p_Get_Pending_Inv_Cust";
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


            string spName = "p_Get_Pending_Inv_Detail_List";

            string[] sParameters = new string[1] { "@BseqIdList" };

            string[] sParametersValue = new string[1] { iItemList };
            string[] sParametersType = new string[1] { "VarChar"};
            string[] sParametersDirection = new string[1] { "Input" };

            gridControl2.DataSource = GetDataTableBySp(spName, sParameters, sParametersValue, sParametersType, sParametersDirection);
        }
        public string getItemList() //获取选中的行
        {
            string iIdList = "";
            foreach (int i in gridView1.GetSelectedRows())
            {
                DataRow rows = gridView1.GetDataRow(i);
                iIdList = iIdList + rows["BSEQID"].ToString() + ",";               
            }

            iIdList = iIdList.Substring(0, iIdList.Length - 1);
            return iIdList;
        }
        public int ValidData() //校验开票数据
        {

            return 0;
        }
        public string GetXml()
        {
            string sXml = "<d>";
            foreach (int i in gridView2.GetSelectedRows())
            {
                sXml = sXml + "<r>";
                DataRow row = gridView2.GetDataRow(i);
                sXml = sXml + "<BSEQID>" + row ["BSEQID"].ToString()+ "</BSEQID>";
                sXml = sXml + "<CUSTID>" + sCustId + "</CUSTID>";
                sXml = sXml + "<BILLTYPEID>"+ row["BILLTYPEID"].ToString() + "</BILLTYPEID>";
                sXml = sXml + "<iLINENO>" + row["iLINENO"].ToString() + "</iLINENO>";
                sXml = sXml + "<ARTID>" + row["ARTID"].ToString() + "</ARTID>";
                sXml = sXml + "<TOTAL>" + row["TOTAL"].ToString() + "</TOTAL>";
                sXml = sXml + "<PRICE>" + row["PRICE"].ToString() + "</PRICE>";
                sXml = sXml + "<AMOUNT>" + row["AMOUNT"].ToString() + "</AMOUNT>";
                sXml = sXml + "</r>";
            }
            return sXml = sXml + "</d>";
        }

        //保存发票
        public int InvoiceSave(string sBseqId, string sInvoiceCode, string sInvoiceNo)
        {
            int iResult = 0;
            string spName = "p_fin_invoice_bill";

            string[] sParameters = new string[5] { "@BseqId", "@InvoiceCode", "@InvoiceNumber", "@UserId", "@Msg" };

            string[] sParametersValue = new string[5] { sBseqId, sInvoiceCode, sInvoiceNo, "0", sRetMsg };
            string[] sParametersType = new string[5] { "Varchar2", "Varchar2", "Varchar2", "Varchar2", "Varchar2" };
            string[] sParametersDirection = new string[5] { "Input", "Input", "Input", "Input", "Output" };

            iResult = int.Parse(OperData(spName, sParameters, sParametersValue, sParametersType, sParametersDirection));
            return iResult;
        }

        //读取开票结果明细
        public void GetInvoiceData(int iInvseqId)
        {
            string sDeptid = txtDept.Text.Trim();
            string sCustId = txtCust.Text.Trim();
            string sInvTypeId = cbbInvType.SelectedItem.ToString();
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
            frmMain.oComTaxCard._InvocieHeader.sInfoSellerBankAccount = "江南农村商业银行大学城支行 88801019012010000001281";
            frmMain.oComTaxCard._InvocieHeader.sInfoSellerAddressPhone = "江苏省常州市武进经济开发区长扬路15号 0519-69698289";
            //frmMain.oComTaxCard._InvocieHeader.iInfoTaxRate = iTaxRate;
            frmMain.oComTaxCard._InvocieHeader.sInfoNotes = txtNote.Text.Trim();
            frmMain.oComTaxCard._InvocieHeader.sInfoInvoicer = ""; //开票员
            frmMain.oComTaxCard._InvocieHeader.sInfoChecker = ""; //复核员
            frmMain.oComTaxCard._InvocieHeader.sInfoCashier =""; //
            //frmMain.oComTaxCard._InvocieHeader.sInfoBillNumber = Convert.ToString(row["BSEQID"]);

            return 0;
        }
        //取已经未审核发票明细
        public int InvoiceBillDetail()
        {
            DataTable myDt = new DataTable();

            string spName = "sp_get_invDetail";

            string[] sParameters = new string[1] { "@InvseqId"};

            string[] sParametersValue = new string[1] { iInvseqId.ToString() };
            string[] sParametersType = new string[1] { "Varchar2"};
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
        public int InvoiceBill()
        {
            return frmMain.oComTaxCard.InvoiceBill();
        }
        //审核发票
        public int InvoiceValidated(string sBseqId, string sInvoiceCode, string sInvoiceNo)
        {
            int iResult = 0;
            string spName = "p_fin_invoice_Validated";

            string[] sParameters = new string[5] { "@InvseqId", "@InvoiceCode", "@InvoiceNumber", "@UserId", "@Msg" };

            string[] sParametersValue = new string[5] { iInvseqId.ToString(), sInvoiceCode, sInvoiceNo, "0", sRetMsg };
            string[] sParametersType = new string[5] { "Varchar2", "Varchar2", "Varchar2", "Varchar2", "Varchar2" };
            string[] sParametersDirection = new string[5] { "Input", "Input", "Input", "Input", "Output" };

            iResult = int.Parse(OperData(spName, sParameters, sParametersValue, sParametersType, sParametersDirection));
            return iResult;
        }
        //作废发票
        public int InvoiceCanceled(string sInvseqId)
        {
            int iResult = 0;
            string spName = "p_fin_invoice_Canceled";

            string[] sParameters = new string[3] { "@InvseqId","@UserId", "@Msg" };

            string[] sParametersValue = new string[3] { iInvseqId.ToString(),"0", sRetMsg };
            string[] sParametersType = new string[3] { "Varchar2", "Varchar2", "Varchar2" };
            string[] sParametersDirection = new string[3] { "Input", "Input","Output" };

            iResult = int.Parse(OperData(spName, sParameters, sParametersValue, sParametersType, sParametersDirection));
            return iResult;
        }

        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            GetDetailData();
        }
    }
}
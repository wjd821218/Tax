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
using System.Xml;
using DevExpress.XtraGrid.Views.Grid;

namespace InvoiceBill
{
    public partial class frmBase : Form
    {
        public string operSpName = "";
        public string querySpName = "";

        public string[] sParameters;   //参数列表
        public string[] sParametersValue;  //参数值
        public string[] sParametersType;   //参数类型
        public string[] sParametersDirection;  //参数传递方向

        string sRetMsg = "";
        int iTaxDetailCount = 0;

        public CommonInterface pObj_Comm;

        public frmBase()
        {
            InitializeComponent();
        }

        public DataTable GetDataTableBySp()
        {
            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.Oracle);
            try
            {
                DataTable pDTMain = pObj_Comm.ExecuteSPSursor(querySpName, sParameters, sParametersValue, sParametersType, sParametersDirection).Tables[0];

                pObj_Comm.Close();
                return pDTMain;
            }
            catch (Exception ex)
            {
                pObj_Comm.Close();
                throw ex;
            }
        }

        public virtual void SetParams()
        {
            //
        }
        public virtual void SetQueryParams()
        {
            //
        }
        public string Operator()
        {
            string sResult;

            sResult = OperData(operSpName, sParameters, sParametersValue, sParametersType, sParametersDirection);
            return sResult;
        }

        public string OperData(string StoredProcedureName, string[] Parameters, string[] ParametersValue, string[] ParametersType, string[] ParametersDirection)
        {
            string iResult;

            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                iResult = pObj_Comm.ExecuteSP(StoredProcedureName, Parameters, ParametersValue, ParametersType, ParametersDirection).ToString();

                pObj_Comm.Close();

                return iResult;
            }
            catch (Exception ex)
            {
                pObj_Comm.Close();
                throw ex;
            }
        }

        public void fLoadInvoiceType(ComboBox oComboBox)
        {
            string sDeliverySql =
                "SELECT INVTYPEID,INVTYPENAME FROM T_Invoice_Type ";

            oComboBox.DataSource = GetDataTable(sDeliverySql);
            oComboBox.ValueMember = "INVTYPEID";
            oComboBox.DisplayMember = "INVTYPENAME";

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

        private string getDataXml(string sGoodsNoVer, string sGoodsTaxNo, string sTaxPre, string sZeroTax, string sCropGoodsNo)
        {
            string sTaxPreCon = "";

            string sDataXml =
            "<?xml version=\"1.0\" encoding=\"GBK\"?>" +
            "<FPXT>" +
                "<INPUT>" +
                    "<GoodsNo>" +
                    "<GoodsNoVer>" + sGoodsNoVer + "</GoodsNoVer>" +
                    "<GoodsTaxNo>" + sGoodsTaxNo + "</GoodsTaxNo>" +
                    "<TaxPre>" + sTaxPre + "</TaxPre>" +
                    "<TaxPreCon>" + sTaxPreCon + "</TaxPreCon>" +
                    "<ZeroTax>" + sZeroTax + "</ZeroTax>" +
                    "<CropGoodsNo>" + sCropGoodsNo + "</CropGoodsNo>" +
                    "<TaxDeduction></TaxDeduction>" +
                    "</GoodsNo>" +
                    "</INPUT>" +
            "</FPXT>";

            return sDataXml;
        }
        private string BatchUpLoad(string sDataXml)
        {
            string sResultXml = "";
            //Base64 cBase64 = new Base64();

            sResultXml =
                "<?xml version=\"1.0\" encoding=\"GBK\"?>" +
                "<FPXT_COM_INPUT>" +
                "<ID>1100</ID> " +
                "<DATA>" + Base64.EncodeBase64(sDataXml) + "</DATA> " +
                "</FPXT_COM_INPUT>";

            return sResultXml;
        }

        public int fVaildBatchUp(string sXml)
        {
            string sCode = "";
            string sMess = "";

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(sXml);

            foreach (XmlNode node in doc.SelectNodes("FPXT_COM_OUTPUT"))
            {
                sCode = node.ChildNodes[1].FirstChild.Value.ToString();
                sMess = node.ChildNodes[2].FirstChild.Value.ToString();
            }

            if (sCode != "0000")
            {
                sRetMsg = "校验税收分类编码错误，错误代码：" + sCode + "--" + sMess + "!";
                return 1;

            }
            return 0;

        }

        public void fGetDetailCount(int iItemId, GridView gridView1 )
        {
            DataRow row = gridView1.GetDataRow(iItemId);

            string sBseqId = Convert.ToString(row["BSEQID"]);

            DataTable myDt = new DataTable();
            string sDeliverySql =
                "SELECT ARTID FROM T_Inv_Pending_BILL_DETAIL  WHERE BSEQID = " + sBseqId;

            myDt = GetDataTable(sDeliverySql);

            iTaxDetailCount = myDt.Rows.Count;

        }

    }
}

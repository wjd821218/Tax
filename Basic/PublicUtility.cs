using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvoiceBill.DAO;
using System.Data;
using System.Net;
using System.IO;
using static InvoiceBill.Basic.ComStruct;
using System.Web.Script.Serialization;
using System.Configuration;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;

namespace InvoiceBill.Basic
{
    public class CboItemEntity
    {
        private object _text = 0;
        private object _Value = "";
        /// <summary>
        /// 显示值
        /// </summary>
        public object Text
        {
            get { return this._text; }
            set { this._text = value; }
        }
        /// <summary>
        /// 对象值
        /// </summary>
        public object Value
        {
            get { return this._Value; }
            set { this._Value = value; }
        }

        public override string ToString()
        {
            return this.Text.ToString();
        }
    }

    class PublicUtility
    {
        public static string GetTreeCheckList(TreeList oTreeList)
        {
            string SelectValues = "";  

            for (int i = 0; i < oTreeList.AllNodesCount; i++)
            {
                TreeListNode oNode = oTreeList.FindNodeByID(i);
                if (oNode.Checked) SelectValues += oNode.GetValue(1).ToString() + ",";
            }
            return SelectValues ;
            
        }
        public static string GetCheckList(CheckedListBoxControl oCheckedListBoxControl)
        {
            string SelectValues = "";

            for (int i = 0; i < oCheckedListBoxControl.ItemCount; i++)
            {
                if (oCheckedListBoxControl.GetItemChecked(i))
                {
                    SelectValues += oCheckedListBoxControl.GetItemValue(i).ToString() + ",";
                }
            }
            return SelectValues;

        }
        public static DataTable GetDataTable(string SqlOraStr)
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
        public static int PrintBill(string sInvSeqid)
        {
            int iResult = 0;
            string sCurrentInvSeqId = "";

            string spName = "p_fin_invoice_print";

            string[] sParameters = new string[4] { "result", "@InvSeqId", "@UserId", "@Msg" };

            string[] sParametersValue = new string[4] { "", sInvSeqid, frmMain.sUserid, "" };
            string[] sParametersType = new string[4] { "VarChar", "VarChar", "Int", "VarChar" };
            string[] sParametersDirection = new string[4] { "ReturnValue", "Input", "Input", "Output" };
            int[] sParametersSize = new int[4] { 20, 20, 20, 512 };
            
            iResult = int.Parse(PublicUtility.OperData(spName, sParameters, sParametersValue, sParametersType, sParametersDirection, sParametersSize, out sCurrentInvSeqId, out frmMain.sRetMsg));
            return iResult;
        }
        public static ToJsonMy JsonMy(string sJson)
        {                    　　　　　　 
            JavaScriptSerializer js = new JavaScriptSerializer();   //实例化一个能够序列化数据的类
            ToJsonMy list = js.Deserialize<ToJsonMy>(sJson);    //将json数据转化为对象类型并赋值给list
            return list;
        }
        public static string PostJson(string url, string josn)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "json";
            //声明一个HttpWebRequest请求
            request.Timeout = 80000;
            //转发机制
            Encoding encoding = Encoding.UTF8;
            Stream streamrequest = request.GetRequestStream();
            StreamWriter streamWriter = new StreamWriter(streamrequest, encoding);
            streamWriter.Write(josn);
            streamWriter.Flush();
            streamWriter.Close();
            streamrequest.Close();

            //设置连接超时时间
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream streamresponse = response.GetResponseStream();
            StreamReader streamReader = new StreamReader(streamresponse, encoding);
            string result = streamReader.ReadToEnd();
            //log.InfoFormat("上传返回信息,{0}", result);
            streamresponse.Close();
            streamReader.Close();

            return result;
        }

        public static int ValidCustInfo(int InvType, DevExpress.XtraGrid.Views.Grid.GridView GridView1)
        {
            foreach (int i in GridView1.GetSelectedRows())
            {
                DataRow dr = GridView1.GetDataRow(i);;
                if (
                    (
                        (InvType == 2)
                        &&
                        (
                            (dr["TAXCUSTNAME"].ToString().Trim() == "")
                            //|| (dr["TAXNO"].ToString().Trim() == "")
                        )
                        )
                    )
                {
                    MessageBox.Show(dr["TAXCUSTNAME"] + "开票资料不完整！");
                    return 1;
                }
                //专用发票
                if (
                    (InvType == 0) &&
                    (
                           (dr["TAXCUSTNAME"].ToString().Trim() == "")
                        || (dr["TAXNO"].ToString().Trim() == "")
                        || (dr["BANKNAME"].ToString().Trim() == "")
                        || (dr["BANKACCOUNT"].ToString().Trim() == "")
                        || (dr["ADDRESS"].ToString().Trim() == "")
                        //|| (dr["CONTACTPHONE"].ToString().Trim() == "")
                    )
                    )
                {
                    MessageBox.Show(dr["TAXCUSTNAME"] + "开票资料不完整！");
                    return 1;
                }
            }
            return 0;
        }
        public static string OperDataEx(string StoredProcedureName, string[] Parameters, string[] ParametersValue, string[] ParametersType, string[] ParametersDirection, out string[] ParametersOut)
        {
            string iResult;

            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                iResult = pObj_Comm.ExecuteSP(StoredProcedureName, Parameters, ParametersValue, ParametersType, ParametersDirection, out ParametersOut);

                pObj_Comm.Close();

                return iResult;
            }
            catch (Exception ex)
            {
                pObj_Comm.Close();
                throw ex;
            }
        }
        public static string OperData(string StoredProcedureName, string[] Parameters, string[] ParametersValue, string[] ParametersType, string[] ParametersDirection, int[] ParametersSize, out string Id, out string ErrMsg)
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

        public static string OperData(string StoredProcedureName, string[] Parameters, string[] ParametersValue, string[] ParametersType, string[] ParametersDirection, int[] ParametersSize)
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

        public static DataTable InvoiceBillDetail(string iFinSeqid)
        {
            DataTable myDt = new DataTable();

            string spName = "p_Get_Pending_Inv_Detail_Cust";

            string[] sParameters = new string[1] { "@InvSeqId" };

            string[] sParametersValue = new string[1] {iFinSeqid};
            string[] sParametersType = new string[1] { "VarChar" };
            string[] sParametersDirection = new string[1] { "Input" };

            myDt = GetDataTableBySp(spName, sParameters, sParametersValue, sParametersType, sParametersDirection);

            return myDt;
        }

        public static int InvoiceValidated(string sInvSeqId, string sInvoiceCode, string sInvoiceNo)
        {
            if (sInvoiceCode is null) sInvoiceCode = "";

            int iResult = 0;
            string sOut = "";
            string spName = "p_fin_invoice_Validated";

            string[] sParameters = new string[6] { "result", "@InvSeqId", "@InvoiceCode", "@InvoiceNumber", "@UserId", "@Msg" };

            string[] sParametersValue = new string[6] { "0", sInvSeqId, sInvoiceCode, sInvoiceNo, frmMain.sUserid, frmMain.sRetMsg };
            string[] sParametersType = new string[6] { "Int", "VarChar", "VarChar", "VarChar", "VarChar", "VarChar" };
            string[] sParametersDirection = new string[6] { "ReturnValue", "Input", "Input", "Input", "Input", "Output" };
            int[] sParametersSize = new int[6] { 20, 20, 20, 20,20, 512 };

            iResult = int.Parse(OperData(spName, sParameters, sParametersValue, sParametersType, sParametersDirection, sParametersSize, out sOut, out frmMain.sRetMsg));
            iResult = InvoiceValidatedSK(sInvSeqId, sInvoiceCode, sInvoiceNo);
            return iResult;
        }
        public static int InvoiceValidatedSK(string sInvSeqId, string sInvoiceCode, string sInvoiceNo)
        {
            if (sInvoiceCode is null) sInvoiceCode = "";

            int iResult = 0;
            string sOut = "";
            string spName = "p_fin_invoice_Validated_SK";

            string[] sParameters = new string[6] { "result", "@InvSeqId", "@InvoiceCode", "@InvoiceNumber", "@UserId", "@Msg" };

            string[] sParametersValue = new string[6] { "0", sInvSeqId, sInvoiceCode, sInvoiceNo, frmMain.sUserid, frmMain.sRetMsg };
            string[] sParametersType = new string[6] { "Int", "VarChar", "VarChar", "VarChar", "VarChar", "VarChar" };
            string[] sParametersDirection = new string[6] { "ReturnValue", "Input", "Input", "Input", "Input", "Output" };
            int[] sParametersSize = new int[6] { 20, 20, 20, 20, 20, 512 };

            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql, ConfigurationSettings.AppSettings["CCERPConnStr"]);
            try
            {
                iResult = int.Parse(pObj_Comm.ExecuteSP(spName, sParameters, sParametersValue, sParametersType, sParametersDirection, sParametersSize, out sOut, out frmMain.sRetMsg));

                pObj_Comm.Close();

                return iResult;
            }
            catch (Exception ex)
            {
                pObj_Comm.Close();
                throw ex;
            }
        }
        public static DataTable GetDataTableBySp(string sPName, string[] _Parameters, string[] _ParametersValue, string[] _ParametersType, string[] _ParametersDirection)
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

        public static int InvoiceCanceled(string sInvseqId)
        {
            int iResult = 0;
            string sOut = "";
            string spName = "P_Invoice_Cancel";

            string[] sParameters = new string[4] { "result", "@InvseqId", "@UserId", "@Msg" };

            string[] sParametersValue = new string[4] { "0", sInvseqId, frmMain.sUserid, frmMain.sRetMsg };
            string[] sParametersType = new string[4] { "Int", "VarChar", "VarChar", "VarChar" };
            string[] sParametersDirection = new string[4] { "ReturnValue", "Input", "Input", "Output" };
            int[] sParametersSize = new int[4] { 10, 20, 20, 512 };

            iResult = int.Parse(OperData(spName, sParameters, sParametersValue, sParametersType, sParametersDirection, sParametersSize, out sOut, out frmMain.sRetMsg));
            return iResult;
        }
        public static int InvoiceCanceledSK(string sInvseqId)
        {
            int iResult = 0;
            string sOut = "";
            string spName = "P_Invoice_Cancel_SK";

            string[] sParameters = new string[4] { "result", "@InvseqId", "@UserId", "@Msg" };

            string[] sParametersValue = new string[4] { "0", sInvseqId, frmMain.sUserid, frmMain.sRetMsg };
            string[] sParametersType = new string[4] { "Int", "VarChar", "VarChar", "VarChar" };
            string[] sParametersDirection = new string[4] { "ReturnValue", "Input", "Input", "Output" };
            int[] sParametersSize = new int[4] { 10, 20, 20, 512 };

            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql, ConfigurationSettings.AppSettings["CCERPConnStr"]);
            try
            {
                iResult = int.Parse(pObj_Comm.ExecuteSP(spName, sParameters, sParametersValue, sParametersType, sParametersDirection, sParametersSize, out sOut, out frmMain.sRetMsg));

                pObj_Comm.Close();

                return iResult;
            }
            catch (Exception ex)
            {
                pObj_Comm.Close();
                throw ex;
            }
        }
    }
}

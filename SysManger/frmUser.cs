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
using InvoiceBill.Basic;
using DevExpress.XtraEditors.Controls;
using static InvoiceBill.Basic.ComStruct;

namespace InvoiceBill.SysManger
{
    public partial class frmUser : DevExpress.XtraEditors.XtraForm
    {
        int iUserId = 0;
        int iOperType = -1;
        UserInfo oUserInfo = new UserInfo();
        public frmUser()
        {
            InitializeComponent();

        }

        private void btnFresh_Click(object sender, EventArgs e)
        {
            GetData();
        }
        private void GetData()
        {
             string sInvoiceSql = "SELECT ID,USERCODE,USERNAME,PASSWORD,STATE,CREATEDATE FROM T_USER";
            gridControl1.DataSource = PublicUtility.GetDataTable(sInvoiceSql);
        }
        private void FillData(int iId, frmUserInfo ofrmUserInfo)
        {
            if (gridView1.FocusedRowHandle > 0)
            {
                ofrmUserInfo.iUserId = int.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID").ToString());
                ofrmUserInfo.txtId.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID").ToString();
                ofrmUserInfo.txtNo.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "USERCODE").ToString();
                ofrmUserInfo.txtUserName.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "USERNAME").ToString();
                //ofrmUserInfo.txtPassWord.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PASSWORD").ToString();
                //ofrmUserInfo.txtPassWordPre.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PASSWORD").ToString();

                oUserInfo.UserId = int.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID").ToString());
                oUserInfo.UserCode = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "USERCODE").ToString();
                oUserInfo.UserName = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "USERNAME").ToString();
                oUserInfo.PassWord = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PASSWORD").ToString();
                oUserInfo.PermsDept = PublicUtility.GetCheckList(ofrmUserInfo.chkListDept);
                oUserInfo.PermsRole = PublicUtility.GetCheckList(ofrmUserInfo.chkListRole);
            }

        }

        private void GetData(frmUserInfo ofrmUserInfo)
        {

            oUserInfo.UserId = ofrmUserInfo.iUserId;
            oUserInfo.UserCode = ofrmUserInfo.txtNo.Text.Trim();
            oUserInfo.UserName = ofrmUserInfo.txtUserName.Text.Trim();
            oUserInfo.PassWord = ofrmUserInfo.txtPassWord.Text.Trim();
            oUserInfo.PermsDept = PublicUtility.GetCheckList(ofrmUserInfo.chkListDept);
            oUserInfo.PermsRole = PublicUtility.GetCheckList(ofrmUserInfo.chkListRole);

        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            GetData();
        }
        private void initForm(int iUserId,frmUserInfo ofrmUserInfo)
        {
            string sDeptSql = "SELECT DEPTID,DEPTNAME," +
            "CONVERT(Bit,CASE WHEN(SELECT DEPTID FROM T_USER_DEPT WHERE DEPTID = A.DEPTID AND USERID = " + iUserId.ToString() +") IS NULL THEN 0 ELSE 1 END) AS ISCHECK " +
            "FROM T_DEPT A";
            ofrmUserInfo.chkListDept.DataSource = PublicUtility.GetDataTable(sDeptSql);
            ofrmUserInfo.chkListDept.DisplayMember = "DEPTNAME";
            ofrmUserInfo.chkListDept.ValueMember = "DEPTID";
            ofrmUserInfo.chkListDept.CheckMember = "ISCHECK";

            string sRoleSql = "SELECT ROLEID,ROLENAME," +
                            "CONVERT(Bit,CASE WHEN(SELECT ROLEID FROM T_USER_ROLE WHERE ROLEID = A.ROLEID AND USERID = " + iUserId.ToString() +") IS NULL THEN 0 ELSE 1 END) AS ISCHECK " +
                            "FROM T_ROLE A ";
            ofrmUserInfo.chkListRole.DataSource = PublicUtility.GetDataTable(sRoleSql);
            ofrmUserInfo.chkListRole.DisplayMember = "ROLENAME";
            ofrmUserInfo.chkListRole.ValueMember = "ROLEID";
            ofrmUserInfo.chkListRole.CheckMember = "ISCHECK";
            
        }

        private void SaveInfo()
        {
            int iResult = 0;
            string sRetMsg = "";
            
            string spName = "p_User_Save";

            string[] sParameters = new string[9] { "result", "@OperType", "@UserCode", "@UserName", "@Password", "@UserId", "@PermsDept", "@PermsRole", "@Msg" };

            string[] sParametersValue = new string[9] { "0", iOperType.ToString(), oUserInfo.UserCode, oUserInfo.UserName, oUserInfo.PassWord, oUserInfo.UserId.ToString(), oUserInfo.PermsDept, oUserInfo.PermsRole,sRetMsg };
            string[] sParametersType = new string[9] { "Int", "Int", "VarChar", "VarChar", "VarChar", "Int", "VarChar", "VarChar" , "VarChar" };
            string[] sParametersDirection = new string[9] { "ReturnValue", "Input", "Input", "Input", "Input", "Input", "Input", "Input", "Output" };
            int[] sParametersSize = new int[9] { 10, 20, 10, 50, 20, 20, 200, 200,512 };
            
            iResult = int.Parse(PublicUtility.OperData(spName, sParameters, sParametersValue, sParametersType, sParametersDirection, sParametersSize, out sRetMsg, out sRetMsg));

            if (iResult == -1) { MessageBox.Show(sRetMsg); return; }
           
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmUserInfo ofrmUserInfo = new frmUserInfo();
            iOperType = 0;
            initForm(0, ofrmUserInfo);
            ofrmUserInfo.ShowDialog(this);

            if (ofrmUserInfo.DialogResult == DialogResult.OK)
            {
                GetData(ofrmUserInfo);
                SaveInfo();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            iOperType = 1;
            int iUserId = int.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID").ToString());

            frmUserInfo ofrmUserInfo = new frmUserInfo();
            FillData(0, ofrmUserInfo);
            initForm(iUserId, ofrmUserInfo);
            ofrmUserInfo.ShowDialog(this);

            if (ofrmUserInfo.DialogResult == DialogResult.OK)
            {
                GetData(ofrmUserInfo);
                SaveInfo();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            iOperType = 2;
            SaveInfo();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            int iUserId = int.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID").ToString());
            frmUserInfo ofrmUserInfo = new frmUserInfo();
            FillData(0, ofrmUserInfo);
            initForm(iUserId, ofrmUserInfo);
            ofrmUserInfo.ShowDialog(this);
        }
    }
}
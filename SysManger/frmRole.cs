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

namespace InvoiceBill.SysManger
{
    public partial class frmRole : DevExpress.XtraEditors.XtraForm
    {
        int iRoleId = 0;
        int iOperType = 0;
        string sRoleName = "";
        string sRoleAction = "";

        public frmRole()
        {
            InitializeComponent();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            //frmRoleAction OfrmRoleAction = new frmRoleAction();
            //OfrmRoleAction.Show();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            frmRoleAction OfrmRoleAction = new frmRoleAction();

            FillData(int.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ROLEID").ToString()), OfrmRoleAction);
            OfrmRoleAction.Show();
        }
        private void GetData()
        {
            string sInvoiceSql = "SELECT ROLEID,ROLENAME FROM T_ROLE";
            gridControl1.DataSource = PublicUtility.GetDataTable(sInvoiceSql);
        }

        private void frmRole_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void FillData(int iRoleId, frmRoleAction ofrmRoleAction)
        {
            string sDeptSql = "SELECT ID AS ACTIONID,ID,PERMID,ACTIONNO,ACTIONNAME,PARENTID," +
            "CONVERT(Bit,CASE WHEN(SELECT ROLEID FROM T_ROLE_ACTION WHERE ACTIONID = A.PERMID AND ROLEID = " + iRoleId.ToString() + ") IS NULL THEN 0 ELSE 1 END) AS ISCHECK " +
            "FROM T_Action A";
 
            ofrmRoleAction.tlRole.DataSource = PublicUtility.GetDataTable(sDeptSql);
            ofrmRoleAction.tlRole.KeyFieldName = "ACTIONID";
            ofrmRoleAction.tlRole.ParentFieldName = "PARENTID";
            ofrmRoleAction.tlRole.CheckBoxFieldName = "ISCHECK";

            ofrmRoleAction.tlRole.Columns["ID"].Visible = false;
            ofrmRoleAction.tlRole.Columns["ISCHECK"].Visible = false;
            //ofrmRoleAction.tlRole.Columns["PARENTID"].Visible = false;

            ofrmRoleAction.txtRoleName.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ROLENAME").ToString();
        }

        private void SaveInfo()
        {
            int iResult = 0;
            string sRetMsg = "";

            string spName = "p_Role_Save";

            string[] sParameters = new string[6] { "result", "@OperType", "@RoleName", "@RoleId", "@RoleAction","@Msg" };

            string[] sParametersValue = new string[6] { "0", iOperType.ToString(), sRoleName, iRoleId.ToString(), sRoleAction, sRetMsg };
            string[] sParametersType = new string[6] { "Int", "Int", "VarChar","Int", "VarChar","VarChar" };
            string[] sParametersDirection = new string[6] { "ReturnValue", "Input", "Input", "Input", "Input", "Output" };
            int[] sParametersSize = new int[6] { 10, 20, 10,10, 500, 50 };

            iResult = int.Parse(PublicUtility.OperData(spName, sParameters, sParametersValue, sParametersType, sParametersDirection, sParametersSize, out sRetMsg, out sRetMsg));

            if (iResult == -1) { MessageBox.Show(sRetMsg); return; }

        }

        private void GetData(frmRoleAction ofrmRoleAction)
        {

            iRoleId = int.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ROLEID").ToString());
            sRoleName = ofrmRoleAction.txtRoleName.Text.Trim();
            sRoleAction = PublicUtility.GetTreeCheckList(ofrmRoleAction.tlRole);

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmRoleAction ofrmRoleAction = new frmRoleAction();
            iOperType = 0;
            FillData(0, ofrmRoleAction);
            ofrmRoleAction.ShowDialog(this);

            if (ofrmRoleAction.DialogResult == DialogResult.OK)
            {
                GetData(ofrmRoleAction);
                SaveInfo();
            }

            GetData();

        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            iOperType = 3;
            SaveInfo();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmRoleAction ofrmRoleAction = new frmRoleAction();
            iOperType = 1;
            FillData(int.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ROLEID").ToString()), ofrmRoleAction);
            ofrmRoleAction.ShowDialog(this);

            if (ofrmRoleAction.DialogResult == DialogResult.OK)
            {
                GetData(ofrmRoleAction);
                SaveInfo();
            }

            GetData();
        }

        private void btnFresh_Click(object sender, EventArgs e)
        {
            GetData();
        }
    }

}
using InvoiceBill.Basic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaxDll;

namespace InvoiceBill
{
    public partial class frmLogin : Form
    {
        public string sUserId = "11111";
        public string sPerms = "000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";
        public string sPermsDept = "11111111111111";
        public string sRetMsg = "111111111111111111111111111111111111111111";
        public string sTrueName = "管理员";
        public frmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (Login(txtUser.Text.Trim(), txtPWD.Text.Trim()) == 1)
            {

                frmMain ofrmMain = new frmMain();
                frmMain.sUserid = sUserId;
                frmMain.sPerms = sPerms;
                frmMain.sPermsDept = sPermsDept;
                frmMain.sTrueName =sTrueName;
                ofrmMain.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(sRetMsg);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public int Login(string UserCode,string PassWord)
        {
            int iResult = 0;

            string spName = "p_Login";

            string[] sOutPara = new string[8] { "", "", "", "000000000", "000000000000000", "00000000000000000000000", "00000000000000000" ,"管理员"};

            string[] sParameters = new string[8] { "result", "@UserName", "@Password", "@UserId", "@PermsDept", "@Perms", "@Msg", "@TrueName" };

            string[] sParametersValue = new string[8] { "0", UserCode, PassWord, sUserId, sPermsDept,sPerms, sRetMsg ,sTrueName };
            string[] sParametersType = new string[8] { "Int", "VarChar", "VarChar", "Int", "VarChar", "VarChar", "VarChar" , "VarChar" };
            string[] sParametersDirection = new string[8] { "ReturnValue", "Input", "Input", "Output", "Output", "Output", "Output", "Output" };
            int[] sParametersSize = new int[8] { 10, UserCode.Length, PassWord.Length, 20, 200,200, 512,20 };
            
            iResult = int.Parse(PublicUtility.OperDataEx(spName, sParameters, sParametersValue, sParametersType, sParametersDirection, out sOutPara));
            sUserId = sOutPara[3];
            sPermsDept = sOutPara[4];
            sPerms = sOutPara[5];
            sRetMsg = sOutPara[6];
            sTrueName = sOutPara[7];

            return iResult;
        }

    }
}

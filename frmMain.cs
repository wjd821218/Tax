using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaxDll;
using DevExpress.XtraEditors;
using DevExpress.Skins;
using InvoiceBill.Basic;
using DevExpress.XtraTab;
using InvoiceBill.SysManger;

namespace InvoiceBill
{
    public partial class frmMain : Form
    {
        static internal ComTaxCard oComTaxCard = new ComTaxCard();
        public static string sRetMsg = "";
        public static string sUserid = "";
        public static string sTrueName = "";
        public static string sPermsDept = "";
        public static string sPerms = "";
        public frmMain()
        {
            InitializeComponent();
            formInit();
        }
        private void MenuInit()
        {
            foreach (ToolStripMenuItem con in this.MainMenuStrip.Items)
            {
                foreach (ToolStripItem con2 in con.DropDownItems)
                { 
                    if (con2 is ToolStripMenuItem)                        
                        if (!sPerms.Contains(con2.Tag.ToString()))
                            con2.Enabled = false;  //使此项不能选
                }
            }

        }
        private void formInit()
        {
            lblTaxNo.Text = "税号：";
            lblLimit.Text = "开票限额：专票0，普票0，金税卡中有票可开，未到抄税期，未到锁死期。";
            lblTaxNumber.Text = "开票机号码：";
            lblOpenTime.Text = "本次开卡时间：";
            lblCom.Text = "普票剩余份数0，将要开具的发票号码为 00000";
            lblSpecial.Text = "专票剩余份数0，将要开具的发票号码为 00000";
            btnOpen.Enabled = true;
            btnClose.Enabled = false;

        }
        private void meuInvoiceBill_Click(object sender, EventArgs e)
        {
            //
        }

        private void menuInvoiceManager_Click(object sender, EventArgs e)
        {
            frmInvoiceManager ofrmInvoiceManager = new frmInvoiceManager();
            //ofrmInvoiceManager.Show();
            //CreateForm("frmInvoiceManager", "InvoiceBill");

            /*ofrmInvoiceManager.TopLevel = false;
            ofrmInvoiceManager.Dock = DockStyle.Fill;
            ofrmInvoiceManager.Parent = panel2;
            ofrmInvoiceManager.BringToFront();
            ofrmInvoiceManager.Show();*/
        }

        private void menuInvoicePrint_Click(object sender, EventArgs e)
        {
            /*frmInvoicePrint ofrmInvoicePrint = new frmInvoicePrint();
            ofrmInvoicePrint.Show();

            ofrmInvoicePrint.TopLevel = false;
            ofrmInvoicePrint.Dock = DockStyle.Fill;
            ofrmInvoicePrint.Parent = panel2;
            ofrmInvoicePrint.BringToFront();
            ofrmInvoicePrint.Show();

            //CreateForm("InvoiceBill.frmInvoicePrint", "InvoiceBill");*/
        }
        public void CreateForm(string strName, string AssemblyName)
        {
            string path = AssemblyName;//项目的Assembly选项名称  
            string name = strName; //类的名字 
            Form doc = (Form)Assembly.Load(path).CreateInstance(name);
            doc.TopLevel = false;
            doc.Dock = DockStyle.Fill;
            doc.Parent = panel2;
            doc.BringToFront();
            doc.Show();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

         public  void refreshInfo()
        {
            lblTaxNo.Text = lblTaxNo.Text + oComTaxCard._OpenTaxInfo.sTaxCode;
            lblTaxNumber.Text = lblTaxNumber.Text + oComTaxCard._OpenTaxInfo.sMachineNo;
            lblLimit.Text = "开票限额：" + oComTaxCard._OpenTaxInfo.iInvLimit.ToString() +
                    (oComTaxCard._OpenTaxInfo.iIsInvEmpty == 0 ? "，金税卡无票可开" : "，金税卡有票可开") +
                    (oComTaxCard._OpenTaxInfo.iIsRepReached == 0 ? "，未到抄税期" : "，已到抄税期") +
                    (oComTaxCard._OpenTaxInfo.iIsLockReached == 0 ? "，未到锁死期" : "，已到锁死期");

            oComTaxCard.GetStockInfo(0);//专用发票
            lblSpecial.Text = "专票剩余份数 " + oComTaxCard._StockTaxInfoPro.iInvStock.ToString() + "，将要开具的发票号码为 " + oComTaxCard._StockTaxInfoPro.iInfoNumber.ToString();

            oComTaxCard.GetStockInfo(2);//普通发票
            lblCom.Text = "普票剩余份数 " + oComTaxCard._StockTaxInfoPro.iInvStock.ToString() + "，将要开具的发票号码为 " + oComTaxCard._StockTaxInfoPro.iInfoNumber.ToString();

        }
        private void btnOpen_Click(object sender, EventArgs e)
        {                       
            if (oComTaxCard.OpenCard() == 0)
            {
                lblTaxNo.Text = lblTaxNo.Text + oComTaxCard._OpenTaxInfo.sTaxCode;
                lblTaxNumber.Text = lblTaxNumber.Text + oComTaxCard._OpenTaxInfo.sMachineNo;                
                lblLimit.Text = "开票限额：" + oComTaxCard._OpenTaxInfo.iInvLimit.ToString()+
                        (oComTaxCard._OpenTaxInfo.iIsInvEmpty == 0 ? "，金税卡无票可开" : "，金税卡有票可开") +
                        (oComTaxCard._OpenTaxInfo.iIsRepReached == 0 ? "，未到抄税期" : "，已到抄税期") + 
                        (oComTaxCard._OpenTaxInfo.iIsLockReached == 0 ? "，未到锁死期" : "，已到锁死期");

                oComTaxCard.GetStockInfo(0);//专用发票
                lblSpecial.Text = "专票剩余份数 " + oComTaxCard._StockTaxInfoPro.iInvStock.ToString() + "，将要开具的发票号码为 " + oComTaxCard._StockTaxInfoPro.iInfoNumber.ToString();

                oComTaxCard.GetStockInfo(2);//普通发票
                lblCom.Text = "普票剩余份数 " + oComTaxCard._StockTaxInfoPro.iInvStock.ToString() + "，将要开具的发票号码为 " + oComTaxCard._StockTaxInfoPro.iInfoNumber.ToString();

                btnClose.Enabled = true;
                btnOpen.Enabled = false;
            }
            else MessageBox.Show(oComTaxCard.sRetMsg, "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
 //           oComTaxCard.GetStockInfo(0);

 //           oComTaxCard.GetStockInfo(2);

        }

        private void TaxClose()
        {
            if (oComTaxCard.InvCloseCard() == 0)
            {
                formInit();
            }
            else MessageBox.Show("关闭金税卡失败！");
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            TaxClose();
        }

        private void 按单快速开票ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInvoiceBill ofrmInvoiceBill = new frmInvoiceBill();
            Add_TabPage("ofrmInvoiceBill", "按单快速开票", ofrmInvoiceBill);
            //CreateForm("frmInvoiceBill", "InvoiceBill");
            /*ofrmInvoiceBill.TopLevel = false;
            ofrmInvoiceBill.Dock = DockStyle.Fill;
            ofrmInvoiceBill.Parent = panel2;
            ofrmInvoiceBill.BringToFront();
            ofrmInvoiceBill.Show();*/
        }

        private void 按客户汇总开票ToolStripMenuItem_Click(object sender, EventArgs e)
        {


            frmBillSum ofrmBillSum = new frmBillSum();

            /*//CreateForm("frmInvoiceBill", "InvoiceBill");
            ofrmBillSum.TopLevel = false;
            ofrmBillSum.Dock = DockStyle.Fill;
            //ofrmBillSum.FormBorderStyle =  FormBorderStyle.None;
            ofrmBillSum.Parent = panel2;
            ofrmBillSum.BringToFront();
            ofrmBillSum.Show();*/
            Add_TabPage("ofrmBillSum", "按客户汇总开票", ofrmBillSum);
        }
        public bool tabControlCheckHave(DevExpress.XtraTab.XtraTabControl tab, String tabName)
        {
            for (int i = 0; i < tab.TabPages.Count; i++)
            {
                if (tab.TabPages[i].Text == tabName)
                {
                    tab.SelectedTabPageIndex = i;
                    return true;
                }
            }
            return false;
        }
        public void Add_TabPage(string str, string sCaption, Form myForm)
        {
            if (tabControlCheckHave(tColMain, str))
            {
                return;
            }
            else
            {
                tColMain.TabPages.Add(str);
                //tColMain.SelectedTabPage(tColMain.TabPages.Count - 1);
                tColMain.SelectedTabPageIndex = tColMain.TabPages.Count - 1;
                tColMain.SelectedTabPage.Text = sCaption;

                myForm.FormBorderStyle = FormBorderStyle.None;
                myForm.Dock = DockStyle.Fill;
                myForm.TopLevel = false;
                myForm.Show();
                myForm.Parent = tColMain.SelectedTabPage;
            }
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            foreach (SkinContainer cnt in SkinManager.Default.Skins)
            {
                cbbSkin.Properties.Items.Add(cnt.SkinName);
            }

            if (sUserid != "1") MenuInit();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = "Office 2010 Blue";
        }

        private void cbbSkin_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxEdit comboBox = sender as ComboBoxEdit;
            string skinName = comboBox.Text;
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = skinName;
        }

        private void 销售发票开票ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInvoiceByCust ofrmInvoiceByCust = new frmInvoiceByCust();
            Add_TabPage("ofrmInvoiceByCust", "销售发票开票", ofrmInvoiceByCust);
        }

        private void 远程打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmInvoicePrintRemote ofrmInvoicePrintRemote = new frmInvoicePrintRemote();
            Add_TabPage("ofrmInvoicePrintRemote", "远程打印", ofrmInvoicePrintRemote);
        }

        private void 发票作废ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmInvoiceManager OfrmInvoiceManager = new frmInvoiceManager();
            Add_TabPage("OfrmInvoiceManager", "发票管理", OfrmInvoiceManager);
        }

        private void meuInovie_Click(object sender, EventArgs e)
        {
            frmInvoiceByCustEx OfrmInvoiceByCustEx = new frmInvoiceByCustEx();
            Add_TabPage("OfrmInvoiceByCustEx", "普通发票红字发票开票", OfrmInvoiceByCustEx);
        }

        private void 普通发票红字开票ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmInvoiceBillNegative ofrmInvoiceBillNegative = new frmInvoiceBillNegative();
            Add_TabPage("ofrmInvoiceBillNegative", "发票红字开票（处理未作废）", ofrmInvoiceBillNegative);

        }

        private void 发票查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInvoiceQuery ofrmInvoiceQuery = new frmInvoiceQuery();
            Add_TabPage("ofrmInvoiceQuery", "发票查询", ofrmInvoiceQuery);
        }

        private void 开票申请ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPendingInvoice ofrmPendingInvoice = new frmPendingInvoice();
            Add_TabPage("ofrmPendingInvoice", "未开发票查询", ofrmPendingInvoice);
        }

        private void 税收分类编码维护ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTaxArt ofrmTaxArt = new frmTaxArt();
            Add_TabPage("ofrmTaxArt", "税收分类编码维护", ofrmTaxArt);
        }

        private void 开票资料维护ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTaxCust ofrmTaxCust = new frmTaxCust();
            Add_TabPage("ofrmTaxCust", "开票资料维护", ofrmTaxCust);
        }

        private void 特殊红字开票ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInvoiceNegativeBillEx ofrmInvoiceNegativeBillEx = new frmInvoiceNegativeBillEx();
            Add_TabPage("ofrmInvoiceNegativeBillEx", "特殊红字开票", ofrmInvoiceNegativeBillEx);
        }

        private void menuConfig_DoubleClick(object sender, EventArgs e)
        {
            frmInvConfig ofrmInvConfig = new frmInvConfig();
            Add_TabPage("ofrmInvConfig", "开票配置", ofrmInvConfig);
        }

        private void 按月汇总开票ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBillSumMonth ofrmBillSumMonth = new frmBillSumMonth();
            Add_TabPage("ofrmBillSumMonth", "按月汇总开票", ofrmBillSumMonth);
        }

        private void 按原单红字发票ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInvoiceNegativeBillExEx ofrmInvoiceNegativeBillExEx = new frmInvoiceNegativeBillExEx();
            Add_TabPage("ofrmInvoiceNegativeBillExEx", "按原单红字发票", ofrmInvoiceNegativeBillExEx);
        }

        private void tColMain_CloseButtonClick(object sender, EventArgs e)
        {
            DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs EArg = (DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs)e;
            string name = EArg.Page.Text;//得到关闭的选项卡的text
            foreach (XtraTabPage page in tColMain.TabPages)//遍历得到和关闭的选项卡一样的Text
            {
                if (page.Text == name)
                {
                    tColMain.TabPages.Remove(page);
                    page.Dispose();
                    return;
                }
            }
        }

        private void 普通发票填开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInvoice ofrmInvoice = new frmInvoice();
            Add_TabPage("ofrmInvoice", "发票填开", ofrmInvoice);
        }

        private void 用户管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUser ofrmUser = new frmUser();
            Add_TabPage("ofrmUser", "用户管理", ofrmUser);
        }

        private void 角色管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRole ofrmRole = new frmRole();
            Add_TabPage("ofrmRole", "角色管理", ofrmRole);
        }
    }
}

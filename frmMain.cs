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

namespace InvoiceBill
{
    public partial class frmMain : Form
    {
        static internal ComTaxCard oComTaxCard = new ComTaxCard();
        //static internal ComTaxCard oComTaxCard;
        public frmMain()
        {
            InitializeComponent();
            formInit();
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
            //frmInvoicePrint ofrmInvoicePrint = new frmInvoicePrint();
            //ofrmInvoicePrint.Show();

            //ofrmInvoicePrint.TopLevel = false;
            //ofrmInvoicePrint.Dock = DockStyle.Fill;
            //ofrmInvoicePrint.Parent = panel2;
            //ofrmInvoicePrint.BringToFront();
            //ofrmInvoicePrint.Show();

            //CreateForm("InvoiceBill.frmInvoicePrint", "InvoiceBill");
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

        private void menuConfig_Click(object sender, EventArgs e)
        {
            frmInvConfig ofrmInvConfig = new frmInvConfig();

            ofrmInvConfig.TopLevel = false;
            ofrmInvConfig.Dock = DockStyle.Fill;
            ofrmInvConfig.Parent = panel2;
            ofrmInvConfig.BringToFront();
            ofrmInvConfig.Show();
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
            oComTaxCard.InvCloseCard();

            if (oComTaxCard.iResult == 0)
            {
                formInit();
            }
            else MessageBox.Show(oComTaxCard.sRetMsg);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            TaxClose();
        }

        private void 按单快速开票ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInvoiceBill ofrmInvoiceBill = new frmInvoiceBill();

            //CreateForm("frmInvoiceBill", "InvoiceBill");
            ofrmInvoiceBill.TopLevel = false;
            ofrmInvoiceBill.Dock = DockStyle.Fill;
            ofrmInvoiceBill.Parent = panel2;
            ofrmInvoiceBill.BringToFront();
            ofrmInvoiceBill.Show();
        }

        private void 按客户汇总开票ToolStripMenuItem_Click(object sender, EventArgs e)
        {


            frmBillSum ofrmBillSum = new frmBillSum();

            //CreateForm("frmInvoiceBill", "InvoiceBill");
            ofrmBillSum.TopLevel = false;
            ofrmBillSum.Dock = DockStyle.Fill;
            ofrmBillSum.Parent = panel2;
            ofrmBillSum.BringToFront();
            ofrmBillSum.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            foreach (SkinContainer cnt in SkinManager.Default.Skins)
            {
                cbbSkin.Properties.Items.Add(cnt.SkinName);
            }
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

            //CreateForm("frmInvoiceBill", "InvoiceBill");
            ofrmInvoiceByCust.TopLevel = false;
            ofrmInvoiceByCust.Dock = DockStyle.Fill;
            ofrmInvoiceByCust.Parent = panel2;
            ofrmInvoiceByCust.BringToFront();
            ofrmInvoiceByCust.Show();

        }

        private void 远程打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            frmPrintWeb ofrmPrintWeb = new frmPrintWeb();

            //CreateForm("frmInvoiceBill", "InvoiceBill");
            ofrmPrintWeb.TopLevel = false;
            ofrmPrintWeb.Dock = DockStyle.Fill;
            ofrmPrintWeb.Parent = panel2;
            ofrmPrintWeb.BringToFront();
            ofrmPrintWeb.Show();
        }

        private void 发票作废ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmInvoiceManager OfrmInvoiceManager = new frmInvoiceManager();

            OfrmInvoiceManager.TopLevel = false;
            OfrmInvoiceManager.Dock = DockStyle.Fill;
            OfrmInvoiceManager.Parent = panel2;
            OfrmInvoiceManager.BringToFront();
            OfrmInvoiceManager.Show();
        }
    }
}

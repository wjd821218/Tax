using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InvoiceBill.DAO;

namespace InvoiceBill.Basic
{
    public partial class frmBasicBase : Form
    {
        public int iId;

        public const int pfPrint = 0;
        public const int pfAdd = 1;
        public const int pfEdit = 2;
        public const int pfView = 3;
        public const int pfDelete = 4;
        public const int pfSave = 5;


        public CommonInterface pObj_Comm;
        public DataTable dt = null;
        public DataSet ds = new DataSet();

        public SqlDataAdapter sda = null;

        public SqlConnection connection = new SqlConnection(CommonDataConfig.ConnectionDefaultStr);

        public frmBasicBase()
        {
            InitializeComponent();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Excel文件|*.XLS|所有文件|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = saveFileDialog1.FileName;
                gridView1.ExportToXls(filename);

                //this.ShowMessage("导出成功");
            }
        }
            public string Operator(int sOperMode)
            {
                if (sOperMode == pfSave) { Save(); };
                return "";
            }
        
            public virtual string Save()
            {
                return "";
            }

            public virtual void Filter()
            {
                //
            }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Operator(pfSave);
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            Filter();
        }

        public virtual void GetData()
        {
            //
        }

        public void DataRefresh(string sSQL, string sTable)
        {
            if (connection.State == ConnectionState.Open) { connection.Close(); }
            ds.Clear();

            sda = new SqlDataAdapter(
            sSQL, connection);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
        
            connection.Open();
            sda.Fill(ds, sTable);

            gridControl1.DataSource = ds.Tables[0];


        }

        private void frmBasicBase_FormClosed(object sender, FormClosedEventArgs e)
        {
            connection.Close();
            connection.Dispose();
            connection = null;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            GetData();
        }
    }
}

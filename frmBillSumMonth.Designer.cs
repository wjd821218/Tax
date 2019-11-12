namespace InvoiceBill
{
    partial class frmBillSumMonth
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCashier = new System.Windows.Forms.TextBox();
            this.txtChecker = new System.Windows.Forms.TextBox();
            this.chkShowPrint = new System.Windows.Forms.CheckBox();
            this.chkPrint = new System.Windows.Forms.CheckBox();
            this.btnBill = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cbbInvType = new System.Windows.Forms.ComboBox();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gColTaxNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gColAdress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gColContactPhone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gColAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dtpBeginDate = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gColDept = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gColCustId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gColCustCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gColCustName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gColInvTypeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gColTaxRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gColBankName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gColBankAccount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gColNotes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCust = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbbDept = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbbBillMode = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.upTimerLong = new System.Windows.Forms.NumericUpDown();
            this.chkAutoBill = new System.Windows.Forms.CheckBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.chkEnable = new System.Windows.Forms.CheckBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upTimerLong)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(702, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 18;
            this.label7.Text = "收款人：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(576, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 17;
            this.label6.Text = "复核员：";
            // 
            // txtCashier
            // 
            this.txtCashier.Location = new System.Drawing.Point(753, 11);
            this.txtCashier.Name = "txtCashier";
            this.txtCashier.Size = new System.Drawing.Size(67, 21);
            this.txtCashier.TabIndex = 16;
            // 
            // txtChecker
            // 
            this.txtChecker.Location = new System.Drawing.Point(626, 13);
            this.txtChecker.Name = "txtChecker";
            this.txtChecker.Size = new System.Drawing.Size(67, 21);
            this.txtChecker.TabIndex = 15;
            // 
            // chkShowPrint
            // 
            this.chkShowPrint.AutoSize = true;
            this.chkShowPrint.Location = new System.Drawing.Point(654, 45);
            this.chkShowPrint.Name = "chkShowPrint";
            this.chkShowPrint.Size = new System.Drawing.Size(120, 16);
            this.chkShowPrint.TabIndex = 14;
            this.chkShowPrint.Text = "是否显示打印选项";
            this.chkShowPrint.UseVisualStyleBackColor = true;
            // 
            // chkPrint
            // 
            this.chkPrint.AutoSize = true;
            this.chkPrint.Location = new System.Drawing.Point(576, 45);
            this.chkPrint.Name = "chkPrint";
            this.chkPrint.Size = new System.Drawing.Size(72, 16);
            this.chkPrint.TabIndex = 13;
            this.chkPrint.Text = "是否打印";
            this.chkPrint.UseVisualStyleBackColor = true;
            // 
            // btnBill
            // 
            this.btnBill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBill.Location = new System.Drawing.Point(865, 62);
            this.btnBill.Name = "btnBill";
            this.btnBill.Size = new System.Drawing.Size(75, 23);
            this.btnBill.TabIndex = 12;
            this.btnBill.Text = "开具发票";
            this.btnBill.UseVisualStyleBackColor = true;
            this.btnBill.Click += new System.EventHandler(this.btnBill_Click_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(247, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "发票类别：";
            // 
            // cbbInvType
            // 
            this.cbbInvType.FormattingEnabled = true;
            this.cbbInvType.Location = new System.Drawing.Point(309, 59);
            this.cbbInvType.Name = "cbbInvType";
            this.cbbInvType.Size = new System.Drawing.Size(81, 20);
            this.cbbInvType.TabIndex = 10;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "开票抬头";
            this.gridColumn6.FieldName = "TAXCUSTNAME";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 8;
            this.gridColumn6.Width = 146;
            // 
            // gColTaxNo
            // 
            this.gColTaxNo.Caption = "税号";
            this.gColTaxNo.FieldName = "TAXNO";
            this.gColTaxNo.Name = "gColTaxNo";
            this.gColTaxNo.Visible = true;
            this.gColTaxNo.VisibleIndex = 9;
            this.gColTaxNo.Width = 106;
            // 
            // gColAdress
            // 
            this.gColAdress.Caption = "地址";
            this.gColAdress.FieldName = "ADDRESS";
            this.gColAdress.Name = "gColAdress";
            this.gColAdress.Visible = true;
            this.gColAdress.VisibleIndex = 12;
            this.gColAdress.Width = 115;
            // 
            // gColContactPhone
            // 
            this.gColContactPhone.Caption = "电话";
            this.gColContactPhone.FieldName = "CONTACTPHONE";
            this.gColContactPhone.Name = "gColContactPhone";
            this.gColContactPhone.Visible = true;
            this.gColContactPhone.VisibleIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(394, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "结束日期：";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(462, 20);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(82, 21);
            this.dtpEndDate.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(243, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "开始日期：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "客户：";
            // 
            // gColAmount
            // 
            this.gColAmount.Caption = "金额";
            this.gColAmount.FieldName = "BSNAMOUNT";
            this.gColAmount.Name = "gColAmount";
            this.gColAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "BSNAMOUNT", "SUM={0:0.##}")});
            this.gColAmount.Visible = true;
            this.gColAmount.VisibleIndex = 7;
            // 
            // dtpBeginDate
            // 
            this.dtpBeginDate.Location = new System.Drawing.Point(308, 19);
            this.dtpBeginDate.Name = "dtpBeginDate";
            this.dtpBeginDate.Size = new System.Drawing.Size(82, 21);
            this.dtpBeginDate.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gridControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(944, 350);
            this.panel2.TabIndex = 4;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(944, 350);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gColDept,
            this.gColCustId,
            this.gColCustCode,
            this.gColCustName,
            this.gColInvTypeName,
            this.gColTaxRate,
            this.gColAmount,
            this.gridColumn6,
            this.gColTaxNo,
            this.gColBankName,
            this.gColBankAccount,
            this.gColAdress,
            this.gColContactPhone,
            this.gColNotes});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gColDept
            // 
            this.gColDept.Caption = "部门";
            this.gColDept.FieldName = "DEPTNAME";
            this.gColDept.Name = "gColDept";
            this.gColDept.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "DEPTNAME", "{0}")});
            this.gColDept.Visible = true;
            this.gColDept.VisibleIndex = 1;
            // 
            // gColCustId
            // 
            this.gColCustId.Caption = "客户代码";
            this.gColCustId.FieldName = "CUSTID";
            this.gColCustId.Name = "gColCustId";
            this.gColCustId.Visible = true;
            this.gColCustId.VisibleIndex = 2;
            // 
            // gColCustCode
            // 
            this.gColCustCode.Caption = "客户编码";
            this.gColCustCode.FieldName = "CUSTCODE";
            this.gColCustCode.Name = "gColCustCode";
            this.gColCustCode.Visible = true;
            this.gColCustCode.VisibleIndex = 3;
            // 
            // gColCustName
            // 
            this.gColCustName.Caption = "往来单位";
            this.gColCustName.FieldName = "CUSTNAME";
            this.gColCustName.Name = "gColCustName";
            this.gColCustName.Visible = true;
            this.gColCustName.VisibleIndex = 4;
            this.gColCustName.Width = 239;
            // 
            // gColInvTypeName
            // 
            this.gColInvTypeName.Caption = "发票类别";
            this.gColInvTypeName.FieldName = "INVTYPENAME";
            this.gColInvTypeName.Name = "gColInvTypeName";
            this.gColInvTypeName.Visible = true;
            this.gColInvTypeName.VisibleIndex = 5;
            // 
            // gColTaxRate
            // 
            this.gColTaxRate.Caption = "税率";
            this.gColTaxRate.FieldName = "TAXRATE";
            this.gColTaxRate.Name = "gColTaxRate";
            this.gColTaxRate.Visible = true;
            this.gColTaxRate.VisibleIndex = 6;
            // 
            // gColBankName
            // 
            this.gColBankName.Caption = "开户行";
            this.gColBankName.FieldName = "BANKNAME";
            this.gColBankName.Name = "gColBankName";
            this.gColBankName.Visible = true;
            this.gColBankName.VisibleIndex = 10;
            this.gColBankName.Width = 138;
            // 
            // gColBankAccount
            // 
            this.gColBankAccount.Caption = "帐号";
            this.gColBankAccount.FieldName = "BANKACCOUNT";
            this.gColBankAccount.Name = "gColBankAccount";
            this.gColBankAccount.Visible = true;
            this.gColBankAccount.VisibleIndex = 11;
            // 
            // gColNotes
            // 
            this.gColNotes.Caption = "备注";
            this.gColNotes.FieldName = "NOTES";
            this.gColNotes.Name = "gColNotes";
            this.gColNotes.Visible = true;
            this.gColNotes.VisibleIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "部门：";
            // 
            // txtCust
            // 
            this.txtCust.Location = new System.Drawing.Point(48, 20);
            this.txtCust.Name = "txtCust";
            this.txtCust.Size = new System.Drawing.Size(185, 21);
            this.txtCust.TabIndex = 1;
            this.txtCust.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCust_KeyPress);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkEnable);
            this.panel1.Controls.Add(this.cbbDept);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.cbbBillMode);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.upTimerLong);
            this.panel1.Controls.Add(this.chkAutoBill);
            this.panel1.Controls.Add(this.btnFilter);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtCashier);
            this.panel1.Controls.Add(this.txtChecker);
            this.panel1.Controls.Add(this.chkShowPrint);
            this.panel1.Controls.Add(this.chkPrint);
            this.panel1.Controls.Add(this.btnBill);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cbbInvType);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.dtpEndDate);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtpBeginDate);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtCust);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(944, 100);
            this.panel1.TabIndex = 3;
            // 
            // cbbDept
            // 
            this.cbbDept.FormattingEnabled = true;
            this.cbbDept.Location = new System.Drawing.Point(48, 54);
            this.cbbDept.Name = "cbbDept";
            this.cbbDept.Size = new System.Drawing.Size(185, 20);
            this.cbbDept.TabIndex = 25;
            this.cbbDept.SelectedIndexChanged += new System.EventHandler(this.cbbDept_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(396, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 24;
            this.label9.Text = "开票模式：";
            // 
            // cbbBillMode
            // 
            this.cbbBillMode.FormattingEnabled = true;
            this.cbbBillMode.Location = new System.Drawing.Point(464, 58);
            this.cbbBillMode.Name = "cbbBillMode";
            this.cbbBillMode.Size = new System.Drawing.Size(81, 20);
            this.cbbBillMode.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(662, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 12);
            this.label8.TabIndex = 22;
            this.label8.Text = "开票间隔(秒)：";
            // 
            // upTimerLong
            // 
            this.upTimerLong.Location = new System.Drawing.Point(759, 66);
            this.upTimerLong.Name = "upTimerLong";
            this.upTimerLong.Size = new System.Drawing.Size(56, 21);
            this.upTimerLong.TabIndex = 21;
            // 
            // chkAutoBill
            // 
            this.chkAutoBill.AutoSize = true;
            this.chkAutoBill.Location = new System.Drawing.Point(576, 71);
            this.chkAutoBill.Name = "chkAutoBill";
            this.chkAutoBill.Size = new System.Drawing.Size(72, 16);
            this.chkAutoBill.TabIndex = 20;
            this.chkAutoBill.Text = "自动开票";
            this.chkAutoBill.UseVisualStyleBackColor = true;
            this.chkAutoBill.CheckedChanged += new System.EventHandler(this.chkAutoBill_CheckedChanged);
            // 
            // btnFilter
            // 
            this.btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFilter.Location = new System.Drawing.Point(865, 11);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 23);
            this.btnFilter.TabIndex = 19;
            this.btnFilter.Text = "查询";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // chkEnable
            // 
            this.chkEnable.AutoSize = true;
            this.chkEnable.Location = new System.Drawing.Point(780, 45);
            this.chkEnable.Name = "chkEnable";
            this.chkEnable.Size = new System.Drawing.Size(84, 16);
            this.chkEnable.TabIndex = 29;
            this.chkEnable.Text = "不调用接口";
            this.chkEnable.UseVisualStyleBackColor = true;
            this.chkEnable.CheckedChanged += new System.EventHandler(this.chkEnable_CheckedChanged);
            // 
            // frmBillSumMonth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmBillSumMonth";
            this.Text = "增值税发票开票（按需合并开票）";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBillSum_FormClosing);
            this.Load += new System.EventHandler(this.frmBillSum_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upTimerLong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCashier;
        private System.Windows.Forms.TextBox txtChecker;
        private System.Windows.Forms.CheckBox chkShowPrint;
        private System.Windows.Forms.CheckBox chkPrint;
        private System.Windows.Forms.Button btnBill;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbbInvType;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gColTaxNo;
        private DevExpress.XtraGrid.Columns.GridColumn gColAdress;
        private DevExpress.XtraGrid.Columns.GridColumn gColContactPhone;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraGrid.Columns.GridColumn gColAmount;
        private System.Windows.Forms.DateTimePicker dtpBeginDate;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gColDept;
        private DevExpress.XtraGrid.Columns.GridColumn gColCustName;
        private DevExpress.XtraGrid.Columns.GridColumn gColNotes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCust;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown upTimerLong;
        private System.Windows.Forms.CheckBox chkAutoBill;
        private System.Windows.Forms.Button btnFilter;
        private DevExpress.XtraGrid.Columns.GridColumn gColBankName;
        private DevExpress.XtraGrid.Columns.GridColumn gColBankAccount;
        private DevExpress.XtraGrid.Columns.GridColumn gColCustCode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbbBillMode;
        private DevExpress.XtraGrid.Columns.GridColumn gColTaxRate;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraGrid.Columns.GridColumn gColCustId;
        private System.Windows.Forms.ComboBox cbbDept;
        private DevExpress.XtraGrid.Columns.GridColumn gColInvTypeName;
        private System.Windows.Forms.CheckBox chkEnable;
    }
}
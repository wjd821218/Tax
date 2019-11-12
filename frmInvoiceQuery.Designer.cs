namespace InvoiceBill
{
    partial class frmInvoiceQuery
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
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cbbInvType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.gColAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gColInvseqId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gColDept = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gColCustName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gColINVOICENO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gColNotes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gColCancel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gColDropper = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gColDropper1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDept = new System.Windows.Forms.TextBox();
            this.txtCust = new System.Windows.Forms.TextBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.chkShowCancle = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "审核日期";
            this.gridColumn7.FieldName = "INVDATE";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 12;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "开票员";
            this.gridColumn6.FieldName = "BILLER";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(580, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "发票类别：";
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "发票日期";
            this.gridColumn5.FieldName = "INVDATE";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 10;
            // 
            // cbbInvType
            // 
            this.cbbInvType.FormattingEnabled = true;
            this.cbbInvType.Location = new System.Drawing.Point(648, 51);
            this.cbbInvType.Name = "cbbInvType";
            this.cbbInvType.Size = new System.Drawing.Size(98, 20);
            this.cbbInvType.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(580, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "结束日期：";
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.Location = new System.Drawing.Point(648, 20);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(98, 21);
            this.dtpDateTo.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(368, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "开始日期：";
            // 
            // gColAmount
            // 
            this.gColAmount.Caption = "发票金额";
            this.gColAmount.FieldName = "AMOUNT";
            this.gColAmount.Name = "gColAmount";
            this.gColAmount.Visible = true;
            this.gColAmount.VisibleIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "客户：";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gridControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(999, 350);
            this.panel2.TabIndex = 4;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(999, 350);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gColInvseqId,
            this.gColDept,
            this.gColCustName,
            this.gColINVOICENO,
            this.gridColumn3,
            this.gridColumn4,
            this.gColAmount,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gColNotes,
            this.gColCancel,
            this.gColDropper,
            this.gColDropper1,
            this.gridColumn1,
            this.gridColumn2});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gColInvseqId
            // 
            this.gColInvseqId.Caption = "发票流水";
            this.gColInvseqId.FieldName = "INVSEQID";
            this.gColInvseqId.Name = "gColInvseqId";
            this.gColInvseqId.Visible = true;
            this.gColInvseqId.VisibleIndex = 1;
            // 
            // gColDept
            // 
            this.gColDept.Caption = "部门";
            this.gColDept.FieldName = "DEPTNAME";
            this.gColDept.Name = "gColDept";
            this.gColDept.Visible = true;
            this.gColDept.VisibleIndex = 2;
            // 
            // gColCustName
            // 
            this.gColCustName.Caption = "往来单位";
            this.gColCustName.FieldName = "CUSTNAME";
            this.gColCustName.Name = "gColCustName";
            this.gColCustName.Visible = true;
            this.gColCustName.VisibleIndex = 8;
            // 
            // gColINVOICENO
            // 
            this.gColINVOICENO.Caption = "发票号码";
            this.gColINVOICENO.FieldName = "INVOICENO";
            this.gColINVOICENO.Name = "gColINVOICENO";
            this.gColINVOICENO.Visible = true;
            this.gColINVOICENO.VisibleIndex = 5;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "发票代码";
            this.gridColumn3.FieldName = "INVOICECODE";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 6;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "发票种类";
            this.gridColumn4.FieldName = "INVTYPENAME";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 7;
            // 
            // gColNotes
            // 
            this.gColNotes.Caption = "备注";
            this.gColNotes.FieldName = "NOTES";
            this.gColNotes.Name = "gColNotes";
            this.gColNotes.Visible = true;
            this.gColNotes.VisibleIndex = 16;
            // 
            // gColCancel
            // 
            this.gColCancel.Caption = "状态";
            this.gColCancel.FieldName = "CANCELED";
            this.gColCancel.Name = "gColCancel";
            this.gColCancel.Visible = true;
            this.gColCancel.VisibleIndex = 13;
            // 
            // gColDropper
            // 
            this.gColDropper.Caption = "作废日期";
            this.gColDropper.FieldName = "DATEDROPPED";
            this.gColDropper.Name = "gColDropper";
            this.gColDropper.Visible = true;
            this.gColDropper.VisibleIndex = 14;
            // 
            // gColDropper1
            // 
            this.gColDropper1.Caption = "作废人";
            this.gColDropper1.FieldName = "USERNAME";
            this.gColDropper1.Name = "gColDropper1";
            this.gColDropper1.Visible = true;
            this.gColDropper1.VisibleIndex = 15;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "装车单号";
            this.gridColumn1.FieldName = "DSEQID";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 3;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "装车顺序";
            this.gridColumn2.FieldName = "SN";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 4;
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.Location = new System.Drawing.Point(436, 21);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(128, 21);
            this.dtpDateFrom.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "部门：";
            // 
            // txtDept
            // 
            this.txtDept.Location = new System.Drawing.Point(80, 56);
            this.txtDept.Name = "txtDept";
            this.txtDept.Size = new System.Drawing.Size(282, 21);
            this.txtDept.TabIndex = 2;
            // 
            // txtCust
            // 
            this.txtCust.Location = new System.Drawing.Point(80, 20);
            this.txtCust.Name = "txtCust";
            this.txtCust.Size = new System.Drawing.Size(282, 21);
            this.txtCust.TabIndex = 1;
            // 
            // btnQuery
            // 
            this.btnQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuery.Location = new System.Drawing.Point(912, 21);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 0;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.chkShowCancle);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtInvoiceNo);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cbbInvType);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.dtpDateTo);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtpDateFrom);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtDept);
            this.panel1.Controls.Add(this.txtCust);
            this.panel1.Controls.Add(this.btnQuery);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(999, 100);
            this.panel1.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(785, 21);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 23);
            this.button2.TabIndex = 20;
            this.button2.Text = "仅作废航天发票";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(912, 57);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 16;
            this.btnExport.Text = "导出";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // chkShowCancle
            // 
            this.chkShowCancle.AutoSize = true;
            this.chkShowCancle.Location = new System.Drawing.Point(752, 55);
            this.chkShowCancle.Name = "chkShowCancle";
            this.chkShowCancle.Size = new System.Drawing.Size(108, 16);
            this.chkShowCancle.TabIndex = 15;
            this.chkShowCancle.Text = "显示已作废发票";
            this.chkShowCancle.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(370, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "发票号码：";
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.Location = new System.Drawing.Point(436, 53);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(128, 21);
            this.txtInvoiceNo.TabIndex = 13;
            // 
            // frmInvoiceQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmInvoiceQuery";
            this.Text = "已开发票管理";
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private System.Windows.Forms.ComboBox cbbInvType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraGrid.Columns.GridColumn gColAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gColDept;
        private DevExpress.XtraGrid.Columns.GridColumn gColCustName;
        private DevExpress.XtraGrid.Columns.GridColumn gColNotes;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDept;
        private System.Windows.Forms.TextBox txtCust;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private DevExpress.XtraGrid.Columns.GridColumn gColInvseqId;
        private DevExpress.XtraGrid.Columns.GridColumn gColINVOICENO;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private System.Windows.Forms.CheckBox chkShowCancle;
        private DevExpress.XtraGrid.Columns.GridColumn gColCancel;
        private DevExpress.XtraGrid.Columns.GridColumn gColDropper;
        private DevExpress.XtraGrid.Columns.GridColumn gColDropper1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button button2;
    }
}
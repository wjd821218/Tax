﻿namespace InvoiceBill
{
    partial class frmInvoiceManager
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
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.cbbBillMode = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCashier = new System.Windows.Forms.TextBox();
            this.txtChecker = new System.Windows.Forms.TextBox();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chkShowPrint = new System.Windows.Forms.CheckBox();
            this.chkPrint = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gColBseqId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cbbInvType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.gColAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gColDept = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gColCustName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gColNotes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dtpBeginDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDept = new System.Windows.Forms.TextBox();
            this.txtCust = new System.Windows.Forms.TextBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "地址";
            this.gridColumn8.FieldName = "BANKNAME";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 10;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "开户行";
            this.gridColumn2.FieldName = "BANKNAME";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(580, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 20;
            this.label8.Text = "开票模式：";
            // 
            // cbbBillMode
            // 
            this.cbbBillMode.FormattingEnabled = true;
            this.cbbBillMode.Location = new System.Drawing.Point(648, 57);
            this.cbbBillMode.Name = "cbbBillMode";
            this.cbbBillMode.Size = new System.Drawing.Size(121, 20);
            this.cbbBillMode.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(912, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 18;
            this.label7.Text = "收款人：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(786, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 17;
            this.label6.Text = "复核员：";
            // 
            // txtCashier
            // 
            this.txtCashier.Location = new System.Drawing.Point(963, 21);
            this.txtCashier.Name = "txtCashier";
            this.txtCashier.Size = new System.Drawing.Size(67, 21);
            this.txtCashier.TabIndex = 16;
            // 
            // txtChecker
            // 
            this.txtChecker.Location = new System.Drawing.Point(836, 23);
            this.txtChecker.Name = "txtChecker";
            this.txtChecker.Size = new System.Drawing.Size(67, 21);
            this.txtChecker.TabIndex = 15;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "税号";
            this.gridColumn7.FieldName = "BSEQID";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 9;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "开票抬头";
            this.gridColumn6.FieldName = "CUSTNAME";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 6;
            // 
            // chkShowPrint
            // 
            this.chkShowPrint.AutoSize = true;
            this.chkShowPrint.Location = new System.Drawing.Point(868, 56);
            this.chkShowPrint.Name = "chkShowPrint";
            this.chkShowPrint.Size = new System.Drawing.Size(120, 16);
            this.chkShowPrint.TabIndex = 14;
            this.chkShowPrint.Text = "是否显示打印选项";
            this.chkShowPrint.UseVisualStyleBackColor = true;
            // 
            // chkPrint
            // 
            this.chkPrint.AutoSize = true;
            this.chkPrint.Location = new System.Drawing.Point(786, 57);
            this.chkPrint.Name = "chkPrint";
            this.chkPrint.Size = new System.Drawing.Size(72, 16);
            this.chkPrint.TabIndex = 13;
            this.chkPrint.Text = "是否打印";
            this.chkPrint.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(365, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "发票类别：";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "银行账号";
            this.gridColumn1.FieldName = "BANKACCOUNT";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 8;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "捡配时间";
            this.gridColumn5.FieldName = "EndDate";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(1046, 59);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "作废发票";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // gColBseqId
            // 
            this.gColBseqId.Caption = "票据流水";
            this.gColBseqId.FieldName = "BSEQID";
            this.gColBseqId.Name = "gColBseqId";
            this.gColBseqId.Visible = true;
            this.gColBseqId.VisibleIndex = 3;
            // 
            // cbbInvType
            // 
            this.cbbInvType.FormattingEnabled = true;
            this.cbbInvType.Location = new System.Drawing.Point(433, 57);
            this.cbbInvType.Name = "cbbInvType";
            this.cbbInvType.Size = new System.Drawing.Size(121, 20);
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
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(648, 20);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(128, 21);
            this.dtpEndDate.TabIndex = 8;
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
            this.gColAmount.Caption = "金额";
            this.gColAmount.FieldName = "AMOUNT";
            this.gColAmount.Name = "gColAmount";
            this.gColAmount.Visible = true;
            this.gColAmount.VisibleIndex = 4;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "电话";
            this.gridColumn9.FieldName = "CONTACTPHONE";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 12;
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
            this.panel2.Size = new System.Drawing.Size(1153, 350);
            this.panel2.TabIndex = 4;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1153, 350);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gColDept,
            this.gColCustName,
            this.gColBseqId,
            this.gColAmount,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn2,
            this.gridColumn1,
            this.gridColumn8,
            this.gridColumn9,
            this.gColNotes});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gColDept
            // 
            this.gColDept.Caption = "部门";
            this.gColDept.Name = "gColDept";
            this.gColDept.Visible = true;
            this.gColDept.VisibleIndex = 1;
            // 
            // gColCustName
            // 
            this.gColCustName.Caption = "往来单位";
            this.gColCustName.FieldName = "CUSTNAME";
            this.gColCustName.Name = "gColCustName";
            this.gColCustName.Visible = true;
            this.gColCustName.VisibleIndex = 2;
            // 
            // gColNotes
            // 
            this.gColNotes.Caption = "备注";
            this.gColNotes.FieldName = "NOTES";
            this.gColNotes.Name = "gColNotes";
            this.gColNotes.Visible = true;
            this.gColNotes.VisibleIndex = 11;
            // 
            // dtpBeginDate
            // 
            this.dtpBeginDate.Location = new System.Drawing.Point(433, 21);
            this.dtpBeginDate.Name = "dtpBeginDate";
            this.dtpBeginDate.Size = new System.Drawing.Size(128, 21);
            this.dtpBeginDate.TabIndex = 4;
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
            this.btnQuery.Location = new System.Drawing.Point(1044, 20);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 0;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.cbbBillMode);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtCashier);
            this.panel1.Controls.Add(this.txtChecker);
            this.panel1.Controls.Add(this.chkShowPrint);
            this.panel1.Controls.Add(this.chkPrint);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cbbInvType);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.dtpEndDate);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtpBeginDate);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtDept);
            this.panel1.Controls.Add(this.txtCust);
            this.panel1.Controls.Add(this.btnQuery);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1153, 100);
            this.panel1.TabIndex = 3;
            // 
            // frmInvoiceManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1153, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmInvoiceManager";
            this.Text = "已开发票管理";
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbbBillMode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCashier;
        private System.Windows.Forms.TextBox txtChecker;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private System.Windows.Forms.CheckBox chkShowPrint;
        private System.Windows.Forms.CheckBox chkPrint;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private System.Windows.Forms.Button btnCancel;
        private DevExpress.XtraGrid.Columns.GridColumn gColBseqId;
        private System.Windows.Forms.ComboBox cbbInvType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraGrid.Columns.GridColumn gColAmount;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gColDept;
        private DevExpress.XtraGrid.Columns.GridColumn gColCustName;
        private DevExpress.XtraGrid.Columns.GridColumn gColNotes;
        private System.Windows.Forms.DateTimePicker dtpBeginDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDept;
        private System.Windows.Forms.TextBox txtCust;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Panel panel1;
    }
}
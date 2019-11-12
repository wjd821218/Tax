namespace InvoiceBill.Basic
{
    partial class frmTaxArt
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
            this.txtFactory = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSpec = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chkAll = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.ds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.CentrePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(0, 87);
            this.gridControl1.Size = new System.Drawing.Size(800, 363);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn6,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(701, 16);
            this.btnFilter.Size = new System.Drawing.Size(75, 34);
            // 
            // CentrePanel
            // 
            this.CentrePanel.Controls.Add(this.chkAll);
            this.CentrePanel.Controls.Add(this.txtFactory);
            this.CentrePanel.Controls.Add(this.label2);
            this.CentrePanel.Controls.Add(this.txtSpec);
            this.CentrePanel.Controls.Add(this.label1);
            this.CentrePanel.Controls.Add(this.txtName);
            this.CentrePanel.Controls.Add(this.lblName);
            this.CentrePanel.Size = new System.Drawing.Size(800, 62);
            this.CentrePanel.Controls.SetChildIndex(this.btnFilter, 0);
            this.CentrePanel.Controls.SetChildIndex(this.lblName, 0);
            this.CentrePanel.Controls.SetChildIndex(this.txtName, 0);
            this.CentrePanel.Controls.SetChildIndex(this.label1, 0);
            this.CentrePanel.Controls.SetChildIndex(this.txtSpec, 0);
            this.CentrePanel.Controls.SetChildIndex(this.label2, 0);
            this.CentrePanel.Controls.SetChildIndex(this.txtFactory, 0);
            this.CentrePanel.Controls.SetChildIndex(this.chkAll, 0);
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(800, 25);
            // 
            // txtFactory
            // 
            this.txtFactory.Location = new System.Drawing.Point(401, 16);
            this.txtFactory.Name = "txtFactory";
            this.txtFactory.Size = new System.Drawing.Size(143, 21);
            this.txtFactory.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(366, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "产地";
            // 
            // txtSpec
            // 
            this.txtSpec.Location = new System.Drawing.Point(233, 16);
            this.txtSpec.Name = "txtSpec";
            this.txtSpec.Size = new System.Drawing.Size(100, 21);
            this.txtSpec.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(203, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "规格";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(56, 16);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(135, 21);
            this.txtName.TabIndex = 7;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(22, 22);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 12);
            this.lblName.TabIndex = 6;
            this.lblName.Text = "名称:";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "编码";
            this.gridColumn1.FieldName = "ARTID";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "名称";
            this.gridColumn2.FieldName = "NAME";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "规格";
            this.gridColumn3.FieldName = "SPEC";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "产地";
            this.gridColumn4.FieldName = "FACTORY";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "分类编码";
            this.gridColumn5.FieldName = "TAXCODE";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "内码";
            this.gridColumn6.FieldName = "ARTCODE";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 2;
            // 
            // chkAll
            // 
            this.chkAll.Location = new System.Drawing.Point(566, 18);
            this.chkAll.Name = "chkAll";
            this.chkAll.Properties.Caption = "查看所有品种";
            this.chkAll.Size = new System.Drawing.Size(106, 19);
            this.chkAll.TabIndex = 12;
            // 
            // frmTaxArt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "frmTaxArt";
            this.Text = "税收分类编码维护";
            ((System.ComponentModel.ISupportInitialize)(this.ds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.CentrePanel.ResumeLayout(false);
            this.CentrePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFactory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSpec;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.CheckEdit chkAll;
    }
}
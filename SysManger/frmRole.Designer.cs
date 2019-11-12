namespace InvoiceBill.SysManger
{
    partial class frmRole
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gColUserId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gColUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gColSate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gColCreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnDel = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnFresh = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 25);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(521, 263);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.White;
            this.gridView1.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView1.Appearance.OddRow.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.gridView1.Appearance.OddRow.Options.UseBackColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gColUserId,
            this.gColUserName,
            this.gColSate,
            this.gColCreateDate});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // gColUserId
            // 
            this.gColUserId.Caption = "ID";
            this.gColUserId.FieldName = "ROLEID";
            this.gColUserId.Name = "gColUserId";
            this.gColUserId.OptionsColumn.AllowEdit = false;
            this.gColUserId.OptionsColumn.AllowFocus = false;
            this.gColUserId.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "DEPTNAME", "{0}")});
            this.gColUserId.Visible = true;
            this.gColUserId.VisibleIndex = 0;
            // 
            // gColUserName
            // 
            this.gColUserName.Caption = "角色名称";
            this.gColUserName.FieldName = "ROLENAME";
            this.gColUserName.Name = "gColUserName";
            this.gColUserName.OptionsColumn.AllowEdit = false;
            this.gColUserName.OptionsColumn.AllowFocus = false;
            this.gColUserName.Visible = true;
            this.gColUserName.VisibleIndex = 1;
            // 
            // gColSate
            // 
            this.gColSate.Caption = "状态";
            this.gColSate.FieldName = "STATE";
            this.gColSate.Name = "gColSate";
            this.gColSate.OptionsColumn.AllowEdit = false;
            this.gColSate.OptionsColumn.AllowFocus = false;
            this.gColSate.Visible = true;
            this.gColSate.VisibleIndex = 2;
            // 
            // gColCreateDate
            // 
            this.gColCreateDate.Caption = "创建日期";
            this.gColCreateDate.FieldName = "CREATEDATE";
            this.gColCreateDate.Name = "gColCreateDate";
            this.gColCreateDate.OptionsColumn.AllowEdit = false;
            this.gColCreateDate.OptionsColumn.AllowFocus = false;
            this.gColCreateDate.Visible = true;
            this.gColCreateDate.VisibleIndex = 3;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.btnDel,
            this.btnEdit,
            this.btnFresh});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(521, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::InvoiceBill.Properties.Resources.add_32x32;
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(52, 22);
            this.btnAdd.Text = "增加";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDel
            // 
            this.btnDel.Image = global::InvoiceBill.Properties.Resources.close_32x32;
            this.btnDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(52, 22);
            this.btnDel.Text = "删除";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Image = global::InvoiceBill.Properties.Resources.editname_32x32;
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(52, 22);
            this.btnEdit.Text = "修改";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnFresh
            // 
            this.btnFresh.Image = global::InvoiceBill.Properties.Resources.convert_32x32;
            this.btnFresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFresh.Name = "btnFresh";
            this.btnFresh.Size = new System.Drawing.Size(52, 22);
            this.btnFresh.Text = "刷新";
            this.btnFresh.Click += new System.EventHandler(this.btnFresh_Click);
            // 
            // frmRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 288);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmRole";
            this.Text = "角色管理";
            this.Load += new System.EventHandler(this.frmRole_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gColUserId;
        private DevExpress.XtraGrid.Columns.GridColumn gColUserName;
        private DevExpress.XtraGrid.Columns.GridColumn gColSate;
        private DevExpress.XtraGrid.Columns.GridColumn gColCreateDate;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnDel;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnFresh;
    }
}
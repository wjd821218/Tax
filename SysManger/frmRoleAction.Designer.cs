namespace InvoiceBill.SysManger
{
    partial class frmRoleAction
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
            this.btnCanceled = new DevExpress.XtraEditors.SimpleButton();
            this.btnSure = new DevExpress.XtraEditors.SimpleButton();
            this.tlRole = new DevExpress.XtraTreeList.TreeList();
            this.txtRoleName = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tlRole)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRoleName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCanceled
            // 
            this.btnCanceled.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCanceled.Location = new System.Drawing.Point(180, 275);
            this.btnCanceled.Name = "btnCanceled";
            this.btnCanceled.Size = new System.Drawing.Size(75, 23);
            this.btnCanceled.TabIndex = 16;
            this.btnCanceled.Text = "取消";
            this.btnCanceled.Click += new System.EventHandler(this.btnCanceled_Click);
            // 
            // btnSure
            // 
            this.btnSure.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSure.Location = new System.Drawing.Point(51, 275);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(75, 23);
            this.btnSure.TabIndex = 15;
            this.btnSure.Text = "确定";
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // tlRole
            // 
            this.tlRole.KeyFieldName = "ActionNo";
            this.tlRole.Location = new System.Drawing.Point(12, 58);
            this.tlRole.Name = "tlRole";
            this.tlRole.OptionsView.ShowCheckBoxes = true;
            this.tlRole.ParentFieldName = "ParentId";
            this.tlRole.PreviewFieldName = "ActionName";
            this.tlRole.Size = new System.Drawing.Size(336, 200);
            this.tlRole.TabIndex = 18;
            // 
            // txtRoleName
            // 
            this.txtRoleName.Location = new System.Drawing.Point(81, 22);
            this.txtRoleName.Name = "txtRoleName";
            this.txtRoleName.Size = new System.Drawing.Size(267, 20);
            this.txtRoleName.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 14);
            this.label1.TabIndex = 20;
            this.label1.Text = "角色名称";
            // 
            // frmRoleAction
            // 
            this.AcceptButton = this.btnSure;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCanceled;
            this.ClientSize = new System.Drawing.Size(363, 321);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRoleName);
            this.Controls.Add(this.tlRole);
            this.Controls.Add(this.btnCanceled);
            this.Controls.Add(this.btnSure);
            this.Name = "frmRoleAction";
            this.Text = "角色信息";
            ((System.ComponentModel.ISupportInitialize)(this.tlRole)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRoleName.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCanceled;
        public DevExpress.XtraTreeList.TreeList tlRole;
        private System.Windows.Forms.Label label1;
        public DevExpress.XtraEditors.TextEdit txtRoleName;
        public DevExpress.XtraEditors.SimpleButton btnSure;
    }
}
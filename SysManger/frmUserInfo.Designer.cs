namespace InvoiceBill.SysManger
{
    partial class frmUserInfo
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
            this.btnSure = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.txtId = new DevExpress.XtraEditors.TextEdit();
            this.txtNo = new DevExpress.XtraEditors.TextEdit();
            this.txtUserName = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPassWordPre = new DevExpress.XtraEditors.TextEdit();
            this.txtPassWord = new DevExpress.XtraEditors.TextEdit();
            this.chkListDept = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.chkListRole = new DevExpress.XtraEditors.CheckedListBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassWordPre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassWord.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkListDept)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkListRole)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSure
            // 
            this.btnSure.Location = new System.Drawing.Point(55, 358);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(75, 23);
            this.btnSure.TabIndex = 0;
            this.btnSure.Text = "确定";
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(183, 358);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "取消";
            this.btnClose.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(55, 12);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(100, 20);
            this.txtId.TabIndex = 2;
            // 
            // txtNo
            // 
            this.txtNo.Location = new System.Drawing.Point(55, 48);
            this.txtNo.Name = "txtNo";
            this.txtNo.Size = new System.Drawing.Size(100, 20);
            this.txtNo.TabIndex = 3;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(248, 48);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(100, 20);
            this.txtUserName.TabIndex = 4;
            this.txtUserName.EditValueChanged += new System.EventHandler(this.textEdit3_EditValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "账号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(204, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 14);
            this.label3.TabIndex = 7;
            this.label3.Text = "姓名";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(180, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 14);
            this.label4.TabIndex = 11;
            this.label4.Text = "确认口令";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 14);
            this.label5.TabIndex = 10;
            this.label5.Text = "口令";
            // 
            // txtPassWordPre
            // 
            this.txtPassWordPre.Location = new System.Drawing.Point(248, 74);
            this.txtPassWordPre.Name = "txtPassWordPre";
            this.txtPassWordPre.Size = new System.Drawing.Size(100, 20);
            this.txtPassWordPre.TabIndex = 9;
            // 
            // txtPassWord
            // 
            this.txtPassWord.Location = new System.Drawing.Point(55, 74);
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.Size = new System.Drawing.Size(100, 20);
            this.txtPassWord.TabIndex = 8;
            // 
            // chkListDept
            // 
            this.chkListDept.Location = new System.Drawing.Point(15, 127);
            this.chkListDept.Name = "chkListDept";
            this.chkListDept.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.chkListDept.Size = new System.Drawing.Size(333, 95);
            this.chkListDept.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 14);
            this.label6.TabIndex = 13;
            this.label6.Text = "可用部门";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 225);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 14);
            this.label7.TabIndex = 15;
            this.label7.Text = "角色";
            // 
            // chkListRole
            // 
            this.chkListRole.Location = new System.Drawing.Point(15, 246);
            this.chkListRole.Name = "chkListRole";
            this.chkListRole.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.chkListRole.Size = new System.Drawing.Size(333, 95);
            this.chkListRole.TabIndex = 14;
            // 
            // frmUserInfo
            // 
            this.AcceptButton = this.btnSure;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(360, 393);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.chkListRole);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chkListDept);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPassWordPre);
            this.Controls.Add(this.txtPassWord);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.txtNo);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSure);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmUserInfo";
            this.Text = "用户信息";
            ((System.ComponentModel.ISupportInitialize)(this.txtId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassWordPre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassWord.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkListDept)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkListRole)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnSure;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        public DevExpress.XtraEditors.TextEdit txtId;
        public DevExpress.XtraEditors.TextEdit txtNo;
        public DevExpress.XtraEditors.TextEdit txtUserName;
        public DevExpress.XtraEditors.TextEdit txtPassWordPre;
        public DevExpress.XtraEditors.TextEdit txtPassWord;
        public DevExpress.XtraEditors.CheckedListBoxControl chkListDept;
        public DevExpress.XtraEditors.CheckedListBoxControl chkListRole;
    }
}
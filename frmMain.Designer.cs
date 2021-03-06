﻿namespace InvoiceBill
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.meuInvoiceBill = new System.Windows.Forms.ToolStripMenuItem();
            this.按单快速开票ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.按客户汇总开票ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.按月汇总开票ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.销售发票开票ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.meuInovie = new System.Windows.Forms.ToolStripMenuItem();
            this.按原单红字发票ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.普通发票红字开票ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.普通发票填开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.填制手工发票ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.特殊红字开票ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuInvoiceManager = new System.Windows.Forms.ToolStripMenuItem();
            this.发票作废ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.发票查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开票申请ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuInvoicePrint = new System.Windows.Forms.ToolStripMenuItem();
            this.远程打印ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.税收分类编码维护ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开票资料维护ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.系统设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.用户管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.角色管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblOpenTime = new System.Windows.Forms.Label();
            this.lblTaxNumber = new System.Windows.Forms.Label();
            this.lblSpecial = new System.Windows.Forms.Label();
            this.lblCom = new System.Windows.Forms.Label();
            this.lblLimit = new System.Windows.Forms.Label();
            this.lblTaxNo = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tColMain = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.cbbSkin = new DevExpress.XtraEditors.ComboBoxEdit();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tColMain)).BeginInit();
            this.tColMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbbSkin.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.meuInvoiceBill,
            this.menuInvoiceManager,
            this.menuInvoicePrint,
            this.menuConfig,
            this.系统设置ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(952, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // meuInvoiceBill
            // 
            this.meuInvoiceBill.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.按单快速开票ToolStripMenuItem,
            this.按客户汇总开票ToolStripMenuItem,
            this.按月汇总开票ToolStripMenuItem,
            this.销售发票开票ToolStripMenuItem,
            this.toolStripSeparator1,
            this.meuInovie,
            this.按原单红字发票ToolStripMenuItem,
            this.普通发票红字开票ToolStripMenuItem,
            this.toolStripSeparator2,
            this.普通发票填开ToolStripMenuItem,
            this.填制手工发票ToolStripMenuItem,
            this.特殊红字开票ToolStripMenuItem});
            this.meuInvoiceBill.Name = "meuInvoiceBill";
            this.meuInvoiceBill.Size = new System.Drawing.Size(68, 21);
            this.meuInvoiceBill.Tag = "1";
            this.meuInvoiceBill.Text = "开具发票";
            this.meuInvoiceBill.Click += new System.EventHandler(this.meuInvoiceBill_Click);
            // 
            // 按单快速开票ToolStripMenuItem
            // 
            this.按单快速开票ToolStripMenuItem.Name = "按单快速开票ToolStripMenuItem";
            this.按单快速开票ToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.按单快速开票ToolStripMenuItem.Tag = "11";
            this.按单快速开票ToolStripMenuItem.Text = "按单快速开票";
            this.按单快速开票ToolStripMenuItem.Click += new System.EventHandler(this.按单快速开票ToolStripMenuItem_Click);
            // 
            // 按客户汇总开票ToolStripMenuItem
            // 
            this.按客户汇总开票ToolStripMenuItem.Name = "按客户汇总开票ToolStripMenuItem";
            this.按客户汇总开票ToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.按客户汇总开票ToolStripMenuItem.Tag = "12";
            this.按客户汇总开票ToolStripMenuItem.Text = "按客户汇总开票";
            this.按客户汇总开票ToolStripMenuItem.Click += new System.EventHandler(this.按客户汇总开票ToolStripMenuItem_Click);
            // 
            // 按月汇总开票ToolStripMenuItem
            // 
            this.按月汇总开票ToolStripMenuItem.Name = "按月汇总开票ToolStripMenuItem";
            this.按月汇总开票ToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.按月汇总开票ToolStripMenuItem.Tag = "111";
            this.按月汇总开票ToolStripMenuItem.Text = "按月汇总开票";
            this.按月汇总开票ToolStripMenuItem.Click += new System.EventHandler(this.按月汇总开票ToolStripMenuItem_Click);
            // 
            // 销售发票开票ToolStripMenuItem
            // 
            this.销售发票开票ToolStripMenuItem.Name = "销售发票开票ToolStripMenuItem";
            this.销售发票开票ToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.销售发票开票ToolStripMenuItem.Tag = "13";
            this.销售发票开票ToolStripMenuItem.Text = "销售发票开票";
            this.销售发票开票ToolStripMenuItem.Click += new System.EventHandler(this.销售发票开票ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(229, 6);
            this.toolStripSeparator1.Tag = "14";
            // 
            // meuInovie
            // 
            this.meuInovie.Name = "meuInovie";
            this.meuInovie.Size = new System.Drawing.Size(232, 22);
            this.meuInovie.Tag = "15";
            this.meuInovie.Text = "普通发票红字发票开票";
            this.meuInovie.Click += new System.EventHandler(this.meuInovie_Click);
            // 
            // 按原单红字发票ToolStripMenuItem
            // 
            this.按原单红字发票ToolStripMenuItem.Name = "按原单红字发票ToolStripMenuItem";
            this.按原单红字发票ToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.按原单红字发票ToolStripMenuItem.Tag = "112";
            this.按原单红字发票ToolStripMenuItem.Text = "按原单红字发票";
            this.按原单红字发票ToolStripMenuItem.Click += new System.EventHandler(this.按原单红字发票ToolStripMenuItem_Click);
            // 
            // 普通发票红字开票ToolStripMenuItem
            // 
            this.普通发票红字开票ToolStripMenuItem.Name = "普通发票红字开票ToolStripMenuItem";
            this.普通发票红字开票ToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.普通发票红字开票ToolStripMenuItem.Tag = "16";
            this.普通发票红字开票ToolStripMenuItem.Text = "发票红字开票（处理未作废）";
            this.普通发票红字开票ToolStripMenuItem.Click += new System.EventHandler(this.普通发票红字开票ToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(229, 6);
            this.toolStripSeparator2.Tag = "17";
            // 
            // 普通发票填开ToolStripMenuItem
            // 
            this.普通发票填开ToolStripMenuItem.Name = "普通发票填开ToolStripMenuItem";
            this.普通发票填开ToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.普通发票填开ToolStripMenuItem.Tag = "18";
            this.普通发票填开ToolStripMenuItem.Text = "普通发票填开";
            this.普通发票填开ToolStripMenuItem.Click += new System.EventHandler(this.普通发票填开ToolStripMenuItem_Click);
            // 
            // 填制手工发票ToolStripMenuItem
            // 
            this.填制手工发票ToolStripMenuItem.Name = "填制手工发票ToolStripMenuItem";
            this.填制手工发票ToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.填制手工发票ToolStripMenuItem.Tag = "19";
            this.填制手工发票ToolStripMenuItem.Text = "专用发票填开";
            // 
            // 特殊红字开票ToolStripMenuItem
            // 
            this.特殊红字开票ToolStripMenuItem.Name = "特殊红字开票ToolStripMenuItem";
            this.特殊红字开票ToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.特殊红字开票ToolStripMenuItem.Tag = "110";
            this.特殊红字开票ToolStripMenuItem.Text = "特殊红字开票";
            this.特殊红字开票ToolStripMenuItem.Click += new System.EventHandler(this.特殊红字开票ToolStripMenuItem_Click);
            // 
            // menuInvoiceManager
            // 
            this.menuInvoiceManager.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.发票作废ToolStripMenuItem,
            this.发票查询ToolStripMenuItem,
            this.开票申请ToolStripMenuItem});
            this.menuInvoiceManager.Name = "menuInvoiceManager";
            this.menuInvoiceManager.Size = new System.Drawing.Size(68, 21);
            this.menuInvoiceManager.Tag = "2";
            this.menuInvoiceManager.Text = "发票管理";
            this.menuInvoiceManager.Click += new System.EventHandler(this.menuInvoiceManager_Click);
            // 
            // 发票作废ToolStripMenuItem
            // 
            this.发票作废ToolStripMenuItem.Name = "发票作废ToolStripMenuItem";
            this.发票作废ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.发票作废ToolStripMenuItem.Tag = "21";
            this.发票作废ToolStripMenuItem.Text = "发票管理";
            this.发票作废ToolStripMenuItem.Click += new System.EventHandler(this.发票作废ToolStripMenuItem_Click);
            // 
            // 发票查询ToolStripMenuItem
            // 
            this.发票查询ToolStripMenuItem.Name = "发票查询ToolStripMenuItem";
            this.发票查询ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.发票查询ToolStripMenuItem.Tag = "22";
            this.发票查询ToolStripMenuItem.Text = "发票查询";
            this.发票查询ToolStripMenuItem.Click += new System.EventHandler(this.发票查询ToolStripMenuItem_Click);
            // 
            // 开票申请ToolStripMenuItem
            // 
            this.开票申请ToolStripMenuItem.Name = "开票申请ToolStripMenuItem";
            this.开票申请ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.开票申请ToolStripMenuItem.Tag = "23";
            this.开票申请ToolStripMenuItem.Text = "未开发票查询";
            this.开票申请ToolStripMenuItem.Click += new System.EventHandler(this.开票申请ToolStripMenuItem_Click);
            // 
            // menuInvoicePrint
            // 
            this.menuInvoicePrint.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.远程打印ToolStripMenuItem});
            this.menuInvoicePrint.Name = "menuInvoicePrint";
            this.menuInvoicePrint.Size = new System.Drawing.Size(68, 21);
            this.menuInvoicePrint.Tag = "3";
            this.menuInvoicePrint.Text = "发票打印";
            this.menuInvoicePrint.Click += new System.EventHandler(this.menuInvoicePrint_Click);
            // 
            // 远程打印ToolStripMenuItem
            // 
            this.远程打印ToolStripMenuItem.Name = "远程打印ToolStripMenuItem";
            this.远程打印ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.远程打印ToolStripMenuItem.Tag = "31";
            this.远程打印ToolStripMenuItem.Text = "远程打印";
            this.远程打印ToolStripMenuItem.Click += new System.EventHandler(this.远程打印ToolStripMenuItem_Click);
            // 
            // menuConfig
            // 
            this.menuConfig.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.税收分类编码维护ToolStripMenuItem,
            this.开票资料维护ToolStripMenuItem});
            this.menuConfig.Name = "menuConfig";
            this.menuConfig.Size = new System.Drawing.Size(68, 21);
            this.menuConfig.Tag = "4";
            this.menuConfig.Text = "开票设置";
            // 
            // 税收分类编码维护ToolStripMenuItem
            // 
            this.税收分类编码维护ToolStripMenuItem.Name = "税收分类编码维护ToolStripMenuItem";
            this.税收分类编码维护ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.税收分类编码维护ToolStripMenuItem.Tag = "41";
            this.税收分类编码维护ToolStripMenuItem.Text = "税收分类编码维护";
            this.税收分类编码维护ToolStripMenuItem.Click += new System.EventHandler(this.税收分类编码维护ToolStripMenuItem_Click);
            // 
            // 开票资料维护ToolStripMenuItem
            // 
            this.开票资料维护ToolStripMenuItem.Name = "开票资料维护ToolStripMenuItem";
            this.开票资料维护ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.开票资料维护ToolStripMenuItem.Tag = "42";
            this.开票资料维护ToolStripMenuItem.Text = "开票资料维护";
            this.开票资料维护ToolStripMenuItem.Click += new System.EventHandler(this.开票资料维护ToolStripMenuItem_Click);
            // 
            // 系统设置ToolStripMenuItem
            // 
            this.系统设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.用户管理ToolStripMenuItem,
            this.角色管理ToolStripMenuItem});
            this.系统设置ToolStripMenuItem.Name = "系统设置ToolStripMenuItem";
            this.系统设置ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.系统设置ToolStripMenuItem.Tag = "5";
            this.系统设置ToolStripMenuItem.Text = "系统设置";
            // 
            // 用户管理ToolStripMenuItem
            // 
            this.用户管理ToolStripMenuItem.Name = "用户管理ToolStripMenuItem";
            this.用户管理ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.用户管理ToolStripMenuItem.Tag = "51";
            this.用户管理ToolStripMenuItem.Text = "用户管理";
            this.用户管理ToolStripMenuItem.Click += new System.EventHandler(this.用户管理ToolStripMenuItem_Click);
            // 
            // 角色管理ToolStripMenuItem
            // 
            this.角色管理ToolStripMenuItem.Name = "角色管理ToolStripMenuItem";
            this.角色管理ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.角色管理ToolStripMenuItem.Tag = "52";
            this.角色管理ToolStripMenuItem.Text = "角色管理";
            this.角色管理ToolStripMenuItem.Click += new System.EventHandler(this.角色管理ToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblOpenTime);
            this.panel1.Controls.Add(this.lblTaxNumber);
            this.panel1.Controls.Add(this.lblSpecial);
            this.panel1.Controls.Add(this.lblCom);
            this.panel1.Controls.Add(this.lblLimit);
            this.panel1.Controls.Add(this.lblTaxNo);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnOpen);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(952, 56);
            this.panel1.TabIndex = 2;
            // 
            // lblOpenTime
            // 
            this.lblOpenTime.AutoSize = true;
            this.lblOpenTime.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblOpenTime.Location = new System.Drawing.Point(352, 13);
            this.lblOpenTime.Name = "lblOpenTime";
            this.lblOpenTime.Size = new System.Drawing.Size(89, 12);
            this.lblOpenTime.TabIndex = 8;
            this.lblOpenTime.Text = "本次开卡时间：";
            // 
            // lblTaxNumber
            // 
            this.lblTaxNumber.AutoSize = true;
            this.lblTaxNumber.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblTaxNumber.Location = new System.Drawing.Point(238, 13);
            this.lblTaxNumber.Name = "lblTaxNumber";
            this.lblTaxNumber.Size = new System.Drawing.Size(77, 12);
            this.lblTaxNumber.TabIndex = 6;
            this.lblTaxNumber.Text = "开票机号码：";
            // 
            // lblSpecial
            // 
            this.lblSpecial.AutoSize = true;
            this.lblSpecial.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblSpecial.Location = new System.Drawing.Point(556, 34);
            this.lblSpecial.Name = "lblSpecial";
            this.lblSpecial.Size = new System.Drawing.Size(251, 12);
            this.lblSpecial.TabIndex = 5;
            this.lblSpecial.Text = "专票剩余份数0，将要开具的发票号码为 00000";
            // 
            // lblCom
            // 
            this.lblCom.AutoSize = true;
            this.lblCom.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblCom.Location = new System.Drawing.Point(556, 11);
            this.lblCom.Name = "lblCom";
            this.lblCom.Size = new System.Drawing.Size(251, 12);
            this.lblCom.TabIndex = 4;
            this.lblCom.Text = "普票剩余份数0，将要开具的发票号码为 00000";
            // 
            // lblLimit
            // 
            this.lblLimit.AutoSize = true;
            this.lblLimit.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblLimit.Location = new System.Drawing.Point(108, 34);
            this.lblLimit.Name = "lblLimit";
            this.lblLimit.Size = new System.Drawing.Size(401, 12);
            this.lblLimit.TabIndex = 3;
            this.lblLimit.Text = "开票限额：专票0，普票0，金税卡中有票可开，未到抄税期，未到锁死期。";
            // 
            // lblTaxNo
            // 
            this.lblTaxNo.AutoSize = true;
            this.lblTaxNo.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblTaxNo.Location = new System.Drawing.Point(108, 12);
            this.lblTaxNo.Name = "lblTaxNo";
            this.lblTaxNo.Size = new System.Drawing.Size(41, 12);
            this.lblTaxNo.TabIndex = 2;
            this.lblTaxNo.Text = "税号：";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(13, 29);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "关闭金税卡";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(13, 4);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "打开金税卡";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tColMain);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 81);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(952, 433);
            this.panel2.TabIndex = 3;
            // 
            // tColMain
            // 
            this.tColMain.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPageHeaders;
            this.tColMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tColMain.HeaderButtons = ((DevExpress.XtraTab.TabButtons)((DevExpress.XtraTab.TabButtons.Close | DevExpress.XtraTab.TabButtons.Default)));
            this.tColMain.Location = new System.Drawing.Point(0, 0);
            this.tColMain.Name = "tColMain";
            this.tColMain.SelectedTabPage = this.xtraTabPage1;
            this.tColMain.Size = new System.Drawing.Size(952, 433);
            this.tColMain.TabIndex = 1;
            this.tColMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
            this.tColMain.CloseButtonClick += new System.EventHandler(this.tColMain_CloseButtonClick);
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(946, 404);
            this.xtraTabPage1.Text = "导航";
            // 
            // cbbSkin
            // 
            this.cbbSkin.Location = new System.Drawing.Point(736, 3);
            this.cbbSkin.Name = "cbbSkin";
            this.cbbSkin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbbSkin.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.cbbSkin.Size = new System.Drawing.Size(100, 20);
            this.cbbSkin.TabIndex = 4;
            this.cbbSkin.SelectedIndexChanged += new System.EventHandler(this.cbbSkin_SelectedIndexChanged);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 514);
            this.Controls.Add(this.cbbSkin);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "增值税发票开票系统";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tColMain)).EndInit();
            this.tColMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbbSkin.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem meuInvoiceBill;
        private System.Windows.Forms.ToolStripMenuItem menuInvoiceManager;
        private System.Windows.Forms.ToolStripMenuItem menuInvoicePrint;
        private System.Windows.Forms.ToolStripMenuItem menuConfig;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Label lblSpecial;
        private System.Windows.Forms.Label lblCom;
        private System.Windows.Forms.Label lblLimit;
        private System.Windows.Forms.Label lblTaxNo;
        private System.Windows.Forms.Label lblTaxNumber;
        private System.Windows.Forms.Label lblOpenTime;
        private System.Windows.Forms.ToolStripMenuItem 按单快速开票ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 按客户汇总开票ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem meuInovie;
        private System.Windows.Forms.ToolStripMenuItem 填制手工发票ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 普通发票填开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 发票作废ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 发票查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 开票申请ToolStripMenuItem;
        private DevExpress.XtraEditors.ComboBoxEdit cbbSkin;
        private System.Windows.Forms.ToolStripMenuItem 销售发票开票ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 远程打印ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 普通发票红字开票ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 税收分类编码维护ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 开票资料维护ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 特殊红字开票ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 按月汇总开票ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 按原单红字发票ToolStripMenuItem;
        private DevExpress.XtraTab.XtraTabControl tColMain;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private System.Windows.Forms.ToolStripMenuItem 系统设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 用户管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 角色管理ToolStripMenuItem;
    }
}
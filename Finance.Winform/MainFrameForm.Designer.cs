﻿namespace Finance.Winform
{
    partial class MainFrameForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("每日实收");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("应收明细");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("开票申请");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("实际开票");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("收款", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("应付明细");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("对方发票");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("付款申请");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("发票核销付款");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("付款", new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9});
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("班轮结算系统", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode10});
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tv = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tv);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 187;
            this.splitContainer1.TabIndex = 0;
            // 
            // tv
            // 
            this.tv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tv.Location = new System.Drawing.Point(0, 0);
            this.tv.Name = "tv";
            treeNode1.Name = "每日实收";
            treeNode1.Text = "每日实收";
            treeNode2.Name = "应收明细";
            treeNode2.Text = "应收明细";
            treeNode3.Name = "开票申请";
            treeNode3.Text = "开票申请";
            treeNode4.Name = "实际开票";
            treeNode4.Text = "实际开票";
            treeNode5.Checked = true;
            treeNode5.Name = "收款";
            treeNode5.Text = "收款";
            treeNode6.Name = "应付明细";
            treeNode6.Text = "应付明细";
            treeNode7.Name = "对方发票";
            treeNode7.Text = "对方发票";
            treeNode8.Name = "付款申请";
            treeNode8.Text = "付款申请";
            treeNode9.Name = "发票核销付款";
            treeNode9.Text = "发票核销付款";
            treeNode10.Checked = true;
            treeNode10.Name = "付款";
            treeNode10.Text = "付款";
            treeNode11.Checked = true;
            treeNode11.Name = "班轮结算系统";
            treeNode11.Text = "班轮结算系统";
            this.tv.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode11});
            this.tv.Size = new System.Drawing.Size(187, 450);
            this.tv.TabIndex = 1;
            this.tv.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_AfterSelect);
            // 
            // MainFrameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainFrameForm";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tv;
    }
}


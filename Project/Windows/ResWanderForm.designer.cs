namespace ResWander
{
    partial class ResWanderForm
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
            this.crawButton = new System.Windows.Forms.Button();
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.choseButton = new System.Windows.Forms.Button();
            this.setButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.messageLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.formatLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.sizeLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.heightLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.widthLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.selectAllButton = new System.Windows.Forms.Button();
            this.upDateButton = new System.Windows.Forms.Button();
            this.openListButton = new System.Windows.Forms.Button();
            this.resourceTabControl = new System.Windows.Forms.TabControl();
            this.resourceTabPage = new System.Windows.Forms.TabPage();
            this.resourceDataGridView = new System.Windows.Forms.DataGridView();
            this.previewTabPage = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureSPButton = new System.Windows.Forms.Button();
            this.lastPictureBox = new System.Windows.Forms.PictureBox();
            this.nextPictureBox = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.resourceTabControl.SuspendLayout();
            this.resourceTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resourceDataGridView)).BeginInit();
            this.previewTabPage.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lastPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nextPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // crawButton
            // 
            this.crawButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.crawButton.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.crawButton.Location = new System.Drawing.Point(1095, 3);
            this.crawButton.Name = "crawButton";
            this.crawButton.Size = new System.Drawing.Size(74, 28);
            this.crawButton.TabIndex = 2;
            this.crawButton.Text = "爬取";
            this.crawButton.UseVisualStyleBackColor = true;
            this.crawButton.Click += new System.EventHandler(this.CrawButton_Click);
            // 
            // urlTextBox
            // 
            this.urlTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.urlTextBox.Location = new System.Drawing.Point(90, 3);
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.Size = new System.Drawing.Size(986, 25);
            this.urlTextBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "目标URL：";
            // 
            // choseButton
            // 
            this.choseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.choseButton.Location = new System.Drawing.Point(893, 60);
            this.choseButton.Name = "choseButton";
            this.choseButton.Size = new System.Drawing.Size(100, 28);
            this.choseButton.TabIndex = 6;
            this.choseButton.Text = "筛选";
            this.choseButton.UseVisualStyleBackColor = true;
            this.choseButton.Click += new System.EventHandler(this.ChoseButton_Click);
            // 
            // setButton
            // 
            this.setButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.setButton.Location = new System.Drawing.Point(1056, 60);
            this.setButton.Name = "setButton";
            this.setButton.Size = new System.Drawing.Size(100, 28);
            this.setButton.TabIndex = 7;
            this.setButton.Text = "设置";
            this.setButton.UseVisualStyleBackColor = true;
            this.setButton.Click += new System.EventHandler(this.SetButton_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.urlTextBox);
            this.panel1.Controls.Add(this.crawButton);
            this.panel1.Location = new System.Drawing.Point(1, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1179, 34);
            this.panel1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.messageLabel);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(1, 44);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(813, 54);
            this.panel2.TabIndex = 9;
            // 
            // messageLabel
            // 
            this.messageLabel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.messageLabel.Location = new System.Drawing.Point(80, 7);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(730, 47);
            this.messageLabel.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(2, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "爬取情况：";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.formatLabel);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.sizeLabel);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.heightLabel);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.widthLabel);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(6, 107);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(641, 28);
            this.panel3.TabIndex = 10;
            // 
            // formatLabel
            // 
            this.formatLabel.AutoSize = true;
            this.formatLabel.Location = new System.Drawing.Point(500, 3);
            this.formatLabel.Name = "formatLabel";
            this.formatLabel.Size = new System.Drawing.Size(0, 15);
            this.formatLabel.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(450, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 15);
            this.label6.TabIndex = 6;
            this.label6.Text = "格式：";
            // 
            // sizeLabel
            // 
            this.sizeLabel.AutoSize = true;
            this.sizeLabel.Location = new System.Drawing.Point(320, 3);
            this.sizeLabel.Name = "sizeLabel";
            this.sizeLabel.Size = new System.Drawing.Size(0, 15);
            this.sizeLabel.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(275, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "大小：";
            // 
            // heightLabel
            // 
            this.heightLabel.AutoSize = true;
            this.heightLabel.Location = new System.Drawing.Point(170, 3);
            this.heightLabel.Name = "heightLabel";
            this.heightLabel.Size = new System.Drawing.Size(0, 15);
            this.heightLabel.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(125, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "高度：";
            // 
            // widthLabel
            // 
            this.widthLabel.AutoSize = true;
            this.widthLabel.Location = new System.Drawing.Point(47, 3);
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(0, 15);
            this.widthLabel.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "宽度：";
            // 
            // selectAllButton
            // 
            this.selectAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectAllButton.Location = new System.Drawing.Point(179, 6);
            this.selectAllButton.Name = "selectAllButton";
            this.selectAllButton.Size = new System.Drawing.Size(90, 28);
            this.selectAllButton.TabIndex = 5;
            this.selectAllButton.Text = "全选";
            this.selectAllButton.UseVisualStyleBackColor = true;
            this.selectAllButton.Click += new System.EventHandler(this.SelectAllButton_Click);
            // 
            // upDateButton
            // 
            this.upDateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.upDateButton.Location = new System.Drawing.Point(292, 6);
            this.upDateButton.Name = "upDateButton";
            this.upDateButton.Size = new System.Drawing.Size(90, 28);
            this.upDateButton.TabIndex = 6;
            this.upDateButton.Text = "下载选中";
            this.upDateButton.UseVisualStyleBackColor = true;
            this.upDateButton.Click += new System.EventHandler(this.UpDateButton_Click);
            // 
            // openListButton
            // 
            this.openListButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.openListButton.Location = new System.Drawing.Point(402, 6);
            this.openListButton.Name = "openListButton";
            this.openListButton.Size = new System.Drawing.Size(120, 28);
            this.openListButton.TabIndex = 7;
            this.openListButton.Text = "打开下载目录";
            this.openListButton.UseVisualStyleBackColor = true;
            this.openListButton.Click += new System.EventHandler(this.OpenListButton_Click);
            // 
            // resourceTabControl
            // 
            this.resourceTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resourceTabControl.Controls.Add(this.resourceTabPage);
            this.resourceTabControl.Controls.Add(this.previewTabPage);
            this.resourceTabControl.Location = new System.Drawing.Point(7, 151);
            this.resourceTabControl.Name = "resourceTabControl";
            this.resourceTabControl.SelectedIndex = 0;
            this.resourceTabControl.Size = new System.Drawing.Size(1172, 602);
            this.resourceTabControl.TabIndex = 12;
            // 
            // resourceTabPage
            // 
            this.resourceTabPage.Controls.Add(this.resourceDataGridView);
            this.resourceTabPage.Location = new System.Drawing.Point(4, 25);
            this.resourceTabPage.Name = "resourceTabPage";
            this.resourceTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.resourceTabPage.Size = new System.Drawing.Size(1164, 573);
            this.resourceTabPage.TabIndex = 0;
            this.resourceTabPage.Text = "资源爬取情况";
            this.resourceTabPage.UseVisualStyleBackColor = true;
            // 
            // resourceDataGridView
            // 
            this.resourceDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resourceDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resourceDataGridView.Location = new System.Drawing.Point(-4, 6);
            this.resourceDataGridView.Name = "resourceDataGridView";
            this.resourceDataGridView.RowHeadersWidth = 51;
            this.resourceDataGridView.RowTemplate.Height = 27;
            this.resourceDataGridView.Size = new System.Drawing.Size(1168, 567);
            this.resourceDataGridView.TabIndex = 0;
            // 
            // previewTabPage
            // 
            this.previewTabPage.AutoScroll = true;
            this.previewTabPage.Controls.Add(this.lastPictureBox);
            this.previewTabPage.Controls.Add(this.nextPictureBox);
            this.previewTabPage.Location = new System.Drawing.Point(4, 25);
            this.previewTabPage.Name = "previewTabPage";
            this.previewTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.previewTabPage.Size = new System.Drawing.Size(1164, 573);
            this.previewTabPage.TabIndex = 1;
            this.previewTabPage.Text = "预览";
            this.previewTabPage.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.pictureSPButton);
            this.panel4.Controls.Add(this.selectAllButton);
            this.panel4.Controls.Add(this.upDateButton);
            this.panel4.Controls.Add(this.openListButton);
            this.panel4.Location = new System.Drawing.Point(653, 104);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(527, 41);
            this.panel4.TabIndex = 13;
            // 
            // pictureSPButton
            // 
            this.pictureSPButton.Location = new System.Drawing.Point(45, 6);
            this.pictureSPButton.Name = "pictureSPButton";
            this.pictureSPButton.Size = new System.Drawing.Size(100, 28);
            this.pictureSPButton.TabIndex = 8;
            this.pictureSPButton.Text = "以图搜图";
            this.pictureSPButton.UseVisualStyleBackColor = true;
            this.pictureSPButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // lastPictureBox
            // 
            this.lastPictureBox.Image = global::ResWander.Properties.Resources.primaryLeft;
            this.lastPictureBox.Location = new System.Drawing.Point(-5, 294);
            this.lastPictureBox.Name = "lastPictureBox";
            this.lastPictureBox.Size = new System.Drawing.Size(90, 130);
            this.lastPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.lastPictureBox.TabIndex = 4;
            this.lastPictureBox.TabStop = false;
            this.lastPictureBox.Click += new System.EventHandler(this.LastPictureBox_Click);
            this.lastPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LastPictureBox_MouseDown);
            this.lastPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LastPictureBox_MouseUp);
            // 
            // nextPictureBox
            // 
            this.nextPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nextPictureBox.Image = global::ResWander.Properties.Resources.primaryRight;
            this.nextPictureBox.Location = new System.Drawing.Point(1079, 294);
            this.nextPictureBox.Name = "nextPictureBox";
            this.nextPictureBox.Size = new System.Drawing.Size(90, 130);
            this.nextPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.nextPictureBox.TabIndex = 3;
            this.nextPictureBox.TabStop = false;
            this.nextPictureBox.Click += new System.EventHandler(this.NextPictureBox_Click);
            this.nextPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NextPictureBox_MouseDown);
            this.nextPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.NextPictureBox_MouseUp);
            // 
            // ResWanderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 753);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.resourceTabControl);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.setButton);
            this.Controls.Add(this.choseButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ResWanderForm";
            this.Text = "ResWander";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.resourceTabControl.ResumeLayout(false);
            this.resourceTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.resourceDataGridView)).EndInit();
            this.previewTabPage.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lastPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nextPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button crawButton;
        private System.Windows.Forms.TextBox urlTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button choseButton;
        private System.Windows.Forms.Button setButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button selectAllButton;
        private System.Windows.Forms.Button upDateButton;
        private System.Windows.Forms.Button openListButton;
        private System.Windows.Forms.TabControl resourceTabControl;
        private System.Windows.Forms.TabPage resourceTabPage;
        private System.Windows.Forms.DataGridView resourceDataGridView;
        private System.Windows.Forms.TabPage previewTabPage;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Label sizeLabel;
        internal System.Windows.Forms.Label heightLabel;
        internal System.Windows.Forms.Label widthLabel;
        internal System.Windows.Forms.Label formatLabel;
        internal System.Windows.Forms.PictureBox nextPictureBox;
        private System.Windows.Forms.PictureBox lastPictureBox;
        private System.Windows.Forms.Button pictureSPButton;
    }
}


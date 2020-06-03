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
            this.components = new System.ComponentModel.Container();
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
            this.reChoseButton = new System.Windows.Forms.Button();
            this.selectAllButton = new System.Windows.Forms.Button();
            this.upDateButton = new System.Windows.Forms.Button();
            this.openListButton = new System.Windows.Forms.Button();
            this.resourceTabControl = new System.Windows.Forms.TabControl();
            this.resourceTabPage = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.previewTabPage = new System.Windows.Forms.TabPage();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.imgMessageBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.urlDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.resourceTabControl.SuspendLayout();
            this.resourceTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.previewTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgMessageBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // crawButton
            // 
            this.crawButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.crawButton.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.crawButton.Location = new System.Drawing.Point(764, 2);
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
            this.urlTextBox.Size = new System.Drawing.Size(659, 25);
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
            this.choseButton.Location = new System.Drawing.Point(622, 49);
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
            this.setButton.Location = new System.Drawing.Point(739, 49);
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
            this.panel1.Size = new System.Drawing.Size(845, 34);
            this.panel1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.messageLabel);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(1, 44);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(571, 33);
            this.panel2.TabIndex = 9;
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.Location = new System.Drawing.Point(151, 9);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(0, 15);
            this.messageLabel.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(3, 9);
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
            this.panel3.Location = new System.Drawing.Point(1, 83);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(423, 28);
            this.panel3.TabIndex = 10;
            // 
            // formatLabel
            // 
            this.formatLabel.AutoSize = true;
            this.formatLabel.Location = new System.Drawing.Point(380, 3);
            this.formatLabel.Name = "formatLabel";
            this.formatLabel.Size = new System.Drawing.Size(0, 15);
            this.formatLabel.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(334, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 15);
            this.label6.TabIndex = 6;
            this.label6.Text = "格式：";
            // 
            // sizeLabel
            // 
            this.sizeLabel.AutoSize = true;
            this.sizeLabel.Location = new System.Drawing.Point(265, 3);
            this.sizeLabel.Name = "sizeLabel";
            this.sizeLabel.Size = new System.Drawing.Size(0, 15);
            this.sizeLabel.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(220, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "大小：";
            // 
            // heightLabel
            // 
            this.heightLabel.AutoSize = true;
            this.heightLabel.Location = new System.Drawing.Point(158, 3);
            this.heightLabel.Name = "heightLabel";
            this.heightLabel.Size = new System.Drawing.Size(0, 15);
            this.heightLabel.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(113, 3);
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
            // reChoseButton
            // 
            this.reChoseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.reChoseButton.Location = new System.Drawing.Point(3, 3);
            this.reChoseButton.Name = "reChoseButton";
            this.reChoseButton.Size = new System.Drawing.Size(90, 28);
            this.reChoseButton.TabIndex = 4;
            this.reChoseButton.Text = "重新筛选";
            this.reChoseButton.UseVisualStyleBackColor = true;
            this.reChoseButton.Click += new System.EventHandler(this.ReChoseButton_Click);
            // 
            // selectAllButton
            // 
            this.selectAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectAllButton.Location = new System.Drawing.Point(99, 3);
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
            this.upDateButton.Location = new System.Drawing.Point(195, 3);
            this.upDateButton.Name = "upDateButton";
            this.upDateButton.Size = new System.Drawing.Size(90, 28);
            this.upDateButton.TabIndex = 6;
            this.upDateButton.Text = "下载选中";
            this.upDateButton.UseVisualStyleBackColor = true;
            this.upDateButton.Click += new System.EventHandler(this.UpDateButton_Click);
            // 
            // openListButton
            // 
            this.openListButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.openListButton.Location = new System.Drawing.Point(289, 3);
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
            this.resourceTabControl.Location = new System.Drawing.Point(7, 120);
            this.resourceTabControl.Name = "resourceTabControl";
            this.resourceTabControl.SelectedIndex = 0;
            this.resourceTabControl.Size = new System.Drawing.Size(838, 345);
            this.resourceTabControl.TabIndex = 12;
            // 
            // resourceTabPage
            // 
            this.resourceTabPage.Controls.Add(this.dataGridView1);
            this.resourceTabPage.Location = new System.Drawing.Point(4, 25);
            this.resourceTabPage.Name = "resourceTabPage";
            this.resourceTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.resourceTabPage.Size = new System.Drawing.Size(830, 316);
            this.resourceTabPage.TabIndex = 0;
            this.resourceTabPage.Text = "资源爬取情况";
            this.resourceTabPage.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.urlDataGridViewTextBoxColumn});
            this.dataGridView1.DataMember = "RowImages";
            this.dataGridView1.DataSource = this.imgMessageBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(-4, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(839, 307);
            this.dataGridView1.TabIndex = 0;
            // 
            // previewTabPage
            // 
            this.previewTabPage.AutoScroll = true;
            this.previewTabPage.Controls.Add(this.pictureBox6);
            this.previewTabPage.Controls.Add(this.pictureBox8);
            this.previewTabPage.Controls.Add(this.pictureBox7);
            this.previewTabPage.Controls.Add(this.pictureBox5);
            this.previewTabPage.Controls.Add(this.pictureBox4);
            this.previewTabPage.Controls.Add(this.pictureBox3);
            this.previewTabPage.Controls.Add(this.pictureBox2);
            this.previewTabPage.Controls.Add(this.pictureBox1);
            this.previewTabPage.Location = new System.Drawing.Point(4, 25);
            this.previewTabPage.Name = "previewTabPage";
            this.previewTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.previewTabPage.Size = new System.Drawing.Size(830, 316);
            this.previewTabPage.TabIndex = 1;
            this.previewTabPage.Text = "预览";
            this.previewTabPage.UseVisualStyleBackColor = true;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Location = new System.Drawing.Point(225, 178);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(160, 130);
            this.pictureBox6.TabIndex = 8;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.DoubleClick += new System.EventHandler(this.PictureBox6_DoubleClick);
            // 
            // pictureBox8
            // 
            this.pictureBox8.Location = new System.Drawing.Point(626, 178);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(160, 130);
            this.pictureBox8.TabIndex = 7;
            this.pictureBox8.TabStop = false;
            this.pictureBox8.DoubleClick += new System.EventHandler(this.PictureBox8_DoubleClick);
            // 
            // pictureBox7
            // 
            this.pictureBox7.Location = new System.Drawing.Point(425, 178);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(160, 130);
            this.pictureBox7.TabIndex = 6;
            this.pictureBox7.TabStop = false;
            this.pictureBox7.DoubleClick += new System.EventHandler(this.PictureBox7_DoubleClick);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Location = new System.Drawing.Point(22, 178);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(160, 130);
            this.pictureBox5.TabIndex = 4;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.DoubleClick += new System.EventHandler(this.PictureBox5_DoubleClick);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Location = new System.Drawing.Point(626, 17);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(160, 130);
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.DoubleClick += new System.EventHandler(this.PictureBox4_DoubleClick);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(425, 17);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(160, 130);
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.DoubleClick += new System.EventHandler(this.PictureBox3_DoubleClick);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(225, 17);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(160, 130);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.DoubleClick += new System.EventHandler(this.PictureBox2_DoubleClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(22, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(160, 130);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.DoubleClick += new System.EventHandler(this.PictureBox1_DoubleClick);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.selectAllButton);
            this.panel4.Controls.Add(this.upDateButton);
            this.panel4.Controls.Add(this.reChoseButton);
            this.panel4.Controls.Add(this.openListButton);
            this.panel4.Location = new System.Drawing.Point(427, 83);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(418, 41);
            this.panel4.TabIndex = 13;
            // 
            // imgMessageBindingSource
            // 
            this.imgMessageBindingSource.DataSource = typeof(ResWander.Data.ImgResourcesContainer);
            // 
            // urlDataGridViewTextBoxColumn
            // 
            this.urlDataGridViewTextBoxColumn.DataPropertyName = "Url";
            this.urlDataGridViewTextBoxColumn.HeaderText = "Url";
            this.urlDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.urlDataGridViewTextBoxColumn.Name = "urlDataGridViewTextBoxColumn";
            this.urlDataGridViewTextBoxColumn.Width = 125;
            // 
            // ResWanderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 465);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.resourceTabControl);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.setButton);
            this.Controls.Add(this.choseButton);
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.previewTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgMessageBindingSource)).EndInit();
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
        private System.Windows.Forms.Button reChoseButton;
        private System.Windows.Forms.Button selectAllButton;
        private System.Windows.Forms.Button upDateButton;
        private System.Windows.Forms.Button openListButton;
        private System.Windows.Forms.TabControl resourceTabControl;
        private System.Windows.Forms.TabPage resourceTabPage;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage previewTabPage;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Label sizeLabel;
        internal System.Windows.Forms.Label heightLabel;
        internal System.Windows.Forms.Label widthLabel;
        internal System.Windows.Forms.Label formatLabel;
        private System.Windows.Forms.BindingSource imgMessageBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn urlDataGridViewTextBoxColumn;
    }
}


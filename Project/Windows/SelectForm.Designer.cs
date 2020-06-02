namespace ResWander.Windows
{
    partial class SelectForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.maxWidthTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.minWidthTextBox = new System.Windows.Forms.TextBox();
            this.maxHeightTextBox = new System.Windows.Forms.TextBox();
            this.minHeightTextBox = new System.Windows.Forms.TextBox();
            this.maxSizeTextBox = new System.Windows.Forms.TextBox();
            this.minSizeTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.formatComboBox = new System.Windows.Forms.ComboBox();
            this.affirmButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "最大宽度：";
            // 
            // maxWidthTextBox
            // 
            this.maxWidthTextBox.Location = new System.Drawing.Point(100, 32);
            this.maxWidthTextBox.Name = "maxWidthTextBox";
            this.maxWidthTextBox.Size = new System.Drawing.Size(85, 25);
            this.maxWidthTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "最小宽度：";
            // 
            // minWidthTextBox
            // 
            this.minWidthTextBox.Location = new System.Drawing.Point(100, 109);
            this.minWidthTextBox.Name = "minWidthTextBox";
            this.minWidthTextBox.Size = new System.Drawing.Size(85, 25);
            this.minWidthTextBox.TabIndex = 3;
            // 
            // maxHeightTextBox
            // 
            this.maxHeightTextBox.Location = new System.Drawing.Point(348, 35);
            this.maxHeightTextBox.Name = "maxHeightTextBox";
            this.maxHeightTextBox.Size = new System.Drawing.Size(80, 25);
            this.maxHeightTextBox.TabIndex = 4;
            // 
            // minHeightTextBox
            // 
            this.minHeightTextBox.Location = new System.Drawing.Point(348, 109);
            this.minHeightTextBox.Name = "minHeightTextBox";
            this.minHeightTextBox.Size = new System.Drawing.Size(80, 25);
            this.minHeightTextBox.TabIndex = 5;
            // 
            // maxSizeTextBox
            // 
            this.maxSizeTextBox.Location = new System.Drawing.Point(606, 35);
            this.maxSizeTextBox.Name = "maxSizeTextBox";
            this.maxSizeTextBox.Size = new System.Drawing.Size(80, 25);
            this.maxSizeTextBox.TabIndex = 6;
            // 
            // minSizeTextBox
            // 
            this.minSizeTextBox.Location = new System.Drawing.Point(606, 115);
            this.minSizeTextBox.Name = "minSizeTextBox";
            this.minSizeTextBox.Size = new System.Drawing.Size(80, 25);
            this.minSizeTextBox.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(260, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "最大高度：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(260, 115);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "最小高度：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(518, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "最大大小：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(518, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "最小大小：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(239, 209);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 15);
            this.label7.TabIndex = 12;
            this.label7.Text = "图片格式：";
            // 
            // formatComboBox
            // 
            this.formatComboBox.FormattingEnabled = true;
            this.formatComboBox.Items.AddRange(new object[] {
            "JPG",
            "PNG",
            "TIF",
            "GIF",
            "*..*"});
            this.formatComboBox.Location = new System.Drawing.Point(327, 206);
            this.formatComboBox.Name = "formatComboBox";
            this.formatComboBox.Size = new System.Drawing.Size(101, 23);
            this.formatComboBox.TabIndex = 13;
            // 
            // affirmButton
            // 
            this.affirmButton.Location = new System.Drawing.Point(327, 303);
            this.affirmButton.Name = "affirmButton";
            this.affirmButton.Size = new System.Drawing.Size(75, 31);
            this.affirmButton.TabIndex = 14;
            this.affirmButton.Text = "确认";
            this.affirmButton.UseVisualStyleBackColor = true;
            this.affirmButton.Click += new System.EventHandler(this.AffirmButton_Click);
            // 
            // SelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.affirmButton);
            this.Controls.Add(this.formatComboBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.minSizeTextBox);
            this.Controls.Add(this.maxSizeTextBox);
            this.Controls.Add(this.minHeightTextBox);
            this.Controls.Add(this.maxHeightTextBox);
            this.Controls.Add(this.minWidthTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.maxWidthTextBox);
            this.Controls.Add(this.label1);
            this.Name = "SelectForm";
            this.Text = "筛选条件";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox maxWidthTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox minWidthTextBox;
        private System.Windows.Forms.TextBox maxHeightTextBox;
        private System.Windows.Forms.TextBox minHeightTextBox;
        private System.Windows.Forms.TextBox maxSizeTextBox;
        private System.Windows.Forms.TextBox minSizeTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox formatComboBox;
        private System.Windows.Forms.Button affirmButton;
    }
}
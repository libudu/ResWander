﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResWander.Windows
{
    public partial class SelectForm : Form
    {
        public ResWanderForm resForm;
        public SelectForm()
        {
            InitializeComponent();
        }

        private void AffirmButton_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(minWidthTextBox.Text) && !string.IsNullOrWhiteSpace(maxWidthTextBox.Text) &&
               !string.IsNullOrWhiteSpace(minHeightTextBox.Text) && !string.IsNullOrWhiteSpace(maxHeightTextBox.Text) &&
               !string.IsNullOrWhiteSpace(minSizeTextBox.Text) && !string.IsNullOrWhiteSpace(maxSizeTextBox.Text) && formatComboBox.SelectedItem != null)
            {
                resForm.widthLabel.Text = minWidthTextBox.Text + "~" + maxWidthTextBox.Text;
                resForm.heightLabel.Text = minHeightTextBox.Text + "~" + maxHeightTextBox.Text;
                resForm.sizeLabel.Text = minSizeTextBox.Text + "~" + maxSizeTextBox.Text;
                resForm.formatLabel.Text = (string)formatComboBox.SelectedItem;
                //在这还要调用相应的筛选方法，给这个方法传入用户输入的筛选条件，宽度，高度等
                this.Close();
            }
            else
            {
                MessageBox.Show("筛选条件不完整，请用户补全筛选条件！");
            }
            
        }
    }
}

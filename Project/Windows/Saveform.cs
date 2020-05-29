using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResWander
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public Form1 formone;          //声明一个窗口1的引用，便于传输数据
        /// <summary>
        /// 当用户点击确认按钮后，调用该方法，将用户输入的路径保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AffirmButton_Click(object sender, EventArgs e)
        {
            this.formone.stoPath = this.pathTextBox.Text; //获取并保存用户输入的路径
            this.Close();                   //关闭窗口2
        }
    }
}

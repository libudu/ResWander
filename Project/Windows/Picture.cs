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
    public partial class Picture : Form
    {
        public Picture()
        {
            InitializeComponent();
        }

        private void PictureBox_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

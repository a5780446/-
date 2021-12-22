using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 三進原料
{
    public partial class 認證 : Form
    {
        public 認證()
        {
            InitializeComponent();
        }
        核准 f1;
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="sj00" || textBox1.Text == "SJ00")
            {
                MessageBox.Show("Success");
                f1 = new 核准();
                f1.Show();
                this.Close();

            }
            else
            {
                MessageBox.Show("Fail");
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if(textBox1.Text == "sj00" || textBox1.Text == "SJ00")
                {
                    MessageBox.Show("Success");
                    f1 = new 核准();
                    f1.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Fail");
                }
            }
        }

        private void 認證_Load(object sender, EventArgs e)
        {
            label2.Text = 三進原料.product;
        }
    }
}

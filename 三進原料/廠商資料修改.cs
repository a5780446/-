using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 三進原料
{
    public partial class 廠商資料修改 : Form
    {
        public 廠商資料修改()
        {
            InitializeComponent();
        }

        private void 廠商資料修改_Load(object sender, EventArgs e)
        {
            label9.Text = 三進原料.vv;
            label10.Text = 三進原料.gg;
            SqlConnection conn = new SqlConnection(三進原料.cn);
            conn.Open();
            SqlCommand cmd = new SqlCommand($"select name from vendor where number='{label9.Text}'", conn);
            SqlCommand cmd1 = new SqlCommand($"select nikename from vendor where number='{label9.Text}'", conn);
            SqlCommand cmd2 = new SqlCommand($"select number from vendor where number='{label9.Text}'", conn);
            SqlCommand cmd3 = new SqlCommand($"select tel from vendor where number='{label9.Text}'", conn);
            SqlCommand cmd4 = new SqlCommand($"select firstconn from vendor where number='{label9.Text}'", conn);
            SqlCommand cmd5 = new SqlCommand($"select adress from vendor where number='{label9.Text}'", conn);
            SqlCommand cmd6 = new SqlCommand($"select remark from vendor where number='{label9.Text}'", conn);
            SqlCommand cmd7 = new SqlCommand($"select secconn from vendor where number='{label9.Text}'", conn);
            
            textBox1.Text = cmd.ExecuteScalar().ToString();
            textBox2.Text = cmd1.ExecuteScalar().ToString();
            textBox3.Text = cmd2.ExecuteScalar().ToString();
            textBox4.Text = cmd3.ExecuteScalar().ToString();
            textBox5.Text = cmd5.ExecuteScalar().ToString();
            textBox6.Text = cmd4.ExecuteScalar().ToString();
            textBox7.Text = cmd7.ExecuteScalar().ToString();
            richTextBox1.Text = cmd6.ExecuteScalar().ToString();
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(三進原料.cn);
                conn.Open();
                SqlCommand cmd = new SqlCommand($"update vendor set name=N'{textBox1.Text}',nikename=N'{textBox2.Text}',number=N'{textBox3.Text}',tel=N'{textBox4.Text}',firstconn=N'{textBox6.Text}',secconn=N'{textBox7.Text}',adress=N'{textBox5.Text}',remark=N'{richTextBox1.Text}' where number=N'{label9.Text}'", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("修改成功");
                this.Close();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}

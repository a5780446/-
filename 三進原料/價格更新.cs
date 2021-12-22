using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace 三進原料
{
    public partial class 價格更新 : Form
    {
        public 價格更新()
        {
            InitializeComponent();
        }

        private void 價格更新_Load(object sender, EventArgs e)
        {
            label1.Text =三進原料.gg;
            label4.Text = 三進原料.vv;
            label2.Text = DateTime.Now.ToShortDateString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(三進原料.cn);
                conn.Open();
                SqlCommand cmd = new SqlCommand($"update vendor set nowprice='{textBox1.Text}',nowsus='{textBox2.Text}' where number='{label4.Text}'", conn);
                cmd.ExecuteNonQuery();
                SqlCommand cmd1 = new SqlCommand($"insert into upprice (vname,month,sphc,sus,spg) values (@廠,@月,@1,@2,@3)", conn);
                cmd1.Parameters.Add("@廠", SqlDbType.NVarChar, 50).Value = label1.Text;
                cmd1.Parameters.Add("@月", SqlDbType.NVarChar, 50).Value = label2.Text;
                cmd1.Parameters.Add("@1", SqlDbType.NChar,10).Value = textBox1.Text;
                cmd1.Parameters.Add("@2", SqlDbType.NChar, 10).Value = textBox2.Text;
                cmd1.Parameters.Add("@3", SqlDbType.NChar, 10).Value = textBox3.Text;
                cmd1.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("價格已更新");
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

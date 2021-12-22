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
    public partial class 廠商新增 : Form
    {
        public 廠商新增()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!(new System.Text.RegularExpressions.Regex("[0-9]{8}")).IsMatch(textBox3.Text))
            {
                MessageBox.Show("統一編號格式錯誤");
            }
            
            else
            {
                try
                {
                    //連結SQL 新增資料
                    SqlConnection conn = new SqlConnection(三進原料.cn);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("insert into vendor(name,nikename,number,tel,firstconn,secconn,adress,remark) values (@全名,@簡稱,@統編,@電話,@主聯,@次聯,@地址,@備註)", conn);
                    cmd.Parameters.Add("@全名", SqlDbType.NVarChar, 50).Value = textBox1.Text;
                    cmd.Parameters.Add("@簡稱", SqlDbType.NVarChar, 50).Value = textBox2.Text;
                    cmd.Parameters.Add("@統編", SqlDbType.NChar, 10).Value = textBox3.Text;
                    cmd.Parameters.Add("@電話", SqlDbType.NVarChar, 50).Value = textBox4.Text;
                    cmd.Parameters.Add("@主聯", SqlDbType.NVarChar, 50).Value = textBox7.Text;
                    cmd.Parameters.Add("@次聯", SqlDbType.NVarChar, 50).Value = textBox6.Text;
                    cmd.Parameters.Add("@地址", SqlDbType.NVarChar, 50).Value = textBox5.Text;
                    cmd.Parameters.Add("@備註", SqlDbType.NVarChar, 50).Value = richTextBox1.Text;
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("新增成功");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
           
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

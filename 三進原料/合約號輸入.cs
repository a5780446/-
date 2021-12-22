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
    public partial class 合約號輸入 : Form
    {
        public 合約號輸入()
        {
            InitializeComponent();
        }

        private void 合約號輸入_Load(object sender, EventArgs e)
        {
            label1.Text = 三進原料.product;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(三進原料.cn);
                conn.Open();
                SqlCommand cmd = new SqlCommand($"update ask set agreement ='{textBox1.Text}' where orderid='{label1.Text}'", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("合約號新增成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}

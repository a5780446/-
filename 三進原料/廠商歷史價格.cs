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
    public partial class 廠商歷史價格 : Form
    {
        public 廠商歷史價格()
        {
            InitializeComponent();
        }

        private void 廠商歷史價格_Load(object sender, EventArgs e)
        {
            label1.Text = 三進原料.gg;
            SqlConnection conn = new SqlConnection(三進原料.cn);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter($"select month as '日期',sphc as 'SPHC',sus as 'SUS',spg as 'SPG' from upprice where vname=N'{label1.Text}'", conn);  //待修改
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(三進原料.cn);
            con.Open();
            SqlCommand cmd = new SqlCommand($"select month as '日期',sphc as 'SPHC',sus as 'SUS',spg as 'SPG' from upprice where month like N'{textBox1.Text}' ",con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}

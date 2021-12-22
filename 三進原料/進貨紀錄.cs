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
    public partial class 進貨紀錄 : Form
    {
        public 進貨紀錄()
        {
            InitializeComponent();
        }

        private void 進貨紀錄_Load(object sender, EventArgs e)
        {
            label1.Text = 三進原料.product;
            SqlConnection conn = new SqlConnection(三進原料.cn);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter($"select inid as '單號',vendor as '廠商',material as '材質',product as '品名',format as '規格',inqty as '進貨量',inmoney as '金額',leftqty as '寄庫剩餘',indate as '異動時間' from inlog where inid='{label1.Text}'", conn);  //待修改
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            SqlCommand cmd = new SqlCommand($"select sum(inmoney) from inlog where inid='{label1.Text}'", conn);
            cmd.ExecuteNonQuery();
            label2.Text = cmd.ExecuteScalar().ToString();
        }
    }
}

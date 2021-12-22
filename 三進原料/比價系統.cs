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
    public partial class 比價系統 : Form
    {
        public 比價系統()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(三進原料.cn);
                SqlDataAdapter da = new SqlDataAdapter($"select top(6) vendor as '廠商',material as '材質',unit as '單位',vprice as '廠商報價',askdate as '詢價日期'  from ask where material like N'%{comboBox1.Text}%' order by askdate DESC,vprice ASC ", conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                chart1.DataSource = ds;
                chart1.Series["廠商價格"].XValueMember = "廠商";
                chart1.Series["廠商價格"].YValueMembers = "廠商報價";
                //chart1.Series["歷史最低"].XValueMember = "廠商";
                //chart1.Series["歷史最低"].YValueMembers = "廠商報價";
                chart1.Titles.Add("鐵價");
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }
    }
}

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
    public partial class 詳情 : Form
    {
        public 詳情()
        {
            InitializeComponent();
        }

        private void 詳情_Load(object sender, EventArgs e)
        {
            if (三進原料.page == "詢價表")
            {
                label1.Text = 三進原料.product;
                SqlConnection conn = new SqlConnection(三進原料.cn);
                conn.Open();
                SqlCommand cmd = new SqlCommand($"select vendor from ask where orderid='{三進原料.product}'", conn);
                cmd.ExecuteNonQuery();
                SqlCommand cmd1 = new SqlCommand($"select material from ask where orderid='{三進原料.product}'", conn);
                cmd1.ExecuteNonQuery();
                SqlCommand cmd2 = new SqlCommand($"select product from ask where orderid='{三進原料.product}'", conn);
                cmd2.ExecuteNonQuery();
                SqlCommand cmd3 = new SqlCommand($"select format from ask where orderid='{三進原料.product}'", conn);
                cmd3.ExecuteNonQuery();
                SqlCommand cmd4 = new SqlCommand($"select unit from ask where orderid='{三進原料.product}'", conn);
                cmd4.ExecuteNonQuery();
                SqlCommand cmd5 = new SqlCommand($"select price from ask where orderid='{三進原料.product}'", conn);
                cmd5.ExecuteNonQuery();
                SqlCommand cmd6 = new SqlCommand($"select process from ask where orderid='{三進原料.product}'", conn);
                cmd6.ExecuteNonQuery();
                SqlCommand cmd7 = new SqlCommand($"select remark from ask where orderid='{三進原料.product}'", conn);
                cmd7.ExecuteNonQuery();
                SqlCommand cmd8 = new SqlCommand($"select vprice from ask where orderid='{三進原料.product}'", conn);
                cmd7.ExecuteNonQuery();
                label2.Text = cmd.ExecuteScalar().ToString();
                label3.Text =  cmd1.ExecuteScalar().ToString();
                label4.Text =  cmd2.ExecuteScalar().ToString();
                label5.Text = cmd3.ExecuteScalar().ToString();
                label6.Text = cmd4.ExecuteScalar().ToString();
                label7.Text =  cmd8.ExecuteScalar().ToString();
                label8.Text =  cmd5.ExecuteScalar().ToString();
                label9.Text =  cmd6.ExecuteScalar().ToString();
                label14.Text = cmd7.ExecuteScalar().ToString();
                conn.Close();
            }
            if(三進原料.page == "合約表")
            {
                label1.Text = 三進原料.product;
                SqlConnection conn = new SqlConnection(三進原料.cn);
                conn.Open();
                SqlCommand cmd = new SqlCommand($"select vendor from ask where orderid='{三進原料.product}'", conn); //廠商
                cmd.ExecuteNonQuery();
                SqlCommand cmd1 = new SqlCommand($"select material from ask where orderid='{三進原料.product}'", conn); //材質
                cmd1.ExecuteNonQuery();
                SqlCommand cmd2 = new SqlCommand($"select product from ask where orderid='{三進原料.product}'", conn); //品茗
                cmd2.ExecuteNonQuery();
                SqlCommand cmd3 = new SqlCommand($"select format from ask where orderid='{三進原料.product}'", conn); //規格
                cmd3.ExecuteNonQuery();
                SqlCommand cmd4 = new SqlCommand($"select unit from ask where orderid='{三進原料.product}'", conn); //單位
                cmd4.ExecuteNonQuery();
                SqlCommand cmd5 = new SqlCommand($"select price from ask where orderid='{三進原料.product}'", conn); //採購價格
                cmd5.ExecuteNonQuery();
                SqlCommand cmd6 = new SqlCommand($"select process from ask where orderid='{三進原料.product}'", conn); //表面處理
                cmd6.ExecuteNonQuery();
                SqlCommand cmd7 = new SqlCommand($"select remark from ask where orderid='{三進原料.product}'", conn);  //備註
                cmd7.ExecuteNonQuery();
                SqlCommand cmd8 = new SqlCommand($"select vprice from ask where orderid='{三進原料.product}'", conn); //廠商價格
                cmd8.ExecuteNonQuery();
                SqlCommand cmd9 = new SqlCommand($"select name from ask where orderid='{三進原料.product}'", conn); //審核人
                cmd9.ExecuteNonQuery();
                SqlCommand cmd10 = new SqlCommand($"select agreement from ask where orderid='{三進原料.product}'", conn); //合約號
                cmd10.ExecuteNonQuery();
                SqlCommand cmd11 = new SqlCommand($"select qty from ask where orderid='{三進原料.product}'", conn); //購買量
                cmd11.ExecuteNonQuery();
                SqlCommand cmd12 = new SqlCommand($"select needdate from ask where orderid='{三進原料.product}'", conn); //核准日
                cmd12.ExecuteNonQuery();
                label2.Text = cmd.ExecuteScalar().ToString();
                label3.Text =  cmd1.ExecuteScalar().ToString();
                label4.Text =  cmd2.ExecuteScalar().ToString();
                label5.Text = cmd3.ExecuteScalar().ToString();
                label6.Text = cmd4.ExecuteScalar().ToString();
                label7.Text =  cmd8.ExecuteScalar().ToString();
                label8.Text =  cmd5.ExecuteScalar().ToString();
                label9.Text =  cmd6.ExecuteScalar().ToString();
                label10.Text =  cmd9.ExecuteScalar().ToString();
                label11.Text =  cmd11.ExecuteScalar().ToString();
                label12.Text =  cmd10.ExecuteScalar().ToString();
                label13.Text = cmd12.ExecuteScalar().ToString();
                label14.Text = cmd7.ExecuteScalar().ToString();
                conn.Close();
            }
            
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

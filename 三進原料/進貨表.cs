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
    public partial class 進貨表 : Form
    {
        public 進貨表()
        {
            InitializeComponent();
        }

        private void 進貨表_Load(object sender, EventArgs e)
        {
            label5.Text = 三進原料.product;

            SqlConnection conn = new SqlConnection(三進原料.cn);
            conn.Open();
            SqlCommand cmd = new SqlCommand($"select qtyleft from ask where orderid='{三進原料.product}'", conn);
            SqlCommand cmd1 = new SqlCommand($"select price from ask where orderid='{三進原料.product}'", conn);
            SqlCommand cmd2 = new SqlCommand($"select MIN(leftqty) from inlog where inid='{三進原料.product}'", conn);
            SqlCommand cmd3 = new SqlCommand($"select buyunit from ask where orderid='{三進原料.product}'", conn);
            cmd3.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            cmd1.ExecuteNonQuery();
            cmd.ExecuteNonQuery();
            label6.Text = cmd.ExecuteScalar().ToString();
            textBox3.Text = cmd1.ExecuteScalar().ToString();
            label12.Text = cmd2.ExecuteScalar().ToString();
            label13.Text = cmd3.ExecuteScalar().ToString();
            conn.Close();
            label7.Text = 三進原料.vendor;
            label8.Text = 三進原料.material;
            label9.Text = 三進原料.produ;
            label10.Text = 三進原料.format;
            
            panel1.Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (float.Parse(textBox2.Text) > float.Parse(label12.Text))
            {
                MessageBox.Show("進貨數大於寄庫量了!");
                textBox2.Focus();
            }
            else if (float.Parse(textBox2.Text) == float.Parse(label12.Text))
            {
                DialogResult ans;
                ans=MessageBox.Show("確定結單?","警告",MessageBoxButtons.YesNo);
                if (ans == DialogResult.Yes)
                {
                    SqlConnection con = new SqlConnection(三進原料.cn);
                    con.Open();
                    SqlCommand cmdd = new SqlCommand($"update ask set state =N'已結單' where orderid='{label5.Text}'", con);
                    cmdd.ExecuteNonQuery();
                    SqlCommand cmd81 = new SqlCommand($"update ask set qtyleft=qtyleft-'{textBox2.Text}' where orderid='{label5.Text}'", con);
                    cmd81.ExecuteNonQuery();
                    SqlCommand cmd9 = new SqlCommand("insert into inlog (inid,vendor,material,product,format,indate,inqty,leftqty,inmoney) values (@單號,@廠商,@材質,@品名,@規格,@進貨日,@進量,@剩量,@進錢)", con);
                    cmd9.Parameters.Add("@單號", SqlDbType.NVarChar, 50).Value = label5.Text;
                    cmd9.Parameters.Add("@廠商", SqlDbType.NVarChar, 50).Value = label7.Text;
                    cmd9.Parameters.Add("@材質", SqlDbType.NVarChar, 50).Value = label8.Text;
                    cmd9.Parameters.Add("@品名", SqlDbType.NVarChar, 50).Value = label9.Text;
                    cmd9.Parameters.Add("@規格", SqlDbType.NVarChar, 50).Value = label10.Text;
                    cmd9.Parameters.Add("@進貨日", SqlDbType.NVarChar, 50).Value = dateTimePicker1.Value.ToShortDateString();
                    cmd9.Parameters.Add("@進量", SqlDbType.Float).Value = textBox2.Text;
                    cmd9.Parameters.Add("@剩量", SqlDbType.Float).Value = float.Parse(label6.Text) - float.Parse(textBox2.Text);
                    cmd9.Parameters.Add("@進錢", SqlDbType.Float).Value = label11.Text;
                    cmd9.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show($"單號 {label5.Text} 已結單");
                }

            }
            else
            {
                try
                {
                    SqlConnection conn = new SqlConnection(三進原料.cn);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand($"update ask set qtyleft=qtyleft-'{textBox2.Text}' where orderid='{label5.Text}'", conn);
                    cmd.ExecuteNonQuery();
                    SqlCommand cmd1 = new SqlCommand("insert into inlog (inid,vendor,material,product,format,indate,inqty,leftqty,inmoney) values (@單號,@廠商,@材質,@品名,@規格,@進貨日,@進量,@剩量,@進錢)", conn);
                    cmd1.Parameters.Add("@單號", SqlDbType.NVarChar, 50).Value = label5.Text;
                    cmd1.Parameters.Add("@廠商", SqlDbType.NVarChar, 50).Value = label7.Text;
                    cmd1.Parameters.Add("@材質", SqlDbType.NVarChar, 50).Value = label8.Text;
                    cmd1.Parameters.Add("@品名", SqlDbType.NVarChar, 50).Value = label9.Text;
                    cmd1.Parameters.Add("@規格", SqlDbType.NVarChar, 50).Value = label10.Text;
                    cmd1.Parameters.Add("@進貨日", SqlDbType.NVarChar, 50).Value = dateTimePicker1.Value.ToShortDateString();
                    cmd1.Parameters.Add("@進量", SqlDbType.Float).Value = textBox2.Text;
                    cmd1.Parameters.Add("@剩量", SqlDbType.Float).Value = float.Parse(label6.Text) - float.Parse(textBox2.Text);
                    cmd1.Parameters.Add("@進錢", SqlDbType.Float).Value = label11.Text;
                    cmd1.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("成功");
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text == "")
                {
                    textBox2.Focus();
                }
                else
                {
                    label11.Text = (float.Parse(textBox2.Text) * float.Parse(textBox3.Text)).ToString();
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

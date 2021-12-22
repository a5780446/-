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
    public partial class 核准 : Form
    {
        public 核准()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("請填購買量");
                    textBox1.Focus();
                }
                else if (comboBox2.Text == "")
                {
                    MessageBox.Show("請填審核人");
                    comboBox2.Focus();
                }
                else
                {
                    DialogResult z;
                    z = MessageBox.Show("確認後不可再做修改,確定送出?", "警告", MessageBoxButtons.YesNo);
                    if (z == DialogResult.Yes)
                    {
                        SqlConnection conn = new SqlConnection(三進原料.cn);
                        conn.Open();
                        SqlCommand cmd = new SqlCommand($"update ask set orderid='F'+'{三進原料.product}', state=N'已核',qty={textBox1.Text},buyunit=N'{comboBox1.Text}',needdate='{dateTimePicker1.Value.ToShortDateString()}',name=N'{comboBox2.Text}',qtyleft={textBox1.Text} where orderid='{三進原料.product}'", conn);
                        cmd.ExecuteNonQuery();
                        SqlCommand cmd1 = new SqlCommand("insert into inlog (inid,vendor,material,product,format,leftqty,indate,totalprice) values (@單號,@廠商,@材質,@品名,@規格,@剩量,@修改日期,@總價)", conn);
                        cmd1.Parameters.Add("@單號", SqlDbType.NVarChar, 50).Value = "F" + label4.Text;
                        cmd1.Parameters.Add("@廠商", SqlDbType.NVarChar, 50).Value = label6.Text;
                        cmd1.Parameters.Add("@材質", SqlDbType.NVarChar, 50).Value = label7.Text;
                        cmd1.Parameters.Add("@品名", SqlDbType.NVarChar, 50).Value = label8.Text;
                        cmd1.Parameters.Add("@規格", SqlDbType.NVarChar, 50).Value = label9.Text;
                        cmd1.Parameters.Add("@剩量", SqlDbType.Float).Value = textBox1.Text;
                        cmd1.Parameters.Add("@修改日期", SqlDbType.NVarChar, 50).Value = dateTimePicker1.Value.ToShortDateString();
                        cmd1.Parameters.Add("@總價", SqlDbType.Float).Value = label12.Text;
                        cmd1.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("提交成功");
                        this.Close();
                    }
                    else
                    {

                    }
                    
                }  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void 核准_Load(object sender, EventArgs e)
        {
            label4.Text = 三進原料.product;
            label6.Text = 三進原料.vendor;
            label7.Text = 三進原料.material;
            label8.Text = 三進原料.produ;
            label9.Text = 三進原料.format;
            panel1.Visible = false;

            SqlConnection conn = new SqlConnection(三進原料.cn);
            conn.Open();
            SqlCommand cmd = new SqlCommand($"select vprice from ask where orderid='{label4.Text}'", conn);
            SqlCommand cmd1 = new SqlCommand($"select price from ask where orderid='{label4.Text}'", conn);
            cmd.ExecuteNonQuery();
            cmd1.ExecuteNonQuery();
            label11.Text = cmd.ExecuteScalar().ToString();
            label12.Text = cmd1.ExecuteScalar().ToString();
            label14.Text = cmd.ExecuteScalar().ToString();
            label15.Text= cmd1.ExecuteScalar().ToString();
            conn.Close();

            label13.Text = (float.Parse(label14.Text) - float.Parse(label15.Text)).ToString();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                {
                    核准_Load(sender, e);
                }
                else
                {
                    label11.Text = (float.Parse(label14.Text) * float.Parse(textBox1.Text)).ToString();
                    label12.Text = (float.Parse(label15.Text) * float.Parse(textBox1.Text)).ToString();
                    label13.Text = (float.Parse(label11.Text) - float.Parse(label12.Text)).ToString();
                }
                
            }
            catch (Exception)
            {

            }
            
        }
    }
}

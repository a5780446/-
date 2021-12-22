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
    public partial class 詢價表 : Form
    {
        public 詢價表()
        {
            InitializeComponent();
        }
        int x=1;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(三進原料.cn);
                conn.Open();
                SqlCommand cmd = new SqlCommand($"insert into ask (orderid,vendor,material,product,format,unit,price,process,askdate,remark,vprice) values (@單號,@廠商,@材質,@品名,@規格,@單位,@價格,@處理,@問日,@備註,@廠價) ", conn);
                cmd.Parameters.Add("@單號", SqlDbType.NVarChar, 50).Value = 三進原料.dt +"-"+ x.ToString();
                cmd.Parameters.Add("@廠商", SqlDbType.NVarChar, 50).Value = textBox1.Text;
                cmd.Parameters.Add("@材質", SqlDbType.NVarChar, 50).Value = comboBox1.Text;
                cmd.Parameters.Add("@品名", SqlDbType.NVarChar, 50).Value = comboBox2.Text;
                cmd.Parameters.Add("@規格", SqlDbType.NVarChar, 50).Value = textBox4.Text;
                cmd.Parameters.Add("@單位", SqlDbType.NVarChar, 50).Value = comboBox3.Text;
                cmd.Parameters.Add("@價格", SqlDbType.Float).Value = textBox3.Text;
                cmd.Parameters.Add("@處理", SqlDbType.NVarChar, 50).Value = textBox2.Text;
                cmd.Parameters.Add("@問日", SqlDbType.NVarChar, 50).Value = dateTimePicker1.Value.ToShortDateString();
                cmd.Parameters.Add("@備註", SqlDbType.NVarChar, 50).Value = richTextBox1.Text;
                cmd.Parameters.Add("@廠價", SqlDbType.Float).Value = textBox5.Text;
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("新增成功");
                this.Close();
               
            }
            
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                x += 1;
            }
            //x += 1;
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 詢價表_Load(object sender, EventArgs e)
        {
            label10.Text = x.ToString();
        }
    }
}

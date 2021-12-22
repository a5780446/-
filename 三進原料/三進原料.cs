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
    public partial class 三進原料 : Form
    {
        public 三進原料()
        {
            InitializeComponent();
        }

        廠商新增 f1;
        詢價表 f2;
        認證 f3;
        進貨表 f4;
        比價系統 f5;
        詳情 f6;
        合約號輸入 f7;
        進貨紀錄 f8;
        價格更新 f9;
        廠商歷史價格 f10;
        廠商資料修改 f11;
        public static string dt = "";
        public static string product;  //單號
        public static string material;
        public static string format;
        public static string produ;
        public static string vendor;
        public static string page;
        public static string nowtime;
        public static string vv;
        public static string gg;
        

        public static string cn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\as05\Desktop\三進原料\三進原料\bin\Debug\sanjinuse.mdf;Integrated Security=True;Connect Timeout=30";
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            dataGridView1.Enabled = true;
            panel1.Visible = false;
            button4.Visible = false;
            button5.Enabled = false;
            歷史紀錄ToolStripMenuItem.Enabled = false;
            鐵材進貨ToolStripMenuItem.Enabled = false;
            panel2.Visible = false;
            panel3.Visible = false;


            string y;
            y = DateTime.Now.ToShortDateString();
            string[] z = y.Split('/');
            foreach (var item in z)
            {
                dt += item;
            }

            //-------------
            DateTime mytime = DateTime.Now;
            label7.Text = mytime.ToString("yyyy/MM");
            nowtime = label7.Text;
            label7.Visible = true;

        }

        private void toolStripButton1_Click(object sender, EventArgs e)  //功能-->廠商資料
        {
            dataGridView1.Visible = true;
            toolStripButton1.BackColor = Color.Aqua;
            toolStripButton2.BackColor = Color.WhiteSmoke;
            toolStripButton3.BackColor = Color.WhiteSmoke;
            toolStripButton4.BackColor = Color.WhiteSmoke;
            toolStripButton5.BackColor = Color.WhiteSmoke;
            panel1.Visible = true;
            panel2.Visible = false;
            button4.Visible = true;
            button4.Text = "更新價格";
            label1.Text = "廠商資料";
            page = label1.Text;
            label8.Text = "";
            label9.Text = "";
            歷史紀錄ToolStripMenuItem.Enabled = false;
            鐵材進貨ToolStripMenuItem.Enabled = false;
            價格更新紀錄ToolStripMenuItem.Enabled = true;
            button2.Enabled = true;
            button2.Text = "修改";
            label2.Text = "";
            //連結SQL 查詢廠商table
            SqlConnection conn = new SqlConnection(cn);
            SqlDataAdapter da = new SqlDataAdapter("select number as '統一編號', nikename as '廠商',nowprice as 'SPHC',nowsus as'SUS',tel as '連絡電話',firstconn as '主要聯絡人',secconn as '第二聯絡人',adress as '公司地址',remark as '備註' from vendor", conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            
        }

        

        private void toolStripButton2_Click(object sender, EventArgs e) //功能-->詢價表
        {
            toolStripButton2.BackColor = Color.Aqua;
            toolStripButton1.BackColor = Color.WhiteSmoke;
            toolStripButton3.BackColor = Color.WhiteSmoke;
            toolStripButton4.BackColor = Color.WhiteSmoke;
            toolStripButton5.BackColor = Color.WhiteSmoke;
            label1.Text = "詢價表";
            page = label1.Text;
            歷史紀錄ToolStripMenuItem.Enabled = false;
            鐵材進貨ToolStripMenuItem.Enabled = false;
            價格更新紀錄ToolStripMenuItem.Enabled = false;
            button2.Text = "修改";
            button4.Text = "核可";
            label8.Text = "";
            label9.Text = "";
            panel1.Visible = true;
            button1.Enabled = true;
            button4.Visible = true;
            button5.Enabled = false;
            button2.Enabled = true;
            dataGridView1.Visible = true;
            panel2.Visible = false;
            label2.Text = "";
            //連結SQL 查詢 詢價表table
            SqlConnection conn = new SqlConnection(cn);
            SqlDataAdapter da = new SqlDataAdapter("select orderid as 'ID',vendor as '廠商',material as '材質',product as '品名',format as '規格',unit as '單位',price as '價格',askdate as '洽詢日',state as '狀態' from ask where state= N'未核' order by askdate DESC", conn);
            //SqlDataAdapter da = new SqlDataAdapter($"select orderid as 'ID',vendor as '廠商',material as '材質',product as '品名',format as '規格',unit as '單位',price as '價格',askdate as '洽詢日',state as '狀態' from ask where askdate like N'%{label7.Text}%' order by askdate DESC", conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

        }

        private void toolStripButton3_Click(object sender, EventArgs e)  //功能-->合約表
        {
            toolStripButton3.BackColor = Color.Aqua;
            toolStripButton2.BackColor = Color.WhiteSmoke;
            toolStripButton1.BackColor = Color.WhiteSmoke;
            toolStripButton4.BackColor = Color.WhiteSmoke;
            toolStripButton5.BackColor = Color.WhiteSmoke;
            label1.Text = "合約表";
            page = label1.Text;
            label8.Text = "";
            label9.Text = "";
            歷史紀錄ToolStripMenuItem.Enabled = false;
            鐵材進貨ToolStripMenuItem.Enabled = false;
            價格更新紀錄ToolStripMenuItem.Enabled = false;
            button2.Text = "修改合約號";
            panel1.Visible = true;
            button4.Visible = false;
            button1.Enabled = false;
            button5.Enabled = false;
            button2.Enabled = true;
            dataGridView1.Visible = true;
            panel2.Visible = false;
            label2.Text = "";
            try
            {
                SqlConnection conn = new SqlConnection(cn);
                SqlDataAdapter da = new SqlDataAdapter("select orderid as 'ID',vendor as '廠商',material as '材質',product as '品名',format as '規格',qty as '寄庫量',buyunit as '單位',price as '價格',agreement as '合約' from ask where state = N'已核' order by needdate DESC", conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        private void toolStripButton4_Click(object sender, EventArgs e)  //功能-->寄庫出貨
        {
            dataGridView1.Visible = true;
            toolStripButton4.BackColor = Color.Aqua;
            toolStripButton2.BackColor = Color.WhiteSmoke;
            toolStripButton3.BackColor = Color.WhiteSmoke;
            toolStripButton1.BackColor = Color.WhiteSmoke;
            toolStripButton5.BackColor = Color.WhiteSmoke;
            button5.Enabled = true;
            button2.Enabled = false;
            button4.Visible = false;
            panel2.Visible = true;
            label8.Text = "";
            label9.Text = "";
            歷史紀錄ToolStripMenuItem.Enabled = true;
            鐵材進貨ToolStripMenuItem.Enabled = true;
            價格更新紀錄ToolStripMenuItem.Enabled = false;
            label1.Text = "寄庫出貨";
            label2.Text = "";
            SqlConnection conn = new SqlConnection(cn);
            SqlDataAdapter da = new SqlDataAdapter("select orderid as 'ID',vendor as '廠商',material as '材質',product as '品名',format as '規格',buyunit as '單位',price as '價格',qtyleft as '寄庫餘量',state as '狀態' from ask where state = N'已核'", conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void toolStripButton5_Click(object sender, EventArgs e)  //功能-->比價系統
        {
            label1.Text = "比價";
            label8.Text = "";
            label9.Text = "";
            label2.Text = "";
            f5 = new 比價系統();
            f5.Show();
        }

        private void button1_Click(object sender, EventArgs e) //按鈕-->新增
        {
            
            if (label1.Text=="廠商資料")
            {
                f1 = new 廠商新增();
                f1.Show();
            }
            if(label1.Text=="詢價表")
            {
                f2 = new 詢價表();
                f2.Show();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)  //按鈕-->修改
        {
            if (label1.Text == "廠商資料")
            {
                f11 = new 廠商資料修改();
                f11.Show();
            }
            if (label1.Text == "詢價表")
            {
                dataGridView1.ReadOnly = false; //變更至可修改模式
            }
            if (label1.Text == "合約表")
            {
                if (label2.Text == "")
                {
                    MessageBox.Show("未選擇項目");
                }
                else
                {
                    f7 = new 合約號輸入();
                    f7.Show();
                }
                
            }
        }

        private void button3_Click(object sender, EventArgs e)  //按鈕-->刪除
        {
            DialogResult r;
            if (label1.Text == "廠商資料")
            {
                r = MessageBox.Show("刪除廠商相關資料?", "移除", MessageBoxButtons.OKCancel);
                if (r == DialogResult.OK)
                {
                    SqlConnection conn = new SqlConnection();
                    conn.ConnectionString = cn;
                    conn.Open();
                    SqlCommand cmd = new SqlCommand($"delete from vendor where number=N'{label8.Text}' ", conn);
                    SqlCommand cmd1 = new SqlCommand($"delete from  upprice where vname=N'{label9.Text}' ", conn);
                    cmd.ExecuteNonQuery();
                    cmd1.ExecuteNonQuery();
                    conn.Close();
                    Form1_Load(sender, e);
                }
            }
            else
            {
                r = MessageBox.Show("確定刪除本筆資料", "移除", MessageBoxButtons.OKCancel);
                if (r == DialogResult.OK)
                {
                    SqlConnection conn = new SqlConnection();
                    conn.ConnectionString = cn;
                    conn.Open();
                    SqlCommand cmd = new SqlCommand($"delete from ask where orderid=N'{product}' ", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Form1_Load(sender, e);
                }

            }
        }

        private void button4_Click(object sender, EventArgs e) //按鈕-->核可/價格更新
        {
            if (label1.Text == "廠商資料")
            {
                f9 = new 價格更新();
                f9.Show();
            }
            else
            {
                f3 = new 認證();
                f3.Show();
            }
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) 
        {
            if (label1.Text == "廠商資料")
            {
                try
                {
                    vv = dataGridView1.Rows[e.RowIndex].Cells["統一編號"].Value.ToString();
                    label8.Text = vv;
                    gg = dataGridView1.Rows[e.RowIndex].Cells["廠商"].Value.ToString();
                    label9.Text = gg;
                }
                catch(Exception ex)
                {

                }
                

            }
            else
            {
                try
                {
                    product = dataGridView1.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                    label2.Text = product;
                    produ = dataGridView1.Rows[e.RowIndex].Cells["品名"].Value.ToString();
                    label3.Text = produ;
                    vendor = dataGridView1.Rows[e.RowIndex].Cells["廠商"].Value.ToString();
                    label4.Text = vendor;
                    material = dataGridView1.Rows[e.RowIndex].Cells["材質"].Value.ToString();
                    label5.Text = material;
                    format = dataGridView1.Rows[e.RowIndex].Cells["規格"].Value.ToString();
                    label6.Text = format;

                }
                catch (Exception ex)
                {

                }
            }
            
        }

        private void 詳情ToolStripMenuItem_Click(object sender, EventArgs e) //右建--詳情
        {
            if (label2.Text != "")
            {
                f6 = new 詳情();
                f6.Show();
            }
            else
            {
                MessageBox.Show("未選擇項目");
            }
                
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (label2.Text != "")
            {
                f4 = new 進貨表();
                f4.Show();
                dataGridView1.Enabled = false;
                button6.BackColor = Color.Red;
            }
            else
            {
                MessageBox.Show("未選擇項目");
            }
            
        }

        private void button6_Click(object sender, EventArgs e)  //解鎖鍵
        {
            dataGridView1.Enabled = true;
            button6.BackColor = Color.Transparent;
        }

        private void 鐵材進貨ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (label2.Text != "")
            {
                f4 = new 進貨表();
                f4.Show();
                dataGridView1.Enabled = false;
            }
            else
            {
                MessageBox.Show("未選擇項目");
            }
        }

        private void 歷史紀錄ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (label2.Text != "")
            {
                f8 = new 進貨紀錄();
                f8.Show();
            }
            else
            {
                MessageBox.Show("未選擇項目");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                SqlConnection conn = new SqlConnection(cn);
                SqlDataAdapter da = new SqlDataAdapter("select orderid as 'ID',vendor as '廠商',material as '材質',product as '品名',format as '規格',buyunit as '單位',price as '價格',qtyleft as '寄庫餘量',state as '狀態' from ask where state = N'已核' or state= N'已結單'", conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                SqlConnection conn = new SqlConnection(cn);
                SqlDataAdapter da = new SqlDataAdapter("select orderid as 'ID',vendor as '廠商',material as '材質',product as '品名',format as '規格',buyunit as '單位',price as '價格',qtyleft as '寄庫餘量',state as '狀態' from ask where state = N'已核'", conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (label1.Text == "詢價表")
                {
                    if (comboBox1.Text == "依廠商")
                    {
                        SqlConnection conn = new SqlConnection(cn);
                        SqlDataAdapter da = new SqlDataAdapter($"select orderid as 'ID',vendor as '廠商',material as '材質',product as '品名',format as '規格',unit as '單位',price as '價格',askdate as '洽詢日',state as '狀態' from ask where vendor like N'%{textBox1.Text}%' and state=N'未核' order by askdate DESC", conn);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                    else if (comboBox1.Text == "依材質")
                    {
                        SqlConnection conn = new SqlConnection(cn);
                        SqlDataAdapter da = new SqlDataAdapter($"select orderid as 'ID',vendor as '廠商',material as '材質',product as '品名',format as '規格',unit as '單位',price as '價格',askdate as '洽詢日',state as '狀態' from ask where material like N'%{textBox1.Text}%' and state=N'未核' order by askdate DESC", conn);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                    else
                    {
                        SqlConnection conn = new SqlConnection(cn);
                        SqlDataAdapter da = new SqlDataAdapter($"select orderid as 'ID',vendor as '廠商',material as '材質',product as '品名',format as '規格',unit as '單位',price as '價格',askdate as '洽詢日',state as '狀態' from ask where askdate like N'%{textBox1.Text}%' and state=N'未核' order by askdate DESC", conn);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                }
                if (label1.Text == "合約表")
                {
                    if (comboBox1.Text == "依廠商")
                    {
                        SqlConnection conn = new SqlConnection(cn);
                        SqlDataAdapter da = new SqlDataAdapter($"select orderid as 'ID',vendor as '廠商',material as '材質',product as '品名',format as '規格',qty as '寄庫量',buyunit as '單位',price as '價格',agreement as '合約' from ask where vendor like N'%{textBox1.Text}%' and state=N'已核' order by askdate DESC", conn);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                    else if (comboBox1.Text == "依材質")
                    {
                        SqlConnection conn = new SqlConnection(cn);
                        SqlDataAdapter da = new SqlDataAdapter($"select orderid as 'ID',vendor as '廠商',material as '材質',product as '品名',format as '規格',qty as '寄庫量',buyunit as '單位',price as '價格',agreement as '合約' from ask where material like N'%{textBox1.Text}%' and state=N'已核' order by askdate DESC", conn);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                    else
                    {
                        SqlConnection conn = new SqlConnection(cn);
                        SqlDataAdapter da = new SqlDataAdapter($"select orderid as 'ID',vendor as '廠商',material as '材質',product as '品名',format as '規格',qty as '寄庫量',buyunit as '單位',price as '價格',agreement as '合約' from ask where askdate like N'%{textBox1.Text}%' and state=N'已核' order by askdate DESC", conn);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                }
                if (label1.Text == "寄庫出貨")
                {
                    if (comboBox1.Text == "依廠商")
                    {
                        SqlConnection conn = new SqlConnection(cn);
                        SqlDataAdapter da = new SqlDataAdapter($"select orderid as 'ID',vendor as '廠商',material as '材質',product as '品名',format as '規格',buyunit as '單位',price as '價格',qtyleft as '寄庫餘量',state as '狀態' from ask where vendor like N'%{textBox1.Text}%' and state=N'已核' order by askdate DESC", conn);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                    else if (comboBox1.Text == "依材質")
                    {
                        SqlConnection conn = new SqlConnection(cn);
                        SqlDataAdapter da = new SqlDataAdapter($"select orderid as 'ID',vendor as '廠商',material as '材質',product as '品名',format as '規格',buyunit as '單位',price as '價格',qtyleft as '寄庫餘量',state as '狀態' from ask where material like N'%{textBox1.Text}%' and state=N'已核' order by askdate DESC", conn);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                    else
                    {
                        SqlConnection conn = new SqlConnection(cn);
                        SqlDataAdapter da = new SqlDataAdapter($"select orderid as 'ID',vendor as '廠商',material as '材質',product as '品名',format as '規格',buyunit as '單位',price as '價格',qtyleft as '寄庫餘量',state as '狀態' from ask where askdate like N'%{textBox1.Text}%' and state=N'已核' order by askdate DESC", conn);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            


        }

        private void 價格更新紀錄ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (label9.Text != "")
            {
                f10 = new 廠商歷史價格();
                f10.Show();
            }
            else
            {
                MessageBox.Show("未選擇項目");
            }
        }
    }
}

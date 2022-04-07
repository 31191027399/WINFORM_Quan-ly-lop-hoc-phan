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

namespace Timkiemlophocphan
{
    public partial class Form1 : Form
    {
        public static string un;
        public string username;
        public string alias;
        public static Form1 me;
        public TextBox tb1, tb2;
        String str = @"Data Source=DESKTOP-J79GQJ1\SQLEXPRESS;Initial Catalog=QLSVtrang;Integrated Security=True";// Đổi chuỗi connect
        SqlConnection con = null;

        string suffer = @" SELECT DISTINCT @X FROM (SELECT E.bachoc,E.tenkh,E.tenng,E.tenct,E.namvao,E.malophoc,E.tenmon FROM (SELECT D.*,MH.tenmon FROM MONHOC AS MH 
RIGHT JOIN (SELECT C.*,LHP.malophp,LHP.mamon FROM  LOPHOCPHAN AS LHP RIGHT JOIN (SELECT B.*, LH.malophoc,LH.namvao  FROM LOPHOC AS LH RIGHT JOIN (SELECT A.*,NG.tenng
FROM NGANH AS NG RIGHT JOIN (SELECT CT.*,K.tenkh FROM KHOA AS K RIGHT JOIN CHUONGTRINH AS CT ON CT.makh=K.makh) AS A ON A.mang=NG.mang) AS B on B.mact=LH.mact) AS C
ON C.malophoc=LHP.malophoc) AS D ON D.mamon=MH.mamon) AS E) as I WHERE @X IS NOT NULL";
        string timmahp= @"SELECT E.malophp FROM (SELECT D.*,MH.tenmon FROM MONHOC AS MH 
RIGHT JOIN (SELECT C.*,LHP.malophp,LHP.mamon FROM  LOPHOCPHAN AS LHP RIGHT JOIN (SELECT B.*, LH.malophoc,LH.namvao  FROM LOPHOC AS LH RIGHT JOIN (SELECT A.*,NG.tenng
FROM NGANH AS NG RIGHT JOIN (SELECT CT.*,K.tenkh FROM KHOA AS K RIGHT JOIN CHUONGTRINH AS CT ON CT.makh=K.makh) AS A ON A.mang=NG.mang) AS B on B.mact=LH.mact) AS C
ON C.malophoc=LHP.malophoc) AS D ON D.mamon=MH.mamon) AS E WHERE E.bachoc=N'@M' AND E.tenkh=N'@N' AND E.tenng=N'@P' AND E.tenct=N'@Q' AND E.namvao=N'@H' AND E.malophoc=N'@K' AND E.tenmon=N'@O'";
        String[] tenbien = { "bachoc", "tenkh", "tenng", "tenct", "namvao", "malophoc", "tenmon" };


        string[] dieukien = new string[7];
        int sodieukien = 0;




        public Form1()
        {


            InitializeComponent();
            me = this;
            tb1 = textBox1;
            tb2 = textBox2;

        }


        public void comboBox3_DropDown(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            if (con == null)
            { con = new SqlConnection(str); }
            if (con.State == ConnectionState.Closed)
            { con.Open(); }
            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = con;
            cmd1.CommandText = suffer.Replace("@X", tenbien[0]);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            while (dr1.Read())
            { comboBox3.Items.Add(dr1.GetString(0)); }
            dr1.Close();
            comboBox4.Items.Clear();
            comboBox5.Items.Clear();
            comboBox6.Items.Clear();
            comboBox6.Items.Clear();
            comboBox7.Items.Clear();
            comboBox8.Items.Clear();
            comboBox9.Items.Clear();



        }

        public void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            dieukien[0] = comboBox3.SelectedItem.ToString();
            comboBox4.Items.Clear();
            if (con == null)
            { con = new SqlConnection(str); }
            if (con.State == ConnectionState.Closed)
            { con.Open(); }
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con;
            cmd2.CommandText = suffer.Replace("@X", tenbien[1])
                + " AND " + tenbien[0] + "=N'" + comboBox3.SelectedItem.ToString() + "'";
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            { comboBox4.Items.Add(dr2.GetString(0)); }
            dr2.Close();

        }

        public void ComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            dieukien[1] = comboBox4.SelectedItem.ToString();
            comboBox5.Items.Clear();
            if (con == null)
            { con = new SqlConnection(str); }
            if (con.State == ConnectionState.Closed)
            { con.Open(); }
            SqlCommand cmd3 = new SqlCommand();
            cmd3.Connection = con;
            cmd3.CommandText = suffer.Replace("@X", tenbien[2])
                + " AND " + tenbien[0] + "=N'" + comboBox3.SelectedItem.ToString() + "'"
                + " AND " + tenbien[1] + "=N'" + comboBox4.SelectedItem.ToString() + "'";
            SqlDataReader dr3 = cmd3.ExecuteReader();
            while (dr3.Read())
            { comboBox5.Items.Add(dr3.GetString(0)); }
            dr3.Close();
        }

        public void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            dieukien[2] = comboBox5.SelectedItem.ToString();
            comboBox6.Items.Clear();
            if (con == null)
            { con = new SqlConnection(str); }
            if (con.State == ConnectionState.Closed)
            { con.Open(); }
            SqlCommand cmd4 = new SqlCommand();
            cmd4.Connection = con;
            cmd4.CommandText = suffer.Replace("@X", tenbien[3])
                + " AND " + tenbien[0] + "=N'" + comboBox3.SelectedItem.ToString() + "'"
                + " AND " + tenbien[1] + "=N'" + comboBox4.SelectedItem.ToString() + "'"
                + " AND " + tenbien[2] + "=N'" + comboBox5.SelectedItem.ToString() + "'";
            SqlDataReader dr4 = cmd4.ExecuteReader();
            while (dr4.Read())
            { comboBox6.Items.Add(dr4.GetString(0)); }
            dr4.Close();
        }

        public void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            dieukien[3] = comboBox6.SelectedItem.ToString();
            comboBox7.Items.Clear();
            if (con == null)
            { con = new SqlConnection(str); }
            if (con.State == ConnectionState.Closed)
            { con.Open(); }
            SqlCommand cmd5 = new SqlCommand();
            cmd5.Connection = con;
            cmd5.CommandText = suffer.Replace("@X", tenbien[4])
                + " AND " + tenbien[0] + "=N'" + comboBox3.SelectedItem.ToString() + "'"
                + " AND " + tenbien[1] + "=N'" + comboBox4.SelectedItem.ToString() + "'"
                + " AND " + tenbien[2] + "=N'" + comboBox5.SelectedItem.ToString() + "'"
                + " AND " + tenbien[3] + "=N'" + comboBox6.SelectedItem.ToString() + "'";
            SqlDataReader dr5 = cmd5.ExecuteReader();
            while (dr5.Read())
            { comboBox7.Items.Add(dr5.GetInt32(0)); }
            dr5.Close();
            
            
        }

        public void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            dieukien[4] = comboBox7.SelectedItem.ToString();
            comboBox8.Items.Clear();
            if (con == null)
            { con = new SqlConnection(str); }
            if (con.State == ConnectionState.Closed)
            { con.Open(); }
            SqlCommand cmd6 = new SqlCommand();
            cmd6.Connection = con;
            cmd6.CommandText = suffer.Replace("@X", tenbien[5])
                + " AND " + tenbien[0] + "=N'" + comboBox3.SelectedItem.ToString() + "'"
                + " AND " + tenbien[1] + "=N'" + comboBox4.SelectedItem.ToString() + "'"
                + " AND " + tenbien[2] + "=N'" + comboBox5.SelectedItem.ToString() + "'"
                + " AND " + tenbien[3] + "=N'" + comboBox6.SelectedItem.ToString() + "'"
                + " AND " + tenbien[4] + "=N'" + comboBox7.SelectedItem.ToString() + "'";
            SqlDataReader dr6 = cmd6.ExecuteReader();
            while (dr6.Read())
            { comboBox8.Items.Add(dr6.GetString(0)); }
            dr6.Close();
           
        }

        public void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            dieukien[5] = comboBox8.SelectedItem.ToString();
            comboBox9.Items.Clear();
            if (con == null)
            { con = new SqlConnection(str); }
            if (con.State == ConnectionState.Closed)
            { con.Open(); }
            SqlCommand cmd7 = new SqlCommand();
            cmd7.Connection = con;
            cmd7.CommandText = suffer.Replace("@X", tenbien[6])
                + " AND " + tenbien[0] + "=N'" + comboBox3.SelectedItem.ToString() + "'"
                + " AND " + tenbien[1] + "=N'" + comboBox4.SelectedItem.ToString() + "'"
                + " AND " + tenbien[2] + "=N'" + comboBox5.SelectedItem.ToString() + "'"
                + " AND " + tenbien[3] + "=N'" + comboBox6.SelectedItem.ToString() + "'"
                + " AND " + tenbien[4] + "=N'" + comboBox7.SelectedItem.ToString() + "'"
                + " AND " + tenbien[4] + "=N'" + comboBox7.SelectedItem.ToString() + "'";
            SqlDataReader dr7 = cmd7.ExecuteReader();
            while (dr7.Read())
            { comboBox9.Items.Add(dr7.GetString(0)); }
            dr7.Close();
            
        }
        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            dieukien[6] = (string)comboBox9.SelectedItem.ToString();
        }



     

        private void button1_Click(object sender, EventArgs e)
        {
            if (con == null)
            { con = new SqlConnection(str); }
            if (con.State == ConnectionState.Closed)
            { con.Open(); }
            SqlCommand cmdform1 = new SqlCommand();
            cmdform1.Connection = con;
            //MessageBox.Show("USE QLSVtrang SELECT malophp FROM LOPHOCPHAN WHERE malophp=N'" + Form1.me.textBox2.Text );
            cmdform1.CommandText = @"SELECT malophp FROM LOPHOCPHAN WHERE malophp=N'" + Form1.me.textBox2.Text + "'";
            SqlDataReader reader1 = cmdform1.ExecuteReader();
            if (reader1.Read())
            {
                //findForm("Form3");
                Form3 f = new Form3();
                // f.MdiParent = me;
                f.Show();
            }
            else
            { MessageBox.Show("Vui lòng nhập Mã lớp học phần phù hợp"); };
            reader1.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (con == null)
            { con = new SqlConnection(str); }
            if (con.State == ConnectionState.Closed)
            { con.Open(); }
            SqlCommand cmdhp = new SqlCommand();
            cmdhp.Connection = con;
            cmdhp.CommandText = timmahp.Replace("@M", dieukien[0]).Replace("@N", dieukien[1]).Replace("@P", dieukien[2]).Replace("@Q", dieukien[3]).Replace("@H", dieukien[4]).Replace("@K", dieukien[5]).Replace("@O",dieukien[6]);
     
           SqlDataReader readerhp = cmdhp.ExecuteReader();
            if (readerhp.Read())
            {
                Form1.me.textBox2.Text = readerhp.GetString(0);

            }
            else { MessageBox.Show("Không tìm được mã học phần"); }
            readerhp.Close();
        }


        public void button3_Click(object sender, EventArgs e)
        {
            if (con == null)
            { con = new SqlConnection(str); }
            if (con.State == ConnectionState.Closed)
            { con.Open(); }
            SqlCommand cmdform = new SqlCommand();
            cmdform.Connection = con;
            cmdform.CommandText = @"SELECT masv FROM SINHVIEN WHERE masv=N'" + Form1.me.textBox1.Text + "'";
            SqlDataReader reader = cmdform.ExecuteReader();
            if (reader.Read())
            {
                //findForm("Form2");
                Form2 f = new Form2();
               // f.MdiParent = me;
                f.Show();
            }
            else
            { MessageBox.Show("Vui lòng nhập MSSV phù hợp"); };
            reader.Close();




        }

        /*public Form findForm(string formName)
        {
            Form foundform = null;
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == formName)
                {
                    foundform = f;
                    break;
                }
            }
            return foundform;
        }*/


    }
}




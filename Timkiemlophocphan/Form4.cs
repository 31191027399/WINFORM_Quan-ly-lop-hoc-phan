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
    public partial class Form4 : Form
    {
        String str = @"Data Source=DESKTOP-J79GQJ1\SQLEXPRESS;Initial Catalog=QLSVtrang;Integrated Security=True";
        SqlConnection con = null;
        string timdulieu=@"SELECT tensv,malophoc,email,sdt FROM SINHVIEN WHERE masv=N'@Y'";
        string dkthemsinhvien = @"SELECT C.masv,C.malophp FROM (SELECT B.*,LHP.sohk,LHP.malophp FROM LOPHOCPHAN AS LHP RIGHT JOIN (SELECT A.*,CTMH.mamon
                                FROM CHUONGTRINHMONHOC AS CTMH RIGHT JOIN 
                                (SELECT SV.masv,SV.malophoc,LH.mact  FROM LOPHOC AS LH RIGHT JOIN SINHVIEN AS SV ON SV.malophoc=LH.malophoc) AS A
                                ON CTMH.mact=A.mact) AS B ON LHP.mamon=B.mamon) AS C WHERE C.masv=N'@X' AND C.malophp=N'@Y'" ;


        public Form4()
        {
            InitializeComponent();
            
        }

   

        private void textBox5_TextChanged_1(object sender, EventArgs e)
        {
            if (con == null)
            { con = new SqlConnection(str); }
            if (con.State == ConnectionState.Closed)
            { con.Open(); }
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = timdulieu.Replace("@Y", textBox5.Text.ToString());
            SqlDataReader dr8 = cmd.ExecuteReader();

            while (dr8.Read())
            {
                textBox6.Text = dr8.GetString(0);
                textBox7.Text = dr8.GetString(1);
                textBox8.Text = dr8.GetString(2);
                textBox1.Text = dr8.GetString(3);

            }


            dr8.Close();

        }
        //public void Dieukienthemsinhvien()
        //  {

        //  }
        //  private void button1_Click(object sender, EventArgs e)
        //  { MessageBox.Show("" + Form3.me.dgv1.Rows.Count);
        //  //    if( Form3.me.dgv1.Rows.Count >4)
        //  //    {
        //  //        if (con == null)
        //  //        { con = new SqlConnection(str); }
        //  //        if (con.State == ConnectionState.Closed)
        //  //        { con.Open(); }
        //  //        SqlCommand cmd1 = new SqlCommand();
        //  //        cmd1.Connection = con;
        //  //        cmd1.CommandText = dkthemsinhvien.Replace("@X", textBox6.Text.ToString()).Replace("@Y", Form3.me.tb1.Text.ToString());
        //  //        SqlDataReader dr1 = cmd1.ExecuteReader();
        //  //        if (dr1.Read())
        //  //        { MessageBox.Show("Hihi"); }
        //  //    }
        //  }
    }
}

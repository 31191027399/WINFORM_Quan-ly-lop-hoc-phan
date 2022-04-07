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
    public partial class Form2 : Form
    { string sohk;
        
        String str = @"Data Source=DESKTOP-J79GQJ1\SQLEXPRESS;Initial Catalog=QLSVtrang;Integrated Security=True";// Doi chuoi connect
        SqlConnection con = null;
        string thongtinsv = @"SELECT B.masv,B.malophoc,B.tenct,B.tensv FROM (SELECT CT.tenct, A.* FROM CHUONGTRINH AS CT 
                        LEFT JOIN (SELECT LH.*, SV.masv, SV.tensv, SV.sdt FROM SINHVIEN AS SV 
                        RIGHT JOIN LOPHOC AS LH ON SV.malophoc= LH.malophoc) AS A ON CT.mact=A.mact) AS B WHERE B.masv=N'@X'";
        string timsohk = @"SELECT DISTINCT B.sohk FROM 
                        (SELECT A.*,CTMH.sohk FROM CHUONGTRINHMONHOC AS CTMH RIGHT JOIN 
                        (SELECT LHPSV.*,LHP.mamon FROM LOPHOCPHAN AS LHP RIGHT JOIN LOPHOCPHANSINHVIEN AS LHPSV ON LHP.malophp=LHPSV.malophp)
                        AS A ON CTMH.mamon=A.mamon) AS B WHERE B.masv=N'@Y'";
        string thongtinlhp = @"SELECT D.malophp,D.tenmon,D.sotc,D.tengv,D.diem,D.sohk FROM (SELECT C.*, CTMH.sohk FROM CHUONGTRINHMONHOC AS CTMH RIGHT JOIN
                        (SELECT B.*, GV.tengv FROM GIAOVIEN AS GV RIGHT JOIN
                        (SELECT A.*, LHPSV.masv, LHPSV.diem FROM LOPHOCPHANSINHVIEN AS LHPSV  RIGHT JOIN
                        (SELECT LHP.malophp, LHP.malophoc, LHP.mamon, LHP.magv, MH.tenmon, MH.sotc FROM MONHOC AS MH JOIN LOPHOCPHAN AS LHP ON MH.mamon = LHP.mamon)
                            AS A ON LHPSV.malophp = A.malophp) AS B ON GV.magv = B.magv) AS C ON CTMH.mamon=C.mamon) AS D WHERE masv = N'@Z' AND sohk = N'@T'";
        public Form2()
        {
            
            InitializeComponent();
            textBox1.Text = Form1.me.tb1.Text;
            if (con == null)
            { con = new SqlConnection(str); }
            if (con.State == ConnectionState.Closed)
            { con.Open(); }
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = thongtinsv.Replace("@X",textBox1.Text);
            SqlDataReader dr=cmd.ExecuteReader();
            while (dr.Read())
            { textBox2.Text = dr.GetString(1);
            textBox3.Text = dr.GetString(2);
            textBox4.Text = dr.GetString(3);
            }
            dr.Close();
            SqlCommand cmd1=new SqlCommand();
            cmd1.Connection = con;
            cmd1.CommandText = timsohk.Replace("@Y", Form1.me.tb1.Text);
            SqlDataReader dr1=cmd1.ExecuteReader();
            while(dr1.Read())
            { comboBox1.Items.Add(dr1.GetString(0));}
            dr1.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
             sohk=comboBox1.SelectedItem.ToString();
            if (con == null)
            { con = new SqlConnection(str); }
            if (con.State == ConnectionState.Closed)
            { con.Open(); }
            
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con;
            cmd2.CommandText = thongtinlhp.Replace("@Z", Form1.me.tb1.Text).Replace("@T",sohk);
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataTable dt= new DataTable();
            da.Fill(dt);
            dataGridView1.AutoGenerateColumns=false;
            dataGridView1.DataSource = dt;
          
            con.Close();


        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dataGridView1.Rows[e.RowIndex].Cells["STT"].Value = (e.RowIndex+1).ToString();
        }
    }
}

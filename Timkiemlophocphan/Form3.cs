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
    public partial class Form3 : Form
    {
        public static Form3 me;
        String str = @"Data Source=DESKTOP-J79GQJ1\SQLEXPRESS;Initial Catalog=QLSVtrang;Integrated Security=True";
        SqlConnection con = null;
        string thongtinhp = @"
                SELECT C.tenkh,C.tenmon,C.tengv,C.sohk FROM(SELECT B.*,KH.tenkh FROM KHOA AS KH RIGHT JOIN
                (SELECT A.*, MH.tenmon, MH.makh FROM MONHOC AS MH RIGHT JOIN
                (SELECT LHP.*, GV.tengv FROM GIAOVIEN AS GV RIGHT JOIN LOPHOCPHAN AS LHP ON GV.magv = LHP.magv) AS A ON MH.mamon = A.mamon)
                AS B ON KH.makh = B.makh) AS C WHERE C.malophp = N'@M'";
        string thongtinsv = @"SELECT E.masv,E.tensv,E.malophoc,E.email,E.sdt,E.diem FROM (SELECT D.*,SV.tensv,SV.email,SV.sdt FROM SINHVIEN AS SV JOIN 
                (SELECT C.*, LHPSV.masv, LHPSV.diem FROM LOPHOCPHANSINHVIEN AS LHPSV RIGHT JOIN (SELECT B.*,KH.tenkh  FROM KHOA AS KH  RIGHT JOIN 
                (SELECT A.*,MH.tenmon,MH.makh FROM MONHOC AS MH RIGHT JOIN  
                (SELECT LHP.*,GV.tengv FROM GIAOVIEN AS GV RIGHT JOIN LOPHOCPHAN AS LHP ON GV.magv=LHP.magv) AS A ON MH.mamon=A.mamon)
                AS B ON KH.makh=B.makh) AS C ON C.malophp=LHPSV.malophp) AS D ON SV.masv=D.masv) 
                AS E WHERE E.malophp=N'@A' AND E.tenkh=N'@B' AND E.tenmon=N'@C' AND E.tengv=N'@D' AND E.sohk=N'@F'";
        public DataGridView dgv1;
        public TextBox tb1, tb2, tb3, tb4;
        public Form3()
        {
            me = this;
            dgv1 = Form3.me.dataGridView1;
            tb1 = Form3.me.tb1;
            tb2 = Form3.me.tb2;
            tb3 = Form3.me.tb3;
            tb4 = Form3.me.tb4;

            InitializeComponent();
            textBox1.Text = Form1.me.tb2.Text;
            if (con == null)
            { con = new SqlConnection(str); }
            if (con.State == ConnectionState.Closed)
            { con.Open(); }
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = thongtinhp.Replace("@M", textBox1.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textBox2.Text = dr.GetString(0);
                textBox3.Text = dr.GetString(1);
                textBox4.Text = dr.GetString(2);
                textBox5.Text = dr.GetString(3);
            }
            dr.Close();
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con;
            //MessageBox.Show("" + thongtinsv.Replace("@A", textBox1.Text.ToString()).Replace("@B", textBox2.Text.ToString()).Replace("@C", textBox3.Text.ToString()).Replace("@D", textBox4.Text.ToString()).Replace("@F", textBox5.Text.ToString()));
            cmd2.CommandText = thongtinsv.Replace("@A",textBox1.Text.ToString()).Replace("@B",textBox2.Text.ToString()).Replace("@C",textBox3.Text.ToString()).Replace("@D",textBox4.Text.ToString()).Replace("@F",textBox5.Text.ToString());
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dt;

            con.Close();
            
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dataGridView1.Rows[e.RowIndex].Cells["STT"].Value = (e.RowIndex + 1).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Form4 f =new Form4();
            f.Show();
        }
    }
}

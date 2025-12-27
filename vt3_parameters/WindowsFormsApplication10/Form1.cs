using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace WindowsFormsApplication10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int t1, no;
        string t2, t3, t4;
        int i, j;

        OleDbCommand cmd;
        OleDbConnection con;
        OleDbDataAdapter da;
        OleDbDataReader dr;
        DataSet ds;
        DataTable dt;
        OleDbCommandBuilder cb;


        void baglanti()
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.OLedb.12.0;Data Source=vt.accdb");
            da = new OleDbDataAdapter("Select *from [ogrenci]", con);
            con.Open();
            ds = new DataSet();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            con.Close();
            
        }
        void doldur1()
        {
            ds.Clear();
            da.Fill(ds, "ogrenci");
            dataGridView1.DataSource = ds.Tables[0];
            i = ds.Tables["ogrenci"].Rows.Count - 1;

            
        }
        void goster1()
        {
            textBox1.Text = ds.Tables[0].Rows[j][0].ToString();
            textBox2.Text = ds.Tables[0].Rows[j][1].ToString();
            textBox3.Text = ds.Tables[0].Rows[j][2].ToString();
            textBox4.Text = ds.Tables[0].Rows[j][3].ToString();

            dataGridView1.ClearSelection();
            dataGridView1.Rows[j].Selected = true;
            label1.Text = (i + 1).ToString();
            label2.Text = (j + 1).ToString();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            baglanti();
            doldur1();
            j = i;
            goster1();
        }
        void giris()
        {
            t1 = Convert.ToInt32(textBox1.Text);
            t2 = textBox2.Text;
            t3 = textBox3.Text;
            t4 = textBox4.Text;
            
        }
		private void dataGridView1_Click(object sender, EventArgs e)
        {
            no = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            j = dataGridView1.CurrentCell.RowIndex;
            goster1();
        }
        private void button1_Click(object sender, EventArgs e)//ekle
        {
            giris();
            con.Open();
            string sorgu2 = "Insert into ogrenci values(@numara,@ad,@soyad,@tel)";
            cmd = new OleDbCommand(sorgu2, con);
            cmd.Parameters.AddWithValue("@numara", t1);
            cmd.Parameters.AddWithValue("@ad", t2);
            cmd.Parameters.AddWithValue("@soyad", t3);
            cmd.Parameters.AddWithValue("@tel", t4);


            cmd.ExecuteNonQuery();
            cmd.Dispose();//burata bak
            ds.Clear();
            doldur1();
            j = i;
            goster1();
            MessageBox.Show("Kayit eklndi");
        }
        private void button6_Click(object sender, EventArgs e)//guncelle
        {
            guncelle1();//guncelle2();
        }
        void guncelle1()
        {
            giris();
            con.Open();
            string sorgu2 = "uptade ogrenci set ad@t2,soyad=@t3,tel=@t4 where numara=@t1";
            cmd = new OleDbCommand(sorgu2, con);
            cmd.Parameters.AddWithValue("@ad", t2);
            cmd.Parameters.AddWithValue("@soyad", t3);
            cmd.Parameters.AddWithValue("@tel", t4);
            cmd.Parameters.AddWithValue("@numara", t1);//t1 ya da no >>dikkat!!
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            ds.Clear();
            doldur1();
            goster1();
            MessageBox.Show("KAyıt güncellendi");

        }
        void guncelle2()
        {
            giris();
            con.Open();
            string sorgu2 = "uptade ogrenci set ad=@t2,soyad=@t3,tel=@t4 where numara=" + no;
            cmd = new OleDbCommand(sorgu2, con);
            cmd.Parameters.AddWithValue("@ad", t2);
            cmd.Parameters.AddWithValue("soyad", t2);
            cmd.Parameters.AddWithValue("@tel", t4);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            ds.Clear();
            doldur1();
            goster1();
            MessageBox.Show("Kayıt guncellendi");
            
        }
        private void button7_Click(object sender, EventArgs e)//silme
        {
            giris();
            con.Open();
            string sorgu2 = "delete from ogrenci where numara=@no";
            cmd = new OleDbCommand(sorgu2, con);
            cmd.Parameters.AddWithValue("@no", t1);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            ds.Clear();
            doldur1();
            j = i;
            goster1();
            MessageBox.Show("Kayit silindi");
           
        }
        private void button2_Click(object sender, EventArgs e)//ilk
        {
            j = 0; goster1();
        }
        private void button3_Click(object sender, EventArgs e)//onceki
        {
            if (j > 0)
            {
                j--; goster1();
            }
            else
            {
                MessageBox.Show("ilk kayit"); textBox1.Focus();
            }

        }
        private void button4_Click(object sender, EventArgs e)//sonraki
        {
            if (j < 1)
            {
                j++; goster1();
            }
            else
            {
                MessageBox.Show("son kayit"); textBox1.Focus();
            }
        }
        private void button5_Click(object sender, EventArgs e)//son
        {
            j = i; goster1();
        }
        private void button8_Click(object sender, EventArgs e)//arama
        {
            giris();
            con.Open();
            doldur1();
            for (int s = 0; s < i + 1; s++)
            {
                if (ds.Tables[0].Rows[s][0].ToString() == textBox5.Text)
                {
                    j = s;
                    goster1();
                    MessageBox.Show("kayıt var");
                }
            }
            con.Close();
        }
        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //kullanma 
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //kullanma
        }
        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }
      }
    }


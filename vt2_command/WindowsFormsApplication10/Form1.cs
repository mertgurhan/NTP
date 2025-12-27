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
        int i, j;
        int numara;
        string ad;
        string soyad;
        string tel;
        OleDbConnection con;
        OleDbDataAdapter da;
        OleDbCommand cmd;
        DataSet ds;
        OleDbCommandBuilder cb;
        DataTable dt;
        OleDbDataReader dr;
        void baglanti()
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=vt.accdb");
            da = new OleDbDataAdapter("select * from[ogrenci]",con);
            con.Open();
            ds = new DataSet();
            dt = new DataTable();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            con.Close();
        }
        void doldur2()//DataSet
        {
            ds.Clear();
            da.Fill(ds, "ogrenci");
            dataGridView1.DataSource = ds.Tables[0];
          i= ds.Tables["ogrenci"].Rows.Count - 1;
            
        }
        void goster2()
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
        void goster1()//
        {
            doldur1();
            textBox1.Text = dt.Rows[j][0].ToString();
            textBox2.Text = dt.Rows[j][1].ToString();
            textBox3.Text = dt.Rows[j][2].ToString();
            textBox4.Text = dt.Rows[j][3].ToString();
            dataGridView1.ClearSelection();
            dataGridView1.Rows[j].Selected = true;
            label1.Text = (i + 1).ToString();
            label2.Text = (j + 1).ToString();
        }
        void doldur1()//DataTable
        {
            dt.Clear();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            i = dt.Rows.Count - 1;
           
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            baglanti();
            doldur2();
            j = i;
            goster2();
        }
        void giris()
        {
            numara = Convert.ToInt32(textBox1.Text);
            ad = textBox2.Text;
            soyad = textBox3.Text;
            tel = textBox4.Text;
            
        }
        private void button1_Click(object sender, EventArgs e)//ekle+++
        {
            ekle1();
        }
        void ekle1()
        {
            giris();
            con.Open();
            cmd = new OleDbCommand("insert into ogrenci values(" + numara + ",'" + ad + "','" + soyad + "','" + tel + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            doldur1();
            j = i;
            goster1();
            MessageBox.Show("Kayit eklendi");
           
        }
        void ekle2()//CommandText
        {
            giris();
            con.Open();
            cmd = new OleDbCommand();
            string sql= "insert into ogrenci values(" + numara + ",'" + ad + "','" + soyad + "','" + tel + "')";
            cmd.CommandText = sql;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();
            doldur2();
            j = i;
            goster2();
            MessageBox.Show("Kayit eklendi");
        }
        private void button6_Click(object sender, EventArgs e)//guncelle
        {
            giris();
            cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText="uptade ogrenci set ad='"+ad+"',soyad='"+soyad+"',tel='"+tel+"'where numara="+numara+"";
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            doldur1();
            goster1();
            MessageBox.Show("Kayit Guncellendi");
        }
        private void button7_Click(object sender, EventArgs e)//silme
        {
            giris();
            cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "delete from ogrenci where numara=" + numara + "";
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            ds.Clear();
            con.Close();
            doldur1();
            goster1();
            MessageBox.Show("Kayit silindi");


           
        }
        private void button8_Click(object sender, EventArgs e)//ara
        {
            ara1();
        }
        void ara1()
        {
         
        }
        void ara2()
        {

        }
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            j = dataGridView1.CurrentCell.RowIndex;
            doldur1();

            goster1();
        }
        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //kullanma
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //kullanma
        }
        private void button2_Click(object sender, EventArgs e)//ilk
        {
            j = 0;goster1();
        }
        private void button3_Click(object sender, EventArgs e)//onceki
        {
            if (j > 0)
            {
                j--;goster1();
            }
            else
            {
                MessageBox.Show("ilk kayit"); textBox1.Focus();
            }
        }
        private void button4_Click(object sender, EventArgs e)//sonraki
        {
            if (j < i)
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
        private void button9_Click(object sender, EventArgs e)//kapat
        {
            this.Close();
        }
      }
    }


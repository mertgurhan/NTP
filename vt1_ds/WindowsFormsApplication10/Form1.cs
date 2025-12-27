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
        OleDbCommand cmd;
        OleDbConnection con;
        OleDbDataReader dr;
        OleDbDataAdapter da;
        OleDbCommandBuilder cb;
        DataSet ds;
  

        int i = 0;//toplam
        int j = 0;//aktif
        void baglanti()
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0.Data Source=vt.accdb");
            da = new OleDbDataAdapter("select * from ogrenci", con);
            con.Open();
            ds = new DataSet();
            da.Fill(ds, "ogrenci");
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
            i = ds.Tables["ogrenci"].Rows.Count - 1;
            j = i;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            
        }
        void goster1()
        {
            textBox1.Text = ds.Tables[0].Rows[j][0].ToString();
            textBox2.Text = ds.Tables[0].Rows[j][1].ToString();
            textBox3.Text = ds.Tables[0].Rows[j][2].ToString();
            textBox4.Text = ds.Tables[0].Rows[j][3].ToString();
            dataGridView1.ClearSelection();
            dataGridView1.Rows[j].Selected=true;
            label1.Text = (i + 1).ToString();
            label2.Text = (j + 1).ToString();

        }
        void goster2()
        {
            DataRow drow1 = ds.Tables["ogrenci"].Rows[j];
            textBox1.Text = drow1.ItemArray.GetValue(0).ToString();
            textBox2.Text = drow1.ItemArray.GetValue(1).ToString();
            textBox3.Text = drow1.ItemArray.GetValue(2).ToString();
            textBox4.Text = drow1.ItemArray.GetValue(3).ToString();

            i = ds.Tables["ogrenci"].Rows.Count - 1;
            label1.Text = (i + 1).ToString();
            label2.Text = (j + 1).ToString();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
        private void button1_Click(object sender, EventArgs e)//ekle
        {
            cb = new OleDbCommandBuilder(da);
            DataRow drow1 = ds.Tables[0].NewRow();
            drow1[0] = textBox1.Text;
            drow1[1] = textBox2.Text;
            drow1[2] = textBox3.Text;
            drow1[3] = textBox4.Text;
            ds.Tables[0].Rows.Add(drow1);
            da.Update(ds, "ogrenci");
            MessageBox.Show("kayıt ekşlendi");
            i++;
            j=i;
            goster1();
        }
        private void button6_Click(object sender, EventArgs e)//guncelle
        {
            cb = new OleDbCommandBuilder(da);
            DataRow drow1 = ds.Tables[0].NewRow();
            drow1[0] = textBox1.Text;
            drow1[1] = textBox2.Text;
            drow1[2] = textBox3.Text;
            drow1[3] = textBox4.Text;
       
            da.Update(ds, "ogrenci");
            MessageBox.Show("kayıt güncellendi");
            goster1();
        }
        private void button7_Click(object sender, EventArgs e)//silme
        {
            ds.Tables[0].Rows[j].Delete();
            ds.Tables[0].Rows[j].AcceptChanges();
            i--;
            j = 0;
            MessageBox.Show("Başariyla silindi");
            goster1();
        }
        private void button8_Click(object sender, EventArgs e)//arama
        {

            string ara = textBox5.Text;
            for(int s = 0; s <= i; s++)
            {
                if (ds.Tables[0].Rows[j][1].ToString() == ara)
                {
                    MessageBox.Show("var");
                    return;

                }
            }
            MessageBox.Show("yok");


        }
        private void button2_Click(object sender, EventArgs e)//ilk
        {
            j = 0;
            goster1();
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
            j = i - 1; goster1();
        }
        private void button9_Click(object sender, EventArgs e)//kapat
        {
            this.Close();
        }
    }
    }


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string kullanici = "Ali";
        int sifre = 123;
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "Ad";
            label2.Text = "Sifre";
            button1.Text = "Giris";

            linkLabel1.Text = "Sifre Unuttum";
           

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == kullanici && Convert.ToInt32(textBox2.Text) == sifre)
            {
                MessageBox.Show("Kullanıcı Girisi basarili");
               
            
                Form3 form3 = new Form3();
                form3.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Lutfen duzgun giris yapiniz!");
                return;
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Start();






        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int label4 = Convert.ToInt32(label4.Text);
            label4++;
            label3.Text = label4.ToString();
        }
    }
}

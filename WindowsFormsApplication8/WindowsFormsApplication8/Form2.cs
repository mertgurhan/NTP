using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication8
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        string FilePath = "C:\\Users\\user\\Desktop\\a.txt";
        private void Form2_Load(object sender, EventArgs e)
        {
            radioButton1.Text = "Erkek";
            radioButton1.Text = "Kadın";
            radioButton1.Text = "Belirtmek İstemiyorum";

            List<String> sehir = new List<string>();
            sehir.Add("İstanbul");
            sehir.Add("Ankara");
            sehir.Add("Cankırı");
            foreach(var item in sehir)
            {
                comboBox1.Items.Add(item);


            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = new StreamWriter(FilePath,true))
            {
                sw.WriteLine("Kullanici Adi=" + textBox1.Text);
                sw.WriteLine("Sifre=" + textBox2.Text);
                sw.WriteLine("Sehir" + comboBox1.Text);

                if (radioButton1.Checked = true)
                {
                    sw.WriteLine("Cinsiyet" +radioButton1.Text );
                }
                else if (radioButton2.Checked = true)
                {
                    sw.WriteLine("Cinsiyet" +radioButton2.Text);
                }
                else if (radioButton3.Checked = true)
                {
                    sw.WriteLine("Cinsiyet" +radioButton3.Text);
                }

                MessageBox.Show("Kayıt basarili!");
                Form1 form1 = new Form1();
                form1.Show();
                this.Hide();

            }
        }
    }
}

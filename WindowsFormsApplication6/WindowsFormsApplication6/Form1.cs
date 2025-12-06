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
namespace WindowsFormsApplication6
{
    public partial class Form1 : Form
    {
        private bool buyuharfkontrol;

        public Form1()
        {
            InitializeComponent();
        }
        string FilePath = "C:\\Users\\user\\Desktop\\a.txt";

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            label1.Text = "Kullanici Adi:";
            label2.Text = "Sifre:";
            label3.Text = "Sifre tekrar";
            button1.Text = "Kaydet";
            button2.Text = "Temizle";
            button3.Text = "Kapat";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Lütfen boşlukları doldurunuz tekrar deneyiniz!");
                return;
            }

            if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("Şifreler birbiri ile aynı olmalıdır!");
                return;
            }

            // Şifre gereksinimlerini kontrol et
            if (!BuyukKucukHarfVeOzelKarakterKontrol(textBox2.Text))
            {
                MessageBox.Show("Şifre en az bir büyük harf, bir küçük harf ve bir özel karakter içermelidir!");
                return;
            }




            
            using (StreamWriter sw=new StreamWriter(FilePath,true))
            {
                sw.WriteLine("Kullanici Adı:" + textBox1.Text);
                sw.WriteLine("Sifre:" + textBox2.Text);
                sw.WriteLine("----------");
            }
            MessageBox.Show("Kullanıcı bilgileri başarıyla kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Eğer tüm kontroller başarılıysa Form2'yi aç
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        public void karakter_kontrol(string metin)
        {
            

            
        }

        public bool BuyukKucukHarfVeOzelKarakterKontrol(string metin)
        {
            /*
            bool buyukharfkontrol = false;
            bool kucukharfkontrol = false;
            bool ozelkarakterkontrol = false;
            if (metin.Length >= 0) return true;

            return false;
            foreach (char item in metin)
            {

                int kod = (char)item;

                if (kod >= 65 && kod <= 90)
                {
                    buyuharfkontrol = true;
                }
                else if (kod >= 97 && kod <= 122)
                {

                    kucukharfkontrol = true;

                }
                else 
                {
                    ozelkarakterkontrol = true;
                }
                if (buyukharfkontrol && kucukharfkontrol && ozelkarakterkontrol)
                    return true;


            }
            return false;
            */


            bool buyukharfkontrol = false;
            bool kucukharfkontrol = false;
            bool ozelkarakterkontrol = false;

            // Eğer metin boşsa hemen false döndür
            if (string.IsNullOrEmpty(metin))
                return false;

            foreach (char item in metin)
            {
                int kod = (int)item;

                if (kod >= 65 && kod <= 90) // Büyük harf kontrolü (A-Z)
                {
                    buyukharfkontrol = true;
                }
                else if (kod >= 97 && kod <= 122) // Küçük harf kontrolü (a-z)
                {
                    kucukharfkontrol = true;
                }
                else if (!char.IsLetterOrDigit(item)) // Özel karakter kontrolü
                {
                    ozelkarakterkontrol = true;
                }

                // Eğer tüm kriterler sağlanmışsa true döndür
                if (buyukharfkontrol && kucukharfkontrol && ozelkarakterkontrol)
                    return true;
            }

            // Eğer tüm kriterler sağlanmadıysa false döndür
            return false;
        }
    

        private void textBox2_TextChanged(object sender, EventArgs e)
        {   

            if (!BuyukKucukHarfVeOzelKarakterKontrol(textBox2.Text))
            {
                label4.Text = "Şifre en az bir büyük harf, bir küçük harf ve bir özel karakter içermelidir.";
                label4.ForeColor = System.Drawing.Color.Red; // Uyarı rengini kırmızı yapıyoruz.
            }
          

            else
            {
                label4.Text = "Şifre uygun.";
                label4.ForeColor = System.Drawing.Color.Green; // Uygunsa yeşil renk yapıyoruz.
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}

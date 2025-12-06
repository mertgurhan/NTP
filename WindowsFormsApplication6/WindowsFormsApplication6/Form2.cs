using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication6
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            button1.Text = "Geri dön!";
            comboBox1.Items.Add("İstanbul");

            List<String> sehir_listesi = new List<string>();
            sehir_listesi.Add("Burdur");
            sehir_listesi.Add("Isparta");
            sehir_listesi.Add("İzmir");
            sehir_listesi.Add("Bolu");


            comboBox1.Items.Add(sehir_listesi.ToString());
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Add("İstanbul");

            List<String> sehir_listesi = new List<string>();
            sehir_listesi.Add("Burdur");
            sehir_listesi.Add("Isparta");
            sehir_listesi.Add("İzmir");
            sehir_listesi.Add("Bolu");


            comboBox1.Items.Add(sehir_listesi);


        }
    }
}

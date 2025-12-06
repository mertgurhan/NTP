using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            radioButton1.Text = "Ajdar";
            radioButton2.Text = "Selam";
            maskedTextBox1.Mask = "00:00";

            comboBox1.Text = "Ali";


            List<String> sehir = new List<string>();
            sehir.Add("İstanbul");
            sehir.Add("Cezayir");
            sehir.Add("Hakkari");


            foreach(var item in sehir)
            {

                comboBox1.Items.Add(item);
            }


            for(int i = 0; i <= sehir.Count; i++)
            {
                comboBox1.Items.Add(sehir[i]);
            }

            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = "mer";



            if (textBox1.Text.Contains(text))
            {
                label1.Text = "Bulundu";
            }
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}

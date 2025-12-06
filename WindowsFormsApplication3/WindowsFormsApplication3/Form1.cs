using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ArrayList ad = new ArrayList() { "ali", "ali2", "ali3", "ali4", "ali5", "ali6" };
        ArrayList vize = new ArrayList() { 45, 65, 43, 87, 56, 23 };
        ArrayList final = new ArrayList() { 98, 65, 100, 12, 35, 98 };
        int i, j;
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            sec(1);


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.Items.AddRange(ad.ToArray());
            listBox2.Items.AddRange(vize.ToArray());
            listBox3.Items.AddRange(final.ToArray());
        }

       
        private  void sec(int k)
        {
            listBox1.SelectedIndex = j;
            listBox2.SelectedIndex = j;
            listBox3.SelectedIndex = j;

            k = j;


        }



    }
}

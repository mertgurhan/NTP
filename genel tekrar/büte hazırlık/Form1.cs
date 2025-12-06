using System;
using System.Windows.Forms;
using System.Collections;
namespace büte_hazırlık
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        ArrayList isim = new ArrayList() { "ali", "fatma", "cenk", "cengiz", "davut" };
        ArrayList no = new ArrayList() { 1, 2, 3, 4, 5 };
        int i, j;
        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Text = "Ekle 1(varsa)";
            button2.Text = "ekle2(yoksa)";
            button3.Text = "değiştir";
            button4.Text = "bul";
            button5.Text = "sil";
            button6.Text = "temizle";
            button7.Text = "en üste taşı";
            button8.Text = "en üst ile yer değiştir";
            button9.Text = "en alt ile yer değiiştir";
            button10.Text = "en alt taşı";
            button11.Text = "kapat";

           // listBox1.Items.AddRange(isim.ToArray());
            listBox2.Items.AddRange(no.ToArray());
          

            listBox1.SelectionMode = SelectionMode.MultiSimple;

            listBox2.SelectionMode = SelectionMode.MultiSimple;




        }


        private void ekle()
        {
      



        }
        private void ilerigeritasima()
        {
      


        }


        private void değiştir()
        {






        }



        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void button3_Click(object sender, EventArgs e)
        {
         
        }


        private void bul()
        {

  

        }


   private void sil()
    {
           

    }


        private void enüsttasi()
        {
        
         


        }

        private void button5_Click(object sender, EventArgs e)
        {
  
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        private void button7_Click(object sender, EventArgs e)
        {

            /* int i, a, s = 0;
             String t1 = textBox1.Text;
             a = listBox1.Items.Count;
             for (i = 0; i < a; i++)
             {
                 if (listBox1.GetSelected(i) == true)
                 {
                     listBox1.Items[i] = t1;
                     listBox1.SetSelected(i, true);
                     s++;
                 }
             }
             label1.Text = "listede VAR," + s + " adet değiştirildi";
             */

            /*  listBox1.Items.Insert(4, "kütahya");
              listBox1.Items.RemoveAt(3);
              //////////////aynisi////////////  
            listBox1.SelectedIndex = 3;
            listBox1.Items[3] = "KUTAHYA";
            listBox1.SelectedIndex = -1;

    */
            /*int a = listBox1.SelectedItems.Count;
            for (int i = 0; i < a; i++)
            {
                listBox2.Items.Insert(i, listBox1.SelectedItems[0]);
                listBox1.Items.Remove(listBox1.SelectedItems[0]);
            }*/

            /*   int j = listBox1.SelectedIndex;
               int i = listBox1.Items.Count - 1;
               object a1, a2, a3, a4;
               a1 = listBox1.Items[j];
               listBox1.Items.RemoveAt(j);
               listBox1.Items.Insert(i, a1);// Add(a1)
               listBox1.SelectedIndex = i;
               */

            /* for (int i = 0; i < listBox1.SelectedItems.Count; i++)
             {
                 listBox1.Items.Insert(listBox1.Items.Count, listBox1.SelectedItems[i]);
             }

           */
            /*listBox1.Items.AddRange(new object[3] { "1", "2", "3" });
            int a, b; a = b = listBox1.Items.Count;
            for (int i = 0; i < a; i++, b++)
            {
              //  listBox1.Items.Insert(b, listBox1.Items[i]);
            }
            */


            for(int i = 0; i < 15; i++)
            {
                Console.WriteLine(i);
            }

        }
        


    }





    }


 



    

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
namespace WindowsFormsApplication22
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        OleDbConnection con;
        OleDbDataAdapter da;
        OleDbCommand cmd;
        OleDbDataReader dr;
        OleDbCommandBuilder cb;
        DataSet ds;
        DataTable dt;
        DataView dv;        
        int i,j,s;
        void baglanti1()
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=okul.accdb");
            con.Open();
            string sorgu = "select * from ogrenci";
            da = new OleDbDataAdapter(sorgu,con);
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            dgvwolustur();
            baglanti1(); yukle12();
        }
        void yukle11()
        {
            ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
        void yukle12()
        {
            ds = new DataSet();
            da.Fill(ds);

            dgvwolustur();
            dataGridView1.RowCount = ds.Tables[0].Rows.Count + 1;

            for (s = 0; s < ds.Tables[0].Rows.Count; s++)
            {
                for(int a = 0; a < ds.Tables[0].Columns.Count; a++)
                {
                    dataGridView1.Rows[s].Cells[a].Value = ds.Tables[0].Rows[s][a];
                }
            }

            //datasource yok, DataSet, for(..row.count..)


        }
        void yukle13()
        {
            ds = new DataSet();
            da.Fill(ds);
            dgvwolustur();
            dataGridView1.RowCount = ds.Tables[0].Rows.Count + 1;


            s = 0;
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                dataGridView1.Rows[s].SetValues(Convert.ToInt32(ds.Tables[0].Rows[s][0]), ds.Tables[0].Rows[s][1], ds.Tables[0].Rows[s][2], ds.Tables[0].Rows[s][3]);
                s++;
            }
            //datasource yok, DataSet, foreach()
        }
        void yukle21()
        {
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        void yukle22()
        {

            dt = new DataTable();
            da.Fill(dt);
            dgvwolustur();
            dataGridView1.RowCount = dt.Rows.Count + 1;
            int a;
            for (a = 0; a < dt.Columns.Count; a++)
            {
                for(int d = 0; d < dt.Columns.Count; d++)
                {
                    dataGridView1.Rows[a].Cells[d].Value = dt.Rows[a][d];
                }
            }
            
            
             
           //datasource yok, DataTable, for(..row.count..)
        }
        void yukle23()
        {
            dt = new DataTable();
            da.Fill(dt);
            dgvwolustur();
            dataGridView1.RowCount = dt.Rows.Count + 1;
            s = 0;

            foreach (DataRow row in dt.Rows)
            {
                dataGridView1.Rows[s].SetValues(Convert.ToInt32(dt.Rows[s][0]), dt.Rows[s][1], dt.Rows[s][2], dt.Rows[s][3]);
                s++;

            }


            //datasource yok, DataTable, foreach()
        }
        void yukle31()
        {
            dt = new DataTable();
            da.Fill(dt);
            dv = dt.DefaultView;//dv = new DataView(dt);
            dataGridView1.DataSource = dv;
        }
		void yukle32()
        {
            dt = new DataTable();
            da.Fill(dt);
            dv = dt.DefaultView;//dv = new DataView(dt);

            int a;
            for (a = 0; a < dv.Table.Rows.Count; a++)
            {
                dataGridView1.Rows.Add(Convert.ToInt32(dv.Table.Rows[a][0]), dv.Table.Rows[a][1], dv.Table.Rows[a][2], dv.Table.Rows[a][3], dv.Table.Rows[a][4], dv.Table.Rows[a][5]);
                a++;
                /*for(int col=0; col<dv.Table.Columns.Count; col++ )
                {
                    dataGridView1.Rows[a].Cells[col].Value = dv.Table.Rows[a][col];
                }*/
            }

            //datasource yok, DataTable+DataView, for(..row.count..)
        }
        void yukle33()
        {
            dt = new DataTable();
            da.Fill(dt);
            dv = dt.DefaultView;
            s = 0;
            foreach(DataRow row in dv.Table.Rows)
            {
                dataGridView1.Rows.Add(Convert.ToInt32(dv.Table.Rows[s][0]), dv.Table.Rows[s][1], dv.Table.Rows[s][2], dv.Table.Rows[s][3]);
                s++;

            }

            //datasource yok, DataTable+DataView+Y1, foreach() //y1
        }
        void yukle34()
        {
            dt = new DataTable();
            da.Fill(dt);
            dv = dt.DefaultView;//dv = new DataView(dt);

            s = 0;
            foreach (DataRow row in dv.Table.Rows)
            {
                dataGridView1.Rows.Add();

                foreach (DataColumn col in dv.Table.Columns)
                {
                    dataGridView1.Rows[s].SetValues(Convert.ToInt32(dv.Table.Rows[s][0]), dv.Table.Rows[s][1], dv.Table.Rows[s][2], dv.Table.Rows[s][3], dv.Table.Rows[s][4], dv.Table.Rows[s][5]);
                }
                s++;
            }
          
            //datasource yok, DataTable+DataView+Y1+Y2, foreach() //y2
        }
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            j = dataGridView1.CurrentCell.RowIndex;
        }
        private void dgvwolustur()//
        {
            dataGridView1.ColumnCount = 6;
            dataGridView1.Columns[0].Name = "no";
            dataGridView1.Columns[1].Name = "ad";
            dataGridView1.Columns[2].Name = "soyad";
            dataGridView1.Columns[3].Name = "Fkt";
            dataGridView1.Columns[4].Name = "Blm";
            dataGridView1.Columns[5].Name = "Snf";
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].Width = 80;
            dataGridView1.Columns[3].Width = 50;
            dataGridView1.Columns[4].Width = 50;
            dataGridView1.Columns[5].Width = 50;
        }
        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

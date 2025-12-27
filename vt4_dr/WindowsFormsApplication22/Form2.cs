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
        void baglanti2()
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=okul.accdb");
            con.Open();
            cmd = new OleDbCommand("select * from ogrenci", con);
            dr = cmd.ExecuteReader();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            dgvwolustur();
            baglanti2(); yukle21();
        }
		void yukle11()
        {
            dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
        }
        void yukle12()
        {
            while (dr.Read())
            {
                dataGridView1.Rows.Add(dr[0], dr[1], dr[2], dr[3]);
            }
        }
        void yukle13()
        {
            dt = new DataTable();
            dt.Load(dr);
            foreach(DataRow row in dt.Rows)
            {
                dataGridView1.Rows.Add(row[0], row[1], row[2], row[3]);
            }
            
        }
        void yukle21()
        {
            dt = new DataTable();
            dt.Load(dr);
            ds = new DataSet();
            ds.Tables.Add(dt);

            dataGridView1.DataSource = ds.Tables[0];

        }
        void yukle22()
        {
            
        }
       
		void yukle23()
        {
            
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

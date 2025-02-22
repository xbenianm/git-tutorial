using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZOZNAMULOH
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DataTable toDolist = new DataTable();
        bool isEditing = false;

        private void Form1_Load(object sender, EventArgs e)
        {
            //VYTVOR TABULKU Z HODNOTAMI
            toDolist.Columns.Add("NADPIS");
            toDolist.Columns.Add("POPIS");
            //PREPOJENIE TABULKY S PREMENNOU
            dataGridView1.DataSource = toDolist;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //NAPIS VSETKY UDAJE
            NADPIS.Text = "";
            POPIS.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            isEditing = true;
            //VYPLNI DATA
            NADPIS.Text = toDolist.Rows[dataGridView1.CurrentCell.RowIndex].ItemArray[0].ToString();
            POPIS.Text = toDolist.Rows[dataGridView1.CurrentCell.RowIndex].ItemArray[1].ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                toDolist.Rows[dataGridView1.CurrentCell.RowIndex].Delete();
        }
            catch (Exception ex )
            {
                Console.WriteLine("Chyba:" + ex);
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            if ( isEditing ) {
                toDolist.Rows[dataGridView1.CurrentCell.RowIndex]["NADPIS"] = NADPIS.Text;
                toDolist.Rows[dataGridView1.CurrentCell.RowIndex]["POPIS"] = POPIS.Text;
            }
            else
            {
                toDolist.Rows.Add(NADPIS.Text, POPIS.Text);
                NADPIS.Text = "";
                POPIS.Text = "";
                isEditing = false;
            }
        }
}
}

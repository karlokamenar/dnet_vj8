using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dnet_vj8
{
    public partial class Form1 : Form
    {
        Database1Entities baza = new Database1Entities();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {




            var plesac = from s in baza.natjecanje
                         select s.ime_plesaca;
            comboBox1.DataSource = plesac.ToList();
            var ples = from s in baza.natjecanje
                       select s.ples;

            comboBox2.DataSource = ples.ToList();
            

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ime = comboBox1.SelectedItem.ToString();
            string ples_izbor = comboBox2.SelectedItem.ToString();
            var plesanje = from s in baza.natjecanje
                           where s.ime_plesaca == ime ||
                            s.ples == ples_izbor
                           select new
                           {
                               Ime = s.ime_plesaca,
                               Ples = s.ples,
                               Ocjena = s.ocjena
                           };
            dataGridView1.DataSource = plesanje.ToList();
        }
    }
}

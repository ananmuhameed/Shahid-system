using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2;
using my_report;

namespace Swe_Project
{
    public partial class Main_Form : Form
    {
        CrystalReport1 cr;
        public Main_Form()
        {
            InitializeComponent();
            cr = new CrystalReport1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Update_System f1 = new Update_System();
            f1.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Search_Report r = new Search_Report();
            r.ShowDialog();
            this.Close();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            MessageBox.Show("WELCOME TO SHAHID!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manage_Users m = new Manage_Users();
            m.ShowDialog();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.ShowDialog();
            this.Close();

        }
    }
}

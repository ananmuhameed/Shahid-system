using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Swe_Project;


namespace my_report
{
    public partial class Form1 : Form
    {
        CrystalReport4 r;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            r = new CrystalReport4();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.ReportSource = r;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main_Form m = new Main_Form();
            m.ShowDialog();
            this.Close();
        }
    }
}

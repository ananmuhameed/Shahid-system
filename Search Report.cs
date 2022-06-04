using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;

namespace Swe_Project
{
    public partial class Search_Report : Form
    {
        CrystalReport1 cr;

        public Search_Report()
        {
            InitializeComponent();
        }


        private void Search_Report_Load(object sender, EventArgs e)
        {
            cr = new CrystalReport1();
            foreach (ParameterDiscreteValue v in cr.ParameterFields[0].DefaultValues)
                comboBox1.Items.Add(v.Value);

        }

        private void crystalReportViewer1_Load_1(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cr.SetParameterValue(0, comboBox1.Text);
            crystalReportViewer1.ReportSource = cr;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

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

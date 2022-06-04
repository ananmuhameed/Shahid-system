using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace Swe_Project
{
    public partial class Update_System : Form
    {
        OracleDataAdapter Adp;
        DataSet ds;
        public Update_System()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main_Form f1 = new Main_Form();
            f1.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string constr = "Data Source = orcl; User Id = scott; Password = tiger;";
            String cmdstr = @"select MovieID, MovieName, MovieType from Movies where MovieName =:Name";
            Adp = new OracleDataAdapter(cmdstr, constr);
            Adp.SelectCommand.Parameters.Add("Name", SearchTextBox.Text);
            ds = new DataSet();
            Adp.Fill(ds);
            SerachGridView.DataSource = ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OracleCommandBuilder build = new OracleCommandBuilder(Adp);
            Adp.Update(ds.Tables[0]);
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

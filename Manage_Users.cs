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
using Swe_Project;

namespace WindowsFormsApp2
{
    public partial class Manage_Users : Form
    {

        string ordb = "Data source=orcl;User Id=scott;Password=tiger;";
        OracleConnection conn;
        public Manage_Users()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select CID from clients";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
            }
            dr.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            OracleCommand c = new OracleCommand();
            c.Connection = conn;
            c.CommandText = "select CName,age from clients where CID = :id";
            c.CommandType = CommandType.Text;
            c.Parameters.Add("id", comboBox1.SelectedItem.ToString());
            OracleDataReader dr = c.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr[0].ToString();
                textBox2.Text = dr[1].ToString();
            }
            dr.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "insert into clients(CID,CName,age) values(:id,:name,:age)";
            cmd.Parameters.Add("id", comboBox1.Text);
            cmd.Parameters.Add("name", textBox1.Text);
            cmd.Parameters.Add("age", textBox2.Text);
            int r = cmd.ExecuteNonQuery();
            if (r != -1)
            {
                comboBox1.Items.Add(comboBox1.Text);
                MessageBox.Show("Account Created Successfully");
            }

        }


        private void button2_Click(object sender, EventArgs e)
        {
            int maxAge;
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "GetAge";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("age", OracleDbType.Int32, ParameterDirection.Output);
            cmd.ExecuteNonQuery();

            maxAge = Convert.ToInt32(cmd.Parameters["age"].Value.ToString());
            textBox2.Text = maxAge.ToString();


            OracleCommand c = new OracleCommand();
            c.Connection = conn;
            c.CommandText = "select CID,CName from clients where age = :age";
            c.CommandType = CommandType.Text;
            c.Parameters.Add("age", textBox2.Text.ToString());
            OracleDataReader dr = c.ExecuteReader();
            if (dr.Read())
            {
                comboBox1.Text = dr[0].ToString();
                textBox1.Text = dr[1].ToString();
            }
            dr.Close();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "favMovies";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("id", comboBox1.SelectedItem.ToString());
            cmd.Parameters.Add("moviename", OracleDbType.RefCursor,ParameterDirection.Output);
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr[0]);
            }
            dr.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main_Form m = new Main_Form();
            m.ShowDialog();
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private int image_number = 1;
        private void loadNextImage() 
        {
            if (image_number == 11) 
            {
                image_number = 1;
            }
            pictureBox1.ImageLocation = string.Format(@"Images\{0}.jpg", image_number);
            image_number++;

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            loadNextImage();
        }
    }
}

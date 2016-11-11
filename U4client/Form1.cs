using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace U4client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\U4db.mdf;Integrated Security=True");

        private void Form1_Load(object sender, EventArgs e)
        {
            //DataTable tbl1 = new DataTable();
            //SqlDataAdapter da = new SqlDataAdapter(cmd1);
            //da.Fill(tbl1);
            //this.comboBox1.DataSource = tbl1;
            //this.comboBox1.DisplayMember = "...";// столбец для отображения
            //this.comboBox1.ValueMember = "...";//столбец с id
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand("INSERT INTO [Table] (Заказчик, Тираж, Красочность) VALUES(N'" + textBox1.Text + "', '" + Convert.ToInt32(textBox2.Text) + "', '" + comboBox1.Text + "')", con);
            DataTable data = new DataTable();
            SqlDataAdapter adaper = new SqlDataAdapter(cmd);
            adaper.Fill(data);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM [Table]", con);
            SqlDataAdapter adaper = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adaper.Fill(ds, "Table");
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].Width = 50;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String str;
            SqlConnection myConn = new SqlConnection("Server=localhost;Integrated security=SSPI;database=master");

            str = "CREATE DATABASE MyDatabase ON PRIMARY " +
                "(NAME = MyDatabase_Data, " +
                @"FILENAME = '" + textBox3.Text +".mdf', " +
                "SIZE = 5MB, MAXSIZE = 10MB, FILEGROWTH = 10%) " +
                "LOG ON (NAME = MyDatabase_Log, " +
                @"FILENAME = '" + textBox3.Text +"_log.ldf', " +
                "SIZE = 5MB, " +
                "MAXSIZE = 10MB, " +
                "FILEGROWTH = 10%)";

            SqlCommand myCommand = new SqlCommand(str, myConn);
            try
            {
                myConn.Open();
                myCommand.ExecuteNonQuery();
                MessageBox.Show("DataBase is Created Successfully", "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                textBox3.Text = fbd.SelectedPath;
        }
    }
}

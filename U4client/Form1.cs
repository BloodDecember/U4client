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
    }
}

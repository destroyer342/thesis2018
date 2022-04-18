using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace QRCodeBasedLockerSystem
{
    public partial class Form15 : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost ; port=3306;username=root; password= ");
        MySqlDataAdapter adapter;
        DataTable table = new DataTable();


        MySqlCommand command;
        MySqlDataReader mdr;
        public string textBoxValue;
        public Form15()
        {
            InitializeComponent();
        }
       public Form15(string textBoxValue)
        {
            InitializeComponent();
            this.textBoxValue = textBoxValue;
        }
        private void Form15_Load(object sender, EventArgs e)
        {
          
           
            connection.Open();
            
            textBox2.Text = textBoxValue;
            string selectQuery = "SELECT *From rance.db WHERE lockerno =" + int.Parse(textBox2.Text);
            command = new MySqlCommand(selectQuery, connection);
            mdr = command.ExecuteReader();
            if (mdr.Read())
            {
                textBox3.Text = mdr.GetString("pword");
            }
            else
            {
                MessageBox.Show("no data");

            }
            connection.Close();



        }
        public static string rance;
        
        protected void button1_Click(object sender, EventArgs e)
        {
           
            if(textBox1.Text == textBox3.Text)
            {
                rance = textBox2.Text;
                this.Hide();
                Form16 ff = new Form16();
                ff.Show();

            }else
            {
                MessageBox.Show("not match");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }
    }
}

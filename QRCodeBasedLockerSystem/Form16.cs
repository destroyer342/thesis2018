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
    public partial class Form16 : Form
    {
        public Form16()
        {
            InitializeComponent();
        }
        MySqlConnection connection = new MySqlConnection("datasource=localhost ; port=3306;Initial Catalog = 'rance';username=root; password= ");
        MySqlCommand command;
        public void openConnection()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }
        public void closeConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }

        }
        public void executeQuery(String query)
        {
            try
            {
                openConnection();
                command = new MySqlCommand(query, connection);
                if (command.ExecuteNonQuery() == 1)
                {

                 
                    this.Close();
                    Form1 ff = new Form1();
                    ff.Show();
                }
                else
                {
                    MessageBox.Show("query not executed");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                closeConnection();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text == "1")
            {
                serialPort1.Write("1");
                serialPort1.Close();
                string deleteQuery = "DELETE FROM db where lockerno = " + int.Parse(textBox1.Text);
                executeQuery(deleteQuery);
                Form1 you = new Form1();
                this.Close();
                you.Show();
            }
            else if (textBox1.Text == "2")
            {
                serialPort1.Write("2");
                serialPort1.Close();
                string deleteQuery = "DELETE FROM db where lockerno = " + int.Parse(textBox1.Text);
                executeQuery(deleteQuery);
                Form1 you = new Form1();
                this.Close();
                you.Show();

            }
            else if (textBox1.Text == "3")
            {
                serialPort1.Write("3");
                serialPort1.Close();
                string deleteQuery = "DELETE FROM db where lockerno = " + int.Parse(textBox1.Text);
                executeQuery(deleteQuery);
                Form1 you = new Form1();
                this.Close();
                you.Show();
            }
            else if (textBox1.Text == "4")
            {
                serialPort1.Write("4");
                serialPort1.Close();
                string deleteQuery = "DELETE FROM db where lockerno = " + int.Parse(textBox1.Text);
                executeQuery(deleteQuery);
                Form1 you = new Form1();
                this.Close();
                you.Show();
            }
          
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "1")
            {
                serialPort1.Write("1");
                serialPort1.Close();
                Form1 you = new Form1();
                this.Close();
                you.Show();
            }
            else if (textBox1.Text == "2")
            {
                serialPort1.Write("2");
                serialPort1.Close();
                Form1 you = new Form1();
                this.Close();
                you.Show();

            }
            else if (textBox1.Text == "3")
            {
                serialPort1.Write("3");
                serialPort1.Close();
                Form1 you = new Form1();
                this.Close();
                you.Show();
            }
            else if (textBox1.Text == "4")
            {
                serialPort1.Write("4");
                serialPort1.Close();
                Form1 you = new Form1();
                this.Close();
                you.Show();
            }
           
        }

        private void Form16_Load(object sender, EventArgs e)
        {
            textBox1.Text = Form15.rance;
            serialPort1.Open();
        }
    }
}

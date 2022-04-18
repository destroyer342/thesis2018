using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using MySql.Data.MySqlClient;
namespace QRCodeBasedLockerSystem
{
    public partial class Form3 : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost ; port=3306;username=root; password= ");
        MySqlDataAdapter adapter;
        DataTable table = new DataTable();


        MySqlCommand command;
        MySqlDataReader mdr;
        public string rsr;
        public Form3()
        {
            InitializeComponent();
        }
        public Form3(string rsr)
        {
            InitializeComponent();
            this.rsr = rsr;
        }

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
                    MessageBox.Show(" SUCCESS! ");


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

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            this.Hide();
            f2.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QRCoder.QRCodeGenerator qrgenerator = new QRCoder.QRCodeGenerator();
            var qrdata = qrgenerator.CreateQrCode(textBox3.Text, QRCoder.QRCodeGenerator.ECCLevel.H);
            var qrCode = new QRCoder.QRCode(qrdata);
            var image = qrCode.GetGraphic(150);
            pictureBox1.Image = image;
            
           
         
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            string updateQuery = "UPDATE rance.db SET pword='" + textBox2.Text + "',qrpass='" + textBox3.Text + "' WHERE lockerno = " + textBox1.Text;
            executeQuery(updateQuery);
            button3.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            PrintDocument p = new PrintDocument();
            p.PrintPage += delegate (object sender1, PrintPageEventArgs e1)
            {

                e1.Graphics.DrawImage(pictureBox1.Image, 0, 0, pictureBox1.Width, pictureBox1.Height);
                e1.Graphics.DrawImage(pictureBox2.Image, 0, 206, pictureBox1.Width, pictureBox1.Height);
            };
            try
            {
                p.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception Occured While Printing");
            }
            MessageBox.Show("DONE :)");
            Form1 oo = new Form1();
            this.Close();
            oo.Show();
            connection.Close();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            textBox1.Text = rsr;
            connection.Open();
            string selectQuery = "SELECT *From rance.db WHERE lockerno =" + int.Parse(textBox1.Text);
            command = new MySqlCommand(selectQuery, connection);
            mdr = command.ExecuteReader();
            if (mdr.Read())
            {
                textBox2.Text = mdr.GetString("pword");
                textBox3.Text = mdr.GetString("qrpass");
            }
            else
            {
                MessageBox.Show("no data");

            }
            connection.Close();
        }

    }
}



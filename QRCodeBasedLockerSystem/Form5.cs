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
using System.Drawing.Printing;
namespace QRCodeBasedLockerSystem
{
    public partial class Form5 : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost ; port=3306;username=root; password= ");
        MySqlDataAdapter adapter;
        DataTable table = new DataTable();


        MySqlCommand command;
        MySqlDataReader mdr;
           
        public Form5()
        {
            InitializeComponent();
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
                    MessageBox.Show("query executed ");

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



        private void Form5_Load(object sender, EventArgs e)
        {
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
        private void button4_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            this.Hide();
            f2.ShowDialog();
        }

        

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

       
      

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                printDocument1.PrinterSettings = printDialog1.PrinterSettings;
                printDocument1.Print();

            }
        }

        private void printDocument1_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(pictureBox1.Image, 100, 600, pictureBox1.Width, pictureBox1.Height);
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string updateQuery = "UPDATE rance.db SET pword='" + textBox2.Text + "',qrpass='" + textBox3.Text + "' WHERE lockerno = " + textBox1.Text;
            executeQuery(updateQuery);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.ShowDialog();
        }

        private void button4_Click_1(object sender, EventArgs e)
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
                throw new Exception("Exception Occured While Printing", ex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QRCoder.QRCodeGenerator qrgenerator = new QRCoder.QRCodeGenerator();
            var qrdata = qrgenerator.CreateQrCode(textBox3.Text, QRCoder.QRCodeGenerator.ECCLevel.H);
            var qrCode = new QRCoder.QRCode(qrdata);
            var image = qrCode.GetGraphic(150);
            pictureBox1.Image = image;
            button3.Enabled = true;
        }
    }

}


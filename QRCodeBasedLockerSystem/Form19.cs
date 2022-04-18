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
    public partial class Form19 : Form
    {
        public Form19()
        {
            InitializeComponent();
        }
        MySqlConnection connection = new MySqlConnection("datasource=localhost ; port=3306;Initial Catalog = 'rance';username=root; password= ");
        MySqlCommand command;
        MySqlCommand commandd;
        MySqlDataReader mdr;
        MySqlDataReader mdrr;
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

                    MessageBox.Show("SUCCESS !! ");

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

        private void Form19_Load(object sender, EventArgs e)
        {
            connection.Open();
            string selectQuery = "SELECT *From rance.db WHERE lockerno =" + int.Parse(textBox1.Text);
            command = new MySqlCommand(selectQuery, connection);
            mdr = command.ExecuteReader();
            if (mdr.Read())
            {
                textBox2.Text = mdr.GetString("lockerno");
            }
            else
            {
                

            }
            if (textBox1.Text == textBox2.Text)
            {
                Form21 gg = new Form21();
                this.Close();
                gg.Show();
            }



            connection.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            QRCoder.QRCodeGenerator qrgenerator = new QRCoder.QRCodeGenerator();
            var qrdata = qrgenerator.CreateQrCode(textBox4.Text, QRCoder.QRCodeGenerator.ECCLevel.H);
            var qrCode = new QRCoder.QRCode(qrdata);
            var image = qrCode.GetGraphic(150);
            pictureBox1.Image = image;
        }

        private void button4_Click(object sender, EventArgs e)
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
    
            Form1 oo = new Form1();
            this.Close();
            oo.Show();
            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 you = new Form1();
            this.Close();
            you.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string insertQuery = "INSERT INTO rance.db(lockerno,pword,qrpass) VALUES('" + textBox1.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
            executeQuery(insertQuery);
            button3.Enabled = true;
            button4.Enabled = true;
        }
    }
}

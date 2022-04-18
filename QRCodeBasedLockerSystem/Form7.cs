using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.QrCode;
using AForge;
using AForge.Video;
using AForge.Video.DirectShow;
using MySql.Data.MySqlClient;

namespace QRCodeBasedLockerSystem
{
    public partial class Form7 : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost ; port=3306;username=root; password= ");
        MySqlDataAdapter adapter;
        DataTable table = new DataTable();


        MySqlCommand command;
        MySqlDataReader mdr;
        FilterInfoCollection capturedev;
        private VideoCaptureDevice finalframe;

        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {








            connection.Open();
            string selectQuery = "SELECT *From rance.db WHERE lockerno =" + int.Parse(textBox2.Text);
            command = new MySqlCommand(selectQuery, connection);
            mdr = command.ExecuteReader();
            if (mdr.Read())
            {
                textBox3.Text = mdr.GetString("qrpass");
            }
            else
            {
                MessageBox.Show("NO REGISTERED");
                Form9 you = new Form9();
                this.Close();
                you.Show();
            }







            capturedev = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo Dev in capturedev)


            {
                comboBox1.Items.Add(Dev.Name);
            }
            comboBox1.SelectedIndex = 0;

            connection.Close();
        }

       
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            finalframe = new VideoCaptureDevice(capturedev[comboBox1.SelectedIndex].MonikerString);
            finalframe.NewFrame += new NewFrameEventHandler(FinalFrame_NewFrame);
            finalframe.Start();
            timer1.Enabled = true;
            timer1.Start();
        }
      
        private void timer1_Tick(object sender, EventArgs e)
        {
            BarcodeReader red = new BarcodeReader();
            if (pictureBox1.Image != null)

            {
                Result res = red.Decode((Bitmap)pictureBox1.Image);
                try
                {
                    string dec = res.ToString().Trim();
                    textBox1.Text = dec;
                    if (dec == textBox3.Text) {


                     
                        Form15 fff = new Form15(textBox2.Text);
                        fff.Show();
                        this.Close();
                        





                    }
                   
                    else {
                        Form14 ww = new Form14(textBox2.Text);
                        this.Close();
                        ww.Show();

                    }
                
                }
                catch (Exception ex)
                {
               
                }

            }
        }

        private void FinalFrame_NewFrame(Object sender, NewFrameEventArgs eventArgs)

        {

            try {
                pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();

            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);

            }



        }

        private void Form7_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (finalframe != null)
                if (finalframe.IsRunning == true)
                {
                    finalframe.Stop();
                }
        }

      

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            
        
    }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

       

        private void Form7_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Enabled = false;
         
            Form1 you = new Form1();
            this.Close();
            you.Show();
        }
    }
}


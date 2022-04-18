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

namespace QRCodeBasedLockerSystem
{
    public partial class awdwa : Form
    {
        FilterInfoCollection capturedev;
        private VideoCaptureDevice finalframe;

        public awdwa()
        {
            InitializeComponent();
        }

        private void awdwa_Load(object sender, EventArgs e)
        {



            serialPort1.Open();
















            capturedev = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo Dev in capturedev)


            {
                comboBox1.Items.Add(Dev.Name);
            }
            comboBox1.SelectedIndex = 0;
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
                    if (dec == "http://ilnk.me/coupons")
                    {

                        try
                        {
                            serialPort1.Write("1");

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    }
                    else if (dec == "12345678")
                    {

                        try
                        {
                            serialPort1.Write("2");


                        }
                        catch (Exception)
                        {

                        }


                    }
                    else if (dec == "http://www.youtube.com/watch?v=S5KafuOcyn4")
                    {

                        try
                        {
                            serialPort1.Write("3");


                        }
                        catch (Exception)
                        {

                        }


                    }
                    else if (dec == "www.internationalbarcodes.net")
                    {

                        try
                        {
                            serialPort1.Write("4");


                        }
                        catch (Exception)
                        {

                        }


                    }
                    else
                    {
                        try
                        {
                            serialPort1.Write("0");

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    }

                }
                catch (Exception ex)
                {

                }

            }
        }

        private void FinalFrame_NewFrame(Object sender, NewFrameEventArgs eventArgs)

        {

            try
            {
                pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();

            }
            catch (Exception ex)
            {

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

        private void button1_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            Form1 you = new Form1();
            this.Close();
            you.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Write("0");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Write("2");


            }
            catch (Exception)
            {

            }
        }
    }
}

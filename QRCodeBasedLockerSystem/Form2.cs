using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QRCodeBasedLockerSystem
{
    public partial class Form2 : Form
    {
      
        public Form2()
        {
            InitializeComponent();

        }
       
        public static string a;
        private void button1_Click(object sender, EventArgs e)
        {
            Form17 f3 = new Form17();
            this.Hide();
            f3.ShowDialog();
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.ShowDialog();
        }
        public static string b;
        protected void button2_Click(object sender, EventArgs e)
        {
            Form18 f3 = new Form18();
            this.Hide();
            f3.ShowDialog();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form19 f5 = new Form19();
            this.Hide();
            f5.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form20 f6 = new Form20();
            this.Hide();
            f6.ShowDialog();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

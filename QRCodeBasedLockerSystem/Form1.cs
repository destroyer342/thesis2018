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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            USER f2 = new USER();
            this.Hide();
            f2.Show();   

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }


        private void button3_Click(object sender, EventArgs e)
        {
            Form10 f5 = new Form10();
            
            this.Hide();
            f5.Show();
            

            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form9 ii = new Form9();
            ii.Show();
            this.Hide();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 OO = new Form2();
            this.Hide();
            OO.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

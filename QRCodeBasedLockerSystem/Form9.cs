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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form7 f3 = new Form7();
            this.Hide();
            f3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form11 f4 = new Form11();
            this.Hide();
            f4.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form12 f5 = new Form12();
            this.Hide();
            f5.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form13 f5 = new Form13();
            this.Hide();
            f5.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 f5 = new Form1();
            this.Hide();
            f5.Show();
        }

        private void Form9_Load(object sender, EventArgs e)
        {

        }
    }
}

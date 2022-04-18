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
    public partial class Form14 : Form
    {
        public string ll;
        public Form14()
        {
            InitializeComponent();
        }
        public Form14(string ll)
        {
            InitializeComponent();
            this.ll = ll;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "1")
            {
                Form7 ii = new Form7();
                this.Hide();
                ii.Show();
            }
            else if (textBox1.Text == "2")
            {
                Form11 qq = new Form11();
                this.Hide();
                qq.Show();
            }
            else if (textBox1.Text == "3")
            {
                Form12 ww = new Form12();
                this.Hide();
                ww.Show();
            }
            else if (textBox1.Text == "4")
            {
                Form13 qqq = new Form13();
                this.Hide();
                qqq.Show();
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form14_Load(object sender, EventArgs e)
        {
            textBox1.Text = ll;
        }
    }
}

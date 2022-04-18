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
    public partial class USER : Form
    {
        public USER()
        {
            InitializeComponent();
        }
        MySqlConnection con = new MySqlConnection(@"Data Source=localhost; port=3306; Initial Catalog= rance;User ID=root;password=''");
        int i;
        private void Form10_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '•';
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            i = 0;
            
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select *from db where lockerno ='" + comboBox1.Text + "' and pword='" + textBox2.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());
            if (i == 0)
            {
                MessageBox.Show("invalid UserName or PassWord ");

                con.Close();
            }
            else
            {
                
                string selectQuery = "SELECT *From rance.db WHERE lockerno =" + int.Parse(comboBox1.Text);
                cmd = new MySqlCommand(selectQuery, con);


                    Form3 f3 = new Form3(comboBox1.Text);
                    this.Close();
                    f3.Show();
                    con.Close();
               
                  

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void USER_Load(object sender, EventArgs e)
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f5 = new Form1();
            this.Hide();
            f5.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

   



        }
    

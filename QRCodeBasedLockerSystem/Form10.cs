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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }
        MySqlConnection con = new MySqlConnection(@"Data Source=localhost; port=3306; Initial Catalog= rances;User ID=root;password=''");
        int i;
        private void Form10_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '•';
        }

        private void button1_Click(object sender, EventArgs e)
        {

            i = 0;
        con.Open();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText= "select *from db where fname ='"+textBox1.Text+"' and pword='"+textBox2.Text+"'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());
            if (i==0) {
                MessageBox.Show("invalid UserName or PassWord ");


            }
else {
               
                Form8 f3 = new Form8();
                this.Hide();
                f3.Show();

            }
            con.Close();



        }
    }
}

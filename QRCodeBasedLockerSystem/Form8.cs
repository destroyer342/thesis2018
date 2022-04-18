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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        MySqlConnection connection = new MySqlConnection("datasource=localhost ; port=3306;Initial Catalog = 'rance';username=root; password= ");
        MySqlCommand command;
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
                    this.Close();
                    Form8 ff = new Form8();
                    ff.Show();                    
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
        private void button1_Click(object sender, EventArgs e)
        {
           
          
            Form1 you = new Form1();
            this.Hide();
            you.Show();
           

        }


        private void Form8_Load(object sender, EventArgs e)
            
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            string selectQuery = "SELECT * from db ";
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuery, connection);
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            textBox3.PasswordChar = '*';

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string insertQuery = "INSERT INTO rance.db(lockerno,fname,pword,qrpass) VALUES('" + comboBox1.Text   + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
            executeQuery(insertQuery);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            button3.Enabled = true;
            textBox5.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string deleteQuery = "DELETE FROM db where lockerno = " + int.Parse(textBox5.Text);
            executeQuery(deleteQuery);
            
        }
    }
}

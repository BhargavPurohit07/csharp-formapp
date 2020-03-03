using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.OleDb;

namespace WindowsFormsApp1
{
    public partial class Reg : Form
    {
        private OleDbConnection con = new OleDbConnection();

        public Reg()
        {
            con.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\bharg\Desktop\test.accdb;Persist Security Info=False;";


            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                OleDbCommand cmd = new OleDbCommand();

                cmd.Connection = con;
                if (textBox3.Text == textBox4.Text && textBox1.Text != null && textBox2.Text != null && textBox3.Text != null)
                {

                    cmd.CommandText = "insert into Login (Name,Pass,Num) values( '" + textBox1.Text + "','" + textBox4.Text + "'," + textBox2.Text + " ) ";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("reg thai gyu");
                    Form1 f = new Form1();
                    this.Hide();
                    f.ShowDialog();
                    this.Close();

                }
                else {

                    MessageBox.Show("pass was not same");
                
                }
                con.Close();

            }
            catch (Exception ef)
            {
                MessageBox.Show(" " + ef);

            }
        }

        private void Reg_Load(object sender, EventArgs e)
        {

        }
    }
}

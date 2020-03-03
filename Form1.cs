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
    public partial class Form1 : Form
    {
        //Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\bharg\Desktop\test.accdb
       private OleDbConnection con = new OleDbConnection();

        public Form1()
        {   
            
            InitializeComponent();
            con.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\bharg\Desktop\test.accdb;Persist Security Info=False;";


        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                con.Open();

                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from Login where Name='"+textBox1.Text+"' and Pass='"+textBox2.Text+"' ";
                OleDbDataReader red =  cmd.ExecuteReader();

                int c = 0;
                while (red.Read()) {
                    c = c+1;
                
                }
                if (c == 1)
                {
                    con.Close();
                    con.Dispose();
                    this.Hide();
                    aftlogin f2 = new aftlogin(textBox1.Text);
                   
                    f2.ShowDialog();
                    this.Close();
                }
                else {


                    MessageBox.Show("error in id or pass");
                }
                con.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("error:-");

            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {

            try
            {
                
                con.Open();
                con.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("error:-");

            }

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Reg r = new Reg();
            this.Hide();
            r.ShowDialog();
            this.Close();
        }
    }
}

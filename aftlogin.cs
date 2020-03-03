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
    public partial class aftlogin : Form
    {

        private OleDbConnection con = new OleDbConnection();

        public aftlogin(string s)
        {
            InitializeComponent();
            con.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\bharg\Desktop\test.accdb;Persist Security Info=False;";


            label1.Text = "welcome " + s;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = con;
                cmd.CommandText = "insert into EmpD (Name,Pay,DOB,Country,Numb) values( '" + TName.Text + "'," +Convert.ToDecimal(Pay.Text) +",'"+DOB.Text + "','"+Conutry.Text.ToString()+"', '"+Numb.Text +"' ) ";
                MessageBox.Show("savedd...");
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ef)
            {
                MessageBox.Show(" " + ef);

            }
        }



        private void button2_Click(object sender, EventArgs e)
        {


            try
            {
                con.Open();

                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = con;
                string qur = "delete from EmpD where Eid=" + textBox1.Text+"";
                cmd.CommandText = qur;
                MessageBox.Show("deleted...");
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ef)
            {
                MessageBox.Show(" " + ef);

            }


        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f2 = new Form1();

            f2.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = con;
                string qur = "update EmpD set Name='"+TName.Text+ "', Pay=" + Convert.ToDecimal(Pay.Text) + ",DOB='"+DOB.Text+ "', Country='" + Conutry.Text.ToString() + "',Numb='" + Numb.Text+"' where Eid="+textBox1.Text;
                cmd.CommandText = qur;
                MessageBox.Show("edited...");
                cmd.ExecuteNonQuery();
                con.Close();
                
            }
            catch (Exception ef)
            {
                MessageBox.Show(" " + ef);

            }
        }

        private void aftlogin_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                OleDbCommand cmd = new OleDbCommand();

                cmd.Connection = con;

                string qur = "select * from Cont";
                string qur1 = "select * from EmpD";

                cmd.CommandText = qur;


                OleDbDataReader rd = cmd.ExecuteReader();


                while (rd.Read()) {
                    Conutry.Items.Add(rd["Country"].ToString());


                }
                rd.Close();
                cmd.CommandText = qur1;
                OleDbDataReader rd2 = cmd.ExecuteReader();

                while (rd2.Read())
                {
                    comboBox1.Items.Add(rd2["Eid"].ToString());


                }
                rd.Close();
                
                con.Close();

            }
            catch (Exception ef)
            {
                MessageBox.Show(" " + ef);

            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                con.Open();

                OleDbCommand cmd = new OleDbCommand();

                cmd.Connection = con;

                string qur1 = "select * from EmpD where Eid=" + comboBox1.Text + "";

                cmd.CommandText = qur1;


                OleDbDataReader rd = cmd.ExecuteReader();


                while (rd.Read())
                {

                    textBox1.Text =rd[0].ToString();
                    TName.Text = rd[1].ToString();
                    Numb.Text = rd[5].ToString();
                    Pay.Text = rd[4].ToString();
                    DOB.Value = Convert.ToDateTime (rd[2]);
                    Conutry.SelectedItem = rd[3].ToString();

                }


                con.Close();

            }
            catch (Exception ef)
            {
                MessageBox.Show(" " + ef);

            }



        }

        private void button4_Click(object sender, EventArgs e)
        {



            try
            {
                con.Open();

                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = con;
                string qur = "select * from "+comboBox2.Text+" ";
                cmd.CommandText = qur;
                cmd.ExecuteNonQuery();
                
                OleDbDataAdapter adt = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                adt.Fill(dt);
                dataGridView1.DataSource = dt;

                con.Close();

            }
            catch (Exception ef)
            {
                MessageBox.Show(" " + ef);

            }




        }

        private void ShowChart_Click(object sender, EventArgs e)
        {
            con.Open();

            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from EmpD";
            OleDbDataReader red = cmd.ExecuteReader();

            while (red.Read())
            {
                chart1.Series["Pay"].Points.AddXY(red["Name"].ToString(),red["Pay"].ToString());
            }
            con.Close();
        }
    }
}

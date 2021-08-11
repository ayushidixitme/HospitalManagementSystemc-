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
using System.IO;
namespace HOSPITALMANAGEMENTSYSTEM
{
    public partial class Patient1 : Form
    {
        OleDbCommand cmd;
        OleDbConnection con;
        OleDbDataReader dr;
        string str, sql;
        //string cmdtext = "Select * from[Physician]";
                                 
        public Patient1()
        {
            InitializeComponent();
            str = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=G:\HOSPITALDB.accdb";
            con = new OleDbConnection(str);
          }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
             if (radioButton1.Checked)
            {
                textBox9.Enabled = true;
                textBox7.Enabled = true;
                button1.Enabled = true;
           
            }
        }
        
        


        private void button1_Click(object sender, EventArgs e)
        {
           
            if (button1.Enabled == true)
            { 
                Form4 d = new Form4();
                d.Show();
                textBox7.Text = Form4.rp1.ToString();
                textBox10.Enabled = true;
               
            }

        }


        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {
            if(radioButton4.Checked)
            {
                textBox11.Enabled = true;
                textBox12.Enabled = true;
                dateTimePicker1.Enabled = true;

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string a, b, c, d, te, f, l, m, n,q,p,s;
             a = textBox2.Text;
             b = textBox3.Text;
             c = textBox4.Text;
             d = textBox5.Text;
             te = textBox6.Text;
             f = textBox13.Text;
            sql = "insert into Patient values('" + a + "','" + b  + "','" + c + "','" + d + "','" + te + "','" + f + "')";
            cmd = new OleDbCommand(sql, con);
            con.Open();
            int r= cmd.ExecuteNonQuery();
            MessageBox.Show(r + " row inserted Into Patient");
            con.Close();
            if(radioButton1.Checked)
            {
                l = textBox10.Text;
                n = textBox9.Text;
                sql = "insert into Stays(ID,pateint,room,stime)"+" values('" + l + "','" + a + "','" + n + "',#" + dateTimePicker1.Value+ "#)";
                cmd = new OleDbCommand(sql, con);
                con.Open();
                int y = cmd.ExecuteNonQuery();
                MessageBox.Show(y + " row inserted Into Stays");
                sql = "Update Room set availibility='" + false + "' Where roomno='" + n + "'";
                cmd = new OleDbCommand(sql, con);
                
                dr = cmd.ExecuteReader();
                con.Close();
            }
            if (radioButton4.Checked)
            {
                a = textBox2.Text;
                q = textBox11.Text;
                l = textBox10.Text;
                
                p= textBox12.Text;
                s = textBox8.Text;
                sql = "insert into Undergoes values('" + a + "','" + q + "','" + l + "',#" + dateTimePicker2.Value + "#,'" + p + "','" + s + "')";
                cmd = new OleDbCommand(sql, con);
                con.Open();
                int yu = cmd.ExecuteNonQuery();
                MessageBox.Show(yu + " row inserted Into UnderGoes");
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}


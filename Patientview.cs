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
    public partial class Patientview : Form
    {
        OleDbCommand cmd;
        OleDbConnection con;
        OleDbDataReader dr;
        string str, sql, sql1;
        public static string rc = "", pc = "";
        public static int d;
        public static string T="yu";

        private void button5_Click(object sender, EventArgs e)//amount
        {
            con.Open();
            string id = textBox9.Text;
            sql = "select* from Room where roomno ='" + id + "'";
            cmd = new OleDbCommand(sql, con);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    rc = dr[5].ToString();
                }
            }
            int t = Convert.ToInt32(textBox11.Text);
            string i = t.ToString();
            sql = "select* from Proce where prcode ='" + i + "'";
            cmd = new OleDbCommand(sql, con);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    pc = dr[2].ToString();
                }
            }
            if (pc == "")
            {
                pc = "0";
            }
            if (rc == "")
            {
                rc = "0";
            }

            con.Close();
            DateTime sdt = dateTimePicker1.Value;
            DateTime now = DateTime.Now;
            TimeSpan diff = now.Subtract(sdt);
            d = diff.Days;
            tc = (Convert.ToInt32(rc) * d + Convert.ToInt32(pc));
            Billing ob = new Billing(2);
            ob.Show();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            string id = textBox9.Text;
            
            sql = "select* from Room where roomno ='" + id + "'";
            cmd = new OleDbCommand(sql, con);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    rc = dr[5].ToString();
                }
            }
           
            int t = Convert.ToInt32(textBox11.Text);
            string i = t.ToString();
            sql = "select* from Proce where prcode ='" + i + "'";
            cmd = new OleDbCommand(sql, con);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    pc = dr[2].ToString();
                }
            }
            if (pc == "")
            {
                pc = "0";
            }
            if (rc == "")
            {
                rc = "0";
            }
           
            con.Close();
            DateTime sdt = dateTimePicker1.Value;
            DateTime now = DateTime.Now;
            TimeSpan diff = now.Subtract(sdt);
            d = diff.Days;
            tc = (Convert.ToInt32(rc) * d + Convert.ToInt32(pc));
            Billing ob = new Billing(2);
            ob.Show();


        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        public static int tc;
        public Patientview()
        {
            InitializeComponent();
            str = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=G:\HOSPITALDB.accdb";
            con = new OleDbConnection(str);
        }

        private void Patientview_Load(object sender, EventArgs e)
        {

            string i = Form1.up;
            con.Open();
            sql = "select* from Patient where ssn ='" + i + "'";
            cmd = new OleDbCommand(sql, con);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    textBox2.Text = dr[0].ToString();
                    textBox3.Text = dr[1].ToString();
                    textBox4.Text = dr[2].ToString();
                    textBox5.Text = dr[3].ToString();
                    textBox6.Text = dr[4].ToString();
                    textBox13.Text = dr[5].ToString();
                }
                sql1 = "select* from Stays where pateint ='" + i + "'";
                cmd = new OleDbCommand(sql1, con);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
          

                    while (dr.Read())
                    {

                       
                        textBox9.Text = dr[2].ToString();
                        dateTimePicker1.Text = dr[3].ToString();
                    }
                }
                

                sql1 = "select* from Undergoes where patient ='" + i + "'";
                cmd = new OleDbCommand(sql1, con);
                dr = cmd.ExecuteReader();
                Patient2.fe2 = dr.HasRows;
                if (dr.HasRows)
                {
                    Patient2.fe2 = true;

                    while (dr.Read())
                    {

                        radioButton4.Checked = true;
                        textBox2.Text = dr[0].ToString();
                        textBox11.Text = dr[1].ToString();
                        dateTimePicker2.Text = dr[3].ToString();
                        textBox12.Text = dr[4].ToString();
                        textBox8.Text = dr[5].ToString();

                    }
                }
               


                con.Close();
            }
        }
    }
}

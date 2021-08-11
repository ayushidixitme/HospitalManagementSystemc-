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
    public partial class Form1 : Form
    {
        OleDbCommand cmd;
        OleDbConnection con;
        OleDbDataReader dr;
        string str, sql;
        public static string un="";
        public static string up = "";

        public Form1()
        {
            InitializeComponent();
            str = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=G:\HOSPITALDB.accdb";
            con = new OleDbConnection(str);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                string un, up;
                un = textBox1.Text;
                up = textBox2.Text;
                sql = "select* from admin where aname ='" + un + "'";
                cmd = new OleDbCommand(sql, con);
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        if (dr[0].Equals(un) && dr[1].Equals(up))
                        {
                            MessageBox.Show("Successfully Login");
                            Form2 f2 = new Form2();
                            f2.Show();
                        }

                        else
                            MessageBox.Show("Wrong Password");
                    }
                }
                dr.Close();
                con.Close();
                cmd.Dispose();
            }
            else if(comboBox1.SelectedIndex == 1)
            {
                
                un = textBox1.Text;
                up = textBox2.Text;
                sql = "select* from Patient where pname ='" + un + "'";
                cmd = new OleDbCommand(sql, con);
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        if (dr[1].Equals(un) && dr[0].Equals(up))
                        {
                            MessageBox.Show("Successfully Login");
                             Patientview ob = new Patientview();
                            ob.Show();
                        }

                        else
                            MessageBox.Show("Wrong Password");
                    }
                }
                dr.Close();
                con.Close();
                cmd.Dispose();

            }
        }
    }
}

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
    public partial class Procedures : Form
    {
        OleDbCommand cmd;
        OleDbConnection con;
        OleDbDataReader dr;
        string str, sql;
        string cmdtext = "Select * from[Proce]";
        public Procedures()
        {
            InitializeComponent();
            str = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=G:\HOSPITALDB.accdb";
            con = new OleDbConnection(str);
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(cmdtext, str);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds, "[Proce]");
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }

        private void button2_Click(object sender, EventArgs e)//update
        {
            string prcode, prname, pcost;
            prcode = textBox2.Text;
            prname = textBox1.Text;
            pcost = textBox4.Text;
            sql = "Update Proce set prname='" + prname + "', prcost='" + pcost + "' Where prcode='" + prcode + "'";
            cmd = new OleDbCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    textBox2.Text=dr[0].ToString();
                    textBox1.Text = dr[1].ToString();
                    textBox4.Text = dr[2].ToString();

                }
            }

            con.Close();

        }

        private void button5_Click(object sender, EventArgs e)//search
        {
            con.Open();
            if (textBox2.Text!= "")
            {
                string id = textBox2.Text;
                sql = "select* from Proce where prcode ='" + id + "'";
                cmd = new OleDbCommand(sql, con);

                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        textBox2.Text = dr[0].ToString();
                        textBox1.Text = dr[1].ToString();
                        textBox4.Text = dr[2].ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Data Doesn't Exists");
                }
                con.Close();

            }
        }

        private void button3_Click(object sender, EventArgs e)///delete
        {
            string id = textBox2.Text;
            sql = "delete from Proce where prcode='" + id + "'";
            cmd = new OleDbCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();
            MessageBox.Show("DELETED");
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox1.Clear();
            textBox4.Clear();

        }

        private void button1_Click(object sender, EventArgs e)//save
        {
            string prcode, prname, pcost;
            prcode = textBox2.Text;
            prname = textBox1.Text; 
            pcost = textBox4.Text;
           // sql = "insert into Nurse values('" + id + "','" + name + "','" + posn + "','" + reg + "','" + ssn + "')";

            sql = "insert into Proce values('" + prcode + "','" + prname + "','"+ pcost + "')";
            cmd = new OleDbCommand(sql, con);
            con.Open();
            int r = cmd.ExecuteNonQuery();
            MessageBox.Show(r + " row inserted into Procedures");
            con.Close();

        }
    }
}

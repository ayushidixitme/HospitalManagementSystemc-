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
    public partial class Nurse : Form
    {
        OleDbCommand cmd;
        OleDbConnection con;
        OleDbDataReader dr;
        string str, sql;
        string cmdtext = "Select * from[Nurse]";
        public Nurse()
        {
            InitializeComponent();
            str = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=G:\HOSPITALDB.accdb";
            con = new OleDbConnection(str);
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(cmdtext, str);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds, "[Nurse]");
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }

        private void button5_Click(object sender, EventArgs e)//search
        {
            con.Open();
            if (textBox1.Text != "")
            {
                string id = textBox1.Text;
                sql = "select* from Nurse where Nid ='" + id + "'";
                cmd = new OleDbCommand(sql, con);

                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        textBox1.Text = dr[0].ToString();
                        textBox2.Text = dr[1].ToString();
                        comboBox1.Text = dr[2].ToString();
                        comboBox2.Text = dr[3].ToString();
                        textBox3.Text = dr[4].ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Data Doesn't Exists");
                }

            }
            else if (textBox2.Text != "")
            {
                string name = textBox2.Text;
                sql = "select* from Nurse where nname ='" + name + "'";
                cmd = new OleDbCommand(sql, con);

                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        textBox1.Text = dr[0].ToString();
                        textBox2.Text = dr[1].ToString();
                        comboBox1.Text = dr[2].ToString();
                        comboBox2.Text = dr[3].ToString();
                        textBox3.Text = dr[4].ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Data Doesn't Exists");
                }
            }
            else
            {
                MessageBox.Show("Data Doesn't Exists");
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)//Update
        {
            string id, name, pos, ssn,reg;
            id = textBox1.Text;
            name = textBox2.Text;
            pos = comboBox1.Text;
            ssn = textBox3.Text;
            reg = comboBox2.Text;
            sql = "Update Nurse set nname='" + name + "', npos='" + pos + "', registered='" + reg + "', ss='" + ssn + "' Where Nid='" + id + "'";
            cmd = new OleDbCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    textBox1.Text = dr[0].ToString();
                    textBox2.Text = dr[1].ToString();
                    comboBox1.Text = dr[2].ToString();
                    comboBox2.Text = dr[3].ToString();
                    textBox3.Text = dr[4].ToString();
                }
            }

            con.Close();

        }

        private void button3_Click(object sender, EventArgs e)//Delete
        {
            string id = textBox1.Text;
            sql = "delete from Nurse where Nid='" + id + "'";
            cmd = new OleDbCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();
            MessageBox.Show("DELETED");
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            comboBox1.Text = "";
            comboBox2.Text = "";
            textBox3.Clear();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)//Save
        {
            string id, name, posn,reg, ssn;
            id = textBox1.Text;
            name = textBox2.Text;
            posn = comboBox1.Text;
            reg = comboBox2.Text;
            ssn = textBox3.Text;
            sql = "insert into Nurse values('" + id + "','" + name + "','" + posn + "','" + reg + "','" + ssn + "')";
            cmd = new OleDbCommand(sql, con);
            con.Open();
            int r = cmd.ExecuteNonQuery();
            MessageBox.Show(r + "row inserted");
            con.Close();
        }
    }
}

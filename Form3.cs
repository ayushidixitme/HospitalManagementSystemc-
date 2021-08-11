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
    public partial class Form3 : Form
    {
        OleDbCommand cmd;
        OleDbConnection con;
        OleDbDataReader dr;
        string str, sql;
        string cmdtext = "Select * from[Physician]";
  
        public Form3()
        {
            InitializeComponent();
            str = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=G:\HOSPITALDB.accdb";
            con = new OleDbConnection(str);
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(cmdtext,str);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds, "[Physician]");
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
               
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)//search
        {
            con.Open();
            if (textBox1.Text != "")
            {
                string id = textBox1.Text;
                sql = "select* from physician where eid ='" +id + "'";
                cmd = new OleDbCommand(sql, con);
               
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        textBox1.Text = dr[0].ToString();
                        textBox2.Text = dr[1].ToString();
                        comboBox1.Text = dr[2].ToString();
                        textBox3.Text = dr[3].ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Data Doesn't Exists");
                }
               
            }
            else if(textBox2.Text!="")
            {
                string name = textBox2.Text;
                sql = "select* from physician where sname ='" + name + "'";
                cmd = new OleDbCommand(sql, con);
                
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        textBox1.Text = dr[0].ToString();
                        textBox2.Text = dr[1].ToString();
                        comboBox1.Text = dr[2].ToString();
                        textBox3.Text = dr[3].ToString();
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

        private void button2_Click(object sender, EventArgs e)//update
        {
            string id, name, pos, ssn;
            id = textBox1.Text;
            name = textBox2.Text;
            pos = comboBox1.Text;
            ssn = textBox3.Text;
            sql = "Update Physician set sname='" + name + "', posn='" + pos + "', ssn='" + ssn + "' Where Eid='" + id + "'";
            cmd = new OleDbCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    textBox1.Text = dr[0].ToString();
                    textBox2.Text = dr[1].ToString();
                    comboBox1.Text= dr[2].ToString();
                    textBox3.Text = dr[3].ToString();
                }
            }

            con.Close();


        }

        private void button4_Click(object sender, EventArgs e)//clear
        {
            textBox1.Clear();
            textBox2.Clear();
            comboBox1.Text="";
            textBox3.Clear();
        }

        private void button3_Click(object sender, EventArgs e)//delete
        {
            string id = textBox1.Text;
            sql = "delete from Physician where Eid='" + id + "'";
            cmd = new OleDbCommand(sql,con);
            con.Open();
            dr = cmd.ExecuteReader();
            MessageBox.Show("DELETED");
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)//save
        {
            string id, name, posn, ssn;
            id = textBox1.Text;
            name = textBox2.Text;
            posn = comboBox1.Text;
            ssn = textBox3.Text;
            sql = "insert into Physician values('" + id + "','" + name + "','" + posn + "','" + ssn + "')";
            cmd = new OleDbCommand(sql, con);
            con.Open();
            int r = cmd.ExecuteNonQuery();
            MessageBox.Show(r+ " row inserted");
            con.Close( );
        }
    }
}









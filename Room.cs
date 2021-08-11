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
    public partial class Room : Form
    {
        OleDbCommand cmd;
        OleDbConnection con;
        OleDbDataReader dr;
        string str, sql;
        string cmdtext = "Select * from[Room]";
        public Room()
        {
            InitializeComponent();
            str = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=G:\HOSPITALDB.accdb";
            con = new OleDbConnection(str);
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(cmdtext, str);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds, "[Room]");
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
                textBox3.Text = "1000";
            else if (comboBox1.SelectedIndex == 1)
                textBox3.Text = "2000";
            else if (comboBox1.SelectedIndex == 2)
                textBox3.Text = "4000";
            else if (comboBox1.SelectedIndex == 3)
                textBox3.Text = "6000";
            else if (comboBox1.SelectedIndex == 4)
                textBox3.Text = "8000";
            else  if(comboBox1.SelectedIndex == 5)
                textBox3.Text = "10000";
            

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)//search
        {
            con.Open();
            if (textBox2.Text != "")
            {
                string id = textBox2.Text;
                sql = "select* from Room where roomno ='" + id + "'";
                cmd = new OleDbCommand(sql, con);

                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        textBox2.Text = dr[0].ToString();
                        comboBox1.Text = dr[1].ToString();
                        textBox4.Text = dr[2].ToString();
                        textBox1.Text = dr[3].ToString();
                        comboBox2.Text = dr[4].ToString();
                        textBox3.Text = dr[5].ToString();

                    }
                }
                else
                {
                    MessageBox.Show("Data Doesn't Exists");
                }
                con.Close();

            }
        }

        private void button2_Click(object sender, EventArgs e)//UPDATE
        {
          
            string rn, rt, bn, bc, c, av;
            rn = textBox2.Text;
            rt = comboBox1.Text;
            bn = textBox4.Text;
            bc = textBox1.Text;
            av = comboBox2.Text;
            c = textBox3.Text;

            sql = "Update Room set rtype='" + rt + "', bfloor ='" + bn + "', bcode='" + bc + "', availibility='" + av + "', cost='" + c + "' Where roomno='" + rn + "'";
            //sql = "Update Physician set sname='" + name + "', posn='" + pos + "', ssn='" + ssn + "' Where Eid='" + id + "'";
            con.Open();
            cmd = new OleDbCommand(sql, con);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    textBox2.Text = dr[0].ToString();
                    comboBox1.Text = dr[1].ToString();
                    textBox4.Text = dr[2].ToString();
                    textBox1.Text = dr[3].ToString();
                    comboBox2.Text = dr[4].ToString();
                    textBox3.Text = dr[5].ToString();

                }
            }

            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)//delete
        {
            string id = textBox2.Text;
            sql = "delete from Room where roomno='" + id + "'";
            cmd = new OleDbCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();
            MessageBox.Show("DELETED");
            con.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)//Save
        {
            string rn, rt, bn, bc,c,av;
            rn = textBox2.Text;
            rt = comboBox1.Text;
            bn = textBox4.Text;
            bc = textBox1.Text;
            if (comboBox2.SelectedIndex == 0)
                av = "true";
            else
                av = "false";
            c = textBox3.Text;

            sql = "insert into Room values('" + rn + "','" + rt + "','" + bn + "','" + bc + "','" + av + "','" + c + "')";
            cmd = new OleDbCommand(sql, con);
            con.Open();
            int r = cmd.ExecuteNonQuery();
            MessageBox.Show(r + " row inserted");
            con.Close();
        }

        /*private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            sql = "select* from Room where rtype ='" + comboBox1.Text + "'";
            cmd = new OleDbCommand(sql, con);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    textBox2.Text = dr[0].ToString();
                    textBox4.Text = dr[1].ToString();
                    comboBox1.Text = dr[2].ToString();
                    textBox1.Text = dr[3].ToString();
                    textBox5.Text = dr[4].ToString();
                }
            }
            else
            {
                MessageBox.Show("invalid entry");
            }*/


        }
}


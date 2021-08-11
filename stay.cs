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
    
    public partial class stay : Form
    {
        OleDbCommand cmd;
        OleDbConnection con;
        OleDbDataReader dr;
        string str, sql;
        string sql1;
        string cmdtext = "Select * from[Stays]";
        public stay()
        {
            InitializeComponent();
            str = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=G:\HOSPITALDB.accdb";
            con = new OleDbConnection(str);
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(cmdtext, str);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds, "[Stays]");
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }

        private void button5_Click(object sender, EventArgs e)//search
        {
            con.Open();
            if (textBox2.Text != "")
            {
                string id = textBox2.Text;
                sql = "select* from Stays where ID   ='" + id + "'";
                cmd = new OleDbCommand(sql, con);

                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        textBox2.Text = dr[0].ToString();
                        textBox3.Text = dr[1].ToString();
                        textBox1.Text = dr[2].ToString();
                        dateTimePicker1.Text = dr[3].ToString();
                        dateTimePicker1.Text = dr[4].ToString();


                    }
                }
                else
                {
                    MessageBox.Show("Data Doesn't Exists");
                }
                con.Close();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string id = textBox2.Text;
            sql = "delete from Stays where ID='" + id + "'";
            cmd = new OleDbCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();
            MessageBox.Show("DELETED");
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string a, b,c;
            if (dateTimePicker2.Checked == true)
            {
                string sd = dateTimePicker1.Value.ToShortDateString();
                string ed = dateTimePicker2.Value.ToShortDateString();
                a = textBox2.Text;
                b = textBox3.Text;
                c = textBox1.Text;
                sql1 = "Update Stays set roomno='" + a + "',pateint='" + c + "', stime='" + sd + "', etime='" + ed + "' Where ID='" + a + "'";
                cmd = new OleDbCommand(sql1, con);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        textBox2.Text = dr[0].ToString();
                        textBox3.Text = dr[1].ToString();
                        textBox1.Text = dr[2].ToString();
                        dateTimePicker1.Text = dr[3].ToString();
                        dateTimePicker1.Text = dr[4].ToString();
                    }
                }
            }
        }

        
    }
}

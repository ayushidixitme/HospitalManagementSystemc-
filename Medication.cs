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
    public partial class Medication : Form
    {
        OleDbCommand cmd;
        OleDbConnection con;
        OleDbDataReader dr;
        string str, sql;
        string cmdtext = "Select * from[Prescribes]";
        DataSet ds = new DataSet();
        public Medication()
        {
            InitializeComponent();
            str = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=G:\HOSPITALDB.accdb";
            con = new OleDbConnection(str);
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(cmdtext, str);
            dataAdapter.Fill(ds, "[Prescribes]");
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string p = textBox4.Text;
            string s = comboBox1.Text;
            string Phy = textBox1.Text;
            string pa = textBox2.Text;

            sql = "Update Prescribes set Physician='" + Phy + "', medication ='" + p + "', dose='" + s + "' Where patient ='" + pa + "'";
            //sql = "Update Physician set sname='" + name + "', posn='" + pos + "', ssn='" + ssn + "' Where Eid='" + id + "'";
            con.Open();
            cmd = new OleDbCommand(sql, con);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    textBox2.Text = dr[1].ToString();
                    textBox1.Text = dr[0].ToString();
                    textBox4.Text = dr[2].ToString();
                    comboBox1.Text = dr[5].ToString();


                }
            }
            con.Close();
        }

        private void Medication_Load(object sender, EventArgs e)//Formload
        {
                con.Open();
                string id =Patient2.paa;
                sql = "select* from Prescribes where patient ='" + id + "'";
                cmd = new OleDbCommand(sql, con);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        textBox2.Text = dr[1].ToString();
                        textBox1.Text = dr[0].ToString();
                        textBox4.Text = dr[2].ToString();
                        comboBox1.Text = dr[5].ToString();

                    }
                }
                else
                {
                    MessageBox.Show("Data Doesn't Exists");
                }
                con.Close();
                string u = Patient2.paa;
                DataView dv;
                try
                {
                 dv = new DataView(ds.Tables[0], "patient like '%"+u+"%'", "patient Desc", DataViewRowState.CurrentRows);
                 dataGridView1.DataSource = dv;
                }
                catch (System.Data.EvaluateException)
                {
                 MessageBox.Show("No Data Available");
                }
            con.Close();
        }



        private void button4_Click(object sender, EventArgs e)//search
        {
            con.Open();
            if (textBox2.Text != "")
            {
                string id = textBox2.Text;
                sql = "select* from Prescribes where patient ='" + id + "'";
                cmd = new OleDbCommand(sql, con);

                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        textBox2.Text = dr[1].ToString();
                        textBox1.Text = dr[0].ToString();
                        textBox4.Text = dr[2].ToString();
                        comboBox1.Text = dr[5].ToString();

                    }
                }
                else
                {
                    MessageBox.Show("Data Doesn't Exists");
                }
                con.Close();

            }
        }

        

        
    }
}

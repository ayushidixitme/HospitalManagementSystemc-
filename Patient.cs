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
    public partial class Patient : Form
    {
        OleDbCommand cmd;
        OleDbConnection con;
        OleDbDataReader dr;
        string str, sql;
        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();
        DataSet ds3 = new DataSet(); 
        DataSet ds4 = new DataSet();
        public static string sr;
        public Patient()
        {
           
            InitializeComponent();
            string cmdtext = "Select * from[Patient]";
            str = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=G:\HOSPITALDB.accdb";
            con = new OleDbConnection(str);
            OleDbDataAdapter dataAdapter1 = new OleDbDataAdapter(cmdtext, str);
            dataAdapter1.Fill(ds1, "[Patient]");
            dataGridView1.DataSource = ds1.Tables[0];

            string cmdtext1 = "Select * from[Stays]";
            con = new OleDbConnection(str);
            OleDbDataAdapter dataAdapter2 = new OleDbDataAdapter(cmdtext1, str);
            dataAdapter2.Fill(ds2, "[Stays]");
            dataGridView2.DataSource = ds2.Tables[0];

            string cmdtext3 = "Select * from[Room]";
            con = new OleDbConnection(str);
            OleDbDataAdapter dataAdapter3 = new OleDbDataAdapter(cmdtext3, str);
            dataAdapter3.Fill(ds3, "[Room]");
            dataGridView3.DataSource = ds3.Tables[0];

            string cmdtext4 = "Select * from[Undergoes]";
            con = new OleDbConnection(str);
            OleDbDataAdapter dataAdapter4 = new OleDbDataAdapter(cmdtext4, str);
            dataAdapter4.Fill(ds4, "[Undergoes]");
            dataGridView4.DataSource = ds4.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Patient1 ob = new Patient1();
            ob.Show();
        }

        private void button3_Click(object sender, EventArgs e)//search
        {
            sr = textBox1.Text;
            Patient2 f2 = new Patient2();
            f2.Show();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            if(textBox1.Text=="")
                MessageBox.Show("Enter Aadhaar Number");
            else
                sr = textBox1.Text;
            Patient2 f2 = new Patient2();
            f2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "")
                MessageBox.Show("Enter Aadhaar Number");
            else
                sr = textBox1.Text;
            Patient2 f2 = new Patient2();
            f2.Show();
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

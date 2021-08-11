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
    public partial class Form4 : Form
    {
        OleDbCommand cmd;
        OleDbConnection con;
        OleDbDataReader dr;
        string str, sql;
        public static int rp1;
         string[] a =new string[100];
        public static string rp;
        string cmdtext = "select* from [Room]";
        DataSet ds = new DataSet();
        
        public Form4()
        {
           
            InitializeComponent();
            str = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=G:\HOSPITALDB.accdb";
            con = new OleDbConnection(str);
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(cmdtext, str);
            dataAdapter.Fill(ds, "[Room]");
            dataGridView1.DataSource = ds.Tables[0];
           

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            rp1 = comboBox1.SelectedIndex;
            if (comboBox1.SelectedIndex==0)
            {
                 DataView dv;
                 dv = new DataView(ds.Tables[0], "rtype='Multibed Ward'", "rtype Desc", DataViewRowState.CurrentRows);
                 dataGridView1.DataSource = dv;
               /* string s1 = "Multibed Ward"; bool s2 = true;
                string sql1 = "select * from Room where rtype='" + s1 + "' and availibility =" + true+ "";
                OleDbConnection connection = new OleDbConnection(str);
                OleDbDataAdapter dataadapter = new OleDbDataAdapter(sql1, connection);
                connection.Open();
                dataadapter.Fill(ds, "Room");
                connection.Close();
                dataGridView1.DataSource = ds;*/

            }
            
            else if (comboBox1.SelectedIndex == 1)
            {
                 DataView dv;
                 dv = new DataView(ds.Tables[0], "rtype='Twin Sharing Ward'", "rtype Desc", DataViewRowState.CurrentRows);
                 dataGridView1.DataSource = dv;
                /*string s1 = "Multibed Ward", s2 = "True";
                string sql1 = "select * from Room where rtype='" + s1 + "' and availibility='" + true + "";
                OleDbConnection connection = new OleDbConnection(str);
                OleDbDataAdapter dataadapter = new OleDbDataAdapter(sql1, connection);
                connection.Open();
                dataadapter.Fill(ds, "Room");
                connection.Close();
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Room";*/
            }
            else if(comboBox1.SelectedIndex == 2)
            {
                DataView dv;
                dv = new DataView(ds.Tables[0], "rtype='Single Room'", "rtype Desc", DataViewRowState.CurrentRows);
                dataGridView1.DataSource = dv;
                /*string s1 = "Multibed Ward", s2 = "True";
                string sql1 = "select * from Room where rtype='" + s1 + "' and availibility='" + s2 + "'";
                OleDbConnection connection = new OleDbConnection(str);
                OleDbDataAdapter dataadapter = new OleDbDataAdapter(sql1, connection);
                connection.Open();
                dataadapter.Fill(ds, "Room");
                connection.Close();
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Room";*/
            }
            else if (comboBox1.SelectedIndex == 3)
            {
               DataView dv;
               dv = new DataView(ds.Tables[0], "rtype='Single Deluxe Room'", "rtype Desc", DataViewRowState.CurrentRows);
               dataGridView1.DataSource = dv; 
                /* string s1 = "Multibed Ward", s2 = "True";
                string sql1 = "select * from Room where rtype='" + s1 + "' and availibility='" + s2 + "'";
                OleDbConnection connection = new OleDbConnection(str);
                OleDbDataAdapter dataadapter = new OleDbDataAdapter(sql1, connection);
                connection.Open();
                dataadapter.Fill(ds, "Room");
                connection.Close();
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Room";*/
            }
            else if(comboBox1.SelectedIndex == 4)
            {
                DataView dv;
               dv = new DataView(ds.Tables[0], "rtype='Super Deluxe Room'", "rtype Desc", DataViewRowState.CurrentRows);
               dataGridView1.DataSource = dv;
                /*string s1 = "Multibed Ward", s2 = "True";
                string sql1 = "select * from Room where rtype='" + s1 + "' and availibility='" + s2 + "'";
                OleDbConnection connection = new OleDbConnection(str);
                OleDbDataAdapter dataadapter = new OleDbDataAdapter(sql1, connection);
                connection.Open();
                dataadapter.Fill(ds, "Room");
                connection.Close();
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Room";*/
            }
            else
            {
                DataView dv;
               dv = new DataView(ds.Tables[0], "rtype='Suite'", "rtype Desc", DataViewRowState.CurrentRows);
               dataGridView1.DataSource = dv; /*/
                /*string s1 = "Multibed Ward", s2 = "True";
                string sql1 = "select * from Room where rtype='" + s1 + "' and availibility='" + s2 + "'";
                OleDbConnection connection = new OleDbConnection(str);
                OleDbDataAdapter dataadapter = new OleDbDataAdapter(sql1, connection);
                connection.Open();
                dataadapter.Fill(ds, "Room");
                connection.Close();
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Room";*/
            }

            
        }

        private void button2_Click(object sender, EventArgs e)//Okay
        {
            Room ob = new Room();
            ob.Show();
            rp1 = comboBox1.SelectedIndex; 
            rp1 = rp1 + 1;
            this.Close();

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}

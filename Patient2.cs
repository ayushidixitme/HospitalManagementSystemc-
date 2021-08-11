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

    public partial class Patient2 : Form
    {
        OleDbCommand cmd;
        OleDbConnection con;
        OleDbDataReader dr;
        string str, sql, sql1;
        public static bool fe1=false, fe2=false;
        public static string rc="", pc="";
        public static int tc ;
        public static int d;
        public static string paa="";
        public Patient2()
        {
            InitializeComponent();
            str = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=G:\HOSPITALDB.accdb";
            con = new OleDbConnection(str);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Enabled == true)
            {
                Form4 d = new Form4();
                d.Show();
                textBox7.Text = Form4.rp1.ToString();
                textBox10.Enabled = true;

            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (fe1 == false && radioButton1.Checked == true)
            {
                textBox7.Enabled = true;
                textBox9.Enabled = true;
                button1.Enabled = true;
                textBox10.Enabled = true;
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;
                button3.Enabled = true;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

            con.Open();
            dateTimePicker2.Value = DateTime.Now;
            string t = dateTimePicker2.Value.ToShortDateString();
            string av = "false";
            string rn = textBox9.Text;
            sql = "Update Room set  availibility='" + av + "' Where roomno='" + rn + "'";
            //sql = "Update Physician set sname='" + name + "', posn='" + pos + "', ssn='" + ssn + "' Where Eid='" + id + "'";
            cmd = new OleDbCommand(sql, con);
            dr = cmd.ExecuteReader();
            string id = textBox10.Text;
            sql = "delete from Stays where ID='" + id + "'";
            cmd = new OleDbCommand(sql, con);
            dr = cmd.ExecuteReader();
            id = textBox2.Text;
            sql = "delete from Prescribes where ssn='" + id + "'";
            cmd = new OleDbCommand(sql, con);
            dr = cmd.ExecuteReader();
            sql = "delete from Undergoes where Patient='" + id + "'";
            cmd = new OleDbCommand(sql, con);
            dr = cmd.ExecuteReader();
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Medication ob = new Medication();
            ob.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Procedures ob = new Procedures();
            ob.Show();
        }

        private void button5_Click(object sender, EventArgs e)//billing
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
            tc = (Convert.ToInt32(rc)*d + Convert.ToInt32(pc));
            Billing ob = new Billing(1);
            ob.Show();
        }


        private void button4_Click(object sender, EventArgs e)//update
        {
            string a, b, c, d, te, f, l, m, n, q, p, s;
            a = textBox2.Text;
            b = textBox3.Text;
            c = textBox4.Text;
            d = textBox5.Text;
            te = textBox6.Text;
            f = textBox13.Text;
            sql = "Update Patient set pname='" + b + "',address='" + c + "', phone='" + d + "', insuranceid='" + te + "', pcp='" + f + "' Where ssn='" + a + "'";
            cmd = new OleDbCommand(sql, con);
            con.Open();
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
            }
            

            if (fe1 == false)
            {
                if ((radioButton1.Checked) == true)
                {
                    string tt = dateTimePicker2.Value.ToShortDateString();
                    l = textBox10.Text;
                    n = textBox9.Text;
                    sql = "insert into Stays(ID,pateint,room,stime)" + " values('" + l + "','" + a + "','" + n + "','" + tt + "')";
                    cmd = new OleDbCommand(sql, con);
                    int y = cmd.ExecuteNonQuery();
                    MessageBox.Show(y + " row inserted Into Stays");
                    sql = "Update Room set availibility='" + "false" + "' Where roomno='" + n + "'";
                    cmd = new OleDbCommand(sql, con);

                    dr = cmd.ExecuteReader();

                }
            }

            if ((fe2 == false))
            {
                if ((radioButton4.Checked) == true)
                        {
                    string aa = dateTimePicker2.Value.ToShortDateString();
                    a = textBox2.Text;
                    q = textBox11.Text;
                    l = textBox10.Text;

                    p = textBox12.Text;
                    s = textBox8.Text;
                    sql = "insert into Undergoes values('" + a + "','" + q + "','" + l + "','" + aa + "','" + p + "','" + s + "')";
                    cmd = new OleDbCommand(sql, con);

                    int yu = cmd.ExecuteNonQuery();
                    MessageBox.Show(yu + " row inserted Into UnderGoes");

                }
            }
            if(textBox16.Text!="")
            {
                string ee = dateTimePicker4.Value.ToShortDateString();
                p = textBox16.Text;
                s =comboBox1.Text;
                string Phy = textBox13.Text;
                string pa = textBox2.Text;
                sql = "insert into Prescribes values('" + Phy + "','" + pa + "','" + p + "','" + ee + "','" + null + "','" + s + "')";
                cmd = new OleDbCommand(sql, con);
                
                int yu = cmd.ExecuteNonQuery();
                MessageBox.Show(yu + " row inserted Into Prescribes");
                

            }
            

            con.Close();
        }

        private void Patient2_Load(object sender, EventArgs e)
        {
            
            string i = Patient.sr;
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
                Patient2.fe1 = dr.HasRows;
                if (dr.HasRows)
                {
                    button3.Enabled = true;
                    Patient2.fe1 = true;

                    while (dr.Read())
                    {


                        radioButton1.Checked = true;
                        textBox9.Enabled = true;
                        textBox7.Enabled = true;
                        button1.Enabled = true;

                        textBox10.Text = dr[0].ToString();
                        textBox9.Text = dr[2].ToString();
                        dateTimePicker1.Text = dr[3].ToString();
                    }
                }
                else
                {
                    Patient2.fe1 = false;
                    button3.Enabled = false;
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
                        textBox11.Enabled = true;
                        textBox12.Enabled = true;
                        dateTimePicker1.Enabled = true;
                        textBox2.Text = dr[0].ToString();
                        textBox11.Text = dr[1].ToString();
                        dateTimePicker2.Text = dr[3].ToString();
                        textBox12.Text = dr[4].ToString();
                        textBox8.Text = dr[5].ToString();

                    }
                }
                else
                {
                    Patient2.fe2 = false;
                }
                paa = textBox2.Text;

                con.Close();
            }
            else
            {
                this.Close();
                MessageBox.Show("Data Doesn't Exists");
            }

         }

                private void groupBox6_Enter(object sender, EventArgs e)
                {

                }
            }
        }


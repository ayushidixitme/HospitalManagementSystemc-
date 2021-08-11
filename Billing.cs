using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace HOSPITALMANAGEMENTSYSTEM
{
    public partial class Billing : Form
    {
        StackTrace st = new StackTrace();
        int p;
        public Billing(int t)
        {
            InitializeComponent();
            p = t;
        }

        private void Billing_Load(object sender, EventArgs e)
        {
            if (p == 1)
            {
                textBox1.Text = Patient2.rc.ToString();
                textBox2.Text = Patient2.pc.ToString();
                textBox3.Text = Patient2.tc.ToString();
                textBox4.Text = Patient2.d.ToString();
            }
            if(p==2)
            {
                textBox1.Text = Patientview.rc.ToString();
                textBox2.Text = Patientview.pc.ToString();
                textBox3.Text = Patientview.tc.ToString();
                textBox4.Text = Patientview.d.ToString();
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

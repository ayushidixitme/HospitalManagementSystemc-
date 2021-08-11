using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HOSPITALMANAGEMENTSYSTEM
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//Doctor
        {
            Form3 a= new Form3();
            a.Show();
        }

        private void button6_Click(object sender, EventArgs e)//patient
        {
            Patient ob = new Patient();
            ob.Show();

        }

        private void button2_Click(object sender, EventArgs e)//nurse
        {
            Nurse ob = new Nurse();
            ob.Show();
        }

        private void button5_Click(object sender, EventArgs e)//dept
        {

        }

        private void button3_Click(object sender, EventArgs e)//trainedin
        {

        }

        private void button7_Click(object sender, EventArgs e)//affliated
        {

        }

        private void button4_Click(object sender, EventArgs e)//stay
        {
            stay ob = new stay();
            ob.Show();      

        }

        private void button12_Click(object sender, EventArgs e)//room
        {
            Room ob = new Room();
            ob.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Procedures ob = new Procedures();
            ob.Show();
        }
    }
}

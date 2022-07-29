using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class Form1 : Form
    {
        public string parcel;
        public int total;
        public Form1()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            parcel+="5";
            textBoxVisor2.Text += "5";

        }

        private void textBoxVisor_TextChanged(object sender, EventArgs e)
        {
            textBoxVisor1.Font = new Font(textBoxVisor1.Font.FontFamily, 28);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            parcel+= "2";
            textBoxVisor2.Text += "2";
        }

        private void buttonSoma_Click(object sender, EventArgs e)
        {
            total += Convert.ToInt32(parcel);
            textBoxVisor2.Text += "+";
            parcel = "";
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            total += Convert.ToInt32(parcel);
            textBoxVisor1.Text = "" + total;
            parcel = "";
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            parcel = "";
            total = 0;
            textBoxVisor1.Text = "";
            textBoxVisor2.Text = "";
        }

        private void textBoxVisor2_TextChanged(object sender, EventArgs e)
        {
            textBoxVisor2.Font = new Font(textBoxVisor1.Font.FontFamily, 28);
        }

    }
}

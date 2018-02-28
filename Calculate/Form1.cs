using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtInput.Text += "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtInput.Text += "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtInput.Text += "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtInput.Text += "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtInput.Text += "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtInput.Text += "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            txtInput.Text += "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            txtInput.Text += "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            txtInput.Text += "9";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            txtInput.Text += "0";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            txtInput.Text += "+";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            txtInput.Text += "-";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            txtInput.Text += "*";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            txtInput.Text += "/";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            txtInput.Text += "^";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            txtInput.Text += "v";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            txtInput.Text += "sin";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            txtInput.Text += "cos";
        }

        private void button20_Click(object sender, EventArgs e)
        {
            txtInput.Text += "Asin";
        }

        private void button21_Click(object sender, EventArgs e)
        {
            txtInput.Text += "Acos";
        }

        private void button22_Click(object sender, EventArgs e)
        {
            txtInput.Text = "";
            labelKq.Text = "0";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            String expr = txtInput.Text;
            if (expr.Contains("sin"))
                expr.Replace("sin", "i");
            if (expr.Contains("cos"))
                expr.Replace("cos", "c");
            if (expr.Contains("Asin"))
                expr.Replace("Asin", "w");
            if (expr.Contains("Acos"))
                expr.Replace("Acos", "z");

            if (expr != "" && expr != null) {
                Calculate cal = new Calculate(expr);
                labelKq.Text = Convert.ToString(cal.returnKq());
            }         
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinForm1
{
    public partial class Form1 : Form
    {
        int k = 0;
        public Form1()
        {
            InitializeComponent();
            label1.Text= "hello world";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            k=k+1;
            label1.Text = "pressed " + k + "  times";
        }
    }
}

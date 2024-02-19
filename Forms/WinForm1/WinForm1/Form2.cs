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
    public partial class Form2 : Form
    {
        Form myForm;
        public Form2(Form MainForm)
        {
            InitializeComponent();
            MainForm.Enabled = false;
            myForm = MainForm;
        }
        private void button_add_Click(object sender, EventArgs e)
        {
            myForm.Enabled = true;
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            myForm.Enabled = true;
        }
    }
}

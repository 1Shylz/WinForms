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
        static int massiv_size=10;
        List<string> my_list = new List<string>() {"One","Two","Three" };
        
        
        public Form1()
        {
            massiv_size=my_list.Count;

            InitializeComponent();
        
        }
        private void button1_Click(object sender, EventArgs e)
        {
            k=(k+1)%massiv_size;
            listBox1.Items.Add(textBox2.Text);
        }
    }
}

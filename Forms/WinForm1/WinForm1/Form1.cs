using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WinForm1
{
    public partial class Form1 : Form
    {
        //string filePath = @"C:\Users\steam\Desktop\file.xml";
     
        string filePath = @"C:\file2.xml";
        DataSet ds = new DataSet("dataSet");
        DataTable taskTable = new DataTable("Tasks"); //определяю таблицу

        string textDate = "";
        string textDeskrition = "";
        string textResponsible = "";
        string textStatus = "";
        string textTag = "";
        public Form1()
        {
            InitializeComponent();
            //создаю столбцы
            DataColumn idColumn = new DataColumn("Id",typeof(Int32));
            idColumn.Unique = true;
            idColumn.AllowDBNull = false;
            idColumn.AutoIncrement = true;
            idColumn.AutoIncrementSeed = 0;
            idColumn.AutoIncrementStep = 1;

            DataColumn dateColumn = new DataColumn("срок сдачи",typeof(DateTime));
            dateColumn.DefaultValue = new DateTime(2023, 11, 01);// .ToString("d");
            idColumn.AllowDBNull = false;

            DataColumn deskriptionColumn = new DataColumn("описание",typeof (string));
            idColumn.AllowDBNull = false;

            DataColumn responsibleColumn = new DataColumn("ответственный", typeof(string));
            idColumn.AllowDBNull = false;

            DataColumn statusColumn = new DataColumn("статус", typeof(string));
            idColumn.AllowDBNull = false;

            DataColumn tagColumn = new DataColumn("тэг", typeof(string));
            idColumn.AllowDBNull = false;
            //добавляю столбцы в таблицу
            taskTable.Columns.Add(idColumn);
            taskTable.Columns.Add(dateColumn);
            taskTable.Columns.Add(deskriptionColumn);
            taskTable.Columns.Add(responsibleColumn);
            taskTable.Columns.Add(statusColumn);
            taskTable.Columns.Add(tagColumn);
            //определяю первичный ключ
            taskTable.PrimaryKey = new DataColumn[] { taskTable.Columns["Id"] };
            //DateTime test = new DateTime(2023,11,01);
            //taskTable.Rows.Add(new object[] { 1, null, "первая задача", "админ", "выполняется", "начальная" });
            ds.Tables.Add(taskTable);
              
        }
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = true;
            button3.Enabled = true;
            button4.Enabled = true;

            taskTable.ReadXml(filePath);
            dataGridView1.DataSource = taskTable;
            dataGridView1.Columns[0].Width = 40;
            dataGridView1.Columns[1].Width = 80;
            dataGridView1.Columns[2].Width = 500;
            dataGridView1.Columns[3].Width = 180;
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[5].Width = 100;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            ds.WriteXml(@"C:\file2.xml");
            //button2.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "") { textDeskrition = "задача не записана"; } else textDeskrition = textBox2.Text;
            if (textBox3.Text == "") { textResponsible = "ответственный не назначен"; } else textResponsible = textBox3.Text;
            if (textBox4.Text == "") { textStatus= "не начиналась"; } else textStatus = textBox4.Text;
            if (textBox5.Text == "") { textTag = "не отнесена"; } else textTag = textBox5.Text;

            taskTable.Rows.Add(new object[] { null, null, textDeskrition, textResponsible, textStatus, textTag });
        }


    }
}

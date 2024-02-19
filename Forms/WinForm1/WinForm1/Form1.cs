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

            DataColumn deskriptionColumn = new DataColumn("описание",typeof (string));

            DataColumn responsibleColumn = new DataColumn("ответственный", typeof(string));

            DataColumn statusColumn = new DataColumn("статус", typeof(string));

            DataColumn tagColumn = new DataColumn("тэг", typeof(string));
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


        private void button_load_Click(object sender, EventArgs e)
        {
            button_load.Visible = false;
            button_save.Visible = true;
            button_add.Enabled = true;
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

        private void button_save_Click(object sender, EventArgs e)
        {
            ds.WriteXml(@"C:\file2.xml");
            //button2.Visible = false;

        }

        private void button_add_Click(object sender, EventArgs e)
        {
            textDate = dateTimePicker1.Text;
            if (textBox_description.Text == "") { textDeskrition = "задача не записана"; } else textDeskrition = textBox_description.Text;
            if (textBox_responsible.Text == "") { textResponsible = "ответственный не назначен"; } else textResponsible = textBox_responsible.Text;
            if (textBox_status.Text == "") { textStatus = "не начиналась"; } else textStatus = textBox_status.Text;
            if (textBox_tag.Text == "") { textTag = "не отнесена"; } else textTag = textBox_tag.Text;

            taskTable.Rows.Add(new object[] { null, textDate, textDeskrition, textResponsible, textStatus, textTag });
        }

        private void toolStripButton_add_Click(object sender, EventArgs e)
        {
            Form2 addForm = new Form2(this);
            addForm.Show();
            //this.Visible = false;
        }
    }
}

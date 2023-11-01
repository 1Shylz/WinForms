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
        string filePath = @"XMLFile1.xml";
        DataSet ds = new DataSet("dataSet");
        DataTable taskTable = new DataTable("Tasks"); //определяю таблицу
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
            deskriptionColumn.DefaultValue = "задача не записана";
            idColumn.AllowDBNull = false;

            DataColumn responsibleColumn = new DataColumn("ответственный", typeof(string));
            responsibleColumn.DefaultValue ="ты";
            idColumn.AllowDBNull = false;

            DataColumn statusColumn = new DataColumn("статус", typeof(string));
            statusColumn.DefaultValue = "не выполнено";
            idColumn.AllowDBNull = false;

            DataColumn tagColumn = new DataColumn("тэг", typeof(string));
            tagColumn.DefaultValue = "не указано";
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
            dataGridView1.DataSource = taskTable;
            //dataGridView1.DataSource = ReadXML(filePath);
            
            
            button1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            ds.WriteXml(@"C:\Users\steam\Desktop\file.xml");
            //button2.Visible = false;
        }
    }
}

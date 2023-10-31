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
        public Form1()
        {

            InitializeComponent();
      
        }
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ReadXML(filePath);
            ds.Tables.Add(ReadXML(filePath));
            ds.WriteXml(@"C:\Users\steam\Desktop\file.xml");
            button1.Visible = false;
        }

        private DataTable CreaTable()
        {
            DataTable dt = new DataTable("Friends");
            DataColumn colId=new DataColumn("Id",typeof(Int32));
            DataColumn colName = new DataColumn("Name",typeof(string));
            DataColumn colAge = new DataColumn("Age",typeof(Int32));
            dt.Columns.Add(colId);
            dt.Columns.Add(colName);
            dt.Columns.Add(colAge);
            return dt;
        }

        private DataTable ReadXML(string new_filePath)
        {
            DataTable dt = null;
            try 
            {
                XDocument xDox = XDocument.Load(new_filePath);
                dt = CreaTable();
                DataRow newRow = null;
                foreach (XElement elm in xDox.Descendants("friend"))
                {
                    newRow = dt.NewRow();
                    if (elm.Attribute("id") != null)
                    {
                        newRow["id"] = int.Parse(elm.Attribute("id").Value);
                    }
                
                    if (elm.Element("name") != null)
                    {
                        newRow["name"] = elm.Element("name").Value;
                    }
                    if (elm.Element("age") != null)
                    {
                        newRow["age"] = elm.Element("age").Value;
                    }
                    dt.Rows.Add(newRow);
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }
    }
}

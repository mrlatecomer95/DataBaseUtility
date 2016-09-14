using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;
//using System.Data.SQLite;

namespace Testing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //SQLite
        //DatabaseFactory.SqLite3 DB 

        //Access DB
        DatabaseFactory.AccessDB DB;

        private void simpleButton1_Click(object sender, EventArgs e)
        {


            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog(this);
            textEdit1.Text = ofd.FileName.ToString() ;

            //FOR SQLITE3
            //string str = "DRIVER=SQLite3 ODBC Driver;Data Source=" + textEdit1.Text + ";LongNames=0;Timeout=1000;NoTXN=0;";
            //DB= new DatabaseFactory.SqLite3(str)
            

            //FOR Access
            string str = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + textEdit1.Text;
            DB = new DatabaseFactory.AccessDB(str);
        }

 

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = DB.CreateTable("SELECT LName,FName,MName AS DateUpdated FROM tblbiodata");
        }
    }
}

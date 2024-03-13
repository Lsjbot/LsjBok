using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace LsjBok
{
    public partial class FormAdmin : Form
    {
        Form1 f1;

        public FormAdmin(Form1 ff)
        {
            InitializeComponent();
            f1 = ff;

            setbuttons();

            TBconnectionstring.Text = Form1.connectionstring + "master";
        }

        private void setbuttons()
        {
            if (Form1.db == null)
            {
                foreach (Control c in this.Controls)
                    c.Enabled = false;
                createDBbutton.Enabled = true;
                TBconnectionstring.Enabled = true;
            }
            else if (Form1.currentuser < 0)
            {
                foreach (Control c in this.Controls)
                    c.Enabled = false;
                createuserbutton.Enabled = true;
            }
            else if (Form1.currentcompany < 0)
            {
                foreach (Control c in this.Controls)
                    c.Enabled = false;
                createcompanybutton.Enabled = true;
            }
            else if (Form1.currentfiscal < 0)
            {
                foreach (Control c in this.Controls)
                    c.Enabled = false;
                fiscalyearbutton.Enabled = true;
            }
            else
            {
                foreach (Control c in this.Controls)
                    c.Enabled = true;
                createDBbutton.Enabled = false;
            }
        }

        private void createDBbutton_Click(object sender, EventArgs e)
        {
            if (createDB(Form1.dbname))
            {
                Form1.connectionstring = TBconnectionstring.Text.Replace("=master", "=");
                using (StreamWriter sw = new StreamWriter(Form1.mainfolder + Form1.connectionfn))
                    sw.WriteLine(Form1.connectionstring);

                if (createTables(Form1.dbname))
                {
                    Form1.db = new LsjBokDB(Form1.connectionstring+Form1.dbname);
                    //f1.bookbutton.Enabled = true;
                    foreach (Control c in this.Controls)
                        c.Enabled = true;
                    createDBbutton.Enabled = false;

                    companytypeclass.fill_companytype();
                    kontoclass.fill_kontodict();
                }
            }
            setbuttons();
        }

        private bool createDB(string dbname)
        {
            if (!Directory.Exists(Form1.mainfolder + "DB"))
                Directory.CreateDirectory(Form1.mainfolder + "DB");
            string dbfn = Form1.mainfolder + @"DB\LsjBok.mdf";
            string dblog = Form1.mainfolder + @"DB\LsjBokLog.ldf";

            String str;
            SqlConnection myConn = 
                new SqlConnection(TBconnectionstring.Text);

            str = "CREATE DATABASE " + dbname + " ON PRIMARY " +
             "(NAME = " + dbname + ", " +
             "FILENAME = '" + dbfn + "', " +
             "SIZE = 20MB, FILEGROWTH = 10%)" +
             "LOG ON (NAME = " + dbname + "_Log, " +
             "FILENAME = '" + dblog + "', " +
             "SIZE = 10MB, " +
             "FILEGROWTH = 10%)";

            bool success;
            SqlCommand myCommand = new SqlCommand(str, myConn);
            try
            {
                myConn.Open();
                myCommand.ExecuteNonQuery();
                MessageBox.Show("DataBase is Created Successfully", "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
                success = true;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
                success = false;
            }
            finally
            {
                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
            }
            return success;
        }

        private bool createTables(string dbname)
        {
            String str;
            SqlConnection myConn = 
                new SqlConnection(Form1.connectionstring+dbname);

            str =
"create table LsjBokUser\n" +
"(\n" +
"Id integer not null primary key,\n" +
"Name nvarchar(150) not null,\n" +
"Pwdhash char(32)\n" +
") --https://learn.microsoft.com/en-us/troubleshoot/developer/visualstudio/csharp/language-compilers/compute-hash-values\n" +
"\n" +
"create table Companytype\n" +
"(\n" +
"Id integer not null primary key,\n" +
"Name nvarchar(150) not null,\n" +
"Shortname nvarchar(10) not null\n" +
")\n" +
"\n" +
"create table Company\n" +
"(\n" +
"Id integer not null primary key,\n" +
"Name nvarchar(150) not null,\n" +
"Orgnr char(13) not null,\n" +
"Companytype integer not null foreign key references Companytype(Id),\n" +
"Address nvarchar(250),\n" +
"Phone nvarchar(25),\n" +
"Email nvarchar(50),\n" +
"Momsfreq integer not null, -- 0 = ej moms\n" +
"Kontant bit not null, \n" +
"Admin integer not null foreign key references LsjBokUser(Id),\n" +
"Creator integer not null foreign key references LsjBokUser(Id),\n" +
"Creationdate date not null\n" +
")\n" +
"\n" +
"create table Fiscalyear\n" +
"(\n" +
"Id integer not null primary key,\n" +
"Name varchar(10) not null,\n" +
"Company integer not null foreign key references Company(Id),\n" +
"Startdate date not null,\n" +
"Enddate date not null,\n" +
"Closed bit not null,\n" +
"Creator integer not null foreign key references LsjBokUser(Id),\n" +
"Creationdate date not null\n" +
")\n" +
"\n" +
"create table Konto\n" +
"(\n" +
"Id integer not null primary key,\n" +
"Year integer not null foreign key references Fiscalyear(Id),\n" +
"Name nvarchar(150) not null,\n" +
"Number integer not null,\n" +
"Kontotyp integer not null,\n" +
"Kontogrupp integer not null,\n" +
"Konto1 integer not null,\n" +
"Konto2 integer not null,\n" +
"Konto3 integer not null,\n" +
"IB money not null, --  +=debet, -=kredit\n" +
"UB money not null, --  +=debet, -=kredit\n" +
"Creator integer not null foreign key references LsjBokUser(Id),\n" +
"Creationdate date not null\n" +
")\n" +
"\n" +
"create table Ver\n" +
"(\n" +
"Id integer not null primary key,\n" +
"Verdate date not null,\n" +
"Vernumber integer not null,\n" +
"Year integer not null foreign key references Fiscalyear(Id),\n" +
"Description nvarchar(250) not null,\n" +
"Verifikatfil nvarchar(250),\n" +
"Creator integer not null foreign key references LsjBokUser(Id),\n" +
"Creationdate date not null\n" +
")\n" +
"\n" +
"create table Rad\n" +
"(\n" +
"Id integer not null primary key,\n" +
"Ver integer not null foreign key references Ver(Id),\n" +
"Konto integer not null foreign key references Konto(Id),\n" +
"Amount money not null, --  +=debet, -=kredit\n" +
")\n" +
"\n" +
"create table Momsperiod\n" +
"(\n" +
"Id integer not null primary key,\n" +
"Name varchar(10) not null,\n" +
"Fiscal integer not null foreign key references Fiscalyear(Id),\n" +
"Startdate date not null,\n" +
"Enddate date not null,\n" +
"Net money not null, \n" +
"Closed bit not null,\n" +
"Rapportfil nvarchar(250),\n" +
"Creator integer not null foreign key references LsjBokUser(Id),\n" +
"Creationdate date not null\n" +
")\n" +
"\n" +
"create table Momsentry\n" +
"(\n" +
"Id integer not null primary key,\n" +
"Period integer not null foreign key references Momsperiod(Id),\n" +
"Field integer not null,\n" +
"Amount money not null\n" +
")\n" +
"\n" +
"create table Mall\n" +
"(\n" +
"Id integer not null primary key,\n" +
"Description nvarchar(250) not null,\n" +
"Creator integer not null foreign key references LsjBokUser(Id),\n" +
"Creationdate date not null\n" +
")\n" +
"\n" +
"create table Mallrad\n" +
"(\n" +
"Id integer not null primary key,\n" +
"Mall integer not null foreign key references Mall(Id),\n" +
"Kontonr integer not null,\n" +
"Amount money not null, --  +=debet, -=kredit\n" +
")\n" +
"create table Log\n" +
"(\n" +
"Id integer not null primary key,\n" +
"Description nvarchar(250) not null,\n" +
"Event integer not null,\n" +
"Creator integer not null foreign key references LsjBokUser(Id),\n" +
"Creationdate date not null\n" +
")\n"

;

            bool success;
            SqlCommand myCommand = new SqlCommand(str, myConn);
            try
            {
                myConn.Open();
                myCommand.ExecuteNonQuery();
                MessageBox.Show("Tables added Successfully", "LsjBok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                success = true;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "LsjBok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                success = false;
            }
            finally
            {
                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
            }
            return success;


        }


        private void createuserbutton_Click(object sender, EventArgs e)
        {
            FormAdduser fa = new FormAdduser();
            fa.ShowDialog();
            if (Form1.db.LsjBokUser.Count() == 1)
                Form1.currentuser = Form1.db.LsjBokUser.First().Id;
            f1.updatetitle();
            f1.updateboxes();
            setbuttons();
        }

        private void createcompanybutton_Click(object sender, EventArgs e)
        {
            FormAddcompany fa = new FormAddcompany();
            fa.ShowDialog();
            if (Form1.db.Company.Count() == 1)
                Form1.currentcompany = Form1.db.Company.First().Id;
            f1.updatetitle();
            f1.updateboxes();
            setbuttons();
        }

        private void fiscalyearbutton_Click(object sender, EventArgs e)
        {
            FormFiscalyear ff = new FormFiscalyear();
            ff.ShowDialog();
            f1.updatetitle();
            f1.updateboxes();
            setbuttons();
        }
    }
}

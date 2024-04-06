using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Data;

namespace LsjBok
{
    public class sqlclass
    {
        public static bool backupDB(string dbname,string fn)
        {
            string str = "Backup database " + dbname + " to disk='" + fn + "'";
            SqlConnection myConn =
                new SqlConnection(common.connectionstring + dbname);
            bool success;
            SqlCommand myCommand = new SqlCommand(str, myConn);
            try
            {
                myConn.Open();
                myCommand.ExecuteNonQuery();
                MessageBox.Show("DataBase is Backed up Successfully", "LsjBok", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        public static bool deleteDB(string dbname)
        {
            string str =
                "delete from Loglist\n" +
"delete from Mallrad\n" +
"delete from Mall\n" +
"delete from Rad\n" +
"delete from Ver\n" +
"delete from Momsentry\n" +
"delete from Momsperiod\n" +
"delete from Konto\n" +
"delete from Fiscalyear\n" +
"delete from Company\n" +
"delete from Companytype\n" +
"delete from LsjBokUser\n" +
"DROP TABLE [dbo].[Loglist]\n" +
"DROP TABLE [dbo].[Mallrad]\n" +
"DROP TABLE [dbo].[Mall]\n" +
"DROP TABLE [dbo].[Rad]\n" +
"DROP TABLE [dbo].[Ver]\n" +
"DROP TABLE [dbo].[Momsentry]\n" +
"DROP TABLE [dbo].[Momsperiod]\n" +
"DROP TABLE [dbo].[Konto]\n" +
"DROP TABLE [dbo].[Fiscalyear]\n" +
"DROP TABLE [dbo].[Company]\n" +
"DROP TABLE [dbo].[Companytype]\n" +
"DROP TABLE [dbo].[LsjBokUser]\n" +
                "";
            SqlConnection myConn =
                new SqlConnection(common.connectionstring + dbname);
            bool success;
            SqlCommand myCommand = new SqlCommand(str, myConn);
            try
            {
                myConn.Open();
                myCommand.ExecuteNonQuery();
                myConn.Close();
                common.db.DeleteDatabase();
                MessageBox.Show("DataBase is Successfully Deleted", "LsjBok", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        public static bool createDB(string dbname, string connectiontext)
        {
            if (!Directory.Exists(common.mainfolder + "DB"))
                Directory.CreateDirectory(common.mainfolder + "DB");
            string dbfn = common.mainfolder + @"DB\LsjBok.mdf";
            string dblog = common.mainfolder + @"DB\LsjBokLog.ldf";

            String str;
            SqlConnection myConn =
                new SqlConnection(connectiontext);

            if (connectiontext.ToLower().Contains("localhost"))
            {
                str = "CREATE DATABASE " + dbname + " ON PRIMARY " +
                 "(NAME = " + dbname + ", " +
                 "FILENAME = '" + dbfn + "', " +
                 "SIZE = 20MB, FILEGROWTH = 10%)" +
                 "LOG ON (NAME = " + dbname + "_Log, " +
                 "FILENAME = '" + dblog + "', " +
                 "SIZE = 10MB, " +
                 "FILEGROWTH = 10%)";
            }
            else
            {
                str = "CREATE DATABASE " + dbname;
            }
            bool success;
            SqlCommand myCommand = new SqlCommand(str, myConn);
            try
            {
                myConn.Open();
                myCommand.ExecuteNonQuery();
                MessageBox.Show("DataBase is Created Successfully", "LsjBok", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public static bool createTables(string dbname)
        {
            String str;
            SqlConnection myConn =
                new SqlConnection(common.connectionstring + dbname);

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
"Address nvarchar(300),\n" +
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
"Description nvarchar(300) not null,\n" +
"Verifikatfil nvarchar(300),\n" +
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
"Rapportfil nvarchar(300),\n" +
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
"Description nvarchar(300) not null,\n" +
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
"\n" +
"create table Loglist\n" +
"(\n" +
"Id integer not null primary key,\n" +
"Description nvarchar(300) not null,\n" +
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

    }
}

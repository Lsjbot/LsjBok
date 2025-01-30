using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Sdk.Sfc;
using System.IO;

namespace LsjBok
{
    public partial class FormDBscript : Form
    {
        public FormDBscript()
        {
            InitializeComponent();
        }

        private void scriptbutton_Click(object sender, EventArgs e)
        {
            String dbName = common.dbname; // database name  

            // Connect to the local, default instance of SQL Server.   
            Server srv = new Server();

            // Reference the database.    
            Database db = srv.Databases[dbName];

            // Define a Scripter object and set the required scripting options.   
            Scripter scrp = new Scripter(srv);
            scrp.Options.ScriptDrops = false;
            scrp.Options.WithDependencies = true;
            scrp.Options.Indexes = true;   // To include indexes  
            scrp.Options.DriAllConstraints = true;   // to include referential constraints in the script  
            scrp.Options.ScriptData = true;

            string fn = util.unused_filename(common.mainfolder + @"\Lsjbok.sql");
            using (StreamWriter sw = new StreamWriter(fn))
            {
                common.memo("Scripting database to " + fn);
                // Iterate through the tables in database and script each one. Display the script.     
                foreach (Table tb in db.Tables)
                {
                    common.memo("Table " + tb.Name);
                    // check if the table is not a system table  
                    if (tb.IsSystemObject == false)
                    {
                        common.memo("-- Scripting for table " + tb.Name);
                        sw.WriteLine("-- Scripting for table " + tb.Name);

                        // Generating script for table tb  
                        //System.Collections.Specialized.StringCollection sc = scrp.Script(new Urn[] { tb.Urn });
                        var sc = scrp.EnumScript(new Urn[] { tb.Urn });
                        foreach (string st in sc)
                        {
                            sw.WriteLine(st);
                        }
                        sw.WriteLine("--");
                    }
                }
            }
            MessageBox.Show("Scriptat databasen till " + fn);
        }
    }
}

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

            TBconnectionstring.Text = common.connectionstring + "master";
        }

        private void setbuttons()
        {
            if (common.db == null)
            {
                foreach (Control c in this.Controls)
                    c.Enabled = false;
                createDBbutton.Enabled = true;
                TBconnectionstring.Enabled = true;
            }
            else if (common.currentuser < 0)
            {
                foreach (Control c in this.Controls)
                    c.Enabled = false;
                createuserbutton.Enabled = true;
            }
            else if (common.currentcompany < 0)
            {
                foreach (Control c in this.Controls)
                    c.Enabled = false;
                createcompanybutton.Enabled = true;
            }
            else if (common.currentfiscal < 0)
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
            if (sqlclass.createDB(common.dbname,TBconnectionstring.Text))
            {
                common.connectionstring = TBconnectionstring.Text.Replace("=master", "=");
                using (StreamWriter sw = new StreamWriter(common.mainfolder + common.connectionfn))
                    sw.WriteLine(common.connectionstring);

                if (sqlclass.createTables(common.dbname))
                {
                    common.db = new LsjBokDB(common.connectionstring+common.dbname);
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



        private void createuserbutton_Click(object sender, EventArgs e)
        {
            FormAdduser fa = new FormAdduser();
            fa.ShowDialog();
            if (common.db.LsjBokUser.Count() == 1)
                common.currentuser = common.db.LsjBokUser.First().Id;
            f1.updatetitle();
            f1.updateboxes();
            setbuttons();
        }

        private void createcompanybutton_Click(object sender, EventArgs e)
        {
            FormAddcompany fa = new FormAddcompany();
            fa.ShowDialog();
            if (common.db.Company.Count() == 1)
                common.currentcompany = common.db.Company.First().Id;
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

        private void closebutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void backupDBbutton_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = common.dbname+"-"+DateTime.Now.ToString("yyMMdd");
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fn = saveFileDialog1.FileName;
                sqlclass.backupDB(common.dbname, fn);
            }
        }

        private void deleteDBbutton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Vill du verkligen radera databasen? All bokföring försvinner!","Radera allt?",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                sqlclass.deleteDB(common.dbname);
            }
        }
    }
}

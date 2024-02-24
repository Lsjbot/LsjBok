using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace LsjBok
{
    public partial class Form1 : Form
    {
        public static string mainfolder;
        public static string folderfn = "lsjbokfolder.txt";
        public static string dbname = "LsjBokDB";
        public static string connectionstring = 
            "Server=localhost;Integrated security=True;database=" + dbname;
        public static LsjBokDB db = null;
        public static int currentuser = -1;
        public static int currentcompany = -1;
        public static int currentfiscal = -1;

        public Form1()
        {
            InitializeComponent();
            if (!File.Exists(folderfn))
            {
                mainfolder = @"C:\LsjBok\";
                using (StreamWriter sw = new StreamWriter(folderfn))
                    sw.WriteLine(mainfolder);
            }
            else
            {
                using (StreamReader sr = new StreamReader(folderfn))
                    mainfolder = sr.ReadLine();
            }
            folderlabel.Text = mainfolder;

            try
            {
                db = new LsjBokDB(connectionstring);
                db.LsjBokUser.Count();
            }
            catch (Exception e)
            {
                db = null;
            }


            if (db == null)
            {
                foreach (Control c in this.Controls)
                    c.Enabled = false;
                adminbutton.Enabled = true;
                quitbutton.Enabled = true;
                folderchangebutton.Enabled = true;
                folderlabel.Enabled = true;
                MessageBox.Show("Börja med att skapa databas", "LsjBok", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                companytypeclass.fill_companytype();
                kontoclass.fill_kontodict();
                LBuser.Visible = db.LsjBokUser.Count() > 1;
                LBuser.Enabled = db.LsjBokUser.Count() > 1;
                LBcompany.Visible = db.Company.Count() > 1;
                LBcompany.Enabled = db.Company.Count() > 1;

                if (db.LsjBokUser.Count() == 0)
                {
                    foreach (Control c in this.Controls)
                        c.Enabled = false;
                    adminbutton.Enabled = true;
                    quitbutton.Enabled = true;
                    MessageBox.Show("Börja med att skapa en användare", "LsjBok", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (db.LsjBokUser.Count() > 0)
                    {
                        currentuser = db.LsjBokUser.First().Id;
                        foreach (var user in db.LsjBokUser)
                            LBuser.Items.Add(user.Name);
                    }
                    if (db.Company.Count() == 0)
                    {
                        foreach (Control c in this.Controls)
                            c.Enabled = false;
                        adminbutton.Enabled = true;
                        quitbutton.Enabled = true;
                        MessageBox.Show("Börja med att skapa ett företag", "LsjBok", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (db.Company.Count() > 0)
                        {
                            currentcompany = db.Company.First().Id;
                            foreach (var cc in db.Company)
                                LBcompany.Items.Add(cc.Name);
                        }
                        updatefiscal();
                        bookbutton.Enabled = true;
                        huvudbokbutton.Enabled = true;
                    }
                }
            }
            updatetitle();
        }

        public void updatefiscal()
        {
            LBfiscal.Items.Clear();
            var q = from c in db.Fiscalyear where c.Company == currentcompany select c;
            foreach (var ff in q)
            {
                LBfiscal.Items.Add(ff.Name);
                if (ff.Enddate > DateTime.Now)
                    currentfiscal = ff.Id;
            }
        }

        public void updatetitle()
        {
            this.Text = "LsjBok - " + util.getusername(currentuser) + " - " + util.getcompanyname(currentcompany) + " - "+util.getfiscalname(currentfiscal);
        }

        public void updateboxes()
        {
            LBuser.Visible = db.LsjBokUser.Count() > 1;
            LBuser.Enabled = db.LsjBokUser.Count() > 1;
            LBcompany.Visible = db.Company.Count() > 1;
            LBcompany.Enabled = db.Company.Count() > 1;
            LBuser.Items.Clear();
            foreach (var user in db.LsjBokUser)
                LBuser.Items.Add(user.Name);
            LBcompany.Items.Clear();
            foreach (var cc in db.Company)
                LBcompany.Items.Add(cc.Name);
            updatefiscal();
        }

        private void quitbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void folderchangebutton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            if (fb.ShowDialog() == DialogResult.OK)
            {
                mainfolder = fb.SelectedPath;
                folderlabel.Text = mainfolder;
                string oldfn = util.unused_filename(folderfn);
                File.Move(folderfn, oldfn);
                using (StreamWriter sw = new StreamWriter(folderfn))
                    sw.WriteLine(mainfolder);
            }
        }

        private void adminbutton_Click(object sender, EventArgs e)
        {
            FormAdmin fa = new FormAdmin(this);
            fa.Show();
        }

        private void bookbutton_Click(object sender, EventArgs e)
        {
            FormBook fb = new FormBook();
            fb.Show();
        }

        private void LBuser_SelectedIndexChanged(object sender, EventArgs e)
        {
            var q = (from c in db.LsjBokUser where c.Name == LBuser.SelectedItem.ToString() select c).FirstOrDefault();
            if (q != null)
            {
                currentuser = q.Id;
                updatetitle();
            }
            
        }

        private void LBcompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            var q = (from c in db.Company where c.Name == LBcompany.SelectedItem.ToString() select c).FirstOrDefault();
            if (q != null)
            {
                currentcompany = q.Id;
                updatetitle();
                updatefiscal();
            }

        }

        private void LBfiscal_SelectedIndexChanged(object sender, EventArgs e)
        {
            var q = (from c in db.Fiscalyear where c.Name == LBfiscal.SelectedItem.ToString() select c).FirstOrDefault();
            if (q != null)
            {
                currentfiscal = q.Id;
                updatetitle();
            }

        }

        private void huvudbokbutton_Click(object sender, EventArgs e)
        {
            FormHuvudbok fhb = new FormHuvudbok();
            fhb.Show();
        }

        private void importexportbutton_Click(object sender, EventArgs e)
        {
            FormImportExport fie = new FormImportExport();
            fie.Show();
        }

        private void verbutton_Click(object sender, EventArgs e)
        {
            FormVerifikatlista fv = new FormVerifikatlista();
            fv.Show();
        }
    }
}

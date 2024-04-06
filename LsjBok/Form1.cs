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

        public Form1()
        {
            InitializeComponent();
            if (!File.Exists(common.folderfn))
            {
                common.mainfolder = @"C:\LsjBok\";
                using (StreamWriter sw = new StreamWriter(common.folderfn))
                    sw.WriteLine(common.mainfolder);
            }
            else
            {
                using (StreamReader sr = new StreamReader(common.folderfn))
                    common.mainfolder = sr.ReadLine();
            }
            folderlabel.Text = common.mainfolder;

            if (File.Exists(common.mainfolder + common.connectionfn))
            {
                using (StreamReader sr = new StreamReader(common.mainfolder + common.connectionfn))
                    common.connectionstring = sr.ReadLine();
            }

            try
            {
                common.db = new LsjBokDB(common.connectionstring + common.dbname);
                common.db.LsjBokUser.Count();
            }
            catch (Exception e)
            {
                common.db = null;
            }


            if (common.db == null)
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
                LBuser.Visible = common.db.LsjBokUser.Count() > 1;
                LBuser.Enabled = common.db.LsjBokUser.Count() > 1;
                LBcompany.Visible = common.db.Company.Count() > 1;
                LBcompany.Enabled = common.db.Company.Count() > 1;

                if (common.db.LsjBokUser.Count() == 0)
                {
                    foreach (Control c in this.Controls)
                        c.Enabled = false;
                    adminbutton.Enabled = true;
                    quitbutton.Enabled = true;
                    MessageBox.Show("Börja med att skapa en användare", "LsjBok", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (common.db.LsjBokUser.Count() > 0)
                    {
                        common.currentuser = common.db.LsjBokUser.First().Id;
                        foreach (var user in common.db.LsjBokUser)
                            LBuser.Items.Add(user.Name);
                    }
                    if (common.db.Company.Count() == 0)
                    {
                        foreach (Control c in this.Controls)
                            c.Enabled = false;
                        adminbutton.Enabled = true;
                        quitbutton.Enabled = true;
                        MessageBox.Show("Börja med att skapa ett företag", "LsjBok", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (common.db.Company.Count() > 0)
                        {
                            common.currentcompany = common.db.Company.First().Id;
                            foreach (var cc in common.db.Company)
                                LBcompany.Items.Add(cc.Name);
                        }
                        updatefiscal();
                        bookbutton.Enabled = true;
                        huvudbokbutton.Enabled = true;
                    }
                }
            }
            rrbrclass.fill_rrbr();
            updatetitle();
        }

        public void updatefiscal()
        {
            LBfiscal.Items.Clear();
            var q = from c in common.db.Fiscalyear where c.Company == common.currentcompany select c;
            foreach (var ff in q)
            {
                LBfiscal.Items.Add(ff.Name);
                if (ff.Enddate > DateTime.Now)
                    common.currentfiscal = ff.Id;
            }
        }

        public void updatetitle()
        {
            this.Text = "LsjBok - " + util.getusername(common.currentuser) + " - " + util.getcompanyname(common.currentcompany) + " - "+util.getfiscalname(common.currentfiscal);
        }

        public void updateboxes()
        {
            LBuser.Visible = common.db.LsjBokUser.Count() > 1;
            LBuser.Enabled = common.db.LsjBokUser.Count() > 1;
            LBcompany.Visible = common.db.Company.Count() > 1;
            LBcompany.Enabled = common.db.Company.Count() > 1;
            LBuser.Items.Clear();
            foreach (var user in common.db.LsjBokUser)
                LBuser.Items.Add(user.Name);
            LBcompany.Items.Clear();
            foreach (var cc in common.db.Company)
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
                common.mainfolder = fb.SelectedPath;
                folderlabel.Text = common.mainfolder;
                string oldfn = util.unused_filename(common.folderfn);
                File.Move(common.folderfn, oldfn);
                using (StreamWriter sw = new StreamWriter(common.folderfn))
                    sw.WriteLine(common.mainfolder);
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
            var q = (from c in common.db.LsjBokUser where c.Name == LBuser.SelectedItem.ToString() select c).FirstOrDefault();
            if (q != null)
            {
                common.currentuser = q.Id;
                updatetitle();
            }
            
        }

        private void LBcompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            var q = (from c in common.db.Company where c.Name == LBcompany.SelectedItem.ToString() select c).FirstOrDefault();
            if (q != null)
            {
                common.currentcompany = q.Id;
                updatetitle();
                updatefiscal();
            }

        }

        private void LBfiscal_SelectedIndexChanged(object sender, EventArgs e)
        {
            var q = (from c in common.db.Fiscalyear where c.Name == LBfiscal.SelectedItem.ToString() select c).FirstOrDefault();
            if (q != null)
            {
                common.currentfiscal = q.Id;
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

        private void rrbutton_Click(object sender, EventArgs e)
        {
            FormRR frr = new FormRR("Resultaträkning");
            frr.Show();
        }

        private void balansbutton_Click(object sender, EventArgs e)
        {
            FormRR frr = new FormRR("Balansräkning");
            frr.Show();
        }

        private void momsbutton_Click(object sender, EventArgs e)
        {
            FormMoms fm = new FormMoms();
            fm.Show();
        }
    }
}

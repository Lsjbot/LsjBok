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
using HQAccounting.Models;

namespace LsjBok
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            common.fm.Show();

            common.memo("For debug and other text output");
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
            lblFolder.Text = common.mainfolder;

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
                //foreach (Control c in this.Controls)
                //    c.Enabled = false;
                //flowLayoutPanelSidebar.Enabled = true;
                //flowLayoutPanelSettings.Enabled = true;
                //adminbutton.Enabled = true;
                //buttonSettings.Enabled = true;
                //quitbutton.Enabled = true;
                //folderchangebutton.Enabled = true;
                //folderlabel.Enabled = true;

                //menuStrip1.Enabled = true;
                foreach (ToolStripMenuItem item in menuStrip1.Items)
                {
                    item.Enabled = false;
                }
                settingsToolStripMenuItem.Enabled = true;
                btnFolder.Enabled = true;

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
                    //foreach (Control c in this.Controls)
                    //    c.Enabled = false;
                    //flowLayoutPanelSidebar.Enabled = true;
                    //flowLayoutPanelSettings.Enabled = true;
                    //adminbutton.Enabled = true;
                    //buttonSettings.Enabled = true;
                    //quitbutton.Enabled = true;

                    //menuStrip1.Enabled = true;
                    foreach (ToolStripMenuItem item in menuStrip1.Items)
                    {
                        item.Enabled = false;
                    }
                    settingsToolStripMenuItem.Enabled = true;
                    btnFolder.Enabled = true;

                    MessageBox.Show("Börja med att skapa en användare", "LsjBok", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (common.db.LsjBokUser.Count() > 0)
                    {
                        common.currentuser = common.db.LsjBokUser.First().Id;
                        foreach (var user in common.db.LsjBokUser)
                        {
                            LBuser.Items.Add(user.Name);
                            cboUser.Items.Add(user.Name);
                        }
                    }
                    if (common.db.Company.Count() == 0)
                    {
                        //foreach (Control c in this.Controls)
                        //    c.Enabled = false;
                        //flowLayoutPanelSidebar.Enabled = true;
                        //flowLayoutPanelSettings.Enabled = true;
                        //adminbutton.Enabled = true;
                        //buttonSettings.Enabled = true;
                        //quitbutton.Enabled = true;

                        //menuStrip1.Enabled = true;
                        foreach (ToolStripMenuItem item in menuStrip1.Items)
                        {
                            item.Enabled = false;
                        }
                        settingsToolStripMenuItem.Enabled = true;
                        btnFolder.Enabled = true;

                        MessageBox.Show("Börja med att skapa ett företag", "LsjBok", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (common.db.Company.Count() > 0)
                        {
                            common.currentcompany = common.db.Company.First().Id;
                            foreach (var cc in common.db.Company)
                            {
                                LBcompany.Items.Add(cc.Name);
                                cboCompany.Items.Add(cc.Name);
                            }
                        }
                        updatefiscal();
                        //bookbutton.Enabled = true;
                        //huvudbokbutton.Enabled = true;
                    }
                }
            }
            rrbrclass.fill_rrbr();
            updatetitle();
        }

        public void updatefiscal()
        {
            LBfiscal.Items.Clear();
            cboFiscalYear.Items.Clear();
            var q = from c in common.db.Fiscalyear where c.Company == common.currentcompany select c;
            DateTime latestend = new DateTime(0);
            foreach (var ff in q)
            {
                LBfiscal.Items.Add(ff.Name);
                cboFiscalYear.Items.Add(ff.Name);
                if (ff.Enddate >= DateTime.Now.Date)
                    common.currentfiscal = ff.Id;
                else if (ff.Enddate > latestend)
                {
                    latestend = ff.Enddate;
                    common.currentfiscal = ff.Id;
                }
            }

        }

        public void updatetitle()
        {
            this.Text = "LsjBok - " + util.getusername(common.currentuser) + " - " + util.getcompanyname(common.currentcompany) + " - "+util.getfiscalname(common.currentfiscal);
            cboUser.Text = util.getusername(common.currentuser);
            cboCompany.Text = util.getcompanyname(common.currentcompany);
            cboFiscalYear.Text = util.getfiscalname(common.currentfiscal);
        }

        public void updateboxes()
        {
            LBuser.Visible = common.db.LsjBokUser.Count() > 1;
            LBuser.Enabled = common.db.LsjBokUser.Count() > 1;
            LBcompany.Visible = common.db.Company.Count() > 1;
            LBcompany.Enabled = common.db.Company.Count() > 1;
            LBuser.Items.Clear();
            cboUser.Items.Clear();
            foreach (var user in common.db.LsjBokUser)
            {
                LBuser.Items.Add(user.Name);
                cboUser.Items.Add(user.Name);
            }
            LBcompany.Items.Clear();
            cboCompany.Items.Clear();
            foreach (var cc in common.db.Company)
            {
                LBcompany.Items.Add(cc.Name);
                cboCompany.Items.Add(cc.Name);
            }
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
                lblFolder.Text = common.mainfolder;
                string oldfn = util.unused_filename(common.folderfn);
                File.Move(common.folderfn, oldfn);
                using (StreamWriter sw = new StreamWriter(common.folderfn))
                    sw.WriteLine(common.mainfolder);
            }
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


        private void huvudbokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormHuvudbok();
            form.Show();
        }

        private void balansrapportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormRR("Balansräkning");
            form.Show();
        }

        private void resultatrapportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormRR("Resultaträkning");
            form.Show();
        }

        private void momsrapportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormMoms();
            form.Show();
        }

        private void skapaVerifikatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormBook();
            form.Show();
        }

        private void bokföringsinställningarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bokföringsmallarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tillgångarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void verifikatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormVerifikatlista();
            form.Show();
        }

        private void fakturorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new InvoicesForm();
            form.ShowDialog();
        }

        private void kunderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new CustomersForm();
            form.ShowDialog();
        }

        private void artiklarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ItemsForm();
            form.ShowDialog();
        }

        private void importexportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormImportExport();
            form.Show();
        }

        private void företagsinställningarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormAdmin(this);
            form.Show();
        }

        private void räkenskapsårToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cboUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            var q = (from c in common.db.LsjBokUser where c.Name == cboUser.SelectedItem.ToString() select c).FirstOrDefault();
            if (q != null)
            {
                common.currentuser = q.Id;
                updatetitle();
            }

        }

        private void cboCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            var q = (from c in common.db.Company where c.Name == cboCompany.SelectedItem.ToString() select c).FirstOrDefault();
            if (q != null)
            {
                common.currentcompany = q.Id;
                updatetitle();
                updatefiscal();
            }
        }

        private void cboFiscalYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            var q = (from c in common.db.Fiscalyear where c.Name == cboFiscalYear.SelectedItem.ToString() select c).FirstOrDefault();
            if (q != null)
            {
                common.currentfiscal = q.Id;
                updatetitle();
            }
        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            if (fb.ShowDialog() == DialogResult.OK)
            {
                common.mainfolder = fb.SelectedPath;
                folderlabel.Text = common.mainfolder;
                lblFolder.Text = common.mainfolder;
                string oldfn = util.unused_filename(common.folderfn);
                File.Move(common.folderfn, oldfn);
                using (StreamWriter sw = new StreamWriter(common.folderfn))
                    sw.WriteLine(common.mainfolder);
            }
        }

        private void bokslutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBokslut fbs = new FormBokslut();
            fbs.Show();
        }

        private void avslutaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void räkenskapsårToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FormFiscalyear ff = new FormFiscalyear();
            ff.ShowDialog();
            updatefiscal();
        }

        private void loggToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLog fl = new FormLog();
            fl.Show();
        }

        private void deklarationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDeklaration fd = new FormDeklaration();
            fd.Show();
        }

        private void scriptaDatabasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDBscript fd = new FormDBscript();
            fd.Show();
        }

        private void updatebutton_Click(object sender, EventArgs e)
        {
            updatetitle();
            updateboxes();
        }
    }
}

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
                flowLayoutPanelSidebar.Enabled = true;
                flowLayoutPanelSettings.Enabled = true;
                adminbutton.Enabled = true;
                buttonSettings.Enabled = true;
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
                    flowLayoutPanelSidebar.Enabled = true;
                    flowLayoutPanelSettings.Enabled = true;
                    adminbutton.Enabled = true;
                    buttonSettings.Enabled = true;
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
                        flowLayoutPanelSidebar.Enabled = true;
                        flowLayoutPanelSettings.Enabled = true;
                        adminbutton.Enabled = true;
                        buttonSettings.Enabled = true;
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

            createForms();
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
            if (RBmanywindows.Checked)
            {
                FormAdmin fa = new FormAdmin(this);
                fa.Show();
            }
            else
                showForm(fa);
        }

        private void bookbutton_Click(object sender, EventArgs e)
        {
            if (RBmanywindows.Checked)
            {
                FormBook fb = new FormBook();
                fb.Show();
            }
            else
                showForm(fb);
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
            if (RBmanywindows.Checked)
            {
                FormHuvudbok fhb1 = new FormHuvudbok();
                fhb1.Show();
            }
            else
                showForm(fhb);
        }

        private void importexportbutton_Click(object sender, EventArgs e)
        {
            if (RBmanywindows.Checked)
            {
                FormImportExport fie1 = new FormImportExport();
                fie1.Show();
            }
            else
                showForm(fie);
        }

        private void verbutton_Click(object sender, EventArgs e)
        {
            if (RBmanywindows.Checked)
            {
                FormVerifikatlista fv1 = new FormVerifikatlista();
                fv1.Show();
            }
            else
                showForm(fv);
        }

        private void rrbutton_Click(object sender, EventArgs e)
        {
            if (RBmanywindows.Checked)
            {
                FormRR frr1 = new FormRR("Resultaträkning");
                frr1.Show();
            }
            else
                showForm(frr);
        }

        private void balansbutton_Click(object sender, EventArgs e)
        {
            if (RBmanywindows.Checked)
            {
                FormRR frr1 = new FormRR("Balansräkning");
                frr1.Show();
            }
            else
                showForm(fbr);
        }

        private void momsbutton_Click(object sender, EventArgs e)
        {
            if (RBmanywindows.Checked)
            {
                FormMoms fm1 = new FormMoms();
                fm1.Show();
            }
            else
                showForm(fm);
        }


        List<Form> formList;
        FormAdmin fa;
        FormBook fb;
        FormHuvudbok fhb;
        FormImportExport fie;
        FormVerifikatlista fv;
        FormRR frr;
        FormRR fbr;
        FormMoms fm;
        private void createForms()
        {
            if (RBmanywindows.Checked)
                return;

            fa = new FormAdmin(this);
            fb = new FormBook();
            fhb = new FormHuvudbok();
            fie = new FormImportExport();
            fv = new FormVerifikatlista();
            frr = new FormRR("Resultaträkning");
            fbr = new FormRR("Balansräkning");
            fm = new FormMoms();

            formList = new List<Form>();
            formList.Add(fa);
            formList.Add(fb);
            formList.Add(fhb);
            formList.Add(fie);
            formList.Add(fv);
            formList.Add(frr);
            formList.Add(fbr);
            formList.Add(fm);

            foreach (var f in formList) 
            {
                f.Dock = DockStyle.Fill;
                f.TopLevel = false;
                f.TopMost = true;
                f.FormBorderStyle = FormBorderStyle.None;
                f.AutoScroll = true;
            }
        }

        private void showForm(Form form)
        {
            if (RBsamewindow.Checked)
            {
                this.panelContainer.Controls.Clear();
                this.panelContainer.Controls.Add(form);
                form.Show();
            }
            //else
            //{
            //    Form f = (Form)Activator.CreateInstance(form.GetType());
            //    f.Show();
            //}
        }


        bool sidebarExpanded = true;
        private void sidebarTimer_Tick(object sender, EventArgs e)
        {
            if (sidebarExpanded)
            {
                flowLayoutPanelSidebar.Width -= 50;
                if (flowLayoutPanelSidebar.Width <= flowLayoutPanelSidebar.MinimumSize.Width)
                {
                    sidebarExpanded = false;
                    timerSidebar.Stop();
                }
            }
            else
            {
                flowLayoutPanelSidebar.Width += 50;
                if (flowLayoutPanelSidebar.Width >= flowLayoutPanelSidebar.MaximumSize.Width)
                {
                    sidebarExpanded = true;
                    timerSidebar.Stop();
                }
            }
        }

        private void buttonMenu_Click(object sender, EventArgs e)
        {
            timerSidebar.Start();
        }

        bool accountingExpanded = false;
        private void timerAccounting_Tick(object sender, EventArgs e)
        {
            if (accountingExpanded)
            {
                flowLayoutPanelAccounting.Height -= 100;
                if (flowLayoutPanelAccounting.Height <= flowLayoutPanelAccounting.MinimumSize.Height)
                {
                    accountingExpanded = false;
                    timerAccounting.Stop();
                }
             }
            else
            {
                flowLayoutPanelAccounting.Height += 100;
                if (flowLayoutPanelAccounting.Height >= flowLayoutPanelAccounting.MaximumSize.Height)
                {
                    accountingExpanded = true;
                    timerAccounting.Stop();
                }
            }
        }

        private void buttonAccounting_Click(object sender, EventArgs e)
        {
            timerAccounting.Start();
        }

        bool invoicingExpanded = false;
        private void timerInvoicing_Tick(object sender, EventArgs e)
        {
            if (invoicingExpanded)
            {
                flowLayoutPanelInvoicing.Height -= 100;
                if (flowLayoutPanelInvoicing.Height <= flowLayoutPanelInvoicing.MinimumSize.Height)
                {
                    invoicingExpanded = false;
                    timerInvoicing.Stop();
                }
            }
            else
            {
                flowLayoutPanelInvoicing.Height += 100;
                if (flowLayoutPanelInvoicing.Height >= flowLayoutPanelInvoicing.MaximumSize.Height)
                {
                    invoicingExpanded = true;
                    timerInvoicing.Stop();
                }
            }
        }

        private void buttonInvoicing_Click(object sender, EventArgs e)
        {
            timerInvoicing.Start();
        }

        bool settingsExpanded = false;
        private void timerSettings_Tick(object sender, EventArgs e)
        {
            if (settingsExpanded)
            {
                flowLayoutPanelSettings.Height -= 100;
                if (flowLayoutPanelSettings.Height <= flowLayoutPanelSettings.MinimumSize.Height)
                {
                    settingsExpanded = false;
                    timerSettings.Stop();
                }
            }
            else
            {
                flowLayoutPanelSettings.Height += 100;
                if (flowLayoutPanelSettings.Height >= flowLayoutPanelSettings.MaximumSize.Height)
                {
                    settingsExpanded = true;
                    timerSettings.Stop();
                }
            }

        }
        private void buttonSettings_Click(object sender, EventArgs e)
        {
            timerSettings.Start();
        }

    }
}

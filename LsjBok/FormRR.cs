using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LsjBok
{
    public partial class FormRR : Form
    {
        TreeView tree = new TreeView();
        int localfiscal = Form1.currentfiscal;
        string headerstring = "";
        public FormRR(string headerpar)
        {
            headerstring = headerpar;
            InitializeComponent();
            if (rrbrclass.rrlist.Count == 0)
                rrbrclass.fill_rrbr();
            updatetitle();
            tree.Font = new Font(FontFamily.GenericMonospace, 12);

            filltree();

            tree.Left = 20;
            tree.Top = 20;
            tree.Width = this.Width - 140;
            tree.Height = this.Height - 100;
            this.Controls.Add(tree);

            tree.NodeMouseDoubleClick += new TreeNodeMouseClickEventHandler(tree_NodeMouseDoubleClick);

            foreach (var fy in (from c in Form1.db.Fiscalyear where c.Company == Form1.currentcompany select c))
            {
                LBfiscal.Items.Add(fy.Name);
                if (fy.Id == Form1.currentfiscal)
                    LBfiscal.SelectedItem = fy.Name;
            }
        }

        public void filltree()
        {
            tree.BeginUpdate();
            //tree.Nodes.Add("Parent");
            //tree.Nodes[0].Nodes.Add("Child 1");
            //tree.Nodes[0].Nodes.Add("Child 2");
            //tree.Nodes[0].Nodes[1].Nodes.Add("Grandchild");
            //tree.Nodes[0].Nodes[1].Nodes[0].Nodes.Add("Great Grandchild");

            string dashline = "".PadRight(80, '-');

            if (headerstring == "Resultaträkning")
            {
                rrbrclass rrtop = (from c in rrbrclass.rrlist where c.field == "Resultaträkning" select c).First();

                rrbrclass intakt = (from c in rrbrclass.rrlist where c.field == "Rörelsens intäkter" select c).First();
                rrbrclass kostnad = (from c in rrbrclass.rrlist where c.field == "Rörelsens kostnader" select c).First();
                rrbrclass finans = (from c in rrbrclass.rrlist where c.field == "Finansiella poster" select c).First();
                rrbrclass bokdisp = (from c in rrbrclass.rrlist where c.field == "Bokslutsdispositioner" select c).First();
                rrbrclass skatt = (from c in rrbrclass.rrlist where c.field == "Skatter" select c).First();

                TreeNode rrnode = tree.Nodes.Add(rrtop.field + " | " + (intakt.sumamount(localfiscal)-kostnad.sumamount(localfiscal)).ToString("N2"));
                addtree(rrnode, intakt, 0,rrbrclass.rrlist);
                addtree(rrnode, kostnad, 0, rrbrclass.rrlist);
                rrnode.Nodes.Add(dashline);
                decimal rorelseresultat = intakt.sumamount(localfiscal) - kostnad.sumamount(localfiscal);
                TreeNode roresnode = rrnode.Nodes.Add(RRrow("Rörelseresultat", 0, rorelseresultat));
                roresnode.NodeFont = new Font(tree.Font, FontStyle.Bold);
                rrnode.Nodes.Add(dashline);
                addtree(rrnode, finans, 0, rrbrclass.rrlist);
                decimal resultatfinans = rorelseresultat - finans.sumamount(localfiscal);
                TreeNode firesnode = rrnode.Nodes.Add(RRrow("Resultat efter finansiella poster", 0, resultatfinans));
                firesnode.NodeFont = new Font(tree.Font, FontStyle.Bold);
                addtree(rrnode, bokdisp, 0, rrbrclass.rrlist);
                decimal resultatbokdisp = resultatfinans - bokdisp.sumamount(localfiscal);
                TreeNode bokresnode = rrnode.Nodes.Add(RRrow("Resultat efter bokslutsdispositioner", 0, resultatbokdisp));
                bokresnode.NodeFont = new Font(tree.Font, FontStyle.Bold);
                addtree(rrnode, skatt, 0, rrbrclass.rrlist);
                rrnode.Expand();
            }
            else if (headerstring == "Balansräkning")
            {
                rrbrclass rrtop = (from c in rrbrclass.brlist where c.field == "Balansräkning" select c).First();

                rrbrclass tillgang = (from c in rrbrclass.brlist where c.field == "Tillgångar" select c).First();
                rrbrclass skuld = (from c in rrbrclass.brlist where c.field == "Eget kapital och skulder" select c).First();

                decimal ts = tillgang.sumamount(localfiscal) - skuld.sumamount(localfiscal);
                string balansvarning = ts == 0 ? "" : " !!! EJ I BALANS !!!";
                TreeNode rrnode = tree.Nodes.Add(rrtop.field + " | " + ts.ToString("N2")+balansvarning);
                addtree(rrnode, tillgang, 0, rrbrclass.brlist);
                rrnode.Nodes.Add(dashline);
                addtree(rrnode, skuld, 0, rrbrclass.brlist);
                //decimal balans = tillgang.sumamount(localfiscal) - skuld.sumamount(localfiscal);
                rrnode.Expand();
            }

            tree.EndUpdate();

        }

        public string RRrow(string label,int level, decimal amount)
        {
            string s = label.PadRight(60 - 2 * level) + " | " + amount.ToString("N2").PadLeft(12);
            return s;
        }

        public void addtree(TreeNode rootnode,rrbrclass rootrr,int level, List<rrbrclass> rrlist)
        {
            TreeNode newnode = rootnode.Nodes.Add(RRrow(rootrr.field,level,rootrr.sumamount(localfiscal)));
            if (!String.IsNullOrEmpty(rootrr.description))
                newnode.ToolTipText = rootrr.description;
            foreach (var rr in (from c in rrlist where c.partof == rootrr.field select c))
            {
                if (rr.sumamount(localfiscal) != 0)
                    addtree(newnode, rr,level+1,rrlist);
            }
            foreach (Konto kk in rootrr.getkonto(localfiscal))
            {
                if (kk.UB != 0)
                {
                    TreeNode knode = newnode.Nodes.Add(RRrow(kk.Number + " | " + kk.Name, level + 1, rootrr.sign * kk.UB));
                    //knode.ToolTipText = kk.
                }
            }
        }

        public void updatetitle()
        {
            this.Text = "LsjBok "+headerstring+" - " + util.getcompanyname() + " - " + util.getfiscalname(localfiscal);
        }

        private void closebutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void tree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                // Look for a file extension.
                if (e.Node.Text.Contains("Ver.nr"))
                {
                    int radid = util.tryconvert(e.Node.Text.Split('#').Last().Trim());
                    Rad rr = (from c in Form1.db.Rad where c.Id == radid select c).First();
                    //int vernr = util.tryconvert(e.Node.Text.Split('|')[0].Replace("Ver.nr", "").Trim());
                    FormBook fbn = new FormBook(rr.VerVer, false);
                    fbn.Show();
                }
            }
            // If the file is not found, handle the exception and inform the user.
            catch (System.ComponentModel.Win32Exception)
            {
                MessageBox.Show("File not found.");
            }
        }

        private void LBfiscal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LBfiscal.SelectedItem != null)
            {
                var q = from c in Form1.db.Fiscalyear
                        where c.Company == Form1.currentcompany
                        where c.Name == LBfiscal.SelectedItem.ToString()
                        select c;
                if (q.Count() > 0)
                {
                    localfiscal = q.First().Id;
                    tree.Nodes.Clear();
                    filltree();
                    updatetitle();
                }
            }
        }
    }
}

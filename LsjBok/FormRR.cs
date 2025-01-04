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
        int localfiscal = common.currentfiscal;
        string headerstring = "";
        public FormRR(string headerpar)
        {
            headerstring = headerpar;
            InitializeComponent();
            if (rrbrclass.rrlist.Count == 0)
                rrbrclass.fill_rrbr();
            updatetitle();
            tree.Font = new Font(FontFamily.GenericMonospace, 11);

            filltree();

            tree.Left = 20;
            tree.Top = 20;
            tree.Width = this.Width - 140;
            tree.Height = this.Height - 100;
            this.Controls.Add(tree);

            tree.NodeMouseDoubleClick += new TreeNodeMouseClickEventHandler(tree_NodeMouseDoubleClick);

            foreach (var fy in (from c in common.db.Fiscalyear where c.Company == common.currentcompany select c))
            {
                LBfiscal.Items.Add(fy.Name);
                if (fy.Id == common.currentfiscal)
                {
                    LBfiscal.SelectedItem = fy.Name;
                    TBstart.Text = fy.Startdate.ToString("yyMMdd");
                    TBslut.Text =  fy.Enddate.ToString("yyMMdd");
                }
            }

            TBstart.LostFocus += new EventHandler(TBdate_LostFocus);
            TBslut.LostFocus +=  new EventHandler(TBdate_LostFocus);
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

            DateTime start = fiscalclass.infiscal(util.parsedate(TBstart.Text)) ?
                (DateTime)util.parsedate(TBstart.Text) :
                fiscalclass.getfiscal(localfiscal).Startdate;
            DateTime end = fiscalclass.infiscal(util.parsedate(TBslut.Text)) ?
                (DateTime)util.parsedate(TBslut.Text) :
                fiscalclass.getfiscal(localfiscal).Enddate;


            if (headerstring == "Resultaträkning")
            {
                //rrbrclass rrtop = (from c in rrbrclass.rrlist where c.field == "Resultaträkning" select c).First();

                //rrbrclass intakt = (from c in rrbrclass.rrlist where c.field == "Rörelsens intäkter" select c).First();
                //rrbrclass kostnad = (from c in rrbrclass.rrlist where c.field == "Rörelsens kostnader" select c).First();
                //rrbrclass finans = (from c in rrbrclass.rrlist where c.field == "Finansiella poster" select c).First();
                //rrbrclass bokdisp = (from c in rrbrclass.rrlist where c.field == "Bokslutsdispositioner" select c).First();
                //rrbrclass skatt = (from c in rrbrclass.rrlist where c.field == "Skatter" select c).First();
                rrbrclass rrtop = rrbrclass.rrtop;

                rrbrclass intakt = rrbrclass.intakt;
                rrbrclass kostnad = rrbrclass.kostnad;
                rrbrclass finans = rrbrclass.finans;
                rrbrclass bokdisp = rrbrclass.bokdisp;
                rrbrclass skatt = rrbrclass.skatt;

                decimal rorelseresultat = -intakt.sumamount_transactions(localfiscal, start, end) - kostnad.sumamount_transactions(localfiscal, start, end);
                TreeNode rrnode = tree.Nodes.Add(rrtop.field + " | " + (rorelseresultat).ToString("N2"));
                addtreeRR(rrnode, intakt, 0,rrbrclass.rrlist, start, end);
                addtreeRR(rrnode, kostnad, 0, rrbrclass.rrlist, start, end);
                rrnode.Nodes.Add(dashline);
                TreeNode roresnode = rrnode.Nodes.Add(RRrow("Rörelseresultat", 0, rorelseresultat));
                roresnode.NodeFont = new Font(tree.Font, FontStyle.Bold);
                rrnode.Nodes.Add(dashline);
                addtreeRR(rrnode, finans, 0, rrbrclass.rrlist, start, end);
                decimal resultatfinans = rorelseresultat - finans.sumamount_transactions(localfiscal, start, end);
                TreeNode firesnode = rrnode.Nodes.Add(RRrow("Resultat efter finansiella poster", 0, resultatfinans));
                firesnode.NodeFont = new Font(tree.Font, FontStyle.Bold);
                addtreeRR(rrnode, bokdisp, 0, rrbrclass.rrlist, start, end);
                decimal resultatbokdisp = resultatfinans - bokdisp.sumamount_transactions(localfiscal, start, end);
                TreeNode bokresnode = rrnode.Nodes.Add(RRrow("Resultat efter bokslutsdispositioner", 0, resultatbokdisp));
                bokresnode.NodeFont = new Font(tree.Font, FontStyle.Bold);
                addtreeRR(rrnode, skatt, 0, rrbrclass.rrlist, start, end);
                decimal resultatefterskatt = resultatbokdisp - skatt.sumamount_transactions(localfiscal, start, end);
                TreeNode efterskattnode = rrnode.Nodes.Add(RRrow("Resultat efter skatt", 0, resultatefterskatt));
                rrnode.Expand();
            }
            else if (headerstring == "Balansräkning")
            {
                rrbrclass rrtop = (from c in rrbrclass.brlist where c.field == "Balansräkning" select c).First();

                rrbrclass tillgang = rrbrclass.get_assets();// (from c in rrbrclass.brlist where c.field == "Tillgångar" select c).First();
                rrbrclass skuld = rrbrclass.get_debts();// (from c in rrbrclass.brlist where c.field == "Eget kapital och skulder" select c).First();

                decimal tsIB = tillgang.sumamount_UB(localfiscal, start) + skuld.sumamount_UB(localfiscal, start);
                decimal tsUB = tillgang.sumamount_UB(localfiscal, end) + skuld.sumamount_UB(localfiscal, end);
                string balansvarningIB = tsIB == 0 ? "" : " !!! EJ I BALANS !!!";
                string balansvarningUB = tsUB == 0 ? "" : " !!! EJ I BALANS !!!";
                TreeNode rrnode = tree.Nodes.Add(rrtop.field + " | IB " + tsIB.ToString("N2")+ balansvarningIB + " | UB " + tsUB.ToString("N2") + balansvarningUB);
                addtreeBR(rrnode, tillgang, 0, rrbrclass.brlist, start, end);
                rrnode.Nodes.Add(dashline);
                addtreeBR(rrnode, skuld, 0, rrbrclass.brlist, start, end);
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

        public string BRrow(string label, int level, decimal IB, decimal UB)
        {
            string s = label.PadRight(60 - 2 * level) + " | IB " + IB.ToString("N2").PadLeft(12) + " | UB " + UB.ToString("N2").PadLeft(12);
            return s;
        }

        public void addtreeRR(TreeNode rootnode,rrbrclass rootrr,int level, List<rrbrclass> rrlist,DateTime start, DateTime end)
        {
            TreeNode newnode = rootnode.Nodes.Add(RRrow(rootrr.field,level,-rootrr.sumamount_transactions(localfiscal, start, end)));
            if (!String.IsNullOrEmpty(rootrr.description))
                newnode.ToolTipText = rootrr.description;
            foreach (var rr in (from c in rrlist where c.partof == rootrr.field select c))
            {
                //if (rr.sumamount(localfiscal, start, end) != 0)
                    addtreeRR(newnode, rr,level+1,rrlist,start,end);
            }
            foreach (Konto kk in rootrr.getkonto(localfiscal))
            {
                decimal sum = kontoclass.getUB(kk, end) - kontoclass.getUB(kk, start);
                if (sum != 0)
                {
                    TreeNode knode = newnode.Nodes.Add(RRrow(kk.Number + " | " + kk.Name, level + 1, sum));
                    //knode.ToolTipText = kk.
                }
            }
        }

        public void addtreeBR(TreeNode rootnode, rrbrclass rootrr, int level, List<rrbrclass> rrlist, DateTime start, DateTime end)
        {
            TreeNode newnode = rootnode.Nodes.Add(BRrow(rootrr.field, level, rootrr.sumamount_UB(localfiscal, start), rootrr.sumamount_UB(localfiscal, end)));
            if (!String.IsNullOrEmpty(rootrr.description))
                newnode.ToolTipText = rootrr.description;
            foreach (var rr in (from c in rrlist where c.partof == rootrr.field select c))
            {
                //if (rr.sumamount(localfiscal, start, end) != 0)
                addtreeBR(newnode, rr, level + 1, rrlist, start, end);
            }
            foreach (Konto kk in rootrr.getkonto(localfiscal))
            {
                if (kk.UB != 0)
                {
                    //TreeNode knode = newnode.Nodes.Add(BRrow(kk.Number + " | " + kk.Name, level + 1, rootrr.sign * kk.UB));
                    TreeNode knode = newnode.Nodes.Add(BRrow(kk.Number + " | " + kk.Name, level + 1, kontoclass.getUB(kk,start),kontoclass.getUB(kk,end)));
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
                    Rad rr = (from c in common.db.Rad where c.Id == radid select c).First();
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

        private void TBdate_LostFocus(object sender, EventArgs e)
        {
            updatetree();
        }


        private void updatetree()
        {
            tree.Nodes.Clear();
            filltree();
            updatetitle();
        }

        private void LBfiscal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LBfiscal.SelectedItem != null)
            {
                var q = from c in common.db.Fiscalyear
                        where c.Company == common.currentcompany
                        where c.Name == LBfiscal.SelectedItem.ToString()
                        select c;
                if (q.Count() > 0)
                {
                    localfiscal = q.First().Id;
                    TBstart.Text = q.First().Startdate.ToString("yyMMdd");
                    TBslut.Text = q.First().Enddate.ToString("yyMMdd");
                    updatetree();
                }
            }
        }
    }
}

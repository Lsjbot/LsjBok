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
    public partial class FormHuvudbok : Form
    {
        int localfiscal = common.currentfiscal;
        TreeView tree = new TreeView();
        public FormHuvudbok()
        {
            InitializeComponent();
            updatetitle();
            filltree();
            this.Controls.Add(tree);
            tree.Font = new Font(FontFamily.GenericMonospace, 11);

            tree.NodeMouseDoubleClick += new TreeNodeMouseClickEventHandler(tree_NodeMouseDoubleClick);

            foreach (var fy in (from c in common.db.Fiscalyear where c.Company == common.currentcompany select c))
            {
                LBfiscal.Items.Add(fy.Name);
                if (fy.Id == common.currentfiscal)
                {
                    LBfiscal.SelectedItem = fy.Name;
                    TBstart.Text = fy.Startdate.ToString("yyMMdd");
                    TBslut.Text = fy.Enddate.ToString("yyMMdd");
                }
            }

            TBstart.LostFocus += new EventHandler(TBdate_LostFocus);
            TBslut.LostFocus += new EventHandler(TBdate_LostFocus);

        }

        private void filltree()
        {
            tree.BeginUpdate();
            //tree.Nodes.Add("Parent");
            //tree.Nodes[0].Nodes.Add("Child 1");
            //tree.Nodes[0].Nodes.Add("Child 2");
            //tree.Nodes[0].Nodes[1].Nodes.Add("Grandchild");
            //tree.Nodes[0].Nodes[1].Nodes[0].Nodes.Add("Great Grandchild");
            var q = from c in common.db.Konto
                    where c.Year == localfiscal
                    select c;
            int inode = 0;
            foreach (var kk in q.OrderBy(c => c.Number))
            {
                kontoclass.updateUB(kk);
                tree.Nodes.Add(kk.Number + " " + kk.Name + " | IB: " + kk.IB.ToString("N2") + " | UB: " + kk.UB.ToString("N2"));
                var qrad = from c in common.db.Rad
                           where c.Konto == kk.Id
                           select c;
                decimal saldo = kk.IB;
                foreach (var rr in qrad.OrderBy(c=>c.VerVer.Verdate))
                {
                    saldo += rr.Amount;
                    string debcred = rr.Amount > 0 ?
                        " | " + rr.Amount.ToString("N2").PadLeft(12) + " |           0 |" :
                        " |            0 |" + (-rr.Amount).ToString("N2").PadLeft(12) + " |";
                    tree.Nodes[inode].Nodes.Add("Ver.nr" + rr.VerVer.Vernumber.ToString().PadLeft(5) + debcred + saldo.ToString("N2").PadLeft(12) + " | "+rr.VerVer.Verdate.ToString("yy-MM-dd") + " | Rad #" + rr.Id);
                }
                inode++;
            }
            tree.EndUpdate();
            tree.Left = 20;
            tree.Top = 20;
            tree.Width = this.Width - 40;
            tree.Height = this.Height - 100;
        }

        private void TBdate_LostFocus(object sender, EventArgs e)
        {
            updatetree();
        }



        public void updatetitle()
        {
            this.Text = "LsjBok huvudbok - " + util.getusername() + " - " + util.getcompanyname() + " - " + util.getfiscalname();
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
                    FormBook fbn = new FormBook(rr.VerVer,false);
                    fbn.Show();
                }
            }
            // If the file is not found, handle the exception and inform the user.
            catch (System.ComponentModel.Win32Exception)
            {
                MessageBox.Show("File not found.");
            }
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

        //private decimal UpdateUB(Konto kk)
        //{
        //    decimal value = kk.IB;
        //    var q = from c in common.db.Rad where c.Konto == kk.Id select c;
        //    foreach (Rad rr in q)
        //    {
        //        value += rr.Amount;
        //    }
        //    return value;
        //}

        private void IBbutton_Click(object sender, EventArgs e)
        {
            //kludge to clean up after SIE-import bug losing IB values

            OpenFileDialog of = new OpenFileDialog();
            of.Title = "File with correct IB values";

            var q = from c in common.db.Konto
                    where c.Year == localfiscal
                    select c;

            if (of.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(of.FileName))
                {
                    int n = 0;
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] words = line.Split('\t');
                        if (words.Length < 2)
                            continue;
                        int konto = Convert.ToInt32(words[0]);
                        decimal amount = Convert.ToDecimal(words[1]);
                        var q1 = from c in q
                                 where c.Number == konto
                                 select c;
                        if (q1.Count() == 1)
                        {
                            Konto kk = q1.First();
                            kk.IB = amount;
                            kontoclass.updateUB(kk);
                            n++;
                        }
                        else
                        {
                            MessageBox.Show("q1.Count = " + q1.Count() + ", konto = " + konto + ", amount = " + amount);
                        }
                    }
                    MessageBox.Show("Fixat IB för " + n + " konton");
                    if (n > 0)
                    {
                        common.db.SubmitChanges();
                        updatetree();
                    }
                }
            }
        }

        private void updatebutton_Click(object sender, EventArgs e)
        {
            //var q = from c in common.db.Konto
            //        where c.Year == common.currentfiscal
            //        select c;
            //foreach (Konto kk in q)
            //    kontoclass.updateUB(kk);
            kontoclass.updateUB();
            updatetree();
        }

        private void FormHuvudbok_ResizeEnd(object sender, EventArgs e)
        {
            tree.Width = this.Width - 40;
            tree.Height = this.Height - 100;
        }
    }
}

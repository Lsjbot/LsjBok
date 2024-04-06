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
    public partial class FormVerifikatlista : Form
    {
        public FormVerifikatlista()
        {
            InitializeComponent();
            updatetitle();
            TreeView tree = new TreeView();
            tree.BeginUpdate();
            //tree.Nodes.Add("Parent");
            //tree.Nodes[0].Nodes.Add("Child 1");
            //tree.Nodes[0].Nodes.Add("Child 2");
            //tree.Nodes[0].Nodes[1].Nodes.Add("Grandchild");
            //tree.Nodes[0].Nodes[1].Nodes[0].Nodes.Add("Great Grandchild");
            var q = from c in common.db.Ver
                    where c.Year == common.currentfiscal
                    select c;
            int inode = 0;
            foreach (var kk in q.OrderBy(c=>c.Vernumber))
            {
                tree.Nodes.Add("V"+kk.Vernumber + " | " + kk.Description+" | Ver#"+kk.Id);
                var qrad = from c in common.db.Rad
                           where c.Ver == kk.Id
                           select c;
                foreach (var rr in qrad)
                {
                    string debcred = rr.Amount > 0 ?
                        " | " + rr.Amount.ToString("N2").PadLeft(12) + " |            0 |" :
                        " |            0 |" + (-rr.Amount).ToString("N2").PadLeft(12) + " |";
                    tree.Nodes[inode].Nodes.Add("Konto" + rr.KontoKonto.Number.ToString().PadLeft(5) + debcred + " | Rad #" + rr.Id);
                }
                inode++;
            }
            tree.EndUpdate();
            tree.Left = 20;
            tree.Top = 20;
            tree.Width = this.Width - 40;
            tree.Height = this.Height - 100;
            this.Controls.Add(tree);

            tree.NodeMouseDoubleClick += new TreeNodeMouseClickEventHandler(tree_NodeMouseDoubleClick);
        }

        public void updatetitle()
        {
            this.Text = "LsjBok verifikatlista - " + util.getusername() + " - " + util.getcompanyname() + " - " + util.getfiscalname();
        }

        void tree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Text.Contains("Konto"))
            {
                int radid = util.tryconvert(e.Node.Text.Split('#').Last().Trim());
                Rad rr = (from c in common.db.Rad where c.Id == radid select c).First();
                //int vernr = util.tryconvert(e.Node.Text.Split('|')[0].Replace("Ver.nr", "").Trim());
                FormBook fbn = new FormBook(rr.VerVer, false);
                fbn.Show();
            }
            else
            {
                int verid = util.tryconvert(e.Node.Text.Split('#').Last().Trim());
                Ver vvin = (from c in common.db.Ver where c.Id == verid select c).FirstOrDefault();
                if (vvin != null)
                {
                    FormBook fbn = new FormBook(vvin, false);
                    fbn.Show();
                }

            }
        }

    }
}

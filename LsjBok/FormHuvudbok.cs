﻿using System;
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
    public partial class FormHuvudbok : Form
    {
        public FormHuvudbok()
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
            var q = from c in Form1.db.Konto
                    where c.Year == Form1.currentfiscal
                    select c;
            int inode = 0;
            foreach (var kk in q.OrderBy(c => c.Number))
            {
                tree.Nodes.Add(kk.Number + " " + kk.Name+" | IB: "+kk.IB.ToString("N2")+" | UB: "+kk.UB.ToString("N2"));
                var qrad = from c in Form1.db.Rad
                           where c.Konto == kk.Id
                           select c;
                foreach (var rr in qrad)
                {
                    string debcred = rr.Amount > 0 ?
                        " | " + rr.Amount.ToString("N2").PadLeft(12) + " |            0 |" :
                        " |            0 |" + (-rr.Amount).ToString("N2").PadLeft(12)+" |";
                    tree.Nodes[inode].Nodes.Add("Ver.nr" + rr.VerVer.Vernumber.ToString().PadLeft(5) + debcred+" | Rad #"+rr.Id);
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
                    Rad rr = (from c in Form1.db.Rad where c.Id == radid select c).First();
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
    }
}

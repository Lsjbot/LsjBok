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
    public partial class FormBokslut : Form
    {
        public static Color yescolor = Color.LightGreen;
        public static Color nocolor = Color.MistyRose;

        decimal rorelseresultat = 0;
        decimal resultatfinans = 0;
        decimal bokdisp = 0;
        decimal resultatbokdisp = 0;
        decimal skatt = 0;
        decimal resultatefterskatt = 0;
        decimal taxrate = (decimal)20.6;
        
        public FormBokslut()
        {
            InitializeComponent();
            updatetitle();
            updatefiscal();
            updateamounts();

            foreach (Control cc in this.Controls)
            {
                if (cc.Name.StartsWith("panel"))
                    cc.BackColor = nocolor;
            }

            var q = from c in common.db.Konto
                    where c.Year == common.currentfiscal
                    where c.Konto2 == 21
                    select c;

            aterforandebutton.Enabled = false;
            foreach (Konto kk in q)
            {
                if (kk.UB != 0)
                {
                    CBaterforande.Items.Add(Math.Abs(kk.UB).ToString("N0") + " | " + kk.Number + " | " + kk.Name);
                }
            }
        }

        public void updateamounts()
        {
            kontoclass.updateUB();

            rorelseresultat = -rrbrclass.intakt.sumamount(common.currentfiscal) - rrbrclass.kostnad.sumamount(common.currentfiscal);
            resultatfinans = rorelseresultat - rrbrclass.finans.sumamount(common.currentfiscal);
            bokdisp = rrbrclass.bokdisp.sumamount(common.currentfiscal);
            resultatbokdisp = resultatfinans - bokdisp;
            resultatefterskatt = resultatbokdisp - rrbrclass.skatt.sumamount(common.currentfiscal);

            TBrorelseresultat.Text = rorelseresultat.ToString("N2");
            TBresultatfinans.Text = resultatfinans.ToString("N2");
            TBbokdisp.Text = bokdisp.ToString("N2");
            TBresultatbokdisp.Text = resultatbokdisp.ToString("N2");
            TBskattesats.Text = taxrate.ToString("N1");
            skatt = (decimal)0.01 * resultatbokdisp * taxrate;
            TBskatt.Text = skatt.ToString("N2");
            resultatefterskatt = resultatbokdisp - skatt;
            TBefterskatt.Text = resultatefterskatt.ToString("N2");
        }

        public void updatetitle()
        {
            this.Text = "LsjBok - " + util.getusername(common.currentuser) + " - " + util.getcompanyname(common.currentcompany) + " - " + util.getfiscalname(common.currentfiscal);
        }

        public void updatefiscal()
        {
            LBfiscal.Items.Clear();
            var q = from c in common.db.Fiscalyear where c.Company == common.currentcompany select c;
            foreach (var ff in q)
            {
                LBfiscal.Items.Add(ff.Name);
                if (ff.Enddate >= DateTime.Now.Date)
                    common.currentfiscal = ff.Id;
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

        private void RByesbook_CheckedChanged(object sender, EventArgs e)
        {
            (sender as Control).Parent.BackColor = yescolor;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RBnobook_CheckedChanged(object sender, EventArgs e)
        {
            (sender as Control).Parent.BackColor = nocolor;
        }

        private void momsbutton_Click(object sender, EventArgs e)
        {
            var form = new FormMoms();
            form.Show();
        }

        private void CBaterforande_SelectedIndexChanged(object sender, EventArgs e)
        {
            aterforandebutton.Enabled = true;
        }

        private void avsattningbutton_Click(object sender, EventArgs e)
        {
            decimal amount = util.tryconvertdecimal(TBavsattning.Text);
            if (amount > 0)
            {
                Dictionary<int, decimal> kontolist = new Dictionary<int, decimal>();
                kontolist.Add(8811, amount);
                int year = fiscalclass.getyear(common.currentfiscal);
                int lastdigit = year % 10;
                int kontonr = 2120 + lastdigit;
                decimal oldamount = kontoclass.updateUB(kontonr);
                if (oldamount > 0)
                {
                    kontonr = 2130 + lastdigit;
                }
                kontolist.Add(kontonr, -amount);

                FormBook fb = new FormBook("Bokför avsättning till periodiseringsfond", kontolist);
                fb.Show();
                updateamounts();
            }
        }

        private void aterforandebutton_Click(object sender, EventArgs e)
        {
            if (CBaterforande.SelectedItem != null)
            {
                string s = CBaterforande.SelectedItem.ToString();
                string[] w = s.Split('|');
                //CBaterforande.Items.Add(kk.UB.ToString("N0") + " | " + kk.Number + " | " + kk.Name);
                if (w.Length < 3)
                    return;
                decimal amount = util.tryconvertdecimal(w[0]);
                int kontonr = util.tryconvert(w[1]);
                Dictionary<int, decimal> kontolist = new Dictionary<int, decimal>();
                kontolist.Add(8819, -amount);
                kontolist.Add(kontonr, amount);

                FormBook fb = new FormBook("Bokför återförande från periodiseringsfond", kontolist);
                fb.Show();
                updateamounts();
            }
        }
    }
}

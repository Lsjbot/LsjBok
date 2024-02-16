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
    public partial class FormBook : Form
    {
        static int maxrow = 20;
        static int defaultrow = 3;
        static int xbase = 10;
        static int ybase = 100;
        static int numberwidth = 100;
        static int moneywidth = 150;
        static int sep = 10;
        static int namewidth = 300;
        static int onoffwidth = 20;
        static int heightdist = 30;

        int activerows;

        private ComboBox[] cbnumber = new ComboBox[maxrow];
        private ComboBox[] cbname = new ComboBox[maxrow];
        private TextBox[] cbcredit = new TextBox[maxrow];
        private TextBox[] cbdebit = new TextBox[maxrow];
        private Button[] onoff = new Button[maxrow];
        private bool[] enabled = new bool[maxrow];

        private TextBox TBcreditsum = new TextBox();
        private TextBox TBdebitsum = new TextBox();
        private TextBox TBdiff = new TextBox();
        private Label creditlabel = new Label();
        private Label debitlabel = new Label();
        private Label difflabel = new Label();

        public FormBook()
        {
            InitializeComponent();



            for (int i=0;i<maxrow;i++)
            {
                cbnumber[i] = new ComboBox();
                cbnumber[i].Left = xbase;
                cbnumber[i].Width = numberwidth;
                cbnumber[i].Top = ybase + i*heightdist;

                cbname[i] = new ComboBox();
                cbname[i].Left = cbnumber[i].Right + sep;
                cbname[i].Width = namewidth;
                cbname[i].Top = ybase + i * heightdist;

                cbdebit[i] = new TextBox();
                cbdebit[i].Left = cbname[i].Right + sep;
                cbdebit[i].Width = moneywidth;
                cbdebit[i].Top = ybase + i * heightdist;

                cbcredit[i] = new TextBox();
                cbcredit[i].Left = cbdebit[i].Right + sep;
                cbcredit[i].Width = moneywidth;
                cbcredit[i].Top = ybase + i * heightdist;

                onoff[i] = new Button();
                onoff[i].Left = cbcredit[i].Right + sep;
                onoff[i].Width = onoffwidth;
                onoff[i].Top = ybase + i * heightdist;

                if (i < defaultrow)
                    enabled[i] = true;

                this.Controls.Add(cbnumber[i]);
                this.Controls.Add(cbname[i]);
                this.Controls.Add(cbdebit[i]);
                this.Controls.Add(cbcredit[i]);
                this.Controls.Add(onoff[i]);

                onoff[i].Click += new EventHandler(onoffclick);
                cbname[i].TextChanged += new EventHandler(comboBox2_TextChanged);
                cbname[i].SelectedIndexChanged += new EventHandler(comboBox2_SelectedIndexChanged);
                cbnumber[i].TextChanged += new EventHandler(cbnumber_TextChanged);
                cbcredit[i].LostFocus += new EventHandler(cbmoney_Lostfocus);
                cbdebit[i].LostFocus += new EventHandler(cbmoney_Lostfocus);
            }
            activerows = defaultrow;

            setvisible();

            TBcreditsum.Top = cbcredit[0].Top - heightdist;
            TBcreditsum.Left = cbcredit[0].Left;
            TBcreditsum.Width = cbcredit[0].Width;
            TBdebitsum.Top = cbdebit[0].Top - heightdist;
            TBdebitsum.Left = cbdebit[0].Left;
            TBdebitsum.Width = cbdebit[0].Width;
            TBdiff.Top = cbname[0].Top - heightdist;
            TBdiff.Left = cbdebit[0].Left-sep-moneywidth;
            TBdiff.Width = cbdebit[0].Width;

            creditlabel.Text = "Kredit";
            creditlabel.Left = TBcreditsum.Left;
            creditlabel.Top = TBcreditsum.Top - heightdist;
            debitlabel.Text = "Debet";
            debitlabel.Left = TBdebitsum.Left;
            debitlabel.Top = TBdebitsum.Top - heightdist;
            difflabel.Text = "Debet-kredit";
            difflabel.Left = TBdiff.Left;
            difflabel.Top = TBdiff.Top - heightdist;

            this.Controls.Add(TBcreditsum);
            this.Controls.Add(TBdebitsum);
            this.Controls.Add(TBdiff);
            this.Controls.Add(creditlabel);
            this.Controls.Add(debitlabel);
            this.Controls.Add(difflabel);

            TBdate.Text = DateTime.Now.ToString("yyMMdd");
            TBdate.LostFocus += new EventHandler(checkdate);
        }

        private void setvisible()
        {
            int lastenabled = -1;
            for (int i = 0; i < maxrow; i++)
                if (enabled[i])
                    lastenabled = i;
            for (int i = 0; i < maxrow; i++)
            {
                if (enabled[i])
                {
                    onoff[i].Text = "🗑";
                }
                cbnumber[i].Enabled = enabled[i];
                cbnumber[i].Visible = enabled[i];
                cbname[i].Enabled = enabled[i];
                cbname[i].Visible = enabled[i];
                cbdebit[i].Enabled = enabled[i];
                cbdebit[i].Visible = enabled[i];
                cbcredit[i].Enabled = enabled[i];
                cbcredit[i].Visible = enabled[i];
                onoff[i].Enabled = enabled[i];
                onoff[i].Visible = enabled[i];

                if (!enabled[i] && i <= lastenabled+1)
                {
                    onoff[i].Visible = true;
                    onoff[i].Enabled = true;
                    onoff[i].Text = "+";
                }
            }
        }

        private int getrowindex(object sender)
        {
            return ((sender as Control).Top - ybase) / heightdist;
        }

        private void onoffclick(object sender, EventArgs e)
        {
            int i = getrowindex(sender);
            if ((sender as Button).Text == "🗑")
            {
                enabled[i] = false;
                activerows--;
            }
            else if ((sender as Button).Text == "+")
            {
                enabled[i] = true;
                activerows++;
            }
            setvisible();
        }

        bool mytextchange = false;

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mytextchange)
                return;
            int i = ((sender as Control).Top - ybase) / heightdist;

            mytextchange = true;
            if (cbname[i].SelectedItem == null)
                return;
            string s = cbname[i].SelectedItem.ToString();
            cbnumber[i].Text = s.ToString().Split('~')[0].Trim();
            cbname[i].DroppedDown = false;
            cbname[i].SelectedItem = null;
            cbname[i].Items.Clear();
            cbname[i].Items.Add(s.Split('~')[1].Trim());
            cbname[i].Text = s.Split('~')[1].Trim();
            mytextchange = false;
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            if (mytextchange)
                return;
            if ((sender as ComboBox).Text.Length > 1)
            {
                var q = kontoclass.searchkonto((sender as ComboBox).Text);
                if (q.Count() > 0)
                {
                    (sender as ComboBox).BeginUpdate();
                    (sender as ComboBox).Items.Clear();
                    foreach (int k in q.Keys)
                        (sender as ComboBox).Items.Add(k + " ~ " + q[k]);
                    (sender as ComboBox).EndUpdate();
                    //(sender as ComboBox).DropDownStyle = ComboBoxStyle.Simple;
                    (sender as ComboBox).DroppedDown = true;
                }
                (sender as ComboBox).Select((sender as ComboBox).Text.Length, 0);
                
            }
        }

        private void cbnumber_TextChanged(object sender, EventArgs e)
        {
            if ((sender as ComboBox).Text.Length == 4)
            {
                int nr = util.tryconvert((sender as ComboBox).Text);
                int i = ((sender as Control).Top - ybase) / heightdist;
                if (kontoclass.validkonto(nr))
                {
                    mytextchange = true;
                    cbnumber[i].ForeColor = Color.Black;
                    cbname[i].Text = kontoclass.kontodict[nr];
                    mytextchange = false;
                }
                else
                {
                    cbnumber[i].ForeColor = Color.Red;
                }
                (sender as ComboBox).Select((sender as ComboBox).Text.Length, 0);

            }

        }



        private void cbmoney_Lostfocus(object sender, EventArgs e)
        {
            decimal csum = 0;
            decimal dsum = 0;
            for (int i=0;i<maxrow;i++)
            {
                if (!enabled[i])
                    continue;
                if (!kontoclass.validkonto(cbnumber[i].Text))
                    continue;

                decimal c = util.tryconvertdecimal(cbcredit[i].Text);
                decimal d = util.tryconvertdecimal(cbdebit[i].Text);
                if (c == Decimal.MinValue)
                {
                    cbcredit[i].ForeColor = Color.Red;
                    bookbutton.Enabled = false;
                    return;
                }
                else
                    cbcredit[i].ForeColor = Color.Black;
                if (d == Decimal.MinValue)
                {
                    cbdebit[i].ForeColor = Color.Red;
                    bookbutton.Enabled = false;
                    return;
                }
                else
                    cbdebit[i].ForeColor = Color.Black;
                csum += c;
                dsum += d;
                TBcreditsum.Text = csum.ToString();
                TBdebitsum.Text = dsum.ToString();
                TBdiff.Text = (dsum - csum).ToString();
                if (dsum - csum != 0)
                    TBdiff.ForeColor = Color.Red;
                else
                    TBdiff.ForeColor = Color.Black;

                bookbutton.Enabled = (dsum - csum == 0);
            }

        }

        private void checkdate(object sender, EventArgs e)
        {
            DateTime? verdate = util.parsedate(TBdate.Text);
            if (!util.infiscal(verdate))
            {
                TBdate.ForeColor = Color.Red;
            }
            else
                TBdate.ForeColor = Color.Black;


        }

        private void cancelbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bookbutton_Click(object sender, EventArgs e)
        {

            Ver vv = new Ver();
            var q = from c in Form1.db.Ver select c.Id;
            if (q.Count() == 0)
                vv.Id = 1;
            else
                vv.Id = q.Max() + 1;
            var qv = from c in Form1.db.Ver where c.Year == Form1.currentfiscal select c.Vernumber;
            if (qv.Count() == 0)
                vv.Vernumber = 1;
            else
                vv.Vernumber = qv.Max() + 1;
            vv.Description = TBdecription.Text;
            vv.Year = Form1.currentfiscal;
            vv.Creator = Form1.currentuser;
            vv.Creationdate = DateTime.Now;
            DateTime? verdate = util.parsedate(TBdate.Text);
            if (!util.infiscal(verdate))
            {
                TBdate.ForeColor = Color.Red;
                return;
            }
            vv.Verdate = (DateTime)verdate;

            int idrad = 1;
            var qr = from c in Form1.db.Rad select c.Id;
            if (qr.Count() > 0)
                idrad = qr.Max() + 1;
            int idkonto = 1;
            var qkk = from c in Form1.db.Konto select c.Id;
            if (qkk.Count() > 0)
                idkonto = qkk.Max() + 1;
            List<Rad> lrad = new List<Rad>();
            List<Konto> lkonto = new List<Konto>();


            decimal csum = 0;
            decimal dsum = 0;
            for (int i = 0; i < maxrow; i++)
            {
                if (!enabled[i])
                    continue;
                if (!kontoclass.validkonto(cbnumber[i].Text))
                    continue;


                decimal cred = util.tryconvertdecimal(cbcredit[i].Text);
                decimal deb = util.tryconvertdecimal(cbdebit[i].Text);
                if (cred == Decimal.MinValue)
                {
                    cbcredit[i].ForeColor = Color.Red;
                    bookbutton.Enabled = false;
                    return;
                }
                else
                    cbcredit[i].ForeColor = Color.Black;
                if (deb == Decimal.MinValue)
                {
                    cbdebit[i].ForeColor = Color.Red;
                    bookbutton.Enabled = false;
                    return;
                }
                else
                    cbdebit[i].ForeColor = Color.Black;
                csum += cred;
                dsum += deb;
                TBcreditsum.Text = csum.ToString();
                TBdebitsum.Text = dsum.ToString();
                TBdiff.Text = (dsum - csum).ToString();

                int kontonr = util.tryconvert(cbnumber[i].Text);
                Konto qk = (from cc in Form1.db.Konto 
                         where cc.Number == kontonr
                         where cc.Year == Form1.currentfiscal
                         select cc).FirstOrDefault();
                if (qk == null)
                {
                    qk = (from cc in lkonto 
                          where cc.Number == kontonr
                          where cc.Year == Form1.currentfiscal
                          select cc).FirstOrDefault();
                }
                if (qk == null)
                {
                    qk = new Konto();
                    qk.Id = idkonto;
                    idkonto++;
                    qk.Number = kontonr;
                    qk.Name = kontoclass.kontodict[kontonr];
                    qk.Year = Form1.currentfiscal;
                    qk.Kontotyp = 0;
                    qk.Kontogrupp = 0;
                    qk.Konto1 = kontonr / 1000;
                    qk.Konto2 = kontonr / 100;
                    qk.Konto3 = kontonr / 10;
                    qk.IB = 0;
                    qk.UB = 0;
                    qk.Creator = Form1.currentuser;
                    qk.Creationdate = DateTime.Now;
                    lkonto.Add(qk);
                    //Form1.db.Konto.InsertOnSubmit(qk);
                    //Form1.db.SubmitChanges();
                }
                Rad rr = new Rad();
                rr.Id = idrad;
                idrad++;
                rr.Ver = vv.Id;
                rr.Konto = qk.Id;
                rr.Amount = deb - cred;
                qk.UB += rr.Amount;

                //Form1.db.Rad.InsertOnSubmit(rr);
                lrad.Add(rr);
                //bookbutton.Enabled = (dsum - csum == 0);
            }

            if (dsum - csum != 0)
            {
                TBdiff.ForeColor = Color.Red;
                return;
            }
            else
                TBdiff.ForeColor = Color.Black;

            Form1.db.Ver.InsertOnSubmit(vv);
            Form1.db.SubmitChanges();

            Form1.db.Konto.InsertAllOnSubmit(lkonto);
            Form1.db.SubmitChanges();

            Form1.db.Rad.InsertAllOnSubmit(lrad);
            Form1.db.SubmitChanges();

        }
    }
}

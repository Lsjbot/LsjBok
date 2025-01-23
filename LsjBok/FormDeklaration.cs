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
using System.Text.RegularExpressions;

namespace LsjBok
{
    public partial class FormDeklaration : Form
    {
        int margin = 20;
        int tbwidth = 200;
        int labelwidth = 300;
        int columns = 3;
        int linespacing = 5;

        int[] colleft = new int[3] { 20, 540, 1060 };
        int[] colsection = new int[3] { 3,2, 4 };
        string[] colheader = new string[3] { "Resultaträkning", "Balansräkning", "Skattemässiga justeringar" };
        string[] colinstr = new string[3] { 
            "Direkt från bokföringen, ska normalt inte ändras", 
            "Direkt från bokföringen, ska normalt inte ändras", 
            "Behöver gås igenom manuellt, inte allt finns i bokföringen" };
        int[] colbottom = new int[3] { 20, 20, 20 };
        int[] colwidth = new int[3] { 400, 400, 700 };
        Dictionary<int, int> sectioncol = new Dictionary<int, int>();
        Dictionary<int, TextBox> tbdict = new Dictionary<int, TextBox>();

        public FormDeklaration()
        {
            InitializeComponent();
            int screenwidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenheight = Screen.PrimaryScreen.WorkingArea.Height;

            this.Top = 0;
            this.Left = 0;
            this.Width = screenwidth;
            this.Height = screenheight;

            int colsum = this.Width - (columns + 1) * margin;
            //int colwidth = colsum / columns;
            colwidth[0] = colsum / 4;
            colwidth[1] = colsum / 4;
            colwidth[2] = colsum / 2;
            //int tbwidth = 1 * colwidth / 5;
            //int labelwidth = 4 * colwidth / 5;

            colleft[0] = margin;
            colleft[1] = colleft[0] + colwidth[0] + margin;
            colleft[2] = colleft[1] + colwidth[1] + margin;

            Panel panelRRBR = new Panel();
            
            panelRRBR.Top = 0;
            panelRRBR.Left = 0;
            panelRRBR.Width = colleft[2];
            panelRRBR.Height = screenheight;
            panelRRBR.BackColor = Color.Lavender;

            this.Controls.Add(panelRRBR);

            Panel panelSkattejust = new Panel();

            panelSkattejust.Top = 0;
            panelSkattejust.Left = colleft[2];
            panelSkattejust.Width = colwidth[2];
            panelSkattejust.Height = screenheight;
            panelSkattejust.BackColor = Color.LightYellow;

            this.Controls.Add(panelSkattejust);


            for (int i=0;i<3;i++)
            {
                Label ll = new Label();
                ll.Top = margin;
                ll.Left = colleft[i];
                ll.Text = colheader[i];
                ll.Font = new Font(FontFamily.GenericSansSerif, 16);
                ll.AutoSize = true;
                colbottom[i] = margin + ll.Height + 2*linespacing;
                this.Controls.Add(ll);

                Label ll2 = new Label();
                ll2.Top = ll.Bottom+linespacing;
                ll2.Left = colleft[i];
                ll2.Text = colinstr[i];
                ll2.Font = new Font(FontFamily.GenericSansSerif, 12);
                ll2.AutoSize = true;
                colbottom[i] = colbottom[i] + ll2.Height + 2 * linespacing;
                this.Controls.Add(ll2);

                sectioncol.Add(colsection[i],i);
            }

            sruclass.fill_srulist();

            bool addpanel = true;
            foreach (sruclass sru in sruclass.srudict.Values)
            {
                decimal amount = sru.sumsru(common.currentfiscal);
                //0 = use original sign, >0 = always positive, <0 = reverse original sign
                if (sru.displaysign > 0)
                    amount = Math.Abs(amount);
                else if (sru.displaysign < 0)
                    amount = -amount;

                if (amount != 0 || sru.grupp == 4)
                {
                    int col = sectioncol[sru.grupp];
                    Label ll = new Label();
                    ll.Top = colbottom[col]+2;
                    ll.Left = colleft[col];
                    ll.Text = sru.Ink2rad + " " + sru.description;
                    ll.AutoSize = true;
                    this.Controls.Add(ll);

                    TextBox tb = new TextBox();
                    tb.TextAlign = HorizontalAlignment.Right;
                    tb.Top = colbottom[col];
                    tb.Left = colleft[col] + 4*colwidth[col]/5;
                    tb.Text = amount != 0 ? amount.ToString("N0") : "";
                    this.Controls.Add(tb);
                    tb.LostFocus += new EventHandler(sum_INK2S);
                    tbdict.Add(sru.fieldcode, tb);

                    if (addpanel)
                    {
                        Panel pp = new Panel();
                        pp.Top = tb.Top;
                        pp.Height = tb.Height;
                        pp.Left = ll.Right + 10;
                        pp.Width = tb.Left - pp.Left - 10;
                        pp.BackColor = Color.LightBlue;
                        this.Controls.Add(pp);
                        addpanel = false;
                    }
                    else
                        addpanel = true;

                    colbottom[col] += tb.Height + linespacing;
                }
            }

            Company cc = util.getcompany(common.currentcompany);

            string ziprex = @"\d\d\d ?\d\d";

            string zip = "";
            string city = "";
            string address = "";

            foreach (Match m in Regex.Matches(cc.Address,ziprex))
            {
                zip = m.Value.Replace(" ","");
                address = cc.Address.Replace(zip,"£").Replace("\n","");

                //StringSplitOptions opt = StringSplitOptions.None;
                city = address.Split('£').Last();
                address = address.Split('£').First();
            }

            TBaddress.Text = address.Trim();
            TBzip.Text = zip.Trim();
            TBcity.Text = city.Trim();

            panelRRBR.SendToBack();
            panelSkattejust.SendToBack();

        }

        private void sum_INK2S(object sender, EventArgs e)
        {
            decimal s4 = 0;
            var q = from c in sruclass.srudict.Keys
                    where c < 8000
                    where sruclass.srudict[c].grupp == 4
                    select c;

            foreach (int fc in q)
            {
                if (fc == 7670 || fc == 7770)
                    continue;
                //s4 += srudict[fc].sumsru_addsign(fiscalyear);
                decimal amount = util.tryconvertdecimal(tbdict[fc].Text);
                s4 += sruclass.signfix(amount,sruclass.srudict[fc].addsign);

            }

            tbdict[7670].Text = "";
            tbdict[7770].Text = "";
            int fcresult = 7670;
            if (s4 < 0)
                fcresult = 7770;
            tbdict[fcresult].Text = Math.Abs(s4).ToString("N0");
        }

        private string orgnr16(string orgnr)
        {
            return "16" + orgnr.Replace("-", "").Trim();
        }

        private string datetimestring = "";

        private void make_info_sru()
        {
            string fn = util.unused_filename(common.mainfolder + @"\INFO.SRU");
            using (
                var sw = new StreamWriter(
                    new FileStream(fn, FileMode.CreateNew, FileAccess.Write),
                    //Encoding.GetEncoding("iso-8859-1")
                    Encoding.GetEncoding(437)
                )
            )
            {
                sw.WriteLine("#DATABESKRIVNING_START");
                sw.WriteLine("#PRODUKT SRU");
                datetimestring = DateTime.Now.ToString("yyyyMMdd") + " " + DateTime.Now.ToString("hhmmss");
                sw.WriteLine("#SKAPAD "+datetimestring);
                sw.WriteLine("#PROGRAM LsjBok");
                sw.WriteLine("#FILNAMN BLANKETTER.SRU");
                sw.WriteLine("#DATABESKRIVNING_SLUT");
                sw.WriteLine("#MEDIELEV_START");

                Company cc = util.getcompany(common.currentcompany);

                sw.WriteLine("#ORGNR " + orgnr16(cc.Orgnr)); 
                sw.WriteLine("#NAMN "+cc.Name);
                //sw.WriteLine("#ADRESS "+TBaddress.Text);
                sw.WriteLine("#POSTNR "+TBzip.Text);
                sw.WriteLine("#POSTORT "+TBcity.Text);
                sw.WriteLine("#MEDIELEV_SLUT");
            }
            common.memo("INFO.SRU skriven till " + fn);
        }

        private void make_blanketter_sru()
        {
            string fn = util.unused_filename(common.mainfolder + @"\BLANKETTER.SRU");
            using (
                var sw = new StreamWriter(
                    new FileStream(fn, FileMode.CreateNew, FileAccess.Write),
                    //Encoding.GetEncoding("iso-8859-1")
                    Encoding.GetEncoding(437)
                )
            )
            {
                if (String.IsNullOrEmpty(datetimestring))
                    datetimestring = DateTime.Now.ToString("yyyyMMdd") + " " + DateTime.Now.ToString("hhmmss");

                Company cc = util.getcompany(common.currentcompany);
                Fiscalyear fy = fiscalclass.getfiscal(common.currentfiscal);

                sw.WriteLine("#BLANKETT INK2R-" + fiscalclass.getyear(common.currentfiscal) + "P4");
                sw.WriteLine("#IDENTITET " + orgnr16(cc.Orgnr) + " " + datetimestring);
                sw.WriteLine("#NAMN " + cc.Name);
                sw.WriteLine("#UPPGIFT 7011 " + fy.Startdate.ToString("yyyyMMdd"));
                sw.WriteLine("#UPPGIFT 7012 " + fy.Enddate.ToString("yyyyMMdd"));

                var qr = from c in sruclass.srudict.Values where (c.grupp == 2 || c.grupp == 3) select c;

                foreach (sruclass sr in qr)
                {
                    if (tbdict.ContainsKey(sr.fieldcode) && !String.IsNullOrEmpty(tbdict[sr.fieldcode].Text))
                    {
                        sw.WriteLine("#UPPGIFT " + sr.fieldcode + " " + tbdict[sr.fieldcode].Text.Replace(" ",""));
                    }
                }

                sw.WriteLine("#BLANKETTSLUT");


                sw.WriteLine("#BLANKETT INK2S-" + fiscalclass.getyear(common.currentfiscal) + "P4");
                sw.WriteLine("#IDENTITET " + orgnr16(cc.Orgnr) + " " + datetimestring);
                sw.WriteLine("#NAMN " + cc.Name);
                sw.WriteLine("#UPPGIFT 7011 " + fy.Startdate.ToString("yyyyMMdd"));
                sw.WriteLine("#UPPGIFT 7012 " + fy.Enddate.ToString("yyyyMMdd"));

                var qs = from c in sruclass.srudict.Values where c.grupp == 4  select c;

                foreach (sruclass sr in qs)
                {
                    if (tbdict.ContainsKey(sr.fieldcode) && !String.IsNullOrEmpty(tbdict[sr.fieldcode].Text))
                    {
                        sw.WriteLine("#UPPGIFT " + sr.fieldcode + " " + tbdict[sr.fieldcode].Text.Replace(" ", ""));
                    }
                }

                if (RByesaccountant.Checked)
                    sw.WriteLine("#UPPGIFT 8040 X");
                if (RBnoaccountant.Checked)
                    sw.WriteLine("#UPPGIFT 8041 X");
                if (RByesrevision.Checked)
                    sw.WriteLine("#UPPGIFT 8044 X");
                if (RBnorevision.Checked)
                    sw.WriteLine("#UPPGIFT 8045 X");

                sw.WriteLine("#BLANKETTSLUT");

                sw.WriteLine("#FIL_SLUT");
            }
            common.memo("BLANKETTER.SRU skriven till " + fn);
        }

        private void srubutton_Click(object sender, EventArgs e)
        {
            make_info_sru();
            make_blanketter_sru();
        }
    }
}

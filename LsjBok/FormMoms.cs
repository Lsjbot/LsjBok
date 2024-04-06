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
    public partial class FormMoms : Form
    {
        int localfiscal = common.currentfiscal;

        int xc1 = 150;
        int xc2 = 500;
        int ytop = 50;
        int pitch = 35;
        int labelwidth = 200;

        int[] col1 = new int[] { 5, 6, 7, 8, 20, 21, 22, 23, 24, 50, 35, 36, 37, 38, 39, 40, 41, 42 };
        int[] col2 = new int[] { 10, 11, 12, 0, 30, 31, 32, 0, 0, 60, 61, 62, 0, 48, 0, 49 };

        Dictionary<TextBox, int> tbrutdict = new Dictionary<TextBox, int>();
        Dictionary<int,TextBox> ruttbdict = new Dictionary<int,TextBox>();

        public FormMoms()
        {
            InitializeComponent();
            updatetitle();
            updatefiscal();
            updateperiods();
            momsrutaclass.fill_momsdict();

            for (int i=0;i<col1.Length;i++)
            {
                Label ll = new Label();
                ll.Text = momsrutaclass.momsdict[col1[i]].description + " "+col1[i];
                ll.TextAlign = ContentAlignment.MiddleRight;
                //ll.AutoSize = false;
                ll.Width = labelwidth;
                ll.Height = pitch - 5;
                ll.Font = new Font(ll.Font.Name,7,ll.Font.Style);
                ll.Location = new Point(xc1,ytop+pitch*i);
                this.Controls.Add(ll);
                TextBox tb = new TextBox();
                tb.Location = new Point(xc1 + labelwidth + 10, ytop + pitch * i);
                tb.Width = xc2 - tb.Location.X - 10;
                tb.TextAlign = HorizontalAlignment.Right;
                this.Controls.Add(tb);
                tbrutdict.Add(tb, col1[i]);
                ruttbdict.Add(col1[i], tb);
            }

            for (int i = 0; i < col2.Length; i++)
            {
                if (col2[i] == 0)
                    continue;
                Label ll = new Label();
                ll.Text = momsrutaclass.momsdict[col2[i]].description + " " + col2[i];
                ll.TextAlign = ContentAlignment.MiddleRight;
                //ll.AutoSize = false;
                ll.Width = labelwidth;
                ll.Height = pitch - 5;
                ll.Font = new Font(ll.Font.Name, 7, ll.Font.Style);
                ll.Location = new Point(xc2, ytop + pitch * i);
                this.Controls.Add(ll);
                TextBox tb = new TextBox();
                tb.Location = new Point(xc2 + labelwidth + 10, ytop + pitch * i);
                tb.TextAlign = HorizontalAlignment.Right;
                tb.Width = 150;
                this.Controls.Add(tb);
                tbrutdict.Add(tb, col2[i]);
                ruttbdict.Add(col2[i], tb);
            }
        }

        public void updatetitle()
        {
            this.Text = "LsjBok momsdeklaration - " + util.getusername() + " - " + util.getcompanyname() + " - " + util.getfiscalname();
            updatefiscal();
        }

        public void updatefiscal()
        {
            LBfiscal.Items.Clear();
            var q = from c in common.db.Fiscalyear where c.Company == common.currentcompany select c;
            foreach (var ff in q)
            {
                LBfiscal.Items.Add(ff.Name);
            }
        }

        public void updateperiods()
        {
            LBperiod.Items.Clear();
            var q = from c in common.db.Momsperiod where c.Fiscal == localfiscal select c;
            if (q.Count() == 0)
                makeperiodbutton.Enabled = true;
            else
            {
                makeperiodbutton.Enabled = false;
                foreach (var ff in q)
                {
                    LBperiod.Items.Add(ff.Name);
                }
            }
        }

        private void LBfiscal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LBfiscal.SelectedItem == null)
                return;
            var q = from c in common.db.Fiscalyear
                    where c.Name == LBfiscal.SelectedItem.ToString()
                    where c.Company == common.currentcompany select c;
            if (q.Count() == 0)
                return;
            localfiscal = q.First().Id;
            updateperiods();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Skapa momsperioder
            var q = from c in common.db.Fiscalyear
                    where c.Id == localfiscal
                    select c;
            if (q.Count() == 0)
                return;
            FormFiscalyear.make_momsperiods(q.First());
            updateperiods();
        }

        private void LBperiod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LBperiod.SelectedItem == null)
                return;
            var q = from c in common.db.Momsperiod
                    where c.Name == LBperiod.SelectedItem.ToString()
                    where c.Fiscal == localfiscal
                    select c;
            if (q.Count() == 0)
                return;
            updateamounts(q.First());
        }

        private void updateamounts(Momsperiod mp)
        {
            foreach (momsrutaclass mc in momsrutaclass.momsdict.Values)
            {
                decimal amount = mc.summoms(localfiscal, mp.Startdate, mp.Enddate);
                if (amount != 0)
                {
                    ruttbdict[mc.ruta].Text = amount.ToString("N2");
                }
                else
                {
                    ruttbdict[mc.ruta].Text = "";
                }
            }
        }

        private void momsxmlbutton_Click(object sender, EventArgs e)
        {
            if (LBperiod.SelectedItem == null)
                return;
            var q = from c in common.db.Momsperiod
                    where c.Name == LBperiod.SelectedItem.ToString()
                    where c.Fiscal == localfiscal
                    select c;
            if (q.Count() == 0)
                return;
            Momsperiod mp = q.First();
            string orgnr = util.getcompany(common.currentcompany).Orgnr.Trim();
            string fn = util.unused_filename(common.mainfolder + "\\moms_" + orgnr + "_" + mp.Startdate.ToString("yyMMdd") + "_" + mp.Enddate.ToString("yyMMdd")+"_.txt");
            using (StreamWriter sw = new StreamWriter(fn))
            {
                sw.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                sw.WriteLine("<!DOCTYPE eSKDUpload PUBLIC \"-//Skatteverket, Sweden//DTD Skatteverket eSKDUpload-DTD Version 6.0//SV\" \"https://www.skatteverket.se/download/18.3f4496fd14864cc5ac99cb1/1415022101213/eSKDUpload_6p0.dtd\">");
                sw.WriteLine("<eSKDUpload Version=\"6.0\">");
                sw.WriteLine("  <OrgNr>"+orgnr+"</OrgNr>");
                sw.WriteLine("  <Moms>");
                sw.WriteLine("    <Period>"+mp.Name+"</Period>");
                
                foreach (int ruta in ruttbdict.Keys)
                {
                    string tag = momsrutaclass.momsdict[ruta].xmltag;
                    decimal amount = util.tryconvertdecimal(ruttbdict[ruta].Text);
                    if (amount != 0 || ruta == 5 || ruta == 49)
                        sw.WriteLine("    <" + tag + ">" + amount.ToString("F0") + "</" + tag + ">");
                }
                sw.WriteLine("  </Moms>");
                sw.WriteLine("</eSKDUpload>");
            }
            MessageBox.Show("Momsdeklaration skapad: " + fn);
        }
    }
}

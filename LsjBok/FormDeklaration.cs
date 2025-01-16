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

                if (amount != 0 || sru.group == 4)
                {
                    int col = sectioncol[sru.group];
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
        }
    }
}

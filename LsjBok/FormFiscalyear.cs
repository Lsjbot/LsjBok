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
    public partial class FormFiscalyear : Form
    {
        public static Fiscalyear find_latest(int company)
        {
            var q = from c in Form1.db.Fiscalyear where c.Company == company select c;
            if (q.Count() > 0)
            {
                int year = -1;
                Fiscalyear latest = null;
                foreach (var c in q)
                {
                    if (c.Startdate.Year > year)
                    {
                        year = c.Startdate.Year;
                        latest = c;
                    }
                }
                return latest;
            }
            return null;
        }
        public FormFiscalyear()
        {
            InitializeComponent();
            this.Text = "Skapa räkenskapsår för " + util.getcompanyname();
            var latest = find_latest(Form1.currentcompany);
            
            if (latest != null)
            {
                TBstart.Text = latest.Startdate.AddYears(1).ToString("yyMMdd");
                TBslut.Text = latest.Enddate.AddYears(1).ToString("yyMMdd");
            }
            else
            {
                TBstart.Text = (DateTime.Now.Year - 2000).ToString() + "0101";
                TBslut.Text  = (DateTime.Now.Year - 2000).ToString() + "1231";
            }
        }

        private void cancelbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void createbutton_Click(object sender, EventArgs e)
        {
            DateTime? startparse = util.parsedate(TBstart.Text);
            DateTime? slutparse = util.parsedate(TBslut.Text);
            bool okdates = true;
            if (startparse == null)
            {
                TBstart.ForeColor = Color.Red;
                okdates = false;
            }
            if (slutparse == null)
            {
                TBslut.ForeColor = Color.Red;
                okdates = false; ;
            }
            if (okdates)
            {
                DateTime start = (DateTime)startparse;
                DateTime slut = (DateTime)slutparse;
                if (slut <= start)
                    okdates = false;

                if (!okdates)
                {
                    MessageBox.Show("Ogiltiga datum", "LsjBok", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    Fiscalyear fy = new Fiscalyear();
                    fy.Id = Form1.db.Fiscalyear.Count() + 1;
                    fy.Name = start.Year.ToString();
                    if (slut.Year != start.Year)
                        fy.Name += "-" + slut.Year;
                    fy.Company = Form1.currentcompany;
                    fy.Startdate = start;
                    fy.Enddate = slut;
                    fy.Closed = false;
                    fy.Creator = Form1.currentuser;
                    fy.Creationdate = DateTime.Now;
                    Form1.db.Fiscalyear.InsertOnSubmit(fy);
                    Form1.db.SubmitChanges();
                    Form1.currentfiscal = fy.Id;

                    //Skapa momsperioder:

                    make_momsperiods(fy);
                    this.Close();
                }
            }
        }

        public static void make_momsperiods(Fiscalyear fy)
        {
            int mm = fy.CompanyCompany.Momsfreq;
            int id = 1;
            if (Form1.db.Momsperiod.Count() > 0)
                id = (from c in Form1.db.Momsperiod select c.Id).Max() + 1;
            DateTime st = fy.Startdate;
            while (st < fy.Enddate)
            {
                DateTime sl = st.AddMonths(mm).AddDays(-1);
                Momsperiod mp = new Momsperiod();
                mp.Id = id;
                mp.Startdate = st;
                mp.Enddate = sl;
                mp.Name = sl.Year.ToString() + sl.Month.ToString("D2");
                //mp.Company = Form1.currentcompany;
                mp.Fiscal = fy.Id;
                mp.Closed = false;
                mp.Net = 0;
                mp.Creator = Form1.currentuser;
                mp.Creationdate = DateTime.Now;
                Form1.db.Momsperiod.InsertOnSubmit(mp);
                st = st.AddMonths(mm);
                id++;
            }
            Form1.db.SubmitChanges();

        }

    }
}

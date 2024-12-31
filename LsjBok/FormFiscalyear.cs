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
        public FormFiscalyear()
        {
            InitializeComponent();
            this.Text = "Skapa räkenskapsår för " + util.getcompanyname();
            var latest = fiscalclass.find_latest(common.currentcompany);
            
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
            DateTime start = DateTime.Now; //dummy assignment because DateTime is not nullable
            DateTime slut = start;
            if (okdates)
            {
                start = (DateTime)startparse;
                slut = (DateTime)slutparse;
                if (slut <= start)
                    okdates = false;
            }

            if (!okdates)
            {
                MessageBox.Show("Ogiltiga datum", "LsjBok", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                Fiscalyear fy = new Fiscalyear();
                fy.Id = common.db.Fiscalyear.Count() + 1;
                fy.Name = start.Year.ToString();
                if (slut.Year != start.Year)
                    fy.Name += "-" + slut.Year;
                fy.Company = common.currentcompany;
                fy.Startdate = start;
                fy.Enddate = slut;
                fy.Closed = false;
                fy.Creator = common.currentuser;
                fy.Creationdate = DateTime.Now;
                common.db.Fiscalyear.InsertOnSubmit(fy);
                common.db.SubmitChanges();
                util.logentry("Skapar räkenskapsår " + fy.Name, fy.Id);

                common.currentfiscal = fy.Id;

                fiscalclass.update_IB(fy);

                string cin = fiscalclass.consistent_in(fy);
                if (!String.IsNullOrEmpty(cin))
                    MessageBox.Show(cin);

                //Skapa momsperioder:

                make_momsperiods(fy);
                this.Close();
            }

        }

        public static void make_momsperiods(Fiscalyear fy)
        {
            int mm = fy.CompanyCompany.Momsfreq;
            int id = 1;
            if (common.db.Momsperiod.Count() > 0)
                id = (from c in common.db.Momsperiod select c.Id).Max() + 1;
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
                mp.Creator = common.currentuser;
                mp.Creationdate = DateTime.Now;
                common.db.Momsperiod.InsertOnSubmit(mp);
                st = st.AddMonths(mm);
                id++;
            }
            common.db.SubmitChanges();

        }


    }
}

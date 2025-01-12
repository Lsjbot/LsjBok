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
    public partial class FormLog : Form
    {
        public static string logimportexport = "Import/export";
        public static string logskapande = "Skapande";
        public static string logfiscalyear = "Räkenskapsår";
        public static string logmoms = "Moms";

        public static Dictionary<string, int> logdict = new Dictionary<string, int>()
        {
            {logimportexport,-1 },
            {logskapande, -2},
            {logfiscalyear, -3},
            {logmoms, -4},
            //{"", },
            //{"", },
            //{"", },
            //{"", },
        };

        public FormLog()
        {
            InitializeComponent();

            dgLogtable.DataSource = logdata;
            //dgLogtable.Columns.Add(new DataGridViewColumn());
            //dgLogtable.Columns.Add(new DataGridViewColumn());
            //dgLogtable.Columns.Add(new DataGridViewColumn());
            //dgLogtable.Columns.Add(new DataGridViewColumn());
            //dgLogtable.Columns.Add(new DataGridViewColumn());
            foreach (Loglist ll in common.db.Loglist)
            {
                //logdata.Add(new loggrad(ll));
                logdata.Add(ll);
            }
            dgLogtable.Columns[0].HeaderText = "Id";
            dgLogtable.Columns[1].HeaderText = "Beskrivning";
            dgLogtable.Columns[2].HeaderText = "Händelsetyp";
            dgLogtable.Columns[3].HeaderText = "Skapare";
            dgLogtable.Columns[4].HeaderText = "Datum";
        }

        BindingList<Loglist> logdata = new BindingList<Loglist>();
        //BindingList<loggrad> logdata = new BindingList<loggrad>();

        public class loggrad
        {
            public int Id;
            public string Beskrivning;
            public string Händelse;
            public string Skapare;
            public DateTime Datum;

            public loggrad(Loglist ll)
            {
                this.Id = ll.Id;
                this.Beskrivning = ll.Description;
                if (ll.Event > 0)
                    this.Händelse = "Ver. " + ll.Event;
                else
                {
                    var q = from c in logdict where c.Value == ll.Event select c;
                    if (q.Count() != 1)
                        this.Händelse = "Okänd händelsetyp";
                    else
                        this.Händelse = q.First().Key;
                }
                this.Skapare = util.getusername(ll.Creator);
                this.Datum = ll.Creationdate;
            }
        }
    }
}

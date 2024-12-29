using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LsjBok
{
    public class kontogruppclass
    {
        public string description = "";
        public string konto1string = "";
        public string konto2string = "";
        public string konto3string = "";
        public string konto4string = "";
        public List<int> konto1list = new List<int>();
        public List<int> konto2list = new List<int>();
        public List<int> konto3list = new List<int>();
        public List<int> konto4list = new List<int>();


        public List<Konto> getkonto(int fiscalyear)
        {
            var q = from c in common.db.Konto where c.Year == fiscalyear select c;
            var qq = from c in q.ToList()
                     where
                     (konto1list.Contains(c.Konto1)
                     || konto2list.Contains(c.Konto2)
                     || konto3list.Contains(c.Konto3)
                     || konto4list.Contains(c.Number))
                     select c;
            return qq.ToList();
        }
        public decimal sumkonto_IB(int fiscalyear)
        {
            decimal sum = 0;
            foreach (Konto kk in getkonto(fiscalyear))
                sum += kk.IB;
            return sum;
        }

        public decimal sumkonto(int fiscalyear)
        {
            decimal sum = 0;
            foreach (Konto kk in getkonto(fiscalyear))
                sum += kk.UB;
            return sum;
        }

        public decimal sumkonto_transactions(int fiscalyear, DateTime start, DateTime end)
        {
            decimal sum = 0;
            //decimal IBsum = 0;
            foreach (Konto kk in getkonto(fiscalyear))
            {
                sum += kontoclass.sumperiod(kk,start, end);
                //IBsum += kk.IB;
                //sum += kk.UB;
            }
            return sum;

        }

        public decimal sumkonto_IB(int fiscalyear, DateTime start)
        {
            decimal sum = 0;
            decimal IBsum = 0;
            foreach (Konto kk in getkonto(fiscalyear))
            {
                IBsum += kk.IB;
                foreach (Rad rr in kk.Rad)
                {
                    if (rr.VerVer.Verdate < start)
                        IBsum += rr.Amount;
                    //else if (rr.VerVer.Verdate > end)
                    //    continue;
                    //else
                    //    sum += rr.Amount;
                }
                //sum += kk.UB;
            }
            return IBsum;
        }

        public decimal sumkonto_UB(int fiscalyear, DateTime end)
        {
            decimal sum = 0;
            decimal UBsum = 0;
            foreach (Konto kk in getkonto(fiscalyear))
            {
                UBsum += kk.IB;
                foreach (Rad rr in kk.Rad)
                {
                    if (rr.VerVer.Verdate < end)
                        UBsum += rr.Amount;
                    //else if (rr.VerVer.Verdate > end)
                    //    continue;
                    //else
                    //    sum += rr.Amount;
                }
                //sum += kk.UB;
            }
            return UBsum;
        }
        public void stringtolists()
        {
            if (!String.IsNullOrEmpty(konto1string))
            {
                foreach (string s in konto1string.Split(','))
                {
                    konto1list.Add(util.tryconvert(s));
                }
            }
            if (!String.IsNullOrEmpty(konto2string))
            {
                foreach (string s in konto2string.Split(','))
                {
                    konto2list.Add(util.tryconvert(s));
                }
            }
            if (!String.IsNullOrEmpty(konto3string))
            {
                foreach (string s in konto3string.Split(','))
                {
                    konto3list.Add(util.tryconvert(s));
                }
            }
            if (!String.IsNullOrEmpty(konto4string))
            {
                foreach (string s in konto4string.Split(','))
                {
                    konto4list.Add(util.tryconvert(s));
                }
            }

        }

    }
}

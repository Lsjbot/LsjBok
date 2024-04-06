using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LsjBok
{
    class fiscalclass
    {
        public static Fiscalyear getfiscal(int id)
        {
            return (from c in common.db.Fiscalyear where c.Id == id select c).FirstOrDefault();
        }
        public static bool infiscal(DateTime? date)
        {
            if (date == null)
                return false;
            else
                return infiscal((DateTime)date);
        }
        public static bool infiscal(DateTime date)
        {
            return infiscal(date, common.currentfiscal);
        }

        public static bool infiscal(DateTime? date, int fiscal)
        {
            Fiscalyear fy = (from c in common.db.Fiscalyear where c.Id == fiscal select c).FirstOrDefault();
            return infiscal(date, fy);
        }

        public static bool infiscal(DateTime? date, Fiscalyear fy)
        {
            if (fy == null)
                return false;
            if (date < fy.Startdate)
                return false;
            if (date > fy.Enddate)
                return false;
            return true;
        }

        public static Fiscalyear find_latest(int company)
        {
            var q = from c in common.db.Fiscalyear where c.Company == company select c;
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

        public static Fiscalyear find_ongoing(int company)
        {
            var q = from c in common.db.Fiscalyear where c.Company == company select c;
            if (q.Count() > 0)
            {
                foreach (var c in q)
                {
                    if (c.Startdate < DateTime.Now && c.Enddate > DateTime.Now)
                    {
                        return c;
                    }
                }
            }
            return null;
        }

        public static TimeSpan oneday = new TimeSpan(24, 0, 0);

        public static Fiscalyear previousfiscal(Fiscalyear old)
        {
            var q = from c in common.db.Fiscalyear where c.Company == old.Company select c;
            if (q.Count() > 0)
            {
                foreach (Fiscalyear fy in q)
                {
                    if (old.Startdate - fy.Enddate == oneday)
                        return fy;
                }
            }
            return null;
        }

        public static Fiscalyear nextfiscal(Fiscalyear old)
        {
            var q = from c in common.db.Fiscalyear where c.Company == old.Company select c;
            if (q.Count() > 0)
            {
                foreach (Fiscalyear fy in q)
                {
                    if (fy.Startdate - old.Enddate == oneday)
                        return fy;
                }
            }
            return null;
        }

        public static bool hascontent()
        {
            return hascontent(common.currentfiscal);
        }

        public static bool hascontent(int fid)
        {
            Fiscalyear fy = (from c in common.db.Fiscalyear where c.Id == fid select c).FirstOrDefault();
            if (fy == null)
                return false;
            return hascontent(fy);
        }

        public static bool hascontent(Fiscalyear fy)
        {
            var q = from c in common.db.Ver where c.Year == fy.Id select c;
            if (q.Count() > 0)
                return true;
            var qk = from c in common.db.Konto where c.Year == fy.Id select c;
            foreach (Konto kk in qk)
            {
                if (kk.IB != 0)
                    return true;
                if (kk.UB != 0)
                    return true;
            }
            return false;
        }

        public static decimal ibsum(Fiscalyear fy)
        {
            decimal sum = 0;
            var qk = from c in common.db.Konto where c.Year == fy.Id select c;
            foreach (Konto kk in qk)
            {
                sum += kk.IB;
            }
            return sum;

        }
        public static decimal ubsum(Fiscalyear fy)
        {
            decimal sum = 0;
            var qk = from c in common.db.Konto where c.Year == fy.Id select c;
            foreach (Konto kk in qk)
            {
                sum += kk.UB;
            }
            return sum;
        }

        public static string consistent_in(Fiscalyear fy)
        {
            StringBuilder sb = new StringBuilder("");
            rrbrclass tillgang = rrbrclass.get_assets();// (from c in rrbrclass.brlist where c.field == "Tillgångar" select c).First();
            rrbrclass skuld = rrbrclass.get_debts();// (from c in rrbrclass.brlist where c.field == "Eget kapital och skulder" select c).First();

            decimal ts = tillgang.sumamount_IB(fy.Id) - skuld.sumamount_IB(fy.Id);

            if (ts != 0)
                sb.Append("IB balanserar ej. Diff = "+ts.ToString("N2")+"\n");

            Fiscalyear prevfy = fiscalclass.previousfiscal(fy);
            if (prevfy == null)
                return "";
            if (!fiscalclass.hascontent(prevfy))
                return "";

            var qbk = from c in common.db.Konto
                      where c.Year == fy.Id
                      where c.Konto1 < 3
                      select c;
            var qbkprev = from c in common.db.Konto
                      where c.Year == prevfy.Id
                      where c.Konto1 < 3
                      select c;

            foreach (Konto kk in qbk)
            {
                var qk2 = from c in qbkprev where c.Number == kk.Number select c;
                if (qk2.Count() == 0)
                {
                    if (kk.IB != 0)
                        sb.Append("Konto " + kk.Number + "saknas för år " + prevfy.Name + "\n");
                }
                else if (qk2.First().UB != kk.IB)
                {
                    sb.Append("Konto " + kk.Number + ": UB (" + prevfy.Name + ") != IB(" + fy.Name + ") Diff = "+(kk.IB-qk2.First().UB).ToString("N2")+"\n");
                }
            }

            foreach (Konto kkp in qbkprev)
            {
                var qk2 = from c in qbk where c.Number == kkp.Number select c;
                if ((qk2.Count() == 0) && (kkp.UB != 0))
                {
                    sb.Append("Konto " + kkp.Number + "saknas för år " + fy.Name+"\n");
                }
            }

            return sb.ToString();
        }

        public static string consistent_out(Fiscalyear fy)
        {
            Fiscalyear nextfy = fiscalclass.nextfiscal(fy);
            if (nextfy == null)
                return "";
            if (!fiscalclass.hascontent(nextfy))
                return "";

            return consistent_in(nextfy);
        }

        public static void update_IB(Fiscalyear fy)
        {
            Fiscalyear prevfy = fiscalclass.previousfiscal(fy);
            if (prevfy == null)
                return;
            if (!fiscalclass.hascontent(prevfy))
                return;

            var qbk = from c in common.db.Konto
                      where c.Year == fy.Id
                      where c.Konto1 < 3
                      select c;
            var qbkprev = from c in common.db.Konto
                          where c.Year == prevfy.Id
                          where c.Konto1 < 3
                          select c;

            foreach (Konto kk in qbk)
            {
                var qk2 = from c in qbkprev where c.Number == kk.Number select c;
                if (qk2.Count() != 0)
                {
                    var kk2 = qk2.First();
                    if (kk2.UB != kk.IB)
                    {
                        decimal oldib = kk.IB;
                        kk.IB = kk2.UB;
                        kk.UB -= oldib;
                        kk.UB += kk.IB;
                    }
                }
                else
                {
                    kk.UB -= kk.IB;
                    kk.IB = 0;
                }
            }

            int kkid = 1;
            var qkid = from c in common.db.Konto select c.Id;
            if (qkid.Count() > 0)
                kkid = qkid.Max() + 1;
            foreach (Konto kkp in qbkprev)
            {
                var qk2 = from c in qbk where c.Number == kkp.Number select c;
                if ((qk2.Count() == 0) && (kkp.UB != 0))
                {
                    Konto kk = new Konto();
                    kk.Id = kkid;
                    kkid++;
                    kk.Year = fy.Id;
                    kk.Creationdate = DateTime.Now;
                    kk.Creator = common.currentuser;
                    kk.Name = kkp.Name;
                    kk.Number = kkp.Number;
                    kk.Kontotyp = kkp.Kontotyp;
                    kk.Konto1 = kkp.Konto1;
                    kk.Konto2 = kkp.Konto2;
                    kk.Konto3 = kkp.Konto3;
                    kk.IB = kkp.UB;
                    kk.UB = kk.IB;
                }
            }

        }
    }
}

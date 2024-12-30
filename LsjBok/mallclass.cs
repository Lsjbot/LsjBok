using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LsjBok
{
    class mallclass
    {
        public static void standardmallar_to_db()
        {
            Dictionary<int, Dictionary<int, decimal>> malldict = new Dictionary<int, Dictionary<int, decimal>>();
            Dictionary<int, string> mallnamedict = new Dictionary<int, string>();
            malldict.Add(1, new Dictionary<int, decimal>()); mallnamedict.Add(1, "Försäljning tjänst 25% moms");
            malldict[1].Add(1930, 100);
            malldict[1].Add(2610, -20);
            malldict[1].Add(3011, -80);
            malldict.Add(2, new Dictionary<int, decimal>()); mallnamedict.Add(2, "Vinstdisposition");
            malldict[2].Add(2098, 100);
            malldict[2].Add(2091, -50);
            malldict[2].Add(2898, -50);
            malldict.Add(3, new Dictionary<int, decimal>()); mallnamedict.Add(3, "Utdelning utbetalning");
            malldict[3].Add(1930, -50);
            malldict[3].Add(2898, 50);
            malldict.Add(4, new Dictionary<int, decimal>()); mallnamedict.Add(4, "Banktjänster");
            malldict[4].Add(1930, -100);
            malldict[4].Add(6570, 100);
            malldict.Add(5, new Dictionary<int, decimal>()); mallnamedict.Add(5, "Årets resultat");
            malldict[5].Add(2099, -100);
            malldict[5].Add(8999, 100);
            malldict.Add(6, new Dictionary<int, decimal>()); mallnamedict.Add(6, "Beräknad inkomstskatt");
            malldict[6].Add(2512, -100);
            malldict[6].Add(8910, 100);
            malldict.Add(7, new Dictionary<int, decimal>()); mallnamedict.Add(7, "Omföring vinst");
            malldict[7].Add(2099, 100);
            malldict[7].Add(2098, -100);
            malldict.Add(8, new Dictionary<int, decimal>()); mallnamedict.Add(8, "Aktieutdelning");
            malldict[8].Add(1930, -100);
            malldict[8].Add(2898, 100);
            malldict.Add(9, new Dictionary<int, decimal>()); mallnamedict.Add(9, "Inköp förbrukningsmtrl");
            malldict[9].Add(1930, -100);
            malldict[9].Add(2640, 20);
            malldict[9].Add(5410, 80);
            malldict.Add(10, new Dictionary<int, decimal>()); mallnamedict.Add(10, "Inköp böcker");
            malldict[10].Add(1930, -106);
            malldict[10].Add(2640, 6);
            malldict[10].Add(6970, 100);
            malldict.Add(11, new Dictionary<int, decimal>()); mallnamedict.Add(11, "Löneutbetalning");
            malldict[11].Add(1930, -80);
            malldict[11].Add(2710, -20);
            malldict[11].Add(2731, -30);
            malldict[11].Add(7210, 100);
            malldict[11].Add(7510, 30);
            malldict.Add(12, new Dictionary<int, decimal>()); mallnamedict.Add(12, "Arbetsgivaravgifter och skatt");
            malldict[12].Add(1930, -50);
            malldict[12].Add(1630, 50);
            malldict[12].Add(2710, 20);
            malldict[12].Add(2731, 30);
            malldict[12].Add(16300, -50);
            malldict.Add(13, new Dictionary<int, decimal>()); mallnamedict.Add(13, "Preliminärskatt");
            malldict[13].Add(1930, -100);
            malldict[13].Add(1630, 100);
            malldict[13].Add(2510, 100);
            malldict[13].Add(16300, -100);
            malldict.Add(14, new Dictionary<int, decimal>()); mallnamedict.Add(14, "Royalty Sverige");
            malldict[14].Add(1930, 106);
            malldict[14].Add(2630, 6);
            malldict[14].Add(3920, 100);

            var q = from c in common.db.Mall select c;
            if (q.Count() > 0)
                return;

            foreach (int mi in malldict.Keys)
            {
                Mall mm = new Mall();
                mm.Id = mi;
                mm.Description = mallnamedict[mi];
                mm.Creator = common.currentuser;
                mm.Creationdate = DateTime.Now;
                common.db.Mall.InsertOnSubmit(mm);
            }
            common.db.SubmitChanges();
            int mrid = 1;
            foreach (int mi in malldict.Keys)
            {
                foreach (int k in malldict[mi].Keys)
                {
                    Mallrad mr = new Mallrad();
                    mr.Id = mrid;
                    mrid++;
                    mr.Mall = mi;
                    int kk = k;
                    if (k > 9999)
                        kk /= 10;
                    mr.Kontonr = kk;
                    mr.Amount = malldict[mi][k];
                    common.db.Mallrad.InsertOnSubmit(mr);
                }
            }
            common.db.SubmitChanges();
        }
    }
}

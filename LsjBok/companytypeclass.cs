using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LsjBok
{
    class companytypeclass
    {
        public static Dictionary<string, string> ctdict = new Dictionary<string, string>();
        public static Dictionary<string, int> ctiddict = new Dictionary<string, int>();
        public static Dictionary<int, string> idctdict = new Dictionary<int, string>();

        public static void fill_companytype()
        {

            if (common.db.Companytype.Count() == 0)
            {
                if (ctdict.Count == 0)
                {
                    ctdict.Add("AB", "Aktiebolag");
                    ctdict.Add("E", "Enskild näringsidkare");
                    ctdict.Add("HB", "Handelsbolag");
                    ctdict.Add("KB", "Kommanditbolag");
                    ctdict.Add("EK", "Ekonomisk förening");
                    ctdict.Add("KHF", "Kooperativ hyresrättsförening");
                    ctdict.Add("BRF", "Bostadsrättsförening");
                    ctdict.Add("BF", "Bostadsförening");
                    ctdict.Add("SF", "Sambruksförening");
                    ctdict.Add("I", "Ideell förening som bedriver näring");
                    ctdict.Add("S", "Stiftelse som bedriver näring");
                    ctdict.Add("FL", "Filial till utländskt bolag");
                    ctdict.Add("BAB", "Bankaktiebolag");
                    ctdict.Add("MB", "Medlemsbank");
                    ctdict.Add("SB", "Sparbank");
                    ctdict.Add("BFL", "Utländsk banks filial");
                    ctdict.Add("FAB", "Försäkringsaktiebolag");
                    ctdict.Add("OFB", "Ömsesidigt försäkringsbolag");
                    ctdict.Add("SE", "Europabolag");
                    ctdict.Add("SCE", "Europakooperativ");
                    ctdict.Add("TSF", "Trossamfund");
                    ctdict.Add("X", "Annan företagsform");
                }
                int id = 0;
                foreach (string sn in ctdict.Keys)
                {
                    Companytype ct = new Companytype();
                    id++;
                    ct.Id = id;
                    ct.Shortname = sn;
                    ct.Name = ctdict[sn];
                    common.db.Companytype.InsertOnSubmit(ct);
                    ctiddict.Add(sn, id);
                    ctiddict.Add(ctdict[sn], id);
                    idctdict.Add(id, sn);
                }
                common.db.SubmitChanges();
            }
            else
            {
                foreach (Companytype ct in common.db.Companytype)
                {
                    ctdict.Add(ct.Shortname, ct.Name);
                    ctiddict.Add(ct.Shortname, ct.Id);
                    ctiddict.Add(ct.Name, ct.Id);
                    idctdict.Add(ct.Id, ct.Shortname);
                }
            }
        }

    }
}

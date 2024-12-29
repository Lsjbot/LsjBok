using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LsjBok
{
    public class momsrutaclass:kontogruppclass
    {
        public static Dictionary<int, momsrutaclass> momsdict = new Dictionary<int, momsrutaclass>();

        public static List<int> momskontorutor = new List<int>() { 10, 11, 12, 30, 31, 32, 60, 61, 62, 48 };

        public string xmltag = "";
        public int ruta = -1;
        public decimal amount;

        public momsrutaclass(int rutnr,string desc, string tag, string k1, string k2, string k3, string k4)
        {
            ruta = rutnr;
            description = desc;
            xmltag = tag;
            konto1string = k1;
            konto2string = k2;
            konto3string = k3;
            konto4string = k4;
            stringtolists();
        }

        internal static void fill_momsdict()
        {
            if (momsdict.Count > 0)
                return;

            momsdict.Add(5, new momsrutaclass(5, "Momspliktig försäljning som inte ingår i ruta 06, 07 eller 08", "ForsMomsEjAnnan", "3", "", "", ""));
            momsdict.Add(6, new momsrutaclass(6, "Momspliktiga uttag", "UttagMoms", "", "", "", "3401"));
            momsdict.Add(7, new momsrutaclass(7, "Beskattningsunderlag vid vinstmarginalbeskattning", "UlagMargbesk", "", "", "", "3211,3212,3220,4211,4212,4220"));
            momsdict.Add(8, new momsrutaclass(8, "Hyresinkomster vid frivillig skattskyldighet", "HyrinkomstFriv", "", "", "", "3913"));
            momsdict.Add(20, new momsrutaclass(20, "Inköp av varor från ett annat EU-land", "InkopVaruAnnatEg", "", "", "", "4515,4516,4517"));
            momsdict.Add(21, new momsrutaclass(21, "Inköp av tjänster från ett annat EU-land enligt huvudregeln", "InkopTjanstAnnatEg", "", "", "", "4535,4536,4537"));
            momsdict.Add(22, new momsrutaclass(22, "Inköp av tjänster från ett land utanför EU", "InkopTjanstUtomEg", "", "", "", "4531,4532,4533"));
            momsdict.Add(23, new momsrutaclass(23, "Inköp av varor i Sverige som köparen är skattskyldig för", "InkopVaruSverige", "", "", "", "4415,4416,4417"));
            momsdict.Add(24, new momsrutaclass(24, "Övriga inköp av tjänster i Sverige som köparen är skattskyldig för", "InkopTjanstSverige", "", "", "", "4425,4426,4427"));
            momsdict.Add(50, new momsrutaclass(50, "Beskattningsunderlag vid import", "MomsUlagImport", "", "", "", "4545,4546,4547"));
            momsdict.Add(35, new momsrutaclass(35, "Försäljning av varor till ett annat EU-land", "ForsVaruAnnatEg", "", "", "", "3106"));
            momsdict.Add(36, new momsrutaclass(36, "Försäljning av varor utanför EU", "ForsVaruUtomEg", "", "", "", "3105"));
            momsdict.Add(37, new momsrutaclass(37, "Mellanmans inköp av varor vid trepartshandel", "InkopVaruMellan3p", "", "", "", "4512"));
            momsdict.Add(38, new momsrutaclass(38, "Mellanmans försäljning av varor vid trepartshandel", "ForsVaruMellan3p", "", "", "", "3107"));
            momsdict.Add(39, new momsrutaclass(39, "Försäljning av tjänster till näringsidkare i annat EU-land enligt huvudregeln", "ForsTjSkskAnnatEg", "", "", "", "3308"));
            momsdict.Add(40, new momsrutaclass(40, "Övrig försäljning av tjänster omsatta utanför Sverige", "ForsTjOvrUtomEg", "", "", "", "3305"));
            momsdict.Add(41, new momsrutaclass(41, "Försäljning när köparen är skattskyldig i Sverige", "ForsKopareSkskSverige", "", "", "", "3231,3232,3233"));
            momsdict.Add(42, new momsrutaclass(42, "Övrig försäljning m.m.", "ForsOvrigt", "", "", "", "3004,3994,3980,3992,3404"));
            momsdict.Add(10, new momsrutaclass(10, "Utgående moms 25%", "MomsUtgHog", "", "", "", "2610,2611,2612,2613,2616"));
            momsdict.Add(11, new momsrutaclass(11, "Utgående moms 12%", "MomsUtgMedel", "", "", "", "2620,2621,2622"));
            momsdict.Add(12, new momsrutaclass(12, "Utgående moms 6%", "MomsUtgLag", "", "", "", "2630,2631,2632,2636"));
            momsdict.Add(30, new momsrutaclass(30, "Utgående moms 25% ruta 20-24", "MomsInkopUtgHog", "", "", "", "2614"));
            momsdict.Add(31, new momsrutaclass(31, "Utgående moms 12% ruta 20-24", "MomsInkopUtgMedel", "", "", "", "2624"));
            momsdict.Add(32, new momsrutaclass(32, "Utgående moms 6% ruta 20-24", "MomsInkopUtgLag", "", "", "", "2634"));
            momsdict.Add(60, new momsrutaclass(60, "Utgående moms 25% ruta 50", "MomsImportUtgHog", "", "", "", "2615"));
            momsdict.Add(61, new momsrutaclass(61, "Utgående moms 12% ruta 50", "MomsImportUtgMedel", "", "", "", "2625"));
            momsdict.Add(62, new momsrutaclass(62, "Utgående moms 6% ruta 50", "MomsImportUtgLag", "", "", "", "2635"));
            momsdict.Add(48, new momsrutaclass(48, "Ingående moms att dra av", "MomsIngAvdr", "", "", "264", ""));
            momsdict.Add(49, new momsrutaclass(49, "Moms att betala/få tillbaka", "MomsBetala", "10+11+12+30+31+32-48", "", "", "2650"));
        }

        public decimal summoms(int fiscal, DateTime start, DateTime end)
        {
            if (ruta == 5)
            {
                decimal sum = sumkonto_transactions(fiscal, start, end);
                sum -= momsdict[6].sumkonto_transactions(fiscal, start, end);
                sum -= momsdict[7].sumkonto_transactions(fiscal, start, end);
                sum -= momsdict[8].sumkonto_transactions(fiscal, start, end);
                sum -= momsdict[35].sumkonto_transactions(fiscal, start, end);
                sum -= momsdict[36].sumkonto_transactions(fiscal, start, end);
                sum -= momsdict[38].sumkonto_transactions(fiscal, start, end);
                sum -= momsdict[39].sumkonto_transactions(fiscal, start, end);
                sum -= momsdict[40].sumkonto_transactions(fiscal, start, end);
                sum -= momsdict[41].sumkonto_transactions(fiscal, start, end);
                sum -= momsdict[42].sumkonto_transactions(fiscal, start, end);
                return Math.Abs(sum);
            }
            else if (ruta == 49)
            {
                decimal sum = 0;
                sum += momsdict[10].sumkonto_transactions(fiscal, start, end);
                sum += momsdict[11].sumkonto_transactions(fiscal, start, end);
                sum += momsdict[12].sumkonto_transactions(fiscal, start, end);
                sum += momsdict[30].sumkonto_transactions(fiscal, start, end);
                sum += momsdict[31].sumkonto_transactions(fiscal, start, end);
                sum += momsdict[32].sumkonto_transactions(fiscal, start, end);
                sum += momsdict[60].sumkonto_transactions(fiscal, start, end);
                sum += momsdict[61].sumkonto_transactions(fiscal, start, end);
                sum += momsdict[62].sumkonto_transactions(fiscal, start, end);
                sum = Math.Abs(sum) - Math.Abs(momsdict[48].sumkonto_transactions(fiscal, start, end));
                return sum;
            }
            else
            {
                return Math.Abs(sumkonto_transactions(fiscal, start, end));
            }
        }
    }
}

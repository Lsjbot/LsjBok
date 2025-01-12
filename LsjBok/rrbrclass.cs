using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LsjBok
{
    public class rrbrclass : kontogruppclass
    {

        public string field = "";
        public int sign = 1;
        public string partof = "";
        public List<string> parts = new List<string>();

        public static List<rrbrclass> rrlist = new List<rrbrclass>();
        public static List<rrbrclass> brlist = new List<rrbrclass>();

        //public static Dictionary<string,rrbrclass>

        public static rrbrclass rrtop = null;

        public static rrbrclass intakt = null;
        public static rrbrclass kostnad = null;
        public static rrbrclass finans = null;
        public static rrbrclass bokdisp = null;
        public static rrbrclass skatt = null;
        public static rrbrclass periodiseringsfond = null;


        public rrbrclass(string f,string desc,string k1,string k2,string k3,string k4,int sg,string partofpar)
        {
            field = f.Replace("Fält: ", "");
            description = desc.Replace("Beskrivning: ", "");
            konto1string = k1;
            konto2string = k2;
            konto3string = k3;
            konto4string = k4;
            stringtolists();
            sign = sg;
            partof = partofpar;
        }

        //public decimal sumamount(int fiscalyear)
        //{
        //    decimal sum = sumkonto(fiscalyear);
        //    sum = sign * sum;
        //    var qpr = from c in rrlist where c.partof == this.field select c;
        //    foreach (rrbrclass r in qpr)
        //        sum += r.sumamount(fiscalyear);
        //    var qpb = from c in brlist where c.partof == this.field select c;
        //    foreach (rrbrclass r in qpb)
        //        sum += r.sumamount(fiscalyear);
        //    return sum;
        //}
        public decimal sumamount_IB(int fiscalyear)
        {
            decimal sum = sumkonto_IB(fiscalyear);
            //sum = sign * sum;
            var qpr = from c in rrlist where c.partof == this.field select c;
            foreach (rrbrclass r in qpr)
                sum += r.sumamount_IB(fiscalyear);
            var qpb = from c in brlist where c.partof == this.field select c;
            foreach (rrbrclass r in qpb)
                sum += r.sumamount_IB(fiscalyear);
            return sum;
        }

        public decimal sumamount(int fiscalyear)
        {
            decimal sum = sumkonto(fiscalyear);
            //sum = sign * sum;
            var qpr = from c in rrlist where c.partof == this.field select c;
            foreach (rrbrclass r in qpr)
                sum += r.sumamount(fiscalyear);
            var qpb = from c in brlist where c.partof == this.field select c;
            foreach (rrbrclass r in qpb)
                sum += r.sumamount(fiscalyear);
            return sum;

        }
        public decimal sumamount_transactions(int fiscalyear, DateTime start, DateTime end)
        {
            decimal sum = sumkonto_transactions(fiscalyear, start, end);
            //sum = sign * sum;
            var qpr = from c in rrlist where c.partof == this.field select c;
            foreach (rrbrclass r in qpr)
                sum += r.sumamount_transactions(fiscalyear, start, end);
            var qpb = from c in brlist where c.partof == this.field select c;
            foreach (rrbrclass r in qpb)
                sum += r.sumamount_transactions(fiscalyear, start, end);
            return sum;
        }

        public decimal sumamount_UB(int fiscalyear, DateTime end)
        {
            decimal sum = sumkonto_UB(fiscalyear, end);
            //sum = sign * sum;
            var qpr = from c in rrlist where c.partof == this.field select c;
            foreach (rrbrclass r in qpr)
                sum += r.sumamount_UB(fiscalyear, end);
            var qpb = from c in brlist where c.partof == this.field select c;
            foreach (rrbrclass r in qpb)
                sum += r.sumamount_UB(fiscalyear, end);
            return sum;
        }

        public static rrbrclass get_assets()
        {
            return (from c in rrbrclass.brlist where c.field == "Tillgångar" select c).First();
        }

        public static rrbrclass get_debts()
        {
            return (from c in rrbrclass.brlist where c.field == "Eget kapital och skulder" select c).First();
        }

        public static List<int> checkallkonto(List<rrbrclass> rlist )
        {
            List<int> covered = new List<int>();
            foreach (var rr in rlist)
            {
                foreach (int i in rr.konto1list)
                {
                    for (int j=0;j<1000;j++)
                    {
                        int k = i*1000 + j;
                        if (!covered.Contains(k))
                            covered.Add(k);
                        else
                            Console.WriteLine("Dublett1 " + k + " " + rr.field);
                    }
                }
                foreach (int i in rr.konto2list)
                {
                    for (int j = 0; j < 100; j++)
                    {
                        int k = i*100 + j;
                        if (!covered.Contains(k))
                            covered.Add(k);
                        else
                            Console.WriteLine("Dublett2 " + k + " " + rr.field);
                    }
                }
                foreach (int i in rr.konto3list)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        int k = i*10 + j;
                        if (!covered.Contains(k))
                            covered.Add(k);
                        else
                            Console.WriteLine("Dublett3 " + k + " " + rr.field);
                    }
                }
                foreach (int k in rr.konto4list)
                {
                    if (!covered.Contains(k))
                        covered.Add(k);
                    else
                        Console.WriteLine("Dublett4 " + k + " " + rr.field);
                }
            }
            return covered;
        }

        public static void fill_rrbr()
        {
            if (rrlist.Count > 0)
                return;

            rrlist.Add(new rrbrclass("Fält: Nettoomsättning", "Beskrivning: Intäkter som genererats av företagets ordinarie verksamhet, t.ex. varuförsäljning och tjänsteintäkter.", "", "30,31,32,33,34,35,36,37", "", "", -1, "Rörelsens intäkter"));
            rrlist.Add(new rrbrclass("Fält: Aktiverat arbete för egen räkning", "Beskrivning: Kostnader för eget arbete där resultatet av arbetet tas upp som en tillgång i balansräkningen.", "", "38", "", "", -1, "Rörelsens intäkter"));
            rrlist.Add(new rrbrclass("Fält: Övriga rörelseintäkter", "Beskrivning: Intäkter genererade utanför företagets ordinarie verksamhet, t.ex. valutakursvinster eller realisationsvinster.", "", "39", "", "", -1, "Rörelsens intäkter"));
            rrlist.Add(new rrbrclass("Fält: Råvaror och förnödenheter", "Beskrivning: Årets inköp av råvaror och förnödenheter +/- förändringar av lagerposten ”Råvaror och förnödenheter”. Även kostnader för legoarbeten och underentreprenader.", "", "40,41,42,43,44,45,46,47", "491,492", "4930,4931", 1, "Varukostnader"));
            rrlist.Add(new rrbrclass("Fält: Förändring av lager av produkter i arbete, färdiga varor och pågående arbete för annans räkning", "Beskrivning: Årets förändring av värdet på produkter i arbete och färdiga egentillverkade varor samt förändring av värde på uppdrag som utförs till fast pris.", "", "", "490,494,495,497,499", "4932,4933,4934,4935,4936,4937,4938,4939", 1, "Varukostnader"));
            rrlist.Add(new rrbrclass("Fält: Handelsvaror", "Beskrivning: Årets inköp av handelsvaror +/- förändring av lagerposten ”Handelsvaror”.", "", "", "496,498", "", 1, "Varukostnader"));
            rrlist.Add(new rrbrclass("Fält: Övriga externa kostnader", "Beskrivning: Normala kostnader som inte passar någon annanstans. T.ex. lokalhyra, konsultarvoden, telefon, porto, reklam och nedskrivning av kortfristiga fordringar.", "5,6", "", "", "", 1, "Rörelsens kostnader"));
            rrlist.Add(new rrbrclass("Fält: Personalkostnader", "", "", "70,71,72,73,74,75,76", "", "", 1, "Rörelsens kostnader"));
            rrlist.Add(new rrbrclass("Fält: Av- och nedskrivningar av materiella och immateriella anläggningstillgångar", "", "", "78", "770,771,772,773,775,776,777,778", "", 1, "Av- och nedskrivningar"));
            rrlist.Add(new rrbrclass("Fält: Nedskrivningar av omsättningstillgångar utöver normala nedskrivningar", "Beskrivning: Används mycket sällan. Ett exempel är om man gör ovanligt stora nedskrivningar av kundfordringar.", "", "", "774,779", "", 1, "Av- och nedskrivningar"));
            rrlist.Add(new rrbrclass("Fält: Övriga rörelsekostnader", "Beskrivning: Kostnader som ligger utanför företagets normala verksamhet. T.ex. valutakursförluster och realisationsförlust vid försäljning av icke- finansiella anläggningstillgångar.", "", "79", "", "", 1, "Rörelsens kostnader"));
            rrlist.Add(new rrbrclass("Fält: Resultat från andelar i koncernföretag", "Beskrivning: Nettot av företagets finansiella intäkter och kostnader från koncernföretag med undantag av räntor, koncernbidrag och nedskrivningar. T.ex. erhållna utdelningar, andel i handelsbolags resultat och realisationsresultat.", "", "", "800,801,802,803,804,805,806,809", "", 1, "Finansiella poster"));
            rrlist.Add(new rrbrclass("Fält: Nedskrivningar av finansiella anläggningstillgångar och kortfristiga placeringar", "Beskrivning: Nedskrivningar av och återföring av nedskrivningar på finansiella anläggningstillgångar och kortfristiga placeringar", "", "", "807,808,827,828,837,838", "", 1, "Finansiella poster"));
            rrlist.Add(new rrbrclass("Fält: Resultat från andelar i intresseföretag och gemensamt styrda företag", "Beskrivning: Nettot av företagets finansiella intäkter och kostnader från intresseföretag och gemensamt styrda företag med undantag av räntor och nedskrivningar. T.ex. erhållna utdelningar, andel i handelsbolags resultat och realisationsresultat.", "", "", "810,814,815,816,819", "8110,8111,8112,8114,8115,8116,8117,8119,8120,8121,8122,8124,8125,8126,8127.8128,8129,8130,8131,8132,8134,8135,8136,8137,8138,8139", 1, "Finansiella poster"));
            rrlist.Add(new rrbrclass("Fält: Resultat från övriga företag som det finns ett ägarintresse i", "Beskrivning: Nettot av företagets finansiella intäkter och kostnader från övriga företag som det finns ett ägarintresse i med undantag av räntor och nedskrivningar. T.ex. vissa erhållna vinstutdelningar, andel i handelsbolags resultat och realisationsresultat.", "", "", "", "8113,8118,8123,8133", 1, "Finansiella poster"));
            rrlist.Add(new rrbrclass("Fält: Resultat från övriga finansiella anläggningstillgångar", "Beskrivning: Nettot av intäkter och kostnader från företagets övriga värdepapper och fordringar som är anläggningstillgångar, med undantag av nedskrivningar. T.ex. ränteintäkter (även på värdepapper avseende koncern- och intresseföretag), utdelningar, positiva och negativa valutakursdifferenser och realisationsresultat.", "", "", "820,821,822,823,824,825,826,829", "", 1, "Finansiella poster"));
            rrlist.Add(new rrbrclass("Fält: Övriga ränteintäkter och liknande resultatposter", "Beskrivning: Resultat från finansiella omsättningstillgångar med undantag för nedskrivningar. T.ex. ränteintäkter (även dröjsmålsräntor på kundfordringar), utdelningar och positiva valutakursdifferenser.", "", "", "830,831,832,833,834,835,836,839", "", 1, "Finansiella poster"));
            rrlist.Add(new rrbrclass("Fält: Räntekostnader och liknande resultatposter", "Beskrivning: Resultat från finansiella skulder, t.ex. räntor på lån, positiva och negativa valutakursdifferenser samt dröjsmåls-räntor på leverantörsskulder.", "", "84", "", "", 1, "Finansiella poster"));
            rrlist.Add(new rrbrclass("Fält: Extraordinära intäkter", "Beskrivning: Används mycket sällan. Får inte användas för räkenskapsår som börjar 2016-01-01 eller senare.", "", "", "", "8710", 1, ""));
            rrlist.Add(new rrbrclass("Fält: Extraordinära kostnader", "Beskrivning: Används mycket sällan. Får inte användas för räkenskapsår som börjar 2016-01-01 eller senare.", "", "", "", "8750", 1, ""));
            rrlist.Add(new rrbrclass("Fält: Förändring av periodiseringsfonder", "", "", "", "881", "", 1, "Bokslutsdispositioner"));
            rrlist.Add(new rrbrclass("Fält: Erhållna koncernbidrag", "", "", "", "882", "", 1, "Bokslutsdispositioner"));
            rrlist.Add(new rrbrclass("Fält: Lämnade koncernbidrag", "", "", "", "883", "", 1, "Bokslutsdispositioner"));
            rrlist.Add(new rrbrclass("Fält: Övriga bokslutsdispositioner", "", "", "", "884,886,887,888,889", "", 1, "Bokslutsdispositioner"));
            rrlist.Add(new rrbrclass("Fält: Förändring av överavskrivningar", "", "", "", "885", "", 1, "Bokslutsdispositioner"));
            rrlist.Add(new rrbrclass("Fält: Skatt på årets resultat", "Beskrivning: Skatt som belastar årets resultat. Här ingår beräknad skatt på årets resultat, men även t.ex. justeringar avseende tidigare års skatt.", "", "", "890,891,892,893,894,895,896,897", "", 1, "Skatter"));
            rrlist.Add(new rrbrclass("Fält: Övriga skatter", "Beskrivning: Används sällan.", "", "", "898", "", 1, "Skatter"));
            rrlist.Add(new rrbrclass("Nedskrivningar", "", "", "", "817", "", 1, "Av- och nedskrivningar"));
            rrlist.Add(new rrbrclass("Återföring av nedskrivningar", "", "", "", "818", "", 1, "Av- och nedskrivningar"));




            brlist.Add(new rrbrclass("Fält: Koncessioner, patent, licenser, varumärken samt liknande rättigheter", "", "", "", "102,103,104,105", "1080,1081,1082,1083,1084,1085,1086,1087,1089", 1, "Immateriella tillgångar"));
            brlist.Add(new rrbrclass("Fält: Hyresrätter och liknande rättigheter", "", "", "", "106", "", 1, "Immateriella tillgångar"));
            brlist.Add(new rrbrclass("Fält: Goodwill", "", "", "", "107", "", 1, "Immateriella tillgångar"));
            brlist.Add(new rrbrclass("Fält: Förskott avseende immateriella anläggningstillgångar", "Beskrivning: Förskott i samband med förvärv, t.ex. handpenning och deposition.", "", "", "", "1088", 1, "Immateriella tillgångar"));
            brlist.Add(new rrbrclass("Fält: Byggnader och mark", "Beskrivning: Fögnadens allmänna användning.", "", "", "110,111,113,114,115,116,117,119", "", 1, "Anläggningstillgångar"));
            brlist.Add(new rrbrclass("Fält: Förbättringsutgifter på annans fastighet", "", "", "", "112", "", 1, "Anläggningstillgångar"));
            brlist.Add(new rrbrclass("Fält: Pågående nyanläggningar och förskott avseende materiella anläggningstillgångar", "", "", "", "118,128", "", 1, "Anläggningstillgångar"));
            brlist.Add(new rrbrclass("Fält: Maskiner och andra tekniska anläggningar", "Beskrivning: Maskiner och tekniska anläggningar avsedda för produktionen.", "", "", "121", "", 1, "Anläggningstillgångar"));
            brlist.Add(new rrbrclass("Fält: Inventarier, verktyg och installationer", "Beskrivning: Om du fyller i detta fält måste du även fylla i motsvarande not i avsnittet \"Noter\".", "", "", "122,123,124,125,127", "", 1, "Anläggningstillgångar"));
            brlist.Add(new rrbrclass("Fält: Övriga materiella anläggningstillgångar", "Beskrivning: T.ex. djur som klassificerats som anläggningstillgång.", "", "", "129", "", 1, "Anläggningstillgångar"));
            brlist.Add(new rrbrclass("Fält: Andelar i koncernföretag", "Beskrivning: Aktier och andelar i koncernföretag.", "", "", "131", "", 1, "Långsiktiga fordringar"));
            brlist.Add(new rrbrclass("Fält: Fordringar hos koncernföretag", "Beskrivning: Fordringar på koncernföretag som förfaller till betalning senare än 12 månader från balansdagen.", "", "", "132", "", 1, "Långsiktiga fordringar"));
            brlist.Add(new rrbrclass("Fält: Andelar i intresseföretag och gemensamt styrda företag", "Beskrivning: Aktier och andelar i intresseföretag.", "", "", "", "1330,1331,1332,1333,1334,1335,1338,1339", 1, "Långsiktiga fordringar"));
            brlist.Add(new rrbrclass("Fält: Ägarintressen i övriga företag", "Beskrivning: Aktier och andelar i övriga företag som det redovisningsskyldiga företaget har ett ägarintresse i.", "", "", "", "1336,1337", 1, "Långsiktiga fordringar"));
            brlist.Add(new rrbrclass("Fält: Fordringar hos intresseföretag och gemensamt styrda företag", "Beskrivning: Fordringar på intresseföretag och gemensamt styrda företag, som förfaller till betalning senare än 12 månader från balansdagen.", "", "", "", "1340,1341,1342,1343,1344,1345,1348,1349", 1, "Långsiktiga fordringar"));
            brlist.Add(new rrbrclass("Fält: Fordringar hos övriga företag som det finns ett ägarintresse i", "Beskrivning: Fordringar på övriga företag som det finns ett ägarintresse i och som ska betalas senare än 12 månader från balansdagen.", "", "", "", "1346,1347", 1, "Långsiktiga fordringar"));
            brlist.Add(new rrbrclass("Fält: Andra långfristiga värdepappersinnehav", "Beskrivning: Långsiktigt innehav av värdepapper som inte avser koncern- eller intresseföretag.", "", "", "135", "", 1, "Långsiktiga fordringar"));
            brlist.Add(new rrbrclass("Fält: Lån till delägare eller närstående", "Beskrivning: Fordringar på delägare, och andra som står delägare nära, som förfaller till betalning senare än 12 månader från balansdagen.", "", "", "136", "", 1, "Långsiktiga fordringar"));
            brlist.Add(new rrbrclass("Fält: Andra långfristiga fordringar", "Beskrivning: Fordringar som förfaller till betalning senare än 12 månader från balansdagen.", "", "", "138", "", 1, "Långsiktiga fordringar"));
            brlist.Add(new rrbrclass("Fält: Råvaror och förnödenheter", "Beskrivning: Lager av råvaror eller förnödenheter som har köpts för att bearbetas eller för att vara komponenter i den egna tillverkningen.", "", "", "141,142", "1430,1431,1438", 1, "Omsättningstillgångar"));
            brlist.Add(new rrbrclass("Fält: Varor under tillverkning", "Beskrivning: Lager av varor där tillverkning har påbörjats.", "", "", "144", "1432,1433,1434,1435,1436,1437,1439", 1, "Omsättningstillgångar"));
            brlist.Add(new rrbrclass("Fält: Färdiga varor och handelsvaror", "Beskrivning: Lager av färdiga egentillverkade varor eller varor som har köpts för vidareförsäljning (handelsvaror).", "", "", "145,146", "", 1, "Omsättningstillgångar"));
            brlist.Add(new rrbrclass("Fält: Pågående arbete för annans räkning", "Beskrivning: Om du fyller i detta fält måste du även fylla i motsvarande not i avsnittet \"Noter\".", "", "", "147", "", 1, "Omsättningstillgångar"));
            brlist.Add(new rrbrclass("Fält: Förskott till leverantörer", "Beskrivning: Betalningar och obetalda fakturor för varor och tjänster som redovisas som lager men där prestationen ännu inte erhållits.", "", "", "148", "", 1, "Omsättningstillgångar"));
            brlist.Add(new rrbrclass("Fält: Övriga lagertillgångar", "Beskrivning: Lager av värdepapper (t.ex. lageraktier), lagerfastigheter och djur som klassificerats som omsättningstillgång.", "", "", "149", "", 1, "Omsättningstillgångar"));
            brlist.Add(new rrbrclass("Fält: Kundfordringar", "", "", "", "150,151,152,153,154,155,158", "", 1, "Kortfristiga fordringar"));
            brlist.Add(new rrbrclass("Fält: Fordringar hos koncernföretag", "Beskrivning: Fordringar på koncernföretag, inklusive kundfordringar.", "", "", "156,166", "", 1, "Kortfristiga fordringar"));
            brlist.Add(new rrbrclass("Fält: Fordringar hos intresseföretag och gemensamt styrda företag", "Beskrivning: Fordringar på intresseföretag och gemensamt styrda företag, inklusive kundfordringar.", "", "", "", "1570,1571,1572,1574,1575,1576,1577,1578,1579,1670,1671,1672,1674,1675,1676,1677,1678,1679", 1, "Kortfristiga fordringar"));
            brlist.Add(new rrbrclass("Fält: Fordringar hos övriga företag som det finns ett ägarintresse i", "Beskrivning: Fordringar på övriga företag som det finns ett ägarintresse i, inklusive kundfordringar.", "", "", "", "1573,1673", 1, "Kortfristiga fordringar"));
            brlist.Add(new rrbrclass("Fält: Övriga fordringar", "Beskrivning: T.ex. aktuella skattefordringar.", "", "", "159,160,161,163,164,165,168", "", 1, "Kortfristiga fordringar"));
            brlist.Add(new rrbrclass("Fält: Upparbetad men ej fakturerad intäkt", "Beskrivning: Upparbetade men ej fakturerade intäkter från uppdrag på löpande räkning eller till fast pris enligt huvudregeln.", "", "", "162", "", 1, "Kortfristiga fordringar"));
            brlist.Add(new rrbrclass("Fält: Tecknat men ej inbetalat kapital", "Beskrivning: Fordringar på aktieägare före tecknat men ej inbetalt kapital. Används vid nyemission.", "", "", "169", "", 1, "Kortfristiga fordringar"));
            brlist.Add(new rrbrclass("Fält: Förutbetalda kostnader och upplupna intäkter", "Beskrivning: Förutbetalda kostnader (t.ex. förutbetalda hyror eller försäkringspremier) och upplupna intäkter (varor eller tjänster som är levererade men där kunden ännu inte betalat).", "", "17", "", "", 1, "Kortfristiga fordringar"));
            brlist.Add(new rrbrclass("Fält: Övriga kortfristiga placeringar", "Beskrivning: Innehav av värdepapper eller andra placeringar som inte är anläggningstillgångar och som inte redovisas i någon annan post under Omsättningstillgångar och som ni planerar att avyttra inom 12 månader från bokföringsårets slut.", "", "", "180,181,182,183,184,185,187,188,189", "", 1, "Kortfristiga fordringar"));
            brlist.Add(new rrbrclass("Fält: Andelar i koncernföretag", "Beskrivning: Här registrerar ni de andelar i koncernföretag som ni planerar att avyttra inom 12 månader från bokföringsårets slut.", "", "", "186", "", 1, "Kortfristiga fordringar"));
            brlist.Add(new rrbrclass("Fält: Kassa & bank", "", "", "", "190,191,192,193,194,195,196,198", "", 1, "Kassa och bank"));
            brlist.Add(new rrbrclass("Fält: Redovisningsmedel", "", "", "", "199", "", 1, "Kassa och bank"));
            brlist.Add(new rrbrclass("Fält: Aktiekapital", "Beskrivning: Aktiekapitalet i ett aktiebolag ska vara minst 25 000 kr.", "", "", "", "2080,2081,2083,2084", -1, "Bundet eget kapital"));
            brlist.Add(new rrbrclass("Fält: Ej registrerat aktiekapital", "Beskrivning: Beslutad ökning av aktiekapitalet genom fond- eller nyemission.", "", "", "", "2082", -1, "Bundet eget kapital"));
            brlist.Add(new rrbrclass("Fält: Uppskrivningsfond", "", "", "", "", "2085", -1, "Bundet eget kapital"));
            brlist.Add(new rrbrclass("Fält: Reservfond", "", "", "", "", "2086", -1, "Bundet eget kapital"));
            brlist.Add(new rrbrclass("Fält: Bunden överkursfond", "", "", "", "", "2087", -1, "Bundet eget kapital"));
            brlist.Add(new rrbrclass("Fält: Balanserat resultat", "Beskrivning: Summan av tidigare års vinster och förluster. Registrera balanserat resultat med minustecken om det balanserade resultatet är en balanserad förlust. Är det en balanserad vinst ska du inte använda minustecken.", "", "", "", "2090,2091,2093,2094,2095,2098", -1, "Fritt eget kapital"));
            brlist.Add(new rrbrclass("Fält: Årets resultat", "Beskrivning: Årets vinst (+) eller förlust (-).", "", "", "", "2099", -1, "Fritt eget kapital"));
            brlist.Add(new rrbrclass("Fält: Fri överkursfond", "", "", "", "", "2097", -1, "Fritt eget kapital"));
            brlist.Add(new rrbrclass("Fält: Periodiseringsfonder", "Beskrivning: Man kan avsätta upp till 25% av resultat efter finansiella poster till periodiseringsfonden. Det är ett sätt att skjuta upp bolagsskatten i upp till fem år. Avsättningen måste återföras till beskattning senast på det sjätte året efter det att avsättningen gjordes.", "", "", "211,212,213,214", "", -1, "Obeskattade reserver"));
            brlist.Add(new rrbrclass("Fält: Ackumulerade överavskrivningar", "", "", "", "215", "", -1, "Obeskattade reserver"));
            brlist.Add(new rrbrclass("Fält: Övriga obeskattade reserver", "", "", "", "216,217,218,219", "", -1, "Obeskattade reserver"));
            brlist.Add(new rrbrclass("Fält: Avsättningar för pensioner och liknande förpliktelser enligt lagen (1967:531) om tryggande av pensionsutfästelse m.m.", "Beskrivning: Åtaganden för pensioner enligt tryggandelagen.", "", "", "221", "", -1, "Avsättningar"));
            brlist.Add(new rrbrclass("Fält: Övriga avsättningar", "Beskrivning: Andra avsättningar än för pensioner, t.ex. garantiåtaganden.", "", "", "222,225,226,227,228,229", "", -1, "Avsättningar"));
            brlist.Add(new rrbrclass("Fält: Övriga avsättningar för pensioner och liknande förpliktelser", "Beskrivning: Övriga pensionsåtaganden till nuvarande och tidigare anställda.", "", "", "223", "", -1, "Avsättningar"));
            brlist.Add(new rrbrclass("Fält: Obligationslån", "", "", "", "231,232", "", -1, "Långfristiga skulder"));
            brlist.Add(new rrbrclass("Fält: Checkräkningskredit", "", "", "", "233", "", -1, "Långfristiga skulder"));
            brlist.Add(new rrbrclass("Fält: Övriga skulder till kreditinstitut", "", "", "", "234,235", "", -1, "Långfristiga skulder"));
            brlist.Add(new rrbrclass("Fält: Skulder till koncernföretag", "", "", "", "236", "", -1, "Långfristiga skulder"));
            brlist.Add(new rrbrclass("Fält: Skulder till intresseföretag och gemensamt styrda företag", "", "", "", "", "2370,2371,2372,2374,2375,2376,2377,2378,2379", -1, "Långfristiga skulder"));
            brlist.Add(new rrbrclass("Fält: Skulder till övriga företag som det finns ett ägarintresse i", "", "", "", "", "2373", -1, "Långfristiga skulder"));
            brlist.Add(new rrbrclass("Fält: Övriga skulder", "", "", "", "239", "", -1, "Långfristiga skulder"));
            brlist.Add(new rrbrclass("Fält: Övriga skulder till kreditinstitut", "", "", "", "241", "", -1, "Kortfristiga skulder"));
            brlist.Add(new rrbrclass("Fält: Förskott från kunder", "", "", "", "242", "", -1, "Kortfristiga skulder"));
            brlist.Add(new rrbrclass("Fält: Pågående arbete för annans räkning", "Beskrivning: Om du fyller i detta fält måste du även fylla i motsvarande not i avsnittet \"Noter\".", "", "", "243", "", -1, "Kortfristiga skulder"));
            brlist.Add(new rrbrclass("Fält: Leverantörsskulder", "", "", "", "244", "", -1, "Kortfristiga skulder"));
            brlist.Add(new rrbrclass("Fält: Fakturerad men ej upparbetad intäkt", "", "", "", "245", "", -1, "Kortfristiga skulder"));
            brlist.Add(new rrbrclass("Fält: Skulder till koncernföretag", "", "", "", "246,286", "", -1, "Kortfristiga skulder"));
            brlist.Add(new rrbrclass("Fält: Skulder till intresseföretag och gemensamt styrda företag", "", "", "", "", "2470,2471,2472,2474,2475,2476,2477,2478,2479,2870,2871,2872,2874,2875,2876,2877,2878,2879", -1, "Kortfristiga skulder"));
            brlist.Add(new rrbrclass("Fält: Skulder till övriga företag som det finns ett ägarintresse i", "", "", "", "", "2473,2873", -1, "Kortfristiga skulder"));
            brlist.Add(new rrbrclass("Fält: Checkräkningskredit", "", "", "", "248", "", -1, "Kortfristiga skulder"));
            brlist.Add(new rrbrclass("Fält: Övriga skulder", "", "", "26,27", "281,282,283,284,285,288,289", "2490,2491,2493,2494,2495,2496,2497,2498,2499", -1, "Kortfristiga skulder"));
            brlist.Add(new rrbrclass("Fält: Växelskulder", "", "", "", "", "2492", -1, "Kortfristiga skulder"));
            brlist.Add(new rrbrclass("Fält: Skatteskuld", "", "", "25", "", "", -1, "Skatteskulder"));
            brlist.Add(new rrbrclass("Fält: Upplupna kostnader och förutbetalda intäkter", "", "", "29", "", "", -1, "Kortfristiga skulder"));
            brlist.Add(new rrbrclass("Utveckling", "", "", "", "101", "", 1, "Immateriella tillgångar"));
            brlist.Add(new rrbrclass("Leasade tillgångar", "", "", "", "126", "", 1, "Anläggningstillgångar"));
            brlist.Add(new rrbrclass("Uppskjuten skattefordran", "", "", "", "137", "", 1, "Långsiktiga fordringar"));
            brlist.Add(new rrbrclass("Särskilda bankkonton", "", "", "", "197", "", 1, "Kassa och bank"));
            brlist.Add(new rrbrclass("Eget kapital (firma/delägare)", "", "", "", "201,202,203,204", "", 1, "Eget kapital"));
            brlist.Add(new rrbrclass("Avsättning till expansionsfond", "", "", "", "205", "", -1, "Eget kapital"));
            brlist.Add(new rrbrclass("Eget kapital (ideell/stitelse mm)", "", "", "", "206", "", -1, "Eget kapital"));
            brlist.Add(new rrbrclass("Ändamålsbestäma medel", "", "", "", "207", "", -1, "Eget kapital"));
            brlist.Add(new rrbrclass("Fondmedel", "", "", "", "", "2088,2089,2096", -1, "Eget kapital"));
            brlist.Add(new rrbrclass("Koncernbidrag", "", "", "", "", "2092", -1, "Eget kapital"));
            brlist.Add(new rrbrclass("Avsättningar för uppskjutna skatter", "", "", "", "", "2240", -1, "Skatteskulder"));


            rrlist.Add(new rrbrclass("Resultaträkning", "", "", "", "", "", 1, ""));
            rrlist.Add(new rrbrclass("Rörelsens intäkter", "", "", "", "", "", -1, "Resultaträkning"));


            rrlist.Add(new rrbrclass("Varukostnader", "", "", "", "", "", -1, "Rörelsens kostnader"));


            rrlist.Add(new rrbrclass("Rörelsens kostnader", "", "", "", "", "", 1, "Resultaträkning"));

            rrlist.Add(new rrbrclass("Av- och nedskrivningar", "", "", "", "", "", 1, "Rörelsens kostnader"));

            rrlist.Add(new rrbrclass("Rörelsens kostnader", "", "", "", "", "", 1, ""));
            rrlist.Add(new rrbrclass("Finansiella poster", "", "", "", "", "", 1, "Resultaträkning"));







            rrlist.Add(new rrbrclass("Bokslutsdispositioner", "", "", "", "", "", 1, "Resultaträkning"));




            rrlist.Add(new rrbrclass("Skatter", "", "", "", "", "", 1, "Resultaträkning"));


            brlist.Add(new rrbrclass("Balansräkning", "", "", "", "", "", 1, ""));
            brlist.Add(new rrbrclass("Tillgångar", "", "", "", "", "", 1, "Balansräkning"));
            brlist.Add(new rrbrclass("Eget kapital och skulder", "", "", "", "", "", 1, "Balansräkning"));
            brlist.Add(new rrbrclass("Immateriella tillgångar", "", "", "", "", "", 1, "Tillgångar"));



            brlist.Add(new rrbrclass("Anläggningstillgångar", "", "", "", "", "", 1, "Tillgångar"));





            brlist.Add(new rrbrclass("Långsiktiga fordringar", "", "", "", "", "", 1, "Tillgångar"));








            brlist.Add(new rrbrclass("Omsättningstillgångar", "", "", "", "", "", 1, "Tillgångar"));





            brlist.Add(new rrbrclass("Kortfristiga fordringar", "", "", "", "", "", 1, "Tillgångar"));









            brlist.Add(new rrbrclass("Kassa och bank", "", "", "", "", "", 1, "Tillgångar"));

            brlist.Add(new rrbrclass("Eget kapital", "", "", "", "", "", 1, "Eget kapital och skulder"));
            brlist.Add(new rrbrclass("Bundet eget kapital", "", "", "", "", "", 1, "Eget kapital"));




            brlist.Add(new rrbrclass("Fritt eget kapital", "", "", "", "", "", 1, "Eget kapital"));

            brlist.Add(new rrbrclass("Obeskattade reserver", "", "", "", "", "", 1, "Eget kapital"));


            brlist.Add(new rrbrclass("Avsättningar", "", "", "", "", "", 1, "Eget kapital och skulder"));


            brlist.Add(new rrbrclass("Långfristiga skulder", "", "", "", "", "", 1, "Eget kapital och skulder"));






            brlist.Add(new rrbrclass("Kortfristiga skulder", "", "", "", "", "", 1, "Eget kapital och skulder"));










            brlist.Add(new rrbrclass("Skatteskulder", "", "", "", "", "", 1, "Eget kapital och skulder"));














            var covered = checkallkonto(rrlist);
            covered.AddRange(checkallkonto(brlist));
            foreach (int k in kontoclass.kontodict.Keys)
            {
                if (k < 1000)
                    continue;
                if (!covered.Contains(k))
                    Console.WriteLine(k + " " + kontoclass.kontodict[k]);
            }

            rrtop = (from c in rrbrclass.rrlist where c.field == "Resultaträkning" select c).First();

            intakt = (from c in rrbrclass.rrlist where c.field == "Rörelsens intäkter" select c).First();
            kostnad = (from c in rrbrclass.rrlist where c.field == "Rörelsens kostnader" select c).First();
            finans = (from c in rrbrclass.rrlist where c.field == "Finansiella poster" select c).First();
            bokdisp = (from c in rrbrclass.rrlist where c.field == "Bokslutsdispositioner" select c).First();
            periodiseringsfond = (from c in rrbrclass.brlist where c.field == "Periodiseringsfonder" select c).First();
            skatt = (from c in rrbrclass.rrlist where c.field == "Skatter" select c).First();

        }
    }
}

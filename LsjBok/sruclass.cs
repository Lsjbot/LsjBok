using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LsjBok
{
    public class sruclass : kontogruppclass
    {
        public static Dictionary<int, sruclass> srudict = new Dictionary<int, sruclass>();

        public int fieldcode = 0;
        public string Ink2rad = "";
        public bool onlyplus = false;
        public bool onlyminus = false;
        public bool special = false;
        public int fromfield = -1;
        public int fromsign = 1;
        public int grupp = -1;
        public int displaysign = 0; //0 = use original sign, >0 = always positive, <0 = reverse original sign
        public int addsign = 0; //0 = use original sign, >0 = always positive, <0 = reverse original sign

        public static string onlyminusstring = "(Om netto -)";
        public static string onlyplusstring = "(Om netto +)";

        public sruclass(int field, string rad, string desc, string kontolist, int fromf, int froms,int grp, int dispsg, int addsg)
        {
            fieldcode = field;
            Ink2rad = rad;
            description = desc;
            fromfield = fromf;
            fromsign = froms;
            grupp = grp;
            displaysign = dispsg;
            addsign = addsg;
            parsekontolist(kontolist);
        }

        public decimal sumsru(int fiscalyear)
        {
            if (special)
            {
                return specialsumsru(fiscalyear);
            }
            else if (fromfield > 0)
            {
                return fromsign * srudict[fromfield].sumsru(fiscalyear);
            }
            else
            {
                decimal amount = sumkonto(fiscalyear);
                if (onlyplus)
                {
                    if (amount > 0)
                        return amount;
                    else
                        return 0;
                }
                else if (onlyminus)
                {
                    if (amount < 0)
                        return amount;
                    else
                        return 0;
                }
                else
                    return amount;
            }
        }

        public static decimal signfix(decimal amount, int signcode)
        {
            if (signcode > 0)
                return Math.Abs(amount);
            else if (signcode < 0)
                return -amount;
            return amount;
        }

        public decimal sumsru_addsign(int fiscalyear)
        {
            decimal amount = sumsru(fiscalyear);
            if (addsign > 0)
                return Math.Abs(amount);
            else if (addsign < 0)
                return -amount;
            return amount;
        }
        public decimal sumsru_displaysign(int fiscalyear)
        {
            decimal amount = sumsru(fiscalyear);
            if (displaysign > 0)
                return Math.Abs(amount);
            else if (displaysign < 0)
                return -amount;
            return amount;
        }

        public decimal specialsumsru(int fiscalyear)
        {
            switch (fieldcode)
            {
                case 7654: //schablonintäkt periodiseringsfond
                    decimal IB = rrbrclass.periodiseringsfond.sumkonto_IB(fiscalyear);
                    int year = fiscalclass.getyear(fiscalyear);
                    decimal interest = (decimal)1.96;
                    switch (year)
                    {
                        case 2024: 
                            interest = (decimal)2.62;
                            break;
                        case 2025:
                            interest = (decimal)1.96;
                            break;
                    }
                    return Math.Abs(IB * interest / 100);
                    //break;
                case 7667: //uppräkning återförd periodiseringsfond
                    decimal sum = 0;
                    var q = from c in common.db.Rad
                            where c.KontoKonto.Number == 8819
                            where c.VerVer.Year == fiscalyear
                            select c;
                    foreach (Rad rr in q)
                    {
                        foreach (Rad rr2 in rr.VerVer.Rad)
                        {
                            if (rr2.KontoKonto.Konto2 == 21)
                            {
                                decimal amount7667 = rr2.Amount;
                                int yy = rr2.KontoKonto.Number % 10;
                                int yynow = DateTime.Now.Year % 10;
                                int decadenow = 10 * (DateTime.Now.Year / 10);
                                int year2;
                                if (yy < yynow)
                                    year2 = decadenow + yy;
                                else
                                    year2 = (decadenow - 1) + yy;
                                if (year2 < 2019)
                                    sum += (decimal)0.06 * amount7667;
                                else if (year2 < 2021)
                                    sum += (decimal)0.04 * amount7667;
                            }
                        }
                    }
                    return sum;
                    //break;
                    //srudict.Add(7420, new sruclass(7420, "3.21", "Återföring av periodiseringsfond", "8810 (Om netto +), 8819", -1, 1, 3, 1, -1));
                    //srudict.Add(7525, new sruclass(7525, "3.22", "Avsättning till periodiseringsfond", "8810 (Om netto -), 8811", -1, 1, 3, 1, -1));
                case 7420:
                    decimal ub8810 = kontoclass.getUB(8810, fiscalyear);
                    decimal amount7420 = kontoclass.getUB(8819, fiscalyear);
                    if (ub8810 > 0)
                        amount7420 += ub8810;
                    return amount7420;
                case 7525:
                    decimal ub8810b = kontoclass.getUB(8810, fiscalyear);
                    decimal amount7525 = kontoclass.getUB(8811, fiscalyear);
                    if (ub8810b < 0)
                        amount7525 += ub8810b;
                    return amount7525;
                case 7670:
                    decimal s4plus = sum4(fiscalyear);
                    if (s4plus > 0)
                        return s4plus;
                    else
                        return 0;
                case 7770:
                    decimal s4minus = sum4(fiscalyear);
                    if (s4minus < 0)
                        return -s4minus;
                    else
                        return 0;

                case 7764:
                case 7668:
                case 7665:
                    return 0;
                default:
                    common.memo("sru special " + fieldcode);
//sru special 7755
//sru special 7656
//sru special 7756
//sru special 7657
//sru special 7658
//sru special 7757
//sru special 7758
//sru special 7659
//sru special 7660
//sru special 7759
//sru special 7666
//sru special 7765
//sru special 7661
//sru special 7760
//sru special 7761
//sru special 7662
//sru special 7663
//sru special 7762
//sru special 7763
//sru special 7664
//sru special 7670
//sru special 7770
//sru special 8020
//sru special 8021
//sru special 8023
//sru special 8026
                    break;

            }
            return 0;
        }

        public static decimal sum4(int fiscalyear)
        {
            decimal s4 = 0;
            var q = from c in srudict.Keys
                    where c < 8000
                    where srudict[c].grupp == 4
                    select c;

            foreach (int fc in q)
            {
                if (fc == 7670 || fc == 7770)
                    continue;
                s4 += srudict[fc].sumsru_addsign(fiscalyear);
                //s4 += tbdict[fc].Text
            }

            return s4;
        }

        public static char hyphenchar = '-';
        public void parsekontolist(string s)
        {
            string s1 = s;
            if (String.IsNullOrEmpty(s1))
            {
                if (fromfield < 0)
                    special = true;
                return;
            }
            if (s1.EndsWith(onlyplusstring))
            {
                this.onlyplus = true;
            }
            else if (s1.Contains(onlyplusstring))
            {
                special = true;
            }

            if (s1.EndsWith(onlyminusstring))
            {
                this.onlyminus = true;
            }
            else if (s1.Contains(onlyminusstring))
            {
                special = true;
            }
            s1 = s1.Replace(onlyplusstring, "");
            s1 = s1.Replace(onlyminusstring, "");

            string[] w = s1.Split(',');
            foreach (string sss in w)
            {
                string ss = sss.Trim();
                if (ss.Contains("xx"))
                {
                    if (ss.Contains(hyphenchar))
                    {
                        string[] ww = ss.Split(hyphenchar);
                        if (ww.Length != 2)
                        {
                            common.memo("Parse error " + s);
                        }
                        else
                        {
                            int k1 = util.tryconvert(ww[0].Trim().Trim('x'));
                            int k2 = util.tryconvert(ww[1].Trim().Trim('x'));
                            for (int k = k1; k <= k2; k++)
                            {
                                this.konto2list.Add(k);
                            }
                        }
                    }
                    else
                        this.konto2list.Add(util.tryconvert(ss.Replace("xx", "")));
                }
                else if (ss.Contains("x"))
                {
                    if (ss.Contains(hyphenchar))
                    {
                        string[] ww = ss.Split(hyphenchar);
                        if (ww.Length != 2)
                        {
                            common.memo("Parse error " + s);
                        }
                        else
                        {
                            int k1 = util.tryconvert(ww[0].Trim().Trim('x'));
                            int k2 = util.tryconvert(ww[1].Trim().Trim('x'));
                            for (int k = k1; k <= k2; k++)
                            {
                                this.konto3list.Add(k);
                            }
                        }
                    }
                    else
                        this.konto3list.Add(util.tryconvert(ss.Replace("x", "")));
                }
                else if (ss.Contains(hyphenchar))
                {
                    string[] ww = ss.Split(hyphenchar);
                    if (ww.Length != 2)
                    {
                        common.memo("Parse error " + s);
                    }
                    else
                    {
                        int k1 = util.tryconvert(ww[0].Trim());
                        int k2 = util.tryconvert(ww[1].Trim());
                        for (int k=k1;k<=k2;k++)
                        {
                            this.konto4list.Add(k);
                        }
                    }

                }
                else
                {
                    int k = util.tryconvert(ss.Trim());
                    if (k > 0)
                        this.konto4list.Add(k);
                    else
                        special = true;
                }
            }
        }

        public static decimal sum_skattejust(int fiscalyear)
        {
            decimal sum = 0;

            foreach (sruclass sru in (from c in srudict.Values where c.grupp == 4 select c))
            {
                if (sru.fieldcode == 7650)
                    continue;
                if (sru.fieldcode == 7750)
                    continue;
                sum += sru.sumsru_addsign(fiscalyear);

            }

            return sum;
        }
        public static void fill_srulist()
        {
            if (srudict.Count > 0)
                return;

            //Från SRU INK2_P1_intervall-241119.xlsx

            srudict.Add(7201, new sruclass(7201, "2.1", "Koncessioner, patent, licenser, varumärken, hyresrätter, goodwill och liknande rättigheter", "1000-1087, 1089-1099", -1, 1, 2, 1, 0));
            srudict.Add(7202, new sruclass(7202, "2.2", "Förskott avseende immateriella anläggningstillgångar", "1088", -1, 1, 2, 1, 0));


            srudict.Add(7214, new sruclass(7214, "2.3", "Byggnader och mark", "1100-1119, 1130-1179, 1190-1199", -1, 1, 2, 1, 0));
            srudict.Add(7215, new sruclass(7215, "2.4 ", "Maskiner, inventarier och övriga materiella anläggningstillgångar", "1200-1279, 1290-1299", -1, 1, 2, 1, 0));
            srudict.Add(7216, new sruclass(7216, "2.5", "Förbättringsutgifter på annans fastighet", "112x", -1, 1, 2, 1, 0));
            srudict.Add(7217, new sruclass(7217, "2.6", "Pågående nyanläggningar och förskott avseende materiella anläggningstillgångar", "118x, 128x", -1, 1, 2, 1, 0));


            srudict.Add(7230, new sruclass(7230, "2.7", "Andelar i koncernföretag", "131x", -1, 1, 2, 1, 0));
            srudict.Add(7231, new sruclass(7231, "2.8", "Andelar i intresseföretag och gemensamt styrda företag", "1330-1335, 1338-1339", -1, 1, 2, 1, 0));
            srudict.Add(7233, new sruclass(7233, "2.9", "Ägarintresse i övriga företag och andra långfristiga värdepappersinnehav", "135x, 1336, 1337", -1, 1, 2, 1, 0));
            srudict.Add(7232, new sruclass(7232, "2.10", "Fordringar hos koncern-, intresse- och gemensamt styrda företag", "132x, 1340-1345, 1348-1349", -1, 1, 2, 1, 0));
            srudict.Add(7234, new sruclass(7234, "2.11", "Lån till delägare eller närstående", "136x", -1, 1, 2, 1, 0));
            srudict.Add(7235, new sruclass(7235, "2.12", "Fordringar hos övriga företag som det finns ett ett ägarintresse i och Andra långfristiga fordringar", "137x, 138x, 1346, 1347", -1, 1, 2, 1, 0));




            srudict.Add(7241, new sruclass(7241, "2.13", "Råvaror och förnödenheter", "141x, 142x", -1, 1, 2, 1, 0));
            srudict.Add(7242, new sruclass(7242, "2.14", "Varor under tillverkning", "144x", -1, 1, 2, 1, 0));
            srudict.Add(7243, new sruclass(7243, "2.15", "Färdiga varor och handelsvaror", "145x, 146x", -1, 1, 2, 1, 0));
            srudict.Add(7244, new sruclass(7244, "2.16", "Övriga lagertillgångar", "149x", -1, 1, 2, 1, 0));
            srudict.Add(7245, new sruclass(7245, "2.17", "Pågående arbeten för annans räkning", "147x", -1, 1, 2, 1, 0));
            srudict.Add(7246, new sruclass(7246, "2.18", "Förskott till leverantörer", "148x", -1, 1, 2, 1, 0));


            srudict.Add(7251, new sruclass(7251, "2.19", "Kundfordringar", "151x–155x, 158x", -1, 1, 2, 1, 0));
            srudict.Add(7252, new sruclass(7252, "2.20", "Fordringar hos koncern-, intresse- och gemensamt styrda företag", "156x, 1570-1572, 1574-1579, 166x, 1671-1672, 1674-1679", -1, 1, 2, 1, 0));
            srudict.Add(7261, new sruclass(7261, "2.21", "Fordringar hos övriga företag som det finns ett ägarintresse i och Övriga fordringar", "161x, 163x-165x, 168x-169x, 1573, 1673", -1, 1, 2, 1, 0));
            srudict.Add(7262, new sruclass(7262, "2.22", "Upparbetad men ej fakturerad intäkt", "162x", -1, 1, 2, 1, 0));
            srudict.Add(7263, new sruclass(7263, "2.23", "Förutbetalda kostnader och upplupna intäkter", "17xx", -1, 1, 2, 1, 0));


            srudict.Add(7270, new sruclass(7270, "2.24", "Andelar i koncernföretag", "186x", -1, 1, 2, 1, 0));
            srudict.Add(7271, new sruclass(7271, "2.25", "Övriga kortfristiga placeringar", "1800-1859, 1870-1899", -1, 1, 2, 1, 0));


            srudict.Add(7281, new sruclass(7281, "2.26", "Kassa, bank och redovisningsmedel", "19xx", -1, 1, 2, 1, 0));




            srudict.Add(7301, new sruclass(7301, "2.27", "Bundet eget kapital", "208x", -1, 1, 2, 1, 0));
            srudict.Add(7302, new sruclass(7302, "2.28", "Fritt eget kapital", "209x", -1, 1, 2, 1, 0));




            srudict.Add(7321, new sruclass(7321, "2.29", "Periodiseringsfonder", "211x-213x", -1, 1, 2, 1, 0));
            srudict.Add(7322, new sruclass(7322, "2.30", "Ackumulerade överavskrivningar", "215x", -1, 1, 2, 1, 0));
            srudict.Add(7323, new sruclass(7323, "2.31", "Övriga obeskattade reserver", "216x-219x", -1, 1, 2, 1, 0));


            srudict.Add(7331, new sruclass(7331, "2.32", "Avsättningar för pensioner och liknande förpliktelser enligt lagen (1967:531) om tryggande av pensionsutfästelserr m.m.", "221x", -1, 1, 2, 1, 0));
            srudict.Add(7332, new sruclass(7332, "2.33", "Övriga avsättningar för pensioner och liknande förpliktelser", "223x", -1, 1, 2, 1, 0));
            srudict.Add(7333, new sruclass(7333, "2.34", "Övriga avsättningar", "2220-2229, 2240-2299", -1, 1, 2, 1, 0));




            srudict.Add(7350, new sruclass(7350, "2.35", "Obligationslån", "231x-232x", -1, 1, 2, 1, 0));
            srudict.Add(7351, new sruclass(7351, "2.36", "Checkräkningskredit", "233x", -1, 1, 2, 1, 0));
            srudict.Add(7352, new sruclass(7352, "2.37", "Övriga skulder till kreditinstitut", "234x-235x", -1, 1, 2, 1, 0));
            srudict.Add(7353, new sruclass(7353, "2.38", "Skulder till koncern-, intresse- och gemensamt styrda företag", "2360- 2372, 2374-2379", -1, 1, 2, 1, 0));
            srudict.Add(7354, new sruclass(7354, "2.39", "Skulder till övriga företag som det finns ett ägarintresse i och övriga skulder", "238x-239x, 2373", -1, 1, 2, 1, 0));


            srudict.Add(7360, new sruclass(7360, "2.40", "Checkräkningskredit", "248x", -1, 1, 2, 1, 0));
            srudict.Add(7361, new sruclass(7361, "2.41", "Övriga skulder till kreditinstitut", "241x", -1, 1, 2, 1, 0));
            srudict.Add(7362, new sruclass(7362, "2.42", "Förskott från kunder", "242x", -1, 1, 2, 1, 0));
            srudict.Add(7363, new sruclass(7363, "2.43", "Pågående arbeten för annans räkning", "243x", -1, 1, 2, 1, 0));
            srudict.Add(7364, new sruclass(7364, "2.44", "Fakturerad men ej upparbetad intäkt", "245x", -1, 1, 2, 1, 0));
            srudict.Add(7365, new sruclass(7365, "2.45", "Leverantörsskulder", "244x", -1, 1, 2, 1, 0));
            srudict.Add(7366, new sruclass(7366, "2.46", "Växelskulder", "2492", -1, 1, 2, 1, 0));
            srudict.Add(7367, new sruclass(7367, "2.47", "Skulder till koncern-, intresse- och gemensamt styrda företag", "2460-2472, 2474-2479, 2874-2879", -1, 1, 2, 1, 0));
            srudict.Add(7369, new sruclass(7369, "2.48", "Skulder till övriga företag som det finns ett ägarintresse i och Övriga skulder", "2490-2491, 2493-2499, 2600-2859, 2880-2899", -1, 1, 2, 1, 0));
            srudict.Add(7368, new sruclass(7368, "2.49", "Skatteskulder", "25xx", -1, 1, 2, 0, 0));
            srudict.Add(7370, new sruclass(7370, "2.50", "Upplupna kostnader och förutbetalda intäkter", "29xx", -1, 1, 2, 1, 0));




            srudict.Add(7410, new sruclass(7410, "3.1", "Nettoomsättning", "30xx-37xx", -1, 1, 3, 1, -1));
            srudict.Add(7411, new sruclass(7411, "3.2", "Förändring av lager av produkter i arbete, färdiga varor och pågående arbete för annans räkning", "4900-4909, 4930-4959, 4970-4979, 4990-4999 (Om netto +)", -1, 1, 3, 1, -1));
            srudict.Add(7510, new sruclass(7510, "3.2", "Förändring av lager av produkter i arbete, färdiga varor och pågående arbete för annans räkning", "4900-4909, 4930-4959, 4970-4979, 4990-4999 (Om netto -)", -1, 1, 3, 1, -1));
            srudict.Add(7412, new sruclass(7412, "3.3", "Aktiverat arbete för egen räkning", "38xx", -1, 1, 3, 1, -1));
            srudict.Add(7413, new sruclass(7413, "3.4", "Övriga rörelseintäkter", "39xx", -1, 1, 3, 1, -1));
            srudict.Add(7511, new sruclass(7511, "3.5", "Råvaror och förnödenheter", "40xx-47xx, 4910-4920", -1, 1, 3, 1, -1));
            srudict.Add(7512, new sruclass(7512, "3.6", "Handelsvaror", "40xx-47xx, 496x, 498x", -1, 1, 3, 1, -1));
            srudict.Add(7513, new sruclass(7513, "3.7", "Övriga externa kostnader", "50xx-69xx", -1, 1, 3, 1, -1));
            srudict.Add(7514, new sruclass(7514, "3.8", "Personalkostnader", "70xx-76xx", -1, 1, 3, 1, -1));
            srudict.Add(7515, new sruclass(7515, "3.9", "Av- och nedskrivningar av materiella och immateriella anläggningstillgångar", "7700-7739, 7750-7789, 7800-7899", -1, 1, 3, 1, -1));
            srudict.Add(7516, new sruclass(7516, "3.10", "Nedskrivningar av omsättningstillgångar utöver normala nedskrivningar", "774x, 779x", -1, 1, 3, 1, -1));
            srudict.Add(7517, new sruclass(7517, "3.11", "Övriga rörelsekostnader", "79xx", -1, 1, 3, 1, -1));
            srudict.Add(7414, new sruclass(7414, "3.12", "Resultat från andelar i koncernföretag", " 8000-8069, 8090-8099 (Om netto +)", -1, 1, 3, 1, -1));
            srudict.Add(7518, new sruclass(7518, "3.12", "Resultat från andelar i koncernföretag", "8000-8069,8090-8099 (Om netto -)", -1, 1, 3, 1, -1));
            srudict.Add(7415, new sruclass(7415, "3.13", "Resultat från andelar i intresseföretag och gemensamt styrda företag", "8100-8112, 8114-8117, 8119-8122, 8124-8132, 8134-8169, 8190-8199 (Om netto +)", -1, 1, 3, 1, -1));
            srudict.Add(7519, new sruclass(7519, "3.13", "Resultat från andelar i intresseföretag och gemensamt styrda företag", "8100-8112, 8114-8117, 8119-8122, 8124-8132, 8134-8169, 8190-8199 (Om netto -)", -1, 1, 3, 1, -1));
            srudict.Add(7423, new sruclass(7423, "3.14", "Resultat från övriga företag som det finns ett ägarintresse i", "8113, 8118, 8123, 8133 (Om netto +)", -1, 1, 3, 1, -1));
            srudict.Add(7530, new sruclass(7530, "3.14", "Resultat från övriga företag som det finns ett ägarintresse i", " 8113, 8118, 8123, 8133 (Om netto -)", -1, 1, 3, 1, -1));
            srudict.Add(7416, new sruclass(7416, "3.15", "Resultat från övriga anläggningstillgångar", " 8200-8269, 8290-8299 (Om netto +)", -1, 1, 3, 1, -1));
            srudict.Add(7520, new sruclass(7520, "3.15", "Resultat från övriga anläggningstillgångar", "8200-8269, 8290-8299 (Om netto -)", -1, 1, 3, 1, -1));
            srudict.Add(7417, new sruclass(7417, "3.16", "Övriga ränteintäkter och liknande resultatposter", "8300-8369, 8390-8399", -1, 1, 3, 1, -1));
            srudict.Add(7521, new sruclass(7521, "3.17", "Nedskrivningar av finansiella anläggningstillgångar och kortfristiga placeringar", "807x, 808x, 817x, 818x, 827x, 828x, 837x, 838x", -1, 1, 3, 1, -1));
            srudict.Add(7522, new sruclass(7522, "3.18", "Räntekostnader och liknande resultatposter", "84xx", -1, 1, 3, 1, -1));
            srudict.Add(7524, new sruclass(7524, "3.19", "Lämnade koncernbidrag", "883x", -1, 1, 3, 1, -1));
            srudict.Add(7419, new sruclass(7419, "3.20", "Mottagna koncernbidrag", "882x", -1, 1, 3, 1, -1));
            srudict.Add(7420, new sruclass(7420, "3.21", "Återföring av periodiseringsfond", "8810 (Om netto +), 8819", -1, 1, 3, 1, -1));
            srudict.Add(7525, new sruclass(7525, "3.22", "Avsättning till periodiseringsfond", "8810 (Om netto -), 8811", -1, 1, 3, 1, -1));
            srudict.Add(7421, new sruclass(7421, "3.23", "Förändring av överavskrivningar", "885x (Om netto +)", -1, 1, 3, 1, -1));
            srudict.Add(7526, new sruclass(7526, "3.23", "Förändring av överavskrivningar", "885x (Om netto -)", -1, 1, 3, 1, -1));
            srudict.Add(7422, new sruclass(7422, "3.24", "Övriga bokslutsdispositioner", "886x-889x (Om netto +)", -1, 1, 3, 1, -1));
            srudict.Add(7527, new sruclass(7527, "3.24", "Övriga bokslutsdispositioner", "886x-889x, 884x (Om netto -)", -1, 1, 3, 1, -1));
            srudict.Add(7528, new sruclass(7528, "3.25", "Skatt på årets resultat", "8900-8989", -1, 1, 3, 1, -1));
            srudict.Add(7450, new sruclass(7450, "3.26", "Årets resultat, vinst (flyttas till p. 4.1)  (+)", "899x (Om netto +)", -1, 1, 3, 1, -1));
            srudict.Add(7550, new sruclass(7550, "3.27", "Årets resultat, förlust (flyttas till p. 4.2) (-)", "899x (Om netto -)", -1, 1, 3, 1, -1));



            //srudict.Add(Härifrån är det egen tolkning, hittar ingen officiell kopplingsfil:, new sruclass(Härifrån är det egen tolkning, hittar ingen officiell kopplingsfil:, "", "", "",,,,,));


            srudict.Add(7650, new sruclass(7650, "4.1", "Årets resultat, vinst", "", 7450, 1, 4, 1, 1));
            srudict.Add(7750, new sruclass(7750, "4.2", "Årets resultat, förlust", "", 7550, 1, 4, 1, -1));
            srudict.Add(7651, new sruclass(7651, "4.3a", "Bokförda kostnader som inte dras av a: Skatt på årets resultat", "", 7528, 1, 4, 1, 1));
            srudict.Add(7652, new sruclass(7652, "4.3b", "Bokförda kostnader som inte dras av b: Nedskrivning av finansiella tillgångar", "807x,817x,827x,8370", -1, 1, 4, 1, 1));
            srudict.Add(7653, new sruclass(7653, "4.3c", "Bokförda kostnader som inte dras av a: Andra bokförda kostnader", "5099,5199,6072,6342,6982,6992,7622,7623,7632,8423", -1, 1, 4, 1, 1));

            srudict.Add(7751, new sruclass(7751, "4.4a", "Kostnader som ska dras av men som inte ingår i det redovisade resultatet a. Lämnade koncernbidrag", "", 7524, 1, 4, 1, 0));
            srudict.Add(7764, new sruclass(7764, "4.4b", "Kostnader som ska dras av men som inte ingår i det redovisade resultatet b. Andra ej bokförda kostnader", "", -1, 1, 4, 1, 0));
            srudict.Add(7752, new sruclass(7752, "4.5a", "Bokförda intäkter som inte ska tas upp: a. Ackordsvinster", "3995,8491", -1, 1, 4, 1, -1));
            srudict.Add(7753, new sruclass(7753, "4.5b", "Bokförda intäkter som inte ska tas upp: b. Utdelning", "8010,8012,8110-8113,8210,8212", -1, 1, 4, 1, -1));
            srudict.Add(7754, new sruclass(7754, "4.5c", "Bokförda intäkter som inte ska tas upp: c. Andra bokförda intäkter", "8254,8314", -1, 1, 4, 1, -1));
            srudict.Add(7654,new sruclass(7654,"4.6a","Intäkter som ska tas upp men som inte ingår i det redovisade resultatet: a. Beräknad schablonintäkt på kvarvarande periodiseringsfonder vid beskattningsårets ingång ","special",-1,1,4,1,0));
            srudict.Add(7655, new sruclass(7655, "4.6c", "Intäkter som ska tas upp men som inte ingår i det redovisade resultatet:  b. Mottagna koncernbidrag", "8820", 7419, 1, 4, 1, 0));
            srudict.Add(7668, new sruclass(7668, "4.6b", "Intäkter som ska tas upp men som inte ingår i det redovisade resultatet: c. Fondandelar schablonintäkt", "", -1, 1, 4, 1, 0));
            srudict.Add(7667, new sruclass(7667, "4.6d", "Intäkter som ska tas upp men som inte ingår i det redovisade resultatet: d. Uppräknat belopp vid återföring av periodiseringsfond", "special", -1, 1, 4, 1, 0));
            srudict.Add(7665, new sruclass(7665, "4.6e", "Intäkter som ska tas upp men som inte ingår i det redovisade resultatet: d. Andra ej bokförda intäkter", "", -1, 1, 4, 1, 0));
            srudict.Add(7755, new sruclass(7755, "4.7a", "Avyttring av delägarrätter: a. Bokförd vinst", "812x (Om netto +)", -1, 1, 4, 1, 0));
            srudict.Add(7656, new sruclass(7656, "4.7b", "Avyttring av delägarrätter: b. Bokförd förlust", "812x (Om netto -)", -1, 1, 4, 1, 0));
            srudict.Add(7756, new sruclass(7756, "4.7c", "Avyttring av delägarrätter: c. Uppskov med kapitalvinst enligt blankett N4", "", -1, 1, 4, 1, 0));
            srudict.Add(7657, new sruclass(7657, "4.7d", "Avyttring av delägarrätter: d. Återfört uppskov med kapitalvinst enligt blankett N4", "", -1, 1, 4, 1, 0));
            srudict.Add(7658, new sruclass(7658, "4.7e", "Avyttring av delägarrätter: e. Kapitalvinst för beskattningsåret", "", -1, 1, 4, 1, 0));
            srudict.Add(7757, new sruclass(7757, "4.7f", "Avyttring av delägarrätter: f. Kapitalförlust som ska dra av", "", -1, 1, 4, 1, 0));
            srudict.Add(7758, new sruclass(7758, "4.8a", "Andel i handelsbolag (inkl. avyttring): a. Bokförd intäkt/vinst", "", -1, 1, 4, 1, 0));
            srudict.Add(7659, new sruclass(7659, "4.8b", "Andel i handelsbolag (inkl. avyttring): b. Skattemässig överskott enligt N3B/kapitalvinst", "", -1, 1, 4, 1, 0));
            srudict.Add(7660, new sruclass(7660, "4.8c", "Andel i handelsbolag (inkl. avyttring): c. Bokförd kostnad/förlust          ", "", -1, 1, 4, 1, 0));

            srudict.Add(7759, new sruclass(7759, "4.8d", "Andel i handelsbolag (inkl. avyttring): d. Skattemässig underskott enligt N3B/kapitalförlust         ", "", -1, 1, 4, 1, 0));

            srudict.Add(7666, new sruclass(7666, "4.9+", "Skattemässig justering av bokfört resultat för avskrivningar på byggnader och annan fast egendom samt restvärdesavskrivning på maskiner och inventarier (+) ", "", -1, 1, 4, 1, 0));

            srudict.Add(7765, new sruclass(7765, "4.9-", "Skattemässig justering av bokfört resultat för avskrivningar på byggnader och annan fast egendom samt restvärdesavskrivning på maskiner och inventarier (-) ", "", -1, 1, 4, 1, 0));
            srudict.Add(7661, new sruclass(7661, "4.10+", "Skattemässig korrigering av bokfört resultat vid avyttring av näringsfastighet och näringsbostadsrätt: +      ", "", -1, 1, 4, 1, 0));
            srudict.Add(7760, new sruclass(7760, "4.10-", "Skattemässig korrigering av bokfört resultat vid avyttring av näringsfastighet och näringsbostadsrätt: -      ", "", -1, 1, 4, 1, 0));
            srudict.Add(7761, new sruclass(7761, "4.11", "Skogs-/substansminskningsavdrag (specificeras på blankett N8)", "", -1, 1, 4, 1, 0));

            srudict.Add(7662, new sruclass(7662, "4.12", "Återföringar vid avyttring av fastighet t.ex. värdeminskningsavdrag, skogsavdrag och substansminskningsavdrag...    ", "", -1, 1, 4, 1, 0));

            srudict.Add(7663, new sruclass(7663, "4.13+", "Andra skattemässiga justeringar av resultatet: +        ", "", -1, 1, 4, 1, 0));
            srudict.Add(7762, new sruclass(7762, "4.13-", "Andra skattemässiga justeringar av resultatet: -         ", "", -1, 1, 4, 1, 0));
            srudict.Add(7763, new sruclass(7763, "4.14a. Outnyttjat underskott från föregående år", "Underskott: a. Outnyttjat underskott från föregående år         ", "", -1, 1, 4, 1, -1));
            srudict.Add(7664, new sruclass(7664, "4.14b", "Underskott: b. Reduktion av underskott med hänsyn till exempelvis ägarförändring eller ackord         ", "", -1, 1, 4, 1, 0));
            srudict.Add(7670, new sruclass(7670, "4.15", "Överskott (flyttas till p. 1.1 på sid. 1)         ", "special", -1, 1, 4, 1, 0));
            srudict.Add(7770, new sruclass(7770, "4.16", "Underskott (flyttas till p. 1.2 på sid. 1)         ", "special", -1, 1, 4, 1, 0));
            srudict.Add(8020, new sruclass(8020, "4.17", "Årets begärda och tidigare års medgivna värdeminskningsavdrag på byggnader...         ", "", -1, 1, 4, 1, 0));
            srudict.Add(8021, new sruclass(8021, "4.18", "Årets begärda och tidigare års medgivna värdeminskningsavdrag på markanläggningar...         ", "", -1, 1, 4, 1, 0));
            srudict.Add(8023, new sruclass(8023, "4.19", "Vid restvärdesavskrivning: återförda belopp för av- och nedskrivning, försäljning, utrangering         ", "", -1, 1, 4, 1, 0));
            srudict.Add(8026, new sruclass(8026, "4.20", "Lån från aktieägare (fysisk person) vid räkenskapsårets utgång         ", "", -1, 1, 4, 1, 0));

        }
    }
}

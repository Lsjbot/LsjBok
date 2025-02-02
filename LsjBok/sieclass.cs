using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using System.Windows.Forms;

namespace LsjBok
{
    class sieclass
    {
        public delegate void MemoDelegate(string s);

        static Dictionary<string, string> funnychars = new Dictionary<string, string>()
        {
            {"\u0094","ö" },
            {"\u0084","ä" },
            {"\u0086","å" },
            {"\u0099","Ö" },
            {"\u008e","Ä" },
            {"\u008f","Å" },
        };

        public static void read_SIE(string fn,MemoDelegate memo)
        {
            using (
                    var sr = new StreamReader(
                    new FileStream(fn, FileMode.Open, FileAccess.Read),
                    Encoding.GetEncoding("iso-8859-1")
                  ))
            {
                String format = "PC8";
                string sietyp = "";
                Company cc = new Company();
                cc.Companytype = 1;
                Dictionary<int, Fiscalyear> fiscdict = new Dictionary<int, Fiscalyear>();
                List<Ver> verlist = new List<Ver>();
                List<Rad> radlist = new List<Rad>();
                List<int> usedkonto = new List<int>();
                List<Konto> kontolist = new List<Konto>();
                Dictionary<int, string> siekontodict = new Dictionary<int, string>();
                Dictionary<int, List<int>> srudict = new Dictionary<int, List<int>>();
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine().Trim(new char[] { ' ', '\t' });
                    //memo("The encoding used was " + sr.CurrentEncoding);
                    if (format == "PC8")
                    {
                        foreach (string f in funnychars.Keys)
                            if (line.Contains(f))
                                line = line.Replace(f, funnychars[f]);
                    }
                    //line = line.Replace("\u0094", "ö");
                    //if (line.Contains("ndamål"))
                    //    memo(line);
                    string[] words = util.splitcsv(line, ' ', '"', '"');
                    switch (words[0])
                    {
                        //Identifikationsposter:
                        case "#FLAGGA":
                            break;
                        case "#PROGRAM":
                            break;
                        case "#FORMAT":
                            format = words[1];
                            break;
                        case "#GEN":
                            break;
                        case "#SIETYP":
                            sietyp = words[1];
                            break;
                        case "#PROSA":
                            break;
                        case "#FTYP":
                            var qftyp = (from c in common.db.Companytype where c.Shortname == words[1] select c).FirstOrDefault();
                            if (qftyp == null)
                            {
                                memo("Okänd företagstyp " + words[1]);
                                qftyp = (from c in common.db.Companytype where c.Shortname == "AB" select c).FirstOrDefault();
                            }
                            cc.Companytype = qftyp.Id;
                            break;
                        case "#FNR":
                            break;
                        case "#ORGNR":
                            //if (!util.validate_orgnr(words[1]))
                            //    memo("Ogiltigt orgnr " + words[1]);
                            //else
                            //{
                            //    if (words[1].Contains('-'))
                            //        cc.Orgnr = words[1];
                            //    else
                            //        cc.Orgnr = words[1].Insert(6, "-");
                            //}
                            cc.Orgnr = "1234567890";
                            break;
                        case "#BKOD":
                            break;
                        case "#ADRESS":
                            cc.Address = line.Replace("#ADRESS", "");
                            break;
                        case "#FNAMN":
                            //cc.Name = words[1].Trim('"');
                            cc.Name = "TEST";
                            break;
                        case "#RAR":
                            int fnr = util.tryconvert(words[1]);
                            Fiscalyear fy = new Fiscalyear();
                            DateTime? start = util.parsedate(words[2]);
                            DateTime? end = util.parsedate(words[3]);
                            if (start == null || end == null)
                                memo("Ogiltigt räkenskapsår " + line);
                            else
                            {
                                fy.Startdate = (DateTime)start;
                                fy.Enddate = (DateTime)end;
                                fiscdict.Add(fnr, fy);
                            }
                            break;
                        case "#TAXAR":
                            break;
                        case "#OMFATTN":
                            break;
                        case "#KPTYP":
                            if (!words[1].StartsWith("BAS"))
                                memo("Okänd kontoplan " + words[1]);
                            break;
                        case "#VALUTA":
                            if (words[1] != "SEK")
                                memo("Okänd valuta " + words[1]);
                            break;

                        //Kontoplansposter:

                        case "#KONTO":
                            int k = util.tryconvert(words[1]);
                            if (siekontodict.ContainsKey(k))
                                memo("Konto " + k + " dublett i filen");
                            siekontodict.Add(k, words[2].Trim('"'));
                            break;
                        case "#SRU":
                            int ksru = util.tryconvert(words[1]);
                            int ssru = util.tryconvert(words[2]);
                            if (!srudict.ContainsKey(ssru))
                                srudict.Add(ssru, new List<int>());
                            srudict[ssru].Add(ksru);
                            break;
                        case "#KTYP":
                            break;
                        case "#ENHET":
                            break;
                        case "#DIM":
                            break;
                        case "#UNDERDIM":
                            break;
                        case "#OBJEKT":
                            break;
                        case "#OIB":
                            break;
                        case "#OUB":
                            break;
                        case "#IB":
                            int irar = util.tryconvert(words[1]);
                            int ikk = util.tryconvert(words[2]);
                            decimal iamount = util.tryconvertdecimal(words[3]);
                            var ikonto = (from c in kontolist where c.Year == irar where c.Number == ikk select c).FirstOrDefault();
                            if (ikonto == null)
                            {
                                ikonto = new Konto();
                                ikonto.Number = ikk;
                                if (siekontodict.ContainsKey(ikk))
                                    ikonto.Name = siekontodict[ikk];
                                ikonto.Year = irar;
                                ikonto.IB = iamount;
                                kontolist.Add(ikonto);
                            }
                            else
                            {
                                ikonto.IB = iamount;
                            }
                            break;
                        case "#UB":
                            int urar = util.tryconvert(words[1]);
                            int ukk = util.tryconvert(words[2]);
                            decimal uamount = util.tryconvertdecimal(words[3]);
                            var ukonto = (from c in kontolist where c.Year == urar where c.Number == ukk select c).FirstOrDefault();
                            if (ukonto == null)
                            {
                                ukonto = new Konto();
                                ukonto.Number = ukk;
                                if (siekontodict.ContainsKey(ukk))
                                    ukonto.Name = siekontodict[ukk];
                                ukonto.Year = urar;
                                ukonto.UB = uamount;
                                kontolist.Add(ukonto);
                            }
                            else
                            {
                                ukonto.UB = uamount;
                            }
                            break;
                        case "#RES":
                            int rrar = util.tryconvert(words[1]);
                            int rkk = util.tryconvert(words[2]);
                            decimal ramount = util.tryconvertdecimal(words[3]);
                            var rkonto = (from c in kontolist where c.Year == rrar where c.Number == rkk select c).FirstOrDefault();
                            if (rkonto == null)
                            {
                                rkonto = new Konto();
                                rkonto.Number = rkk;
                                if (siekontodict.ContainsKey(rkk))
                                    rkonto.Name = siekontodict[rkk];
                                rkonto.Year = rrar;
                                rkonto.UB = ramount;
                                kontolist.Add(rkonto);
                            }
                            else
                            {
                                rkonto.UB = ramount;
                            }
                            break;

                        case "#VER":
                            Ver vv = new Ver();
                            vv.Vernumber = util.tryconvert(words[2].Trim('"'));
                            vv.Verdate = (DateTime)util.parsedate(words[3]);
                            vv.Description = words[4].Trim('"') + " från " + fn;
                            vv.Creationdate = (DateTime)util.parsedate(words[5]);

                            //if (words.Length > 6)
                            //    vv.Creator = 
                            verlist.Add(vv);
                            string l2 = sr.ReadLine().Trim(new char[] { ' ', '\t' });
                            decimal total = 0;
                            do
                            {
                                string[] w2 = util.splitcsv(l2, ' ', '"', '"');
                                if (w2[0] == "#TRANS")
                                {
                                    Rad rr = new Rad();
                                    rr.Ver = vv.Vernumber;
                                    rr.Konto = util.tryconvert(w2[1]);
                                    var tkonto = (from c in kontolist where c.Year == 0 where c.Number == rr.Konto select c).FirstOrDefault();
                                    if (tkonto == null)
                                    {
                                        tkonto = new Konto();
                                        tkonto.Number = rr.Konto;
                                        if (siekontodict.ContainsKey(rr.Konto))
                                            tkonto.Name = siekontodict[rr.Konto];
                                        tkonto.Year = 0;
                                        tkonto.IB = 0;
                                        tkonto.UB = 0;
                                        kontolist.Add(tkonto);
                                    }
                                    rr.Amount = util.tryconvertdecimal(w2[3]);
                                    total += rr.Amount;
                                    radlist.Add(rr);

                                }
                                else if (l2 != "{")
                                {
                                    memo("Ogiltig transaktion " + l2);
                                }
                                l2 = sr.ReadLine().Trim(new char[] { ' ', '\t' });
                            }
                            while (l2 != "}");
                            if (total != 0)
                                memo("Obalans " + total + " i " + words[4]);
                            break;

                        default:
                            memo("Okänd post " + words[0]);
                            break;
                    }

                }
                memo("# konton:\t" + siekontodict.Count);
                memo("# använda konton\t" + kontolist.Count);
                memo("# räkenskapsår:\t" + fiscdict.Count);
                memo("# verifikat:\t" + verlist.Count);
                memo("# transaktioner:\t" + radlist.Count);
                memo("");

                var q = from c in common.db.Company
                        where (c.Orgnr == cc.Orgnr || c.Name == cc.Name)
                        select c;
                int importcompany = -1;
                if (q.Count() == 1)
                {
                    importcompany = q.First().Id;
                    memo("Importerar till befintligt företag " + q.First().Name);
                }
                else if (q.Count() == 0)
                {
                    memo("Skapar nytt företag " + cc.Name);
                    cc.Id = (from c in common.db.Company select c).Count() + 1;
                    importcompany = cc.Id;
                    cc.Admin = common.currentuser;
                    cc.Creator = common.currentuser;
                    cc.Creationdate = DateTime.Now;
                    common.db.Company.InsertOnSubmit(cc);
                    common.db.SubmitChanges();
                }
                else
                {
                    MessageBox.Show("Matchar flera befintliga företag. Kan ej importera"
                        , "IB-konflikt", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    memo("Matchar flera befintliga företag. Kan ej importera.");
                    return;
                }

                Dictionary<int, int> rarmatchdict = new Dictionary<int, int>();
                var qfisc = from c in common.db.Fiscalyear where c.Company == importcompany select c;
                foreach (int rnr in fiscdict.Keys.ToList())
                {
                    foreach (Fiscalyear fy in qfisc)
                    {
                        if (fy.Startdate == fiscdict[rnr].Startdate)
                        {
                            if (fy.Enddate == fiscdict[rnr].Enddate)
                            {
                                rarmatchdict.Add(rnr, fy.Id);
                            }
                            else
                            {
                                memo("Fel slutdatum i räkenskapsår " + rnr + " " + fy.Name);
                            }
                        }
                        else if (fy.Enddate == fiscdict[rnr].Enddate)
                        {
                            memo("Fel startdatum i räkenskapsår " + rnr + " " + fy.Name);
                        }
                        else
                        {
                            if (fy.Startdate < fiscdict[rnr].Startdate)
                            {
                                if (fy.Enddate >= fiscdict[rnr].Startdate)
                                {
                                    memo("Överlappande räkenskapsår " + rnr + " " + fy.Name);
                                }
                            }
                            else if (fy.Startdate <= fiscdict[rnr].Enddate)
                            {
                                memo("Överlappande räkenskapsår " + rnr + " " + fy.Name);
                            }
                        }
                    }
                }
                foreach (int rnr in fiscdict.Keys.ToList())
                {
                    if (!rarmatchdict.ContainsKey(rnr))
                    {
                        var fiscid = 1;
                        var qf = from c in common.db.Fiscalyear select c.Id;
                        if (qf.Count() > 0)
                            fiscid = qf.Max() + 1;
                        fiscdict[rnr].Id = fiscid;
                        rarmatchdict.Add(rnr, fiscid);
                        fiscdict[rnr].Name = fiscdict[rnr].Startdate.Year.ToString();
                        if (fiscdict[rnr].Enddate.Year != fiscdict[rnr].Startdate.Year)
                            fiscdict[rnr].Name += "-" + fiscdict[rnr].Enddate.Year;
                        fiscdict[rnr].Company = importcompany;
                        fiscdict[rnr].Closed = false;
                        fiscdict[rnr].Creator = common.currentuser;
                        fiscdict[rnr].Creationdate = DateTime.Now;
                        memo("Skapar räkenskapsår " + fiscdict[rnr].Name);
                        common.db.Fiscalyear.InsertOnSubmit(fiscdict[rnr]);
                        common.db.SubmitChanges();
                    }
                }

                var qoldver = from c in common.db.Ver where c.Year == rarmatchdict[0] select c;
                if (qoldver.Count() > 0)
                {
                    MessageBox.Show("Finns redan " + qoldver.Count() + " verifikat bokförda på år 0.\n" +
                        "Kan inte blanda gamla och importerade verifikat."
                        , "Finns redan verifikat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //Fixar IB från äldre års UB:
                foreach (Konto kkk in kontolist)
                {
                    if (kkk.Year != 0)
                        continue;
                    if (kkk.IB != 0)
                        continue;
                    var bkonto = from c in kontolist where c.Year < 0 where c.Number == kkk.Number select c;
                    foreach (Konto bk in bkonto.OrderByDescending(c => c.Year))
                    {
                        if (bk.UB != 0)
                            kkk.IB = bk.UB;
                        break;
                    }
                }

                Dictionary<int, int> kontoiddict = new Dictionary<int, int>();

                foreach (Konto kkk in kontolist)
                {
                    if (kkk.Year != 0)
                        continue;
                    kkk.Year = rarmatchdict[kkk.Year];
                    var qk = (from c in common.db.Konto
                              where c.Year == kkk.Year
                              where c.Number == kkk.Number
                              select c).FirstOrDefault();
                    if (qk == null)
                    {
                        int kid = 1;
                        var qkid = from c in common.db.Konto select c.Id;
                        if (qkid.Count() > 0)
                            kid = qkid.Max() + 1;
                        kkk.Id = kid;
                        kkk.Kontotyp = 0;
                        kkk.Kontogrupp = 0;
                        kkk.Konto1 = kkk.Number / 1000;
                        kkk.Konto2 = kkk.Number / 100;
                        kkk.Konto3 = kkk.Number / 10;
                        kkk.Creator = common.currentuser;
                        kkk.Creationdate = DateTime.Now;
                        if (kkk.Year == rarmatchdict[0])
                            kontoiddict.Add(kkk.Number, kkk.Id);
                        common.db.Konto.InsertOnSubmit(kkk);
                        common.db.SubmitChanges();
                    }
                    else
                    {
                        kontoiddict.Add(qk.Number, qk.Id);
                    }
                }

                Dictionary<int, int> veriddict = new Dictionary<int, int>();

                int verid = 1;
                var qqver = from c in common.db.Ver select c.Id;
                if (qqver.Count() > 0)
                    verid = qqver.Max() + 1;
                foreach (Ver vv in verlist)
                {
                    vv.Id = verid;
                    verid++;
                    if (veriddict.ContainsKey(vv.Vernumber))
                    {
                        MessageBox.Show("VARNING: Två verifikat med samma nummer. Nummerbyte.", "Nummerkonflikt", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        while (veriddict.ContainsKey(vv.Vernumber))
                            vv.Vernumber += 10000;
                    }
                    veriddict.Add(vv.Vernumber, vv.Id);
                    vv.Year = rarmatchdict[0];
                    vv.Creator = common.currentuser;
                    common.db.Ver.InsertOnSubmit(vv);
                }
                common.db.SubmitChanges();

                int radid = 1;
                var qqrad = from c in common.db.Rad select c.Id;
                if (qqrad.Count() > 0)
                    radid = qqrad.Max() + 1;
                foreach (Rad rr in radlist)
                {
                    rr.Id = radid;
                    radid++;
                    rr.Ver = veriddict[rr.Ver];
                    rr.Konto = kontoiddict[rr.Konto];
                    common.db.Rad.InsertOnSubmit(rr);
                }
                common.db.SubmitChanges();

                foreach (int ssru in srudict.Keys)
                {
                    StringBuilder sb = new StringBuilder(ssru + "\t");
                    string s = "";
                    foreach (int ksru in srudict[ssru])
                    {
                        sb.Append(s+ksru.ToString());
                        s = ",";
                    }
                    memo(sb.ToString());
                }

                string cin = fiscalclass.consistent_in(fiscalclass.getfiscal(rarmatchdict[0]));
                string cout = fiscalclass.consistent_out(fiscalclass.getfiscal(rarmatchdict[0]));

                if (!String.IsNullOrEmpty(cin))
                {
                    MessageBox.Show(cin, "IB-konflikt", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (!String.IsNullOrEmpty(cout))
                {
                    MessageBox.Show(cout, "UB-konflikt", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                util.logentry("Importerar " + fn, FormLog.logdict[FormLog.logimportexport]);

            }

        }
        public static void write_SIE(string fn,Fiscalyear currentfy, Company cc)
        {
            using (
                var sw = new StreamWriter(
                    new FileStream(fn, FileMode.CreateNew, FileAccess.Write),
                    //Encoding.GetEncoding("iso-8859-1")
                    Encoding.GetEncoding(437)
                )
            )
            {
                NumberFormatInfo nfi = new NumberFormatInfo();
                nfi.NumberDecimalSeparator = ".";
                nfi.NumberDecimalDigits = 2;
                nfi.NumberGroupSeparator = "";
                sw.WriteLine("#FLAGGA 0");
                sw.WriteLine("#PROGRAM LsjBok 1.0");
                sw.WriteLine("#FORMAT PC8");
                sw.WriteLine("#GEN " + DateTime.Now.ToString("yyyyMMdd"));
                sw.WriteLine("#SIETYP 4");
                sw.WriteLine("#ORGNR " + cc.Orgnr);
                sw.WriteLine("#FNAMN \"" + cc.Name + "\"");
                Dictionary<int, int> fiscdict = new Dictionary<int, int>();
                fiscdict.Add(0, common.currentfiscal);
                int fyid = common.currentfiscal;
                Fiscalyear fy = currentfy;
                sw.WriteLine("#RAR 0 " + fy.Startdate.ToString("yyyyMMdd") + " " + fy.Enddate.ToString("yyyyMMdd"));
                int n = 0;
                do
                {
                    fy = fiscalclass.previousfiscal(fy);
                    n--;
                    if (fy != null)
                    {
                        fiscdict.Add(n, fy.Id);
                        sw.WriteLine("#RAR " + n + " " + fy.Startdate.ToString("yyyyMMdd") + " " + fy.Enddate.ToString("yyyyMMdd"));
                    }
                }
                while (fy != null);
                sw.WriteLine("#KPTYP BAS2024");
                var qkk = from c in common.db.Konto where c.Year == common.currentfiscal select c;
                foreach (Konto kk in qkk)
                {
                    sw.WriteLine("#KONTO " + kk.Number + " \"" + kk.Name + "\"");
                }
                var qkbal = from c in qkk where c.Konto1 < 3 select c;
                foreach (Konto kk in qkbal)
                {
                    sw.WriteLine("#IB 0 " + kk.Number + " " + kk.IB.ToString("N2", nfi));
                    sw.WriteLine("#UB 0 " + kk.Number + " " + kk.UB.ToString("N2", nfi));
                }
                if (fiscdict.ContainsKey(-1))
                {
                    var qkbal1 = from c in common.db.Konto where c.Year == fiscdict[-1] where c.Konto1 < 3 select c;
                    foreach (Konto kk in qkbal1)
                    {
                        sw.WriteLine("#IB -1 " + kk.Number + " " + kk.IB.ToString("N2", nfi));
                        sw.WriteLine("#UB -1 " + kk.Number + " " + kk.UB.ToString("N2", nfi));
                    }
                }
                var qkres = from c in qkk where c.Konto1 > 2 select c;
                foreach (Konto kk in qkres)
                {
                    sw.WriteLine("#RES 0 " + kk.Number + " " + kk.UB.ToString("N2", nfi));
                }
                if (fiscdict.ContainsKey(-1))
                {
                    var qkres1 = from c in common.db.Konto where c.Year == fiscdict[-1] where c.Konto1 > 2 select c;
                    foreach (Konto kk in qkres1)
                    {
                        sw.WriteLine("#RES -1 " + kk.Number + " " + kk.UB.ToString("N2", nfi));
                    }
                }
                var qver = from c in common.db.Ver where c.Year == common.currentfiscal select c;
                foreach (Ver vv in qver)
                {
                    sw.WriteLine("#VER V " + vv.Vernumber + " " + vv.Verdate.ToString("yyyyMMdd")
                        + " \"" + vv.Description + "\" " + vv.Creationdate.ToString("yyyyMMdd") + " \"" + util.getusername() + "\"");
                    sw.WriteLine("{");
                    var qrad = from c in common.db.Rad where c.Ver == vv.Id select c;
                    foreach (Rad rr in qrad)
                    {
                        sw.WriteLine("\t#TRANS " + rr.KontoKonto.Number + " {} " + rr.Amount.ToString("N2", nfi));
                    }
                    sw.WriteLine("}");
                }
                util.logentry("Exporterar till " + fn, FormLog.logdict[FormLog.logimportexport]);
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace LsjBok
{
    class util
    {
        private static int nextlogid = -1;
        public static string unused_filename(string fnbase)
        {
            string fn = fnbase;
            int n = 0;
            while (File.Exists(fn))
            {
                n++;
                fn = fnbase.Replace(".", n.ToString("D3") + ".");
            }
            return fn;
        }

        public static string getleaf(string fn)
        {
            return fn.Split('\\').Last();
        }
        public static string getusername()
        {
            return getusername(Form1.currentuser);
        }
        public static string getusername(int nr)
        {
            if (Form1.db == null)
                return "";
            var q = (from c in Form1.db.LsjBokUser where c.Id == nr select c).FirstOrDefault();
            if (q == null)
                return "(no user)";
            else
                return q.Name;
        }
        public static string getcompanyname()
        {
            return getcompanyname(Form1.currentcompany);
        }
        public static string getcompanyname(int nr)
        {
            if (Form1.db == null)
                return "";
            var q = (from c in Form1.db.Company where c.Id == nr select c).FirstOrDefault();
            if (q == null)
                return "(no company)";
            else
                return q.Name;
        }

        public static string getfiscalname()
        {
            return getfiscalname(Form1.currentfiscal);
        }

        public static string getfiscalname(int nr)
        {
            if (Form1.db == null)
                return "";
            var q = (from c in Form1.db.Fiscalyear where c.Id == nr select c).FirstOrDefault();
            if (q == null)
                return "(no fiscal year)";
            else
                return q.Name;

        }

        public static DateTime? parsedate(string date)
        {
            DateTime ret;
            if (DateTime.TryParseExact(date, "yyMMdd", null, 0, out ret))
            {
                return ret;
            }
            else if (DateTime.TryParseExact(date, "yyyyMMdd", null, 0, out ret))
            {
                return ret;
            }
            else if (DateTime.TryParse(date,out ret))
            {
                return ret;
            }
            return null;
        }

        public static int tryconvert(string word)
        {
            if (String.IsNullOrEmpty(word))
                return 0;

            int i = -1;

            try
            {
                i = Convert.ToInt32(word);
            }
            catch (OverflowException)
            {
                //memo("i Outside the range of the Int32 type: " + word);
            }
            catch (FormatException)
            {
                //if ( !String.IsNullOrEmpty(word))
                //    Console.WriteLine("i Not in a recognizable format: " + word);
            }

            return i;

        }

        public static decimal tryconvertdecimal(string word)
        {
            if (String.IsNullOrEmpty(word))
                return 0;

            decimal i = Decimal.MinValue;

            try
            {
                i = Convert.ToDecimal(word);
            }
            catch (OverflowException)
            {
                //memo("i Outside the range of the Int32 type: " + word);
            }
            catch (FormatException)
            {
                if (word.Contains('.'))
                    return tryconvertdecimal(word.Replace('.', ','));
                if (word.Contains(','))
                    return tryconvertdecimal(word.Replace(',', '.'));
                //if ( !String.IsNullOrEmpty(word))
                //    Console.WriteLine("i Not in a recognizable format: " + word);
            }

            return i;

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
            return infiscal(date, Form1.currentfiscal);
        }

        public static bool infiscal(DateTime? date, int fiscal)
        {
            Fiscalyear fy = (from c in Form1.db.Fiscalyear where c.Id == fiscal select c).FirstOrDefault();
            if (fy == null)
                return false;
            if (date < fy.Startdate)
                return false;
            if (date > fy.Enddate)
                return false;
            return true;
        }

        public static Fiscalyear prevfiscal(int oldfyid)
        {
            var oldfy = (from c in Form1.db.Fiscalyear where c.Id == oldfyid select c).FirstOrDefault();
            if (oldfy == null)
                return null;
            else
                return prevfiscal(oldfy);
        }
        public static Fiscalyear nextfiscal(int oldfyid)
        {
            var oldfy = (from c in Form1.db.Fiscalyear where c.Id == oldfyid select c).FirstOrDefault();
            if (oldfy == null)
                return null;
            else
                return nextfiscal(oldfy);
        }
        public static Fiscalyear prevfiscal(Fiscalyear oldfy)
        {
            var q = from c in Form1.db.Fiscalyear where c.Company == Form1.currentcompany select c;
            foreach (Fiscalyear fy in q)
            {
                if ((oldfy.Startdate - fy.Enddate).Days == 1)
                    return fy;
            }
            return null;
        }

        public static Fiscalyear nextfiscal(Fiscalyear oldfy)
        {
            var q = from c in Form1.db.Fiscalyear where c.Company == Form1.currentcompany select c;
            foreach (Fiscalyear fy in q)
            {
                if ((fy.Startdate - oldfy.Enddate).Days == 1)
                    return fy;
            }
            return null;
        }

        public static string[] splitcsv(string line)
        {
            if (line.Contains("\";\""))
                return splitcsv(line, ';');
            else
                return splitcsv(line, ',');
        }

        public static string[] splitcsv(string line, char splitchar)
        {
            return splitcsv(line, splitchar, '"', '"');
        }
        public static string[] splitcsv(string line, char splitchar, char groupstart, char groupend)
        {
            string rex = "(\\" + groupstart + "[^\\" + groupend + "]*\\" + groupend + ")" + splitchar;
            string matchsub = @"¤¤¤MATCH£";
            string matchrex = matchsub + @"(\d+)";
            //string splitstring =  "\"" + splitchar + "\"" ;
            MatchCollection matches = Regex.Matches(line + splitchar, rex);
            if (matches.Count > 0)
            {
                //int imatch = 0;
                for (int imatch = 0; imatch < matches.Count; imatch++)
                {
                    line = line.Replace(matches[imatch].Groups[1].Value, matchsub + imatch);
                    //imatch++;
                }
                string[] words = line.Split(splitchar);
                for (int i = 0; i < words.Length; i++)
                {
                    //if (words[i].Trim('\"').StartsWith("%%%MATCH£"))
                    //{
                    //    int imatch = util.tryconvert(words[i].Split('£')[1].Trim(groupend));
                    //    words[i] = matches[imatch].Groups[1].Value;
                    //}
                    foreach (Match m in Regex.Matches(words[i], matchrex))
                    {
                        int imatch = util.tryconvert(m.Groups[1].Value);
                        words[i] = words[i].Replace(m.Value, matches[imatch].Groups[1].Value);
                    }
                    //if (words[i].Contains("%%%MATCH£"))
                    //{
                    //    int imatch = util.tryconvert(words[i].Split('£')[1].Trim(groupend));
                    //    words[i] = words[i].Replace("%%%MATCH£"+imatch,matches[imatch].Groups[1].Value);
                    //}
                }
                //string[] words = new string[matches.Count];
                //int imatch = 0;
                //foreach (Match match in matches)
                //{
                //    words[imatch] = match.Groups[1].Value;
                //    imatch++;
                //}
                return words;
            }
            else
                return line.Split(splitchar);
            //string[] words = line.Split(splitstring, 99, System.StringSplitOptions.None);
        }

        public static bool validate_orgnr(string nr)
        {
            string rex = @"\d{6}\-?\d{4}";
            foreach (Match m in Regex.Matches(nr, rex))
            {
                if (m.Value == nr)
                    return true;
            }
            return false;
        }

        private static int getnextlogid()
        {
            if (nextlogid < 0)
            {
                var q = from c in Form1.db.Log select c.Id;
                nextlogid = q.Count() + 1;
                //if (q.Count() == 0)
                //    nextlogid = 1;
                //else
                //    nextlogid = q.Max() + 1;
            }
            else
                nextlogid++;
            return nextlogid;
        }

        public static void logentry(string desc, int evid)
        {
            Log ll = new Log();
            ll.Id = getnextlogid();
            ll.Description = desc;
            ll.Event = evid;
            ll.Creator = Form1.currentuser;
            ll.Creationdate = DateTime.Now;
            Form1.db.Log.InsertOnSubmit(ll);
            Form1.db.SubmitChanges();
        }
    }
}

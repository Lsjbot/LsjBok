using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LsjBok
{
    class util
    {
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
            Fiscalyear fy = (from c in Form1.db.Fiscalyear where c.Id == Form1.currentfiscal select c).FirstOrDefault();
            if (fy == null)
                return false;
            if (date < fy.Startdate)
                return false;
            if (date > fy.Enddate)
                return false;
            return true;
        }

    }
}

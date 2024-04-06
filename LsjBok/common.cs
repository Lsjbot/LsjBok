using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LsjBok
{
    class common
    {
        public static string mainfolder;
        public static string folderfn = "lsjbokfolder.txt";
        public static string connectionfn = "connectionstring.txt";
        public static string dbname = "LsjBokDB";
        public static string connectionstring =
            "Server=localhost;Integrated security=True;database=";// + dbname;
        public static LsjBokDB db = null;
        public static int currentuser = -1;
        public static int currentcompany = -1;
        public static int currentfiscal = -1;
    }
}

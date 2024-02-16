using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace LsjBok
{
    public partial class FormImportExport : Form
    {


        public FormImportExport()
        {
            //using (
            //    var sw = new StreamWriter(
            //        new FileStream(saveFileDialog1.FileName, FileMode.Open, FileAccess.ReadWrite),
            //        Encoding.UTF8
            //    )
            //)
            //{
            //    sw.Write(sb.ToString());
            //}
            InitializeComponent();
        }

        private void closebutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

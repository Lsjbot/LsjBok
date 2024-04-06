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
using System.Globalization;

namespace LsjBok
{
    public partial class FormImportExport : Form
    {


        public FormImportExport()
        {
            InitializeComponent();
            updatetitle();
        }

        private void closebutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void updatetitle()
        {
            this.Text = "LsjBok import/export - " + util.getusername() + " - " + util.getcompanyname() + " - " + util.getfiscalname();
        }



        public void memo(string s)
        {
            richTextBox1.AppendText(s + "\n");
            richTextBox1.ScrollToCaret();
        }

        // http://sietest.sie.se/ för att verifiera SIE-filer

        private void importbutton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Välj SIE-fil";
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr != DialogResult.OK)
            {
                memo("Ingen fil vald");
                return;
            }
            string fn = openFileDialog1.FileName;

            sieclass.read_SIE(fn,memo);

            memo("Import av " + fn + " slutförd!");
            memo("======================================================");

        }

        private void exportbutton_Click(object sender, EventArgs e)
        {
            Company cc = (from c in common.db.Company where c.Id == common.currentcompany select c).First();
            Fiscalyear currentfy = (from c in common.db.Fiscalyear where c.Id == common.currentfiscal select c).First();
            String fn = util.unused_filename(common.mainfolder + "\\" + cc.Name + "_" + cc.Orgnr + "_" + currentfy.Name + ".se");
            memo("Skriver SIE till " + fn);

            sieclass.write_SIE(fn,currentfy,cc);

            memo("== Export till SIE klar ==");

        }
    }
}

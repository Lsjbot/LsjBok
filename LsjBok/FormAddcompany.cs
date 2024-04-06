using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace LsjBok
{
    public partial class FormAddcompany : Form
    {
        public FormAddcompany()
        {
            InitializeComponent();
            foreach (string s in companytypeclass.ctdict.Values)
                LBcompanytype.Items.Add(s);
            LBcompanytype.SelectedIndex = 0;
        }

        private bool validate()
        {
            if (LBcompanytype.SelectedItem == null)
                return false;
            if (String.IsNullOrEmpty(TBnamn.Text))
                return false;
            if (String.IsNullOrEmpty(TBorgnr.Text))
                return false;
            if (!util.validate_orgnr(TBorgnr.Text))
                return false;
            return true;
        }

        private void TBorgnr_TextChanged(object sender, EventArgs e)
        {
            createbutton.Enabled = validate();
        }

        private void cancelbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void createbutton_Click(object sender, EventArgs e)
        {
            Company cc = new Company();
            cc.Id = common.db.Company.Count() + 1;
            cc.Name = TBnamn.Text;
            if (TBorgnr.Text.Contains('-'))
                cc.Orgnr = TBorgnr.Text;
            else
                cc.Orgnr = TBorgnr.Text.Insert(6, "-");
            cc.Address = TBaddress.Text;
            cc.Phone = TBphone.Text;
            cc.Email = TBemail.Text;
            cc.Companytype = companytypeclass.ctiddict[LBcompanytype.SelectedItem.ToString()];
            cc.Kontant = RBkontant.Checked;
            if (RB1month.Checked)
                cc.Momsfreq = 1;
            else if (RB3months.Checked)
                cc.Momsfreq = 3;
            else if (RB12months.Checked)
                cc.Momsfreq = 12;
            else
                cc.Momsfreq = 0;
            cc.Admin = common.currentuser;
            cc.Creator = common.currentuser;
            cc.Creationdate = DateTime.Now;
            common.db.Company.InsertOnSubmit(cc);
            common.db.SubmitChanges();

            util.logentry("Skapar företag " + cc.Name, cc.Id);

            common.currentcompany = cc.Id;
            
            this.Close();
        }

        private void TBnamn_TextChanged(object sender, EventArgs e)
        {
            createbutton.Enabled = validate();
        }

        private void LBcompanytype_SelectedIndexChanged(object sender, EventArgs e)
        {
            createbutton.Enabled = validate();
        }
    }
}

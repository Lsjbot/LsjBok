﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LsjBok
{
    public partial class FormAdduser : Form
    {
        public FormAdduser()
        {
            InitializeComponent();
        }

        private void cancelbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool checkmatch()
        {
            if (String.IsNullOrEmpty(TBnamn.Text))
                return false;
            if (TBpw1.Text != TBpw2.Text)
                return false;
            return true;
        }

        private void TBnamn_TextChanged(object sender, EventArgs e)
        {
            createbutton.Enabled = checkmatch();
        }

        private void TBpw1_TextChanged(object sender, EventArgs e)
        {
            createbutton.Enabled = checkmatch();
        }

        private void TBpw2_TextChanged(object sender, EventArgs e)
        {
            createbutton.Enabled = checkmatch();
        }

        private void createbutton_Click(object sender, EventArgs e)
        {
            LsjBokUser lb = new LsjBokUser();
            lb.Id = common.db.LsjBokUser.Count() + 1;
            lb.Name = TBnamn.Text;
            common.db.LsjBokUser.InsertOnSubmit(lb);
            common.db.SubmitChanges();
            common.currentuser = lb.Id;
            util.logentry("Skapar användare " + lb.Name, FormLog.logdict[FormLog.logskapande]);


            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HQAccounting.Models
{
    public partial class AddEditItemForm : Form
    {
        private readonly InvoicingContext _context;

        public AddEditItemForm()
        {
            InitializeComponent();
            _context = new InvoicingContext();
        }

        public AddEditItemForm(Item article)
        {
            InitializeComponent();
            _context = new InvoicingContext();

            txtItemId.Text = article.ItemId.ToString();
            txtItemName.Text = article.ItemName;
            txtNetAmount.Text = article.NetAmount.ToString();
            cboUnit.Text = article.Unit.ToString();
            cboItemType.Text = article.ItemType.ToString();
            cboVAT.Text = article.VAT.ToString() + " %";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var item = new Item
            {
                ItemName = txtItemName.Text,
                NetAmount = Convert.ToDecimal(txtNetAmount.Text),
                Unit = cboUnit.Text,
                VAT = Convert.ToInt32(new string(cboVAT.Text.Where(c => char.IsDigit(c)).ToArray())),
                ItemType = cboItemType.Text,
            };
            if (!string.IsNullOrWhiteSpace(txtItemId.Text))
            {
                item.ItemId = Convert.ToInt32(txtItemId.Text);
            }

            _context.Items.AddOrUpdate(item);
            _context.SaveChanges();
            MessageBox.Show("Artikel sparad!");
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Artikel har inte sparats!");
            this.Close();
        }
    }
}

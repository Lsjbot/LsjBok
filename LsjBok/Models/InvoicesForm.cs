using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HQAccounting.Models
{
    public partial class InvoicesForm : Form
    {
        private readonly InvoicingContext _context;

        public InvoicesForm()
        {
            InitializeComponent();
            _context = new InvoicingContext();
        }

        private void btnAddInvoice_Click(object sender, EventArgs e)
        {
            var form = new AddEditInvoiceForm();
            form.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (1 == listView1.SelectedItems.Count)
            {
                var form = new AddEditInvoiceForm((Invoice)listView1.SelectedItems[0].Tag);
                form.ShowDialog();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (1 == listView1.SelectedItems.Count)
            {
                _context.Invoices.Remove((Invoice)listView1.SelectedItems[0].Tag);
                _context.SaveChanges();
                listView1.Items.Remove(listView1.SelectedItems[0]);
            }
        }

        private void showInvoices()
        {
            listView1.Items.Clear();

            foreach (var invoice in _context.Invoices)
            {
                ListViewItem item = new ListViewItem();
                item.Tag = invoice;
                item.Text = invoice.InvoiceId.ToString();

                Customer customer = _context.Customers.Find(invoice.CustomerId);
                item.SubItems.Add(customer.CustomerName);

                IQueryable<InvoiceItem> invoiceItems = _context.InvoiceItems.Where(x => x.InvoiceId == invoice.InvoiceId);
                decimal sum = 0;
                foreach (var invoiceItem in invoiceItems)
                {
                    int quantity = invoiceItem.Quantity;
                    var _item = _context.Items.Find(invoiceItem.ItemId);
                    int VAT = _item.VAT;
                    Decimal netAmount = _item.NetAmount;
                    sum += quantity * netAmount * VAT;
                }
                item.SubItems.Add(sum.ToString());
                item.SubItems.Add("");
                item.SubItems.Add(invoice.DateOfInvoice.ToString("yyyy-MM-dd"));
                item.SubItems.Add(invoice.DueDate.Date.ToString("yyyy-MM-dd"));
                listView1.Items.Add(item);
            }
        }

        private void ArticleForm_Activated(object sender, EventArgs e)
        {
            showInvoices();
        }

        private void ArticleForm_Load(object sender, EventArgs e)
        {
            showInvoices();
        }

        private void InvoicesForm_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var form = new AddEditInvoiceForm((Invoice)listView1.SelectedItems[0].Tag);
            form.ShowDialog();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var form = new AddEditInvoiceForm((Invoice)listView1.SelectedItems[0].Tag);
            form.ShowDialog();
        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            if (1 == listView1.SelectedItems.Count)
            {
                Invoice invoice = (Invoice)listView1.SelectedItems[0].Tag;
            }
        }
    }
}

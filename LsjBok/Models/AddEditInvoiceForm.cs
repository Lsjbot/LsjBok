using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HQAccounting.Models
{
    public partial class AddEditInvoiceForm : Form
    {
        private readonly InvoicingContext _context;
        private List<InvoiceItem> invoiceItemsToBeDeleted = new List<InvoiceItem>();

        public AddEditInvoiceForm()
        {
            InitializeComponent();
            _context = new InvoicingContext();
            init();

            dtpDateOfInvoice.Value = DateTime.Now;
        }

        public AddEditInvoiceForm(Invoice invoice)
        {
            InitializeComponent();
            _context = new InvoicingContext();
            init();

            // Invoice
            dtpDateOfInvoice.Value = invoice.DateOfInvoice;
            dtpDueDate.Value = invoice.DueDate;
            txtInvoiceId.Text = invoice.InvoiceId.ToString();

            // Customer
            Customer customer = _context.Customers.Find(invoice.CustomerId);
            txtDeliveryTerms.Text = customer.Delivery.ToString();
            txtOverdueInterest.Text = customer.OverdueInterest.ToString();
            txtPaymentTerms.Text = customer.PaymentTerms.ToString();

            // InvoiceItems
            IQueryable<InvoiceItem> invoiceItems = _context.InvoiceItems
                .Where(i => i.InvoiceId == invoice.InvoiceId).Select(x => x);
            foreach (InvoiceItem invoiceItem in invoiceItems)
            {
                Item _item = _context.Items.Find(invoiceItem.ItemId);

                var index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Tag = invoiceItem;
                dataGridView1.Rows[index].Cells["Column1"].Value = _item.ItemName;
                dataGridView1.Rows[index].Cells["Column2"].Value = _item.VAT.ToString();
                dataGridView1.Rows[index].Cells["Column3"].Value = invoiceItem.Quantity;
                dataGridView1.Rows[index].Cells["Column4"].Value = _item.NetAmount.ToString();
                dataGridView1.Rows[index].Cells["Column5"].Value = (invoiceItem.Quantity * _item.NetAmount).ToString();
            }
        }

        private void init()
        {
            List<Customer> customerList = new List<Customer>();
            customerList.AddRange(_context.Customers);
            cboCustomer.DataSource = customerList;
            cboCustomer.DisplayMember = "CustomerName";
            
            List<Item> items = new List<Item>();
            items.AddRange(_context.Items);
            cboItems.DataSource = items;
            cboItems.DisplayMember = "ItemName";

            invoiceItemsToBeDeleted.Clear();
        }

        private void cboCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDeliveryTerms.Text = ((Customer)cboCustomer.SelectedItem).Delivery;
            txtOverdueInterest.Text = ((Customer)cboCustomer.SelectedItem).OverdueInterest.ToString();
            txtPaymentTerms.Text = ((Customer)cboCustomer.SelectedItem).PaymentTerms.ToString();
            dtpDueDate.Value = dtpDateOfInvoice.Value.AddDays(((Customer)cboCustomer.SelectedItem).PaymentTerms);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Faktura inte sparad!");
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var invoice = new Invoice
            {
                //InvoiceId = ,
                //InvoiceTitle = ,
                CustomerId = ((Customer)cboCustomer.SelectedItem).CustomerId,
                Customer = ((Customer)cboCustomer.SelectedItem),
                //InvoiceItems = ,
                DateOfInvoice = dtpDateOfInvoice.Value,
                DueDate = dtpDueDate.Value,
            };
            if (!string.IsNullOrWhiteSpace(txtInvoiceId.Text))
            {
                invoice.InvoiceId = Convert.ToInt32(txtInvoiceId.Text);
            }
            _context.Invoices.AddOrUpdate(invoice);
            _context.SaveChanges();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    ((InvoiceItem)row.Tag).InvoiceId = invoice.InvoiceId;
                    _context.InvoiceItems.AddOrUpdate((InvoiceItem)row.Tag);
                }
            }
            _context.SaveChanges();

            _context.InvoiceItems.RemoveRange(invoiceItemsToBeDeleted);
            _context.SaveChanges();
            invoiceItemsToBeDeleted.Clear();

            MessageBox.Show("Faktura sparad!");
            this.Close();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            var invoiceItem = new InvoiceItem
            {
                //InvoiceItemId = ,
                //InvoiceId = Convert.ToInt32(txtInvoiceId.Text),
                //Invoice = ,
                ItemId = ((Item)cboItems.SelectedItem).ItemId,
                Item = (Item)cboItems.SelectedItem,
                Quantity = 1,
            };
            if (!string.IsNullOrWhiteSpace(txtInvoiceId.Text))
            {
                invoiceItem.InvoiceId = Convert.ToInt32(txtInvoiceId.Text);
            }

            var index = dataGridView1.Rows.Add();
            dataGridView1.Rows[index].Tag = invoiceItem;
            dataGridView1.Rows[index].Cells["Column1"].Value = ((Item)cboItems.SelectedItem).ItemName;
            dataGridView1.Rows[index].Cells["Column2"].Value = ((Item)cboItems.SelectedItem).VAT;
            dataGridView1.Rows[index].Cells["Column3"].Value = 1;
            dataGridView1.Rows[index].Cells["Column4"].Value = (((Item)cboItems.SelectedItem).NetAmount.ToString());
            dataGridView1.Rows[index].Cells["Column5"].Value = (((Item)cboItems.SelectedItem).NetAmount.ToString());
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            invoiceItemsToBeDeleted.Add((InvoiceItem)dataGridView1.Rows[e.RowIndex].Tag);
        }

        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (!dataGridView1.Rows[e.RowIndex].IsNewRow && e.ColumnIndex == 2)
            {
                int quantity = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Column3"].EditedFormattedValue);
                decimal netAmount = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["Column4"].EditedFormattedValue);
                decimal sales = quantity * netAmount;
                ((InvoiceItem)dataGridView1.Rows[e.RowIndex].Tag).Quantity = quantity;
                dataGridView1.Rows[e.RowIndex].Cells["Column5"].Value = sales;
            }
        }

        private void dtpDateOfInvoice_ValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtPaymentTerms.Text))
            {
                dtpDueDate.Value = dtpDateOfInvoice.Value.AddDays(Convert.ToInt32(txtPaymentTerms.Text));
            }
        }
    }
}

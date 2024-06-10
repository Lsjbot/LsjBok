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
    public partial class CustomersForm : Form
    {
        private readonly InvoicingContext _context;

        public CustomersForm()
        {
            InitializeComponent();
            _context = new InvoicingContext();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            var form = new AddEditCustomerForm();
            form.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (1 == listView1.SelectedItems.Count)
            {
                var form = new AddEditCustomerForm((Customer)listView1.SelectedItems[0].Tag);
                form.ShowDialog();
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (1 == listView1.SelectedItems.Count)
            {
                _context.Customers.Remove((Customer)listView1.SelectedItems[0].Tag);
                _context.SaveChanges();
                listView1.Items.Remove(listView1.SelectedItems[0]);
            }
        }

        private void showCustomers()
        {
            listView1.Items.Clear();

            foreach (var customer in _context.Customers)
            {
                ListViewItem item = new ListViewItem();
                item.Tag = customer;
                item.Text = customer.CustomerId.ToString();
                item.SubItems.Add(customer.CustomerName);
                listView1.Items.Add(item);
            }
        }

        private void ArticleForm_Activated(object sender, EventArgs e)
        {
            showCustomers();
        }

        private void ArticleForm_Load(object sender, EventArgs e)
        {
            showCustomers();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var form = new AddEditCustomerForm((Customer)listView1.SelectedItems[0].Tag);
            form.ShowDialog();
        }
    }
}

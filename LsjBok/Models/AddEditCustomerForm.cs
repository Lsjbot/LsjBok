using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace HQAccounting.Models
{
    public partial class AddEditCustomerForm : Form
    {
        private readonly InvoicingContext _context;

        public AddEditCustomerForm()
        {
            InitializeComponent();
            _context = new InvoicingContext();
        }
        public AddEditCustomerForm(Customer customer)
        {
            InitializeComponent();
            _context = new InvoicingContext();

            rbtnCorporation.Checked = customer.CustomerType == "Företagskund";
            rbtnInduvidual.Checked = customer.CustomerType == "Privatkund";

            txtName.Text = customer.CustomerName;
            txtCompanyNumber.Text = customer.CompanyNumber;
            txtVatNumber.Text = customer.VatNumber;
            txtPersonalNumber.Text = customer.PersonalNumber;
            txtCustomerId.Text = customer.CustomerId.ToString();
            txtAddress.Text = customer.Address;
            txtPostalCode.Text = customer.PostalCode;
            txtCity.Text = customer.City;
            txtContact.Text = customer.ContactPerson;
            txtEmail.Text = customer.Email;
            txtPhoneNumber.Text = customer.PhoneNumber;
            txtPaymentTerms.Text = customer.PaymentTerms.ToString();
            txtOverdueInterest.Text = customer.OverdueInterest.ToString();
            txtDelivery.Text = customer.Delivery;
        }

        private void rbtnCompany_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnCorporation.Checked)
            {
                rbtnInduvidual.Checked = false;
                labelPersonalNumber.Visible = false;
                txtPersonalNumber.Visible = false;
                labelOrgNumber.Visible = true;
                txtCompanyNumber.Visible = true;
                labelVatNumber.Visible = true;
                txtVatNumber.Visible = true;
            }
        }

        private void rbtnPrivate_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnInduvidual.Checked)
            {
                rbtnCorporation.Checked = false;
                labelPersonalNumber.Visible = true;
                txtPersonalNumber.Visible = true;
                labelOrgNumber.Visible = false;
                txtCompanyNumber.Visible = false;
                labelVatNumber.Visible = false;
                txtVatNumber.Visible = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string overdueInterest = new String(txtOverdueInterest.Text.Where(Char.IsDigit).ToArray());
            //string overdueInterest = Regex.Match(txtOverdueInterest.Text, @"\d+").Value;
            //Int32.Parse(overdueInterest)

            var customer = new Customer
            {
                CustomerType = rbtnCorporation.Checked ? "Företagskund" : "Privatkund",
                CustomerName = txtName.Text,
                CompanyNumber = txtCompanyNumber.Text,
                VatNumber = txtVatNumber.Text,
                PersonalNumber = txtPersonalNumber.Text,
                Address = txtAddress.Text,
                PostalCode = txtPostalCode.Text,
                City = txtCity.Text,
                //County =
                ContactPerson = txtContact.Text,
                Email = txtEmail.Text,
                PhoneNumber = txtPhoneNumber.Text,
                PaymentTerms = Convert.ToInt32(txtPaymentTerms.Text),
                OverdueInterest = Convert.ToInt32(overdueInterest),
                Delivery = txtDelivery.Text,
            };
            if (!string.IsNullOrWhiteSpace(txtCustomerId.Text))
            {
                customer.CustomerId = Convert.ToInt32(txtCustomerId.Text);
            }

            _context.Customers.AddOrUpdate(customer);
            _context.SaveChanges();
            MessageBox.Show("Kund sparad!");
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Kund har inte sparats!");
            this.Close();
        }
    }
}

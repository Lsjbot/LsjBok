using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQAccounting.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerType { get; set; } // "Företagskund" eller "Privatkund"
        public string CompanyNumber { get; set; } // Endast för företagskund
        public string VatNumber { get; set; } // Endast för företagskund
        public string PersonalNumber { get; set; } // Endast för privatkund
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ContactPerson { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Language { get; set; }
        public int PaymentTerms { get; set; }
        public string Delivery { get; set; }
        public int OverdueInterest { get; set; }
        public string InvoiceComment { get; set; }
        public List<Invoice> Invoices { get; set; }
    }

    public class Item
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal NetAmount { get; set; }
        public int VAT { get; set; }
        public string Unit { get; set; }
        public string ItemType { get; set; }
    }

    public class Invoice
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int InvoiceId { get; set; }
        public string InvoiceTitle { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public List<InvoiceItem> InvoiceItems { get; set; }
        public DateTime DateOfInvoice { get; set; }
        public DateTime DueDate { get; set; }
    }

    public class InvoiceItem
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int InvoiceItemId { get; set; }
        //[Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        [ForeignKey("Invoice")]
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
        //[Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        [ForeignKey("Item")]
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }
    }
}

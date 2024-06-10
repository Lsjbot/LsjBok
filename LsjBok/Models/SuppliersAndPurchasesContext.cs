using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQAccounting.Models
{
    internal class SuppliersAndPurchasesContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Item> Articles { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }

        public SuppliersAndPurchasesContext() : base(LsjBok.common.connectionstring + LsjBok.common.dbname)
        {
        }
    }
}

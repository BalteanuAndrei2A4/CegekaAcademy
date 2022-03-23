using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Model
{
    public class Invoice
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int InvoiceNumber { get; set; }

        public DateTime InvoiceDate { get; set; }

        public decimal Amount { get; set; }

    }
}

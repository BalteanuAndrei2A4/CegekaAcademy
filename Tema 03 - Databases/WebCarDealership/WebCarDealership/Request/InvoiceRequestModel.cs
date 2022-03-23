using System.ComponentModel.DataAnnotations;

namespace WebCarDealership.Request
{
    public class InvoiceRequestModel
    {
        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int InvoiceNumber { get; set; }
    }
}

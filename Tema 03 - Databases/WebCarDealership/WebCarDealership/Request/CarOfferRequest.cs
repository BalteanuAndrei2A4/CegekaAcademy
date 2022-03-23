using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebCarDealership.Request
{
    public class CarOfferRequest 
    {
        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        [Range(0, 10000)]
        public int AvailableStock { get; set; }
    }
}

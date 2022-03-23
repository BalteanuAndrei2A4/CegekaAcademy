using System.ComponentModel.DataAnnotations;

namespace WebCarDealership.Request
{
    public class CustomerRequestModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        
    }
}

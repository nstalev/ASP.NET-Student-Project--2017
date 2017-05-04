using System.ComponentModel.DataAnnotations;

namespace ComputerStore.Models.BindingModels.Orders
{
    public class AddAddressBM
    {
        [Required]
        [MinLength(4)]
        public string City { get; set; }

        [Required]
        [MinLength(4)]
        public string Streat { get; set; }

        [Required]
        public string PhoneNumber { get; set; }


        [Required]
        [MinLength(3)]
        public string PostCode { get; set; }
    }
}

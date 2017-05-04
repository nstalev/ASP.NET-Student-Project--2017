using System.ComponentModel.DataAnnotations;

namespace ComputerStore.Models.BindingModels.Addresses
{
    public class EditAddressBM
    {
        public int Id { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Streat { get; set; }

        [Required]
        public string PhoneNumber { get; set; }


        [Required]
        public string PostCode { get; set; }
    }
}

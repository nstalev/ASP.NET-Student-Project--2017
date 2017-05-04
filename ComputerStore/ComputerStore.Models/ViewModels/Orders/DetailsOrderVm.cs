using ComputerStore.Models.EntityModels.Addresses;
using ComputerStore.Models.EntityModels.Products;
using ComputerStore.Models.ViewModels.Addresses;
using Microsoft.Owin.BuilderProperties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.Models.ViewModels.Orders
{
    public class DetailsOrderVm
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }

        public AddressVM DeliveryAddress { get; set; }


        public virtual IEnumerable<BuyProductVm> Products { get; set; }

        public decimal OrderPrice { get; set; }
    }
}

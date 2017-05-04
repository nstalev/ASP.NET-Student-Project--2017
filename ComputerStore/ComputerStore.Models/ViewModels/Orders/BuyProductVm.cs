﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.Models.ViewModels.Orders
{
    public class BuyProductVm
    {
        public int Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }
        public Decimal Price { get; set; }
    }
}
using System;

namespace ComputerStore.Models.ViewModels.DeskComputers
{
    public class AllDescCompVM
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }
        public string Processor { get; set; }
        public int RAM { get; set; }

        public int Storage { get; set; }

        public string VideoGraphic { get; set; }
        public Decimal Price { get; set; }
    }
}

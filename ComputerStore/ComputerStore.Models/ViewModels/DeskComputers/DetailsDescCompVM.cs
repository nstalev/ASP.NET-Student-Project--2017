using ComputerStore.Models.BindingModels.Comment;
using System;

namespace ComputerStore.Models.ViewModels.DeskComputers
{
    public class DetailsDescCompVM
    {
        public int Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }
        public Decimal Price { get; set; }

        public bool IsAvailable { get; set; }
        public string Processor { get; set; }
        public int RAM { get; set; }

        public int Storage { get; set; }

        public string VideoGraphic { get; set; }

        public string OpticalDrive { get; set; }

        public string OparationSystem { get; set; }

        public string Dimensions { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public AddCommentBM bind { get; set; }
    }
}

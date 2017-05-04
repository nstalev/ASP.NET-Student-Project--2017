using ComputerStore.Models.Attributes;
using ComputerStore.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace ComputerStore.Models.BindingModels.Notebook
{
    public class AddNotebookBm
    {
        public int Id { get; set; }

        [Required]
        public NotebookBrand Brand { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public Decimal Price { get; set; }

        [Required]
        public string Processor { get; set; }

        [Required]
        public int RAM { get; set; }

        [Required]
        public int Storage { get; set; }

        [Required]
        public string VideoGraphic { get; set; }

        [Required]
        public string OparationSystem { get; set; }

        [Required]
        public string DisplaySize { get; set; }

        [Required]
        public string Dimensions { get; set; }

        [Required]
        public string Description { get; set; }

        [UrlImageAttribute]
        [Required]
        public string ImageUrl { get; set; }

        [UrlImageAttribute]
        public string Image2Url { get; set; }

        [UrlImageAttribute]
        public string Image3Url { get; set; }

    }
}

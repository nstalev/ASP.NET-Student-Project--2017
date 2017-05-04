using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace ComputerStore.Models.EntityModels.Products
{

    [Table("Notebooks")]
    public class Notebooks : Item
    {
        public Notebooks()
        {
            this.Comments = new HashSet<Comment>();
        }
        public string Processor { get; set; }
        public int RAM { get; set; }

        public int Storage { get; set; }

        public string VideoGraphic { get; set; }

        public string OparationSystem { get; set; }

        public string DisplaySize { get; set; }

        public string Dimensions { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string Image2Url { get; set; }

        public string Image3Url { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }


    }
}

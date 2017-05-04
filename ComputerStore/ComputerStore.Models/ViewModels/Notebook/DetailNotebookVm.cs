using ComputerStore.Models.BindingModels.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.Models.ViewModels.Notebook
{
    public class DetailsNotebookVm
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

        public string OparationSystem { get; set; }

        public string DisplaySize { get; set; }

        public string Dimensions { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public AddCommentBM bind { get; set; }


    }
}

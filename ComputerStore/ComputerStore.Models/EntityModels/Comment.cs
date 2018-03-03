using System;

namespace ComputerStore.Models.EntityModels
{
    public class Comment
    {
        public int Id { get; set; }

        public string PersonName { get; set; }

        public DateTime Date { get; set; }

        public string Content { get; set; }
    }
}

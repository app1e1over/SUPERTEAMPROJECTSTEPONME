using System;
using System.Collections.Generic;

namespace Library.Models
{
    public partial class Pizza
    {
        public Pizza()
        {
            OrderedPizzas = new HashSet<OrderedPizza>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int Size { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<OrderedPizza> OrderedPizzas { get; set; }
    }
}

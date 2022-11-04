using System;
using System.Collections.Generic;

namespace Library.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderedPizzas = new HashSet<OrderedPizza>();
        }

        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual ICollection<OrderedPizza> OrderedPizzas { get; set; }
    }
}

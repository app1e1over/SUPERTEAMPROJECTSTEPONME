using System;
using System.Collections.Generic;

namespace Library.Models
{
    public partial class OrderedPizza
    {
        public OrderedPizza()
        {
            OrderedIngredients = new HashSet<OrderedIngredient>();
        }

        public int Id { get; set; }
        public int PizzaId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }

        public virtual Order Order { get; set; } = null!;
        public virtual Pizza Pizza { get; set; } = null!;
        public virtual ICollection<OrderedIngredient> OrderedIngredients { get; set; }
    }
}

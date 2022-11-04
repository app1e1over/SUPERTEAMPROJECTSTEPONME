using System;
using System.Collections.Generic;

namespace Library.Models
{
    public partial class OrderedIngredient
    {
        public int Id { get; set; }
        public int IngredientId { get; set; }
        public int OrderedPizzaId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public virtual Ingredient Ingredient { get; set; } = null!;
        public virtual OrderedPizza OrderedPizza { get; set; } = null!;
    }
}

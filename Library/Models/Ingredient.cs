using System;
using System.Collections.Generic;

namespace Library.Models
{
    public partial class Ingredient
    {
        public Ingredient()
        {
            OrderedIngredients = new HashSet<OrderedIngredient>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public decimal Price { get; set; }

        public virtual ICollection<OrderedIngredient> OrderedIngredients { get; set; }
    }
}

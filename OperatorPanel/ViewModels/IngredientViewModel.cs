using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Models;

namespace OperatorPanel.ViewModels
{
    public class IngredientViewModel : NotifyPropertyChangedBase
    {
        public Ingredient ingredient { get; set; }

        public int Id { get => ingredient.Id; }
        public string ImageSource { get => ingredient.ImageSource; }
        public string Title { get => ingredient.Title; }
        public decimal Price{ get => ingredient.Price; }
    }
}

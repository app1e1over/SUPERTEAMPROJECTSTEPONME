using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Library.Models;

namespace OperatorPanel.ViewModels
{
    public class OrderedIngredientViewModel : NotifyPropertyChangedBase
    {
        public OrderedIngredient ingredient { get; set; }

        public int Id { get => ingredient.Id; }
        public string ImageSource { get => ingredient.Ingredient.ImageSource; }
        public string Title { get => ingredient.Ingredient.Title; }
        public decimal Price{ get => ingredient.Price; }

        public ICommand DeleteIngredient { get; set; }
    }
}

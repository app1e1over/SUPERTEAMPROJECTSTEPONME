using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Models;

namespace Admin_Panel.ViewModels
{
    public class IngredientViewModel : NotifyPropertyChangedBase
    {
        public Ingredient ingredient { get; set; }

        public int Id { get => ingredient.Id; }
        public string ImageSource { get => ingredient.ImageSource;
            set {
                ingredient.ImageSource = value;
                OnPropertyChanged(nameof(ImageSource));
            }

        }
        public string Title { get => ingredient.Title;
            set {
                ingredient.Title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
        public decimal Price
        {
            get => ingredient.Price;
            set {
                ingredient.Price = value;
                OnPropertyChanged(nameof(Price));
            }
        }
    }
}

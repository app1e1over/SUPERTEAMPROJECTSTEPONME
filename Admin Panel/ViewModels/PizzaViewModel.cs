using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Models;

namespace Admin_Panel.ViewModels
{
    public class PizzaViewModel : NotifyPropertyChangedBase
    {
        public Pizza pizza { get; set; }

        public int Id { get => pizza.Id; }
        public string ImageSource { get => pizza.ImageSource;
            set {
                pizza.ImageSource = value;
                OnPropertyChanged(nameof(ImageSource));
            }

        }
        public string Title { get => pizza.Title;
            set {
                pizza.Title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
        public int Size { get => pizza.Size;
            set { 
            pizza.Size = value;
                OnPropertyChanged(nameof(Size));
            }
        }
        public decimal Price
        {
            get => pizza.Price;
            set {
                pizza.Price = value;
                OnPropertyChanged(nameof(Price));
            }
        }
    }
}

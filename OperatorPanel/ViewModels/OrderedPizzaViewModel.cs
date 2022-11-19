using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Library.Models;

namespace OperatorPanel.ViewModels
{
    public class OrderedPizzaViewModel : NotifyPropertyChangedBase
    {
        public OrderedPizza pizza { get; set; }

        public int Id { get => pizza.Id; }
        public string ImageSource { get => pizza.Pizza.ImageSource; }
        public string Title { get => pizza.Pizza.Title; }
        public int Size { get => pizza.Pizza.Size; }
        public decimal Price { get => pizza.Price; }

        public ObservableCollection<OrderedIngredientViewModel> OrderedIngredients
        {
            get
            {
                var collection = new ObservableCollection<OrderedIngredientViewModel>();

                pizza.OrderedIngredients.ToList().ForEach(x => collection.Add(new OrderedIngredientViewModel
                {
                    ingredient = x,
                    DeleteIngredient = DeleteIngredient
                }));
                return collection;
            }
        }

        public void RemoveIngredientFromPizza(OrderedIngredient ingredient)
        {
            pizza.OrderedIngredients.Remove(ingredient);
            OnPropertyChanged(nameof(OrderedIngredients));
        }

        public void AddIngredientToPizza(OrderedIngredient ingredient)
        {
            ingredient.OrderedPizza = pizza;
            pizza.OrderedIngredients.Add(ingredient);
            OnPropertyChanged(nameof(OrderedIngredients));
        }

        public ICommand AddIngredientCommand { get; set; }

        public ICommand DeletePizza { get; set; }

        public ICommand DeleteIngredient { get; set; }
    }
}

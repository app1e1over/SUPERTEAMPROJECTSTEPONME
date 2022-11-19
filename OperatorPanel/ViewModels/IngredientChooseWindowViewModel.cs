using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Library.Models;

namespace OperatorPanel.ViewModels
{
    public class IngredientChooseWindowViewModel : NotifyPropertyChangedBase
    {
        public ObservableCollection<IngredientViewModel> Ingredients { get; set; }
        
        public Window window;
        public IngredientViewModel selectedIngredient { get; set; }

        public IngredientChooseWindowViewModel()
        {
        }

        public ICommand AddIngredientToPizzaCommand => new RelayCommand(x =>
        {
            selectedIngredient = x as IngredientViewModel;

            window.Close();
        },
          x => true);
    }
}

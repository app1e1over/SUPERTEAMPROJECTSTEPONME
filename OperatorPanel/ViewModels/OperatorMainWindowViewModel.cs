using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Library.Models;

namespace OperatorPanel.ViewModels
{
    public class OperatorMainWindowViewModel : NotifyPropertyChangedBase
    {
        public ObservableCollection<PizzaViewModel> Pizzas { get; set; }
        public ObservableCollection<IngredientViewModel> Ingredients { get; set; }

        public OperatorMainWindowViewModel()
        {
            Pizzas = new ObservableCollection<PizzaViewModel>();
            _db = new PizzaContext();
            _db.Pizzas
                .Select(p => new PizzaViewModel { pizza = p })
                .ToList()
                .ForEach(Pizzas.Add);

            Ingredients = new ObservableCollection<IngredientViewModel>();
            _db.Ingredients
                .Select(i => new IngredientViewModel { ingredient = i })
                .ToList()
                .ForEach(Ingredients.Add);
        }

        private PizzaContext _db;

        private PizzaViewModel _selectedPizza;
        public PizzaViewModel SelectedPizza
        {
            get => _selectedPizza;
            set
            {
                _selectedPizza = value;
                OnPropertyChanged(nameof(SelectedPizza));
            }
        }

        private IngredientViewModel _selectedIngredient;
        public IngredientViewModel SelectedIngredient
        {
            get => _selectedIngredient;
            set
            {
                _selectedIngredient = value;
                OnPropertyChanged(nameof(SelectedIngredient));
            }
        }
    }
}

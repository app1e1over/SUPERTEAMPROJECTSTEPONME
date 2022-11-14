using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Library.Models;

namespace Admin_Panel.ViewModels
{
    public class AdminMainWindowViewModel : NotifyPropertyChangedBase
    {
        public ObservableCollection<PizzaViewModel> Pizzas { get; set; }
        public ObservableCollection<IngredientViewModel> Ingredients { get; set; }

        public AdminMainWindowViewModel()
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
            set {
                _selectedIngredient = value;
                OnPropertyChanged(nameof(SelectedIngredient));
            }
        }

        public ICommand SaveCommand => new RelayCommand(x =>
        {
            _db.SaveChanges();
        },
            x => true);
        public ICommand NewPizzaCommand => new RelayCommand(x =>
        {
            var model = new Pizza();
            _db.Pizzas.Add(model);

            var viewModel = new PizzaViewModel() { pizza = model };
            Pizzas.Add(viewModel);
        },
    x => true);
        public ICommand NewIngredientCommand => new RelayCommand(x =>
        {
            var model = new Ingredient();
            _db.Ingredients.Add(model);

            var viewModel = new IngredientViewModel() { ingredient = model };
            Ingredients.Add(viewModel);
        },
x => true);






    }
}

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Library.Models;


namespace OperatorPanel.ViewModels
{
    public class OperatorMainWindowViewModel : NotifyPropertyChangedBase
    {
        public Order Order { get; set; } = new Order();
        public ObservableCollection<PizzaViewModel> Pizzas { get; set; }
        public ObservableCollection<OrderedPizzaViewModel> OrderedPizzas { get; set; }

        public decimal OrderPrice {
            get {
                return OrderedPizzas.AsEnumerable().Sum(x => x.Price + x.OrderedIngredients.AsEnumerable().Sum(x => x.Price));
            }
        }

        public List<Ingredient> AllIngredients { get; set; }

        public OperatorMainWindowViewModel()
        {
            Pizzas = new ObservableCollection<PizzaViewModel>();
            _db = new PizzaContext();
            _db.Pizzas
                .Select(p => new PizzaViewModel { pizza = p })
                .ToList()
                .ForEach(Pizzas.Add);

            AllIngredients = _db.Ingredients.ToList();

            OrderedPizzas = new ObservableCollection<OrderedPizzaViewModel>();
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

        //private IngredientViewModel _selectedIngredient;
        //public IngredientViewModel SelectedIngredient
        //{
        //    get => _selectedIngredient;
        //    set
        //    {
        //        _selectedIngredient = value;
        //        OnPropertyChanged(nameof(SelectedIngredient));
        //    }
        //}

        public ICommand AddPizzaToCartCommand => new RelayCommand(x =>
        {
            var selectedPizza = x as PizzaViewModel;
            var pizza = new OrderedPizza()
            {
                Pizza = selectedPizza.pizza,
                Price = selectedPizza.Price,
                Quantity = 1,
                Order = Order,
            };

            var viewModel = new OrderedPizzaViewModel() {
                pizza = pizza,
                AddIngredientCommand = AddIngredientCommand,
                DeletePizza = DeletePizza,
                DeleteIngredient = DeleteIngredient,
            };

            OrderedPizzas.Add(viewModel);

            OnPropertyChanged(nameof(OrderPrice));
        },
          x => true);

        public ICommand AddIngredientCommand => new RelayCommand(
            x =>
            {
                var pizza = x as OrderedPizzaViewModel;
                var indredients = new ObservableCollection<IngredientViewModel>();
                AllIngredients.ForEach(x => indredients.Add(new IngredientViewModel { ingredient = x }));

                var viewModel = new IngredientChooseWindowViewModel()
                {
                    selectedIngredient = null,
                    Ingredients = indredients,
                };
                var window = new IngredientsChooseWindow(viewModel);
                window.ShowDialog();
                if (viewModel.selectedIngredient == null)
                {
                    return;
                }

                pizza.AddIngredientToPizza(new OrderedIngredient
                {
                    OrderedPizza = pizza.pizza,
                    Ingredient = viewModel.selectedIngredient.ingredient,
                    Price = viewModel.selectedIngredient.ingredient.Price,
                    Quantity = 1,
                });
                OnPropertyChanged(nameof(OrderPrice));
            },
            x => true);

        public ICommand DeletePizza => new RelayCommand(x =>
        {
            var pizza = x as OrderedPizzaViewModel;
            OrderedPizzas.Remove(pizza);
            OnPropertyChanged(nameof(OrderPrice));
        },
        x => true);

        public ICommand DeleteIngredient => new RelayCommand(x =>
        {

            var ingredient = x as OrderedIngredientViewModel;
            var pizza = ingredient.ingredient.OrderedPizza;

            var orderedPizza = OrderedPizzas.Where(x => x.pizza == pizza).First();
            orderedPizza.RemoveIngredientFromPizza(ingredient.ingredient);

            OnPropertyChanged(nameof(OrderPrice));
        },
x => true);

        public ICommand MakeOrder => new RelayCommand(x =>
        {
            _db.Orders.Add(Order);
            OrderedPizzas.ToList().ForEach(x =>
            {
                _db.OrderedPizzas.Add(x.pizza);
                x.pizza.OrderedIngredients.ToList().ForEach(x => _db.OrderedIngredients.Add(x));
                
            });
            _db.SaveChanges();

            Order = new Order();
            OrderedPizzas.Clear();
            OnPropertyChanged(nameof(OrderPrice));


        }, x => OrderPrice > 0); 
    }
}

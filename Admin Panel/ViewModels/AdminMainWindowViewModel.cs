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

        public AdminMainWindowViewModel()
        {
            Pizzas = new ObservableCollection<PizzaViewModel>();
            _db = new PizzaContext();
            _db.Pizzas
                .Select(p => new PizzaViewModel { pizza = p })
                .ToList()
                .ForEach(Pizzas.Add);

        }
        private PizzaContext _db;
        public ICommand SaveCommand => new RelayCommand(x =>
        {
            _db.SaveChanges();
        },
            x => true);

        public ICommand NewCommand => new RelayCommand(x =>
        {
            var model = new Pizza();
            _db.Pizzas.Add(model);

            var viewModel = new PizzaViewModel() { pizza = model };
            Pizzas.Add(viewModel);
        },
    x => true);

    }
}

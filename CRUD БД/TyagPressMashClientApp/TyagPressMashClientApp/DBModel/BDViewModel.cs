using System.Collections.ObjectModel;

namespace TyagPressMashClientApp
{
    public class BDViewModel : ViewModelBase
    {
        private ObservableCollection<Должности> positions;
        private ObservableCollection<Доплаты> payments;
        private ObservableCollection<Заказы> orders;
        private ObservableCollection<Продукция> products;
        private ObservableCollection<ПродукцияЦехов> workshopsProducts;
        private ObservableCollection<Сотрудники> employees;
        private ObservableCollection<Цеха> workshops;

        public ObservableCollection<Должности> Positions { get => positions; set { positions = value; OnPropertyChanged("Positions"); } }
        public ObservableCollection<Доплаты> Payments { get => payments; set { payments = value; OnPropertyChanged("Payments"); } }
        public ObservableCollection<Заказы> Orders { get => orders; set { orders = value; OnPropertyChanged("Orders"); } }
        public ObservableCollection<Продукция> Products { get => products; set { products = value; OnPropertyChanged("Products"); } }
        public ObservableCollection<ПродукцияЦехов> WorkshopsProducts { get => workshopsProducts; set { workshopsProducts = value; OnPropertyChanged("WorkshopsProducts"); } }
        public ObservableCollection<Сотрудники> Employees { get => employees; set { employees = value; OnPropertyChanged("Employees"); } }
        public ObservableCollection<Цеха> Workshops { get => workshops; set { workshops = value; OnPropertyChanged("Workshops"); } }
    }
}

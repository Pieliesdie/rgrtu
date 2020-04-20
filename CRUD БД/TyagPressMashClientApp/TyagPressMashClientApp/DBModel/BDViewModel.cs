using System.ComponentModel;

namespace TyagPressMashClientApp
{
    public class BDViewModel : ViewModelBase
    {
        private BindingList<Должности> positions;
        private BindingList<Доплаты> payments;
        private BindingList<Заказы> orders;
        private BindingList<Продукция> products;
        private BindingList<ПродукцияЦехов> workshopsProducts;
        private BindingList<Сотрудники> employees;
        private BindingList<Цеха> workshops;

        public BindingList<Должности> Positions { get => positions; set { positions = value; OnPropertyChanged("Positions"); } }
        public BindingList<Доплаты> Payments { get => payments; set { payments = value; OnPropertyChanged("Payments"); } }
        public BindingList<Заказы> Orders { get => orders; set { orders = value; OnPropertyChanged("Orders"); } }
        public BindingList<Продукция> Products { get => products; set { products = value; OnPropertyChanged("Products"); } }
        public BindingList<ПродукцияЦехов> WorkshopsProducts { get => workshopsProducts; set { workshopsProducts = value; OnPropertyChanged("WorkshopsProducts"); } }
        public BindingList<Сотрудники> Employees { get => employees; set { employees = value; OnPropertyChanged("Employees"); } }
        public BindingList<Цеха> Workshops { get => workshops; set { workshops = value; OnPropertyChanged("Workshops"); } }
    }
}

using System.ComponentModel;

namespace TyagPressMashClientApp
{
    public class BDViewModel : ViewModelBase
    {
        private BindingList<Должности> positions;
        private BindingList<Документы> documents;
        private BindingList<Отпуска> holidays;
        private BindingList<Сотрудники> employees;
        private BindingList<Увольнения> layoffs;
        private BindingList<Цехи> shops;

        public BindingList<Должности> Positions { get => positions; set { positions = value; OnPropertyChanged("Positions"); } }
        public BindingList<Документы> Documents { get => documents; set { documents = value; OnPropertyChanged("Documents"); } }
        public BindingList<Отпуска> Holidays { get => holidays; set { holidays = value; OnPropertyChanged("Holidays"); } }
        public BindingList<Сотрудники> Employees { get => employees; set { employees = value; OnPropertyChanged("Employees"); } }
        public BindingList<Увольнения> Layoffs { get => layoffs; set { layoffs = value; OnPropertyChanged("Layoffs"); } }
        public BindingList<Цехи> Shops { get => shops; set { shops = value; OnPropertyChanged("Shops"); } }
    }
}

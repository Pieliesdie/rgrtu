using EntityFrameworkCore.Jet;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace TyagPressMashClientApp
{
    public partial class MainWindow : Window
    {
        ModelContext db;
        public BDViewModel BDViewModel { get; set; }
        public StringContainer CurrentPage { get; set; } = new StringContainer() { Value = "Сотрудники" };

        public MainWindow()
        {
            SplashScreen ss = new SplashScreen("Images/Splash.png");
            ss.Show(false);
            BDViewModel = new BDViewModel();
            if (!Startup())
                this.Close();
            InitializeComponent();
            this.DataContext = this;
            ss.Close(TimeSpan.FromSeconds(0.1));
        }

        private bool Startup()
        {
            MySettings settings = MySettings.Load();
            if (string.IsNullOrEmpty(settings.Server))
            {
                var result = MessageBox.Show("Ошибка при чтении файла настроек");
                return false;
            }
            var optionsBuilder = new DbContextOptionsBuilder<ModelContext>();
            var options = optionsBuilder.UseJet(settings?.Server).Options;
            db = new ModelContext(options);
            if (!db.Database.CanConnect())
            {
                MessageBox.Show("Ошибка при подключении к базе данных");
                return false;
            }
            db.Должности.Load(); 
            db.Доплаты.Load(); 
            db.Заказы.Load();         
            db.Продукция.Load();
            db.ПродукцияЦехов.Load();
            db.Сотрудники.Load();
            db.Цеха.Load();
            BDViewModel.Positions = new ObservableCollection<Должности>(db.Должности.Local.ToBindingList());
            BDViewModel.Payments = new ObservableCollection<Доплаты>(db.Доплаты.Local.ToBindingList());
            BDViewModel.Orders = new ObservableCollection<Заказы> (db.Заказы.Local.ToBindingList());
            BDViewModel.Products = new ObservableCollection<Продукция> (db.Продукция.Local.ToBindingList());
            BDViewModel.WorkshopsProducts = new ObservableCollection<ПродукцияЦехов> (db.ПродукцияЦехов.Local.ToBindingList());
            BDViewModel.Employees = new ObservableCollection<Сотрудники> (db.Сотрудники.Local.ToBindingList());
            BDViewModel.Workshops = new ObservableCollection<Цеха>( db.Цеха.Local.ToBindingList());
            return true;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            db?.Dispose();
            base.OnClosing(e);
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void UpdateDB_Click(object sender, RoutedEventArgs e)
        {
            Startup();
        }

        private async void SaveDB_Click(object sender, RoutedEventArgs e)
        {
            await db.SaveChangesAsync();
            MessageBox.Show("Изменения сохранены");
        }

        private void PositionsButton_Click(object sender, RoutedEventArgs e) { tabCntrl.SelectedItem = PositionsGrid; CurrentPage.Value = "Должности"; }

        private void PaymentsButton_Click(object sender, RoutedEventArgs e) { tabCntrl.SelectedItem = PaymentsGrid; CurrentPage.Value = "Доплаты"; }

        private void OrdersButton_Click(object sender, RoutedEventArgs e) { tabCntrl.SelectedItem = OrdersGrid; CurrentPage.Value = "Заказы"; }

        private void ProductsButton_Click(object sender, RoutedEventArgs e) { tabCntrl.SelectedItem = ProductsGrid; CurrentPage.Value = "Продукция"; }

        private void WorkshopsProductsButton_Click(object sender, RoutedEventArgs e) { tabCntrl.SelectedItem = WorkshopsProductsGrid; CurrentPage.Value = "Производство в цехах"; }

        private void EmployeesButton_Click(object sender, RoutedEventArgs e) { tabCntrl.SelectedItem = EmployeesGrid; CurrentPage.Value = "Сотрудники"; }

        private void WorkshopsButton_Click(object sender, RoutedEventArgs e) { tabCntrl.SelectedItem = WorkshopsGrid; CurrentPage.Value = "Цеха"; }
    }
}

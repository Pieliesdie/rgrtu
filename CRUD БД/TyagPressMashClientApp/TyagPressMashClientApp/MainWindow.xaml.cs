using EntityFrameworkCore.Jet;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Threading;

namespace TyagPressMashClientApp
{
    public partial class MainWindow : Window
    {
        ModelContext db;
        public BindingList<Должности> Positions { get; set; }
        public BindingList<Доплаты> Payments { get; set; }
        public BindingList<Заказы> Orders { get; set; }
        public BindingList<Продукция> Products { get; set; }
        public BindingList<ПродукцияЦехов> WorkshopsProducts { get; set; }
        public BindingList<Сотрудники> Employees { get; set; }
        public BindingList<Цеха> Workshops { get; set; }

        public string CurrentPage { get; set; } = "Сотрудники";

        public MainWindow()
        {
            SplashScreen ss = new SplashScreen("Images/Splash.png");
            ss.Show(false);
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
            Positions = db.Должности.Local.ToBindingList();
            Payments = db.Доплаты.Local.ToBindingList();
            Orders = db.Заказы.Local.ToBindingList();
            Products = db.Продукция.Local.ToBindingList();
            WorkshopsProducts = db.ПродукцияЦехов.Local.ToBindingList();
            Employees = db.Сотрудники.Local.ToBindingList();
            Workshops = db.Цеха.Local.ToBindingList();
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

        }

        private void SaveDB_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PositionsButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PaymentsButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OrdersButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ProductsButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void WorkshopsProductsButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EmployeesButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void WorkshopsButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

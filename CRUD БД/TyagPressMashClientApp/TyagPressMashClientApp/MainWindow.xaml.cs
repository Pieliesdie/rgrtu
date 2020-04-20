using EntityFrameworkCore.Jet;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows;

namespace TyagPressMashClientApp
{
    public partial class MainWindow : Window
    {
        private ModelContext db;
        public BDViewModel BDViewModel { get; set; }

        public ValueContainer<string> CurrentPage { get; set; } = new ValueContainer<string>("Сотрудники");

        public List<string> Educations { get; } = Enum.GetValues(typeof(Образование))
            .Cast<Образование>()
            .Select(x => (x.ToString().Replace('_', ' ')))
            .ToList();

        public ValueContainer<bool> IsUpdating { get; set; } = new ValueContainer<bool>();

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
            try
            {
                db.Должности.Load();
                db.Доплаты.Load();
                db.Заказы.Load();
                db.Продукция.Load();
                db.ПродукцияЦехов.Load();
                db.Сотрудники.Load();
                db.Цеха.Load();
            }
            catch
            {
                MessageBox.Show("Таблица открыта другим пользователем");
                return false;
            }
            BDViewModel.Positions = db.Должности.Local.ToBindingList();
            BDViewModel.Payments = db.Доплаты.Local.ToBindingList();
            BDViewModel.Orders = db.Заказы.Local.ToBindingList();
            BDViewModel.Products = db.Продукция.Local.ToBindingList();
            BDViewModel.WorkshopsProducts = db.ПродукцияЦехов.Local.ToBindingList();
            BDViewModel.Employees = db.Сотрудники.Local.ToBindingList();
            BDViewModel.Workshops = db.Цеха.Local.ToBindingList();
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
            StopEditing();
            Startup();
        }

        private void SaveDB_Click(object sender, RoutedEventArgs e)
        {
            StopEditing();
            int count = 0;
            try
            {
                count = db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show($"Ошибка сохранения\n {ex.InnerException.Message}");
            }
            MessageBox.Show($"Сохранено изменений: {count}");
        }

        private void StopEditing()
        {
            IsUpdating.Value = true;
            IsUpdating.Value = false;
        }

        private void PositionsButton_Click(object sender, RoutedEventArgs e) { tabCntrl.SelectedItem = PositionsGrid; CurrentPage.Value = "Должности"; }

        private void PaymentsButton_Click(object sender, RoutedEventArgs e) { tabCntrl.SelectedItem = PaymentsGrid; CurrentPage.Value = "Доплаты"; }

        private void OrdersButton_Click(object sender, RoutedEventArgs e) { tabCntrl.SelectedItem = OrdersGrid; CurrentPage.Value = "Заказы"; }

        private void ProductsButton_Click(object sender, RoutedEventArgs e) { tabCntrl.SelectedItem = ProductsGrid; CurrentPage.Value = "Продукция"; }

        private void WorkshopsProductsButton_Click(object sender, RoutedEventArgs e) { tabCntrl.SelectedItem = WorkshopsProductsGrid; CurrentPage.Value = "Производство в цехах"; }

        private void EmployeesButton_Click(object sender, RoutedEventArgs e) { tabCntrl.SelectedItem = EmployeesGrid; CurrentPage.Value = "Сотрудники"; }

        private void WorkshopsButton_Click(object sender, RoutedEventArgs e) { tabCntrl.SelectedItem = WorkshopsGrid; CurrentPage.Value = "Цеха"; }

        private void ToggleButton_Click(object sender, RoutedEventArgs e) => StopEditing();
    }
}

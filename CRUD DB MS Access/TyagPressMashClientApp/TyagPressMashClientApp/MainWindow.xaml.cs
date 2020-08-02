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
                db.Цехи.Load();
                db.Документы.Load();
                db.Отпуска.Load();
                db.Сотрудники.Load();
                db.Увольнения.Load();
            }
            catch
            {
                MessageBox.Show("Таблица открыта другим пользователем");
                return false;
            }
            BDViewModel.Positions = db.Должности.Local.ToBindingList();
            BDViewModel.Shops = db.Цехи.Local.ToBindingList();
            BDViewModel.Documents = db.Документы.Local.ToBindingList();
            BDViewModel.Holidays = db.Отпуска.Local.ToBindingList();
            BDViewModel.Employees = db.Сотрудники.Local.ToBindingList();
            BDViewModel.Layoffs = db.Увольнения.Local.ToBindingList();
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

        private void ToggleButton_Click(object sender, RoutedEventArgs e) => StopEditing();

        private void DocumentsButton_Click(object sender, RoutedEventArgs e) { tabCntrl.SelectedItem = DocumentsGrid; CurrentPage.Value = "Документы"; }

        private void PositionsButton_Click(object sender, RoutedEventArgs e) { tabCntrl.SelectedItem = PositionsGrid; CurrentPage.Value = "Должности"; }

        private void HolidaysButton_Click(object sender, RoutedEventArgs e) { tabCntrl.SelectedItem = HolidaysGrid; CurrentPage.Value = "Отпуска"; }

        private void EmployeesButton_Click(object sender, RoutedEventArgs e) { tabCntrl.SelectedItem = EmployeesGrid; CurrentPage.Value = "Сотрудники"; }

        private void LayoffsButton_Click(object sender, RoutedEventArgs e) { tabCntrl.SelectedItem = LayoffsGrid; CurrentPage.Value = "Увольнения"; }

        private void ShopsButton_Click(object sender, RoutedEventArgs e) { tabCntrl.SelectedItem = WorkshopsGrid; CurrentPage.Value = "Цехи"; }
    }
}

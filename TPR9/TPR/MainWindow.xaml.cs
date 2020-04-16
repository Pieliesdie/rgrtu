using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TPR
{
    public class StringContainer
    {
        public string Value { get; set; }
    }

    public class DoubleContainer
    {
        public double Value { get; set; }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Criterions = new ObservableCollection<StringContainer>() {
                new StringContainer() { Value = "Скорость" },
                new StringContainer() { Value = "Функционал" },
                new StringContainer() { Value = "Удобство" }};
            Objects = new ObservableCollection<StringContainer>() { 
                new StringContainer() { Value = "C#" },
                new StringContainer() { Value = "C++" }, 
                new StringContainer() { Value = "JavaScript" },
                new StringContainer() { Value = "Object Pascal" },
                new StringContainer() { Value = "Assembler" }};
            ObjectRatios = new ObservableCollection<ObservableCollection<DoubleContainer>>();
            CriterionRatios = new ObservableCollection<DoubleContainer>();
            Criterions.CollectionChanged += CreateObjectMatrixs;
            Objects.CollectionChanged += CreateObjectMatrixs;
            CreateCriterionMatrix(null,null);
            CreateObjectMatrixs(null, null);
            this.DataContext = this;
        }

        public ObservableCollection<StringContainer> Criterions { get; set; }

        public ObservableCollection<StringContainer> Objects { get; set; }

        public ObservableCollection<ObservableCollection<DoubleContainer>> ObjectRatios { get; set; }

        public ObservableCollection<DoubleContainer> CriterionRatios { get; set; }

        private DataGrid GetDG()
        {
            DataGrid dataGrid = new DataGrid();
            var Transform = new TransformGroup();
            Transform.Children.Add(new RotateTransform(-90));
            Transform.Children.Add(new ScaleTransform(1, -1));

            dataGrid.LayoutTransform = Transform;
            dataGrid.ColumnHeaderStyle = ImTired.ColumnHeaderStyle;
            dataGrid.CellStyle = ImTired.CellStyle;
            dataGrid.RowHeaderStyle = ImTired.RowHeaderStyle;
            dataGrid.CanUserAddRows = false;
            dataGrid.CanUserSortColumns = false;
            dataGrid.CanUserDeleteRows = false;
            return dataGrid;
        }

        private void CreateCriterionMatrix(object sender, EventArgs e)
        {
            CriterionMatrixs.Children.Clear();

            if (Criterions.Count == 0)
                return;

            var tmp = new ObservableCollection<DoubleContainer>();
            Criterions.ToList().ForEach(x => tmp.Add(new DoubleContainer() { Value = 1 }));
            CriterionRatios = tmp;

            DataGrid dataGrid = GetDG();
            dataGrid.ItemsSource = CriterionRatios;

            dataGrid.LoadingRow += DataGrid_LoadingRow1;
            dataGrid.AutoGeneratingColumn += DataGrid_AutoGeneratingColumn1; 
            CriterionMatrixs.Children.Add(dataGrid);

        }

        private void DataGrid_AutoGeneratingColumn1(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            e.Column.Header = Criterions?.FirstOrDefault()?.Value;
        }

        private void DataGrid_LoadingRow1(object sender, DataGridRowEventArgs e)
        {
            int index = e.Row.GetIndex();
            e.Row.Header = Criterions[index].Value;
            if (index == 0)
            {
                e.Row.IsEnabled = false;
            }
        }

        private void CreateObjectMatrixs(object sender, EventArgs e)
        {
            ObjectRatios.Clear();
            ObjectMatrixs.Children.Clear();
            foreach (var i in Criterions)
            {
                var label = new Label() { Content = $"Критерий {i.Value}" };


                var dataForTable = new ObservableCollection<DoubleContainer>();

                ObservableCollection<DoubleContainer> list = new ObservableCollection<DoubleContainer>();
                ObjectRatios.Add(list);
                Objects.ToList().ForEach(x => list.Add(new DoubleContainer() { Value = 1 }));

                DataGrid dataGrid = GetDG();
                dataGrid.ItemsSource = list;

                dataGrid.AutoGeneratingColumn += DataGrid_AutoGeneratingColumn;
                dataGrid.LoadingRow += DataGrid_LoadingRow;

                ObjectMatrixs.Children.Add(label);
                ObjectMatrixs.Children.Add(dataGrid);
            }

            CreateCriterionMatrix(sender,e);
        }

        private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            e.Column.Header = Objects?.FirstOrDefault()?.Value;
        }

        private void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            int index = e.Row.GetIndex();
            e.Row.Header = Objects[index].Value;
            if (index == 0)
            {
                e.Row.IsEnabled = false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var criterions = Criterions.Select(x => x.Value).ToList();
            var objects = Objects.Select(x => x.Value).ToList();
            var objectRatios = ObjectRatios.Select(x => x.Select(y => y.Value).ToList()).ToList();
            var criterionRatios = CriterionRatios.Select(x => x.Value).ToList();
            new ResultWindow(criterions, objects, objectRatios, criterionRatios,IsEquilibriumCheckBox.IsChecked??true).Show();
        }
    }
}

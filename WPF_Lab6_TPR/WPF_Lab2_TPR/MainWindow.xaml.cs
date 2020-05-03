using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows;
using TPRLibrary;
using Matrix = TPRLibrary.Matrix;

namespace WPF_Lab2_TPR
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Matrix matrix;

        public ObservableCollection<Probability> psForBaies { get; set; }

        public ObservableCollection<Probability> psForHodjes { get; set; }

        public Probability GurvicP { get; set; } = new Probability();

        public Probability HodjesP { get; set; } = new Probability();

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            psForBaies = new ObservableCollection<Probability>();
            psForHodjes = new ObservableCollection<Probability>();
        }

        private void ReadMatrix(object sender, RoutedEventArgs e)
        {
            textBox.Text = string.Empty;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.FileName = "*.csv";
            if (openFileDialog1.ShowDialog() == true)
            {
                var csv = File
                    .ReadAllLines(openFileDialog1.FileName)
                    .Select(a => Array.ConvertAll(a.Split(';'), Double.Parse)).To2DArray();

                matrix = new Matrix(csv);
                dataGrid.ItemsSource2D = csv;
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (matrix == null)
            {
                MessageBox.Show("Load matrix");
                return;
            }
            textBox.Text = string.Empty;
            List<(string method, int row)> results = new List<(string, int row)>();
            if (GrumblerCheckbox.IsChecked == true)
                results.Add(("Азартный", matrix.Grambler()));
            if (MaxminCheckbox.IsChecked == true)
                results.Add(("MaxMin", matrix.MaxMin()));
            if (GurvicCheckbox.IsChecked == true)
                results.Add(("Гурвиц", matrix.Gurvic(GurvicP.value??0)));
            if (SevidgeCheckbox.IsChecked == true)
                results.Add(("Севидж", matrix.Sevidge()));

            if (BaiesCheckbox.IsChecked == true)
                if (Criterions.DoubleEqual(psForBaies.ToList().Sum(x => x.value??0), 1))
                    if (psForBaies.Count() == matrix.ColumnCount)
                        results.Add(("Байес", matrix.Baies(psForBaies.Select(x => x.value??0).ToList())));
                    else
                        MessageBox.Show("Wrong vector for baies");
                else
                    MessageBox.Show("Sum for baies != 1");

            if (LaplasCheckbox.IsChecked == true)
                results.Add(("Лаплас", matrix.Laplas()));

            if (HodjesCheckbox.IsChecked == true)
            {
                if (Criterions.DoubleEqual(psForHodjes.ToList().Sum(x => x.value??0), 1))
                    if (psForHodjes.Count() == matrix.ColumnCount)
                        results.Add(("Ходжес-Леман", matrix.HodjesLeman(psForHodjes.Select(x => x.value??0).ToList(), HodjesP.value ?? 0)));
                    else
                        MessageBox.Show("Wrong vector for Hodjes");
                else
                    MessageBox.Show("Sum for Hodjes != 1");
            }

            results.ForEach(x => textBox.AppendText($"{x.method} - выбрал стретегию {x.row + 1}\n"));
            textBox.AppendText($"Стоит выбрать стратегию : {results.GroupBy(x => x.row).OrderByDescending(x => x.Count()).FirstOrDefault()?.Key + 1}\n");
        }

    }

}

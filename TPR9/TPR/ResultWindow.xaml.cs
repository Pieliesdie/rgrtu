using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using LiveCharts;
using LiveCharts.Wpf;

namespace TPR
{
    /// <summary>
    /// Interaction logic for ResultWindow.xaml
    /// </summary>
    public partial class ResultWindow : Window
    {
        public static readonly string Format = "0.000";

        public ResultWindow(List<string> Criterions, List<string> Objects, List<List<double>> ObjectRatios, List<double> CriterionRatios, bool IsEquilibrium)
        {
            InitializeComponent();

            this.SeriesCollection = new SeriesCollection();
            this.Criterions = Criterions;
            this.Objects = Objects;

            this.ranks = GetRanks(CriterionRatios).ToList();
            if (IsEquilibrium)
                ranks = Enumerable.Repeat((double)1, Criterions.Count).ToList();

            Values = ObjectRatios.Select(x => GetRanks(x)).Zip(ranks, (x, y) => x.Select(x => Math.Pow(x, y)).ToList()).ToList();

            var RotateList = Enumerable.Range(0, Values[0].Count)
                         .Select(x => Enumerable.Range(0, Values.Count)
                                                .Select(y => Values[y][x]).ToList()).ToList();


            //uncomment if wanna in another dg
            //Mins = RotateList.Select(x => new StringContainer() { Value = $"{x.Min().ToString(Format)}({Criterions[x.FindIndex(y=>y==x.Min())]})" }).ToList();

            var mins = RotateList.Select(x =>x.Min()).ToList();
            Values.Add(mins);
            Criterions.Add("Minimums");

            var sortedMins = mins.OrderByDescending(x => x).ToList();
         
            Values.Add(mins.Select(x => (double)sortedMins.FindIndex(y => x == y)+1).ToList()); 
            Criterions.Add("Raiting");

            RotateList.Zip(Objects, (x,y) => new {x,y }).ToList().ForEach(x => SeriesCollection.Add(new LineSeries() { Values = new ChartValues<double>(x.x),Title =x.y}));

            this.DataContext = this;
        }

        private List<double> ranks { get; }

        public SeriesCollection SeriesCollection { get; }
        public Func<double, string> Formatter => value => value.ToString(Format);

        public List<StringContainer> Mins { get; }
        public List<string> Criterions { get; }
        public List<string> Objects { get; }
        public List<StringContainer> Ranks => ranks.Select(x => new StringContainer() { Value = x.ToString(Format) }).ToList();
        public List<List<double>> Values { get; set; }

        public static IEnumerable<double> GetRanks(IEnumerable<double> src)
        {
            var result = new List<double>(src.Count());
            foreach (var i in src)
            {
                double cell = 0;
                foreach (var j in src)
                {
                    cell += i / j;
                }
                result.Add(1 / cell);
            }
            return result;
        }
    }
}


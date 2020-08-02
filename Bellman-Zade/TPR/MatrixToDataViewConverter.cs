using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace TPR
{
    public class MatrixToDataViewConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var myDataTable = new DataTable();
            var colums = values[0] as List<string>;
            var rows = values[1] as List<string>;
            var vals = (values[2] as List<List<double>>).Select(x=>x.Select(y=>y.ToString(ResultWindow.Format)).ToList()).ToList();
            myDataTable.Columns.Add("---");    //The blanc corner column
            foreach (var value in colums)
            {
                myDataTable.Columns.Add(value.ToString());
            }
            int index = 0;

            foreach (string row in rows)
            {
                var tmp = new string[1 + vals[index].Count()];
                vals[index].CopyTo(tmp, 1);
                tmp[0] = row;
                myDataTable.Rows.Add(tmp);
                index++;
            }

            return myDataTable.DefaultView;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

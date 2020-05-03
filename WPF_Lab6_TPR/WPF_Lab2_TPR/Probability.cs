using System;
using System.ComponentModel;

namespace WPF_Lab2_TPR
{

    public partial class MainWindow
    {
        public class Probability :IDataErrorInfo
        {
            private double? _value;
            private string error;

            public double? value
            {
                get => _value;
                set
                {
                    if (value.HasValue)
                    {
                        if (value >= 0 && value <= 1)
                        {
                            _value = value;
                            error = String.Empty;
                        }
                        else
                        {
                            _value = null;
                            error = "Value must be beetwen 0 and 1";
                        }
                    }
                    else
                        error = "Can't convert";
                }
            }

            public string this[string columnName]
            {
                get { return error; }
            }

            public string Error
            {
                get { throw new NotImplementedException(); }
            }
        }

    }

}

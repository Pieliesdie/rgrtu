namespace TyagPressMashClientApp
{
    public class StringContainer : ViewModelBase
    {
        private string _value;

        public string Value { get => _value; set { _value =value; OnPropertyChanged("Value"); } }
    }
}

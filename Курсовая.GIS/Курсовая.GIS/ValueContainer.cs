namespace Курсовая.GIS
{
    public class ValueContainer<T> : ViewModelBase
    {
        private T _value;

        public ValueContainer(T value=default(T))
        {
            _value = value;
        }

        public T Value { get => _value; set { _value = value; OnPropertyChanged("Value"); } }

        public override string ToString()
        {
            return _value.ToString();
        }
    }
}

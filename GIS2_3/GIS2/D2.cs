namespace GIS2
{
    public class D2<T>
    {
        public T[] input;
        int lenght0;
        public D2(T[] input, int lenght0)
        {
            this.input = input;
            this.lenght0 = lenght0;
        }
        public T this[int index0, int index1]
        {
            get { return input[index0 * this.lenght0 + index1]; }
            set { input[index0 * this.lenght0 + index1] = value; }
        }
    }
}

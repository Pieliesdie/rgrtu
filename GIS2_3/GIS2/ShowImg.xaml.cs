using System.Windows;
using System.Windows.Media;

namespace GIS2
{
    /// <summary>
    /// Interaction logic for ShowImg.xaml
    /// </summary>
    public partial class ShowImg : Window
    {
        public ShowImg(ImageSource image)
        {
            InitializeComponent();
            img.Source = image;
        }
    }
}

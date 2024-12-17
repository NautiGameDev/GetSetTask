using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;


namespace Projecraft.Views
{
    /// <summary>
    /// Interaction logic for NewProfileThumb.xaml
    /// </summary>
    public partial class NewProfileThumb : UserControl
    {
        MainWindow mainWindow;

        public NewProfileThumb(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void NewProfileButton_MouseLeave(object sender, MouseEventArgs e)
        {
            BrushConverter brushConverter = new BrushConverter();
            NewProfileButton.Foreground = (Brush)brushConverter.ConvertFrom("#C7E8F3");
        }

        private void NewProfileButton_MouseEnter(object sender, MouseEventArgs e)
        {
            BrushConverter brushConverter = new BrushConverter();
            NewProfileButton.Foreground = (Brush)brushConverter.ConvertFrom("#123456");
        }

        private void NewProfileButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.CreateNewProfileView();
        }
    }
}

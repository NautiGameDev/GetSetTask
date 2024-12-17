using System.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;


namespace Projecraft.Views
{
    /// <summary>
    /// Interaction logic for ProfileThumbs.xaml
    /// </summary>
    public partial class ProfileThumbs : UserControl
    {

        MainWindow mainWindow;
        string profile;

        public ProfileThumbs(string profileName, MainWindow mainWindow)
        {
            InitializeComponent();
            profile = profileName.Split("Profiles\\")[1];
            ProfileNameButton.Content = profile;
            this.mainWindow = mainWindow;
        }



        private void ProfileNameButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                mainWindow.UserLogIn(profile);
            }
            catch (Exception ex)
            {
                SystemSounds.Asterisk.Play();
                MessageBox.Show(ex.ToString());
            }
        }

        private void ProfileNameButton_MouseEnter(object sender, MouseEventArgs e)
        {
            var brushConverter = new BrushConverter();
            ProfileNameButton.Foreground = (Brush)brushConverter.ConvertFrom("#123456");
        }

        private void ProfileNameButton_MouseLeave(object sender, MouseEventArgs e)
        {
            var brushConverter = new BrushConverter();
            ProfileNameButton.Foreground = (Brush)brushConverter.ConvertFrom("#C7E8F3");
            
        }
    }
}

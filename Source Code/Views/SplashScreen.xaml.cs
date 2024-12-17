using System.IO;
using System.Windows.Controls;


namespace Projecraft.Views
{
    /// <summary>
    /// Interaction logic for SplashScreen.xaml
    /// </summary>
    public partial class SplashScreen : UserControl
    {
        MainWindow mainWindow;

        public SplashScreen(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            LookForProfiles();
            

            
        }

        private void LookForProfiles()
        {
            
            string path = AppDomain.CurrentDomain.BaseDirectory + "/Profiles";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            foreach (string profile in Directory.GetDirectories(path))
            {
                ProfileThumbs thumb = new ProfileThumbs(profile, mainWindow);
                ProfileStackBox.Children.Add(thumb);
            }

            NewProfileThumb newProfileThumb = new NewProfileThumb(mainWindow);
            ProfileStackBox.Children.Add(newProfileThumb);
            
        }



    }
}

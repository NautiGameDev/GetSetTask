using System.Windows;
using System.Windows.Controls;


/*  
 *  NOTE:
 *  This page isn't used in the current version of the program. Maintained for potential future updates. 
 */

namespace Projecraft.Views
{
    /// <summary>
    /// Interaction logic for LogInPage.xaml
    /// </summary>
    public partial class LogInPage : UserControl
    {
        MainWindow mainWindow;

        public LogInPage(MainWindow mainWin)
        {
            InitializeComponent();
            this.mainWindow = mainWin;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string userName = UserNameBox.Text;
                mainWindow.UserLogIn(userName);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error: " + exception);
            }
        }
    }
}

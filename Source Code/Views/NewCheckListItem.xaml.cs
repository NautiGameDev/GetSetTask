using System.Media;
using System.Windows;
using System.Windows.Controls;


namespace Projecraft.Views
{
    /// <summary>
    /// Interaction logic for NewCheckListItem.xaml
    /// </summary>
    public partial class NewCheckListItem : UserControl
    {
        MainWindow mainWindow;
        TaskDetailsWindow taskDetailsWindow;
        TaskController taskController;

        bool hasBeenFocused = false;

        public NewCheckListItem(TaskController taskController, TaskDetailsWindow taskDetailsWindow, MainWindow mainWindow)
        {
            InitializeComponent();
            this.taskController = taskController;
            this.taskDetailsWindow = taskDetailsWindow;
            this.mainWindow = mainWindow;
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox.Text.Trim() != "")
            {
                try
                {
                    taskController.AddStep(TextBox.Text);
                    taskDetailsWindow.PopulateChecklist();
                    mainWindow.IncreaseStepsCreatedCount();
                    mainWindow.SaveData();
                }
                catch (Exception ex)
                {
                    SystemSounds.Asterisk.Play();
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                SystemSounds.Asterisk.Play();
                MessageBox.Show("Please, enter information for your step.");
            }
        }

        
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            taskDetailsWindow.RemoveNewChecklistItem(this);
        }

       

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!hasBeenFocused)
            {
                TextBox.Text = "";
                TextBox.FontWeight = FontWeights.Medium;
            }
           
          
        }
    }
}

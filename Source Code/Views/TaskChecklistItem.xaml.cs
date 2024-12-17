using System.Media;
using System.Windows;
using System.Windows.Controls;


namespace Projecraft.Views
{
    /// <summary>
    /// Interaction logic for TaskChecklistItem.xaml
    /// </summary>
    public partial class TaskChecklistItem : UserControl
    {
        MainWindow mainWindow;
        TaskController taskController;
        TaskDetailsWindow taskDetailsWindow;
        string checkBoxData;

        public TaskChecklistItem(string checkBoxData, bool status, TaskController taskController, TaskDetailsWindow taskDetailsWindow, MainWindow mainWindow)
        {
            InitializeComponent();

           
            CheckBox.Content = checkBoxData;
            this.checkBoxData = checkBoxData;
            CheckBox.IsChecked = status;
            this.taskController = taskController;
            this.taskDetailsWindow = taskDetailsWindow;
            this.mainWindow = mainWindow;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                taskController.RemoveStep(checkBoxData);
                taskDetailsWindow.PopulateChecklist();
                mainWindow.SaveData();
            }
            catch (Exception ex)
            {
                SystemSounds.Asterisk.Play();
                MessageBox.Show(ex.ToString());
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (taskController != null)
                {
                    taskController.CompleteStep(checkBoxData);
                    mainWindow.IncreaseStepsCompletedCount();
                    mainWindow.SaveData();
                }
            }
            catch (Exception ex)
            {
                SystemSounds.Asterisk.Play();
                MessageBox.Show(ex.ToString());
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (taskController != null)
                {
                    taskController.UnCompleteStep(checkBoxData);
                    mainWindow.DecreaseStepsCompletedCount();
                    mainWindow.SaveData();
                }
            }
            catch (Exception ex)
            {
                SystemSounds.Asterisk.Play();
                MessageBox.Show(ex.ToString());
            }
        }
    }
}

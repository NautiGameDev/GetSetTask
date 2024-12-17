using System.Media;
using System.Windows;
using System.Windows.Controls;


namespace Projecraft.Views
{
    /// <summary>
    /// Interaction logic for NewTaskWindow.xaml
    /// </summary>
    public partial class NewTaskWindow : UserControl
    {
        MainWindow mainWindow;
        
        ProjectController projectController;

        public NewTaskWindow(MainWindow mainWin, ProjectController projController)
        {
            InitializeComponent();
            mainWindow = mainWin;
            projectController = projController;
        }

        private void CreateTask_Click(object sender, RoutedEventArgs e)
        {

            if (TaskNameBox.Text.Trim() != "")
            {
                string taskTitle = TaskNameBox.Text;
                string taskDescription = TaskDescriptionBox.Text;
                string taskCategory = TaskCategoryBox.Text;
                string taskCreationDate = DateTime.Now.ToString();
                string taskDueDate = "";
                if (DueDatePicker.SelectedDate != null)
                {
                    taskDueDate = DueDatePicker.SelectedDate.ToString().Split(" ")[0];
                }

                try
                {

                    projectController.NewTask(taskTitle, taskDescription, taskCreationDate, taskDueDate, taskCategory);
                    mainWindow.IncreaseTaskCreatedCount();
                    mainWindow.SaveData();
                    mainWindow.CloseCreateTaskWindow(this);
                    mainWindow.RefreshProjectDetailsWindow();
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
                MessageBox.Show("Please enter a name for your task.");
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.ProjectDetailsWindow(projectController.GetSelectedProject());
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.CloseCreateTaskWindow(this);
        }
    }
}

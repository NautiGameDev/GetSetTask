using System.Media;
using System.Windows;
using System.Windows.Controls;


namespace Projecraft.Views
{
    /// <summary>
    /// Interaction logic for EditTaskView.xaml
    /// </summary>
    public partial class EditTaskView : UserControl
    {
        TaskController taskController { get; set; }
        ProjectController projectController { get; set; }
        MainWindow mainWindow { get; set; }

        public EditTaskView(MainWindow mainWindow, TaskController taskController, ProjectController projectController)
        {
            InitializeComponent();
            this.taskController = taskController;
            this.mainWindow = mainWindow;
            this.projectController = projectController;

            PopulateEditTaskView();
            
        }

        public void PopulateEditTaskView()
        {
            Dictionary<string, string> taskInfo = taskController.GetTaskInformation();

            TaskNameBox.Text = taskInfo["Name"];
            TaskDescriptionBox.Text = taskInfo["Description"];
            TaskCategoryBox.Text = taskInfo["Category"];
            
            if (taskInfo["Due Date"] != "")
            {
                DueDatePicker.SelectedDate = DateTime.Parse(taskInfo["Due Date"]);
            }
        }

        private void EditTaskButton_Click(object sender, RoutedEventArgs e)
        {
            if (TaskNameBox.Text.Trim() != "")
            {
                Dictionary<string, string> taskInfo = new Dictionary<string, string>();

                taskInfo["Name"] = TaskNameBox.Text;
                taskInfo["Description"] = TaskDescriptionBox.Text;
                taskInfo["Category"] = TaskCategoryBox.Text;
                taskInfo["Due Date"] = DueDatePicker.SelectedDate.ToString().Split(" ")[0];

                try
                {
                    Dictionary<string, string> originalTaskInformation = taskController.GetTaskInformation();

                    projectController.UpdateTask(originalTaskInformation["Name"], taskInfo["Name"]);
                    taskController.SetTaskInformation(taskInfo);

                    mainWindow.SaveData();
                    mainWindow.RefreshTaskDetailsWindow();
                    mainWindow.CloseEditTaskWindow(this);
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
                MessageBox.Show("Please, enter a name for your task.");
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.CloseEditTaskWindow(this);
        }
    }
}

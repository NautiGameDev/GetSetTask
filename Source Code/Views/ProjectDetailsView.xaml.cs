using System.Windows;
using System.Windows.Controls;


namespace Projecraft.Views
{
    /// <summary>
    /// Interaction logic for ProjectDetailsView.xaml
    /// </summary>
    public partial class ProjectDetailsView : UserControl
    {
        MainWindow mainWindow;
        ProjectController projectController { get; set; }

        public ProjectDetailsView(MainWindow mainWin, ProjectController projController)
        {
            InitializeComponent();
            projectController = projController;
            mainWindow = mainWin;
            PopulateProjectWindow();
        }

        public void PopulateProjectWindow()
        {
            Dictionary<string, string> projectInformation = projectController.GetProjectInformation();

            ProjectNameText.Content = projectInformation["Name"];
            ProjectCategoryText.Text = projectInformation["Category"];
            ProjectDescriptionText.Text = projectInformation["Description"];
            ProjectDateText.Text = projectInformation["Date"];
            PopulateTaskBox();
        }

        public void PopulateTaskBox()
        {
            if (ToDoButton.IsChecked == true) 
            {
                PopulateToDoTasks();
            }
            else if (CompletedButton.IsChecked == true) 
            {
                PopulateCompletedTasks();
            }
        }

        private void PopulateToDoTasks()
        {
            TaskBox.Children.Clear();
            Dictionary<string, Task> taskDict = projectController.GetTasks();

            foreach (string task in taskDict.Keys)
            {
                TaskItem newTaskItem = new TaskItem(taskDict[task], mainWindow, this);
                TaskBox.Children.Add(newTaskItem);
            }
        }

        private void PopulateCompletedTasks()
        {
            TaskBox.Children.Clear();
            Dictionary<string, Task> taskDict = projectController.GetCompletedTasks();

            foreach (string task in taskDict.Keys)
            {
                TaskItem newTaskItem = new TaskItem(taskDict[task], mainWindow, this);
                TaskBox.Children.Add(newTaskItem);
            }
        }

        public void CompleteTask(string taskTitle)
        {
            mainWindow.IncreaseTaskCompetedCount();
            projectController.SetTaskToComplete(taskTitle);
            PopulateTaskBox();
            mainWindow.SaveData();
        }

        public void DeleteTask(string taskTitle)
        {
            projectController.RemoveTask(taskTitle);
            PopulateTaskBox();
            mainWindow.SaveData();
        }

        private void NewTask_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.CreateTaskWindow();
        }

        private void EditProjectButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.EditProjectView();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.CloseProjectDetailsWindow(this);
        }

        private void ToDoButton_Click(object sender, RoutedEventArgs e)
        {
            PopulateToDoTasks();
        }

        private void CompleteButton_Click(object sender, RoutedEventArgs e)
        {
            PopulateCompletedTasks();
        }
    }
}

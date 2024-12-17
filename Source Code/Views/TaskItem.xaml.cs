using System.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace Projecraft.Views
{
    /// <summary>
    /// Interaction logic for TaskItem.xaml
    /// </summary>
    public partial class TaskItem : UserControl
    {
        Task task;
        MainWindow mainWindow;
        ProjectDetailsView projectDetailsView;
        public TaskItem(Task task, MainWindow mainWindow, ProjectDetailsView projectDetailsView)
        {
            InitializeComponent();
            this.task = task;
            this.mainWindow = mainWindow;
            this.projectDetailsView = projectDetailsView;

            CheckIfTaskComplete();
            PopulateItem();
        }

        private void CheckIfTaskComplete()
        {
            if (task.isCompleted)
            {
                CompleteButton.Visibility = Visibility.Hidden;
                DeleteButton.Visibility = Visibility.Hidden;
            }
        }

        private void PopulateItem()
        {
            TaskText.Text = task.taskTitle;
        }

        private void TextBlock_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (!task.isCompleted) 
            { 
                mainWindow.TaskDetailsWindow(task);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                projectDetailsView.DeleteTask(task.taskTitle);
            }
            catch (Exception ex)
            {
                SystemSounds.Asterisk.Play();
                MessageBox.Show(ex.ToString());
            }
        }

        private void CompleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                projectDetailsView.CompleteTask(task.taskTitle);
            }
            catch (Exception ex)
            {
                SystemSounds.Asterisk.Play();
                MessageBox.Show(ex.ToString());
            }

        }
    }
}

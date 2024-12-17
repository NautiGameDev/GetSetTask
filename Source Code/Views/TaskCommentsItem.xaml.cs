using System.Media;
using System.Windows;
using System.Windows.Controls;


namespace Projecraft.Views
{
    /// <summary>
    /// Interaction logic for TaskCommentsItem.xaml
    /// </summary>
    public partial class TaskCommentsItem : UserControl
    {
        MainWindow mainWindow;
        TaskController taskController;
        TaskDetailsWindow taskDetailsWindow;

        public TaskCommentsItem(string commentTitle, string commentDate, string comment, TaskController taskController, TaskDetailsWindow taskDetailsWindow, MainWindow mainWindow)
        {
            InitializeComponent();
            CommentTitleBox.Text = commentTitle;
            CommentDateBox.Text = commentDate;
            CommentBox.Text = comment;
            this.taskController = taskController;
            this.taskDetailsWindow = taskDetailsWindow;
            this.mainWindow = mainWindow;
        }  

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                taskController.RemoveNote(CommentTitleBox.Text);
                taskDetailsWindow.PopulateCommentslist();
                mainWindow.SaveData();
            }
            catch (Exception ex)
            {
                SystemSounds.Asterisk.Play();
                MessageBox.Show(ex.ToString());
            }
        }
    }
}

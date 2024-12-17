
using System.Media;
using System.Windows;
using System.Windows.Controls;


namespace Projecraft.Views
{
    /// <summary>
    /// Interaction logic for NewCommentItem.xaml
    /// </summary>
    public partial class NewCommentItem : UserControl
    {

        TaskController taskController;
        MainWindow mainWindow;
        TaskDetailsWindow taskDetailsWindow;

        bool hasFocusedTitleBox = false;
        bool hasFocusedCommentBox = false;


        public NewCommentItem(TaskController taskController, MainWindow mainWindow, TaskDetailsWindow taskDetailsWindow)
        {
            InitializeComponent();
            this.taskController = taskController;
            this.mainWindow = mainWindow;
            this.taskDetailsWindow = taskDetailsWindow;
        }

        private void CommentTitleBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!hasFocusedTitleBox)
            {
                hasFocusedTitleBox = true;
                CommentTitleBox.Text = "";
            }
        }

        private void CommentBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!hasFocusedCommentBox)
            {
                hasFocusedCommentBox = true;
                CommentBox.Text = "";
            }
        }

        private async void CreateCommentButton_Click(object sender, RoutedEventArgs e)
        {
            if (CommentTitleBox.Text.Trim() != "")
            {
                try
                {
                    taskController.CreateNote(CommentTitleBox.Text, CommentBox.Text);
                    mainWindow.IncreaseCommentsCreatedCount();
                    mainWindow.SaveData();
                    taskDetailsWindow.PopulateCommentslist();
                    mainWindow.CloseCreateCommentWindow(this);
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
                MessageBox.Show("Please, enter a name for your comment.");
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.CloseCreateCommentWindow(this);
        }
    }
}

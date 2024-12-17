using System.Windows;
using System.Windows.Controls;


namespace Projecraft.Views
{
    /// <summary>
    /// Interaction logic for TaskDetailsWindow.xaml
    /// </summary>
    public partial class TaskDetailsWindow : UserControl
    {

        MainWindow mainWindow;
        TaskController taskController;

        public TaskDetailsWindow(MainWindow mainWin, TaskController tController)
        {
            InitializeComponent();
            mainWindow = mainWin;
            taskController = tController;

            PopulateTaskDetails();
        }

        public void PopulateTaskDetails()
        {
            Dictionary<string, string> taskDict = taskController.GetTaskInformation();

            TaskNameText.Content = taskDict["Name"];
            TaskDescriptionText.Text = taskDict["Description"];
            TaskDateText.Text = taskDict["Creation Date"];
            TaskDueDateText.Text = taskDict["Due Date"];
            TaskCategoryText.Text = taskDict["Category"];

            PopulateChecklist();

        }

        public void PopulateChecklist()
        {
            Dictionary<string, bool> checkListDict = taskController.GetTaskCheckList();

            DataBox.Children.Clear();

            foreach (string checkBox in checkListDict.Keys) 
            {
                TaskChecklistItem newCheckListItem = new TaskChecklistItem(checkBox, checkListDict[checkBox], taskController, this, mainWindow);
                DataBox.Children.Add(newCheckListItem);
            }
        }

        public void PopulateCommentslist()
        {
            Dictionary<string, Dictionary<string, string>> commentsDict = taskController.GetTaskNotes();

            DataBox.Children.Clear();

            foreach (string commentTitle in commentsDict.Keys)
            {
                foreach (string commentDate in commentsDict[commentTitle].Keys) 
                { 
                    string comment = commentsDict[commentTitle][commentDate];

                    TaskCommentsItem newTaskCommentItem = new TaskCommentsItem(commentTitle, commentDate, comment, taskController, this, mainWindow);
                    DataBox.Children.Add(newTaskCommentItem);
                }
            }
        }



        private void CommentsButton_Click(object sender, RoutedEventArgs e)
        {
            PopulateCommentslist();
        }

        private void CheckList_Click(object sender, RoutedEventArgs e)
        {
            PopulateChecklist();
        }

        private void AddNewButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckListButton.IsChecked == true) 
            { 
                NewCheckListItem newChecklistItem = new NewCheckListItem(taskController, this, mainWindow);
                DataBox.Children.Add(newChecklistItem);
            }
            else if (CommentsButton.IsChecked == true) 
            {
                mainWindow.CreateCommentWindow();
            }
        }

        public void RemoveNewChecklistItem(NewCheckListItem newCheckListItem)
        {
            DataBox.Children.Remove(newCheckListItem);
            mainWindow.SaveData();
        }

        private void EditTaskButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.EditTaskWindow();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            
            mainWindow.CloseTaskDetailsWindow(this);
        }
    }
}

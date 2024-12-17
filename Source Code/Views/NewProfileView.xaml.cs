using System.Media;
using System.Windows;
using System.Windows.Controls;


namespace Projecraft.Views
{
    /// <summary>
    /// Interaction logic for NewProfileView.xaml
    /// </summary>
    public partial class NewProfileView : UserControl
    {
        List<string> goals = new List<string>();
        MainWindow mainWindow;
        ProfileController profileController;

        public NewProfileView(MainWindow mainWindow, ProfileController profileController)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            PopulateGoalList();
            this.profileController = profileController;
        }

        private void PopulateGoalList()
        {
            if (goals.Count > 0) 
            {
                foreach (string goal in goals)
                {
                    GoalItem goalItem = new GoalItem(this, goal);
                    GoalsBox.Children.Add(goalItem);
                }
            }

            NewGoalItem newGoalItem = new NewGoalItem(this);
            GoalsBox.Children.Add(newGoalItem);
        }

        public void AddGoal(string goal)
        {
            goals.Add(goal);
            GoalsBox.Children.Clear();
            PopulateGoalList();
        }

        public void RemoveGoal(string goal)
        {
            goals.Remove(goal);
            GoalsBox.Children.Clear();
            PopulateGoalList();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProfileNameBox.Text.Trim() != "")
            {
                try
                {
                    if (ProfileNameBox.Text.Trim() != "")
                    {
                        mainWindow.NewProfile(ProfileNameBox.Text, goals);
                    }
                    else
                    {
                        SystemSounds.Asterisk.Play();
                        MessageBox.Show("Enter a name to create a profile.");
                    }
                }
                catch (Exception ex)
                {
                    SystemSounds.Asterisk.Play();
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                SystemSounds.Asterisk.Play();
                MessageBox.Show("Please enter a name for your profile.");
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.CloseNewProfileView(this);
        }
    }
}

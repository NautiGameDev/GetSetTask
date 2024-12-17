using System.Windows.Controls;


namespace Projecraft.Views
{
    /// <summary>
    /// Interaction logic for ProfileView.xaml
    /// </summary>
    public partial class ProfileView : UserControl
    {
        ProfileController profileController { get; set; }
        MainWindow mainWindow { get; set; }

        public ProfileView(ProfileController profileController, MainWindow mainWindow)
        {
            InitializeComponent();
            this.profileController = profileController;
            this.mainWindow = mainWindow;

            PopulateProfileView();
        }

        public void PopulateProfileView()
        {
            Dictionary<string, string> profileData = profileController.GetProfileInformation();

            ProfileNameText.Text = profileData["userName"];
            ProjectsCreatedText.Text = profileData["projectsCreated"];
            TasksCreatedText.Text = profileData["tasksCreated"];
            TasksCompletedText.Text = profileData["tasksCompleted"];
            StepsCreatedText.Text = profileData["stepsCreated"];
            StepsCompletedText.Text = profileData["stepsCompleted"];
            CommentsCreatedText.Text = profileData["notesCreated"];

            List<string> goals = profileController.GetGoals();

            GoalsBox.Children.Clear();

            if (goals != null)
            {
                foreach (string goal in goals)
                {
                    GoalItem goalItem = new GoalItem(profileController, this, goal);
                    GoalsBox.Children.Add(goalItem);
                }
            }

            

            NewGoalItem newGoalItem = new NewGoalItem(this);
            GoalsBox.Children.Add(newGoalItem);
        }

        public void AddGoal(string goal)
        {
            profileController.AddGoal(goal);
            PopulateProfileView();
            mainWindow.SaveData();
        }

        public void RemoveGoal(string goal) 
        {
            profileController.RemoveGoal(goal);
            PopulateProfileView();
            mainWindow.SaveData();
        }
    }
}

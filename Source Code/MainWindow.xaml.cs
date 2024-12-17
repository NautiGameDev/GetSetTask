using Projecraft.Views;
using System.Windows;
using System.Windows.Input;


namespace Projecraft
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Spash screen views
        public Projecraft.Views.SplashScreen splashScreen { get; set; }
        public NewProfileView newProfileView { get; set; }

        //Main window views
        public ProjectsView projectsView { get; set; }
        public ProfileView profileView { get; set; }

        //Project Views
        public NewProjectView newProjectView { get; set; }
        public ProjectDetailsView projectDetailsView { get; set; }
        public EditProjectView editProjectView { get; set; }

        //Task Views
        public NewTaskWindow newTaskWindow { get; set; }
        public TaskDetailsWindow taskDetailsWindow { get; set; }
        public EditTaskView editTaskView { get; set; }
        public NewCommentItem newCommentItem { get; set; }
              
        //Controllers
        ProfileController profileController { get; set; }
        ProjectDBController projectDBController { get; set; }
        ProjectController projectController { get; set; }
        TaskController taskController { get; set; }
        


        public MainWindow()
        {
            InitializeComponent();

            DisplaySplashScreen();
        }

 #region Splash Screen Windows
        public void DisplaySplashScreen()
        {
            splashScreen = new Projecraft.Views.SplashScreen(this);
            ContentBox.Children.Add(splashScreen);
        }

        public void CreateNewProfileView()
        {
            profileController = new ProfileController();
            NewProfileView newProfileView = new NewProfileView(this, profileController);
            ContentBox.Children.Add(newProfileView);
        }

        public void NewProfile(string userName, List<string> goals)
        {
            Profile newProfile = profileController.CreateNewProfile(userName, goals);
            projectDBController = new ProjectDBController(newProfile, profileController.GetProfileDatabase());
            projectController = new ProjectController();
            taskController = new TaskController();

            ProjectsButton.Visibility = Visibility.Visible;
            ProfileButton.Visibility = Visibility.Visible;

            ChangeToProjectsWindow();

            splashScreen = null;
        }

        public void CloseNewProfileView(NewProfileView newProfileView)
        {
            ContentBox.Children.Remove(newProfileView);
        }

        public void UserLogIn(string userName)
        {
            if (profileController == null) 
            {
                profileController = new ProfileController();
            }
            
            Profile userProfile = profileController.LoadProfile(userName);
            ProjectDB dataBase = profileController.GetProfileDatabase(); //Profile database is created and loaded in profile controller
            projectDBController = new ProjectDBController(userProfile, dataBase);
            projectController = new ProjectController();
            taskController = new TaskController();

            ProjectsButton.Visibility = Visibility.Visible;
            ProfileButton.Visibility = Visibility.Visible;
            
            ChangeToProjectsWindow();

            splashScreen = null;
        }
        #endregion

 #region Main Window Views
        public void ChangeToProjectsWindow()
        {
            ProjectsButton.IsChecked = true;
            this.profileView = null;
            ContentBox.Children.Clear();
            projectsView = new ProjectsView(this, projectDBController);
            ContentBox.Children.Add(projectsView);
        }

        public void RefreshProjects()
        {
            projectsView.RefreshProjects();
        }

        public void ChangeToProfileWindow()
        {
            this.projectsView = null;
            ContentBox.Children.Clear();
            profileView = new ProfileView(profileController, this);
            ContentBox.Children.Add(profileView);
        }
#endregion

        public void ProjectDetailsWindow(Project project)
        {
            projectController.SetSelectedProject(project);
            projectDetailsView = new ProjectDetailsView(this, projectController);
            ContentBox.Children.Add(projectDetailsView);
        }

        public void RefreshProjectDetailsWindow()
        {
            if (projectDetailsView != null) 
            {
                projectDetailsView.PopulateProjectWindow();
            }
        }
        public void CloseProjectDetailsWindow(ProjectDetailsView projectDetailsView)
        {
            ContentBox.Children.Remove(projectDetailsView);
            this.projectDetailsView = null;
        }

        public void CreateProjectWindow()
        {
            ProjectsButton.IsChecked = false;
            newProjectView = new NewProjectView(this, projectDBController);
            ContentBox.Children.Add(newProjectView);
        }

        public void CloseCreateProjectWindow(NewProjectView newProjectView)
        {
            ContentBox.Children.Remove(newProjectView);
            this.newProjectView = null;
        }

        public void EditProjectView()
        {
            editProjectView = new EditProjectView(this, projectController, projectDBController, projectDetailsView);
            ContentBox.Children.Add(editProjectView);
        }

        public void CloseEditProjectView(EditProjectView editProjectView)
        {
            ContentBox.Children.Remove(editProjectView);
            RefreshProjectDetailsWindow();
            RefreshProjects();
            this.editProjectView = null;
        }

 #region Task Windows
        public void CreateTaskWindow()
        {
            newTaskWindow = new NewTaskWindow(this, projectController);
            ContentBox.Children.Add(newTaskWindow);
        }

        public void CloseCreateTaskWindow(NewTaskWindow newTaskWindow)
        {
            ContentBox.Children.Remove(newTaskWindow);
            this.newTaskWindow = null;
        }

        public void TaskDetailsWindow(Task task)
        {
            taskController.SetSelectedTask(task);
            taskDetailsWindow = new TaskDetailsWindow(this, taskController);
            ContentBox.Children.Add(taskDetailsWindow);
            taskDetailsWindow.PopulateTaskDetails();
        }

        public void CloseTaskDetailsWindow(TaskDetailsWindow taskDetailsWindow)
        {
            ContentBox.Children.Remove(taskDetailsWindow);
            this.taskDetailsWindow = null;
            projectDetailsView.PopulateProjectWindow();
        }

        public void RefreshTaskDetailsWindow()
        {
            taskDetailsWindow.PopulateTaskDetails();
        }

        public void EditTaskWindow()
        {
            editTaskView = new EditTaskView(this, taskController, projectController);
            ContentBox.Children.Add(editTaskView);
        }

        public void CloseEditTaskWindow(EditTaskView editTaskView)
        {
            ContentBox.Children.Remove(editTaskView);
            this.editTaskView = null;
        }

        public void CreateCommentWindow()
        {
            newCommentItem = new NewCommentItem(taskController, this, taskDetailsWindow);
            ContentBox.Children.Add(newCommentItem);
        }

        public void CloseCreateCommentWindow(NewCommentItem newCommentItem)
        {
            ContentBox.Children.Remove(newCommentItem);
        }
        #endregion

        #region Main Window Interactions
        private void ProjectsButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeToProjectsWindow();
        }

        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeToProfileWindow();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) 
            {
                DragMove();
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            NullifyAllObjects();
            projectsView = null;
            this.Close();
        }
        #endregion

        #region Data Management
        private void NullifyAllObjects()
        {
            
            projectsView = null;
            newProjectView = null;
            projectDetailsView = null;
            newTaskWindow = null;
            taskDetailsWindow = null;
            newCommentItem = null;
            
        }

        public void SaveData()
        {
            profileController.SaveProfileData();
            projectDBController.SaveProjectData();
        }
        #endregion

        #region increase profile counts
        public void IncreaseProjectCount()
        {
            profileController.IncreaseProjectCount();
        }

        public void IncreaseTaskCreatedCount()
        {
            profileController.IncreaseTasksCreatedCount();
        }

        public void IncreaseTaskCompetedCount()
        {
            profileController.IncreaseTasksCompletedCount();
        }

        public void IncreaseStepsCreatedCount()
        {
            profileController.IncreaseStepsCreatedCount();
        }

        public void IncreaseStepsCompletedCount()
        {
            profileController.IncreaseStepsCompleted();
        }

        public void DecreaseStepsCompletedCount()
        {
            profileController.DecreaseStepsCompleted();
        }

        public void IncreaseCommentsCreatedCount()
        {
            profileController.IncreaseNotesCreatedCount();
        }
        #endregion
    }
}
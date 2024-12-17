using System.Media;
using System.Windows;
using System.Windows.Controls;

namespace Projecraft.Views
{
    /// <summary>
    /// Interaction logic for EditProjectView.xaml
    /// </summary>
    public partial class EditProjectView : UserControl
    {
        MainWindow mainWindow { get; set; }
        ProjectDetailsView projectDetailsView { get; set; }
        ProjectController projectController { get; set; }
        ProjectDBController projectDBController { get; set; }

        public EditProjectView(MainWindow mainWindow, ProjectController projectController, ProjectDBController projectDBController, ProjectDetailsView projectDetailsView)
        {
            InitializeComponent();

            this.mainWindow = mainWindow;
            this.projectController = projectController;
            this.projectDBController = projectDBController;
            this.projectDetailsView = projectDetailsView;

            PopulateEditProjectWindow();
            
        }

        public void PopulateEditProjectWindow()
        {
            Dictionary<string, string> projectInfo = projectController.GetProjectInformation();

            ProjectNameBox.Text = projectInfo["Name"];
            ProjectCategoryBox.Text = projectInfo["Category"];
            ProjectDescriptionBox.Text = projectInfo["Description"];
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.CloseEditProjectView(this);
        }

        private void EditProjectButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProjectNameBox.Text.Trim() != "")
            {
                Dictionary<string, string> projectInfo = new Dictionary<string, string>();

                projectInfo["Name"] = ProjectNameBox.Text;
                projectInfo["Category"] = ProjectCategoryBox.Text;
                projectInfo["Description"] = ProjectDescriptionBox.Text;


                try
                {
                    Dictionary<string, string> origProjectInfo = projectController.GetProjectInformation();

                    projectDBController.UpdateProject(origProjectInfo["Name"], projectInfo["Name"]);

                    projectController.SetProjectInformation(projectInfo);
                    mainWindow.SaveData();
                    mainWindow.CloseEditProjectView(this);
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
                MessageBox.Show("Please enter a name for your project.");
            }
        }

        private void DeleteProjectButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                projectDBController.RemoveProject(projectController.GetProjectName());
                mainWindow.SaveData();
                mainWindow.RefreshProjects();
                mainWindow.CloseProjectDetailsWindow(projectDetailsView);
                mainWindow.CloseEditProjectView(this);
            }
            catch (Exception ex)
            {
                SystemSounds.Asterisk.Play();
                MessageBox.Show(ex.ToString());
            }
        }
    }
}

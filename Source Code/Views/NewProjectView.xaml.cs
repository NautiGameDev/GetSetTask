using System.Media;
using System.Windows;
using System.Windows.Controls;


namespace Projecraft.Views
{
    /// <summary>
    /// Interaction logic for NewProjectView.xaml
    /// </summary>
    public partial class NewProjectView : UserControl
    {
        MainWindow mainWindow {  get; set; }
        ProjectDBController projectDBController { get; set; }

        public NewProjectView(MainWindow mainWin, ProjectDBController projDBCont)
        {
            InitializeComponent();
            mainWindow = mainWin;
            projectDBController = projDBCont;
        }

        private void CreateProject_Click(object sender, RoutedEventArgs e)
        {
            if (ProjectNameBox.Text.Trim() != "")
            {
                try
                {
                    string projectName = ProjectNameBox.Text;
                    string projectCategory = ProjectCategoryBox.Text;
                    string projectDescription = ProjectDescriptionBox.Text;
                    string projectDate = DateTime.Now.ToString();

                    ClearTextBoxes();

                    projectDBController.CreateNewProject(projectName, projectDescription, projectCategory, projectDate);
                    mainWindow.IncreaseProjectCount();
                    mainWindow.SaveData();
                    mainWindow.ChangeToProjectsWindow();
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
                MessageBox.Show("Please enter a project name.");
            }
        }

        public void ClearTextBoxes()
        {
            ProjectNameBox.Clear();
            ProjectCategoryBox.Clear();
            ProjectDescriptionBox.Clear();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.CloseCreateProjectWindow(this);
        }
    }
}

using System.Windows.Controls;
using System.Windows.Input;


namespace Projecraft.Views
{
    /// <summary>
    /// Interaction logic for ProjectBox.xaml
    /// </summary>
    public partial class ProjectBox : UserControl
    {
        Project project {  get; set; }
        MainWindow mainWindow;
        public ProjectBox(Project proj, MainWindow mainWin)
        {
            InitializeComponent();
            project = proj;

            Dictionary<string, Task> taskDict = project.GetTasks();

            projectNameText.Text = project.projectName;
           
            projectDescriptionText.Text = project.projectDescription;
            mainWindow = mainWin;
        }

        private void StackPanel_MouseUp(object sender, MouseButtonEventArgs e)
        {
            mainWindow.ProjectDetailsWindow(project);
        }
    }
}

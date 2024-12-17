using System.Windows;
using System.Windows.Controls;


namespace Projecraft.Views
{
    

    public partial class ProjectsView : UserControl
    {
        MainWindow mainWindow {  get; set; }
        ProjectDBController projectDBController { get; set; }

        public ProjectsView(MainWindow mainWin, ProjectDBController projectDBCont)
        {
            InitializeComponent();
            mainWindow = mainWin;
            projectDBController = projectDBCont;

            RefreshProjects();

        }

        private void NewProject_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.CreateProjectWindow();
        }

        public void RefreshProjects()
        {
            LeftColumn.Children.Clear();
            CenterColumn.Children.Clear();
            RightColumn.Children.Clear();

            Dictionary<string, Project> projectsDict = projectDBController.GetProjectDictionary();

            int columnIndex = 0;

            foreach (String projName in projectsDict.Keys)
            {
                ProjectBox newProjectBox = new ProjectBox(projectsDict[projName], mainWindow);
                if (columnIndex == 0)
                {
                    LeftColumn.Children.Add(newProjectBox);
                }
                else if (columnIndex == 1)
                {
                    CenterColumn.Children.Add(newProjectBox);
                }
                else if (columnIndex == 2)
                {
                    RightColumn.Children.Add(newProjectBox);
                }

                columnIndex++;
                if (columnIndex > 2)
                {
                    columnIndex = 0;
                }
            }
        }
    }
}

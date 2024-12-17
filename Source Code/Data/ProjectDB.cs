namespace Projecraft
{
    public class ProjectDB
    {
        public Dictionary<string, Project> projects {get; set;}
    

        public ProjectDB()
        {
            if (projects == null)
            {
                projects = new Dictionary<string, Project>();
            }
            
        }


        public void NewProject(string projectName, string projectDescription, string projectDate, string projectTheme)
        {
            if (!projects.ContainsKey(projectName))
            {
                projects[projectName] = new Project(projectName, projectDescription, projectTheme, projectDate);
            }
            else
            {
                throw new Exception($"A project with the name {projectName} already exists.");
            }

        }

        public void RemoveProject(string projectName)
        {
            projects.Remove(projectName);
        }

        public void UpdateProject(string origProjectName, string newProjectName)
        {
            if (!projects.ContainsKey(newProjectName))
            {
                Project project = projects[origProjectName];
                projects[newProjectName] = project;
                projects.Remove(origProjectName);
            }
            else
            {
                throw new Exception($"A project with the name {newProjectName} already exists.");
            }
        }
        

        public Dictionary<string, Project> GetProjectDictionary()
        {
            return projects;
        }

        public Project GetProject(string projectName)
        {
            return projects[projectName];
        }
    }


}
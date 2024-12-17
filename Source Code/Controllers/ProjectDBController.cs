using Microsoft.VisualBasic;

namespace Projecraft
{
    public class ProjectDBController
    {
        
        Profile userProfile;
        ProjectDB projectData;

        public ProjectDBController(Profile uProfile, ProjectDB dataBase)
        {
            userProfile = uProfile;
            projectData = dataBase;
        }

        public void SaveProjectData()
        {
            try
            {
                DataController.SaveData(projectData, AppDomain.CurrentDomain.BaseDirectory + userProfile.profileDirectory);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occured while trying to save project data.\n {ex}");
            }
        }

        public Dictionary<string, Project> GetProjectDictionary()
        {
            return projectData.GetProjectDictionary();
        }

        public void CreateNewProject(string projectName, string projectDescription, string projectCategory, string projectDate)
        {
            try
            {
                projectData.NewProject(projectName, projectDescription, projectDate, projectCategory);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while trying to create {projectName}.\n {ex}");
            }
        }

        public void RemoveProject(string projectName)
        {
            try
            {
                projectData.RemoveProject(projectName);
            }
            catch (Exception ex) 
            {
                throw new Exception($"An error occured while trying to remove project {projectName}.\n {ex}");
            }
        }

        public void UpdateProject(string origProjectName, string newProjectName)
        {
            try
            {
                projectData.UpdateProject(origProjectName, newProjectName);
            }
            catch (Exception ex) 
            {
                throw new Exception($"An error occured while trying to update the project {origProjectName}.\n {ex}");
            }
        }
    }
}
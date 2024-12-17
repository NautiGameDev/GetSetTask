namespace Projecraft
{
    public class ProjectController
    {
        Project selectedProject;

        #region Project Management
        public void SetSelectedProject(Project project)
        {
            selectedProject = project;
        }

        public void RemoveSelectedProject()
        {
            selectedProject = null;
        }

        public Project GetSelectedProject()
        {
            return selectedProject;
        }

        public string GetProjectName()
        {
            return selectedProject.GetProjectName();
        }

        public Dictionary<string, string> GetProjectInformation()
        {
            return selectedProject.GetProjectInformation();
        }

        public void SetProjectInformation(Dictionary<string, string> projectInformation) 
        {
            try
            {
                selectedProject.SetProjectInformation(projectInformation);
            }
            catch (Exception ex) 
            {
                throw new Exception($"There was an problem updating the project information.\n {ex}");
            }
        }
        #endregion

        #region project management
        public Dictionary<string, Task> GetTasks()
        {
            return selectedProject.GetTasks();
        }

        public Dictionary<string, Task> GetCompletedTasks()
        {
            return selectedProject.GetCompletedTasks();            
        }

        public void NewTask(string taskTitle, string taskDescription, string taskCreationDate, string taskDueDate, string taskCategory)
        {
            try
            {
                selectedProject.AddTask(taskTitle, taskDescription, taskCreationDate, taskDueDate, taskCategory);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while trying to create {taskTitle}. \n {ex}");
            }
        }

        public void RemoveTask(string taskTitle)
        {
            try
            {
                selectedProject.RemoveTask(taskTitle);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while trying to remove {taskTitle}.\n {ex}");
            }
        }

        public void UpdateTask(string origTaskTitle, string newTaskTitle)
        {
            try
            {
                selectedProject.UpdateTask(origTaskTitle, newTaskTitle);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while trying to update the task {origTaskTitle}.\n {ex}");
            }
        }

        public void SetTaskToComplete(string taskTitle)
        {
            try
            {
                selectedProject.MoveTaskToComplete(taskTitle);
            }
            catch (Exception ex) 
            {
                throw new Exception($"An error occurred while trying to sat {taskTitle} to complete. \n {ex}");
            }
        }
        #endregion

    }
}
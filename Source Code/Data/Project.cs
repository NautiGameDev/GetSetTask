namespace Projecraft
{
    public class Project
    {
        //Project information
        public string projectName {get; set;}
        public string projectDescription {get; set;}
        public string projectCategory {get; set;}
        public string projectDate {get; set;}


        //Added for potential future updates - Currently not used
        public int recordedHours {get; set;}
        public int recordedMinutes {get; set;}
        public int recordedSeconds {get; set;}


        //Task variables
        public Dictionary<string, Task> projectTasks {get; set;}
        public Dictionary<string, Task> completedTasks {get; set;}

        public Project()
        {
            //Exists for JSON Deserialization
        }

        public Project(string pName, string pDescription, string pTheme, string pDate)
        {
            projectName = pName;
            projectDescription = pDescription;
            projectCategory = pTheme;
            projectDate = pDate;

            projectTasks = new Dictionary<string, Task>();
            completedTasks = new Dictionary<string, Task>();

        }

        #region Task Management
        public void AddTask(string taskTitle, string taskDescription, string taskCreationDate, string taskDueDate, string taskCategory)
        {
            if (!projectTasks.ContainsKey(taskTitle) && !completedTasks.ContainsKey(taskTitle))
            {
                Task newTask = new Task(this, taskTitle, taskDescription, taskCreationDate, taskDueDate, taskCategory);
                projectTasks[taskTitle] = newTask;
            }
            else
            {
                throw new Exception($"A task with the title {taskTitle} already exists.");
            }
        }

        public void RemoveTask(string taskTitle)
        {
            projectTasks.Remove(taskTitle);
        }

        public void UpdateTask(string origTaskTitle, string newTaskTitle)
        {
            if (!projectTasks.ContainsKey(newTaskTitle) && !completedTasks.ContainsKey(newTaskTitle))
            {
                Task originalTask = projectTasks[origTaskTitle];
                projectTasks[newTaskTitle] = originalTask;
                projectTasks.Remove(origTaskTitle);
            }
            else
            {
                throw new Exception($"A task with the name {newTaskTitle} already exists.");
            }
        }
        public void MoveTaskToComplete(string taskTitle)
        {
            if (projectTasks.ContainsKey(taskTitle))
            {
                Task task = projectTasks[taskTitle];
                task.SetTaskToComplete();
                completedTasks[taskTitle] = task;
                projectTasks.Remove(taskTitle);
            }
            else
            {
                throw new Exception($"{taskTitle} doesn't exist in the task dictionary.");
            }
        }
        public Dictionary<string, Task> GetTasks()
        {
            return projectTasks;
        }
        
        public Dictionary<string, Task> GetCompletedTasks()
        {
            return completedTasks;
        }
        #endregion

        #region GetSet Project Information
        public string GetProjectName()
        {
            return projectName;
        }
                

        public Dictionary<string, string> GetProjectInformation()
        {
            return new Dictionary<string, string> {
                {"Name", projectName},
                {"Description", projectDescription},
                {"Category", projectCategory},
                {"Date", projectDate}
            };
        }

        public void SetProjectInformation(Dictionary<string, string> projectInfo)
        {
            projectName = projectInfo["Name"];
            projectDescription = projectInfo["Description"];
            projectCategory = projectInfo["Category"];
        }
        #endregion
        
    }
}
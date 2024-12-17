namespace Projecraft
{
    public class Profile
    {
        public string profileDirectory {set; get;}
        
        public string userName { get; set; }

        public int tasksCreated { get; set; }
        public int tasksCompleted { get; set; }
        public int projectsCreated { get; set; }
        public int stepsCreated { get; set; }
        public int stepsCompleted { get; set; }
        public int notesCreated { get; set; }
        public int totalHoursWorked { get; set; }
        public int totalMinutesWorked { get; set; }
        public int totalSecondsWorked { get; set; }
        public List<string> goals {  get; set; }


        public Profile()
        {
            //Exists for JSON Deserialization
        }        

        public Profile(string name, string directory, List<string> goals)
        {
            userName = name;
            tasksCreated = 0;
            tasksCompleted = 0;
            projectsCreated = 0;
            stepsCreated = 0;
            stepsCompleted = 0;
            notesCreated = 0;

            profileDirectory = directory;
            this.goals = goals;

            totalHoursWorked = 0;
            totalMinutesWorked = 0;
            totalSecondsWorked = 0;
        }


 #region Getters and Setters
        public string GetUserName()
        {
            return userName;
        }

        public Dictionary<string, string> GetProfileInformation()
        {
            return new Dictionary<string, string>() {
                {"userName", userName},
                {"tasksCreated", tasksCreated.ToString()},
                {"tasksCompleted", tasksCompleted.ToString()},
                {"projectsCreated", projectsCreated.ToString()},
                {"stepsCreated", stepsCreated.ToString()},
                {"stepsCompleted", stepsCompleted.ToString()},
                {"notesCreated", notesCreated.ToString()},
                {"totalHoursWorked", totalHoursWorked.ToString()},
                {"totalMinutesWorked", totalMinutesWorked.ToString()},
                {"totalSecondsWorked", totalSecondsWorked.ToString()}
            };
        }
       
        public List<string> GetProfileGoals()
        {
            return goals;
        }

 #endregion


 #region Increase Counts
        public void IncreaseProjectCount()
        {
            projectsCreated++;
        }

        public void IncreaseTasksCreatedCount()
        {
            tasksCreated++;
        }

        public void IncreaseTasksCompletedCount()
        {
            tasksCompleted++;
        }

        public void IncreaseNotesCreatedCount()
        {
            notesCreated++;
        }

        public void IncreaseStepsCreatedCount()
        {
            stepsCreated++;
        }

        public void IncreaseStepsCompleted()
        {
            stepsCompleted++;
        }

        public void DecreaseStepsCompleted()
        {
            stepsCompleted--;
        }
 #endregion

 #region Goal managers
        public void AddGoal(string goal)
        {
            if (goals == null)
            {
                goals = new List<string>();
            }

            goals.Add(goal);
        }

        public void RemoveGoal(string goal) 
        {
            goals.Remove(goal);
        }

 #endregion
    }
}
using Microsoft.VisualBasic;

namespace Projecraft
{
    public class Task
    {
        Project parentProject;

        public string taskTitle {get; set;}
        public string taskDescription {get; set;}
        public string taskCreationDate {get; set;}
        public string taskDueDate {get; set;}
        public string taskCategory {get; set;}

        public bool isCompleted { get; set;}

        public Dictionary<string, bool> checkList {get; set;}
        public Dictionary<string, Dictionary<string, string>> taskNotes {get; set;}

        public Task()
        {
            //Exists for JSON Deserialization
        }

        public Task(Project tParent, string tTitle, string tDescription, string tCreationDate, string tDueDate, string tCategory)
        {
            parentProject = tParent;
            taskTitle = tTitle;
            taskDescription = tDescription;
            taskCreationDate = tCreationDate;
            taskDueDate = tDueDate;
            taskCategory = tCategory;

            checkList = new Dictionary<string, bool>();
            taskNotes = new Dictionary<string, Dictionary<string, string>>();
        }

 #region Setters and Getters
        public string GetTaskName()
        {
            return taskTitle;
        }

        public Dictionary<string, string> GetTaskInformation()
        {
            return new Dictionary<string, string>() {
                {"Name", taskTitle},
                {"Description", taskDescription},
                {"Creation Date", taskCreationDate},
                {"Due Date", taskDueDate},
                {"Category", taskCategory}
            };
        }

        public void SetTaskInformation(Dictionary<string, string> taskInfo)
        {
            taskTitle = taskInfo["Name"];
            taskDescription = taskInfo["Description"];
            taskCategory = taskInfo["Category"];
            taskDueDate = taskInfo["Due Date"];
        }

        public void SetTaskToComplete()
        {
            isCompleted = true;
        }

        public Dictionary<string, bool> GetTaskCheckList()
        {
            return checkList;
        }

        public Dictionary<string, Dictionary<string, string>> GetTaskNotes()
        {
            return taskNotes;
        }

 #endregion

 #region Note/Comment management
        public void AddNote(string noteTitle, string note)
        {
            if (!taskNotes.ContainsKey(noteTitle))
            {
                taskNotes[noteTitle] = new Dictionary<string, string>() { { DateTime.Now.ToString(), note } };
            }
            else 
            { 
                throw new Exception($"A comment with the title {noteTitle} already exists.");
            }
        }

        public void RemoveNote(string noteTitle)
        {
            
             taskNotes.Remove(noteTitle);
            
        }
#endregion

#region step/checklist management
        public void AddStep(string step)
        {
            if (!checkList.ContainsKey(step))
            {
                checkList[step] = false;
            }
            else
            {
                throw new Exception($"The step {step} already exists!");
            }
        }

        public void RemoveStep(string step)
        {
            checkList.Remove(step);
        }

        public void CompleteStep(string step)
        {
            checkList[step] = true;
        }

        public void UnCompleteStep(string step)
        {       
            checkList[step] = false;
        }
#endregion
    }
}
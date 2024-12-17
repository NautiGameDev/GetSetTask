namespace Projecraft
{
    public class TaskController
    {
        Task selectedTask;

        public void SetSelectedTask(Task task)
        {
            selectedTask = task;
        }

        public void RemoveSelectedTask()
        {
            selectedTask = null;
        }

        public Task GetCurrentTask()
        {
            return selectedTask;
        }

        public Dictionary<string, string> GetTaskInformation()
        {
            return selectedTask.GetTaskInformation();
        }

        public void SetTaskInformation(Dictionary<string, string> taskInformation)
        {
            try
            {
                selectedTask.SetTaskInformation(taskInformation);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while trying to update the task {taskInformation["Name"]}.\n {ex}");
            }
        }

        public Dictionary<string, bool> GetTaskCheckList()
        {
            return selectedTask.GetTaskCheckList();
        }

        public Dictionary<string, Dictionary<string, string>> GetTaskNotes()
        {
            return selectedTask.GetTaskNotes();
        }

        public void CreateNote(string noteTitle, string note)
        {
            try
            {
                selectedTask.AddNote(noteTitle, note);
            }
            catch (Exception ex) 
            {
                throw new Exception($"An error occurred while trying to create the comment {noteTitle}.\n {ex}");
            }
        }

        public void RemoveNote(string noteTitle)
        {
            try
            {
                selectedTask.RemoveNote(noteTitle);
            }
            catch (Exception ex) 
            {
                throw new Exception($"An error occurred while trying to remove the comment {noteTitle}.\n {ex}");
            }
        }

        public void AddStep(string step)
        {
            try
            {
                selectedTask.AddStep(step);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while trying to create a new step.\n {ex}");
            }
        }

        public void RemoveStep(string step)
        {
            try
            {
                selectedTask.RemoveStep(step);
            }
            catch (Exception ex) 
            {
                throw new Exception($"An error occurred while trying to remove the step {step}.\n {ex}");
            }
        }

        public void CompleteStep(string step)
        {
            try
            {
                selectedTask.CompleteStep(step);
            }
            catch (Exception ex) 
            {
                throw new Exception($"An error occurred while trying to set the step {step} as complete.\n {ex}");
            }
        }

        public void UnCompleteStep(string step)
        {
            try
            {
                selectedTask.UnCompleteStep(step);
            }
            catch(Exception ex) 
            {
                throw new Exception($"An error occurred while trying to set the step {step} as uncomplete.\n {ex}");
            }
        }
    }
}
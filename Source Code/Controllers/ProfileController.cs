using System.IO;

namespace Projecraft
{
    public class ProfileController
    {
        Profile currentProfile;
        ProjectDB projectDB;

        #region Data Management
        public Profile LoadProfile(string userName) //Needs refactored after creating profile page
        {
            try
            {
                string folderPath = AppDomain.CurrentDomain.BaseDirectory + "/Profiles/" + userName;

                currentProfile = DataController.LoadProfileData(folderPath);
                projectDB = DataController.LoadDataBase(folderPath);

                return currentProfile;
            }
            catch (Exception ex) 
            {
                throw new Exception($"An error occured while trying to load profile data.\n {ex}");
            }
        }

        public Profile CreateNewProfile(string userName, List<string> goals)
        {
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "/Profiles/" + userName))
            {
                try
                {
                    string profilePath = "/Profiles/" + userName;
                    string folderPath = AppDomain.CurrentDomain.BaseDirectory + profilePath;
                    Directory.CreateDirectory(folderPath);
                    Profile newProfile = new Profile(userName, profilePath, goals);
                    currentProfile = newProfile;
                    projectDB = new ProjectDB();
                    DataController.SaveData(newProfile, folderPath);
                    DataController.SaveData(projectDB, folderPath);

                    return currentProfile;
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred while trying to create a new profile for {userName}.\n {ex}");
                }
            }
            else
            {
                throw new Exception($"A profile with the name {userName} already exists.");
            }
        }

        public void SaveProfileData()
        {
            try
            {
                DataController.SaveData(currentProfile, AppDomain.CurrentDomain.BaseDirectory + currentProfile.profileDirectory);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while trying to save profile data.\n {ex}");
            }
        }
        #endregion

        #region Setters and Getters

        public ProjectDB GetProfileDatabase()
        {
            return projectDB;
        }


        public Dictionary<string, string> GetProfileInformation()
        {
            return currentProfile.GetProfileInformation();
        }

        public List<string> GetGoals()
        {
            return currentProfile.GetProfileGoals();
        }
        #endregion

        #region Goal Management

        public void AddGoal(string goal)
        {
            try
            {
                currentProfile.AddGoal(goal);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while creating the goal {goal}.\n {ex}");
            }
        }

        public void RemoveGoal(string goal)
        {
            try
            {
                currentProfile.RemoveGoal(goal);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while trying to remove the goal {goal}.\n {ex}");
            }
        }
        #endregion

        #region increase profile counts
        public void IncreaseProjectCount()
        {
            currentProfile.IncreaseProjectCount();
        }

        public void IncreaseTasksCreatedCount()
        {
            currentProfile.IncreaseTasksCreatedCount();
        }

        public void IncreaseTasksCompletedCount()
        {
            currentProfile.IncreaseTasksCompletedCount();
        }

        public void IncreaseNotesCreatedCount()
        {
            currentProfile.IncreaseNotesCreatedCount();
        }

        public void IncreaseStepsCreatedCount()
        {
            currentProfile.IncreaseStepsCreatedCount();
        }

        public void IncreaseStepsCompleted()
        {
            currentProfile.IncreaseStepsCompleted();
        }

        public void DecreaseStepsCompleted()
        {
            currentProfile.DecreaseStepsCompleted();
        }
        #endregion
    }
}
using System.IO;
using System.Text.Json;

namespace Projecraft
{
    public static class DataController
    {       
        public static void SaveData(Profile profile, string path)
        {
            var options = new JsonSerializerOptions();
            options.WriteIndented = true;
            string profileData = JsonSerializer.Serialize<Profile>(profile, options);

            if (File.Exists(path + "/ProfileData.json"))
            {
                File.Delete(path + "/ProfileData.json");
            }

            File.WriteAllText(path + "/ProfileData.json", profileData);
        }

        public static void SaveData(ProjectDB projectData, string path)
        {
            var options = new JsonSerializerOptions();
            options.WriteIndented = true;
            string projectDB = JsonSerializer.Serialize<ProjectDB>(projectData, options);

            if (File.Exists(path + "/ProjectData.json"))
            {
                File.Delete(path + "/ProjectData.json");
            }

            File.WriteAllText(path + "/ProjectData.json", projectDB);
        }

        public static Profile LoadProfileData(string path)
        {
            var profileData = File.ReadAllText(path + "/ProfileData.json");
            Profile loadedProfile = JsonSerializer.Deserialize<Profile>(profileData);
            profileData = null;
            return loadedProfile;
        }

        public static ProjectDB LoadDataBase(string path)
        {
            var projectData = File.ReadAllText(path + "/ProjectData.json");
            ProjectDB loadedDB = JsonSerializer.Deserialize<ProjectDB>(projectData);
            projectData = null;
            return loadedDB;
        }
    }
}
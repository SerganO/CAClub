using UnityEngine;
using System;
using System.IO;
using System.Linq;
using UnityEngine.UI;

public class SaveDataToJSON : MonoBehaviour
{
    public static bool IsChanged = false;

    public static readonly string SavingsFilesFolder = "UserProfiles";

    public ProfilesSceneScript profiles;

    public static string EnvDirectory
    {
        get
        {
            string envDirectory = "";
#if UNITY_ANDROID && !UNITY_EDITOR
            envDirectory = Application.persistentDataPath;
#else
            envDirectory = Application.dataPath;
#endif
            Debug.Log("Env Directory - " + envDirectory);
            return Path.Combine(envDirectory, SavingsFilesFolder);
        }
    }

    public Button StartButton;
    public Text CurrentUserLabel;
    public Text BlinkLabel;

    bool isFirstUpdate = true;

    void Update()
    {
        FirstUpdateIfNeeded();
    }

    protected void FirstUpdateIfNeeded()
    {
        if (isFirstUpdate)
        {
            FirstUpdate();
            isFirstUpdate = false;
        }
    }

    public virtual void FirstUpdate()
    {
        ProfileCheck();
    }

    void ProfileCheck()
    {
        string lastSavedUserLogin = "";

        Debug.Log("Full path: " + EnvDirectory);

        if (Directory.Exists(EnvDirectory))
        {
            Debug.Log("Before : " + GlobalUserData.userData);
            if (GlobalUserData.userData == null)
            {
                try
                {
                    FileInfo[] myFiles = GetFilesFromDirectoryByDate(new DirectoryInfo(EnvDirectory)).Where(x => x.Extension == ".json").ToArray();

                    if (myFiles.Length > 0)
                    {
                        lastSavedUserLogin = myFiles[0].Name;
                        Debug.Log("Last user in system:" + lastSavedUserLogin);
                    }
                }
                catch (Exception err)
                {
                    Debug.Log(err.Message);
                    ChangeStartButton(false);
                }
            }
            else
            {
                if (GlobalUserData.userData.login != "")
                {
                    lastSavedUserLogin = GlobalUserData.userData.login;
                    Debug.Log("User Global User Data login exist: " + lastSavedUserLogin);
                }
            }

            if (lastSavedUserLogin != "")
            {
                Debug.Log(lastSavedUserLogin);
                LoadUserDataFromFile(lastSavedUserLogin);
                Debug.Log("Loaded user profile: " + GlobalUserData.userData.login);
                SetupProfileLabel(true);
                CurrentUserLabel.text = GlobalUserData.userData.login;
                ChangeStartButton(true);
            }
            else
            {
                SetupProfileLabel(false);
                ChangeStartButton(false);
                Debug.Log("lastSavedUserLogin");
            }
        }
        else
        {
            try
            {
                Directory.CreateDirectory(EnvDirectory);
                SetupProfileLabel(false);
                ChangeStartButton(false);
                Debug.Log("Folder created!");
            }
            catch (Exception err)
            {
                Debug.Log(err.Message);
            }
        }
    }


    public void SetupProfileLabel(bool value)
    {
        CurrentUserLabel.gameObject.SetActive(value);
        BlinkLabel.gameObject.SetActive(!value);
    }

    public void UpdateForCurrent()
    {
        Debug.Log("UpdateForCurrent");
        Debug.Log(GlobalUserData.userData.login);
        SetupProfileLabel(true);
        CurrentUserLabel.text = GlobalUserData.userData.login;
        ChangeStartButton(true);
    }

    public static void LoadUserDataFromFile(string profileName)
    {
        string path = PathCombine(profileName);

        if (File.Exists(path))
        {
            try
            {
                UserData CurrentUserData = JsonUtility.FromJson<UserData>(File.ReadAllText(path));
                GlobalUserData.InitUserData(CurrentUserData);
                Debug.Log("Welcome " + CurrentUserData.login);
            }
            catch (Exception err)
            {
                Debug.Log(profileName);
                Debug.Log("File for load not exist!" + err.Message);
            }
        }
        else
        {
            Debug.Log("File for load not exist!" + path);
        }
    }

    public static string PathCombine(string profileName)
    {
        return Path.Combine(EnvDirectory, profileName);
    }

    public static FileInfo[] GetFilesFromDirectoryByDate(DirectoryInfo directory)
    {
        return directory.GetFiles().OrderByDescending(f => f.LastWriteTime).ToArray();
    }

    private void ChangeStartButton(bool needState)
    {
        StartButton.interactable = needState;
        StartButton.enabled = needState;
    }

//#if UNITY_ANDROID && !UNITY_EDITOR
//        private void OnApplicationPause(bool pause)
//        {
//            if (pause) {
//                SaveProfile(GlobalUserData.login, GlobalUserData.UserData());
//            }
//        }    
//#endif

    //private void OnApplicationQuit()
    //{
    //    if (GlobalUserData.userData != null)
    //    {
    //        SaveProfile(GlobalUserData.userData.login, GlobalUserData.UserData());
    //    }
    //}

    public static void AutoSaveData()
    {
        if (IsChanged && GlobalUserData.userData != null)
        {
            SaveProfile(GlobalUserData.userData.login, GlobalUserData.ActiveUser);
            IsChanged = false;
        }
    }

    public void Delete()
    {
        if (GlobalUserData.ActiveUser != null)
        {
            DeleteProfile(GlobalUserData.ActiveUser.login);
            GlobalUserData.ActiveUser = null;
            profiles.UpdateUI();
            ProfileCheck();
        }
    }

    public static void SaveProfile(string profileName, UserData userData)
    {
        string pathToSave = PathCombine(profileName) + ".json";
        try
        {
            if (!Directory.Exists(EnvDirectory))
            {
                DirectoryInfo di = Directory.CreateDirectory(EnvDirectory);
            }

            File.WriteAllText(pathToSave, JsonUtility.ToJson(userData));
        }
        catch (Exception e)
        {
            Console.WriteLine("The process failed: {0}", e.ToString());
        }
    }

    public static void DeleteProfile(string profileName)
    {
        string path = PathCombine(profileName) + ".json";
        try
        {
            File.Delete(path);
        }
        catch (Exception e)
        {
            Console.WriteLine("The process failed: {0}", e.ToString());
        }
    }
}
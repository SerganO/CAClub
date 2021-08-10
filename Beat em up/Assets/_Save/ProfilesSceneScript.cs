using System;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class ProfilesSceneScript : MonoBehaviour
{
    public GameObject ProfileButton;
    public Text CreateProfileText;

    public SaveDataToJSON handler;

    private FileInfo[] myFiles;

    void Start()
    {
        if (Directory.Exists(SaveDataToJSON.EnvDirectory))
        {
            try
            {
                UpdateUI();
            }
            catch (Exception err)
            {
                Debug.Log("cant get files from directory!" + err.Message);
            }
        }
    }

    void Update()
    {

    }

    public void UpdateUI()
    {
        foreach (Transform t in transform)
        {
            Destroy(t.gameObject);
        }

        UpdateProfilesList();
        
        foreach (FileInfo userFile in myFiles)
        {
            CreateListItem(userFile.Name.Split('.')[0]);
        }
    }

    private void UpdateProfilesList() {
        myFiles = SaveDataToJSON.GetFilesFromDirectoryByDate(new DirectoryInfo(SaveDataToJSON.EnvDirectory));
    }

    private void CreateListItem(string userName) {
        GameObject g = Instantiate(ProfileButton, transform);
        Button btn = g.GetComponentInChildren<Button>();
        btn.GetComponentInChildren<Text>().text = userName;
        btn.onClick.AddListener(() => this.ChangeSelectingIndex(btn));
    }
    

    private void ChangeSelectingIndex(Button btn)
    {
        SaveDataToJSON.LoadUserDataFromFile(btn.GetComponentInChildren<Text>().text + ".json");
        handler.UpdateForCurrent();
    }

    public bool CreateProfileHandler() {
        if (CreateProfileText == null) return false;

        string profileName = CreateProfileText.text.ToUpper();
        if (ValidateProfileName(profileName))
        {
            SaveDataToJSON.SaveProfile(profileName, new UserData(profileName));
            UpdateProfilesList();
            CreateListItem(profileName);
            SaveDataToJSON.LoadUserDataFromFile(profileName + ".json");
            handler.UpdateForCurrent();
            return true;
        }
        return false;
    }

    private readonly int MinProfileNameLength = 4;
    private readonly int MaxProfileNameLength = 12;

    private bool ValidateProfileName(string profileName) {
        foreach (FileInfo userFile in myFiles)
        {
            string userName = userFile.Name.Split('.')[0];

            if (userName == profileName) {
                return false;
            }
        }
        
        if(! (profileName.Length >= MinProfileNameLength && profileName.Length <= MaxProfileNameLength))
        {
            return false;
        }

        return !(profileName.IndexOfAny(System.IO.Path.GetInvalidFileNameChars()) != -1);
    }
}

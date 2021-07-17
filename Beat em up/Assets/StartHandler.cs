using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class StartHandler : SceneHandler
{
    public AudioClip background;
    public SceneLoader Loader;
    public MessagePanelScript messagePanel;
    public SaveDataToJSON SaveData;
    public ProfilesSceneScript Profiles;
    public TipsPanelScript Tips;

    public override void FirstUpdate()
    {
        if (MusicManager.playingAudioID != "menu")
        {
            MusicManager.instance.Play(background);
            MusicManager.playingAudioID = "menu";
        }

        if(TransitionMaster.needShowEndGameMessage)
        {
            messagePanel.SetMessageText(LocalizationManager.local.GetValueForId("EndGameMessage"));
            messagePanel.ShowInfo();
            TransitionMaster.needShowEndGameMessage = false;
        }

        if(PlayerPrefs.GetInt("MainTip") != 1)
        {
            Tips.ShowMainTip();
            PlayerPrefs.SetInt("MainTip", 1);
        }

    }

    public void ShowProfile()
    {
        if (PlayerPrefs.GetInt("ProfileTip") != 1)
        {
            Tips.ShowProfileTip();
            PlayerPrefs.SetInt("ProfileTip", 1);
        }
    }

    public void Quit()
    {
        messagePanel.SetMessageText(LocalizationManager.local.GetValueForId("QuitAccept"));
        messagePanel.ShowQuestions(Quit);
    }

    void Quit(bool value)
    {
        if(value) Application.Quit();
    }

    public void Delete()
    {
        if (GlobalUserData.ActiveUser == null) return;
        messagePanel.SetMessageText(LocalizationManager.local.GetValueForId("DeleteConfirmation") + GlobalUserData.ActiveUser.login);
        messagePanel.ShowQuestions(value =>
        {
            if(value)
            {
                SaveData.Delete();
            }
        });
    }

    public void Create()
    {
        if(!Profiles.CreateProfileHandler())
        {
            messagePanel.SetMessageText(LocalizationManager.local.GetValueForId("CreateError"));
            messagePanel.ShowInfo();
        }
    }

    public void LoadNextScene()
    {
        if(GlobalUserData.ActiveUser.IntroWatched)
        {
            Loader.LoadWithTransparent(SceneLoader.Scene.ChooseLevel);
        } else
        {
            Loader.LoadWithTransparent(SceneLoader.Scene.Intro);
        }
    }

    public void OpenTelegram()
    {
        Application.OpenURL("https://t.me/com_red");
    }

    public void OpenInstagram()
    {
        Application.OpenURL("https://instagram.com/com.red.gamedev");
    }


}

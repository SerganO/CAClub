using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.Advertisements;

public class LevelSceneHandler : SceneHandler
{
    public TipsPanelScript Tips;
    [Header("Debug area")]
    public bool isDebug = false;
    public string DefaultHeroId = "Angel";
    public Planet DefaulPlanet = Planet.Forest;
    public int DefaultSublevel = 1;
    [Space]
    public List<LevelBackEntity> sourcer;

    public SpriteRenderer BackgroundImage;
    public SpriteRenderer Land;

    public List<MoveButton> Buttons;

    public List<Hero> Heroes;

    public CameraWalker walker;

    Hero Hero;

    public Producer Producer;

    public LevelEndingUI levelEndingUI;

    public GameObject ControlGameObject;

    public AudioSource source;
    public AudioClip failClip;
    public AudioClip successClip;

    public string RewardedPlacementId = "video";

    private void Start()
    {
        if (Advertisement.isSupported)
        {
            Advertisement.Initialize("3952391", false);
        }
    }


    public string GetLevel()
    {
        if (isDebug)
        {
            return DefaulPlanet.ToString() + DefaultSublevel;
        }
        return TransitionMaster.CurrentPlanet.ToString() + TransitionMaster.CurrentSublevel;
    }

    public override void FirstUpdate()
    {
        Time.timeScale = 1;
        if (!GlobalUserData.ActiveUser.ShowLevelTip)
        {
            Tips.ShowLevelTip();
            GlobalUserData.ActiveUser.ShowLevelTip = true;
            SaveDataToJSON.IsChanged = true;
            Save();
        }

        var heroID = TransitionMaster.CurrentHeroID;

        if (isDebug)
        {
            SetupBackground(DefaulPlanet);
        }
        else
        {
            SetupBackground(TransitionMaster.CurrentPlanet);
        }

        foreach (var button in Buttons)
        {
            button.gameObject.SetActive(false);
        }

        Hero = Heroes.Find(x => x.ID == heroID);
        Hero.gameObject.SetActive(true);
        Hero.onDie += OnDie;
        Producer.OnSuccess += OnSuccess;

        walker.player = Hero.transform;

        foreach (var move in Hero.moves)
        {
            Buttons.Find(x => x == move.BindedButton).gameObject.SetActive(true);
        }
    }

    void SetupBackground(Planet planet)
    {
        BackgroundImage.sprite = sourcer.Find(x => x.Name == planet.ToString()).Background;
        Land.sprite = sourcer.Find(x => x.Name == planet.ToString()).Land;

        MusicManager.instance.Play(sourcer.Find(x => x.Name == planet.ToString()).BackAudio);
        MusicManager.playingAudioID = "level";
    }

    void OnDie()
    {
        Time.timeScale = 0;
        /*if (!GlobalUserData.ActiveUser.ShowLoseTip)
        {
            Tips.ShowLoseTip();
            GlobalUserData.ActiveUser.ShowLoseTip = true;
            SaveDataToJSON.IsChanged = true;
        }*/
        ControlGameObject.SetActive(false);
        MusicManager.instance.Stop();
        levelEndingUI.Fail();
        source.clip = failClip;
        source.Play();
        ShowVideo();
    }

    void OnSuccess()
    {
        Time.timeScale = 0;
        /*if (!GlobalUserData.ActiveUser.ShowWinTip)
        {
            Tips.ShowWinTip();
            GlobalUserData.ActiveUser.ShowWinTip = true;
            SaveDataToJSON.IsChanged = true;
        }*/
        SaveDataToJSON.IsChanged = true;
        ControlGameObject.SetActive(false);
        MusicManager.instance.Stop();
        levelEndingUI.Success();
        source.clip = successClip;
        source.Play();
        var level = GlobalUserData.ActiveUser.progress.Find(x => x.ID == GetLevel());
        if (level.progress)
        {
            GlobalUserData.ActiveUser.XP += InformationMaster.rewards[GetLevel()].nextReward;
            levelEndingUI.XPText.text = InformationMaster.rewards[GetLevel()].nextReward.ToString();
        }
        else
        {
            GlobalUserData.ActiveUser.XP += InformationMaster.rewards[GetLevel()].firstReward;
            levelEndingUI.XPText.text = InformationMaster.rewards[GetLevel()].firstReward.ToString();
            if (InformationMaster.ScrigalLevels.Contains(GetLevel()))
            {
                GlobalUserData.ActiveUser.scrigalPartCount++;
                levelEndingUI.SCRBlock.SetActive(true);
            }
        }
        level.progress = true;
        SaveDataToJSON.AutoSaveData();
    }

    void ShowVideo()
    {
        if (!Advertisement.isShowing)
        {
            if (Advertisement.IsReady())
            {
                var options = new ShowOptions { resultCallback = HandleShowResult };
                Advertisement.Show(RewardedPlacementId, options);

                //Advertisement.Show("rewardedVideo");

            }
        }
    }

    private void HandleShowResult(ShowResult result)
    {
        //switch (result)
        //{
        //    case ShowResult.Finished:
        //        Debug.Log("The ad was successfully shown.");

        //        GlobalUserData.ActiveUser.XP += GivenXP;
        //        SaveDataToJSON.IsChanged = true;
        //        SaveDataToJSON.AutoSaveData();

        //        UpdateXP();
        //        UpdateUI();
        //        UpdateScreen.UpdateXp();

        //        break;
        //    case ShowResult.Skipped:
        //        Debug.Log("The ad was skipped before reaching the end.");
        //        break;
        //    case ShowResult.Failed:
        //        Debug.LogError("The ad failed to be shown.");
        //        break;
        //}
    }
}

[System.Serializable]
public class LevelBackEntity
{
    public string Name;
    public Sprite Background;
    public Sprite Land;
    public AudioClip BackAudio;
}

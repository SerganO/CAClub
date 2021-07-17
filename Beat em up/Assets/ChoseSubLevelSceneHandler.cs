using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoseSubLevelSceneHandler : SceneHandler
{
    public TipsPanelScript Tips;
    public List<PlanetSprite> PlanetsSprite;
    public GameObject ChooseSublevelPanel;
    public Image planetImage;

    public SceneLoader Loader;

    public List<Button> buttons;
    public Sprite newLevel;
    public Sprite oldLevel;

    public Text ScrigalText;
    public TopPanelScript TopPanel;

    int sublevel;

    public AudioClip background;
    public void SetSublevel(int sub)
    {
        sublevel = sub;
        TransitionMaster.CurrentSublevel = sublevel;
    }

    public void ShowSublevel(int sub)
    {

        if (!GlobalUserData.ActiveUser.ShowHeroesTip)
        {
            Tips.ShowHeroesTip();
            GlobalUserData.ActiveUser.ShowHeroesTip = true;
            SaveDataToJSON.IsChanged = true;
        }
        Debug.Log(sub);
        SetSublevel(sub);
        ChooseSublevelPanel.SetActive(true);
        TopPanel.Setup();
    }

    public override void FirstUpdate()
    {
        if (!GlobalUserData.ActiveUser.GameEnded && GlobalUserData.ActiveUser.scrigalPartCount >= InformationMaster.ScrigalParts)
        {
            Loader.LoadWithTransparent(SceneLoader.Scene.Final);
        }
        else
        {

            if (!GlobalUserData.ActiveUser.ShowPlanetTip)
            {
                Tips.ShowPlanetTip();
                GlobalUserData.ActiveUser.ShowPlanetTip = true;
                SaveDataToJSON.IsChanged = true;
            }
            Save();
            if (MusicManager.playingAudioID != "menu")
            {
                MusicManager.instance.Play(background);
                MusicManager.playingAudioID = "menu";
            }
            TransitionMaster.CurrentHeroID = "Angel";
            planetImage.sprite = PlanetsSprite.Find(x => x.Planet == TransitionMaster.CurrentPlanet).Sprite;

            for (int i = 0; i < buttons.Count; i++)
            {
                if (GlobalUserData.ActiveUser.ProgressForLevel(TransitionMaster.CurrentPlanet.ToString() + (i + 1)))
                {
                    buttons[i].image.sprite = oldLevel;
                }
                else
                {
                    buttons[i].image.sprite = newLevel;
                }
            }

            ScrigalText.text = GlobalUserData.ActiveUser.scrigalPartCount.ToString() + ":" + InformationMaster.ScrigalParts.ToString();
        }
    }

    public void Load()
    {
        TransitionMaster.CurrentSublevel = sublevel;
        Loader.LoadWithImage(SceneLoader.Scene.Level);
    }

    public void LoadFinal()
    {
        Loader.LoadWithImage(SceneLoader.Scene.Level);
    }
}

[System.Serializable]
public class PlanetSprite
{
    public Planet Planet;
    public Sprite Sprite;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoseLevelSceneHandler : SceneHandler
{

    public AudioClip background;
    public SceneLoader Loader;
    public TipsPanelScript Tips;

public Text ScrigalText;

    Planet CurrentPlanet = Planet.Forest;

    public override void FirstUpdate()
    {
        if (!GlobalUserData.ActiveUser.GameEnded && GlobalUserData.ActiveUser.scrigalPartCount >= InformationMaster.ScrigalParts)
        {
            Loader.LoadWithTransparent(SceneLoader.Scene.Final);
        }
        else
        {
            if(!GlobalUserData.ActiveUser.ShowPlanetsTip)
            {
                Tips.ShowPlanetsTip();
                GlobalUserData.ActiveUser.ShowPlanetsTip = true;
                SaveDataToJSON.IsChanged = true;
            }
            Save();
            if (MusicManager.playingAudioID != "menu")
            {
                MusicManager.instance.Play(background);
                MusicManager.playingAudioID = "menu";
            }
            ScrigalText.text = GlobalUserData.ActiveUser.scrigalPartCount.ToString() + ":" + InformationMaster.ScrigalParts.ToString();
        }
    }

    public void SetPlanet(Planet planet)
    {
        CurrentPlanet = planet;
    }
    
    public void LoadNextScene()
    {
        Loader.LoadWithTransparent(SceneLoader.Scene.ChooseSublevel);
        TransitionMaster.CurrentPlanet = CurrentPlanet;
    }

    public void LoadPlanet(int planetCode)
    {
        SetPlanet((Planet)planetCode);
        LoadNextScene();
    }

    public void LoadPlanet(Planet planet)
    {
        SetPlanet(planet);
        LoadNextScene();
    }
}

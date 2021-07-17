using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopHandler : SceneHandler
{
    public SceneLoader Loader;
    public AudioClip background;
    public TipsPanelScript Tips;
    public MessagePanelScript Message;

    public BuyZoneScript Buy;

    public void Back()
    {
        Debug.Log(SceneLoader.PrevSceneId);
        Loader.LoadWithTransparent(SceneLoader.PrevSceneId);
    }

    public override void FirstUpdate()
    {
        MusicManager.instance.Play(background);
        MusicManager.playingAudioID = "shop";

        if (!GlobalUserData.ActiveUser.ShowUpgradeTip)
        {
            Tips.ShowUpgradeTip();
            GlobalUserData.ActiveUser.ShowUpgradeTip = true;
            SaveDataToJSON.IsChanged = true;
        }
    }

    public void BuyRequest(string id)
    {
        var heroData = HeroInfoMaster.HeroInfoForId(id);
        Message.SetMessageText(LocalizationManager.local.GetValueForId("BuyAccept") + heroData.Name + "(" + heroData.Cost+")");
        Message.ShowQuestions(ActiveBuy);
    }

    void ActiveBuy(bool value)
    {
        if (value) Buy.Buy();
    }
}

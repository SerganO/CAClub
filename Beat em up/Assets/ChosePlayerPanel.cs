using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChosePlayerPanel : MonoBehaviour
{

    public HeroListScript HeroList;
    public CurrentHeroZoneScript CurrentHeroZone;

    private void Start()
    {
        HeroList.IdChanged += ChoosePlayer;
        var ids = new List<string>();
        foreach(var hero in GlobalUserData.ActiveUser.heroes)
        {
            if (hero.isAvailable) ids.Add(hero.HeroID);
        }


        HeroList.SetupFromList(ids);
        
    }

    public void ChoosePlayer(HeroInfo info)
    {
        TransitionMaster.CurrentHeroID = info.id;
        CurrentHeroZone.Setup(info.Image, info.Name, info.Description);
    }


}

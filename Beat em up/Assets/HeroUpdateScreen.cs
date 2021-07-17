using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class HeroUpdateScreen : MonoBehaviour
{
    public HeroListScript heroList;
    public SkillListScript skillList;
    public BuyZoneScript BuyZone;

    public Text NameLabel;
    public Text XPPointsCountLabel;
    public Text XPPointsCountLabelAdd;



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
        GlobalUserData.XPUpdatted += GlobalUserData_XPUpdatted;
        UpdateXp();
        heroList.IdChanged += HeroList_IdChanged;
        heroList.SetupFromList(GlobalUserData.ActiveUser.heroes.Select(x=> x.HeroID).ToList());
        skillList.upgrade += SkillList_upgrade;
        BuyZone.BuyEvent += BuyZone_BuyEvent;
    }

    private void GlobalUserData_XPUpdatted()
    {
        UpdateXp();
        skillList.UpdateButton();
        BuyZone.UpdateButton();
    }

    private void BuyZone_BuyEvent()
    {
        UpdateXp();
        heroList.UpdateZone();
        skillList.UpdateZone();
    }

    private void SkillList_upgrade()
    {
        UpdateXp();
    }

    public void UpdateXp()
    {
        XPPointsCountLabel.text = GlobalUserData.ActiveUser.XP.ToString();
        XPPointsCountLabelAdd.text = GlobalUserData.ActiveUser.XP.ToString();
    }

    private void HeroList_IdChanged(HeroInfo info)
    {
        NameLabel.text = info.Name;
        var hero = GlobalUserData.ActiveUser.heroes.Find(x => x.HeroID == info.id);
        var list = new List<MoveData>
        {
            hero.HP
        };
        list.AddRange(hero.moves);
        skillList.SetupFromList(info.id, list);
        BuyZone.SetupForId(info.id);
    }

    private void OnDestroy()
    {
        GlobalUserData.XPUpdatted -= GlobalUserData_XPUpdatted;
    }
}

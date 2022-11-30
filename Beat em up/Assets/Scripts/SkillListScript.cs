using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class SkillListScript : MonoBehaviour
{
    public event VoidFunc upgrade;
    public SkillElement SkillElement;

    public List<SkillInfo> sourcer;
    
    string _hero;
    List<MoveData> _datas;

    public void SetupFromList(string hero, List<MoveData> datas)
    {
        _hero = hero;
        _datas = datas;
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        for (int i = 0; i < datas.Count; i++)
        {
            var button = Instantiate(SkillElement, gameObject.transform);
            var data = SkillMaster.GetSkillFor(hero, datas[i].ID, datas[i].level);
            button.Setup(hero, data);
            button.SetUpAction(() =>
            {
                button.NextLevel();
                upgrade();
            });
        }

    }

    public void UpdateZone()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        for (int i = 0; i < _datas.Count; i++)
        {
            var button = Instantiate(SkillElement, gameObject.transform);
            var data = SkillMaster.GetSkillFor(_hero, _datas[i].ID, _datas[i].level);
            button.Setup(_hero, data);
            button.SetUpAction(() =>
            {
                button.NextLevel();
                upgrade();
            });
        }
    }

    public void UpdateButton()
    {
        foreach (Transform child in transform)
        {
            var skillElement = child.GetComponent<SkillElement>();

            if(skillElement != null)
            {
                skillElement.SetupButton();
            }
        }
        
    }

}

[System.Serializable]
public class SkillInfo
{

    public string Id;
    public string HeroID;

    public bool isMax
    {
        get
        {
            return NextLevelCost == -1;
        }
    }

    public string Name
    {
        get
        {
            Debug.Log(Id);
            return LocalizationManager.local.GetValueForId(HeroID + Id + "Name");
        }
    }
    public string SpriteName;
    public Sprite Image
    {
        get {
            return Resources.Load<Sprite>("Sprites/Skills/" + SpriteName);
        }
    }
    public string Description
    {
        get
        {
            var des1 = LocalizationManager.local.GetValueForId(HeroID + Id + "Desc");
            if (isMax)
            {
                return des1 + "\n" + LocalizationManager.local.max;
            } else
            {
                var des2 = "";
                switch (HeroID)
                {
                    case "Angel":
                        des2 = AngelInfo.GetDescriptionForSkill(Id, Level);
                        break;
                    case "Reaper":
                        des2 = ReaperInfo.GetDescriptionForSkill(Id, Level);
                        break;
                    case "Mur":
                        des2 = MurInfo.GetDescriptionForSkill(Id, Level);
                        break;
                    case "Robot":
                        des2 = RobotInfo.GetDescriptionForSkill(Id, Level);
                        break;
                }

                return des1 + "\n" + des2;
            }
            
            
        }
    }
    public int NextLevelCost;
    public int Level;

    public override string ToString()
    {
        return Id + " " + Name + " " + SpriteName + Description + " " + NextLevelCost + " " + Level;
    }
}

public static class SkillMaster
{
    static string endl = "\n";



    static Dictionary<string, List<SkillInfo>> infos = new Dictionary<string, List<SkillInfo>> {
            {"Angel", new List<SkillInfo> {
        new SkillInfo {HeroID = "Angel", Id = "HP", Level = 1, NextLevelCost = 1500, SpriteName = "angel_hp"},
        new SkillInfo {HeroID = "Angel", Id = "HP", Level = 2, NextLevelCost = 2500, SpriteName = "angel_hp"},
        new SkillInfo {HeroID = "Angel", Id = "HP", Level = 3, NextLevelCost = 3500, SpriteName = "angel_hp"},
        new SkillInfo {HeroID = "Angel", Id = "HP", Level = 4, NextLevelCost = -1, SpriteName = "angel_hp"},
        new SkillInfo {HeroID = "Angel", Id = "Sword", Level = 1, NextLevelCost = 2500, SpriteName = "angel_sword"},
        new SkillInfo {HeroID = "Angel", Id = "Sword", Level = 2, NextLevelCost = 4000, SpriteName = "angel_sword"},
        new SkillInfo {HeroID = "Angel", Id = "Sword", Level = 3, NextLevelCost = 7000, SpriteName = "angel_sword"},
        new SkillInfo {HeroID = "Angel", Id = "Sword", Level = 4, NextLevelCost = -1, SpriteName = "angel_sword"},
        new SkillInfo {HeroID = "Angel", Id = "Fire", Level = 1, NextLevelCost = 1500, SpriteName = "angel_fire"},
        new SkillInfo {HeroID = "Angel", Id = "Fire", Level = 2, NextLevelCost = 2500, SpriteName = "angel_fire"},
        new SkillInfo {HeroID = "Angel", Id = "Fire", Level = 3, NextLevelCost = 3500, SpriteName = "angel_fire"},
        new SkillInfo {HeroID = "Angel", Id = "Fire", Level = 4, NextLevelCost = -1,  SpriteName = "angel_fire"},
        new SkillInfo {HeroID = "Angel", Id = "Dodge", Level = 1, NextLevelCost = 1000, SpriteName = "angel_dodge"},
        new SkillInfo {HeroID = "Angel", Id = "Dodge", Level = 2, NextLevelCost = 2000, SpriteName = "angel_dodge"},
        new SkillInfo {HeroID = "Angel", Id = "Dodge", Level = 3, NextLevelCost = 3000, SpriteName = "angel_dodge"},
        new SkillInfo {HeroID = "Angel", Id = "Dodge", Level = 4, NextLevelCost = -1, SpriteName = "angel_dodge"},
        new SkillInfo {HeroID = "Angel", Id = "Vampire", Level = 0, NextLevelCost = 1500, SpriteName = "angel_vampire"},
        new SkillInfo {HeroID = "Angel", Id = "Vampire", Level = 1, NextLevelCost = 2000, SpriteName = "angel_vampire"},
        new SkillInfo {HeroID = "Angel", Id = "Vampire", Level = 2, NextLevelCost = 3000, SpriteName = "angel_vampire"},
        new SkillInfo {HeroID = "Angel", Id = "Vampire", Level = 3, NextLevelCost = 4000, SpriteName = "angel_vampire"},
        new SkillInfo {HeroID = "Angel", Id = "Vampire", Level = 4, NextLevelCost = -1, SpriteName = "angel_vampire"},
        new SkillInfo {HeroID = "Angel", Id = "Air", Level = 0, NextLevelCost = 1500, SpriteName = "angel_air"},
        new SkillInfo {HeroID = "Angel", Id = "Air", Level = 1, NextLevelCost = 2000, SpriteName = "angel_air"},
        new SkillInfo {HeroID = "Angel", Id = "Air", Level = 2, NextLevelCost = 3000, SpriteName = "angel_air"},
        new SkillInfo {HeroID = "Angel", Id = "Air", Level = 3, NextLevelCost = 4000, SpriteName = "angel_air"},
        new SkillInfo {HeroID = "Angel", Id = "Air", Level = 4, NextLevelCost = -1, SpriteName = "angel_air"},
        new SkillInfo {HeroID = "Angel", Id = "Lightning", Level = 0, NextLevelCost = 2500, SpriteName = "angel_lightning"},
        new SkillInfo {HeroID = "Angel", Id = "Lightning", Level = 1, NextLevelCost = 3000, SpriteName = "angel_lightning"},
        new SkillInfo {HeroID = "Angel", Id = "Lightning", Level = 2, NextLevelCost = 4500, SpriteName = "angel_lightning"},
        new SkillInfo {HeroID = "Angel", Id = "Lightning", Level = 3, NextLevelCost = 7000, SpriteName = "angel_lightning"},
        new SkillInfo {HeroID = "Angel", Id = "Lightning", Level = 4, NextLevelCost = -1, SpriteName = "angel_lightning"},
        }
        },
            {"Reaper", new List<SkillInfo> {
        new SkillInfo {HeroID = "Reaper", Id = "HP", Level = 1, NextLevelCost = 1500, SpriteName = "reaper_hp"},
        new SkillInfo {HeroID = "Reaper", Id = "HP", Level = 2, NextLevelCost = 2500, SpriteName = "reaper_hp"},
        new SkillInfo {HeroID = "Reaper", Id = "HP", Level = 3, NextLevelCost = 3500, SpriteName = "reaper_hp"},
        new SkillInfo {HeroID = "Reaper", Id = "HP", Level = 4, NextLevelCost = -1, SpriteName = "reaper_hp"},
        new SkillInfo {HeroID = "Reaper", Id = "Sword", Level = 1, NextLevelCost = 2500, SpriteName = "reaper_sword"},
        new SkillInfo {HeroID = "Reaper", Id = "Sword", Level = 2, NextLevelCost = 4000, SpriteName = "reaper_sword"},
        new SkillInfo {HeroID = "Reaper", Id = "Sword", Level = 3, NextLevelCost = 7000, SpriteName = "reaper_sword"},
        new SkillInfo {HeroID = "Reaper", Id = "Sword", Level = 4, NextLevelCost = -1, SpriteName = "reaper_sword"},
        new SkillInfo {HeroID = "Reaper", Id = "Kit", Level = 1, NextLevelCost = 1500, SpriteName = "reaper_kit"},
        new SkillInfo {HeroID = "Reaper", Id = "Kit", Level = 2, NextLevelCost = 2500, SpriteName = "reaper_kit"},
        new SkillInfo {HeroID = "Reaper", Id = "Kit", Level = 3, NextLevelCost = 3500, SpriteName = "reaper_kit"},
        new SkillInfo {HeroID = "Reaper", Id = "Kit", Level = 4, NextLevelCost = -1, SpriteName = "reaper_kit"},
        new SkillInfo {HeroID = "Reaper", Id = "Dodge", Level = 1, NextLevelCost = 1000, SpriteName = "reaper_dodge"},
        new SkillInfo {HeroID = "Reaper", Id = "Dodge", Level = 2, NextLevelCost = 2000, SpriteName = "reaper_dodge"},
        new SkillInfo {HeroID = "Reaper", Id = "Dodge", Level = 3, NextLevelCost = 3000, SpriteName = "reaper_dodge"},
        new SkillInfo {HeroID = "Reaper", Id = "Dodge", Level = 4, NextLevelCost = -1, SpriteName = "reaper_dodge"},
        new SkillInfo {HeroID = "Reaper", Id = "Duh", Level = 0, NextLevelCost = 2500, SpriteName = "reaper_duh"},
        new SkillInfo {HeroID = "Reaper", Id = "Duh", Level = 1, NextLevelCost = 3000, SpriteName = "reaper_duh"},
        new SkillInfo {HeroID = "Reaper", Id = "Duh", Level = 2, NextLevelCost = 4500, SpriteName = "reaper_duh"},
        new SkillInfo {HeroID = "Reaper", Id = "Duh", Level = 3, NextLevelCost = 7000, SpriteName = "reaper_duh"},
        new SkillInfo {HeroID = "Reaper", Id = "Duh", Level = 4, NextLevelCost = -1, SpriteName = "reaper_duh"},
        new SkillInfo {HeroID = "Reaper", Id = "Stun", Level = 0, NextLevelCost = 1500, SpriteName = "reaper_stun"},
        new SkillInfo {HeroID = "Reaper", Id = "Stun", Level = 1, NextLevelCost = 2000, SpriteName = "reaper_stun"},
        new SkillInfo {HeroID = "Reaper", Id = "Stun", Level = 2, NextLevelCost = 3000, SpriteName = "reaper_stun"},
        new SkillInfo {HeroID = "Reaper", Id = "Stun", Level = 3, NextLevelCost = 4000, SpriteName = "reaper_stun"},
        new SkillInfo {HeroID = "Reaper", Id = "Stun", Level = 4, NextLevelCost = -1, SpriteName = "reaper_stun"},
        new SkillInfo {HeroID = "Reaper", Id = "Boom", Level = 0, NextLevelCost = 1500, SpriteName = "reaper_boom"},
        new SkillInfo {HeroID = "Reaper", Id = "Boom", Level = 1, NextLevelCost = 2000, SpriteName = "reaper_boom"},
        new SkillInfo {HeroID = "Reaper", Id = "Boom", Level = 2, NextLevelCost = 3000, SpriteName = "reaper_boom"},
        new SkillInfo {HeroID = "Reaper", Id = "Boom", Level = 3, NextLevelCost = 4000, SpriteName = "reaper_boom"},
        new SkillInfo {HeroID = "Reaper", Id = "Boom", Level = 4, NextLevelCost = -1, SpriteName = "reaper_boom"},
            }
        },
        {"Robot", new List<SkillInfo> {
        new SkillInfo {HeroID = "Robot", Id = "HP", Level = 1, NextLevelCost = 1500, SpriteName = "robot_hp"},
        new SkillInfo {HeroID = "Robot", Id = "HP", Level = 2, NextLevelCost = 2500, SpriteName = "robot_hp"},
        new SkillInfo {HeroID = "Robot", Id = "HP", Level = 3, NextLevelCost = 3500, SpriteName = "robot_hp"},
        new SkillInfo {HeroID = "Robot", Id = "HP", Level = 4, NextLevelCost = -1, SpriteName = "robot_hp"},
        new SkillInfo {HeroID = "Robot", Id = "Melle", Level = 0, NextLevelCost = 1500, SpriteName = "robot_melle"},
        new SkillInfo {HeroID = "Robot", Id = "Melle", Level = 1, NextLevelCost = 2500, SpriteName = "robot_melle"},
        new SkillInfo {HeroID = "Robot", Id = "Melle", Level = 2, NextLevelCost = 4000, SpriteName = "robot_melle"},
        new SkillInfo {HeroID = "Robot", Id = "Melle", Level = 3, NextLevelCost = 7000, SpriteName = "robot_melle"},
        new SkillInfo {HeroID = "Robot", Id = "Melle", Level = 4, NextLevelCost = -1, SpriteName = "robot_melle"},
        new SkillInfo {HeroID = "Robot", Id = "Straight", Level = 1, NextLevelCost = 2000, SpriteName = "robot_straight"},
        new SkillInfo {HeroID = "Robot", Id = "Straight", Level = 2, NextLevelCost = 3000, SpriteName = "robot_straight"},
        new SkillInfo {HeroID = "Robot", Id = "Straight", Level = 3, NextLevelCost = 4000, SpriteName = "robot_straight"},
        new SkillInfo {HeroID = "Robot", Id = "Straight", Level = 4, NextLevelCost = -1, SpriteName = "robot_straight"},
        new SkillInfo {HeroID = "Robot", Id = "Dodge", Level = 1, NextLevelCost = 1000, SpriteName = "robot_dodge"},
        new SkillInfo {HeroID = "Robot", Id = "Dodge", Level = 2, NextLevelCost = 2000, SpriteName = "robot_dodge"},
        new SkillInfo {HeroID = "Robot", Id = "Dodge", Level = 3, NextLevelCost = 3000, SpriteName = "robot_dodge"},
        new SkillInfo {HeroID = "Robot", Id = "Dodge", Level = 4, NextLevelCost = -1, SpriteName = "robot_dodge"},
        new SkillInfo {HeroID = "Robot", Id = "Angle", Level = 0, NextLevelCost = 2000, SpriteName = "robot_angle"},
        new SkillInfo {HeroID = "Robot", Id = "Angle", Level = 1, NextLevelCost = 2000, SpriteName = "robot_angle"},
        new SkillInfo {HeroID = "Robot", Id = "Angle", Level = 2, NextLevelCost = 3000, SpriteName = "robot_angle"},
        new SkillInfo {HeroID = "Robot", Id = "Angle", Level = 3, NextLevelCost = 4000, SpriteName = "robot_angle"},
        new SkillInfo {HeroID = "Robot", Id = "Angle", Level = 4, NextLevelCost = -1, SpriteName = "robot_angle"},
        new SkillInfo {HeroID = "Robot", Id = "Clone", Level = 0, NextLevelCost = 1500, SpriteName = "robot_clone"},
        new SkillInfo {HeroID = "Robot", Id = "Clone", Level = 1, NextLevelCost = 2000, SpriteName = "robot_clone"},
        new SkillInfo {HeroID = "Robot", Id = "Clone", Level = 2, NextLevelCost = 3000, SpriteName = "robot_clone"},
        new SkillInfo {HeroID = "Robot", Id = "Clone", Level = 3, NextLevelCost = 4000, SpriteName = "robot_clone"},
        new SkillInfo {HeroID = "Robot", Id = "Clone", Level = 4, NextLevelCost = -1, SpriteName = "robot_clone"},
        new SkillInfo {HeroID = "Robot", Id = "Mega", Level = 0, NextLevelCost = 2500, SpriteName = "robot_mega"},
        new SkillInfo {HeroID = "Robot", Id = "Mega", Level = 1, NextLevelCost = 3000, SpriteName = "robot_mega"},
        new SkillInfo {HeroID = "Robot", Id = "Mega", Level = 2, NextLevelCost = 4500, SpriteName = "robot_mega"},
        new SkillInfo {HeroID = "Robot", Id = "Mega", Level = 3, NextLevelCost = 7000, SpriteName = "robot_mega"},
        new SkillInfo {HeroID = "Robot", Id = "Mega", Level = 4, NextLevelCost = -1, SpriteName = "robot_mega"},
        }
        },
        {"Mur", new List<SkillInfo> {
        new SkillInfo {HeroID = "Mur", Id = "HP", Level = 1, NextLevelCost = 1500, SpriteName = "mur_hp"},
        new SkillInfo { HeroID = "Mur",Id = "HP", Level = 2, NextLevelCost = 2500, SpriteName = "mur_hp"},
        new SkillInfo {HeroID = "Mur", Id = "HP", Level = 3, NextLevelCost = 3500, SpriteName = "mur_hp"},
        new SkillInfo {HeroID = "Mur", Id = "HP", Level = 4, NextLevelCost = -1, SpriteName = "mur_hp"},
        new SkillInfo {HeroID = "Mur", Id = "Sword", Level = 1, NextLevelCost = 2500, SpriteName = "mur_sword"},
        new SkillInfo {HeroID = "Mur", Id = "Sword", Level = 2, NextLevelCost = 4000, SpriteName = "mur_sword"},
        new SkillInfo {HeroID = "Mur", Id = "Sword", Level = 3, NextLevelCost = 7000, SpriteName = "mur_sword"},
        new SkillInfo {HeroID = "Mur", Id = "Sword", Level = 4, NextLevelCost = -1, SpriteName = "mur_sword"},
        new SkillInfo {HeroID = "Mur", Id = "Buff", Level = 1, NextLevelCost = 1500, SpriteName = "mur_buff"},
        new SkillInfo {HeroID = "Mur", Id = "Buff", Level = 2, NextLevelCost = 2500, SpriteName = "mur_buff"},
        new SkillInfo {HeroID = "Mur", Id = "Buff", Level = 3, NextLevelCost = 3500, SpriteName = "mur_buff"},
        new SkillInfo {HeroID = "Mur", Id = "Buff", Level = 4, NextLevelCost = -1, SpriteName = "mur_buff"},
        new SkillInfo {HeroID = "Mur", Id = "Dodge", Level = 1, NextLevelCost = 1000, SpriteName = "mur_dodge"},
        new SkillInfo {HeroID = "Mur", Id = "Dodge", Level = 2, NextLevelCost = 2000, SpriteName = "mur_dodge"},
        new SkillInfo {HeroID = "Mur", Id = "Dodge", Level = 3, NextLevelCost = 3000, SpriteName = "mur_dodge"},
        new SkillInfo {HeroID = "Mur", Id = "Dodge", Level = 4, NextLevelCost = -1, SpriteName = "mur_dodge"},
        new SkillInfo {HeroID = "Mur", Id = "Boom", Level = 0, NextLevelCost = 1500, SpriteName = "mur_boom"},
        new SkillInfo {HeroID = "Mur", Id = "Boom", Level = 1, NextLevelCost = 2000, SpriteName = "mur_boom"},
        new SkillInfo {HeroID = "Mur", Id = "Boom", Level = 2, NextLevelCost = 3000, SpriteName = "mur_boom"},
        new SkillInfo {HeroID = "Mur", Id = "Boom", Level = 3, NextLevelCost = 4000, SpriteName = "mur_boom"},
        new SkillInfo {HeroID = "Mur", Id = "Boom", Level = 4, NextLevelCost = -1, SpriteName = "mur_boom"},
        new SkillInfo {HeroID = "Mur", Id = "Heal", Level = 0, NextLevelCost = 1500, SpriteName = "mur_heal"},
        new SkillInfo {HeroID = "Mur", Id = "Heal", Level = 1, NextLevelCost = 2000, SpriteName = "mur_heal"},
        new SkillInfo {HeroID = "Mur", Id = "Heal", Level = 2, NextLevelCost = 3000, SpriteName = "mur_heal"},
        new SkillInfo {HeroID = "Mur", Id = "Heal", Level = 3, NextLevelCost = 4000, SpriteName = "mur_heal"},
        new SkillInfo {HeroID = "Mur", Id = "Heal", Level = 4, NextLevelCost = -1, SpriteName = "mur_heal"},
        new SkillInfo {HeroID = "Mur", Id = "Invul", Level = 0, NextLevelCost = 2500, SpriteName = "mur_invul"},
        new SkillInfo {HeroID = "Mur", Id = "Invul", Level = 1, NextLevelCost = 3000, SpriteName = "mur_invul"},
        new SkillInfo {HeroID = "Mur", Id = "Invul", Level = 2, NextLevelCost = 4500, SpriteName = "mur_invul"},
        new SkillInfo {HeroID = "Mur", Id = "Invul", Level = 3, NextLevelCost = 7000, SpriteName = "mur_invul"},
        new SkillInfo {HeroID = "Mur", Id = "Invul", Level = 4, NextLevelCost = -1, SpriteName = "mur_invul"},
        }
        }


    };

    public static SkillInfo GetSkillFor(string hero, string id, int level)
    {
        return infos[hero].Find(x => x.Id == id && x.Level == level);
    }


}


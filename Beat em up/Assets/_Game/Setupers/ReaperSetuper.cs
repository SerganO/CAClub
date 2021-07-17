using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReaperSetuper : HeroSetuper
{

    public Slasbox Sword;
    public Entity Kit;
    public SummonPetScript KitSummon;
    public Slasbox Stun;
    public BoomMoveScript Boom;
    public WairthEntity Duh;


    public List<PlayerMove> Moves;

    public override void Setup()
    {
        var HeroData = GlobalUserData.ActiveUser.HeroForId("Reaper");
        
        var boomLevel = HeroData.moves.Find(x => x.ID == "Boom").level;
        var stunLevel = HeroData.moves.Find(x => x.ID == "Stun").level;
        var swordLevel = HeroData.moves.Find(x => x.ID == "Sword").level;
        var kitLevel = HeroData.moves.Find(x => x.ID == "Kit").level;
        var duhLevel = HeroData.moves.Find(x => x.ID == "Duh").level;

        Sword.Damage = ReaperInfo.GetSwordDamageForLevel(swordLevel);

        Hero.maxHP = ReaperInfo.GetHpForLevel(HeroData.HP.level);
        Hero.HP = ReaperInfo.GetHpForLevel(HeroData.HP.level);

        KitSummon.maxCount = ReaperInfo.GetKitCountForLevel(kitLevel);
        Kit.Attacks[0].Damage = ReaperInfo.GetKitDamageForLevel(kitLevel);
        Kit.maxHP = ReaperInfo.GetKitHPForLevel(kitLevel);
        Kit.HP = ReaperInfo.GetKitHPForLevel(kitLevel);

        //Stun.effects = new List<EffectClass>();
        //Stun.effects.Add(new EffectClass
        //{
        //    Effect = Effect.Stun,
        //    Chance = 100,
        //    Time = ReaperInfo.GetStunDurationForLevel(stunLevel),
        //    Hero = Hero
        //});

        Stun.effects.Find(x => x.Effect == Effect.Stun).Time = ReaperInfo.GetStunDurationForLevel(stunLevel);

        Boom.Damage = ReaperInfo.GetBoomDamageForLevel(boomLevel);

        Duh.maxHP = ReaperInfo.GetKitHPForLevel(duhLevel);
        Duh.HP = ReaperInfo.GetKitHPForLevel(duhLevel);
        Duh.Attacks[0].Damage = ReaperInfo.GetDuhDamageStringForLevel(duhLevel);
        Duh.healSize = ReaperInfo.GetDuhHPRegenStringForLevel(duhLevel);


        foreach (var move in Moves)
        {
            move.Countdown = (float)ReaperInfo.GetCountdown(move.ID, HeroData.moves.Find(x => x.ID == move.ID).level);
        }
    }



}

public static class ReaperInfo
{

    public static int GetValue(string valuesString, int level)
    {
        var values = valuesString.Split(':');
        return System.Convert.ToInt32(values[level]);
    }

    public static double GetDoubleValue(string valuesString, int level)
    {
        var values = valuesString.Split(':');
        return System.Convert.ToInt32(values[level]) / 10.0;
    }

    static string HPString = "20:20:25:30:40";

    static string SwordCountdownString = "6:6:6:6:6";
    static string DodgeCountdownString = "5:5:4:3:2";
    static string KitCountdownString = "24:24:22:20:18";
    static string DuhCountdownString = "60:60:58:56:54";
    static string StunCountdownString = "25:25:23:21:19";
    static string BoomCountdownString = "40:40:38:36:35";

    static string SwordDamageString = "4:4:6:8:10";

    static string KitCountString = "1:1:1:1:2";
    static string KitHPString = "20:20:25:30:30";
    static string KitDamageString = "3:3:4:5:5";
    static string StunDurationString = "4:4:5:6:7";
    static string BoomDamageString = "8:8:14:20:24";
    static string DuhHPString = "30:30:35:35:40";
    static string DuhDamageString = "3:3:3:4:4";
    static string DuhHPRegenString = "3:3:3:4:4";


    public static int GetHpForLevel(int level)
    {
        return GetValue(HPString, level);
    }

    public static double GetCountdown(string id, int level)
    {
        switch (id)
        {
            case "Sword":
                return GetDoubleValue(SwordCountdownString, level);
            case "Kit":
                return GetValue(KitCountdownString, level);
            case "Dodge":
                return GetValue(DodgeCountdownString, level);
            case "Duh":
                return GetValue(DuhCountdownString, level);
            case "Stun":
                return GetValue(StunCountdownString, level);
            case "Boom":
                return GetValue(BoomCountdownString, level);
        }
        return 0;
    }

    public static int GetSwordDamageForLevel(int level)
    {
        return GetValue(SwordDamageString, level);
    }

    public static int GetKitCountForLevel(int level)
    {
        return GetValue(KitCountString, level);
    }

    public static int GetKitHPForLevel(int level)
    {
        return GetValue(KitHPString, level);
    }

    public static int GetKitDamageForLevel(int level)
    {
        return GetValue(KitDamageString, level);
    }

    public static int GetStunDurationForLevel(int level)
    {
        return GetValue(StunDurationString, level);
    }

    public static int GetBoomDamageForLevel(int level)
    {
        return GetValue(BoomDamageString, level);
    }

    public static int GetDuhHPStringForLevel(int level)
    {
        return GetValue(DuhHPString, level);
    }

    public static int GetDuhDamageStringForLevel(int level)
    {
        return GetValue(DuhDamageString, level);
    }

    public static int GetDuhHPRegenStringForLevel(int level)
    {
        return GetValue(DuhHPRegenString, level);
    }

    public static string GetDescriptionForCountdown(string id, int level1)
    {
        return GetDescriptionForCountdown(id, level1, level1 + 1);
    }
    public static string GetDescriptionForCountdown(string id, int level1, int level2)
    {
        return countdown + ":" + GetCountdown(id, level1) + separator + GetCountdown(id, level2);
    }

    public static string GetDescriptionForHP(int level1)
    {
        return GetDescriptionForHP(level1, level1 + 1);
    }
    public static string GetDescriptionForHP(int level1, int level2)
    {
        return hp + ":" + GetHpForLevel(level1) + separator + GetHpForLevel(level2);
    }

    public static string GetDescriptionForSkill(string id, int level1)
    {
        return GetDescriptionForSkill(id, level1, level1 + 1);
    }
    public static string GetDescriptionForSkill(string id, int level1, int level2)
    {
        if (id == "HP") return GetDescriptionForHP(level1, level2);
        var res = "";
        switch (id)
        {
            case "Sword":
                res += damage + ":" + GetSwordDamageForLevel(level1) + separator + GetSwordDamageForLevel(level2) + endl;
                break;
            case "Kit":
                res += count + ":" + GetKitCountForLevel(level1) + separator + GetKitCountForLevel(level2) + endl;
                res += damage + ":" + GetKitDamageForLevel(level1) + separator + GetKitDamageForLevel(level2) + endl;
                res += hp + ":" + GetKitHPForLevel(level1) + separator + GetKitHPForLevel(level2) + endl;
                break;
            case "Dodge":
                break;
            case "Duh":
                res += heal + ":" + GetDuhHPRegenStringForLevel(level1) + separator + GetDuhHPRegenStringForLevel(level2) + endl;
                res += damage + ":" + GetDuhDamageStringForLevel(level1) + separator + GetDuhDamageStringForLevel(level2) + endl;
                res += hp + ":" + GetDuhHPStringForLevel(level1) + separator + GetDuhHPStringForLevel(level2) + endl;
                break;
            case "Stun":
                res += duration + ":" + GetStunDurationForLevel(level1) + separator + GetStunDurationForLevel(level2) + endl;
                break;
            case "Boom":
                res += damage + ":" + GetBoomDamageForLevel(level1) + separator + GetBoomDamageForLevel(level2) + endl;
                break;
        }
        res += GetDescriptionForCountdown(id, level1, level2) + endl;
        return res;
    }

    static string endl = "\n";
    static string separator = " > ";
    static string hp
    {
        get
        {
            return LocalizationManager.local.hp;
        }
    }
    static string heal
    {
        get
        {
            return LocalizationManager.local.heal;
        }
    }
    static string time
    {
        get
        {
            return LocalizationManager.local.time;
        }
    }
    static string count
    {
        get
        {
            return LocalizationManager.local.count;
        }
    }
    static string buff
    {
        get
        {
            return LocalizationManager.local.buff;
        }
    }
    static string damage
    {
        get
        {
            return LocalizationManager.local.damage;
        }
    }
    static string countdown
    {
        get
        {
            return LocalizationManager.local.countdown;
        }
    }
    static string duration
    {
        get
        {
            return LocalizationManager.local.duration;
        }
    }

    static string ColorText(string color, string text)
    {
        return "<color=" + color + ">" + text + "</color>";
    }
}

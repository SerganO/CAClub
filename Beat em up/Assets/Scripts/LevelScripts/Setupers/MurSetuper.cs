using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MurSetuper : HeroSetuper
{
    public List<Slasbox> Swords;

    public Slasbox Dodge;

    public InvulnerabilityPlayerScript Invul;
    public HealPlayerMove Heal;
    public BuffPlayerScript Buff;

    public Slasbox Area;


    public List<PlayerMove> Moves;
    
    public override void Setup()
    {
        var HeroData = GlobalUserData.ActiveUser.HeroForId("Mur");

        var boomLevel = HeroData.moves.Find(x => x.ID == "Boom").level;
        var buffLevel = HeroData.moves.Find(x => x.ID == "Buff").level;
        var swordLevel = HeroData.moves.Find(x => x.ID == "Sword").level;
        var healLevel = HeroData.moves.Find(x => x.ID == "Heal").level;
        var invulLevel = HeroData.moves.Find(x => x.ID == "Invul").level;
        var dodgeLevel = HeroData.moves.Find(x => x.ID == "Dodge").level;

        Hero.maxHP = MurInfo.GetHpForLevel(HeroData.HP.level);
        Hero.HP = MurInfo.GetHpForLevel(HeroData.HP.level);

        foreach(var Sword in Swords)
        {
            Sword.Damage = MurInfo.GetSwordDamageForLevel(swordLevel);
        }
        

        Dodge.Damage = MurInfo.GetDodgeDamageForLevel(dodgeLevel);

        Area.Damage = MurInfo.GetBoomDamageForLevel(boomLevel);

        Buff.DamageMult = (float)MurInfo.GetBuffPowerForLevel(buffLevel);
        Buff.Time = MurInfo.GetBuffTimeForLevel(buffLevel);



        foreach (var move in Moves)
        {
            move.Countdown = MurInfo.GetCountdown(move.ID, HeroData.moves.Find(x => x.ID == move.ID).level);
        }
    }
}

public static class MurInfo
{

    public static int GetValue(string valuesString, int level)
    {
        var values = valuesString.Split(':');
        return System.Convert.ToInt32(values[level]);
    }

    public static double GetDoubleValue(string valuesString, int level)
    {
        var values = valuesString.Split(':');
        return System.Convert.ToInt32(values[level]) / 100.0;
    }

    static string HPString = "30:30:35:40:50";

    static string SwordCountdownString = "2:2:2:2:2";
    static string DodgeCountdownString = "14:14:13:12:10";
    static string InvulCountdownString = "60:60:58:56:54";
    static string HealCountdownString = "8:8:8:8:8";
    static string BuffCountdownString = "20:20:20:19:18";
    static string BoomCountdownString = "40:40:38:36:35";


    static string SwordDamageString = "7:7:9:11:13";
    static string DodgeDamageString = "2:2:2:3:3";

    static string InvulTimeString = "10:10:12:14:16";
    static string HealPowerString = "5:5:10:15:20";
    
    static string BuffPowerString = "115:115:125:135:150";
    static string BuffTimeString = "6:6:7:8:10";

    static string BoomDamageString = "8:8:14:20:24";

    public static int GetHpForLevel(int level)
    {
        return GetValue(HPString, level);
    }

    public static int GetCountdown(string id, int level)
    {
        switch (id)
        {
            case "Sword":
                return GetValue(SwordCountdownString, level);
            case "Invul":
                return GetValue(InvulCountdownString, level);
            case "Dodge":
                return GetValue(DodgeCountdownString, level);
            case "Buff":
                return GetValue(BuffCountdownString, level);
            case "Heal":
                return GetValue(HealCountdownString, level);
            case "Boom":
                return GetValue(BoomCountdownString, level);
        }
        return 0;
    }

    public static int GetSwordDamageForLevel(int level)
    {
        return GetValue(SwordDamageString, level);
    }

    public static int GetDodgeDamageForLevel(int level)
    {
        return GetValue(DodgeDamageString, level);
    }

    public static int GetInvulTimeForLevel(int level)
    {
        return GetValue(InvulTimeString, level);
    }
    public static int GetHealPowerForLevel(int level)
    {
        return GetValue(HealPowerString, level);
    }

    public static double GetBuffPowerForLevel(int level)
    {
        return GetDoubleValue(BuffPowerString, level);
    }
    public static int GetBuffTimeForLevel(int level)
    {
        return GetValue(BuffTimeString, level);
    }
    
    public static int GetBoomDamageForLevel(int level)
    {
        return GetValue(BoomDamageString, level);
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
            case "Invul":
                res += duration + ":" + GetInvulTimeForLevel(level1) + separator + GetInvulTimeForLevel(level2) + endl;
                break;
            case "Dodge":
                res += damage + ":" + GetDodgeDamageForLevel(level1) + separator + GetDodgeDamageForLevel(level2) + endl;
                break;
            case "Heal":
                res += heal + ":" + GetHealPowerForLevel(level1) + separator + GetHealPowerForLevel(level2) + endl;
                break;
            case "Buff":
                res += buff + ":" + GetBuffPowerForLevel(level1) + separator + GetBuffPowerForLevel(level2) + endl;
                res += duration + ":" + GetBuffTimeForLevel(level1) + separator + GetBuffTimeForLevel(level2) + endl;
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

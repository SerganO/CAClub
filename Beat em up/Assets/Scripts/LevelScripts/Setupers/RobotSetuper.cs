using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotSetuper : HeroSetuper
{
    public List<Slasbox> Areas;

    public ThrowAttackScript Straight;
    public ThrowAttackScript Angle;
    public ThrowAttackScript Mega;
    public BaitPlayerScript Bait;




    public List<PlayerMove> Moves;

    public override void Setup()
    {
        var HeroData = GlobalUserData.ActiveUser.HeroForId("Robot");

        var baitLevel = HeroData.moves.Find(x => x.ID == "Clone").level;
        var megaLevel = HeroData.moves.Find(x => x.ID == "Mega").level;
        var swordLevel = HeroData.moves.Find(x => x.ID == "Melle").level;
        var angleLevel = HeroData.moves.Find(x => x.ID == "Angle").level;
        var straightLevel = HeroData.moves.Find(x => x.ID == "Straight").level;

        Hero.maxHP = RobotInfo.GetHpForLevel(HeroData.HP.level);
        Hero.HP = RobotInfo.GetHpForLevel(HeroData.HP.level);

        foreach(Slasbox slasbox in Areas)
        {
            slasbox.Damage = RobotInfo.GetSwordDamageForLevel(swordLevel);
        }
        

        Bait.Time = RobotInfo.GetCloneTimeForLevel(baitLevel);
        Straight.Damage = RobotInfo.GetStraightDamageForLevel(straightLevel);
        Angle.Damage = RobotInfo.GetAngledDamageForLevel(angleLevel);
        Mega.Damage = RobotInfo.GetMegaDamageForLevel(megaLevel);




        foreach (var move in Moves)
        {
            move.Countdown = (float)RobotInfo.GetCountdown(move.ID, HeroData.moves.Find(x => x.ID == move.ID).level);
        }
    }
}

public static class RobotInfo
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

    static string SwordCountdownString = "2:2:2:2:2";
    static string DodgeCountdownString = "5:5:4:3:2";
    static string StraightCountdownString = "5:5:5:5:5";
    static string AngleCountdownString = "5:5:5:5:5";
    static string CloneCountdownString = "30:30:28:26:24";
    static string MegaCountdownString = "60:60:58:56:54";

    static string SwordDamageString = "4:4:6:8:10";
    static string StraightDamageString = "4:4:5:6:8";
    static string AngleDamageString = "4:4:5:6:8";
    static string CloneTimeString = "8:8:10:12:15";
    static string MegaDamageString = "15:15:20:25:30";


    public static int GetHpForLevel(int level)
    {
        return GetValue(HPString, level);
    }

    public static double GetCountdown(string id, int level)
    {
        switch (id)
        {
            case "Melle":
                return GetValue(SwordCountdownString, level);
            case "Straight":
                return GetDoubleValue(StraightCountdownString, level);
            case "Dodge":
                return GetValue(DodgeCountdownString, level);
            case "Angle":
                return GetDoubleValue(AngleCountdownString, level);
            case "Clone":
                return GetValue(CloneCountdownString, level);
            case "Mega":
                return GetValue(MegaCountdownString, level);
        }
        return 0;
    }

    public static int GetSwordDamageForLevel(int level)
    {
        return GetValue(SwordDamageString, level);
    }

    public static int GetStraightDamageForLevel(int level)
    {
        return GetValue(StraightDamageString, level);
    }

    public static int GetAngledDamageForLevel(int level)
    {
        return GetValue(AngleDamageString, level);
    }

    public static int GetCloneTimeForLevel(int level)
    {
        return GetValue(CloneTimeString, level);
    }

    public static int GetMegaDamageForLevel(int level)
    {
        return GetValue(MegaDamageString, level);
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
            case "Melle":
                res += damage + ":" + GetSwordDamageForLevel(level1) + separator + GetSwordDamageForLevel(level2) + endl;
                break;
            case "Straight":
                res += damage + ":" + GetStraightDamageForLevel(level1) + separator + GetStraightDamageForLevel(level2) + endl;
                break;
            case "Dodge":
                break;
            case "Angle":
                res += damage + ":" + GetAngledDamageForLevel(level1) + separator + GetAngledDamageForLevel(level2) + endl;
                break;
            case "Clone":
                res += time + ":" + GetCloneTimeForLevel(level1) + separator + GetCloneTimeForLevel(level2) + endl;
                break;
            case "Mega":
                res += damage + ":" + GetMegaDamageForLevel(level1) + separator + GetMegaDamageForLevel(level2) + endl;
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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelSetuper : HeroSetuper
{
    public Slasbox Sword;
    public Slasbox Air;
    public BoomEnemyMoveScript Lightning;


    public PlayerOptionScript Vampire;
    public PlayerOptionScript Fire;

    public List<PlayerMove> Moves;

    public override void Setup()
    {
        var HeroData = GlobalUserData.ActiveUser.HeroForId("Angel");

        var vampireLevel = HeroData.moves.Find(x => x.ID == "Vampire").level;
        var fireLevel = HeroData.moves.Find(x => x.ID == "Fire").level;
        var swordLevel = HeroData.moves.Find(x => x.ID == "Sword").level;
        var airLevel = HeroData.moves.Find(x => x.ID == "Air").level;
        var lightningLevel = HeroData.moves.Find(x => x.ID == "Lightning").level;

        Hero.maxHP = AngelInfo.GetHpForLevel(HeroData.HP.level);
        Hero.HP = AngelInfo.GetHpForLevel(HeroData.HP.level);

        Sword.effects = new List<EffectClass>();

        Vampire.DataPairs = new List<OptionTimePair>();
        Vampire.DataPairs.Add(new OptionTimePair() { option = "Vampire", time = AngelInfo.GetVampireDurationForLevel(vampireLevel) });

        Vampire.addAnimationDuration = AngelInfo.GetVampireDurationForLevel(vampireLevel);

        Sword.effects.Add(new EffectClass()
        {
            Effect = Effect.Vampire,
            Chance = 100,
            Power = AngelInfo.GetVampirePowerForLevel(vampireLevel),
            neededHeroOption = new List<string>() { "Vampire" },
            Hero = Hero
        });

        Fire.DataPairs = new List<OptionTimePair>();
        Fire.DataPairs.Add(new OptionTimePair() { option = "FireSword", time = AngelInfo.GetFireDurationForLevel(fireLevel) });

        Fire.addAnimationDuration = AngelInfo.GetFireDurationForLevel(fireLevel);

        Sword.effects.Add(new EffectClass()
        {
            Effect = Effect.Fire,
            Chance = 100,
            Power = AngelInfo.GetFirePowerForLevel(fireLevel),
            Time = AngelInfo.GetFireTimeForLevel(fireLevel),
            neededHeroOption = new List<string>() { "FireSword" },
            Hero = Hero
        });

        Sword.Damage = AngelInfo.GetSwordDamageForLevel(swordLevel);
        Air.Damage = AngelInfo.GetAirDamageForLevel(airLevel);
        Lightning.Damage = AngelInfo.GetLightningDamageForLevel(lightningLevel);

        foreach (var move in Moves)
        {
            move.Countdown = (float)AngelInfo.GetCountdown(move.ID, HeroData.moves.Find(x => x.ID == move.ID).level);
        }
    }



}

public static class AngelInfo
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
    static string VampirePowerString = "4:4:4:5:5";
    static string VampireDurationString = "5:5:6:7:9";
    static string FirePowerString = "2:2:2:3:4";
    static string FireTimeString = "5:5:6:7:8";
    static string FireDurationString = "3:3:5:5:6";
    static string SwordDamageString = "4:4:6:8:10";
    static string AirDamageString = "1:1:1:2:2";
    static string LightningDamageString = "8:8:14:20:24";

    static string SwordCountdownString = "6:6:6:6:6";
    static string FireCountdownString = "20:20:18:16:14";
    static string DodgeCountdownString = "5:5:4:3:2";
    static string VampireCountdownString = "50:50:45:40:35";
    static string AirCountdownString = "20:20:17:15:12";
    static string LightningCountdownString = "70:70:68:66:64";


    public static int GetHpForLevel(int level)
    {
        return GetValue(HPString, level);
    }

    public static int GetVampirePowerForLevel(int level)
    {
        return GetValue(VampirePowerString, level);
    }

    public static int GetVampireDurationForLevel(int level)
    {
        return GetValue(VampireDurationString, level);
    }

    public static int GetFirePowerForLevel(int level)
    {
        return GetValue(FirePowerString, level);
    }

    public static int GetFireTimeForLevel(int level)
    {
        return GetValue(FireTimeString, level);
    }

    public static int GetFireDurationForLevel(int level)
    {
        return GetValue(FireDurationString, level);
    }

    public static int GetSwordDamageForLevel(int level)
    {
        return GetValue(SwordDamageString, level);
    }

    public static int GetAirDamageForLevel(int level)
    {
        return GetValue(AirDamageString, level);
    }

    public static int GetLightningDamageForLevel(int level)
    {
        return GetValue(LightningDamageString, level);
    }

    public static double GetCountdown(string id, int level)
    {
        switch (id)
        {
            case "Sword":
                return GetDoubleValue(SwordCountdownString, level);
            case "Fire":
                return GetValue(FireCountdownString, level);
            case "Dodge":
                return GetValue(DodgeCountdownString, level);
            case "Vampire":
                return GetValue(VampireCountdownString, level);
            case "Air":
                return GetValue(AirCountdownString, level);
            case "Lightning":
                return GetValue(LightningCountdownString, level);
        }
        return 0;
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
            case "Fire":
                res += damage + ":" + GetFirePowerForLevel(level1) + separator + GetFirePowerForLevel(level2) + endl;
                res += time + ":" + GetFireTimeForLevel(level1) + separator + GetFireTimeForLevel(level2) + endl;
                res += duration + ":" + GetVampireDurationForLevel(level1) + separator + GetVampireDurationForLevel(level2) + endl;
                break;
            case "Dodge":
                break;
            case "Vampire":
                res += hp + ":" + GetVampirePowerForLevel(level1) + separator + GetVampirePowerForLevel(level2) + endl;
                res += duration + ":" + GetVampireDurationForLevel(level1) + separator + GetVampireDurationForLevel(level2) + endl;
                break;
            case "Air":
                res += damage + ":" + GetAirDamageForLevel(level1) + separator + GetAirDamageForLevel(level2) + endl;
                break;
            case "Lightning":
                res += damage + ":" + GetLightningDamageForLevel(level1) + separator + GetLightningDamageForLevel(level2) + endl;
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

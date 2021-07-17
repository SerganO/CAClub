using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class UserData
{
    public string login = "";
    public List<HeroData> heroes = new List<HeroData>();
    public List<LevelProgress> progress = new List<LevelProgress>();

    public int XP
    {
        get { return _xp; }
        set
        {
            SaveDataToJSON.IsChanged = true;
            _xp = value;
            GlobalUserData.InvokeXPEvent();
        }
    }

    public int _xp = 0;


    public int scrigalPartCount = 0;
    public bool IntroWatched = false;
    public bool GameEnded = false;

    public bool ShowProfileTip = false;
    public bool ShowPlanetsTip = false;
    public bool ShowPlanetTip = false;
    public bool ShowLevelTip = false;
    public bool ShowHeroesTip = false;
    public bool ShowMainTip = false;
    public bool ShowUpgradeTip = false;
    public bool ShowWinTip = false;
    public bool ShowLoseTip = false;


    public UserData(string profileName)
    {
        this.login = profileName;
        heroes = new List<HeroData>()
    {
        new HeroData { HeroID = "Angel", isAvailable = true, HP = new MoveData { ID = "HP", level = 1 }, moves = new List<MoveData>
        {
            new MoveData { ID = "Sword", level = 1 },
            new MoveData { ID = "Fire", level = 1 },
            new MoveData { ID = "Dodge", level = 1 },
            new MoveData { ID = "Vampire", level = 0 },
            new MoveData { ID = "Air", level = 0 },
            new MoveData { ID = "Lightning", level = 0 }
        }
        },
        new HeroData { HeroID = "Robot", isAvailable = false, HP = new MoveData { ID = "HP", level = 1 }, moves = new List<MoveData>
        {
            new MoveData { ID = "Straight", level = 1 },
            new MoveData { ID = "Angle", level = 1 },
            new MoveData { ID = "Dodge", level = 1 },
            new MoveData { ID = "Melle", level = 0 },
            new MoveData { ID = "Clone", level = 0 },
            new MoveData { ID = "Mega", level = 0 }
        }
        },
        new HeroData { HeroID = "Reaper", isAvailable = false, HP = new MoveData { ID = "HP", level = 1 }, moves = new List<MoveData>
        {
            new MoveData { ID = "Sword", level = 1 },
            new MoveData { ID = "Kit", level = 1 },
            new MoveData { ID = "Dodge", level = 1 },
            new MoveData { ID = "Duh", level = 0 },
            new MoveData { ID = "Stun", level = 0 },
            new MoveData { ID = "Boom", level = 0 }
        }
        },
        new HeroData { HeroID = "Mur", isAvailable = false, HP = new MoveData { ID = "HP", level = 1 }, moves = new List<MoveData>
        {
            new MoveData { ID = "Sword", level = 1 },
            new MoveData { ID = "Buff", level = 1 },
            new MoveData { ID = "Dodge", level = 1 },
            new MoveData { ID = "Heal", level = 0 },
            new MoveData { ID = "Boom", level = 0 },
            new MoveData { ID = "Invul", level = 0 }
        }
        }
    };
        progress = new List<LevelProgress>
    {
        new LevelProgress {ID = "Baren1", progress = false },
        new LevelProgress {ID = "Baren2", progress = false },
        new LevelProgress {ID = "Baren3", progress = false },
        new LevelProgress {ID = "Baren4", progress = false },
        new LevelProgress {ID = "Baren5", progress = false },
        new LevelProgress {ID = "Baren6", progress = false },
        new LevelProgress {ID = "Baren7", progress = false },
        new LevelProgress {ID = "Baren8", progress = false },
        new LevelProgress {ID = "Baren9", progress = false },
        new LevelProgress {ID = "Baren10", progress = false },
        new LevelProgress {ID = "Desert1", progress = false },
        new LevelProgress {ID = "Desert2", progress = false },
        new LevelProgress {ID = "Desert3", progress = false },
        new LevelProgress {ID = "Desert4", progress = false },
        new LevelProgress {ID = "Desert5", progress = false },
        new LevelProgress {ID = "Desert6", progress = false},
        new LevelProgress {ID = "Desert7", progress = false },
        new LevelProgress {ID = "Desert8", progress = false },
        new LevelProgress {ID = "Desert9", progress = false },
        new LevelProgress {ID = "Desert10",progress = false },
        new LevelProgress {ID = "Forest1", progress = false },
        new LevelProgress {ID = "Forest2", progress = false },
        new LevelProgress {ID = "Forest3", progress = false },
        new LevelProgress {ID = "Forest4", progress = false },
        new LevelProgress {ID = "Forest5", progress = false  },
        new LevelProgress {ID = "Forest6", progress = false },
        new LevelProgress {ID = "Forest7", progress = false  },
        new LevelProgress {ID = "Forest8", progress = false },
        new LevelProgress {ID = "Forest9", progress = false },
        new LevelProgress {ID = "Forest10",progress = false },
        new LevelProgress {ID = "Ice1", progress = false },
        new LevelProgress {ID = "Ice2", progress = false },
        new LevelProgress {ID = "Ice3", progress = false },
        new LevelProgress {ID = "Ice4", progress = false },
        new LevelProgress {ID = "Ice5", progress = false },
        new LevelProgress {ID = "Ice6", progress = false },
        new LevelProgress {ID = "Ice7", progress = false },
        new LevelProgress {ID = "Ice8", progress = false },
        new LevelProgress {ID = "Ice9", progress = false },
        new LevelProgress {ID = "Ice10", progress = false },
        new LevelProgress {ID = "Lava1", progress = false },
        new LevelProgress {ID = "Lava2", progress = false },
        new LevelProgress {ID = "Lava3", progress = false },
        new LevelProgress {ID = "Lava4", progress = false },
        new LevelProgress {ID = "Lava5", progress = false },
        new LevelProgress {ID = "Lava6", progress = false },
        new LevelProgress {ID = "Lava7", progress = false },
        new LevelProgress {ID = "Lava8", progress = false },
        new LevelProgress {ID = "Lava9", progress = false },
        new LevelProgress {ID = "Lava10", progress = false },
        new LevelProgress {ID = "Ocean1", progress = false },
        new LevelProgress {ID = "Ocean2", progress = false },
        new LevelProgress {ID = "Ocean3", progress = false },
        new LevelProgress {ID = "Ocean4", progress = false },
        new LevelProgress {ID = "Ocean5", progress = false },
        new LevelProgress {ID = "Ocean6", progress = false },
        new LevelProgress {ID = "Ocean7", progress = false },
        new LevelProgress {ID = "Ocean8", progress = false },
        new LevelProgress {ID = "Ocean9", progress = false },
        new LevelProgress {ID = "Ocean10", progress = false },
        new LevelProgress {ID = "Terran1", progress = false },
        new LevelProgress {ID = "Terran2", progress = false },
        new LevelProgress {ID = "Terran3", progress = false },
        new LevelProgress {ID = "Terran4", progress = false },
        new LevelProgress {ID = "Terran5", progress = false },
        new LevelProgress {ID = "Terran6", progress = false },
        new LevelProgress {ID = "Terran7", progress = false },
        new LevelProgress {ID = "Terran8", progress = false },
        new LevelProgress {ID = "Terran9", progress = false },
        new LevelProgress {ID = "Terran10", progress = false}
    };
    }

    public HeroData HeroForId(string id)
    {
        return heroes.Find(x => x.HeroID == id);
    }

    public bool ProgressForLevel(string name)
    {
        return progress.Find(x => x.ID == name).progress;
    }

    public override bool Equals(object obj)
    {
        if ((obj == null) || !this.GetType().Equals(obj.GetType()))
        {
            return false;
        }
        else
        {
            UserData user = (UserData)obj;
            return this.login == user.login;
        }
    }


    public override string ToString()
    {
        return login;
    }

}

public static class GlobalUserData
{
    public static bool isDebug = false;
    public static UserData userData = null;

    public static event VoidFunc XPUpdatted;

    public static void InvokeXPEvent()
    {
        XPUpdatted?.Invoke();
    }

    public static void InitUserData(UserData userData)
    {
        GlobalUserData.userData = userData;
    }

    public static UserData ActiveUser
    {
        get
        {
            return isDebug ? debugUser : userData;
        }
        set
        {
            userData = value;
        }
    }

    public static UserData debugUser = new UserData("Debug")
    {
        scrigalPartCount = 7,
        XP = 11000,
        heroes = new List<HeroData>()
    {
      
        new HeroData { HeroID = "Angel", isAvailable = true, HP = new MoveData { ID = "HP", level = 1 }, moves = new List<MoveData>
        {
            new MoveData { ID = "Sword", level = 1 },
            new MoveData { ID = "Fire", level = 1 },
            new MoveData { ID = "Dodge", level = 1 },
            new MoveData { ID = "Vampire", level = 0 },
            new MoveData { ID = "Air", level = 0 },
            new MoveData { ID = "Lightning", level = 0 }
        }
        },
        new HeroData { HeroID = "Robot", isAvailable = true, HP = new MoveData { ID = "HP", level = 1 }, moves = new List<MoveData>
        {
            new MoveData { ID = "Melle", level = 1 },
            new MoveData { ID = "Straight", level = 1 },
            new MoveData { ID = "Dodge", level = 1 },
            new MoveData { ID = "Angle", level = 0 },
            new MoveData { ID = "Clone", level = 0 },
            new MoveData { ID = "Mega", level = 0 }
        }
        },
        new HeroData { HeroID = "Reaper", isAvailable = false, HP = new MoveData { ID = "HP", level = 1 }, moves = new List<MoveData>
        {
            new MoveData { ID = "Sword", level = 1 },
            new MoveData { ID = "Kit", level = 1 },
            new MoveData { ID = "Dodge", level = 1 },
            new MoveData { ID = "Duh", level = 0 },
            new MoveData { ID = "Stun", level = 0 },
            new MoveData { ID = "Boom", level = 0 }
        }
        },
        new HeroData { HeroID = "Mur", isAvailable = true, HP = new MoveData { ID = "HP", level = 1 }, moves = new List<MoveData>
        {
            new MoveData { ID = "Sword", level = 1 },
            new MoveData { ID = "Buff", level = 1 },
            new MoveData { ID = "Dodge", level = 1 },
            new MoveData { ID = "Heal", level = 0 },
            new MoveData { ID = "Boom", level = 0 },
            new MoveData { ID = "Invul", level = 0 }
        }
        }
    }
    };
}

[Serializable]
public class HeroData {
    public string HeroID;
    public bool isAvailable;
    public MoveData HP;
    public List<MoveData> moves;
}

[Serializable]
public class MoveData
{
    public string ID;
    public int level;

    public bool IsEnable
    {
        get
        {
            return level > 0;
        }
    }
}

[Serializable]
public class LevelProgress
{
    public string ID;
    public bool progress;
}


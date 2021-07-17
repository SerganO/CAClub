using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static string StartSceneId = "Start";
    public static string IntroSceneId = "Intro";
    public static string ChooseLevelSceneId = "ChooseLevel";
    public static string ChooseSublevelSceneId = "ChooseSublevel";
    public static string LevelSceneId = "Level";
    public static string FinalSceneId = "Final";

    [System.Serializable]
    public enum Scene
    {
        Start, Intro, ChooseLevel, ChooseSublevel, Level, Final
    }

    [System.Serializable]
    public enum BlockPanelType
    {
        transparent, image
    }

    public static string PrevSceneId;
    private string SceneId;

    public BlockPanelScript BlockPanel;
    public Image LoadBackImage;
    public Image LoadImage;
    public Text LoadText;

    private void Start()
    {
        BlockPanel.gameObject.SetActive(false);
        LoadBackImage.gameObject.SetActive(false);
        LoadImage.gameObject.SetActive(false);
        LoadText.gameObject.SetActive(false);
    }

    public void Load(string command)
    {
        var mainParts = command.Split('@');

        var parts = mainParts[0].Split('|');
        SceneId = parts[0];

        LoadBackImage.gameObject.SetActive(true);
        LoadImage.gameObject.SetActive(true);
        LoadText.gameObject.SetActive(true);
        
        if(mainParts.Length < 2)
        {
            BlockPanel.gameObject.SetActive(true);
        } else
        {
            switch (mainParts[1])
            {
                case "image":
                    BlockPanel.BackImage.color = new Color(255, 255, 255, 1);
                    BlockPanel.Logo.color = new Color(255, 255, 255, 1);
                    BlockPanel.gameObject.SetActive(true);
                    break;
                case "transparent":
                    var image = BlockPanel.BackImage;
                    image.color = new Color(0, 0, 0,0);
                    BlockPanel.Logo.color = new Color(0, 0, 0, 0);
                    BlockPanel.gameObject.SetActive(true);
                    break;

            }
        }

        

        Debug.Log("Load");
        StartCoroutine(AsyncLoad());
    }

    public void LoadWithTransparent(string sceneID)
    {
        SceneId = sceneID;

        var image = BlockPanel.BackImage;
        image.color = new Color(0, 0, 0, 0);
        BlockPanel.Logo.color = new Color(0, 0, 0, 0);
        BlockPanel.gameObject.SetActive(true);

        Debug.Log("Load");
        StartCoroutine(AsyncLoad());
    }

    public void LoadWithImage(string sceneID)
    {
        SceneId = sceneID;


        BlockPanel.BackImage.color = new Color(255, 255, 255, 1);
        BlockPanel.Logo.color = new Color(255, 255, 255, 1);
        BlockPanel.gameObject.SetActive(true);


        Debug.Log("Load");
        StartCoroutine(AsyncLoad());
    }

    public void LoadWithTransparent(Scene scene)
    {
        Load(scene, BlockPanelType.transparent);
    }

    public void LoadWithImage(Scene scene)
    {
        Load(scene, BlockPanelType.image);
    }

    public void Load(Scene scene, BlockPanelType blockPanelType = BlockPanelType.transparent)
    {
        switch (scene)
        {
            case Scene.Start:
                SceneId = StartSceneId;
                break;
            case Scene.Intro:
                SceneId = IntroSceneId;
                break;
            case Scene.ChooseLevel:
                SceneId = ChooseLevelSceneId;
                break;
            case Scene.ChooseSublevel:
                SceneId = ChooseSublevelSceneId;
                break;
            case Scene.Level:
                SceneId = LevelSceneId;
                break;
            case Scene.Final:
                SceneId = FinalSceneId;
                break;
        }

        switch (blockPanelType)
        {
            case BlockPanelType.transparent:
                var image = BlockPanel.BackImage;
                image.color = new Color(0, 0, 0, 0);
                BlockPanel.Logo.color = new Color(0, 0, 0, 0);
                BlockPanel.gameObject.SetActive(true);
                break;
            case BlockPanelType.image:
                BlockPanel.BackImage.color = new Color(255, 255, 255, 1);
                BlockPanel.Logo.color = new Color(255, 255, 255, 1);
                BlockPanel.gameObject.SetActive(true);
                break;
        }

        Debug.Log("Load");
        StartCoroutine(AsyncLoad());
    }


    IEnumerator AsyncLoad()
    {
        Debug.LogWarning(SceneId);
        PrevSceneId = SceneManager.GetActiveScene().name;
        LoadBackImage.gameObject.SetActive(true);
        LoadImage.gameObject.SetActive(true);
        LoadText.gameObject.SetActive(true);
        yield return new WaitForEndOfFrame();
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneId);

        while(!operation.isDone)
        {
            LoadImage.fillAmount = operation.progress / 0.9f;
            LoadText.text = string.Format("{0:0}%", operation.progress / 0.9 * 100);
            yield return null;
        }

    }
}


public class InformationMaster
{
    public static int ScrigalParts {
        get
        {
            return 7;
        }
    }


    public static Dictionary<string, List<string>> enemies = new Dictionary<string, List<string>>
    {
        { "Baren1", new List<string> { "01" , "Reaper1" , "Reaper2" } },
        { "Baren2", new List<string> { "01" , "Reaper1" , "Reaper2" , "Troll3" } },
        { "Baren3", new List<string> { "01" , "Reaper1" , "Reaper2" } },
        { "Baren4", new List<string> { "01" , "Reaper1" , "Reaper2" } },
        { "Baren5", new List<string> { "01" , "Reaper1" , "Reaper2" , "Troll2" } },
        { "Baren6", new List<string> { "01" , "Reaper1" , "Reaper2" , "Troll2" } },
        { "Baren7", new List<string> { "01" , "Reaper1" , "Reaper2" , "Troll2" } },
        { "Baren8", new List<string> { "01" , "Reaper1" , "Reaper2" , "Troll2" } },
        { "Baren9", new List<string> { "01" , "Reaper1" , "Reaper2" , "Troll2" } },
        { "Baren10", new List<string> { "01" , "Reaper1" , "Reaper2" , "Troll2" } },

        { "Desert1", new List<string> { "02", "Golem1", "Slaim" } },
        { "Desert2", new List<string> { "02", "Golem1", "Slaim" } },
        { "Desert3", new List<string> { "02", "Golem1", "Slaim" } },
        { "Desert4", new List<string> { "02", "Golem1", "Orc3", "Slaim" } },
        { "Desert5", new List<string> { "02", "Golem1", "Orc3", "Slaim" } },
        { "Desert6", new List<string> { "02", "Golem1", "Orc3", "Slaim" } },
        { "Desert7", new List<string> { "02", "Golem1", "Orc3", "Slaim" } },
        { "Desert8", new List<string> { "02", "Golem1", "Orc3", "Slaim" } },
        { "Desert9", new List<string> { "02", "Golem1", "Orc3", "Slaim" } },
        { "Desert10", new List<string> { "02", "Golem1", "Orc3", "Slaim" } },

        { "Forest1", new List<string> { "03", "Goblin", "Slaim" } },
        { "Forest2", new List<string> { "03", "Goblin", "Slaim" } },
        { "Forest3", new List<string> { "03", "Goblin", "Slaim" } },
        { "Forest4", new List<string> { "03", "Goblin", "Slaim" } },
        { "Forest5", new List<string> { "03", "Goblin", "Orc2", "Slaim" } },
        { "Forest6", new List<string> { "03", "Goblin", "Orc2", "Slaim", "Knight1" } },
        { "Forest7", new List<string> { "03", "Goblin", "Orc2", "Slaim" } },
        { "Forest8", new List<string> { "03", "Goblin", "Orc2", "Slaim" } },
        { "Forest9", new List<string> { "03", "Goblin", "Orc2", "Slaim" } },
        { "Forest10", new List<string> { "03", "Goblin", "Orc2", "Slaim" } },

        { "Ice1", new List<string> { "Slaim" , "Golem3", "Reaper1" } },
        { "Ice2", new List<string> { "Slaim" , "Golem3", "Reaper1" } },
        { "Ice3", new List<string> { "Slaim" , "Golem3", "Reaper1" } },
        { "Ice4", new List<string> { "Slaim" , "Golem3", "Reaper1" } },
        { "Ice5", new List<string> { "Slaim" , "Golem3", "Troll1", "Orc4", "Reaper1" } },
        { "Ice6", new List<string> { "Slaim" , "Golem3", "Troll1", "Orc4", "Reaper1" } },
        { "Ice7", new List<string> { "Slaim" , "Golem3", "Troll1", "Orc4", "Reaper1" } },
        { "Ice8", new List<string> { "Slaim" , "Golem3", "Troll1", "Orc4", "Reaper1" } },
        { "Ice9", new List<string> { "Slaim" , "Golem3", "Troll1", "Orc4", "Reaper1", "Robot1" } },
        { "Ice10", new List<string> { "Slaim" , "Golem3", "Troll1", "Orc4", "Reaper1" } },

        { "Lava1", new List<string> { "01" , "Golem2", "Reaper2" } },
        { "Lava2", new List<string> { "01" , "Golem2", "Reaper2" } },
        { "Lava3", new List<string> { "01" , "Golem2", "Reaper2" } },
        { "Lava4", new List<string> { "01" , "Golem2", "Reaper2" } },
        { "Lava5", new List<string> { "01" , "Golem2", "Troll3", "Orc3", "Reaper2", "Robot2" } },
        { "Lava6", new List<string> { "01" , "Golem2", "Troll3", "Orc3", "Reaper2" } },
        { "Lava7", new List<string> { "01" , "Golem2", "Troll3", "Orc3", "Reaper2" } },
        { "Lava8", new List<string> { "01" , "Golem2", "Troll3", "Orc3", "Reaper2" } },
        { "Lava9", new List<string> { "01" ,"Golem2", "Troll3", "Orc3", "Reaper2" } },
        { "Lava10", new List<string> { "01" , "Golem2", "Troll3", "Orc3", "Reaper2" } },

        { "Ocean1", new List<string> { "03", "Ogre", "Orc1", "Slaim" } },
        { "Ocean2", new List<string> { "03", "Ogre", "Orc1", "Slaim" } },
        { "Ocean3", new List<string> { "03", "Ogre", "Orc1", "Slaim" } },
        { "Ocean4", new List<string> { "03", "Ogre", "Orc1", "Slaim" } },
        { "Ocean5", new List<string> { "03", "Ogre", "Orc1", "Slaim", "Orc2" } },
        { "Ocean6", new List<string> { "03", "Ogre", "Orc1", "Slaim", "Orc2" } },
        { "Ocean7", new List<string> { "03", "Ogre", "Orc1", "Slaim", "Orc2", "Knight2" } },
        { "Ocean8", new List<string> { "03", "Ogre", "Orc1", "Slaim", "Orc2" } },
        { "Ocean9", new List<string> { "03", "Ogre", "Orc1", "Slaim", "Orc2" } },
        { "Ocean10", new List<string> { "03", "Ogre", "Orc1", "Slaim", "Orc2" } },

        { "Terran1", new List<string> { "03", "Goblin", "Orc1", "Slaim" } },
        { "Terran2", new List<string> { "03", "Goblin", "Orc1", "Slaim" } },
        { "Terran3", new List<string> { "03", "Goblin", "Orc1", "Slaim" } },
        { "Terran4", new List<string> { "03", "Goblin", "Orc1", "Slaim" } },
        { "Terran5", new List<string> { "03", "Goblin", "Orc1", "Slaim", "Orc2" } },
        { "Terran6", new List<string> { "03", "Goblin", "Orc1", "Slaim", "Orc2" } },
        { "Terran7", new List<string> { "03", "Goblin", "Orc1", "Slaim", "Orc2" } },
        { "Terran8", new List<string> { "03", "Goblin", "Orc1", "Slaim", "Orc2" } },
        { "Terran9", new List<string> { "03", "Goblin", "Orc1", "Slaim", "Orc2" } },
        { "Terran10", new List<string> { "03", "Goblin", "Orc1", "Slaim", "Orc2", "Knight1" } }
    };

    public static Dictionary<string, LevelEnemiesQueue> levelEnemies = new Dictionary<string, LevelEnemiesQueue>
    {
        { "Baren1", new LevelEnemiesQueue("5s|20#5s-1m|20~5s-2m|20#4m|20") },
{ "Baren2", new LevelEnemiesQueue("6s|20#5s-1m|20~5s-2m|20#4m|20~1b|20") },
{ "Baren3", new LevelEnemiesQueue("5s|20#5s-1m|20~5s-2m|20#4m|20~5s-2m|20") },
{ "Baren4", new LevelEnemiesQueue("6s|20#5s-2m|20~6s-3m|20#5m|20~6s-3m|20") },
{ "Baren5", new LevelEnemiesQueue("7s|20#5s-3m|20~6s-4m|20#5m|20~6s-4m|20#1b|20") },
{ "Baren6", new LevelEnemiesQueue("8s|20#5s-3m|20~6s-4m|20#5m|20~8s-3m|20#1b|20") },
{ "Baren7", new LevelEnemiesQueue("8s-2m|20#7s-3m|20~6s-4m|20#5s-2m|20~8s-3m|20#2b|20") },
{ "Baren8", new LevelEnemiesQueue("10s-2m|20#5m-1b|20~8s-4m|20#6m|20~8s-2b|20#3b|20") },
{ "Baren9", new LevelEnemiesQueue("10s-4m|20#5m-2b|20~8s-6m|20#6m-2b|20~8s-3b|20#3b|20") },
{ "Baren10", new LevelEnemiesQueue("10s-5m|20#6m-3b|20~4s-8m|20#8m-2b|20~10s-3b|20#4b|20") },

{ "Desert1", new LevelEnemiesQueue("5s|20#5s-1m|20~5s-2m|20#4m|20") },
{ "Desert2", new LevelEnemiesQueue("6s|20#5s-1m|20~5s-2m|20#4m|20") },
{ "Desert3", new LevelEnemiesQueue("5s|20#5s-1m|20~5s-2m|20#4m|20~5s-2m|20") },
{ "Desert4", new LevelEnemiesQueue("6s|20#5s-2m|20~6s-3m|20#5m|20~6s-3m|20~2b|20") },
{ "Desert5", new LevelEnemiesQueue("7s|20#5s-3m|20~6s-4m|20#5m|20~6s-4m|20#1b|20") },
{ "Desert6", new LevelEnemiesQueue("8s|20#5s-3m|20~6s-4m|20#5m|20~8s-3m|20#1b|20") },
{ "Desert7", new LevelEnemiesQueue("8s-2m|20#7s-3m|20~6s-4m|20#5s-2m|20~8s-3m|20#2b|20") },
{ "Desert8", new LevelEnemiesQueue("10s-2m|20#5m-1b|20~8s-4m|20#6m|20~8s-2b|20#3b|20") },
{ "Desert9", new LevelEnemiesQueue("10s-4m|20#5m-2b|20~8s-6m|20#6m-2b|20~8s-3b|20#3b|20") },
{ "Desert10", new LevelEnemiesQueue("10s-5m|20#6m-3b|20~4s-8m|20#8m-2b|20~10s-3b|20#4b|20") },

{ "Forest1", new LevelEnemiesQueue("5s|20#5s-1m|20~5s-2m|20#4m|20") },
{ "Forest2", new LevelEnemiesQueue("6s|20#5s-1m|20~5s-2m|20#4m|20") },
{ "Forest3", new LevelEnemiesQueue("5s|20#5s-1m|20~5s-2m|20#4m|20~5s-2m|20") },
{ "Forest4", new LevelEnemiesQueue("6s|20#5s-2m|20~6s-3m|20#5m|20~6s-3m|20") },
{ "Forest5", new LevelEnemiesQueue("7s|20#5s-3m|20~6s-4m|20#5m|20~6s-4m|20#1b|20") },
{ "Forest6", new LevelEnemiesQueue("8s|20#5s-3m|20~6s-4m|20#5m|20~8s-3m|20#1b|20~1B|20") },
{ "Forest7", new LevelEnemiesQueue("8s-2m|20#7s-3m|20~6s-4m|20#5s-2m|20~8s-3m|20#2b|20") },
{ "Forest8", new LevelEnemiesQueue("10s-2m|20#5m-1b|20~8s-4m|20#6m|20~8s-2b|20#3b|20") },
{ "Forest9", new LevelEnemiesQueue("10s-4m|20#5m-2b|20~8s-6m|20#6m-2b|20~8s-3b|20#3b|20") },
{ "Forest10", new LevelEnemiesQueue("10s-5m|20#6m-3b|20~4s-8m|20#8m-2b|20~10s-3b|20#4b|20") },

{ "Ice1", new LevelEnemiesQueue("5s|20#5s-1m|20~5s-2m|20#4m|20") },
{ "Ice2", new LevelEnemiesQueue("6s|20#5s-1m|20~5s-2m|20#4m|20") },
{ "Ice3", new LevelEnemiesQueue("5s|20#5s-1m|20~5s-2m|20#4m|20~5s-2m|20") },
{ "Ice4", new LevelEnemiesQueue("6s|20#5s-2m|20~6s-3m|20#5m|20~6s-3m|20") },
{ "Ice5", new LevelEnemiesQueue("7s|20#5s-3m|20~6s-4m|20#5m|20~6s-4m|20#1b|20") },
{ "Ice6", new LevelEnemiesQueue("8s|20#5s-3m|20~6s-4m|20#5m|20~8s-3m|20#1b|20") },
{ "Ice7", new LevelEnemiesQueue("8s-2m|20#7s-3m|20~6s-4m|20#5s-2m|20~8s-3m|20#2b|20") },
{ "Ice8", new LevelEnemiesQueue("10s-2m|20#5m-1b|20~8s-4m|20#6m|20~8s-2b|20#3b|20") },
{ "Ice9", new LevelEnemiesQueue("10s-4m|20#5m-2b|20~8s-6m|20#6m-2b|20~8s-3b|20#3b|20~2B|20") },
{ "Ice10", new LevelEnemiesQueue("10s-5m|20#6m-3b|20~4s-8m|20#8m-2b|20~10s-3b|20#4b|20") },

{ "Lava1", new LevelEnemiesQueue("5s|20#5s-1m|20~5s-2m|20#4m|20") },
{ "Lava2", new LevelEnemiesQueue("6s|20#5s-1m|20~5s-2m|20#4m|20") },
{ "Lava3", new LevelEnemiesQueue("5s|20#5s-1m|20~5s-2m|20#4m|20~5s-2m|20") },
{ "Lava4", new LevelEnemiesQueue("6s|20#5s-2m|20~6s-3m|20#5m|20~6s-3m|20") },
{ "Lava5", new LevelEnemiesQueue("7s|20#5s-3m|20~6s-4m|20#5m|20~6s-4m|20#1b|20~1B|20") },
{ "Lava6", new LevelEnemiesQueue("8s|20#5s-3m|20~6s-4m|20#5m|20~8s-3m|20#1b|20") },
{ "Lava7", new LevelEnemiesQueue("8s-2m|20#7s-3m|20~6s-4m|20#5s-2m|20~8s-3m|20#2b|20") },
{ "Lava8", new LevelEnemiesQueue("10s-2m|20#5m-1b|20~8s-4m|20#6m|20~8s-2b|20#3b|20") },
{ "Lava9", new LevelEnemiesQueue("10s-4m|20#5m-2b|20~8s-6m|20#6m-2b|20~8s-3b|20#3b|20") },
{ "Lava10", new LevelEnemiesQueue("10s-5m|20#6m-3b|20~4s-8m|20#8m-2b|20~10s-3b|20#4b|20") },

{ "Ocean1", new LevelEnemiesQueue("5s|20#5s-1m|20~5s-2m|20#4m|20") },
{ "Ocean2", new LevelEnemiesQueue("6s|20#5s-1m|20~5s-2m|20#4m|20") },
{ "Ocean3", new LevelEnemiesQueue("5s|20#5s-1m|20~5s-2m|20#4m|20~5s-2m|20") },
{ "Ocean4", new LevelEnemiesQueue("6s|20#5s-2m|20~6s-3m|20#5m|20~6s-3m|20") },
{ "Ocean5", new LevelEnemiesQueue("7s|20#5s-3m|20~6s-4m|20#5m|20~6s-4m|20#1b|20") },
{ "Ocean6", new LevelEnemiesQueue("8s|20#5s-3m|20~6s-4m|20#5m|20~8s-3m|20#1b|20") },
{ "Ocean7", new LevelEnemiesQueue("8s-2m|20#7s-3m|20~6s-4m|20#5s-2m|20~8s-3m|20#2b|20~1B|20") },
{ "Ocean8", new LevelEnemiesQueue("10s-2m|20#5m-1b|20~8s-4m|20#6m|20~8s-2b|20#3b|20") },
{ "Ocean9", new LevelEnemiesQueue("10s-4m|20#5m-2b|20~8s-6m|20#6m-2b|20~8s-3b|20#3b|20") },
{ "Ocean10", new LevelEnemiesQueue("10s-5m|20#6m-3b|20~4s-8m|20#8m-2b|20~10s-3b|20#4b|20") },

{ "Terran1", new LevelEnemiesQueue("5s|20#5s-1m|20~5s-2m|20#4m|20") },
{ "Terran2", new LevelEnemiesQueue("6s|20#5s-1m|20~5s-2m|20#4m|20") },
{ "Terran3", new LevelEnemiesQueue("5s|20#5s-1m|20~5s-2m|20#4m|20~5s-2m|20") },
{ "Terran4", new LevelEnemiesQueue("6s|20#5s-2m|20~6s-3m|20#5m|20~6s-3m|20") },
{ "Terran5", new LevelEnemiesQueue("7s|20#5s-3m|20~6s-4m|20#5m|20~6s-4m|20#1b|20") },
{ "Terran6", new LevelEnemiesQueue("8s|20#5s-3m|20~6s-4m|20#5m|20~8s-3m|20#1b|20") },
{ "Terran7", new LevelEnemiesQueue("8s-2m|20#7s-3m|20~6s-4m|20#5s-2m|20~8s-3m|20#2b|20") },
{ "Terran8", new LevelEnemiesQueue("10s-2m|20#5m-1b|20~8s-4m|20#6m|20~8s-2b|20#3b|20") },
{ "Terran9", new LevelEnemiesQueue("10s-4m|20#5m-2b|20~8s-6m|20#6m-2b|20~8s-3b|20#3b|20") },
{ "Terran10", new LevelEnemiesQueue("10s-5m|20#6m-3b|20~4s-8m|20#8m-2b|20~10s-3b|20#4b|20~2B|20") }
    };

    public static Dictionary<string, Rewards> rewards = new Dictionary<string, Rewards>
    {
        { "Baren1",  new Rewards() { firstReward = 1500, nextReward = 500}},
        { "Baren2",  new Rewards() { firstReward = 1500, nextReward = 500}},
        { "Baren3",  new Rewards() { firstReward = 1500, nextReward = 500}},
        { "Baren4",  new Rewards() { firstReward = 4000, nextReward = 1000}},
        { "Baren5",  new Rewards() { firstReward = 4000, nextReward = 1000}},
        { "Baren6",  new Rewards() { firstReward = 4000, nextReward = 1000}},
        { "Baren7",  new Rewards() { firstReward = 4000, nextReward = 1000}},
        { "Baren8",  new Rewards() { firstReward = 7500, nextReward = 1500}},
        { "Baren9",  new Rewards() { firstReward = 7500, nextReward = 1500}},
        { "Baren10", new Rewards() { firstReward = 7500, nextReward = 1500}},

        { "Desert1",   new Rewards() { firstReward = 1500, nextReward = 500}},
        { "Desert2",   new Rewards() { firstReward = 1500, nextReward = 500}},
        { "Desert3",   new Rewards() { firstReward = 1500, nextReward = 500}},
        { "Desert4",   new Rewards() { firstReward = 4000, nextReward = 1000}},
        { "Desert5",   new Rewards() { firstReward = 4000, nextReward = 1000}},
        { "Desert6",   new Rewards() { firstReward = 4000, nextReward = 1000}},
        { "Desert7",   new Rewards() { firstReward = 4000, nextReward = 1000}},
        { "Desert8",   new Rewards() { firstReward = 7500, nextReward = 1500}},
        { "Desert9",   new Rewards() { firstReward = 7500, nextReward = 1500}},
        { "Desert10",  new Rewards() { firstReward = 7500, nextReward = 1500}},

        { "Forest1",   new Rewards() { firstReward = 1500, nextReward = 500}},
        { "Forest2",   new Rewards() { firstReward = 1500, nextReward = 500}},
        { "Forest3",   new Rewards() { firstReward = 1500, nextReward = 500}},
        { "Forest4",   new Rewards() { firstReward = 4000, nextReward = 1000}},
        { "Forest5",   new Rewards() { firstReward = 4000, nextReward = 1000}},
        { "Forest6",   new Rewards() { firstReward = 4000, nextReward = 1000}},
        { "Forest7",   new Rewards() { firstReward = 4000, nextReward = 1000}},
        { "Forest8",   new Rewards() { firstReward = 7500, nextReward = 1500}},
        { "Forest9",   new Rewards() { firstReward = 7500, nextReward = 1500}},
        { "Forest10",  new Rewards() { firstReward = 7500, nextReward = 1500}},

        { "Ice1", new Rewards() { firstReward = 1500, nextReward = 500}},
        { "Ice2", new Rewards() { firstReward = 1500, nextReward = 500}},
        { "Ice3", new Rewards() { firstReward = 1500, nextReward = 500}},
        { "Ice4", new Rewards() { firstReward = 4000, nextReward = 1000}},
        { "Ice5", new Rewards() { firstReward = 4000, nextReward = 1000}},
        { "Ice6", new Rewards() { firstReward = 4000, nextReward = 1000}},
        { "Ice7", new Rewards() { firstReward = 4000, nextReward = 1000}},
        { "Ice8", new Rewards() { firstReward = 7500, nextReward = 1500}},
        { "Ice9", new Rewards() { firstReward = 7500, nextReward = 1500}},
        { "Ice10",new Rewards() { firstReward = 7500, nextReward = 1500}},

        { "Lava1",  new Rewards() { firstReward = 1500, nextReward = 500}},
        { "Lava2",  new Rewards() { firstReward = 1500, nextReward = 500}},
        { "Lava3",  new Rewards() { firstReward = 1500, nextReward = 500}},
        { "Lava4",  new Rewards() { firstReward = 4000, nextReward = 1000}},
        { "Lava5",  new Rewards() { firstReward = 4000, nextReward = 1000}},
        { "Lava6",  new Rewards() { firstReward = 4000, nextReward = 1000}},
        { "Lava7",  new Rewards() { firstReward = 4000, nextReward = 1000}},
        { "Lava8",  new Rewards() { firstReward = 7500, nextReward = 1500}},
        { "Lava9",  new Rewards() { firstReward = 7500, nextReward = 1500}},
        { "Lava10", new Rewards() { firstReward = 7500, nextReward = 1500}},

        { "Ocean1",   new Rewards() { firstReward = 1500, nextReward = 500}},
        { "Ocean2",   new Rewards() { firstReward = 1500, nextReward = 500}},
        { "Ocean3",   new Rewards() { firstReward = 1500, nextReward = 500}},
        { "Ocean4",   new Rewards() { firstReward = 4000, nextReward = 1000}},
        { "Ocean5",   new Rewards() { firstReward = 4000, nextReward = 1000}},
        { "Ocean6",   new Rewards() { firstReward = 4000, nextReward = 1000}},
        { "Ocean7",   new Rewards() { firstReward = 4000, nextReward = 1000}},
        { "Ocean8",   new Rewards() { firstReward = 7500, nextReward = 1500}},
        { "Ocean9",   new Rewards() { firstReward = 7500, nextReward = 1500}},
        { "Ocean10",  new Rewards() { firstReward = 7500, nextReward = 1500}},

        { "Terran1", new Rewards() { firstReward = 1500, nextReward = 500}},
        { "Terran2", new Rewards() { firstReward = 1500, nextReward = 500}},
        { "Terran3", new Rewards() { firstReward = 1500, nextReward = 500}},
        { "Terran4", new Rewards() { firstReward = 4000, nextReward = 1000}},
        { "Terran5", new Rewards() { firstReward = 4000, nextReward = 1000}},
        { "Terran6", new Rewards() { firstReward = 4000, nextReward = 1000}},
        { "Terran7", new Rewards() { firstReward = 4000, nextReward = 1000}},
        { "Terran8", new Rewards() { firstReward = 7500, nextReward = 1500}},
        { "Terran9", new Rewards() { firstReward = 7500, nextReward = 1500}},
        { "Terran10",new Rewards() { firstReward = 7500, nextReward = 1500}}
    };

    public static Dictionary<string, int> difficult = new Dictionary<string, int>
    {
        { "Baren1", 1},
        { "Baren2", 1},
        { "Baren3", 1},
        { "Baren4", 2},
        { "Baren5", 2},
        { "Baren6", 2},
        { "Baren7", 2},
        { "Baren8", 3},
        { "Baren9", 3},
        { "Baren10",3},

        { "Desert1",  1},
        { "Desert2",  1},
        { "Desert3",  1},
        { "Desert4",  2},
        { "Desert5",  2},
        { "Desert6",  2},
        { "Desert7",  2},
        { "Desert8",  3},
        { "Desert9",  3},
        { "Desert10", 3} ,

        { "Forest1",  1},
        { "Forest2",  1},
        { "Forest3",  1},
        { "Forest4",  2},
        { "Forest5",  2},
        { "Forest6",  2},
        { "Forest7",  2},
        { "Forest8",  3},
        { "Forest9",  3},
        { "Forest10", 3},

        { "Ice1", 1},
        { "Ice2", 1},
        { "Ice3", 1},
        { "Ice4", 2},
        { "Ice5", 2},
        { "Ice6", 2},
        { "Ice7", 2},
        { "Ice8", 3},
        { "Ice9", 3},
        { "Ice10",3},

        { "Lava1",  1 },
        { "Lava2",  1},
        { "Lava3",  1},
        { "Lava4",  2},
        { "Lava5",  2},
        { "Lava6",  2},
        { "Lava7",  2},
        { "Lava8",  3},
        { "Lava9",  3},
        { "Lava10", 3},

        { "Ocean1",  1} ,
        { "Ocean2",  1},
        { "Ocean3",  1},
        { "Ocean4",  2},
        { "Ocean5",  2},
        { "Ocean6",  2},
        { "Ocean7",  2},
        { "Ocean8",  3},
        { "Ocean9",  3},
        { "Ocean10", 3},

        { "Terran1", 1 },
        { "Terran2", 1 },
        { "Terran3", 1 },
        { "Terran4", 2 },
        { "Terran5", 2 },
        { "Terran6", 2 },
        { "Terran7", 2 },
        { "Terran8", 3 },
        { "Terran9", 3 },
        { "Terran10",3 }
    };

    public static List<string> ScrigalLevels = new List<string>
    {
        "Baren2",
        "Desert4",
        "Forest6",
        "Ice9",
        "Lava5",
        "Ocean7",
        "Terran10"
    };

}

public class Rewards
{
    public int firstReward;
    public int nextReward;
}

public class LevelEnemiesQueue
{
    public List<EnemiesWave> waves = new List<EnemiesWave>();

    public LevelEnemiesQueue(string initString)
    {
        var sWaves = initString.Split('~');

        foreach (var wave in sWaves)
        {
            waves.Add(new EnemiesWave(wave));
        }
    }

    public override string ToString()
    {
        string result = "Q:\n";

        foreach(var wave in waves)
        {
            result += wave.ToString();
        }

        return result;
    }
}

public class EnemiesWave {
    public List<EnemiesGroup> groups = new List<EnemiesGroup>();

    public EnemiesWave(string initString)
    {
        var sGroups = initString.Split('#');
       
        foreach (var group in sGroups)
        {
            groups.Add(new EnemiesGroup(group));
        }
    }

    public override string ToString()
    {
        string result = "W:\n";

        foreach (var wave in groups)
        {
            result += wave.ToString();
        }

        return result;
    }
}


public class EnemiesGroup {
    public List<EnemiesPair> pairs = new List<EnemiesPair>();
    public float time;

    public EnemiesGroup(string initString)
    {
        var parts = initString.Split('|');
        time = (float)System.Convert.ToDouble(parts[1]);
        var sPairs = parts[0].Split('-');

        foreach(var pair in sPairs)
        {
            pairs.Add(new EnemiesPair(pair));
        }
    }

    public int count()
    {
        int result = 0;

        foreach (var pair in pairs) result += pair.count;

        return result;
    }

    public override string ToString()
    {
        string result = "G:\n";

        foreach (var wave in pairs)
        {
            result += wave.ToString();
        }

        return result;
    }
}

public class EnemiesPair
{
    public Enemy.Type type;
    public int count;

    public EnemiesPair(string initString)
    {
        var stype = initString[initString.Length - 1];

        switch(stype)
        {
            case 's':
                type = Enemy.Type.small;
                break;
            case 'm':
                type = Enemy.Type.medium;
                break;
            case 'b':
                type = Enemy.Type.big;
                break;
            case 'r':
                type = Enemy.Type.range;
                break;
            case 'B':
                type = Enemy.Type.boss;
                break;
        }

        var countString = initString.Substring(0, initString.Length - 1);
        count = System.Convert.ToInt32(countString);
    }

    public override string ToString()
    {
        string result = "P: " + type + " " + count + "\n";
        return result;
    }
}



public class TransitionMaster {

    public static bool needShowEndGameMessage = false;

    public static string CurrentHeroID = "Angel";
    public static Planet CurrentPlanet = Planet.Forest;
    public static int CurrentSublevel = 1;

}

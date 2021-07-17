using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipsPanelScript : MonoBehaviour
{
    public Text Top;
    public Image Image;
    public Text Bottom;

    public Button NextButton;
    public Button PrevButton;

    List<string> ShowProfile = new List<string> { "Profile1", "Profile2", "Profile3" };
    List<string> ShowPlanets = new List<string> { "Planets1", "Planets2", "Planets3", "Planets4" };
    List<string> ShowPlanet = new List<string> {  "Planet1", "Planet2" };
    List<string> ShowLevel = new List<string> { "Level1", "Level2", "Level3", "Level4", "Level5", "Level6", "Level7" };
    List<string> ShowHeroes = new List<string> { "Heroes1","Heroes2", "Heroes3", "Heroes4", "Heroes5", "Heroes6" };
    List<string> ShowMain = new List<string> { "Main1", "Main2" , "Main3" , "Main4" };
    List<string> ShowUpgrade = new List<string> {"Upgrade1", "Upgrade2", "Upgrade3", "Upgrade4", "Upgrade5", "Upgrade6", "Upgrade7", "Upgrade8", "Upgrade9", "Upgrade10" };
    List<string> ShowWin = new List<string> {"Win1","Win2","Win3" };
    List<string> ShowLose = new List<string> { "Lose1"};

    List<string> _allTip = null;
    List<string> AllTip
    {
        get
        {
            if (_allTip == null)
            {
                _allTip = new List<string>();

                _allTip.AddRange(ShowMain);
                _allTip.AddRange(ShowProfile);
                _allTip.AddRange(ShowPlanets);
                _allTip.AddRange(ShowPlanet);
                _allTip.AddRange(ShowHeroes);
                _allTip.AddRange(ShowLevel);
                _allTip.AddRange(ShowWin);
                _allTip.AddRange(ShowLose);
                _allTip.AddRange(ShowUpgrade);
            }
            return _allTip;
        }
    }

    List<string> currentTips;

    public void ShowProfileTip()
    {
        currentTips = ShowProfile;
        Show();
    }
    public void ShowPlanetsTip()
    {
        currentTips = ShowPlanets;
        Show();
    }
    public void ShowPlanetTip()
    {
        currentTips = ShowPlanet;
        Show();
    }
    public void ShowLevelTip()
    {
        currentTips = ShowLevel;
        Show();
    }
    public void ShowHeroesTip()
    {
        currentTips = ShowHeroes;
        Show();
    }
    public void ShowMainTip()
    {
        currentTips = ShowMain;
        Show();
    }
    public void ShowUpgradeTip()
    {
        currentTips = ShowUpgrade;
        Show();
    }
    public void ShowWinTip()
    {
        currentTips = ShowWin;
        Show();
    }
    public void ShowLoseTip()
    {
        currentTips = ShowLose;
        Show();
    }
    public void ShowAll()
    {
        currentTips = AllTip;
        Show();
    }

    public void Next()
    {
        if (currentIndex == currentTips.Count - 1) currentIndex = 0;
        else currentIndex++;
        ShowFrame();
    }

    public void Prev()
    {
        if (currentIndex == 0) currentIndex = currentTips.Count - 1;
        else currentIndex--;
        ShowFrame();
    }

    int currentIndex = 0;
    float bTs;
    void Show()
    {
        if (currentTips.Count <= 0) return;
        bTs = Time.timeScale;
        Time.timeScale = 0;
        gameObject.SetActive(true);
        currentIndex = 0;

        ShowFrame();
        
    }

    void CheckNext()
    {
        if (currentIndex >= currentTips.Count - 1) NextButton.gameObject.SetActive(false);
        else NextButton.gameObject.SetActive(true);
    }

    void CheckPrev()
    {
        if (currentIndex == 0) PrevButton.gameObject.SetActive(false);
        else PrevButton.gameObject.SetActive(true);
    }

    void ShowFrame()
    {
        var id = currentTips[currentIndex];
        Top.text = LocalizationManager.local.GetValueForId("TopInfo" + id);
        Bottom.text = LocalizationManager.local.GetValueForId("BottomInfo" + id);
        Image.sprite = Resources.Load<Sprite>("Sprites/Tips/" + id);
        CheckNext();
        CheckPrev();
    }

    public void Hide()
    {
        Time.timeScale = bTs;
        gameObject.SetActive(false);
    }

}

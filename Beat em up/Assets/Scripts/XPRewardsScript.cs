using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.Advertisements;

public class XPRewardsScript : MonoBehaviour
{
    public Text XPText;
    public Button GetButton;

    public HeroUpdateScreen UpdateScreen;

    public GameObject circle;

    public int GivenXP = 1000;

    public string RewardedPlacementId = "rewardedVideo";

    private void Start()
    {    
        if(Advertisement.isSupported)
        {
            Advertisement.Initialize("3952391", false);
        }
        GetButton.onClick.AddListener(() => { GetButtonClick(); });
        UpdateUI();
        ButtonSetEnable(false);
    }

    void UpdateXP()
    {
        
    }

    public void UpdateUI()
    {
        XPText.text = GivenXP.ToString();
    }

    float tmp = 0;

    private void Update()
    {
        if(tmp>0)
        {
            tmp -= Time.deltaTime;
            ButtonSetEnable(false);
            return;
        }
        ButtonSetEnable(!Advertisement.isShowing && Advertisement.IsReady());
    }

    void ButtonSetEnable(bool value)
    {
        GetButton.enabled = value;
        if(value)
        {
            GetButton.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            circle.SetActive(false);
        } else
        {
            GetButton.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
            circle.SetActive(true);
        }

    }

    void GetButtonClick()
    {
        tmp = 3;
        if (!Advertisement.isShowing)
        {
            if (Advertisement.IsReady())
            {
                var options = new ShowOptions { resultCallback = HandleShowResult };
                Advertisement.Show(RewardedPlacementId, options);

                //Advertisement.Show("rewardedVideo");

            }
        }
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");

                GlobalUserData.ActiveUser.XP += GivenXP;
                SaveDataToJSON.IsChanged = true;
                SaveDataToJSON.AutoSaveData();

                UpdateXP();
                UpdateUI();
                UpdateScreen.UpdateXp();

                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                break;
        }
    }

}

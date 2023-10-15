using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.Advertisements;

public class XPRewardsScript : MonoBehaviour, IUnityAdsShowListener
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
        ButtonSetEnable(!Advertisement.isShowing && Advertisement.isInitialized);
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
            if (Advertisement.isInitialized)
            {
                var options = new ShowOptions ();
                Advertisement.Show(RewardedPlacementId, options,this);

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

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
      
    }

    public void OnUnityAdsShowStart(string placementId)
    {
       
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        if (placementId.Equals(RewardedPlacementId))
        {
            switch (showCompletionState) {
                case UnityAdsShowCompletionState.COMPLETED:
                    Debug.Log("The ad was successfully shown.");

                    GlobalUserData.ActiveUser.XP += GivenXP;
                    SaveDataToJSON.IsChanged = true;
                    SaveDataToJSON.AutoSaveData();

                    UpdateXP();
                    UpdateUI();
                    UpdateScreen.UpdateXp();
                    break;
                case UnityAdsShowCompletionState.SKIPPED:
                    Debug.Log("The ad was skipped before reaching the end.");
                    break;
                case UnityAdsShowCompletionState.UNKNOWN:
                    Debug.LogError("The ad failed to be shown.");
                    break;
            }
        }
    }
}

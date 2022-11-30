using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyZoneScript : MonoBehaviour
{
    public Button BuyButton;
    public Text DescriptionText;
    public ShopHandler handler;

    public event VoidFunc BuyEvent;

    string _id;

    private void Start()
    {
        BuyButton.onClick.AddListener(() =>
        {
            OnButtonTap();
        });
    }

    public void SetupForId(string id)
    {
        UpdateZone(id);
        _id = id;
       
    }

    public void OnButtonTap()
    {
        handler.BuyRequest(_id);
    }

    public void Buy()
    {
        Buy(_id);
    }

    public void Buy(string id)
    {
        var hero = GlobalUserData.ActiveUser.HeroForId(id);
        var heroData = HeroInfoMaster.HeroInfoForId(id);

        GlobalUserData.ActiveUser.XP -= heroData.Cost;
        hero.isAvailable = true;
        BuyEvent();
        UpdateZone(id);
        SaveDataToJSON.IsChanged = true;
    }

    HeroInfo _hero;
    HeroData _heroData;
    

    public void UpdateZone(string id)
    {
        _heroData = GlobalUserData.ActiveUser.HeroForId(id);
        _hero = HeroInfoMaster.HeroInfoForId(id);

        DescriptionText.text = _hero.Description;
        UpdateButton();
    }

    public void UpdateButton()
    {
        Helper.SetVisible(BuyButton.transform, !_heroData.isAvailable);
        BuyButton.interactable = GlobalUserData.ActiveUser.XP >= _hero.Cost;
        BuyButton.transform.GetChild(0).GetComponent<Text>().text = _hero.Cost.ToString();
    }
}

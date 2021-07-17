using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroListScript : MonoBehaviour
{
    public delegate void HeroInfoFunc(HeroInfo info);
    public event HeroInfoFunc IdChanged;
    public string currentId;
    public GameObject HeroButtonObject;

    public Sprite Available;
    public Sprite UnAvailable;

    List<string> _ids = new List<string>();

    private void Start()
    {
        LocalizationManager.languageChanged += LocalizationManager_languageChanged;
    }

    private void LocalizationManager_languageChanged()
    {
        foreach(Transform t in transform)
        {
            Destroy(t.gameObject);
        }
        SetupFromList(_ids);
    }

    public void SetupFromList(List<string> ids)
    {
        _ids = ids;
        for(int i =0;i<ids.Count;i++)
        {
            var button = Instantiate(HeroButtonObject, gameObject.transform);
            var data = HeroInfoMaster.HeroInfoForId(ids[i]);
            button.GetComponent<HeroButtonScript>().Setup(data);
            button.GetComponent<Button>().onClick.AddListener(() => OnButtonTap(button.GetComponent<HeroButtonScript>().id));

            if(GlobalUserData.ActiveUser.HeroForId(ids[i]).isAvailable)
            {
                button.GetComponent<Button>().image.sprite = Available;
            } else
            {
                button.GetComponent<Button>().image.sprite = UnAvailable;
            }
        }

        currentId = ids[0];
       
        IdChanged(HeroInfoMaster.HeroInfoForId(ids[0]));

    }



    void OnButtonTap(string id)
    {
        if(id != currentId)
        {
            currentId = id;
            IdChanged(HeroInfoMaster.HeroInfoForId(id));
        }
    }

    public void UpdateZone()
    {
        foreach(Transform child in transform)
        {
            var heroElement = child.GetComponent<HeroButtonScript>();

            var hero = GlobalUserData.ActiveUser.HeroForId(heroElement.id);

            if(hero.isAvailable)
            {
                heroElement.GetComponent<Button>().image.sprite = Available;
            } else
            {
                heroElement.GetComponent<Button>().image.sprite = UnAvailable;
            }


        }

    }

    private void OnDestroy()
    {
        LocalizationManager.languageChanged -= LocalizationManager_languageChanged;
    }

}

[System.Serializable]
public class HeroInfo
{
    public string id;
    public string NameID
    {
        get
        {
            return id + "Name";
        }
    }
    public string Name
    {
        get
        {
            return LocalizationManager.local.GetValueForId(NameID);
        }
    }
    public string SpriteName;
    public Sprite Image {
        get
        {
            return Resources.Load<Sprite>("Sprites/Hero/" + SpriteName);
        }
    }

    public string DescriptionID
    {
        get
        {
            return id + "Description";
        }
    }
    public string Description
    {
        get
        {
            return LocalizationManager.local.GetValueForId(DescriptionID);
        }
    }
    public int Cost;
    public override string ToString()
    {
        return id + " " + Name;
    }
}

public static class HeroInfoMaster
{
    public static List<HeroInfo> infos = new List<HeroInfo>
    {
        new HeroInfo
        {
            id = "Angel",
            SpriteName = "Angel",
            Cost = 0
        },
        new HeroInfo
        {
            id = "Robot",
            SpriteName = "Robot",
            Cost = 30000
        },
        new HeroInfo
        {
            id = "Reaper",
            SpriteName = "Reaper",
            Cost = 30000
        },
        new HeroInfo
        {
            id = "Mur",
            SpriteName = "Mur",
            Cost = 30000
        },
    };
 
    public static HeroInfo HeroInfoForId(string id)
    {
        return infos.Find(x => x.id == id);
    }
}

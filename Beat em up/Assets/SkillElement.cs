using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillElement : MonoBehaviour
{
    public string id;
    public Text Name;
    public Image Image;
    public Text Cost;
    public Text Description;
    public Button UpButton;



    public string _hero;
    public SkillInfo _info;

    public virtual void SetUpAction(VoidFunc action)
    {
        UpButton.onClick.AddListener(() => action());
    }

    public virtual void Setup(string hero, SkillInfo info)
    {
        _hero = hero;
        _info = info;
        Name.text = info.Name;
        Image.sprite = info.Image;
        Cost.text = info.NextLevelCost.ToString();
        Description.text = info.Description;
        SetupButton();
    }

    public virtual void NextLevel()
    {
        if(GlobalUserData.ActiveUser.XP >= _info.NextLevelCost && _info.NextLevelCost != -1)
        {
            GlobalUserData.ActiveUser.XP -= _info.NextLevelCost;
            var data = SkillMaster.GetSkillFor(_hero, _info.Id, _info.Level + 1);
            Setup(_hero, data);

            var hero = GlobalUserData.ActiveUser.heroes.Find(x => x.HeroID == _hero);
            switch(_info.Id)
            {
                case "HP":
                    hero.HP.level = _info.Level;
                    break;
                default:
                    hero.moves.Find(x => x.ID == _info.Id).level = _info.Level;
                    break;
            }

            SaveDataToJSON.IsChanged = true;
        }       
    }

    public virtual void SetupButton()
    {
        UpButton.interactable = GlobalUserData.ActiveUser.XP >= _info.NextLevelCost && _info.NextLevelCost != -1 && GlobalUserData.ActiveUser.HeroForId(_hero).isAvailable;
        Helper.SetVisible(UpButton.transform, _info.NextLevelCost != -1);
        Helper.SetVisible(Cost.transform, _info.NextLevelCost != -1);
    }

    private void Update()
    {
        
    }

    public virtual void Flip180()
    {
        StartCoroutine(Flip180e());
    }

    float time = 0.1f;
    float eps = 20;
    public virtual IEnumerator Flip180e()
    {
        var rect = gameObject.GetComponent<RectTransform>();
        float degrees = 180;
        Vector3 to = new Vector3(0, degrees, 0);
        Vector3 half = new Vector3(0, 90, 0);
        while (!equal(transform.eulerAngles, to, eps))
        {
            transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, to, time);
            yield return new WaitForEndOfFrame();// WaitForSeconds(time);
            Debug.Log("-");
            if (equal(transform.eulerAngles, half, 5)) hcomp180();
        }
        transform.eulerAngles = to;
        comp180();
    }

    public virtual void Flip0()
    {
        StartCoroutine(Flip0e());
    }

    public VoidFunc hcomp0 = () => { };
    public VoidFunc comp0 = () => { };
    public VoidFunc comp180 = () => { };
    public VoidFunc hcomp180 = () => { };

    public virtual IEnumerator Flip0e()
    {
        var rect = gameObject.GetComponent<RectTransform>();
        float degrees = 0;
        Vector3 to = new Vector3(0, degrees, 0);
        Vector3 half = new Vector3(0, 90, 0);
        while (!equal(transform.eulerAngles, to, eps))
        {
            transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, to, time);
            yield return new WaitForEndOfFrame();// WaitForSeconds(time);
            Debug.Log("-");
            if (equal(transform.eulerAngles, half, 5)) hcomp0();
        }
        transform.eulerAngles = to;
        comp0();
    }

    protected bool equal(Vector3 lhs, Vector3 rhs, double eps)
    {
        Debug.Log("@@@");
        Debug.Log(lhs.x + " " + lhs.y + " " + lhs.z);
        Debug.Log(rhs.x + " " + rhs.y + " " + rhs.z);
        return Mathf.Abs(lhs.x - rhs.x) <= eps &&
            Mathf.Abs(lhs.y - rhs.y) <= eps &&
            Mathf.Abs(lhs.z - rhs.z) <= eps;
    }
}

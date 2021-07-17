using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillElementFlipDecorator : SkillElement
{
    public SkillElement element;
    public Button to;
    public Button back;

    public GameObject block;

    public override void SetUpAction(VoidFunc action)
    {
        element.SetUpAction(action);
    }

    private void Start()
    {
        back.onClick.AddListener(() => { Flip0(); });
    }

    public override void Setup(string hero, SkillInfo info)
    {
        element.Setup(hero, info);
        Description.text = info.Description;
    }

    public override void NextLevel()
    {
        element.NextLevel();
        Description.text = element.Description.text;
    }

    public override void SetupButton()
    {
        element.SetupButton();
        Description.text = element.Description.text;
    }

    public override void Flip180()
    {
        element.hcomp180 = () =>
        {
            block.SetActive(true);
        };

        element.comp180 = () =>
        {
            back.gameObject.SetActive(true);
        };
        element.Flip180();
    }

    public override void Flip0()
    {
        to.gameObject.SetActive(false);
        element.comp0 = () =>
        {
            to.gameObject.SetActive(true);
        };
        element.hcomp0 = () =>
        {
            block.SetActive(false);
        };
        back.gameObject.SetActive(false);
        element.Flip0();
    }

}

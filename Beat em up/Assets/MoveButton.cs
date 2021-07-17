using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveButton : Button
{
    public Image Border;
    public Image BackImage;
    public Image FrontImage;
    public GameObject LockObject;

    protected override void Start()
    {
        Border = transform.GetChild(0).GetComponent<Image>();
        BackImage = transform.GetChild(1).GetComponent<Image>();
        FrontImage = transform.GetChild(2).GetComponent<Image>();
        LockObject = transform.GetChild(3).gameObject;
    }

    public void SetEnabled(bool value)
    {
        interactable = value;
        LockObject.SetActive(!value);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentHeroZoneScript : MonoBehaviour
{
    public Text Text;
    public Image Image;
    public Text Desc;

    public void Setup(Sprite image, string name, string desc)
    {
        Image.sprite = image;
        Text.text = name;
        Desc.text = desc;
    }
}

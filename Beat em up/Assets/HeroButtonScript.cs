using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroButtonScript : MonoBehaviour
{
    public string id;
    public Image Image;
    public Text Text;

    public void Setup(string id,Sprite image, string name)
    {
        this.id = id;
        Image.sprite = image;
        Text.text = name;
    }

    public void Setup(HeroInfo data)
    {
        Setup(data.id,data.Image,data.Name);
    }
}

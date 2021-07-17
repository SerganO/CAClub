using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LanguageControllerScript : MonoBehaviour
{
    public Image flag;
    public Text text;


    bool needUpdate = true;

    private void Update()
    {
        if(needUpdate)
        {
            var image = LocalizationManager.currentImage;

            if(image != null)
            {
                flag.sprite = image;
                needUpdate = false;
            }
        }
    }

    public void NextLanguage()
    {
        LocalizationManager.NextLanguage();
        flag.sprite = LocalizationManager.currentImage;
    }
}

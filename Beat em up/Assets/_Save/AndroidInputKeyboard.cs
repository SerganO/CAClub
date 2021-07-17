using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AndroidInputKeyboard : MonoBehaviour
{
    TouchScreenKeyboard keyboard;
    public Text txt;
    string Placeholder;

    public void OpenKeyboard()
    {
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);   
    }

    void Update()
    {
        if (!TouchScreenKeyboard.visible && keyboard != null)
        {
            if (keyboard.status == TouchScreenKeyboard.Status.Done)
            {
                Placeholder = keyboard.text;
                txt.text = Placeholder;
                keyboard = null;
            }
        }
    }
}

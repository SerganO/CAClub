using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class LocalizatedText : MonoBehaviour
{
    public string id;
    Text text;

    bool isSetuped = false;

    void Start()
    {
        text = GetComponent<Text>();
        LocalizationManager.languageChanged += Setup;
        
        Setup();
        
    }

    private void Update()
    {
        if (isSetuped) return;
        Setup();
    }

    void Setup()
    {
        if (LocalizationManager.local == null) return;
        Debug.Log(LocalizationManager.local.languageName);
        text.text = LocalizationManager.local.GetValueForId(id);
        isSetuped = true;
    }

    private void OnDestroy()
    {
        LocalizationManager.languageChanged -= Setup;
    }
}

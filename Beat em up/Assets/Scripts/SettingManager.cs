using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingManager : MonoBehaviour
{
    private static SettingManager _instance;

    public static string playingAudioID;

    public static SettingManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<SettingManager>();

                //Tell unity not to destroy this object when loading a new scene!
                if(_instance != null)
                    DontDestroyOnLoad(_instance.gameObject);
            }

            return _instance;
        }
    }

    void Awake()
    {
        if (_instance == null)
        {
            //If I am the first instance, make me the Singleton
            _instance = this;
            DontDestroyOnLoad(this);

            if(PlayerPrefs.GetInt("dataRecorded") == 0)
            {
                PlayerPrefs.SetInt("MusicEnable", 1);
                PlayerPrefs.SetInt("SoundEnable", 1);

                PlayerPrefs.SetString("Language", "en");
                LocalizationManager.SetupLanguage("en");
                PlayerPrefs.SetInt("dataRecorded", 1);
            } else
            {
                MusicEnable = PlayerPrefs.GetInt("MusicEnable")  == 1;
                SoundEnable = PlayerPrefs.GetInt("SoundEnable")  == 1;

                LocalizationManager.SetupLanguage(PlayerPrefs.GetString("Language"));
            }
        }
        else
        {
            //If a Singleton already exists and you find
            //another reference in scene, destroy it!
            if (this != _instance)
                Destroy(this.gameObject);
        }

        

    }

    bool musicEnable = true;
    public bool MusicEnable {
        get
        {
            return musicEnable;
        }
        set
        {
            PlayerPrefs.SetInt("MusicEnable", value? 1 : 0);
            musicEnable = value;
            MusicEnableChange?.Invoke(value);
        }
    }

    bool soundEnable = true;
    public bool SoundEnable
    {
        get
        {
            return soundEnable;
        }
        set
        {
            PlayerPrefs.SetInt("SoundEnable", value ? 1 : 0);
            soundEnable = value;
            SoundEnableChange?.Invoke(value);
        }
    }

    public event BoolFunc MusicEnableChange;
    public event BoolFunc SoundEnableChange;
}

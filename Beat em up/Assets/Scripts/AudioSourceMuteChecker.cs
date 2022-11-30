using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioSourceMuteChecker : MonoBehaviour
{
    public enum Category {
        music, sound
    }

    public Category category = Category.sound;

    AudioSource audioSource;
    bool isFirstUpdate = true;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        FirstUpdateIfNeeded();
    }

    protected void FirstUpdateIfNeeded()
    {
        if (isFirstUpdate)
        {
            FirstUpdate();
            isFirstUpdate = false;
        }
    }

    public virtual void FirstUpdate()
    {
        switch (category) {
            case Category.music:
                SettingManager.instance.MusicEnableChange += muteSound;
                muteSound(SettingManager.instance.MusicEnable);
                break;
            case Category.sound:
                SettingManager.instance.SoundEnableChange += muteSound;
                muteSound(SettingManager.instance.SoundEnable);
                break;
        }

    }

    void muteSound(bool value)
    {
        audioSource.mute = !value;
    }

    private void OnDestroy()
    {
        switch (category)
        {
            case Category.music:
                if(SettingManager.instance != null)
                    SettingManager.instance.MusicEnableChange -= muteSound;
                break;
            case Category.sound:
                if (SettingManager.instance != null)
                    SettingManager.instance.SoundEnableChange -= muteSound;
                break;
        }
    }
}

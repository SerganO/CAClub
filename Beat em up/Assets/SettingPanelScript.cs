using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanelScript : MonoBehaviour
{
    public Sprite soundOn;
    public Sprite soundOff;

    public Button music;
    public Button sound;

    bool isFirstUpdate = true;

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
        UpdateMusic(SettingManager.instance.MusicEnable);
        UpdateSound(SettingManager.instance.SoundEnable);

        SettingManager.instance.MusicEnableChange += UpdateMusic;
        SettingManager.instance.SoundEnableChange += UpdateSound;

        music.onClick.AddListener(()=> MusicToogle());
        sound.onClick.AddListener(() => SoundToogle());
    }

    void UpdateSound(bool value)
    {
        if (value)
        {
            sound.image.sprite = soundOn;
        }
        else
        {
            sound.image.sprite = soundOff;
        }
    }

    void UpdateMusic(bool value)
    {
        if (value)
        {
            music.image.sprite = soundOn;
        }
        else
        {
            music.image.sprite = soundOff;
        }
    }

    void SoundToogle()
    {
        SettingManager.instance.SoundEnable = !SettingManager.instance.SoundEnable;
    }
    void MusicToogle()
    {
        SettingManager.instance.MusicEnable = !SettingManager.instance.MusicEnable;
    }

    private void OnDestroy()
    {
        SettingManager.instance.MusicEnableChange -= UpdateMusic;
        SettingManager.instance.SoundEnableChange -= UpdateSound;
    }
}

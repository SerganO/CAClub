using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroComicsScript : MonoBehaviour
{
    public List<Sprite> frames;
    public Image Image;
    public Button Button;
    public SceneLoader Loader;

    int currentFrameIndex = 0;

    private void Start()
    {
        Image.sprite = frames[0];
        Button.onClick.AddListener(() => {
            NextFrame();
        });
    }

    void NextFrame()
    {
        if(currentFrameIndex < (frames.Count - 1))
        {
            currentFrameIndex++;
            Image.sprite = frames[currentFrameIndex];
        } else
        {
            SaveDataToJSON.IsChanged = true;
            GlobalUserData.ActiveUser.IntroWatched = true;
            Loader.LoadWithTransparent(SceneLoader.Scene.ChooseLevel);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalComicsScript : MonoBehaviour
{
    public List<Sprite> frames;
    public Image Image;
    public Button Button;
    public SceneLoader Loader;

    int currentFrameIndex = 0;

    private void Start()
    {
        SaveDataToJSON.IsChanged = true;
        GlobalUserData.ActiveUser.GameEnded = true;
        Image.sprite = frames[0];
        Button.onClick.AddListener(() => {
            NextFrame();
        });
    }

    void NextFrame()
    {
        if (currentFrameIndex < (frames.Count - 1))
        {
            currentFrameIndex++;
            Image.sprite = frames[currentFrameIndex];
        }
        else
        {
            TransitionMaster.needShowEndGameMessage = true;
            Loader.LoadWithTransparent(SceneLoader.Scene.Start);
        }
    }
}

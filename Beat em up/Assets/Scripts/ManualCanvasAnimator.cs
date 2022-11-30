using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ManualCanvasAnimator : MonoBehaviour
{
    Image image;

    public List<Sprite> sprites;

    bool start = false;
    int index = 0;

    private void Start()
    {
        image = GetComponent<Image>();
        Show();
    }

    public void Show()
    {
        start = true;
    }

    private void FixedUpdate()
    {
        if(start)
        {
            if(index < sprites.Count)
            {
                image.sprite = sprites[index];
                index++;
            }
            
        }
    }

    public void Hide()
    {
        start = false;
        index = 0;

    }
}

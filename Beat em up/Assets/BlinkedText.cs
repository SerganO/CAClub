using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class BlinkedText : MonoBehaviour
{
    public bool needBlink;
    Text Text;
    Color Color;
    // Start is called before the first frame update
    void Start()
    {
        Text = GetComponent<Text>();
        Color = Text.color;
    }

    public float time = 0.3f;
    bool show = false;
    float tmp = 0.0f;
    void Update()
    {
        if (needBlink)
        {
            tmp -= Time.deltaTime;
            if (tmp <= 0)
            {
                if (show)
                {
                    Text.color = new Color(Color.r, Color.g, Color.b, 0);
                }
                else
                {
                    Text.color = new Color(Color.r, Color.g, Color.b, 1);
                }


                show = !show;
                tmp = time;
            }
        } else if(!show)
        {
            Text.color = new Color(Color.r,Color.g,Color.b, 1);
            show = true;
        }
    }
}

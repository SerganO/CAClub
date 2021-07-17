using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SwipeMenu : MonoBehaviour
{
    public GameObject ScrollBar;
    float scrollPosition = 0;
    float[] pos; 

    void Start()
    { 
        
    }
    
    void Update()
    {
        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);

        for (int i = 0; i < pos.Length; i++) {
            pos[i] = distance * i;
        }

        if (Input.GetMouseButton(0))
        {
            scrollPosition = ScrollBar.GetComponent<Scrollbar>().value;
        }
        else {
            for (int i = 0; i < pos.Length; i++) {
                if (scrollPosition < pos[i] + distance / 2 && scrollPosition > pos[i] - distance/2)
                {
                    ScrollBar.GetComponent<Scrollbar>().value = Mathf.Lerp(ScrollBar.GetComponent<Scrollbar>().value, pos[i], 0.1f);
                }
            }
        }

        for (int i = 0; i < pos.Length; i++)
        {
            if (scrollPosition < pos[i] + distance / 1.5 && scrollPosition > pos[i] - distance / 1.5)
            {
                transform.GetChild(i).localScale = Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(1f, 1f), 0.1f);


                for (int a = 0; a < pos.Length; a++)
                {
                    if (a != i) {
                        transform.GetChild(a).localScale = Vector2.Lerp(transform.GetChild(a).localScale, new Vector2(0.8f, 0.8f), 0.1f);
                    }
                }

            }
        }
    }
}

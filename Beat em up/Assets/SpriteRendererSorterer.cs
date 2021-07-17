using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRendererSorterer : MonoBehaviour
{
    SpriteRenderer sr;
    int baseOrder;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        baseOrder = sr.sortingOrder;
    }

    // Update is called once per frame
    void Update()
    {
        sr.sortingOrder = baseOrder - (int)(gameObject.transform.localPosition.y * 1000);
    }
}

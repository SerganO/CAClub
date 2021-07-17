using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spriter2UnityDX;

public class EntityRendererSorter : MonoBehaviour
{

    EntityRenderer sr;
    int baseOrder;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<EntityRenderer>();
        baseOrder = sr.SortingOrder;
    }

    // Update is called once per frame
    void Update()
    {
        sr.SortingOrder = baseOrder - (int)(gameObject.transform.localPosition.y * 1000);
    }


}

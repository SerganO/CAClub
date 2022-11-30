using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayActiveScript : MonoBehaviour
{
    public float delay = 1f;
    public GameObject Object;

    void Start()
    {
        StartCoroutine(DoActive());
    }

    IEnumerator DoActive()
    {
        yield return new WaitForSeconds(delay);
        Object.SetActive(true);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressCircle : MonoBehaviour
{
    private RectTransform rectTransform;
    private float rotateSpeed = -300f;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        rectTransform.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);
    }
}
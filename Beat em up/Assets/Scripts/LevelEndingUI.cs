using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelEndingUI : MonoBehaviour
{
    public Image SuccessImage;
    public Image FailImage;

    public Text XPText;
    public GameObject SCRBlock;

    private void Start()
    {
        SuccessImage.gameObject.SetActive(false);
        FailImage.gameObject.SetActive(false);
    }

    public void Fail()
    {
        FailImage.gameObject.SetActive(true);
    }

    public void Success()
    {
        SuccessImage.gameObject.SetActive(true);
    }
}

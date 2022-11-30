using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultZone : MonoBehaviour
{
    public Sprite ActiveStar;
    public Sprite UnactiveStar;

    public void Setup(string level)
    {
        int difficult = InformationMaster.difficult[level];

        int i = 0;
        foreach(Transform t in transform)
        {
            var image = t.GetComponent<Image>();
            if (i < difficult) image.sprite = ActiveStar;
            else image.sprite = UnactiveStar;
            i++;
        }
    }

}

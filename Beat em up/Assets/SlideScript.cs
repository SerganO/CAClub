using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideScript : PlayerMoveScript
{
    public float xDistance;
    public float yDistance;
    public float time;

    protected override bool Effect()
    {
        if (Hero.IsDie || Hero.CurrentState == HeroState.slide) return false;
        StartCoroutine(Replace(xDistance, yDistance, time));
        return true;
    }

    IEnumerator Replace(float xDistance, float yDistance, float time)
    {
        Hero.CurrentState = HeroState.slide;
        Hero.SetHitBoxEnabled(false);
        //Visualizate();
        int n = 15;
        var part = time / n;
        var xd = ((Hero.IsInverted ? -1: 1) * xDistance) / n;
        var yd = yDistance / n;


        for (int i = 0; i < n; i++)
        {
            Hero.transform.position += new Vector3(xd, yd, 0);
            yield return new WaitForSeconds(part);
        }
        Hero.SetHitBoxEnabled(true);
        Hero.CurrentState = HeroState.idle;
    }
}


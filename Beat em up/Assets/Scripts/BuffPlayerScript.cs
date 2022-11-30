using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffPlayerScript : PlayerMoveScript
{
    public float DamageMult;
    public float Time;


    protected override bool Effect()
    {
        addAnimationDuration = Time;
        Hero.DamageMult *= DamageMult;

        StartCoroutine(Helper.Wait(Time, () => { Hero.DamageMult /= DamageMult; }));
        return true;
    }
}

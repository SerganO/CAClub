using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedMoveScript : PlayerMoveScript
{
    public float Mult;
    public float Time;


    protected override bool Effect()
    {
        Hero.speedMult *= Mult;
        StartCoroutine(Helper.Wait(Time, () => { Hero.speedMult /= Mult; }));
        return true;
    }
}

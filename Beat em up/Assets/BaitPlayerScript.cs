using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaitPlayerScript : PlayerMoveScript
{
    public GameObject BaitObject;
    public float Time;

    protected override bool Effect()
    {
        var bait = Instantiate(BaitObject, Hero.transform.parent);
        bait.transform.position = Hero.transform.position;
        var s = bait.transform.localScale;
        bait.transform.localScale = new Vector3(s.x * (Hero.IsInverted ? -1: 1), s.y,s.z);
        StartCoroutine(Helper.Wait(Time, () => { Destroy(bait); }));

        return true;
    }

}

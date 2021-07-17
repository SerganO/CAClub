using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOptionScript : PlayerMoveScript
{
    public List<OptionTimePair> DataPairs;
    protected override bool Effect()
    {
        DataPairs.ForEach(x =>
        {
            Hero.options[x.option] = true;
            StartCoroutine(Helper.Wait(x.time, () => Hero.options[x.option] = false));
        });
        return true;
    }

}


[System.Serializable]
public class OptionTimePair
{
    public string option;
    public float time;
}
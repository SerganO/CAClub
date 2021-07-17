using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPlayerMove : PlayerMoveScript
{
    public float HealSize;

    protected override bool Effect()
    {
        Hero.Heal(HealSize);
        return true;
    }
}

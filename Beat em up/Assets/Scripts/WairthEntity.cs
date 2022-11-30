using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WairthEntity : Entity
{
    public float healSize = 0;


    public override IEnumerator AttackCoroutine()
    {
        CurrentState = State.attack;
        var attack = ProbabilityMaster.EntityAttackFrom(Attacks);
        attack.Attack();
        yield return new WaitForSeconds(attack.animationDuration);
        Hero.HP += healSize;
        Hero.HP = Mathf.Min((float)Hero.HP, (float)Hero.maxHP);
        Hero.SetHPFill((float)(Hero.HP / Hero.maxHP));
        cd += attack.afterCD;
        if (CurrentState != State.die) CurrentState = State.idle;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayerMove : PlayerMove
{
    public AttackScript Attack;

    public override bool CanAction()
    {
        return base.CanAction() && Hero.CanAttack();
    }

    public override void Action()
    {
       Hero.SetIsAttacking(true);
       Attack.Attack(() => { Hero.SetIsAttacking(false); });
    }
}

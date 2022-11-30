using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public delegate void VoidFunc();
public delegate void StringFunc(string value);
public delegate void BoolFunc(bool value);

public class AttackScript : PlayerMoveScript
{
    public Slasbox Slasbox;

    protected bool isAttacking = false;

    public override void Setup()
    {
        base.Setup();
        if(Slasbox != null) Slasbox.Hero = Hero;
    }

    public virtual void Attack(VoidFunc completionHandler)
    {
        handler = completionHandler;
        StartCoroutine(PushCoroutine());
    }

    IEnumerator PushCoroutine()
    {
        isAttacking = true;
        Slasbox.gameObject.SetActive(true);
        Visualizate();
        yield return new WaitForSeconds(animationDuration);
        isAttacking = false;
        Slasbox.gameObject.SetActive(false);
        handler();
    }

    protected override bool Effect()
    {
        Attack(() => { });
        return true;
    }
}

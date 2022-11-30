using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuequeAttackScript : AttackScript
{
    public enum Type
    {
        queque, up
    }
    public List<Slasbox> slasboxes;
    public Type type = Type.queque;

    public override void Setup()
    {
        base.Setup();
        slasboxes.ForEach(x => x.Hero = Hero);
    }

    public override void Attack(VoidFunc completionHandler)
    {
        if (slasboxes.Count <= 0) return;
        handler = completionHandler;
        StartCoroutine(PushCoroutine());
    }

    IEnumerator PushCoroutine()
    {
        var time = animationDuration / slasboxes.Count;

        isAttacking = true;
        Visualizate();

        switch (type)
        {
            case Type.queque:
                for (int i = 0; i < slasboxes.Count; i++)
                {
                    slasboxes[i].gameObject.SetActive(true);
                    yield return new WaitForSeconds(time);
                    slasboxes[i].gameObject.SetActive(false);
                }
                break;
            case Type.up:
                for (int i = 0; i < slasboxes.Count; i++)
                {
                    for(int j =0;j <= i;j++)
                    {
                        slasboxes[j].enabled = true;
                    }
                    yield return new WaitForSeconds(time);
                    for (int j = 0; j <= i; j++)
                    {
                        slasboxes[j].enabled = false;
                    }
                    
                }
                break;
        }
        isAttacking = false;
        handler();
    }

}

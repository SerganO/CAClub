using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowAttackScript : AttackScript
{
    public GameObject item;

    public Hero Player;

    public float xOffset = 0;
    public float yOffset = 0;
    public float Angle = 0;
    public float delay = 0;
    public Throwable.Type Type = Throwable.Type.single;
    public float Damage = 1;

    public override void Attack(VoidFunc completionHandler)
    {
        handler = completionHandler;
        StartCoroutine(PushCoroutine());
    }

    IEnumerator PushCoroutine()
    {
        isAttacking = true;
        var p = new Vector2(gameObject.transform.position.x + xOffset * (Player.IsInverted ? -1 : 1), gameObject.transform.position.y + yOffset);

        Visualizate();
        yield return new WaitForSeconds(delay);
        var g = Instantiate(item, p, Quaternion.identity);
        g.GetComponent<Slasbox>().Damage = Damage;
        g.GetComponent<Slasbox>().Hero = Hero;
        g.GetComponent<Throwable>().type = Type;
        g.GetComponent<Throwable>().Hero = GetComponentInParent<Hero>();
        g.GetComponent<Throwable>().Angle = Angle;
        yield return new WaitForSeconds(Mathf.Max(0, animationDuration - delay));

        
        isAttacking = false;
        handler();
    }
}

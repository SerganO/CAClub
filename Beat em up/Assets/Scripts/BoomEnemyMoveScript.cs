using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomEnemyMoveScript : BoomMoveScript
{
    public override int count
    {
        get
        {
            int c = 0;
            var gs = GameObject.FindGameObjectsWithTag("Enemy");
            c = gs.Length;
            Debug.Log(c);
            return c;
        }
    }


    protected override bool Effect()
    {
        if (count <= 0)
        {
            return false;
        }
        else
        {
            var gs = GameObject.FindGameObjectsWithTag("Enemy");

            for(int i =0;i< gs.Length;i++)
            {
                var x = gs[i];
                var g = Instantiate(slasbox, Hero.transform.parent);
                g.transform.position = x.transform.position;
                g.Hero = Hero;
                g.Damage = Damage;

                var b = Instantiate(boomAnimator, Hero.transform.parent);
                b.transform.position = x.transform.position;

                StartCoroutine(Helper.Wait(duration, () => { Destroy(g.gameObject); Destroy(b.gameObject); }));

                //StartCoroutine(Helper.Wait(0.01f, () => { Destroy(x); }));
            }

            return true;
        }
    }
}

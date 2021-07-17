using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomMoveScript : PlayerMoveScript
{
    public List<string> ids;
    public Animator boomAnimator;
    public float duration;
    public Slasbox slasbox;
    public float Damage;



    public virtual int count
    {
        get
        {
            int c = 0;
            var gs = GameObject.FindGameObjectsWithTag("Player");
            for (int i = 0; i < gs.Length; i++)
            {
                var ent = gs[i].GetComponent<Entity>();
                if (ent != null)
                {
                    Debug.Log(ent.ID);
                    if (ids.Contains(ent.Id)) c++;
                }
            }
            Debug.Log(c);
            return c;
        }
    }


    protected override bool Effect()
    {
        if(count <= 0)
        {
            return false;
        } else
        {
            var gs = GameObject.FindGameObjectsWithTag("Player");
            var list = new List<GameObject>();
            for (int i = 0; i < gs.Length; i++)
            {
                var ent = gs[i].GetComponent<Entity>();
                if (ent != null)
                {
                    Debug.Log(ent.ID);
                    if (ids.Contains(ent.Id)) list.Add(ent.gameObject);
                }
            }
            list.ForEach(x => {
                var g = Instantiate(slasbox, Hero.transform.parent);
                g.transform.position = x.transform.position;
                g.Hero = Hero;
                g.Damage = Damage;

                var b = Instantiate(boomAnimator, Hero.transform.parent);
                b.transform.position = x.transform.position;

                StartCoroutine(Helper.Wait(duration, () => { Destroy(g.gameObject); Destroy(b.gameObject); }));

                StartCoroutine(Helper.Wait(0.01f, () => { Destroy(x); }));
            });


            return true;
        }
    }
}

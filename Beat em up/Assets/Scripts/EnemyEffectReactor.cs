using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Spriter2UnityDX;

[RequireComponent(typeof(Enemy))]
public class EnemyEffectReactor : MonoBehaviour
{
    Enemy Enemy;
    public GameObject StunAnim;

    public bool isStuned = false;

    private void Start()
    {
        Enemy = GetComponent<Enemy>();
    }

    float stunTimer = 0;

    List<PowerTimePair> fires = new List<PowerTimePair>();

    float fireTimer = 1;

    private void Update()
    {
        if(stunTimer  <= 0)
        {
            stunTimer = 0;
            isStuned = false;
        } else
        {
            stunTimer -= Time.deltaTime;
            isStuned = true;
        }

        StunAnim.SetActive(isStuned);

        fireTimer -= Time.deltaTime;
        var sr = Enemy.GetComponent<SpriteRenderer>();
        var er = Enemy.GetComponent<EntityRenderer>();

        if (fireTimer <= 0)
        {

            if (fires.Count > 0)
            {
                if (Enemy.isDied) return;
                if (sr != null) sr.color = new Color(255, 69, 0);
                if (er != null) er.Color = new Color(255, 69, 0);

                fires = fires.FindAll(x => x.Time > 0 );

                fires.ForEach(x => x.Time -= 1);

                float damage = 0;

                fires.ForEach(x =>
                {
                    if (x.Power > damage) damage = x.Power;
                });

                Enemy.Hurt(damage);
            }
            else
            {


                if (sr != null) sr.color = new Color(255, 255, 255, 1);
                if (er != null) er.Color = new Color(255, 255, 255, 1);
            }


            fireTimer = 1;
        }

        

    }



    public virtual void ReactOnEffects(EffectClass effect)
    {
        if (!effect.neededHeroOption.TrueForAll(x => effect.Hero.optionCheck(x))) return;
        if (!ProbabilityMaster.Probability(effect.Chance)) return;
        bool flip = Enemy.getTargetPosition().x > Enemy.transform.position.x;
        switch (effect.Effect)
        {
            case Effect.Repulsion:
                StartCoroutine(Replace(flip ? -effect.Power : effect.Power, 0, 0.4f));
                break;
            case Effect.Stun:
                if(stunTimer <= effect.Time)
                {
                    stunTimer = effect.Time;
                }
                break;
            case Effect.Fire:
                var sr = Enemy.GetComponent<SpriteRenderer>();
                var er = Enemy.GetComponent<EntityRenderer>();
                if (sr != null) sr.color = new Color(255, 69, 0);
                if (er != null) er.Color = new Color(255, 69, 0);
                fires.Add(new PowerTimePair { Time = effect.Time, Power = effect.Power });
                break;
            case Effect.Vampire:
                effect.Hero.Heal(effect.Power);
                break;
        }
    }

    IEnumerator Replace(float xDistance, float yDistance, float time)
    {
        int n = 15;
        var part = time / n;
        var xd = xDistance / n;
        var yd = yDistance / n;

        for (int i = 0; i < n; i++)
        {
            Enemy.transform.position += new Vector3(xd, yd, 0);
            yield return new WaitForSeconds(part);
        }
    }
}

class PowerTimePair
{
    public float Time;
    public float Power;
}

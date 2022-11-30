using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Slasbox : MonoBehaviour
{
    public Hero Hero;
    public float Damage = 1;

    public double CalculatedDamage {
        get
        {
            return Damage * Hero.DamageMult;
        }
    }

    public List<EffectClass> effects = new List<EffectClass>();
}

[System.Serializable]
public class EffectClass {
    public Effect Effect;
    public int Chance;
    public float Power;
    public float Time;
    public List<string> neededHeroOption;

    public Hero Hero;
}


public enum Effect
{
    Repulsion, Stun, Fire, Vampire
}

public class ProbabilityMaster
{
    public static bool Probability(int chance)
    {
        var r = Random.Range(0, 101);
        return chance >= r;
    }

    public static int indexFromProbability(List<int> probabilitis)
    {
        int pool = 0;
        foreach(var i in probabilitis)
        {
            pool += i;
        }
        var r = Random.Range(0, pool + 1);

        int temp = 0;
        for (int i=0;i<probabilitis.Count;i++)
        {
            temp += probabilitis[i];
            if (r <= temp) return i;
        }
        return probabilitis.Count - 1;
    }

    public static EnemyAttack EnemyAttackFrom(List<EnemyAttack> attacks)
    {
        var probabilitis = new List<int>();
        for(int i=0;i< attacks.Count;i++)
        {
            probabilitis.Add(attacks[i].Probability);
        }
        return attacks[indexFromProbability(probabilitis)];
    }

    public static EntityAttack EntityAttackFrom(List<EntityAttack> attacks)
    {
        var probabilitis = new List<int>();
        for (int i = 0; i < attacks.Count; i++)
        {
            probabilitis.Add(attacks[i].Probability);
        }
        return attacks[indexFromProbability(probabilitis)];
    }
}


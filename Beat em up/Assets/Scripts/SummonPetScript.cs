using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonPetScript : PlayerMoveScript
{
    public Entity pet;

    int count
    {
        get
        {
            int c = 0;
            var gs =  GameObject.FindGameObjectsWithTag("Player");
            for(int i =0;i< gs.Length;i++)
            {
                var ent = gs[i].GetComponent<Entity>();
                if (ent != null)
                {
                    Debug.Log(ent.ID);
                    if (ent.Id == pet.Id) c++;
                }
            }
            return c;
        }
    }

    public int maxCount = 1;

    protected override bool Effect()
    {
        if (count < maxCount)
        {
            var g = Instantiate(pet, Hero.transform.parent);
            g.transform.position = Hero.transform.position;
            g.Hero = Hero;


            return true;
        } else
        {
            return false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Hero))]
public class HeroSetuper : MonoBehaviour
{
    protected Hero Hero;
    private void Start()
    {
        Hero = GetComponent<Hero>();
        Setup();
    }

    public virtual void Setup()
    {

    }
}




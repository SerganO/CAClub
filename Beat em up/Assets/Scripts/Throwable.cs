using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwable : MonoBehaviour
{
    public Hero Hero;
    public float Speed = 100;
    bool inv = false;
    public float Angle = 0;
    Rigidbody2D rb;

    public enum Type
    {
        unstopable, single
    }

    public Type type = Type.single;

    void Start()
    {
        inv = Hero.IsInverted;
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        Vector2 velocity = new Vector2(inv ? -1:1, Mathf.Sin(Angle));
        rb.velocity = velocity * Speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(type)
        {
            case Type.single:
                if (collision.tag == "EnemyHitBox" || collision.tag == "Border")
                {
                    Destroy(gameObject);
                }
                break;
            case Type.unstopable:
                if (collision.tag == "Border")
                {
                    Destroy(gameObject);
                }
                break;
        }
        

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroHitBox : MonoBehaviour
{
    public delegate void hurtFunc(double damage);

    public event hurtFunc hurt;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemySlashBox")
        {
            hurt(collision.GetComponent< EnemySlashBox>().Damage);
        }

    }
}

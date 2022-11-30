using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitBox : MonoBehaviour
{
    public delegate void hurtFunc(Slasbox slash);
    public delegate void hurtEntityFunc(EntitySlashBox slash);
    public event hurtFunc hurt;
    public event hurtEntityFunc hurtE;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "SlashBox")
        {
            if(collision.GetComponent<Slasbox>() != null)
            {
                try
                {
                    hurt(collision.GetComponent<Slasbox>());
                }
                catch { };
            } else if (collision.GetComponent<EntitySlashBox>() != null)
            {
                try
                {
                    hurtE(collision.GetComponent<EntitySlashBox>());
                }
                catch { };
            }



        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityHitBox : MonoBehaviour
{
    public delegate void hurtFunc(EnemySlashBox slash);

    public event hurtFunc hurt;

    void mock(EnemySlashBox slash)
    {
        
    }

    private void Start()
    {
        hurt += mock;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemySlashBox")
        {
            hurt(collision.GetComponent<EnemySlashBox>());

        }
    }
}

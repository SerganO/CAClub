using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageChecker : MonoBehaviour
{
    [SerializeField]
    Animator animator;
    public int hp = 5;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "SlashBox") {
            hp--;
            if(hp > 0)
            {
                StartCoroutine(PushCoroutine());
            } else
            {
                animator.Play("Dying");
                enabled = false;
            }
        }
        
    }

    IEnumerator PushCoroutine()
    {
        animator.Play("Hurt");
        yield return new WaitForSeconds(0.4f);
        animator.Play("Idle");
    }

}

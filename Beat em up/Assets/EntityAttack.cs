using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAttack : MonoBehaviour
{
    [Header("Attack info")]
    public EntitySlashBox SlashBox;
    public int Probability;

    public float Damage;
    public float afterCD;

    [Header("Visual")]
    public Animator animator;
    public string animationName;
    public float animationDuration;

    public Animator addAnimator;
    public string addAnimationName;
    public float addAnimationDuration;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip sound;


    protected bool isAttacking = false;

    public virtual void Attack()
    {
        StartCoroutine(PushCoroutine());
    }

    IEnumerator PushCoroutine()
    {
        isAttacking = true;
        SlashBox.Damage = Damage;
        SlashBox.SetAreaActive(true);
        Visualizate();
        yield return new WaitForSeconds(animationDuration);
        isAttacking = false;
        SlashBox.SetAreaActive(false);
    }

    protected virtual void TryPlaySound()
    {
        if (audioSource != null && sound != null)
        {
            audioSource.clip = sound;
            audioSource.Play();
        }
    }

    protected virtual void TryPlayAnimation()
    {
        if (animator != null)
        {
            animator.Play(animationName);
        }
    }

    protected virtual void TryPlayAddAnimation()
    {
        if (addAnimator != null)
        {
            TryAddAnimatorActivated(true);
            addAnimator.Play(addAnimationName);
            StartCoroutine(Helper.Wait(addAnimationDuration, () => {
                TryAddAnimatorActivated(false);
            }));
        }
    }

    protected virtual void TryAddAnimatorActivated(bool value)
    {
        if (addAnimator != null)
        {
            addAnimator.gameObject.SetActive(value);
        }
    }

    public virtual void Visualizate()
    {
        TryPlaySound();
        TryPlayAnimation();
        TryPlayAddAnimation();
    }

}

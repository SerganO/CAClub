using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class Helper
{
    public static IEnumerator Wait(float time, VoidFunc action)
    {
        yield return new WaitForSeconds(time);
        action();
    }

    public static void SetVisible(Transform t, bool b)
    {
        int v = b ? 1 : 0;
        t.localScale = new Vector3(v, v, v);
    }

    public static string ColorText(string color, string text)
    {
        return "<color=" + color + ">" + text + "</color>";
    }
}

public class PlayerMoveScript : MonoBehaviour
{
    [Header("Controll Hero")]
    public Hero Hero;

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

    protected VoidFunc handler;

    private void Start()
    {
        Setup();
    }

    public virtual void Setup()
    {
        Debug.Log("Setup");
        TryAddAnimatorActivated(false);
    }

    public virtual void DoWithCompletion(VoidFunc completionHandler)
    {
        handler = completionHandler;
        StartCoroutine(DoCoroutine());
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
        if(animator != null)
        {
            animator.speed = Hero.speedMult;
            animator.Play(animationName);
        }
    }

    protected virtual void TryPlayAddAnimation()
    {
        if (addAnimator != null)
        {
            TryAddAnimatorActivated(true);
            addAnimator.speed = Hero.speedMult;
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

    protected virtual bool Effect() { return true; }

    protected virtual IEnumerator DoCoroutine()
    {
        if (Effect())
        {
            Visualizate();
            yield return new WaitForSeconds(animationDuration);
            handler();
        }
    }

    
}
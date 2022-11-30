using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosePlayerAnimator : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play("Walking");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using UnityEngine;
using System.Collections;
using System;

public class SimpleAnimator : MonoBehaviour {
    private Animator animator;
    public int direction = 0;
    public float speed = 0;
    public bool isInteracting = false;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update ()
    {
        animator.SetInteger("direction", direction);
        animator.SetFloat("speed", speed);
        animator.SetBool("isInteracting", isInteracting);
    }
}

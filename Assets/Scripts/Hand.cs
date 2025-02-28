using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public float speed;
    Animator animator;
    private float gripTarget;
    private float triggerTarget;
    private float thumbTarget;
    private float gripCurrent;
    private float triggerCurrent;
    private float thumbCurrent;
    private string animatorGripParam = "Grip";
    private string animatorTriggerParam = "Trigger";
    private string animatorThumbParam = "Thumb";
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimateHand();
    }

    internal void SetThumb(float v)
    {
        thumbTarget = v;
    }

    internal void SetGrip(float v)
    {
        gripTarget = v;
    }

    internal void SetTrigger(float v)
    {
        triggerTarget = v;
    }

    void AnimateHand()
    {
        if (gripCurrent != gripTarget)
        {
            gripCurrent = Mathf.MoveTowards(gripCurrent, gripTarget, Time.deltaTime * speed);
            animator.SetFloat(animatorGripParam, gripCurrent);
        }
        if (triggerCurrent != triggerTarget)
        {
            triggerCurrent = Mathf.MoveTowards(triggerCurrent, triggerTarget, Time.deltaTime * speed);
            animator.SetFloat(animatorTriggerParam, triggerCurrent);
        }
        if (thumbCurrent != thumbTarget)
        {
            thumbCurrent = Mathf.MoveTowards(thumbCurrent, thumbTarget, Time.deltaTime * speed);
            animator.SetFloat(animatorThumbParam, thumbCurrent);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FlipFlop : MonoBehaviour
{
    [SerializeField] private UnityEvent runWhenOn, runWhenOff;
    [SerializeField] private AudioClip flipSound;
    [SerializeField] private Animator animator;

    public bool state = false;

    public void Flip()
    {
        state = !state;
        AudioSource.PlayClipAtPoint(flipSound, transform.position);
        if (state)
        {
            animator.Play("FlipFlop_On");
        }
        else
        {
            animator.Play("FlipFlop_Off");
        }
    }

    private void Update()
    {
        if (state)
        {
            runWhenOn.Invoke();
        }
        else
        {
            runWhenOff.Invoke();
        }
    }

}

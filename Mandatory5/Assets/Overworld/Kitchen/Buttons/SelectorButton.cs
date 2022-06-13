using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SelectorButton : MonoBehaviour
{
    [SerializeField] private AudioClip flipSound;
    [SerializeField] private Animator animator;

    public int state = 1;

    public void Flip()
    {
        AudioSource.PlayClipAtPoint(flipSound, transform.position);
        state++;
        if (state > 3)
        {
            state = 1;
        }
        if (state == 1)
        {
            animator.Play("Selector_1");
        }
        else if (state == 2)
        {
            animator.Play("Selector_2");
        }
        else if (state == 3)
        {
            animator.Play("Selector_3");
        }
    }
}

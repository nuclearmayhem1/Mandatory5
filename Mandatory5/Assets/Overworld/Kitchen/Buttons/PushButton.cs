using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PushButton : MonoBehaviour
{
    [SerializeField] private UnityEvent runOnPress;
    [SerializeField] private AudioClip flipSound;
    [SerializeField] private Animator animator;

    public void Press()
    {
        AudioSource.PlayClipAtPoint(flipSound, transform.position);
        animator.Play("PushButton");
        runOnPress.Invoke();
    }
}

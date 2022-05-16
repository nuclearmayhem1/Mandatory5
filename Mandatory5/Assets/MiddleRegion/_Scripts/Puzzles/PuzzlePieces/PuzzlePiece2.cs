using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece2 : MonoBehaviour
{
    public MidGameManager gameManager;
    public Animator animator;
    private void Start()
    {
        gameManager = GameObject.Find("MidGameManager").GetComponent<MidGameManager>();
        animator = gameObject.GetComponent<Animator>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameManager.piece2Collected = true;
            animator.SetBool("collected", true);
        }
    }
}
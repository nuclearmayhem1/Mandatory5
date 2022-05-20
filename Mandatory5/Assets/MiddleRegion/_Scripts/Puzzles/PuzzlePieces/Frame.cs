using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frame : MonoBehaviour
{
    public MidGameManager gameManager;
    public Sprite[] mapPieces;
    void Start()
    {
        gameManager = GameObject.Find("MidGameManager").GetComponent<MidGameManager>();
    }

    void Update()
    {
        if (gameManager.piece1Collected == true)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = mapPieces[0];
        }
        if (gameManager.piece2Collected == true)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = mapPieces[1];
        }
        if (gameManager.piece3Collected == true)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = mapPieces[2];
        }
    }
}

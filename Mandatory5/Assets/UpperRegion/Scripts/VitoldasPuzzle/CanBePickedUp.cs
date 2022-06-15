using UnityEngine;

public class CanBePickedUp : MonoBehaviour
{
    public bool pickedUp = false;

    private Transform playerRightHand;

    private Vector3 originalPosition;

    private void Awake()
    {
        playerRightHand = GameObject.Find("Right_Hand").transform;

        originalPosition = transform.GetChild(0).localPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && playerRightHand.childCount == 5)
        {
            if (!pickedUp)
            {
                transform.GetComponent<Animator>().enabled = false;

                transform.GetChild(0).localPosition = originalPosition;

                transform.position = playerRightHand.position;
                transform.rotation = playerRightHand.rotation;
                transform.Rotate(Vector3.right, -135f);

                transform.SetParent(playerRightHand, true);

                pickedUp = true;
            }
        }
    }
}

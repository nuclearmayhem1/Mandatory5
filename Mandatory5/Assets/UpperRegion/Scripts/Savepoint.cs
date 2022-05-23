using UnityEngine;

public class Savepoint : MonoBehaviour
{
    [SerializeField] private Transform[] locations;

    private void Awake()
    {
        locations = GetComponentsInChildren<Transform>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.GetComponentInChildren<CanBePickedUp>() == null)
            {
                return;
            }
            else
            {
                CanBePickedUp itemHeld = other.GetComponentInChildren<CanBePickedUp>();

                int randomLocation = Random.Range(1, locations.Length);

                if (locations[randomLocation].childCount == 0)
                {
                    itemHeld.transform.SetParent(locations[randomLocation].transform);
                    itemHeld.transform.position = locations[randomLocation].position;
                    itemHeld.transform.rotation = locations[randomLocation].rotation;

                    itemHeld.pickedUp = false;
                }
            }
        }
    }
}

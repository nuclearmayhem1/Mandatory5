using UnityEngine;

public class Savepoint : MonoBehaviour
{
    public Transform[] locations;

    private void Awake()
    {
        locations = GetComponentsInChildren<Transform>();
    }

    private void Update()
    {
        if (BeanRescueManager.Instance.reset)
        {
            ClearBeans();

            BeanRescueManager.Instance.reset = false;
        }
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

                if (locations[randomLocation].childCount != 0)
                {
                    return;
                }
                else
                {
                    itemHeld.transform.SetParent(locations[randomLocation].transform);
                    itemHeld.transform.position = locations[randomLocation].position;
                    itemHeld.transform.rotation = locations[randomLocation].rotation;

                    BeanRescueManager.Instance.beansRescued++;
                    itemHeld.pickedUp = false;
                    Destroy(itemHeld);
                }
            }
        }
    }

    public void ClearBeans()
    {
        for (int i = 1; i < locations.Length; i++)
        {
            if (locations[i].childCount != 0)
            {
                Destroy(locations[i].GetChild(0).gameObject);
            }
        }
    }
}

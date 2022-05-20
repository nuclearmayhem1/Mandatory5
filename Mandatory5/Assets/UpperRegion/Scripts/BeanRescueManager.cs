using UnityEngine;

public class BeanRescueManager : MonoBehaviour
{
    [SerializeField] private Transform spawner;
    [SerializeField] private GameObject bean;
    [SerializeField] private float spawnInterval;

    private void Start()
    {
        InvokeRepeating("SpawnBeans", 20f, spawnInterval);
    }

    private void SpawnBeans()
    {
        Instantiate(bean, spawner.localPosition, Quaternion.identity);
    }
}

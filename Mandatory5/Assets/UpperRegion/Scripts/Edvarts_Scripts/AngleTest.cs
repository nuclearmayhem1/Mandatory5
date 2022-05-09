using UnityEngine;

public class AngleTest : MonoBehaviour
{
    public GameObject test2;
    void Update()
    {
        Debug.Log(Vector3.Angle(transform.forward, test2.transform.position));
    }
}

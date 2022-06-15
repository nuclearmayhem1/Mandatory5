using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private GameObject cam;

    private void Awake()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Update()
    {
        transform.rotation = cam.transform.rotation;
    }
}

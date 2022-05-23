using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private GameObject cam;

    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Update()
    {
        transform.rotation = cam.transform.rotation;
    }
}

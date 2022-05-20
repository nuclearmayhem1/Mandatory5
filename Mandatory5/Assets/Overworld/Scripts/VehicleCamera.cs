using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleCamera : MonoBehaviour
{
    [SerializeField] private float cameraSpeed = 300, scrollSpeed = 300;
    [SerializeField] private GameObject camera;

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    float posX = 0, posY = 0;

    [SerializeField] private float cameraDistanceMin = -25, cameraDistanceMax = -10;
    float cameraDistance = -25;

    private void Update()
    {

        posY += Input.GetAxis("Mouse X") * Time.deltaTime * cameraSpeed;
        posX += Input.GetAxis("Mouse Y") * Time.deltaTime * cameraSpeed;

        Vector3 newRotation = new Vector3(posX, posY);

        transform.eulerAngles = newRotation;

        cameraDistance += Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * scrollSpeed;
        cameraDistance = Mathf.Clamp(cameraDistance, cameraDistanceMin, cameraDistanceMax);

        camera.transform.localPosition = new Vector3(0, 0, cameraDistance);

    }
}

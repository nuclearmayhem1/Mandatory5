using UnityEngine;
using UnityEngine.Events;

public class PressurePlate : MonoBehaviour
{
    public Animator plateAnim;
    public float getOffDelay = 0;
    public UnityEvent onPressurePlate;
    public UnityEvent offPressurePlate;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player") 
        {
            plateAnim.SetBool("IsActive", true);
            onPressurePlate.Invoke();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Invoke("Off", getOffDelay);
        }
    }
    private void Off()
    {
        plateAnim.SetBool("IsActive", false);
        offPressurePlate.Invoke();
    }
}

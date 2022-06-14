using UnityEngine.UI;
using UnityEngine;
using StarterAssets;

public class ClawMachine : MonoBehaviour
{
    public GameObject ClawArm;
    public Animator animator;
   
    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    public void MoveLeft()
    {
        ClawArm.transform.position = new Vector3(ClawArm.transform.position.x + 1, ClawArm.transform.position.y, ClawArm.transform.position.z);
    }
    public void MoveRight()
    {
        ClawArm.transform.position = new Vector3(ClawArm.transform.position.x - 1, ClawArm.transform.position.y, ClawArm.transform.position.z);
    }
    public void MoveForward()
    {
        ClawArm.transform.position = new Vector3(ClawArm.transform.position.x, ClawArm.transform.position.y, ClawArm.transform.position.z - 1f);
    }
    public void MoveBackward()
    {
        ClawArm.transform.position = new Vector3(ClawArm.transform.position.x, ClawArm.transform.position.y, ClawArm.transform.position.z + 1f);
    }
    public void Grab()
    {
        animator.SetBool("Grab", true);
    }
    public void Release()
    {
        animator.SetBool("Grab", false);
    }
}
 
using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using StarterAssets;

public class ClawMachine : MonoBehaviour
{
    public GameObject ClawArm;
    public Animator animator;
    private Vector3 startingPos;
    private float elapsedTime;
    private int timesGrabbed;
    public GameObject winCondition;
    float lerpDuration = 1; 
    float startValue = 0;

    private void Start()
    {
        
        //startingPos = new Vector3(ClawArm.transform.localPosition.x, 30, ClawArm.transform.localPosition.z);
        animator = gameObject.GetComponent<Animator>();
        
    }
    public void MoveLeft()
    {
        if (!ClawArm.GetComponent<MidGrabbing>().grabbing)
        {
            ClawArm.transform.position = new Vector3(ClawArm.transform.position.x + 1, ClawArm.transform.position.y,
                ClawArm.transform.position.z);
        }
    }
    public void MoveRight()
    {
        if (!ClawArm.GetComponent<MidGrabbing>().grabbing)
        {
            ClawArm.transform.position = new Vector3(ClawArm.transform.position.x - 1, ClawArm.transform.position.y,
                ClawArm.transform.position.z);
        }
    }
    public void MoveForward()
    {

        if (!ClawArm.GetComponent<MidGrabbing>().grabbing)
        {
            ClawArm.transform.position = new Vector3(ClawArm.transform.position.x, ClawArm.transform.position.y,
                ClawArm.transform.position.z - 1f);
        }
    }
    public void MoveBackward()
    {
        
        if (!ClawArm.GetComponent<MidGrabbing>().grabbing)
        {
            ClawArm.transform.position = new Vector3(ClawArm.transform.position.x, ClawArm.transform.position.y,
                ClawArm.transform.position.z + 1f);
        }
    }
    public void Grab()
    {
        if (!ClawArm.GetComponent<MidGrabbing>().grabbing)
        {
            timesGrabbed++;
            ClawArm.GetComponent<MidGrabbing>().grabbing = true;
            animator.SetBool("Grab", true);
            //Debug.Log("The animator 'grab' bool is set to"+ animator.GetBool("Grab"));
            Invoke("Release",1f);
        }
        
    }
    public void Release()
    {
        if (timesGrabbed == 5)
        {
            winCondition.GetComponent<MidClawWin>().cannister.transform.localPosition = new Vector3(
                winCondition.transform.position.y + 2, winCondition.transform.position.x,
                winCondition.transform.position.z);
        }
        StartCoroutine("ResetPos");
        animator.SetBool("Grab", false);
    }


    private IEnumerator ResetPos()
    {
        yield return new WaitForSecondsRealtime(1);
        //lerpDuration = 3;
        startingPos = new Vector3(0, 1.5f, 0);
        //Debug.Log(startingPos);
        //float timeElapsed = 0;
        while (ClawArm.transform.localPosition != startingPos)
        {
            var step =  5 * Time.deltaTime; // calculate distance to move
            ClawArm.transform.localPosition = Vector3.MoveTowards(ClawArm.transform.localPosition, startingPos, step);
            //timeElapsed += Time.deltaTime;
            yield return null;
        }
        yield return new WaitForSecondsRealtime(2);
        ClawArm.GetComponent<MidGrabbing>().grabbing = false;
        yield break;
    }
}
 
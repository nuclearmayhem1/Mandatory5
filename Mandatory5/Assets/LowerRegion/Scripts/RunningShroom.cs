using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RunningShroom : MonoBehaviour
{
    private NavMeshAgent agent;
    public BoxCollider boxBounds;
    public GameObject player;
    public float distanceToRun = 4f;
    private bool isDirSafe = false;
    private float vRotation = 0f;
    private static int mushroomsCollected;

    public static RunningShroom rShroom;

    private GameObject box;

    [SerializeField]
    private int timesToRun;

    public Vector3 startPosition;

    public bool caught;

    private void Awake() 
    {
        rShroom = this;
        startPosition = transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //box = GameObject.CreatePrimitive(PrimitiveType.Cube);
    }

    // Update is called once per frame
    void Update()
    {
        if (caught) return;

        float distance = Vector3.Distance(transform.position, player.transform.position);


        //run away from the player
        if (distance < distanceToRun)
        {
            timesToRun = 50;
            isDirSafe = false;
            vRotation = 0f;

            while (!isDirSafe && timesToRun > 0)
            {
                //Calculate the vector pointing from Player to the mushroom
                Vector3 dirToPlayer = player.transform.position - transform.position;

                //Rotate the relative by vRotation 
                dirToPlayer = Quaternion.Euler(0, vRotation, 0) * dirToPlayer;

                //Calculate the vector from the mushroom to the direction away from the Player the new point
                Vector3 newPos = transform.position - dirToPlayer;

                newPos.y = transform.position.y;

                //box.transform.position = newPos;

                //check if newPos is inside the bounds
                if (!boxBounds.bounds.Contains(newPos))
                {
                    vRotation += 20;
                    //isDirSafe = false;
                }
                else
                {
                    isDirSafe = true;
                    agent.SetDestination(newPos);
                }

                if (--timesToRun == 0)
                {
                    Debug.Log("exceeded times to run");
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (caught) return;
        if (other.gameObject.CompareTag("Player"))
        {
            if (++mushroomsCollected == 5)
            {
                //activate platforms
                SecondMiniGameController.sMGC.rock.SetActive(false);
                SecondMiniGameController.sMGC.lastPlatform.SetActive(true);

               
            } else Debug.Log(mushroomsCollected);

            StartCoroutine(Caught());
        }
    }

    //method for when the mushroom gets caught
    private IEnumerator Caught()
    {
        caught = true;

        agent.SetDestination(transform.position);

        yield return new WaitForSeconds(1f);

        gameObject.SetActive(false);
    }

    public void RestartPuzzle(RunningShroom[] mushrooms)
    {
        mushroomsCollected = 0;

        for (int i = 0; i < mushrooms.Length; i++)
        {
            mushrooms[i].gameObject.SetActive(true);
            mushrooms[i].transform.position = mushrooms[i].startPosition;
            mushrooms[i].agent.SetDestination(mushrooms[i].startPosition);
            mushrooms[i].caught = false;
        }
    }
}

using UnityEngine;

public class BeanRescueManager : MonoBehaviour
{
    public static BeanRescueManager Instance { get; private set; }

    public int beansRescued = 0;
    public int beanCount = 3;
    public bool reset = false;
    public Timer timer;

    [SerializeField] private Transform spawner;
    [SerializeField] private Transform puzzleRoot;
    [SerializeField] private GameObject bean;
    [SerializeField] private float spawnInterval;
    [SerializeField] private TMPro.TextMeshProUGUI beanCounterText;
    [SerializeField] private Savepoint savepoint;

    private void Awake() => Instance = this;

    private void Update()
    {
        if (timer.timerSeconds > 0)
        {
            beanCounterText.text = "Beans rescued: " + beansRescued + " / " + beanCount;
        }
        else
        {
            Transform bugFixHeldBean = GameObject.Find("Right_Hand").transform;

            if (bugFixHeldBean.childCount > 5)
            {
                Destroy(bugFixHeldBean.GetChild(5).gameObject);
            }
        }
    }

    private void SpawnBeans()
    {
        Instantiate(bean, spawner.localPosition, Quaternion.identity, puzzleRoot);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && beansRescued != beanCount)
        {
            this.enabled = true;
            timer.gameObject.SetActive(true);
            timer.timerRunning = true;
        }
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void OnEnable()
    {
        InvokeRepeating("SpawnBeans", 0f, spawnInterval);

        if (beansRescued > 0)
        {
            savepoint.ClearBeans();
            beansRescued = 0;
        }
    }


}

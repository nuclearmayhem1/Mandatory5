using UnityEngine;

public class BeanRescueManager : MonoBehaviour
{
    public static BeanRescueManager Instance { get; private set; }

    public int beansRescued = 0;
    public int beanCount = 3;
    public bool reset = false;

    [SerializeField] private Transform spawner;
    [SerializeField] private GameObject bean;
    [SerializeField] private float spawnInterval;
    [SerializeField] private TMPro.TextMeshProUGUI beanCounterText;
    [SerializeField] private Timer timer;
    [SerializeField] private Savepoint savepoint;

    private void Awake() => Instance = this;

    private void Update()
    {
        if (timer.timerSeconds > 0)
        {
            beanCounterText.text = "Beans rescued: " + beansRescued + " / " + beanCount;
        }

        if (beansRescued != beanCount)
        {

        }

        if (reset)
        {
            beanCounterText.text = "Beans rescued: " + 0 + " / " + beanCount;

            GameObject[] allBeans = GameObject.FindGameObjectsWithTag("Bean");
            for (int i = 0; i < allBeans.Length; i++)
            {
                Destroy(allBeans[i]);
            }

            reset = false;
        }
        
    }

    private void SpawnBeans()
    {
        Instantiate(bean, spawner.localPosition, Quaternion.identity);
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
    }


}

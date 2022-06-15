using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ColorMiniGameController : MonoBehaviour
{
    public GameObject mushroomController, startPlatform, transitionPlaftom;
    public Renderer[] rends;
    private Color[] colors;
    private float colorDuration = 3f;
    private int colorIndex, roundCounter = 1;
    private bool turnOff = true, hasWaited = true;
    public static ColorMiniGameController cMGC;

    [HideInInspector]
    public bool restartWholeGame = false, minigameHasEnded = false, readyAgain = true;

    // Start is called before the first frame update
    void Awake()
    {
        cMGC = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (restartWholeGame)
        {
            restartWholeGame = false;

            startPlatform.gameObject.SetActive(true);
            transitionPlaftom.gameObject.SetActive(true);
        }

        if (minigameHasEnded)
        {
            startPlatform.gameObject.SetActive(true);
            transitionPlaftom.gameObject.SetActive(true);

            NewRound();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (minigameHasEnded == false)
        {
            
            if (turnOff == true && readyAgain == true)
            {
                Debug.Log("New round");
                turnOff = false;
                readyAgain = false;

                StartCoroutine(Wait());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        StopAllCoroutines();

        NewRound();
    }

    //switch the color of the platforms
    private IEnumerator ColorSwitch()
    {
        startPlatform.gameObject.SetActive(false);
        transitionPlaftom.gameObject.SetActive(false);

        rends[0].material.color = colors[Random.Range(0, colors.Length)];

        List<int> usedIndices = new List<int>();

        for (int i = 1; i < rends.Length; i++)
        {
            yield return new WaitForSeconds(1f);

            do
            {
                colorIndex = Random.Range(0, colors.Length);
            }
            while (usedIndices.Contains(colorIndex));

            usedIndices.Add(colorIndex);

            rends[i].material.color = colors[colorIndex];
        }

        int correctIndex = rends.ToList().FindIndex(1, 4, x => x.material.color == rends[0].material.color);

        Renderer[] incorrect = rends.Where((obj, index) => index != 0 && index != correctIndex).ToArray();

        for (int i = 0; i < 5; ++i)
        {
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(Blink(incorrect));
        }

        StopAllCoroutines();
        foreach (Renderer r in incorrect) r.gameObject.SetActive(false);


        if (roundCounter <= 4)
        {
            roundCounter += 1;
            readyAgain = true;
        }
    }

    //wait before starting the next round
    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.5f);

        NewRound();

        colors = new Color[] {Color.green, Color.red, Color.blue, Color.yellow};

        StartCoroutine(RoundManager());
    }

    //blink the platforms before they disappear
    private IEnumerator Blink(Renderer[] rends)
    {
        Color[] storedColor = new Color[3];

        for (int i = 0; i < rends.Length; i++)
        {
            storedColor[i] = rends[i].material.color;
        }

        for (int i = 0; i < rends.Length; i++)
        {
            rends[i].material.color = Color.grey;
        }

        yield return new WaitForSeconds(0.2f);

        for (int i = 0; i < rends.Length; i++)
        {
            rends[i].material.color = storedColor[i];
        }
    }

    //restart the round (make all platforms active again and all platforms back to white)
    private void NewRound()
    {
        for (int i = 1; i < rends.Length; i++)
        {
            rends[i].gameObject.SetActive(true);
        }

        for (int i = 0; i < rends.Length; i++)
        {
            rends[i].material.color = Color.white;
        }

        turnOff = true;
    }

    //manager for the rounds
    private IEnumerator RoundManager()
    {
        if (restartWholeGame == false)
        {  
            switch (roundCounter)
            {
                case 1:
                    yield return new WaitForSeconds(0.5f);

                    StartCoroutine(ColorSwitch());

                    if (!restartWholeGame)
                    {
                        turnOff = true;
                        StopCoroutine(RoundManager());
                    }

                    break;

                case 2:
                    yield return new WaitForSeconds(0.5f);

                    colorDuration = 2f;
                    StartCoroutine(ColorSwitch());

                    if (!restartWholeGame)
                    {
                        turnOff = true;
                        StopCoroutine(RoundManager());
                    }

                    break;

                case 3:
                    yield return new WaitForSeconds(0.5f);

                    colorDuration = 1.5f;
                    StartCoroutine(ColorSwitch());

                    if (!restartWholeGame)
                    {
                        turnOff = true;
                        StopCoroutine(RoundManager());
                    }

                    break;

                case 4:
                    if (!restartWholeGame)
                    {
                        turnOff = true;
                        minigameHasEnded = true;
                        roundCounter = 1;
                        StopCoroutine(RoundManager());
                    }

                    break;
            }
        }
        else
        {
            roundCounter = 1;
        }
    }
}

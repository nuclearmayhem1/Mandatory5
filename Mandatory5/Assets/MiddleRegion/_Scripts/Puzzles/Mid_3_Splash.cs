using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mid_3_Splash : MonoBehaviour
{
    public float growFactor;
    public float timer = 0;

    
    public bool scaleDownB;

    [SerializeField]
    private Material splashOneMat;

    [SerializeField]
    private Material splashTwoMat;

    [SerializeField]
    private Material splashThreeMat;



    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(0.000001f, 0.000001f, 0.0000001f);

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        /*if (Input.GetKeyDown(KeyCode.O))
        {
            ScaleDown();
        }*/
        

        /*if (Input.GetKeyDown(KeyCode.L))
        {
            scaleDownB = false;
        }*/

        if (scaleDownB)
        {
            transform.localScale -= new Vector3(0.2f, 1, 0.3f) * Time.deltaTime * growFactor;

        }

       

       /* if (Input.GetKeyDown(KeyCode.J)) //Change Material & Turning on scaling
        {
            transform.localScale = new Vector3(0.2f, 1, 0.3f);
        }*/
    }

    public void ResetScale()
    {
        transform.localScale = new Vector3(0.2f, 1, 0.3f);

    }


    /*void ScaleDown()
    {
        scaleDownB = true;
    }*/

    public void MaterialOne()
    {
        gameObject.GetComponent<Renderer>().material = splashOneMat;
    }
    public void MaterialTwo()
    {
        gameObject.GetComponent<Renderer>().material = splashTwoMat;
    }
    public void MaterialThree()
    {
        gameObject.GetComponent<Renderer>().material = splashThreeMat;
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawLineBetweenObjects : MonoBehaviour
{
    public RectTransform object1;
    public RectTransform object2;
    private Image image;
    private RectTransform rectTransform;
    private BrotherSisterScript brotherSister;
    

    void Start()
    {
        brotherSister = GameObject.Find("Sister").GetComponent<BrotherSisterScript>(); //Temp
        image = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
    }

    public void SetObjects()
    {
        object1 = object1.GetComponent<RectTransform>();
        object2 = object2.GetComponent<RectTransform>();

        RectTransform aux;
        if (object1.localPosition.x > object2.localPosition.x)
        {
            aux = object1;
            object1 = object2;
            object2 = aux;
        }
    }
    // Update is called once per frame
    void Update()
    {
        SetObjects();
        object2 = brotherSister.bestTarget.GetComponent<RectTransform>();
        if (object1.gameObject.activeSelf && object2.gameObject.activeSelf)
        {
            rectTransform.localPosition = (object1.localPosition + object2.localPosition) / 2;
            Vector3 dif = object2.localPosition - object1.localPosition;
            rectTransform.sizeDelta = new Vector3(dif.magnitude, 5);
            rectTransform.rotation = Quaternion.Euler(new Vector3(0, 0, 180 * Mathf.Atan(dif.y / dif.x) / Mathf.PI));
        }
    }
}

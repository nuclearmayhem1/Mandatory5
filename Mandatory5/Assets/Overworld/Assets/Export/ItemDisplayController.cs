using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDisplayController : MonoBehaviour
{

    [SerializeField] private GameObject item;

    [SerializeField] private string key;
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance.GetItemValue(key) == 1)
        {
            item.SetActive(true);
        }else
        {
            item.SetActive(false);
        }
    }

    
}

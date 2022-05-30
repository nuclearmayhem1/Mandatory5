using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallPickup : MonoBehaviour
{
    [SerializeField] private string key;
    public void PickUpItem()
    {
        GameManager.Instance.SetItem(key);
    }

}

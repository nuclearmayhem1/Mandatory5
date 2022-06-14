using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnIngredient : MonoBehaviour
{
    [SerializeField] private GameObject ingredientPrefab;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private GameObject displayed;
    [SerializeField] private string itemKey;

    private bool unlocked = false;
    private void Start()
    {
        if (GameManager.Instance.GetItemValue(itemKey) == 1)
        {
            unlocked = true;
            displayed.SetActive(true);
        }
    }

    public void Spawn()
    {
        if (unlocked)
        {
            Instantiate(ingredientPrefab, spawnPos.position, Quaternion.identity, null);
        }
    }


}

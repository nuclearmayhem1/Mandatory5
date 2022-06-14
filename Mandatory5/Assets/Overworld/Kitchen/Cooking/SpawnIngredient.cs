using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnIngredient : MonoBehaviour
{
    [SerializeField] private GameObject ingredientPrefab;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private GameObject displayed;

    public void Spawn()
    {
        Instantiate(ingredientPrefab, spawnPos.position, Quaternion.identity, null);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    public List<finalRecipie> recipies;
    public Transform spawnPos;
    

    public void combineFoods()
    {
        string[] currentIngredeints = new string[ingredients.Count];
        for (int i = 0; i < ingredients.Count; i++)
        {
            currentIngredeints[i] = ingredients[i].name.Replace("(Clone)", "");
        }
        foreach (finalRecipie recipie in recipies)
        {
            bool allMatch = true;
            for (int i = 0; i < recipie.ingredients.Length; i++)
            {
                bool match = false;
                for (int o = 0; o < currentIngredeints.Length; o++)
                {
                    if (recipie.ingredients[i] == currentIngredeints[o])
                    {
                        match = true;
                        break;
                    }
                }
                if (!match)
                {
                    allMatch = false;
                    break;
                }
            }
            if (allMatch)
            {
                foreach (GameObject item in ingredients)
                {
                    Destroy(item);
                }
                Instantiate(recipie.turnsInto, spawnPos.position, Quaternion.identity, null);
                ingredients.Clear();
                return;
            }
        }
    }



    private List<GameObject> ingredients = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Manipulatable")
        {
            ingredients.Add(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Manipulatable")
        {
            ingredients.Remove(other.gameObject);
        }
    }



}
[System.Serializable]
public struct finalRecipie
{
    public string[] ingredients;
    public GameObject turnsInto;
}
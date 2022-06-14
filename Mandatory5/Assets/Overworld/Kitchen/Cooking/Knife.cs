using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public List<KnifeRecipie> recipies = new List<KnifeRecipie>();

    private void OnTriggerEnter(Collider other)
    {
        foreach (KnifeRecipie recipie in recipies)
        {
            if (other.name.Replace("(Clone)","") == recipie.name)
            {
                Vector3 pos = other.transform.position;
                Destroy(other.gameObject);
                Instantiate(recipie.turnsInto, pos, Quaternion.identity, null);
                return;
            }
        }
    }


}

[System.Serializable]
public struct KnifeRecipie
{
    public string name;
    public GameObject turnsInto;
}
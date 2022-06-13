using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanAndPot : MonoBehaviour
{
    public int heat = 0;

    public GameObject burntMess;

    public List<PanAndPotRecipie> recipies = new List<PanAndPotRecipie>();

    private void OnTriggerStay(Collider other)
    {
        foreach (PanAndPotRecipie recipie in recipies)
        {
            if (other.name.Replace("(Clone)", "") == recipie.name)
            {
                if (heat == recipie.heat)
                {
                    Vector3 pos = other.transform.position;
                    Destroy(other.gameObject);
                    Instantiate(recipie.turnsInto, pos, Quaternion.identity, null);
                }
                else if (heat > recipie.heat)
                {
                    Vector3 pos = other.transform.position;
                    Destroy(other.gameObject);
                    Instantiate(burntMess, pos, Quaternion.identity, null);
                }
                return;
            }
        }
    }

}
[System.Serializable]
public struct PanAndPotRecipie
{
    public string name;
    public GameObject turnsInto;
    [Range(1,3)]public int heat;
}
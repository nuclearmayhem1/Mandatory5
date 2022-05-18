using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPart : MonoBehaviour
{
    [SerializeField] private shipParts part;
    public void CollectPart()
    {
        AirshipUpgrades.CollectShipPart(part);
        Destroy(gameObject);
    }
}

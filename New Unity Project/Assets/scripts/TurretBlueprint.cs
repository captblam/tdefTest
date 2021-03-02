using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class TurretBlueprint
{
    UnitSpawn US;

    public GameObject prefab;
    public int cost;

    public GameObject upgradedPrefab;
    public int upgradeCost;

    public int GetSellAmount()
    {
        return cost / 2;
        /*if(US.isUpgraded != true)
        {
            return cost / 2;
        }
        else
        {
            return (cost / 2) + (upgradeCost / 2);
        }*/

    }
}

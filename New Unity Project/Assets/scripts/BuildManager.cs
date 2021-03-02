using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("more then one buildmanager in scene!");
            return;
        }
        instance = this;

        

    }

    public GameObject baseTurretPrefab;
    public GameObject anotherTurret;

    public shop_CS shop;

    private TurretBlueprint unitToBuild;
    private UnitSpawn selectedSpawn;
    

    public UnitUI_CS UnitUI;

    public bool CanBuild { get { return unitToBuild != null; } }
    public bool HasMoney { get { if (unitToBuild == null) unitToBuild = shop.baseTurret ; return PlayerStats_CS.Money >= unitToBuild.cost; } }
    
       

    public void SetUnitToBuild(TurretBlueprint turret)
    {
        unitToBuild = turret;
        selectedSpawn = null;

        DeselectSpawn();
    }    
    public void SelectNode(UnitSpawn spawn)
    {
        if(selectedSpawn == spawn)
        {
            DeselectSpawn();
            return;
        }
        selectedSpawn = spawn;
        unitToBuild = null;

        UnitUI.SetTarget(spawn);
    }
    public void DeselectSpawn()
    {
        selectedSpawn = null;
        UnitUI.Hide();
    }
    public TurretBlueprint getUnitToBuild()
    {
        return unitToBuild;
    }
    //make list to hold all turrets tht can expand if more r made
   /* public void BuildUnitOn(UnitSpawn spawn)
    {
        if (PlayerStats_CS.Money < unitToBuild.cost)
        {
            Debug.Log("not enough money");
            return;
        }
        PlayerStats_CS.Money -= unitToBuild.cost;
        GameObject turret = Instantiate(unitToBuild.prefab, spawn.GetBuildPos(), Quaternion.identity);
        spawn.unit = turret;
        Debug.Log("turret Built! " + PlayerStats_CS.Money + " left to use");
    }*/
}

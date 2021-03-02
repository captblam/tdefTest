using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UnitSpawn : MonoBehaviour
{
    
    
    BuildManager BM;

    //[HideInInspector]
    public GameObject unit;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;

    public Vector3 positionOffset;

    // Start is called before the first frame update
    void Start()
    {
        BM = BuildManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //need to make it place the unit where the mouse clicks not so we can have multiple 
    //turrets spawned in and need to have it check for overlap with other turret b4 spawning too
      private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (BM.CanBuild)
        {
            return;
        }
        if (BM.HasMoney)
        {
            
        }
        else
        {
            Debug.Log("Not Enough Money!");
        }
    }
    void BuildUnit(TurretBlueprint blueprint)
    {
        if (PlayerStats_CS.Money < blueprint.cost)
        {
            Debug.Log("not enough money");
            return;
        }
        PlayerStats_CS.Money -= blueprint.cost;
        turretBlueprint = blueprint;
        GameObject turret = Instantiate(blueprint.prefab, GetBuildPos(), Quaternion.identity);
        unit = turret;
        
        Debug.Log("turret Built! " + PlayerStats_CS.Money + " left to use");
    }
    public void UpgradeTurret()
    {
        if (PlayerStats_CS.Money < turretBlueprint.upgradeCost)
        {
            Debug.Log("not enough money");
            return;
        }
        PlayerStats_CS.Money -= turretBlueprint.upgradeCost;
        //get rid of old turret
        Destroy(unit);
        //build new one
        GameObject turret = Instantiate(turretBlueprint.upgradedPrefab, GetBuildPos(), Quaternion.identity);
        unit = turret;

        isUpgraded = true;

        Debug.Log("turret upgraded! ");
    }

    public void SellTurret()
    {
        PlayerStats_CS.Money += turretBlueprint.GetSellAmount();

        Destroy(unit);
        turretBlueprint = null;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
       
        if (unit != null) 
        {
            BM.SelectNode(this);
            //Debug.Log("cant build there! -display on screen");
            return;
        }
        if (!BM.CanBuild)
        {
            return;
        }
        BuildUnit(BM.getUnitToBuild());
    }
    public Vector3 GetBuildPos()
    {
        return transform.position + positionOffset;
    }
}

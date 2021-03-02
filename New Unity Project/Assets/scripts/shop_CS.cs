//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class shop_CS : MonoBehaviour
{
    public TurretBlueprint baseTurret;
    public TurretBlueprint sniperTurret;
    public TurretBlueprint bombTurret;

    BuildManager BM;
    private void Start()
    {
        BM = BuildManager.instance;
    }
    public void SelectBaseTurret()
    {
        BM.SetUnitToBuild(baseTurret);
    }
    public void SelectSniperTurret()
    {
        BM.SetUnitToBuild(sniperTurret);
    }
    public void SelectBombTurret()
    {
        BM.SetUnitToBuild(bombTurret);
    }

}

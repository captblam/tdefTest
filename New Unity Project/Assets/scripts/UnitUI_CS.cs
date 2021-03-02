using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitUI_CS : MonoBehaviour
{
    public GameObject UI;

    private UnitSpawn target;

    public Text upgradeCost;
    public Button upgradeButton;

    public Text sellAmount;

    private void Awake()
    {
        UI.SetActive(false);
    }
    public void SetTarget(UnitSpawn _target)
    {
        target = _target;

        transform.position = target.GetBuildPos();

        if (!target.isUpgraded)
        {
            upgradeCost.text = "$" + target.turretBlueprint.upgradeCost;
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "DONE";
            upgradeButton.interactable = false;
        }

        sellAmount.text = "$" + target.turretBlueprint.GetSellAmount();

        UI.SetActive(true);
    }

    public void Hide()
    {
        UI.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectSpawn();
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectSpawn();
        target.isUpgraded = false;
    }

}

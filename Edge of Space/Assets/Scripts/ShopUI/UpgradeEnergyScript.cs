﻿using UnityEngine;
using System.Collections;

public class UpgradeEnergyScript : UpgradeScript
{

    // Use this for initialization
    void Start()
    {
        inventory = player.GetComponent<Inventory>();
        descriptionScript = image.GetComponent<DescriptionScript>();
        level = 1;
        describtionText = "Increases the maximum amount of energy your ship has.";
        UpdateUpgradeInfo();
        UpdateDescription();
        UpdatePlayer();
    }

    public override void UpdateUpgradeInfo()
    {
        switch (level)
        {
            case 1:
                upgradeCost = 111;
                power = 100;
                break;

            case 2:
                upgradeCost = 222;
		        power = 175;
                break;

            case 3:
                upgradeCost = 333;
                power = 290;
                break;

            case 4:
                upgradeCost = 444;
                power = 400;
                break;

            case 5:
                upgradeCost = 555;
                power = 750;
                break;

            case 6:
                power = 750;
                upgradeable = false;
                button.SetActive(false);
                break;

            default:
                Debug.Log("Trying to upgrade Energy to a non exsisting level.");
                break;
        }
        image.fillAmount = (float)level / 6;
    }

    public override void UpdatePlayer()
    {
		inventory.baseEnergy = Mathf.RoundToInt(power);
		player.GetComponent<EnergyCore>().ResetPower();
    }

    public override void UpdateDescription()
    {
		descriptionScript.UpdateDescription(describtionText, upgradeCost, "Max Energy", Mathf.RoundToInt(power), level);
    }
}

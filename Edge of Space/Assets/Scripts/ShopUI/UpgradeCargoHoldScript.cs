using UnityEngine;
using System.Collections;

public class UpgradeCargoHoldScript : UpgradeScript
{

    // Use this for initialization
    void Start()
    {
        inventory = player.GetComponent<Inventory>();
        descriptionScript = image.GetComponent<DescriptionScript>();
        level = 1;
        describtionText = "Increases the amount of cargo your ship can carry.";
        UpdateUpgradeInfo();
        UpdateDescription();
        UpdatePlayer();
    }

    public override void UpdateUpgradeInfo()
    {
        switch (level)
        {
            case 1:
                upgradeCost = 100;
                power = 10;
                break;

            case 2:
                upgradeCost = 200;
                power = 20;
                break;

            case 3:
                upgradeCost = 300;
                power = 30;
                break;

            case 4:
                upgradeCost = 400;
                power = 40;
                break;

            case 5:
                upgradeCost = 500;
                power = 50;
                break;

            case 6:
                power = 60;
                upgradeable = false;
                button.SetActive(false);
                break;

            default:
                Debug.Log("Trying to upgrade Cargo Hold to a non exsisting level.");
                break;
        }
        image.fillAmount = (float)level / 6;
    }

    public override void UpdatePlayer()
    {
        inventory.baseCargoHoldSpace = Mathf.RoundToInt(power);
    }

    public override void UpdateDescription()
    {
        descriptionScript.UpdateDescription(describtionText, upgradeCost, "Cargo Space", Mathf.RoundToInt(power), level);
    }
}

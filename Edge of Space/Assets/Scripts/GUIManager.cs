using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour {

    public GameObject player;
    public Image energyBarImage;
    public Image cargoBarImage;
    public Text energyText;
    public Text cargoText;


    private Inventory inventory;
    private EnergyCore energyCore;



	// Use this for initialization
	void Start () 
    {
        inventory = player.GetComponent<Inventory>();
        energyCore = player.GetComponent<EnergyCore>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        energyBarImage.fillAmount = (float)(energyCore.GetEnergyLevel() / inventory.baseEnergy);
        energyText.text = energyCore.GetEnergyLevel() + "/" + inventory.baseEnergy;

        //totally waste of CPU power ftw
        cargoBarImage.fillAmount = (float)inventory.scrap / (float)inventory.baseCargoHoldSpace;
        cargoText.text = inventory.scrap + "/" + inventory.baseCargoHoldSpace;
	}





}

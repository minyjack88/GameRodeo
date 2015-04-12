using UnityEngine;
using System.Collections;

public class EnergyBoost : MonoBehaviour {

    public KeyCode activetKey;
    private float timer;

    Inventory inventory;
    EnergyCore energyCore;

	// Use this for initialization
	void Start () {
        inventory = this.gameObject.GetComponent<Inventory>();
        energyCore = this.gameObject.GetComponent<EnergyCore>();
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;

        if (inventory.energyConsumables > 0 && timer <= 0 && Input.GetKeyDown(activetKey))
        {
            inventory.energyConsumables--;
            timer = inventory.energyCooldown;
            energyCore.AddEnergy(inventory.energyConsumablePower);
        }
	}
}

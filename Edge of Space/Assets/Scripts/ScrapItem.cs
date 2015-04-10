using UnityEngine;
using System.Collections;

public class ScrapItem : PickupableItem
{

    public int size;
    public int baseScrapValue;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void PickupItem(Inventory inventory)
    {
        inventory.AddScrap((int)(baseScrapValue * size));
    }
}

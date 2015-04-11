using UnityEngine;
using System.Collections;
using System;

public class ScrapItem : PickupableItem
{
    [NonSerialized]
    public float size;
    public int baseScrapValue;

    void Awake()
    {
        size = UnityEngine.Random.Range(0.2f, 1);
        this.gameObject.transform.localScale *= size;
    }
	
    public override void PickupItem(Inventory inventory)
    {
        inventory.AddScrap((int)(baseScrapValue * size));
        GlobalSettings.SendMessage(MessageType.scrap);
    }
}

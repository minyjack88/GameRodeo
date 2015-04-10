using UnityEngine;
using System.Collections;

public class ArtifactItem : PickupableItem
{

    public ArtifactType artifactType;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void PickupItem(Inventory inventory)
    {
        inventory.AddArtifact(artifactType);
    }
}

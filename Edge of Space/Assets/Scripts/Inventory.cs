using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum ArtifactType {Blink, Battery, Overdrive}

[RequireComponent(typeof(CenterStats))]
public class Inventory : MonoBehaviour {

<<<<<<< .merge_file_a19280
=======
    public int baseCargoHoldSpace;
    public int baseEnergy;
    public int baseThrusterPower;

>>>>>>> .merge_file_a08972
    public int scrap = 0;
    public int money = 0;
    public List<ArtifactType> artifacts = new List<ArtifactType>();
    public int pickUpLayer;
    private CenterStats cs;
	
    // Use this for initialization
	void Start () 
    {
        cs = GetComponent<CenterStats>();
	}
	

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == pickUpLayer)
        {
            other.gameObject.GetComponent<PickupableItem>().PickupItem(this);
            cs.pullingObject.Remove(other.rigidbody);
            Destroy(other.gameObject);
        }

    }
    


    public void AddScrap(int amount)
    {
        scrap += amount;
    }

    public void AddArtifact(ArtifactType artifactType)
    {
        artifacts.Add(artifactType);
    }
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum ArtifactType {Blink, Battery, Overdrive}


public class Inventory : MonoBehaviour {

    public int scrap = 0;
    public int money = 0;
    public List<ArtifactType> artifacts = new List<ArtifactType>();
    public int pickUpLayer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    /*
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collison with something!");
        if (collision.gameObject.layer == pickUpLayer)
        {
            collision.gameObject.GetComponent<PickupableItem>().PickupItem(this);
            Debug.Log("THE RIGHT ONE!");
        }

    }
    */
    void OnTriggerEnter2D(Collider2D other)
    {
      //  Destroy(other.gameObject);
        Debug.Log("Collison with something!");
        if (other.gameObject.layer == pickUpLayer)
        {
            other.gameObject.GetComponent<PickupableItem>().PickupItem(this);
            Debug.Log("THE RIGHT ONE!");
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

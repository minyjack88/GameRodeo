using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour {

    [SerializeField]
    private GameObject player;

    private Inventory inventory;

    [SerializeField]
    private GameObject canvas;

    public int scrapValue = 1;


    [SerializeField]
    private Text BlinkArtifactText;
    [SerializeField]
    private Text BatteryArtifactText;
    [SerializeField]
    private Text OverdriveArtifactText;

    [SerializeField]
    private Image BlinkArtifactImage;
    [SerializeField]
    private Image BatteryArtifactImage;
    [SerializeField]
    private Image OverdriveArtifactImage;

    [SerializeField]
    private Text resourceText;


	// Use this for initialization
	void Start () 
    {
        inventory = player.GetComponent<Inventory>();
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision with the base.");
        SellCargo();
        

        GlobalSettings.TogglePause(true);
        canvas.SetActive(true);
    }

    public void ExitShop()
    {
        GlobalSettings.TogglePause(false);
        canvas.SetActive(false);
    }

    public void OnClickTest()
    {
        Debug.Log("Button is clicked!");
    }

    public void SellCargo()
    {
        inventory.money += inventory.scrap * scrapValue;
        inventory.scrap = 0;

        foreach (ArtifactType type in inventory.artifacts)
        {
            switch (type)
            {
                case ArtifactType.Blink:
                    BlinkArtifactText.text = "Enables you to warp space time, instantly teleporting to a different location.";
                    BlinkArtifactImage.color = Color.white;
                    //Enable consumeable Canvas
                    break;
                case ArtifactType.Battery:
                    BatteryArtifactText.text = "Unknown technology that allows the compression of energy into a miniscule object.";
                    BatteryArtifactImage.color = Color.white;
                    break;
                case ArtifactType.Overdrive:
                    OverdriveArtifactText.text = "Allows rapid acceleration boosts at the cost of extra fuel.";
                    OverdriveArtifactImage.color = Color.white;
                    break;
                default:
                    break;
            }
        }

        inventory.artifacts.Clear();

        resourceText.text = inventory.money.ToString();
    }
}

using UnityEngine;
using System.Collections;

public class PlayerTacS : CenterStats
{

    public KeyCode TracKey = KeyCode.Mouse0;
    public GameObject TracBeam;

    void Update()
    {
        if (Input.GetKeyDown(TracKey))
        {
            TracBeam.SetActive(true);
        }

        if (Input.GetKeyUp(TracKey))
        {
            TracBeam.SetActive(false);
            pullingObject.Clear();
        }
    }


}

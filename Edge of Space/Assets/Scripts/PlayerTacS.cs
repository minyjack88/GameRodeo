using UnityEngine;
using System.Collections;

public class PlayerTacS : CenterStats
{

    public KeyCode TracKey = KeyCode.Mouse0;
    public GameObject TracBeam;
    private CenterStats cs;

    void start()
    {
        cs = GetComponent<CenterStats>();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(TracKey))
        {
            TracBeam.SetActive(true);
        }

        if (Input.GetKeyUp(TracKey))
        {
            TracBeam.SetActive(false);
            cs.pullingObject.Clear();
        }
    }


}

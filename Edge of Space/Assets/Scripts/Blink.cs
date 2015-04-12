using UnityEngine;
using System.Collections;

public class Blink : MonoBehaviour 
{
    public KeyCode activetKey;
    public Camera cam;
    public ParticleSystem ps;
    private bool LastFramePlay = false;

    void Update()
    {
        if (Input.GetKeyDown(activetKey))
        {
            ps.Play();
        }

        if (LastFramePlay && !ps.isPlaying)
        {
            Vector3 pos = Input.mousePosition;
            pos.z = (cam.transform.position.z * -1) - transform.position.z;
            pos = cam.ScreenToWorldPoint(pos);
            transform.position = new Vector3(pos.x, pos.y, transform.position.z);
        }



        LastFramePlay = ps.isPlaying;

    }


}

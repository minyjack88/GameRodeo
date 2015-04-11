using UnityEngine;
using System.Collections;

public class Thruster : MonoBehaviour 
{
    public ParticleSystem ps;
    public KeyCode activate;

    void Update()
    {
        if (Input.GetKey(activate))
        {
            if (ps.isStopped)
                ps.Play();
        }
        else
        {
            if (ps.isPlaying)
                ps.Stop();
        }

    }

}

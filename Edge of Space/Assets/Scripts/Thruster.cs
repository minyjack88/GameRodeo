using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class Thruster : MonoBehaviour
{

	public ThrusterStruct[] MyThrusters;

    void Update()
    {

	    foreach (var thrusters in MyThrusters)
	    {
		    bool isActive = false;

		    foreach (var key in thrusters.ActivatorKeys)
		    {
			    if (Input.GetKey(key))
			    {
				    isActive = true;
			    }
		    }

		    foreach (var thruster in thrusters.Particles)
		    {
			    if (isActive)
			    {
					if(!thruster.isPlaying)
						thruster.Play();
					
			    }
				else
					thruster.Stop();
			}
	    }
    }
}
	[Serializable]
	public class ThrusterStruct
	{
		public List<KeyCode> ActivatorKeys;
		public List<ParticleSystem> Particles;

	}

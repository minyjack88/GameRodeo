using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
    
    public GameObject followtarget;
    public float maxDistance;
    public float followDitstance;
    public float followSpeed;


    void Update()
    {

        if(Distance2D(followtarget.transform.position,transform.position) >= followDitstance)
        { 
        
        }

        if (Distance2D(followtarget.transform.position, transform.position) >= followDitstance)
        {

        }
    }

    float Distance2D(Vector3 a, Vector3 b)
    {
        return Mathf.Sqrt(((b.x - a.x) * (b.x - a.x) + (b.y-a.y)*(b.y-a.y)));
    }
}

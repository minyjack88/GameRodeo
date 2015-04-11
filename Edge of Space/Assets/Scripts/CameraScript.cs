using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
    
    public GameObject followtarget;
    private PlayerTacS pt;
    public float maxDistance;
    public float followDitstance;
    public float followSpeed;
    public float speedModifier;
    public Vector3 cr;


    void Start()
    {
        pt = followtarget.GetComponent<PlayerTacS>();
    }

    void FixedUpdate()
    {
        float distance = Distance2D(followtarget.transform.position,transform.position);
        float step;

        Debug.Log(distance);

        if(distance >= followDitstance && distance < maxDistance)
        {
            float magSpeed = pt.Speed *((distance - followDitstance) / (maxDistance - followDitstance));

            if (magSpeed > followSpeed * Time.fixedDeltaTime)
                step = magSpeed;
            else
                step = followSpeed * Time.fixedDeltaTime;

            Vector3 movePos = Vector3.MoveTowards(transform.position, followtarget.transform.position, step * speedModifier);
            transform.position = new Vector3(movePos.x, movePos.y, transform.position.z);
           
        }

        if (Distance2D(followtarget.transform.position, transform.position) >= maxDistance)
        {
            Vector3 movePos = Vector3.MoveTowards(transform.position, followtarget.transform.position, pt.Speed * speedModifier);
            transform.position = new Vector3(movePos.x,movePos.y,transform.position.z);
        }
    }

    float Distance2D(Vector3 a, Vector3 b)
    {
        return Mathf.Sqrt(((b.x - a.x) * (b.x - a.x) + (b.y-a.y)*(b.y-a.y)));
    }
}

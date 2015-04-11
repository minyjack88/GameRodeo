using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
    
    [SerializeField] private GameObject _playerShip;
	[SerializeField] private int depth = 35;

	private bool flyToBase = false;

//    private PlayerTacS pt;
//    public float maxDistance;
//    public float followDistance;
//    public float followSpeed;
//    public float speedModifier;
//    public Vector3 cr;
	
	
//    void Start()
//    {
//        pt = followtarget.GetComponent<PlayerTacS>();
//    }



	void FixedUpdate()
	{
		Vector3 myPos = transform.position;
		Vector3 targetPos = _playerShip.transform.position;
		targetPos.z = -depth;
		transform.position = Vector3.Lerp(transform.position, targetPos, Time.fixedDeltaTime);
	}

//    void FixedUpdate()
//    {
//        float distance = Distance2D(followtarget.transform.position,transform.position);
//        float step;
//
//
//        if(distance >= followDistance && distance < maxDistance)
//        {
//            float magSpeed = pt.Speed *((distance - followDistance) / (maxDistance - followDistance));
//
//            if (magSpeed > followSpeed * Time.fixedDeltaTime)
//                step = magSpeed;
//            else
//                step = followSpeed * Time.fixedDeltaTime;
//
//            Vector3 movePos = Vector3.MoveTowards(transform.position, followtarget.transform.position, step * speedModifier);
//            transform.position = new Vector3(movePos.x, movePos.y, transform.position.z);
//           
//        }
//
//        if (Distance2D(followtarget.transform.position, transform.position) >= maxDistance)
//        {
//            Vector3 movePos = Vector3.MoveTowards(transform.position, followtarget.transform.position, pt.Speed * speedModifier);
//            transform.position = new Vector3(movePos.x,movePos.y,transform.position.z);
//        }
//    }

//    float Distance2D(Vector3 a, Vector3 b)
//    {
//        return Mathf.Sqrt(((b.x - a.x) * (b.x - a.x) + (b.y-a.y)*(b.y-a.y)));
//    }
}

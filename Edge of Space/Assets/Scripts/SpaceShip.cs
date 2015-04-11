using UnityEditor;
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class SpaceShip : MonoBehaviour
{
	private Rigidbody2D _myRigidbody2D;

	[SerializeField] private float _speed;
	public EnergyCore MyEnergyCore { get; private set; }
	private GameObject go;

	void Start()
	{
		go = GameObject.CreatePrimitive(PrimitiveType.Sphere);

		if (MyEnergyCore == null)
		{
			MyEnergyCore = gameObject.AddComponent<EnergyCore>();
		}
		_myRigidbody2D = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate ()
	{
		RotateToMouse();
		ApplyMovement();
	}

	void ApplyMovement()
	{
		Vector2 forceVector = Vector3.zero;
		if (Input.GetKey(KeyCode.LeftShift))
		{
			if (_myRigidbody2D.velocity.magnitude > 0.35f)
				forceVector = _myRigidbody2D.velocity*-1;
			else
				forceVector = _myRigidbody2D.velocity*-3;
		}
		else
		{
			if (Input.GetAxis("Vertical") > 0)
				forceVector += (Vector2)transform.right * 2 * _speed * Time.fixedDeltaTime;
			else if (Input.GetAxis("Vertical") < 0)
				forceVector -= (Vector2)transform.right*_speed*Time.fixedDeltaTime;
			forceVector -= (Vector2)transform.up * Input.GetAxis("Horizontal") * _speed * Time.fixedDeltaTime;
		}
		
		_myRigidbody2D.AddForce(forceVector);
	}

	[SerializeField] private Vector3 _mousPos;

	void RotateToMouse()
	{
		_mousPos = Input.mousePosition;
		_mousPos.z = 35;
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(_mousPos);

		var dir = mousePos - transform.position;
		var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}
}

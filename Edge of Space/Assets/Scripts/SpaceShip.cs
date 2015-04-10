using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class SpaceShip : MonoBehaviour
{
	private Rigidbody2D _myRigidbody2D;

	[SerializeField] private float _speed;

	void Start()
	{
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
			print(_myRigidbody2D.velocity.magnitude);
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
	
	void RotateToMouse()
	{
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousePos.z = 0;
		var dir = mousePos - transform.position;
		var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}
}

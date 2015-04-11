using UnityEngine;
using System.Collections;

public class BlackHole : Anomaly
{
	[SerializeField]
	private GameObject _playerGo;
	[SerializeField]
	private Rigidbody2D _playerRigid;

	private float _radius;

	void Start()
	{
		_radius = GetComponent<CircleCollider2D>().radius + 0.5f;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			_playerGo = other.gameObject;
			_playerRigid = other.GetComponent<Rigidbody2D>();
		}
	}

	void Update()
	{
		if (_playerGo != null)
		{
			var dist = Vector2.Distance(transform.position, _playerGo.transform.position);
			if (dist < _radius)
			{
				float f = dist - _radius;
				_playerRigid.AddForce((_playerGo.transform.position - transform.position) * f );
			}
		}
	}
}

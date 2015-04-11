using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class WorldController : MonoBehaviour
{
	private List<GameObject> _allGOs;
	private float _radius;
	[SerializeField] private float _rotationalForce = 10;

	private GameObject _playerGo;
	public GameObject PlayerGo
	{
		get { return _playerGo ?? (_playerGo = GameObject.FindWithTag("Player")); }
	}

	public void SetInitialInfo(float range, List<GameObject> allGOs )
	{
		_radius = range;
		_allGOs = allGOs;
	}

	void Update()
	{
		DamagePlayer();
	}

	void DamagePlayer()
	{
		float dist = Vector3.Distance(transform.position, PlayerGo.transform.position);
		if (dist < _radius)
		{
			_playerGo.GetComponent<SpaceShip>().MyEnergyCore.DoDamage(_radius - dist, Time.deltaTime); //TODO should this be more agressive?

			if (dist < 2)
			{
				PlayerReachedCenter();
			}
		}
	}

	void PlayerReachedCenter()
	{
		Application.LoadLevel("GameWon");
	}
	

	void FixedUpdate()
	{
		foreach (var go in _allGOs)
		{
			var goRigid = go.GetComponent<Rigidbody2D>();
			float goInitialDistance = go.GetComponent<SpawnableGO>().InitialDistance;
			
			var step1 = go.transform.position - transform.position;
			var step2 = new Vector2(step1.y, -step1.x);
			var c = (Vector2)(transform.position) + step2;
			
			var targetDirection = (Vector2)go.transform.position - c * 0.2f;

			float dist = Vector2.Distance(transform.position, go.transform.position);
//			targetDirection -= (Vector2)(go.transform.position - transform.position).normalized * (dist - goInitialDistance) * 10;

			targetDirection += CalcBouyancy(go, goInitialDistance, goRigid, dist);

			goRigid.AddForce(targetDirection);
		}

	}
	Vector2 CalcBouyancy (GameObject go, float floatLevel, Rigidbody2D goRigid, float dist) {
//		float waterLevel = 0.0f; //The actual height
		float floatHeight = 1.0f; //How "heavy" the object should be in the water
		float bounceDamp = 0.05f; //how rapidly it bounces
		
		Vector2 actionPoint = go.transform.position;
		Vector2 uplift;

		float forceFactor = (1f - (dist - floatLevel));
//		forceFactor = (1f - ((actionPoint.y - waterLevel) / floatHeight)) / bPoints.Length;

		if (forceFactor > 10f) {
			uplift = (transform.position - go.transform.position).normalized * (forceFactor - goRigid.velocity.magnitude * ((bounceDamp / 1) * Time.deltaTime));
			print("uplift : " + uplift + ", forcefactor : " + forceFactor);
			return uplift;
//			uplift = -Physics.gravity * (forceFactor - rigidbody.velocity.y * ((bounceDamp / bPoints.Length) * Time.deltaTime));
//			rigidbody.AddForceAtPosition(uplift, actionPoint, forceMode);
		}
		uplift = -(transform.position - go.transform.position).normalized * (forceFactor - goRigid.velocity.magnitude * ((bounceDamp / 1) * Time.deltaTime));
		return uplift;
	}
}

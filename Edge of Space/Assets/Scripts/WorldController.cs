using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class WorldController : MonoBehaviour
{
	private List<GameObject> _allGOs;
	private float _radius;
	[SerializeField] private float _rotationalForce = 10;
	[SerializeField] private float bounceDamp = 0.000005f; //how rapidly it bounces

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
			
			var targetDirection = (Vector2)go.transform.position - c * 0.02f;
//			var targetDirection = Vector2.zero;

			float dist = Vector2.Distance(transform.position, go.transform.position);
			
			targetDirection += CalcBouyancy(go, goInitialDistance, goRigid, dist, targetDirection);

			goRigid.AddForce(targetDirection);
		}

	}
	Vector2 CalcBouyancy (GameObject go, float preSetDistance, Rigidbody2D goRigid, float dist, Vector2 targetDirection) {
//		float floatHeight = 1.0f; //How "heavy" the object should be in the water
//		
//		Vector2 actionPoint = go.transform.position;
//		Vector2 uplift = Vector2.zero;
//		
		float forceFactor = (1f - (dist - preSetDistance));
////		forceFactor = (1f - ((actionPoint.y - waterLevel) / floatHeight)) / bPoints.Length;
//		
//		if (forceFactor < 1f)
//		{
//			forceFactor = preSetDistance - dist * -1;
//			
////			uplift = -((go.transform.position - transform.position).normalized * (forceFactor - goRigid.velocity.magnitude * ((bounceDamp / 10) * Time.fixedDeltaTime)));
//			float val = Mathf.Sqrt(dist - preSetDistance) / 2;
//			if (float.IsNaN(val))
//				val = 0;
//			uplift = -((go.transform.position - transform.position).normalized * ( forceFactor - goRigid.velocity.magnitude * (val)));
//		}

		Vector2 wantedPosition = (go.transform.position - transform.position).normalized * preSetDistance;
		Debug.DrawLine(go.transform.position, wantedPosition, Color.red);

		Vector2 wantedVector2 = (wantedPosition - (Vector2)go.transform.position);
//		Vector2 wantedForce = Vector2.Lerp(go.transform.position, wantedPosition, 0.5f);
		Debug.DrawRay(go.transform.position, wantedVector2, Color.green);
		
		Vector2 uplift = wantedVector2 * 100;
		
		
		
		//Instead, how about calculating my wanted point and then calculating a force based on a lerp?
		return uplift;
	}
}

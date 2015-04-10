using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class AnomalyController : MonoBehaviour
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
		float dist = Vector3.Distance(transform.position, PlayerGo.transform.position);
		if (dist < _radius)
		{
			_playerGo.GetComponent<SpaceShip>().MyEnergyCore.DoDamage(_radius - dist, Time.deltaTime); //TODO should this be more agressive
		}
	}

	void FixedUpdate()
	{
		

		
		foreach (var go in _allGOs)
		{
			var goRigid = go.GetComponent<Rigidbody2D>();
			
			

//			Vector3 relativePos = go.transform.position - transform.position;
//			Quaternion rotation = Quaternion.LookRotation(relativePos);
//			go.transform.rotation = rotation;
//			
//			var goRigid = go.GetComponent<Rigidbody2D>();
//			goRigid.AddForce(go.transform.up * _rotationalForce);
		}
	}
}

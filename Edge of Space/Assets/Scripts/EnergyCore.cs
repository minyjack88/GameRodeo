using System.Runtime.Serialization.Formatters;
using UnityEngine;
using System.Collections;

public class EnergyCore : MonoBehaviour
{
	[SerializeField]
	private float _energyLevel = 1;

	public void DoDamage(float damageAmount, float deltaTime)
	{
		_energyLevel -= damageAmount * deltaTime;
	}

	public float GetEnergyLevel()
	{
		return _energyLevel;
	}
}

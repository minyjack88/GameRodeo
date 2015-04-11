using UnityEngine;
using System.Collections;

public class SpawnableGO : MonoBehaviour
{
	[SerializeField] private int _rarity;
	public float InitialDistance { get; set; }

	public int GetRarity()
	{
		return _rarity;
	}
}

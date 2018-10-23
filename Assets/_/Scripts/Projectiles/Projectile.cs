using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	[SerializeField] protected int damage;

	protected virtual void OnTriggerEnter(Collider other)
	{
		
	}
}

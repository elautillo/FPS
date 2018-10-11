using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	[SerializeField] GameObject projectileSpawner;
	[SerializeField] GameObject newProjectile;
	[SerializeField] protected float attackSpeed = 1.5f;
	[SerializeField] int force = 1000;

	public void Shoot()
	{
		GameObject projectile = Instantiate(newProjectile, projectileSpawner.transform.position, projectileSpawner.transform.rotation);
		projectile.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * force);
	}
}

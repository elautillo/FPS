using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	[SerializeField] Transform projectileSpawner;
	[SerializeField] GameObject prefabProjectile;
	[SerializeField] protected float attackSpeed;
	float shotCadence;
	[SerializeField] protected int force;
	[SerializeField] protected int damage;

	protected virtual void Start()
	{
		shotCadence = attackSpeed;
	}

	public void Shoot()
	{
		shotCadence += Time.deltaTime;

		if (shotCadence >= attackSpeed)
		{
			shotCadence = 0;

			GameObject projectile = Instantiate(
				prefabProjectile,
				projectileSpawner.position,
				projectileSpawner.rotation);

			projectile.GetComponent<Rigidbody>().AddRelativeForce(
				Vector3.forward * force);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticEnemy : Enemy
{
	[Header("ATTACK")]
	[SerializeField] Transform projectileSpawner;
	[SerializeField] GameObject prefabProjectile;
	[SerializeField] float attackDistance = 15; 
	[SerializeField] float attackSpeed = 1;
	float shotCadence;
	[SerializeField] int force = 1000;

	protected override void Start()
	{
		base.Start();
		shotCadence = attackSpeed;
	}

	protected override void Update()
	{
		base.Update();

		transform.LookAt(player.transform.position);

		Vector3 distance = DetectPlayer();

		if (distance.sqrMagnitude < attackDistance * attackDistance)
		{
			Shoot();
		}
	}
	
	void Shoot()
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

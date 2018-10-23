using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticEnemy : Enemy
{
	[Header("ATTACK")]
	[SerializeField] Transform shootPoint;
	[SerializeField] Transform turningPoint;
	[SerializeField] GameObject prefabProjectile;
	[SerializeField] float attackDistance = 15; 
	[SerializeField] float attackSpeed = 2f;
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

		Vector3 target = new Vector3(
			player.transform.position.x,
			transform.position.y,
			player.transform.position.z);

		transform.LookAt(target);

		Vector3 distance = DetectPlayer();

		if (distance.sqrMagnitude < attackDistance * attackDistance)
		{
			TryShoot();
		}
	}
	
	void TryShoot()
	{
		shotCadence += Time.deltaTime;

		if (shotCadence >= attackSpeed)
        {
            shotCadence = 0;

            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject projectile = Instantiate(
            prefabProjectile,
            shootPoint.transform.position,
            shootPoint.transform.rotation);

        projectile.GetComponent<Rigidbody>().AddRelativeForce(
            Vector3.forward * force);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	[SerializeField] GameObject prefabProjectile;
	[SerializeField] protected float attackSpeed;
	float shotCadence;
	[SerializeField] protected int force;
	[SerializeField] protected int damage; //???????

	protected virtual void Start()
	{
		shotCadence = attackSpeed;
	}

	public void TryShoot()
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
            transform.position,
            transform.rotation);

        projectile.GetComponent<Rigidbody>().AddRelativeForce(
            Vector3.forward * force);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	[SerializeField] protected Transform shootPoint;
	[SerializeField] protected GameObject prefabProjectile;
	[SerializeField] protected float attackSpeed = 2f;
	float shotCadence;
	[SerializeField] protected int force;

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

    public virtual void Shoot(){}
}

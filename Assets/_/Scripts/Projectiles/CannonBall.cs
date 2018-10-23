using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : Projectile
{
	void Start()
	{
		damage = 2;
	}

	protected override void OnTriggerEnter(Collider other)
	{
		GameObject target = other.gameObject;

		if (target.tag == "Player")
		{
			target.GetComponent<Player>().GetDamage(damage);
		}

		Destroy(this.gameObject);
	}
}

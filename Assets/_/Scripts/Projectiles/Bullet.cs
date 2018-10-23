using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Projectile
{
	void Start()
	{
		damage = 1;
	}

	protected override void OnTriggerEnter(Collider other)
	{
		GameObject target = other.gameObject;

		if (target.tag == "Enemy")
		{
			target.GetComponent<Enemy>().GetDamage(damage);
		}
		else if (target.tag == "Boss")
		{
			target.GetComponent<Boss>().GetDamage(damage);
		}

		Destroy(this.gameObject);
	}
}

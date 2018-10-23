using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : Enemy
{
	[Header("MOVEMENT")]
	[SerializeField] protected int speed = 10;
	[SerializeField] protected int detectionRange;

	[Header("DAMAGE")]
	[SerializeField] protected int damage = 5;
	[SerializeField] protected bool exploded = false;

	protected override void Update()
	{
		base.Update();
	}

	protected virtual void Move(){}

	protected virtual void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.name == "Player" && !exploded)
		{
			collision.gameObject.GetComponent<Player>().GetDamage(damage);

			exploded = true;

			Debug.Log(damage);

			Die();
		}
	}
}

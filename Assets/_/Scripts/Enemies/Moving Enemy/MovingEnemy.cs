using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : Enemy
{
	[Header("MOVEMENT")]
	[SerializeField] protected int speed = 10;
	[SerializeField] protected Transform[] target;
	[SerializeField] protected int detectionRange;

	protected int current;
	protected int counter = 1;
	protected bool active = false;

	[Header("DAMAGE")]
	[SerializeField] protected int damage = 5;

	protected override void Start()
	{
		base.Start();
	}

	protected override void Update(){}

	protected virtual void Move(){}

	protected virtual void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.name == "Player")
		{
			collision.gameObject.GetComponent<Player>().GetDamage(damage);

			Die();
		}
	}
}

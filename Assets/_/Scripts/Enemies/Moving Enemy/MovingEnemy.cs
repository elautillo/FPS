using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : Enemy
{
	[Header("MOVEMENT")]
	[SerializeField] protected int speed = 10;
	[SerializeField] protected int rotationStart = 1;
	[SerializeField] protected int rotationCadence = 1;

	[Header("DAMAGE")]
	[SerializeField] protected int damage = 3;

	protected override void Start()
	{
		base.Start();

		InvokeRepeating("RandomRotation", rotationStart, rotationCadence);
	}

	protected override void Update()
	{
		base.Update();

		Move();
	}

	protected void Move()
	{
		if (alive)
		{
			transform.Translate(Vector3.forward * speed * Time.deltaTime);
		}
	}

	protected void Rotation()
	{
		transform.Rotate(0, 180f, 0);
	}

	protected void RandomRotation()
    {
        float rotation = Random.Range(0f, 360f);
        transform.eulerAngles = new Vector3(0, rotation, 0);
    }

	void OnCollisionEnter(Collision collision)
    {
		Rotation();

		if (collision.gameObject.name == "Player")
		{
			collision.gameObject.GetComponent<Player>().GetDamage(damage);

			Die();
		}
    }
}

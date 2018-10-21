using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : Enemy
{
	[Header("MOVEMENT")]
	[SerializeField] protected int speed = 10;
	[SerializeField] protected Transform[] target;
	protected int current;
	protected int counter = 1;

	//[SerializeField] protected int rotationStart = 1;
	//[SerializeField] protected int rotationCadence = 1;

	[Header("DAMAGE")]
	[SerializeField] protected int damage = 5;

	protected override void Start()
	{
		base.Start();

		//InvokeRepeating("RandomRotation", rotationStart, rotationCadence);
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
			if (transform.position != target[current].position)
			{
				Vector3 direction = Vector3.MoveTowards(
					transform.position,
					target[current].position,
					speed * Time.deltaTime);

				GetComponent<Rigidbody>().MovePosition(direction);
			}
			else
			{
				//current = (current + 1) % target.Length;
				current += counter;

				if (current == target.Length - 1)
				{
					counter = (-1);
				}

				if (current == 0)
				{
					counter = 1;
				}
			}
		}
	}

	/* protected void Rotation()
	{
		transform.Rotate(0, 90f, 0);
	}

	protected void RandomRotation()
    {
        float rotation = Random.Range(0f, 360f);
        transform.eulerAngles = new Vector3(0, rotation, 0);
    }*/

	void OnCollisionEnter(Collision collision)
    {
		//Rotation();

		/*if (collision.gameObject.tag == "Wall")
		{
			direction.Rotate(0, 90, 0);
		}*/

		if (collision.gameObject.name == "Player")
		{
			collision.gameObject.GetComponent<Player>().GetDamage(damage);

			Die();
		}
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SillyEnemy : MovingEnemy
{	
	protected override void Start()
	{
		GetComponentInChildren<TextMesh>().GetComponent<Renderer>().enabled = false;
	}
	
	protected override void Update()
	{
		base.Update();

		Vector3 distance = DetectPlayer();

		if (!active && distance.sqrMagnitude < detectionRange * detectionRange)
		{
			active = true;

			GetComponentInChildren<TextMesh>().GetComponent<Renderer>().enabled = true;
		}

		if (active)
		{
			Move();
		}
	}

	protected override void Move()
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
}

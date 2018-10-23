using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartEnemy : MovingEnemy
{
	[SerializeField] protected int rotationStart = 1;
	[SerializeField] protected int rotationCadence = 1;

	void Start()
	{
		InvokeRepeating("RandomRotation", rotationStart, rotationCadence);
	}

	protected override void Update()
	{
		base.Update();

		Move();

		Vector3 distance = DetectPlayer();

		if (distance.sqrMagnitude < (detectionRange * detectionRange) / 2)
		{
			this.transform.LookAt(player.transform.position);
		}
	}

	protected override void Move()
	{
		transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}

	protected void Rotation()
	{
		transform.Rotate(0, 90f, 0);
	}

	protected void RandomRotation()
    {
        float rotation = Random.Range(0f, 360f);
        transform.eulerAngles = new Vector3(0, rotation, 0);
    }

	protected override void OnCollisionEnter(Collision collision)
	{
		base.OnCollisionEnter(collision);

		Rotation();
	}
}

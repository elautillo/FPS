using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : Projectile
{
	protected override void Start()
	{
		damage = 3;

		base.Start();
	}
	
	void Update()
	{
		
	}

	protected override void OnTriggerEnter(Collider other, string tag)
	{
		tag = "Player";

		base.OnTriggerEnter(other, tag);
	}
}

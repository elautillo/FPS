using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Projectile
{
	protected override void Start()
	{
		damage = 2;

		base.Start();
	}
	
	void Update()
	{
		
	}

	protected override void OnTriggerEnter(Collider other, string target)
	{
		tag = "Enemy";
		
		base.OnTriggerEnter(other, tag);
	}
}

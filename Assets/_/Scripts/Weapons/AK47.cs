using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK47 : Weapon
{

	protected override void Start()
	{
		base.Start();

		attackSpeed = 0.5f;
		force = 2000;
		damage = 1; // ???????
	}
}

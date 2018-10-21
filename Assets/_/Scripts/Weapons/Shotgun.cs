using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
	protected override void Start()
	{
		base.Start();

		attackSpeed = 1.5f;
		force = 1000;
		//damage = 4;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
	public override void Shoot()
    {
        GameObject bullet = Instantiate(
				prefabProjectile,
				transform.position,
				transform.rotation);

        bullet.GetComponent<Rigidbody>().AddRelativeForce(
            Vector3.forward * force);
    }
}

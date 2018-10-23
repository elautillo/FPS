using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crossbow : Weapon
{
	public GameObject staticArrow;
	GameObject arrow;

	public override void Shoot()
    {
		if (staticArrow.activeSelf)
		{
			arrow = Instantiate(
				prefabProjectile,
				shootPoint.transform.position,
				shootPoint.transform.rotation);
			
			arrow.transform.Rotate(0, 90, 0);

			staticArrow.SetActive(false);
		}
		
        arrow.GetComponent<Rigidbody>().AddRelativeForce(
            Vector3.left * force);
    }
}

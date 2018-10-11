using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	void Start()
	{
		
	}
	
	void Update()
	{
		
	}

	void OnTriggerEnter(Collider other)
	{
		GameObject target = other.gameObject;

		if (target.tag == "Enemy")
		{
			target.GetComponent<Enemy>().GetDamage(2);
		}
		
		Destroy(this.gameObject);
	}
}

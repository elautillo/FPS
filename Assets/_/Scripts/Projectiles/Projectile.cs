using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	protected int damage;

	protected virtual void Start()
	{
		//Invoke("Destroy", 2);
	}
	
	void Update()
	{
		
	}

	protected virtual void OnTriggerEnter(Collider other, string tag)
	{
		GameObject target = other.gameObject;

		if (target.tag == tag)
		{
			target.GetComponent(tag).GetDamage(damage);
		}

		Destroy();
	}

	void Destroy()
	{
		Destroy(this.gameObject);
	}
}

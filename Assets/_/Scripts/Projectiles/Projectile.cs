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

	protected virtual void OnTriggerEnter(Collider other)
	{
		GameObject target = other.gameObject;

		if (target.tag == "Enemy")
		{
			target.GetComponent<Enemy>().GetDamage(damage);
		}

		if (target.tag == "Player")
		{
			target.GetComponent<Player>().GetDamage(damage);
		}

		Destroy();
	}

	void Destroy()
	{
		Destroy(this.gameObject);
	}
}

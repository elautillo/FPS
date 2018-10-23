using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : Projectile
{
	void Start()
	{
		damage = 5;
	}

	protected override void OnTriggerEnter(Collider other)
    {
        GameObject target = other.gameObject;

		if (target.tag == "Enemy")
		{
			target.GetComponent<Enemy>().GetDamage(damage);

			Destroy();
		}
        else if (target.tag == "Boss")
		{
			target.GetComponent<Boss>().GetDamage(damage);

			Destroy();
		}
		else if (target.tag == "Wall")
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = true;

			Invoke("Destroy", 20);
        }
		else
		{
			Destroy();
        }
    }

    private void Destroy()
    {
		GameObject.Find("Player").GetComponent<Player>().Recharge();

        Destroy(this.gameObject);
    }
}

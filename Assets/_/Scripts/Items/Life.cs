using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
	int rotation = 0;
	[SerializeField] int speed = 1;

	void Start()
	{
		
	}
	
	void Update()
	{
		rotation += speed;
		transform.rotation = Quaternion.Euler(new Vector3(0, rotation, 0));
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.name == "Player")
		{
			collision.gameObject.GetComponent<Player>().Heal();
			collision.gameObject.GetComponent<Player>().Heal();
			collision.gameObject.GetComponent<Player>().Heal();

			Destroy(this.gameObject);
		}
	}
}

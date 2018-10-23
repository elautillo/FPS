using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
	int rotation = 0;
	[SerializeField] int speed = 1;
	
	void Update()
	{
		rotation += speed;
		transform.rotation = Quaternion.Euler(new Vector3(0, rotation, 0));
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			other.gameObject.GetComponent<Player>().Heal();
			other.gameObject.GetComponent<Player>().Heal();
			other.gameObject.GetComponent<Player>().Heal();
			
			Destroy(this.gameObject);
		}
	}
}

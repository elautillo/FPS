using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
	[Header("STATE")]
	[SerializeField] int health = 100;
	bool active = false;

	[Header("MOVEMENT")]
	[SerializeField] int speed = 4;
	[SerializeField] int detectionRange = 10;

	[Header("DAMAGE")]
	[SerializeField] int damage = 1;

	[Header("FX")]
	[SerializeField] ParticleSystem particles;

	[Header("REFERENCES")]
	GameObject player;

	void Awake()
	{
		player = GameObject.Find("Player");
	}

	void Start()
	{
		GetComponentInChildren<TextMesh>().GetComponent<Renderer>().enabled = false;
	}
	
	void Update()
	{
		GetComponentInChildren<TextMesh>().text = health.ToString();

		GetComponentInChildren<TextMesh>().transform.LookAt(
			transform.position - DetectPlayer());

		if (DetectPlayer().sqrMagnitude < detectionRange * detectionRange){

			if (!active)
			{
				active = true;

				//GameObject.Find("Door").gameObject.SetActive(true);

				GetComponentInChildren<TextMesh>().GetComponent<Renderer>().enabled = true;
			}
			else if (!(DetectPlayer().sqrMagnitude < (detectionRange * detectionRange) / 3))
			{
				Move();
			}
			else
			{
				//Attack();

				Invoke("Move", 1);
			}
		}
	}

	Vector3 DetectPlayer()
	{
		Vector3 distance = player.transform.position - transform.position;

		return distance;
	}

	void Move()
	{
		this.transform.LookAt(player.transform.position);

		transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}

	// void Attack()
	// {
	// 	GameObject.Find("Blade").transform.Rotate(0, 4 * Time.deltaTime, 0);
	// }

	public void GetDamage(int damage)
	{
		health = health - damage;

		if (health <= 0)
		{
			Die();
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.name == "Player")
		{
			collision.gameObject.GetComponent<Player>().GetDamage(damage);

			Debug.Log(damage);
		}
	}

	void Die()
	{
		GetComponentInChildren<TextMesh>().text = "";

		this.gameObject.GetComponent<Renderer>().enabled = false;

    	ParticleSystem explosion = Instantiate(particles, transform.position, Quaternion.identity);

        explosion.Play();

		GameObject.Find("MainText").GetComponent<TextMesh>().text = "VICTORY";

		Invoke("Destroy", 0.5f);
	}

	void Destroy()
	{
		Destroy(this.gameObject);
	}
}

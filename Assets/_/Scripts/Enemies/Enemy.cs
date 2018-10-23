using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[Header("STATE")]
	[SerializeField] protected int health = 10;

	[Header("FX")]
	[SerializeField] protected ParticleSystem particles;

	[Header("REFERENCES")]
	protected GameObject player;

	protected void Awake()
	{
		player = GameObject.Find("Player");
	}

	protected virtual void Update()
	{
		GetComponentInChildren<TextMesh>().text = health.ToString();

		GetComponentInChildren<TextMesh>().transform.LookAt(
			transform.position - DetectPlayer());
	}

	protected Vector3 DetectPlayer()
	{
		Vector3 distance = player.transform.position - transform.position;

		return distance;
	}

	public void GetDamage(int damage)
	{
		health = health - damage;

		if (health <= 0)
		{
			Die();
		}
	}

	protected void Die()
	{
		GetComponentInChildren<TextMesh>().text = "";

		this.gameObject.GetComponent<Renderer>().enabled = false;

    	ParticleSystem explosion = Instantiate(particles, transform.position, Quaternion.identity);

        explosion.Play();

		if (GameObject.FindGameObjectsWithTag("Enemy") == null)
		{
			GameObject.Find("Door").gameObject.SetActive(false);
		}

		Invoke("Destroy", 0.5f);
	}

	void Destroy()
	{
		Destroy(this.gameObject);
	}
}

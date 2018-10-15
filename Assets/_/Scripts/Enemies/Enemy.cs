using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	[Header("STATE")]
	[SerializeField] protected bool alive = true;
	[SerializeField] protected int health = 10;
	[SerializeField] protected int maxHealth = 10;
	[SerializeField] protected TextMesh prefabHealthText;
	protected TextMesh healthText;
	[SerializeField] protected ParticleSystem explosion;

	[Header("REFERENCES")]
	protected GameObject player;

	protected void Awake()
	{
		player = GameObject.Find("Player");
	}

	protected virtual void Start()
	{
		healthText = Instantiate(prefabHealthText);
	}

	protected virtual void Update()
	{
		healthText.GetComponent<TextMesh>().text = health.ToString();
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
			health = 0;
			Die();
		}

		Debug.Log(health);
	}

	protected void Die()
	{
		alive = false;

		Instantiate(explosion, transform.position, Quaternion.identity);
		explosion.Play();

		Destroy(this.gameObject);
	}
}

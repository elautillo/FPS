using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	[Header("STATE")]
	[SerializeField] protected bool alive = true;
	[SerializeField] protected int health = 10;
	//[SerializeField] int maxHealth;
	[SerializeField] TextMesh healthText;
	TextMesh healthObject;

	[Header("ATTACK")]
	//int speed;
	[SerializeField] protected int detectionDistance = 5;
	//int explosionDistance;
	[SerializeField] protected int damage = 2;

	[Header("FX")]
	[SerializeField] protected ParticleSystem explosion;

	[Header("REFERENCES")]
	[SerializeField] Transform player;

	protected virtual void Start()
	{
		TextMesh healthObject = Instantiate(healthText);
	}

	protected virtual void Update()
	{
		healthObject.GetComponent<TextMesh>().text = health.ToString();
	}

	protected int DetectPlayer()
	{
		return 0;
	}

	protected void Attack()
	{
		
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

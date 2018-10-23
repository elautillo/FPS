using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	[Header("STATE")]
	[SerializeField] int health = 20;
	[SerializeField] int maxHealth = 20;
	[SerializeField] int heal = 1;

	[Header("WEAPONS")]
	const int NUM_WEAPONS = 2;
	[SerializeField] int activeWeapon = 0;
	[SerializeField] Weapon[] weapons = new Weapon[NUM_WEAPONS];

	[Header("FX")]
	ParticleSystem blood;

	void Start()
    {
        ActivateWeapon();

		blood = GetComponentInChildren<ParticleSystem>();

		InvokeRepeating("Heal", 0, 5);
    }

    void Update()
	{
		GetComponentInChildren<TextMesh>().text = health.ToString();

		ChangeWeapon();
		Attack();
	}

    void ActivateWeapon()
    {
        DeactivateWeapons();
        weapons[activeWeapon].gameObject.SetActive(true);
    }

    void DeactivateWeapons()
    {
        foreach (var weapon in weapons)
        {
            weapon.gameObject.SetActive(false);
        }
    }

	void ChangeWeapon()
	{
		if (Input.GetKeyDown(KeyCode.E) && activeWeapon < NUM_WEAPONS - 1)
        {
			activeWeapon++;
            ActivateWeapon();
        }

        if (Input.GetKeyDown(KeyCode.Q) && activeWeapon > 0)
		{
			activeWeapon--;
			ActivateWeapon();
		}
	}

	void Attack()
	{
		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			weapons[activeWeapon].Shoot();
		}
	}

	public void Recharge()
	{
		if (activeWeapon == 0)
		{
			AudioSource[] audio = GetComponents<AudioSource>();

			audio[1].Play();

			GetComponentInChildren<Crossbow>().staticArrow.SetActive(true);
		}
		else
		{
			Debug.Log("Crossbow unactive.");
		}
	}

	public void Heal()
	{
		health += heal;

		if (health > maxHealth) health = maxHealth;
	}

	public void GetDamage(int damage)
	{
		health = health - damage;

		blood.Play();

		if (health <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		GameObject.Find("MainText").GetComponent<TextMesh>().text = "GAME OVER";

		Invoke("Restart", 2);
	}

	private void Restart()
    {
        SceneManager.LoadScene(0);
    }
}

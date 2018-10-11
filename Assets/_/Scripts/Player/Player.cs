using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
	const int NUM_WEAPONS = 2;

	[SerializeField] int activeWeapon = 0;

	[Header("STATE")]
	[SerializeField] bool alive = true;
	[SerializeField] int health = 20;
	[SerializeField] int maxHealth = 20;
	[SerializeField] int heal = 1;
	[SerializeField] TextMesh healthText;

	[Header("WEAPONS")]
	[SerializeField] Weapon[] weapons = new Weapon[NUM_WEAPONS];

	void Start()
    {
        ActivateWeapon(activeWeapon);
		InvokeRepeating("Heal", 0, 5);
    }

    void Update()
	{
		TextMesh healthObject = Instantiate(healthText);
		healthObject.text = health.ToString();

		ChangeWeapon();
		Attack();
	}

    void ActivateWeapon(int index)
    {
        DeactivateWeapons();
		activeWeapon = index;
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
            ActivateWeapon(activeWeapon + 1);
        }

        if (Input.GetKeyDown(KeyCode.Q) && activeWeapon > 0)
		{
			ActivateWeapon(activeWeapon - 1);
		}
	}

	void Attack()
	{
		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			weapons[activeWeapon].Shoot();
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

		if (health <= 0)
		{
			health = 0;
			Die();
		}

		Debug.Log(health);
	}

	void Die()
	{
		
	}
}

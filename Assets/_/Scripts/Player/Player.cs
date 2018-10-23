using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	[Header("STATE")]
	bool alive = true;
	[SerializeField] int health = 20;
	[SerializeField] int maxHealth = 20;
	[SerializeField] int heal = 1;

	[Header("WEAPONS")]
	const int NUM_WEAPONS = 2;
	[SerializeField] int activeWeapon = 0;
	[SerializeField] Weapon[] weapons = new Weapon[NUM_WEAPONS];

	void Start()
    {
        ActivateWeapon();
		InvokeRepeating("Heal", 0, 5);
    }

    void Update()
	{
		if (alive) GetComponentInChildren<TextMesh>().text = health.ToString();

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
		GetComponentInChildren<Crossbow>().staticArrow.SetActive(true);
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
			Die();
		}
	}

	void Die()
	{
		alive = false;

		GetComponentInChildren<TextMesh>().text = "GAME OVER";

		Invoke("Restart", 2);
	}

	private void Restart()
    {
        SceneManager.LoadScene(0);
    }
}

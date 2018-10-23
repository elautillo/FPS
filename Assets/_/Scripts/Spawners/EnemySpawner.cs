using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	bool active = false;
	int numEnemies = 0;
	GameObject turret;
	[SerializeField] int spawningRatio = 15;
	[SerializeField] int maxEnemies = 15;
	[SerializeField] GameObject newEnemy;

	void Awake()
	{
		turret = GameObject.Find("Turret");
	}
	
	void Update()
	{
		if (!active && turret == null)
		{
			active = true;

			InvokeRepeating("CreateEnemy", 0, spawningRatio);
		}
	}

	void CreateEnemy()
	{
		Instantiate(newEnemy, transform.position, Quaternion.identity);

		numEnemies++;

		if (numEnemies == maxEnemies)
		{
			CancelInvoke();
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	int numEnemies = 0;
	[SerializeField] int maxEnemies = 15; 
	[SerializeField] GameObject newEnemy;

	void Start()
	{
		InvokeRepeating("CreateEnemy", 0, 5);
	}
	
	void Update()
	{
		
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

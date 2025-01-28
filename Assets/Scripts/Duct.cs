using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duct : MonoBehaviour
{
	public GameObject prefabToSpawn;
	public float spawnInterval;

	float timer;

	void LateUpdate()
	{
		timer += Time.deltaTime;

		var enemies = Game.instance.flyingEnemies;

		var count = 0;
		foreach(var enemy in enemies)
		{
			if(!enemy.enabled)
				count++;
		}

		var finalInterval = spawnInterval;
		if(count > 0)
		{
			finalInterval = spawnInterval - 0.5f * count;
		}


		if(timer > finalInterval)
		{
			timer %= finalInterval;
			var spawnGO = GameObject.Instantiate(prefabToSpawn, transform.parent);
			spawnGO.transform.position = transform.position;
		}
	}
}

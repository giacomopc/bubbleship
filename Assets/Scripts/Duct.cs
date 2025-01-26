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

		if(timer > spawnInterval)
		{
			timer %= spawnInterval;
			var spawnGO = GameObject.Instantiate(prefabToSpawn, transform.parent);
			spawnGO.transform.position = transform.position;
		}
	}
}

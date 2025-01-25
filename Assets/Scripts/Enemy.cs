using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public float speed;

	void Awake()
	{
		const float variance = 2f;
		speed = Random.Range(speed - variance, speed + variance);
	}
	
	void Update()
	{
		var player = Player.instance;

		var position = transform.position;
		var playerPosition = player.transform.position;

		var direction = playerPosition - position;
		direction = direction.normalized;
		var movement = direction * speed * Time.deltaTime;
		transform.position += movement;
	}
}

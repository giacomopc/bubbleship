using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public const float MinHealth = 0f;

	public float speed;
	public float maxHealth = 2f;
	public float health;

	void Awake()
	{
		const float variance = 2f;
		speed = Random.Range(speed - variance, speed + variance);
		health = maxHealth;
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

	void OnDamage(float damage)
	{
		health = Mathf.Max(MinHealth, health - damage);

		if(health == MinHealth)
		{
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		// print($"{gameObject.name} aaaa");

		if(collider.GetComponent<Attack>() != null)
			OnDamage(2f);
		else if(collider.GetComponent<Player>() != null)
			Player.instance.OnDamage(1f);
	}
}

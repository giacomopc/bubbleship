using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;



public class Enemy : MonoBehaviour
{
	public AudioClip deathclip;
	public const float MinHealth = 0f;

	public SpriteRenderer spriteRenderer;

	public float speed;
	float maxHealth = 2f;
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

		spriteRenderer.color = Color.red;
		spriteRenderer.DOColor(Color.white, 0.4f);

		if(health == MinHealth)
		{
			spriteRenderer.DOKill();
			sfxaudiosource.playclip(deathclip);
			Destroy(gameObject);
		}
		
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		// print($"{gameObject.name} aaaa");

		if(collider.GetComponent<Attack>() != null)
			OnDamage(1f);
		else if(collider.GetComponent<Player>() != null)
			Player.instance.OnDamage(1f);
	}
}

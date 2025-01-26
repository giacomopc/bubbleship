using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
	public SpriteRenderer spriteRenderer;

	bool illuminated;

	void Update()
	{
		if(illuminated)
		{
			transform.localScale -= Vector3.one * 0.1f * Time.deltaTime;

			if(transform.localScale.magnitude < 0.4)
			{
				spriteRenderer.enabled = false;
				Destroy(gameObject);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		print($"HERE {other.gameObject.name}");
		spriteRenderer.color = Color.red;
		illuminated = true;
	}

	void OnTriggerExit2D(Collider2D other)
	{
		print($"HERE2 {other.gameObject.name}");

		spriteRenderer.color = Color.white;
		illuminated = false;
		
	}

}

using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
	public static Player instance;

	[Header("Unity Objects")]
	public GameObject attackPrefab;
	public new Camera camera;
	public SpriteRenderer sprite;
	public Sprite idleSprite;
	public Sprite[] walkSprites;
	public HealthBar healthBar;
	public HealthBar battery;
	new public SpriteRenderer light;
	public SpriteMask lightMask;

	[Header("Unity Audio")]
	public AudioClip attackclip;
	public Collider2D lightCollider;

	[Header("Tweakables")]
	public float speed;
	public float playerRadius = 5f;
	public float fpsWalk = 3f;

	// private
	Vector2 direction = Vector2.right;
	bool moving;
	float movingTime;
	float invincibleTime;
	bool flashlightOn;

	bool invincible => invincibleTime > 0;

	void Awake()
	{
		instance = this;
	}

	void Update()
	{
		// attack
		var angle = Vector2.SignedAngle(Vector2.right, direction);

		if(Input.attack)
		{
			sfxaudiosource.playclip(attackclip);
			var attackGO = GameObject.Instantiate(attackPrefab, null);
			var attackTransform = attackGO.transform;
			
			print($"direction {direction} angle {angle}");
			attackTransform.position = Player.instance.transform.position + playerRadius * new Vector3(direction.x, direction.y, 0f);
			attackTransform.eulerAngles = Vector3.forward * angle;

			print("attack");
		}

		// flashlight
		{
			if(Input.flashlight)
			{
				if(battery.health > 0f)
					flashlightOn = !flashlightOn;
			}

			if(flashlightOn)
			{
				battery.OnDamage(Time.deltaTime / 2f);
				if(battery.health == 0f)
					flashlightOn = false;
			}
			else
			{
				battery.OnDamage(-Time.deltaTime / 2f);
			}

			light.enabled = flashlightOn;
			lightMask.enabled = flashlightOn;
			lightCollider.enabled = flashlightOn;
			
			var newAngle = Mathf.LerpAngle(light.transform.eulerAngles.z, angle, 0.15f);
			light.transform.eulerAngles = Vector3.forward * newAngle;
		}
	}

	void FixedUpdate()
	{
		// movement
		{
			var horizontal = Input.right ? Vector2.right : Input.left ? Vector2.left : Vector2.zero;
			var vertical = Input.up ? Vector2.up : Input.down ? Vector2.down : Vector2.zero;
			var direction = (horizontal + vertical).normalized;

			var movingBefore = moving;
			moving = (direction != Vector2.zero);
			
			if(moving && !movingBefore)
			{
				movingTime = 0f;
			}
			
			if(moving)
			{	
				this.direction = direction;
				var movement3 = new Vector3(direction.x, direction.y, 0f); 
				transform.localPosition = transform.localPosition + movement3 * speed * Time.deltaTime;

			}
		}
	}

	void LateUpdate()
	{
		// animation
		{
			if(moving)
			{
				movingTime += Time.deltaTime;
				var spriteIndex = Mathf.FloorToInt((movingTime * fpsWalk) % walkSprites.Length);
				sprite.sprite = walkSprites[spriteIndex];
			}
			else
			{
				sprite.sprite = idleSprite;
			}
		}

		if(invincible)
		{
			invincibleTime -= Time.deltaTime;
			sprite.color = invincibleTime % 0.5f < 0.25f ? Color.white : Color.clear;
		}
		else
		{
			sprite.color = Color.white;
		}
	}

	public void OnDamage(float damage)
	{
		if(Game.win)
			return;

		if(invincible)
			return;

		print("invincibleTime: " + invincibleTime);

		healthBar.OnDamage(damage);	
		invincibleTime = 2f;
	}

	public void OnCollider2D(Collider2D other)
	{
		print("choke!");
	}

}

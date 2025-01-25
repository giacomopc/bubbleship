using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class Player : MonoBehaviour
{
	public static Player instance;

	public SpriteRenderer sprite;
	public float speed;
	public Camera camera;
	public float playerRadius = 5f;
	public GameObject attackPrefab;

	public float fpsWalk = 3f;
	public Sprite idleSprite;
	public Sprite[] walkSprites;
	
	Vector2 direction = Vector2.right;
	bool moving = false;
	float movingTime = 0f;

	void Awake()
	{
		instance = this;
	}

	void Update()
	{
		// attack
		if(Input.attack)
		{
			var attackGO = GameObject.Instantiate(attackPrefab, null);
			var attackTransform = attackGO.transform;
			
			var angle = Vector2.SignedAngle(Vector2.right, direction);
			print($"direction {direction} angle {angle}");
			attackTransform.position = Player.instance.transform.position + playerRadius * new Vector3(direction.x, direction.y, 0f);
			attackTransform.eulerAngles = Vector3.forward * angle;

			print("attack");
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
	}

}

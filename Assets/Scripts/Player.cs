using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class Player : MonoBehaviour
{
	public static Player instance;

	public SpriteRenderer sprite;
	public float speed;
	public Camera camera;
	


	public GameObject attackPrefab;
	
	Vector3 direction;

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
			attackTransform.position = Player.instance.transform.position;
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
			direction = (horizontal + vertical).normalized;
			var movement3 = new Vector3(direction.x, direction.y, 0f); 

			transform.localPosition = transform.localPosition + movement3 * speed * Time.deltaTime;
		}
	}
}

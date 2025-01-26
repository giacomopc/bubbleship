using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Animation : MonoBehaviour
{
	public Sprite[] sprites;
	public float speed;
	float time;

	void LateUpdate()
	{
		if(!enabled)
			return;
			
		time += Time.deltaTime;
		var sr = GetComponent<SpriteRenderer>();
		sr.sprite = sprites[Mathf.RoundToInt(time * speed) % sprites.Length];
	}
}

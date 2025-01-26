using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Animation : MonoBehaviour
{
	public Sprite[] sprites;
	public float speed;

	void LateUpdate()
	{
		var sr = GetComponent<SpriteRenderer>();
		sr.sprite = sprites[Mathf.RoundToInt(Time.time * speed) % sprites.Length];
	}
}

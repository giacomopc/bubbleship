using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class AnimationImage : MonoBehaviour
{
	public Sprite[] sprites;
	public float speed;

	void LateUpdate()
	{
		var sr = GetComponent<Image>();
		sr.sprite = sprites[Mathf.RoundToInt(Time.time * speed) % sprites.Length];
	}
}

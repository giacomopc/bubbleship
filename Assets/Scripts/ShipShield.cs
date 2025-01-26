using System;
using UnityEngine;

public class ShipShield : MonoBehaviour
{
	public SpriteRenderer spriteRenderer;

	public Gradient defaultColors;
	public float initialScale, finalScale;
	public float speed = 2f;

	void LateUpdate()
	{
		var normalizedSin = (Mathf.Sin(Time.time * speed) + 1f) / 2f;
		spriteRenderer.color = defaultColors.Evaluate(normalizedSin);

		var scale = Mathf.Lerp(initialScale, finalScale, normalizedSin);
		transform.localScale = new Vector3(scale, scale, 1f);
	}
}

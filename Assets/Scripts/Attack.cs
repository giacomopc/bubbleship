using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Attack : MonoBehaviour
{
	public SpriteRenderer spriteRenderer;

	public void Start()
	{
		spriteRenderer
			.DOFade(0f, 0.7f)
			.SetEase(Ease.InQuad)
			.OnComplete(()=>Destroy(gameObject));	
	}
}

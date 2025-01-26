using System.Collections;
using System.Collections.Generic;
using System.Threading;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
	const float InitialHealth = 4;
	public RectTransform rectTransform;
	public Image image;
	public Gradient gradient;

	public float health;
	public float maxHealth = InitialHealth;

	void Awake()
	{
		health = maxHealth;
	}

	void Validate()
	{
		health = Mathf.Clamp(health, 0f, maxHealth);
	}

	public void OnDamage(float damage)
	{
		// print($"health {health} damage {damage}");
		health -= damage;
		Validate();
		UpdateBar();
	}


	void UpdateBar(bool instant = false)
	{
		var duration = instant ? 0f : 0.5f;
		rectTransform.DOKill();
		rectTransform.DOScaleX(health / maxHealth, duration).SetEase(Ease.OutCubic).Done();
	}

	void LateUpdate()
	{
		Validate();
		image.color = gradient.Evaluate(health / maxHealth);
	}
}

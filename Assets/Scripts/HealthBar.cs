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

	public void OnDamage(float damage)
	{
		print($"health {health} damage {damage}");
		health = Mathf.Max(0f, health - damage);
		UpdateBar();
	}

	void UpdateBar()
	{
		rectTransform.DOKill();
		rectTransform.DOScaleX(health / maxHealth, 0.5f).SetEase(Ease.OutCubic);
	}

	void LateUpdate()
	{
		image.color = gradient.Evaluate(health / maxHealth);
	}
}

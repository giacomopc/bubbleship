using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

using UInput = UnityEngine.Input;

public class Game : MonoBehaviour
{
	public Text time;
	public Transform ship;
	public HealthBar battery;

	public float InitialTime = 180f;


	float timeElapsed = 0f;

	void Awake()
	{
		Physics2D.gravity = Vector2.zero;
		ship.DOLocalMoveX(120f, 2f).SetEase(Ease.OutBack).From(-120f);
	}	

	void Update()
	{
		timeElapsed += Time.deltaTime;
		var timeLeft = InitialTime - timeElapsed;

		var minutes = Mathf.FloorToInt(timeLeft / 60f);
		var seconds = Mathf.FloorToInt(timeLeft % 60f);
		time.text = $"TIME {minutes}:{seconds:D2}";
		Input.Update();
	}
}

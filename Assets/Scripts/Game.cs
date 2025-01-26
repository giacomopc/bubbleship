using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

using UInput = UnityEngine.Input;

public class Game : MonoBehaviour
{
	public float InitialTime = 180f;
	float timeElapsed = 0f;
	public Text time;
	public Transform ship;

	void Awake()
	{
		Physics2D.gravity = Vector2.zero;
		ship.DOLocalMoveX(120f, 2f).SetEase(Ease.OutBack);
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

using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

using UInput = UnityEngine.Input;

public class Game : MonoBehaviour
{
	public static Game instance;
	
	public const float ShipRadius = 122f;
	public Text time;
	public Transform ship;
	public SpriteRenderer shipTop;
	public SpriteRenderer house;
	public AudioSource music;
	public CanvasGroup canvasGroup;
	public SpriteRenderer dialogue;

	public FlyingEnemy[] flyingEnemies;
	

	public float InitialTime = 180f;
	float timeElapsed = 0f;

	public static bool win = false;

	void Awake()
	{
		instance = this;
		
		Physics2D.gravity = Vector2.zero;

		shipTop.enabled = true;
		DOTween.Sequence()
		.Append(ship.DOLocalMoveX(120f, 2f).SetEase(Ease.OutBack).From(-120f))
		.AppendInterval(1f)
		.Append(shipTop.DOFade(0f, 1f))
		.OnComplete(()=> shipTop.enabled = false);
	}	

	void Update()
	{
		Input.Update();

		{
			timeElapsed += Time.deltaTime;
			var timeLeft = Mathf.Max(0f, InitialTime - timeElapsed);
			var minutes = Mathf.FloorToInt(timeLeft / 60f);
			var seconds = Mathf.FloorToInt(timeLeft % 60f);
			time.text = $"TIME {minutes}:{seconds:D2}";
		}

		if(!win)
		{
			var count = 0;
			foreach(var enemy in flyingEnemies)
			{
				if(!enemy.enabled)
					count++;
				
			}
			if(count == 4)
				Win();
		}

		if(Input.win)
		{
			Win();
		}

		if(win && Input.attack)
		{
			house.enabled = false;
			dialogue.enabled = true;
		}

		
	}

	void Win()
	{
		win = true;
		house.DOFade(1f, 1f);
		print("win");
		music.DOFade(0f, 1f);
		canvasGroup.DOFade(0f, 1f);
		ship.gameObject.SetActive(false);
		Player.instance.enabled = false;
	}
}

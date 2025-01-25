using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UInput = UnityEngine.Input;

public class Game : MonoBehaviour
{
	void Awake()
	{
		Physics2D.gravity = Vector2.zero;
	}	

	void Update()
	{
		Input.Update();
	}
}

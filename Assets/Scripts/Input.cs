using UnityEngine;

public static class Input
{
	public static bool left;
	public static bool right;
	public static bool up;
	public static bool down;
	public static bool attack;
	public static bool flashlight;
	public static bool win;

	public static void Update()
	{
		right = GetKey(KeyCode.RightArrow) || GetKey(KeyCode.D);
		up = GetKey(KeyCode.UpArrow) || GetKey(KeyCode.W);
		left = GetKey(KeyCode.LeftArrow) || GetKey(KeyCode.A);
		down = GetKey(KeyCode.DownArrow) || GetKey(KeyCode.S);
		attack = GetKeyDown(KeyCode.Space);
		flashlight = GetKeyDown(KeyCode.F);
		win = GetKeyDown(KeyCode.W);
	}

	public static bool GetKey(KeyCode key) => UnityEngine.Input.GetKey(key);
	public static bool GetKeyDown(KeyCode key) => UnityEngine.Input.GetKeyDown(key);

}
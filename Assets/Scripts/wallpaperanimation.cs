using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallpaperanimation : MonoBehaviour
{
    public Sprite[] sprite;
    public float frameRate = 1f;

    private SpriteRenderer spriterenderer;
    private int currentSpriteIndex = 0;
    private float timer = 0f;


    // Start is called before the first frame update
    void Start()
    {
        spriterenderer = GetComponent<SpriteRenderer>();

        if (sprite.Length > 0)
            spriterenderer.sprite = sprite[currentSpriteIndex];

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= frameRate)
        {
            timer= 0f;
            currentSpriteIndex = (currentSpriteIndex+1)%sprite.Length;
            spriterenderer.sprite = sprite[currentSpriteIndex];
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Block : MonoBehaviour
{
    private int hitsRemaining = 5;
    public SpriteRenderer spriteRender;
    private TextMeshPro text;
    public hitNumbers a;
    public bool special;
    private void Awake()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        text = GetComponentInChildren<TextMeshPro>();
        UpdateVisualState();
    }
    private void UpdateVisualState()
    {
        if (this.special == false)
        {
            text.SetText(hitsRemaining.ToString());
            spriteRender.color = Color.Lerp(Color.white, Color.red, hitsRemaining / 10f);
        }
        else
            spriteRender.color = Color.green;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        staticCounter.m_hitNumbers.counterNum();
        hitsRemaining--;
        if (hitsRemaining > 0) 
            UpdateVisualState();         
          
        else
        {
            staticCounter.m_hitNumbers.bloks();
            Destroy(gameObject);
        }
        if (this.special)
        {
            GameObject.Find("Ball Launcher").GetComponent<BallPush>().test();
        }
       
    }

    internal void SetHits(int hits)
    {
        hitsRemaining = hits;
        UpdateVisualState();
    }
    private void Update()
    {
        if (this.transform.position.y < -3)
            Application.Quit();
    }
}

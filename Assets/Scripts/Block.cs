using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Block : MonoBehaviour
{
    private int hitsRemaining = 5;
    private SpriteRenderer spriteRender;
    private TextMeshPro text;

    private void Awake()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        text = GetComponentInChildren<TextMeshPro>();
        UpdateVisualState();
    }
    private void UpdateVisualState()
    {
        text.SetText(hitsRemaining.ToString());
        spriteRender.color = Color.Lerp(Color.white,Color.red,hitsRemaining/10f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        hitsRemaining--;
        if (hitsRemaining > 0)
            UpdateVisualState();
        else
            Destroy(gameObject);
    }

    internal void SetHits(int hits)
    {
        hitsRemaining = hits;
        UpdateVisualState();
    }
}

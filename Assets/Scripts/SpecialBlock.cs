using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class SpecialBlock : MonoBehaviour
{
    private int hitsRemaining = 1;
    private SpriteRenderer spriteRender;
    private TextMeshPro text;
    public hitNumbers a;

    private void Awake()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        text = GetComponentInChildren<TextMeshPro>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        staticCounter.m_hitNumbers.counterNum();
        hitsRemaining--;

        staticCounter.m_hitNumbers.bloks();
        Destroy(gameObject);
  

    }

    internal void SetHits(int hits)
    {
        hitsRemaining = hits;    
    }
}

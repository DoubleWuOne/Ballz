using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallReturn : MonoBehaviour
{
    private BallPush ballPush;
    private void Awake()
    {
        ballPush = FindObjectOfType<BallPush>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ballPush.ReturnBall();
        collision.collider.gameObject.SetActive(false);
    }
}

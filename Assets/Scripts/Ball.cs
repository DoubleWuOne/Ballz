using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1;
    private new Rigidbody2D rigidbody2D;
    BallColors col;
    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        GetComponent<Renderer>().material.color = GameObject.Find("Script").GetComponent<BallColors>().color;
    }
    private void Update()
    {
        rigidbody2D.velocity = rigidbody2D.velocity.normalized * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // rigidbody2D.AddForce(-collision.contacts[0].normal + new Vector2(Random.Range(-1, 1), Random.Range(-1, 1)));
        if (transform.position.x <= Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x || transform.position.x >= Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x)
        {
            Vector2 oldVel = rigidbody2D.velocity;
            rigidbody2D.velocity = Vector2.zero;
            rigidbody2D.velocity = oldVel * new Vector2(-1, 1);
        }

        //Top detection
        if (transform.position.y >= Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).y)
        {
            Vector2 oldVel = rigidbody2D.velocity;
            rigidbody2D.velocity = Vector2.zero;
            rigidbody2D.velocity = oldVel * new Vector2(1, -1);
        }
    }   
}

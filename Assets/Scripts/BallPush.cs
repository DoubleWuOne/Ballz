using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPush : MonoBehaviour
{
    [SerializeField] Ball ballPrefab;
    private Vector3 startDragPosition;
    private Vector3 endDragPosition;

    private BlockSpawner blockSpawner;
    private LaunchPreview launchPreview;
    private List<Ball> balls = new List<Ball>();
    private int ballsReady;


    private void Awake()
    {
        blockSpawner = FindObjectOfType<BlockSpawner>();
        launchPreview = GetComponent<LaunchPreview>();
        CreateBall();
    }

    public void ReturnBall()
    {
        ballsReady++;
        if (ballsReady == balls.Count)
        {
            blockSpawner.SpawnRowOfBlocks();
            CreateBall();
        }
    }

    private void CreateBall()
    {
        var ball = Instantiate(ballPrefab);
        balls.Add(ball);
        ballsReady++;
    }
    private void Update()
    {
        Vector3 worldPosition = Camera.main.ScreenToViewportPoint(Input.mousePosition) + Vector3.back * -10;
        if (Input.GetMouseButtonDown(0))
        {
            launchPreview.lineRenderer.enabled = true;
            StartDrag(worldPosition);
        }
        else if (Input.GetMouseButton(0))
        {
            ContinueDrag(worldPosition);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            EndDrag();
            launchPreview.lineRenderer.enabled = false;
        }

    }

    private void EndDrag()
    {
        StartCoroutine(LaunchBalls());
    }

    private IEnumerator LaunchBalls()
    {
        Vector3 direction = endDragPosition - startDragPosition;
        direction.Normalize();

        foreach (var ball in balls)
        {
            ball.transform.position = transform.position;
            ball.gameObject.SetActive(true);
            ball.GetComponent<Rigidbody2D>().AddForce(-direction);


            ballsReady -= 1;
            yield return new WaitForSeconds(0.1f); 
        }
    }

    private void ContinueDrag(Vector3 worldPosition)
    {
        endDragPosition = worldPosition;

        Vector3 direction = endDragPosition - startDragPosition;

        launchPreview.SetEndPoint(transform.position - direction);
    }

    private void StartDrag(Vector3 worldPosition)
    {
        startDragPosition = worldPosition;
        launchPreview.SetStartPoint(transform.position);
    }
}

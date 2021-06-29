using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPreview : MonoBehaviour
{
    public LineRenderer lineRenderer;
    private Vector3 dragStartPoint;
    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
    }

    public void SetStartPoint(Vector3 worldPoint)
    {
        dragStartPoint = worldPoint;
        lineRenderer.SetPosition(0, dragStartPoint);
    }
    public void SetEndPoint(Vector3 worldPoint)
    {
        Vector3 pointOffset = worldPoint - dragStartPoint;
        Vector3 endPoint = transform.position + pointOffset * 15;

        lineRenderer.SetPosition(1, endPoint);
    }
}

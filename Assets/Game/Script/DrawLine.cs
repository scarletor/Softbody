using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DrawLine : MonoBehaviour
{
    public LineRenderer lineRenderer;
    private Camera mainCamera;
    public Vector3 startPoint;


    public static DrawLine instance;

    private void Awake()
    {
        instance = this;
        Debug.LogError("setup linedraw");
        lr = this.GetComponent<LineRenderer>();

    }
    void Start()
    {
        Debug.LogError("setup linedraw");

        lineRenderer = GetComponent<LineRenderer>();
        mainCamera = Camera.main;
        lineRenderer.positionCount = 2; // We always need exactly 2 points

        lr.sortingLayerName = SortingLayer;
        lr.sortingOrder = OrderInLayer;
    }

    public void EnableDraw()
    {
        gameObject.SetActive(true);
    }


    public void DisableDraw()
    {
        lineRenderer.SetPosition(1, Vector2.zero);
        lineRenderer.SetPosition(0, Vector2.zero);
        gameObject.SetActive(false);

    }


    public void DrawLineAt(Vector3 startPos, Vector3 endPos)
    {
        startPos.z = -1;
        endPos.z = -1;
        lineRenderer.SetPosition(0, startPos);
        lineRenderer.SetPosition(1, endPos);
    }

    public LineRenderer lr;
    public string SortingLayer;
    public int OrderInLayer;

  

}
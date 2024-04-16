using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class DrawLine : MonoBehaviour
{
    public LineRenderer lineRenderer;
    private Camera mainCamera;
    public Vector3 startPoint;


    public static DrawLine instance;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        mainCamera = Camera.main;
        lineRenderer.positionCount = 2; // We always need exactly 2 points
    }

    public void EnableDraw()
    {
        gameObject.SetActive(true);
    }


    public void DisableDraw()
    {
        gameObject.SetActive(false);
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //// Convert the mouse position to world coordinates for the starting point
            //startPoint = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            //startPoint.z = 0; // Ensure the Z position is zero for 2D
            ////lineRenderer.SetPosition(0, startPoint);
            //lineRenderer.enabled = true; // Enable the LineRenderer if it was disabled
        }

        if (Input.GetMouseButton(0))
        {
            // Update the end point of the line with the current mouse position
            Vector3 currentMousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            currentMousePos.z = 0; // Ensure the Z position is zero for 2D
            lineRenderer.SetPosition(1, currentMousePos);
        }
    }
}
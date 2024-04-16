using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class SoftRope : MonoBehaviour
{
    public Transform[] ropeSegments; // Các đốt trên dây
    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = ropeSegments.Length;
    }

    void Update()
    {
        // Cập nhật vị trí của các điểm trên dây
        for (int i = 0; i < ropeSegments.Length; i++)
        {
            lineRenderer.SetPosition(i, ropeSegments[i].position);
        }
    }
}
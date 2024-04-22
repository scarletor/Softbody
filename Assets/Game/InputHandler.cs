using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private Camera mainCamera;
    private bool isDragging = false;
    private Vector3 offset;
    public GameObject touchArea;
    public GameObject colliderTouched;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main; // Get the main camera of the scene
    }


    public Vector2 force;
    public Rigidbody2D grablingRd;

    // Update is called once per frame
    void Update()
    {
        CheckTouch();
    }

   

    public int multiple;
    public void CheckTouch()
    {
        // Kiểm tra nếu đang chạm vào màn hình (hoặc chuột dưới nền tảng máy tính)
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
            Debug.DrawRay(mousePos, Vector3.forward * 10, Color.red, 2f);


            grabingObj = FindNearTouchablePoint(mousePos);


            //if (hit.collider != null && hit.collider.gameObject == gameObject)
            if (grabingObj != null)
            {
                grablingRd = grabingObj.GetComponent<Rigidbody2D>();
                colliderTouched = grabingObj.gameObject;
                Debug.LogError("TOUCH + " + hit.collider);
                isDragging = true;
                DrawLine.instance.EnableDraw();
                offset = grabingObj.transform.position - new Vector3(mousePos.x, mousePos.y, 0);
            }


        }

        if (isDragging)
        {
            Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

            offset = new Vector3(mousePos.x, mousePos.y, 0) - grabingObj.transform.position;
            // Update the GameObject's position using the offset, properly handling the z-component
            //gameObject.transform.position = new Vector3(mousePos.x, mousePos.y, gameObject.transform.position.z) + offset;

            DrawLine.instance.lineRenderer.SetPosition(0, colliderTouched.transform.position);

            Debug.LogError("offset add: " + offset);
            grablingRd.AddForce(offset * multiple);

            // Optionally, draw the drag ray
            Debug.DrawRay(new Vector3(mousePos.x, mousePos.y, 0), Vector3.forward * 10, Color.green, 0.1f);
        }



        if (Input.GetMouseButtonUp(0))
        {
            grabingObj = null;
            isDragging = false;
            DrawLine.instance.DisableDraw();
            grablingRd = null;
        }
    }

    public TouchablePoint grabingObj;
    public TouchablePoint FindNearTouchablePoint(Vector2 touchPos)
    {

        float minDistance = float.MaxValue;
        TouchablePoint nearestPoint = null;

        foreach (TouchablePoint point in GameManager.instance.touchablePointS)
        {
            float distance = Vector3.Distance(touchPos, point.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestPoint = point;
            }
        }
        return nearestPoint;

    }













}

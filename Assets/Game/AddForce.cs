using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour
{

    private Camera mainCamera;
    private bool isDragging = false;
    private Vector3 offset;

    public GameObject colliderTouched;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main; // Get the main camera of the scene
        RD = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ListenInput();
        CheckTouch();
    }

    public void ListenInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            RD.AddForce(force);
        }
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



            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                colliderTouched = hit.collider.gameObject;
                Debug.LogError("TOUCH + " + hit.collider);
                isDragging = true;
                DrawLine.instance.EnableDraw();
                offset = gameObject.transform.position - new Vector3(mousePos.x, mousePos.y, 0);
            }


        }

        if (isDragging)
        {
            Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

            offset = new Vector3(mousePos.x, mousePos.y, 0) - gameObject.transform.position;
            // Update the GameObject's position using the offset, properly handling the z-component
            //gameObject.transform.position = new Vector3(mousePos.x, mousePos.y, gameObject.transform.position.z) + offset;

            DrawLine.instance.lineRenderer.SetPosition(0, colliderTouched.transform.position);

            Debug.LogError("offset add: " + offset);
            RD.AddForce(offset * multiple);

            // Optionally, draw the drag ray
            Debug.DrawRay(new Vector3(mousePos.x, mousePos.y, 0), Vector3.forward * 10, Color.green, 0.1f);
        }



        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            DrawLine.instance.DisableDraw();

        }
    }

    public Vector2 force;
    public Rigidbody2D RD;
}

using UnityEngine;
using UnityEditor;

public class CustomMenuActions
{
    // Thêm một hàm vào menu Unity Editor với phím tắt không bắt buộc
    [MenuItem("Custom Tools/Run Custom Action %g")] // %g là phím tắt Alt+G
    private static void RunCustomAction()
    {
        // Thực hiện một số hành động
        Debug.Log("Custom action executed!");

        // Ví dụ, bạn có thể muốn thay đổi một số thuộc tính của GameObject đang được chọn
        GameObject selectedGameObject = Selection.activeGameObject;
        if (selectedGameObject != null)
        {
            // Thực hiện thay đổi, ví dụ như đổi tên
            selectedGameObject.name = "Renamed GameObject";
            Debug.Log("Selected GameObject has been renamed.");
        }
        else
        {
            Debug.Log("No GameObject selected.");
        }
    }

    

    [MenuItem("Custom Tools/Select GameObject #&z")] // %#x nghĩa là Alt + Shift + X
    private static void SelectGameObject()
    {
        selectedGameObject = Selection.activeGameObject;
        if (selectedGameObject != null)
        {
            Debug.Log("Selected GameObject: " + selectedGameObject.name);
        }
        else
        {
            Debug.Log("No GameObject is selected.");
        }



    }
   public static GameObject selectedGameObject;





    [MenuItem("Custom Tools/set 1 GameObject #&x")] // &a nghĩa là Alt + A
    private static void Set1()
    {
        if (selectedGameObject != null)
        {
            Debug.Log("Selected GameObject: " + selectedGameObject.name);
        }
        else
        {
            Debug.Log("No GameObject is selected.");
        }

        var allSelects = Selection.gameObjects;
        selectedGameObject.GetComponents<SpringJoint2D>()[0].connectedBody = allSelects[0].GetComponent<Rigidbody2D>();
        selectedGameObject.GetComponents<SpringJoint2D>()[1].connectedBody = allSelects[1].GetComponent<Rigidbody2D>();
        selectedGameObject.GetComponents<SpringJoint2D>()[2].connectedBody = allSelects[2].GetComponent<Rigidbody2D>();
        Debug.LogWarning("Selected GameObject: " + selectedGameObject.name);
        Debug.LogWarning("Selected GameObject: " + selectedGameObject.name);
        Debug.LogWarning("Selected GameObject: " + selectedGameObject.name);


    }


    [MenuItem("Custom Tools/set  2 GameObject #&2")] // &a nghĩa là Alt + A
    private static void Set2()
    {
        if (selectedGameObject != null)
        {
            Debug.Log("Selected GameObject: " + selectedGameObject.name);
        }
        else
        {
            Debug.Log("No GameObject is selected.");
        }

        selectedGameObject.GetComponents<SpringJoint2D>()[1].connectedBody = Selection.activeGameObject.GetComponent<Rigidbody2D>();
        Debug.LogWarning("Selected GameObject: " + selectedGameObject.name);


    }


    [MenuItem("Custom Tools/set 3 GameObject #&3")] // &a nghĩa là Alt + A
    private static void Set3()
    {
        if (selectedGameObject != null)
        {
            Debug.Log("Selected GameObject: " + selectedGameObject.name);
        }
        else
        {
            Debug.Log("No GameObject is selected.");
        }

        selectedGameObject.GetComponents<SpringJoint2D>()[2].connectedBody = Selection.activeGameObject.GetComponent<Rigidbody2D>();
        Debug.LogWarning("Selected GameObject: " + selectedGameObject.name);


    }

}

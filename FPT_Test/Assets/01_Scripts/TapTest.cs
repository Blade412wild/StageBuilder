using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapTest : MonoBehaviour
{
    public GameObject targetObject;  // The GameObject that you want to move
    public Camera mainCamera;        // The camera to use for screen-to-world conversion (you can assign it in the inspector)

    void Start()
    {
        // If the main camera is not assigned, use Camera.main
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    void Update()
    {
        // Check if the device has been touched (for Android or any touch input)
        if (Input.touchCount > 0)
        {
            // Get the first touch
            Touch touch = Input.GetTouch(0);

            // If the touch just began (user tapped the screen)
            if (touch.phase == TouchPhase.Moved)
            {
                // Move the GameObject to the touch position
                MoveObjectToTouchPosition(touch.position);
            }
        }

        // Allow mouse input for debugging in the Unity Editor
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            MoveObjectToTouchPosition(mousePos);
        }
    }

    // Method to move the GameObject to the touch/mouse position
    void MoveObjectToTouchPosition(Vector3 screenPosition)
    {
        // Convert screen position to world position
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, GetZPosition()));

        // Move the GameObject to the touch/mouse world position
        targetObject.transform.position = worldPosition;

        // Log the new position of the GameObject
        Debug.Log("Object moved to: " + worldPosition);
    }

    // Method to determine the correct Z position based on the camera type (orthographic vs perspective)
    float GetZPosition()
    {
        if (mainCamera.orthographic)
        {
            // If the camera is orthographic, the Z position is the target object's current Z position
            return targetObject.transform.position.z;
        }
        else
        {
            // If the camera is perspective, return the distance from the camera to the object
            return Mathf.Abs(mainCamera.transform.position.z - targetObject.transform.position.z);
        }
    }
}


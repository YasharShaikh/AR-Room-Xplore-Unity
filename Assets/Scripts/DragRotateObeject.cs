using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragRotateObeject : MonoBehaviour
{
    private float initialDistance;
    Vector3 initialScale;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScaleRoom();
        RotateRoom();
    }

    private void ScaleRoom()
    {
        if (Input.touchCount == 2)
        {
            Touch screenTouchZero = Input.GetTouch(0);
            Touch screenTouchOne = Input.GetTouch(1);

            if (screenTouchZero.phase == TouchPhase.Ended || screenTouchZero.phase == TouchPhase.Canceled && screenTouchOne.phase == TouchPhase.Ended || screenTouchOne.phase == TouchPhase.Canceled)
            {
                return;
            }
            if (screenTouchZero.phase == TouchPhase.Began || screenTouchOne.phase == TouchPhase.Began)
            {
                initialDistance = Vector2.Distance(screenTouchZero.position, screenTouchOne.position);
                initialScale = transform.localScale;
            }
            else
            {
                float currentDistance = Vector2.Distance(screenTouchZero.position, screenTouchOne.position);
                if (Mathf.Approximately(initialDistance, 0))
                {
                    return;
                }
                float factor = currentDistance / initialDistance;
                transform.localScale = factor * initialScale;
            }
        }
    }

    private void RotateRoom()
    {
        if (Input.touchCount == 1)
        {
            Touch screenTouch = Input.GetTouch(0);
            if (screenTouch.phase == TouchPhase.Moved)
            {
                transform.Rotate(0f, -screenTouch.deltaPosition.x, 0);

            }

        }
    }
}

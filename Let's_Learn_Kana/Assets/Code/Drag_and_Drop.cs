using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag_and_Drop : MonoBehaviour
{
//class variables
    private Vector3 dragOffset;
    private Camera cam;
    //private Vector3 originalPosition;

    //class methods
    void Awake()
    {
        cam = Camera.main;
        //originalPosition = transform.position;
    }
    void OnMouseDown()
    {
        dragOffset = (transform.position) - (GetMousePos());
    }
    void OnMouseDrag()
    {
        transform.position = GetMousePos() + dragOffset;
    }
    Vector3 GetMousePos()
    {
        var mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag_and_Drop : MonoBehaviour
{
//class variables
    private Vector3 dragOffset;
    private Camera cam;

//class methods
    void Awake()
    {
        cam = Camera.main;
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

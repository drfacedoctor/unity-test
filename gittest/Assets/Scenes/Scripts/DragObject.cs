using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 mOffset;
    private Vector3 scrollOffset;

    private float scrollz;
    private float mZCoord;

    private bool isDragging = false;
        
    [SerializeField] Camera viewCamera;

    void Update()
    {
        scrollOffset = viewCamera.transform.forward * scrollz - mOffset;
        scrollz += Input.GetAxis("Mouse ScrollWheel");

        if(isDragging)
        {
            transform.position = GetMouseWorldPos() + mOffset + scrollOffset;
        }
    }

    void OnMouseDown()
    {
        if(!isDragging){
            mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
            mOffset = gameObject.transform.position - GetMouseWorldPos();
            scrollz = 0;
            isDragging = true;
        }
        else
        {
            isDragging = false;
        }
    }

    private Vector3 GetMouseWorldPos()
    {
        //2d coordinates (x,y)
        Vector3 mousePoint = Input.mousePosition;

        //z coordinate of game object on screen
        mousePoint.z = mZCoord;

        return viewCamera.ScreenToWorldPoint(mousePoint);
    }

    /*void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + mOffset + scrollOffset;
    }*/
}

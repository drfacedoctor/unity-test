using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class SuperDrag : MonoBehaviour
{

    [SerializeField] private GameObject mousePoint;
    [SerializeField] private float speed = 10f;
    [SerializeField] Camera viewCamera;
    private Vector3 mOffset;
    private float mZCoord;

    private bool isDragging = false;
    private bool canDrag;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        mZCoord = viewCamera.WorldToScreenPoint(mousePoint.transform.position).z;

        mousePoint.transform.position = GetMouseWorldPos();

        if(isDragging)
        {
            transform.position = Vector3.MoveTowards(transform.position, mousePoint.transform.position, speed * Time.deltaTime);

        }

        

    }

    private Vector3 GetMouseWorldPos()
    {
        //2d coordinates (x,y)
        Vector3 mousePos = Input.mousePosition;

        //z coordinate of game object on screen
        mousePos.z = mZCoord;

        return viewCamera.ScreenToWorldPoint(mousePos);
    }

    void OnMouseDown()
    {
        if(canDrag)
        {
            isDragging = true;
            canDrag = false;
        }
        else{
            isDragging = false;
            canDrag = true;
        }
    }
    
}

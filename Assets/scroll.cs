using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scroll : MonoBehaviour
{
    public Camera camera;
    public float first =5f;
    //sens refers to scroll sensitivity
    public float sens = 20;
    //dragSpeed refers to drag sensitivity
    public float dragSpeed = 2;
    Vector3 dragOrigin;
    
    // Update is called once per frame
    
    void Update()
    {
        
        //handles scroll zoom
        camera.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * sens;
        
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;
            return;
        }
        
 
        if (!Input.GetMouseButton(0)) return;
 
        Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
        Vector3 move = new Vector3(pos.x * dragSpeed, pos.y * dragSpeed,0 );
 
        transform.Translate(move, Space.World);


    }
}

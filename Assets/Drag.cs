using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class Drag : MonoBehaviour

{

    private Vector3 mOffset;

    public float time;
    private bool started = false;



    private float mZCoord;



    void OnMouseDown()

    {

        mZCoord = Camera.main.WorldToScreenPoint(

            gameObject.transform.position).z;



        // Store offset = gameobject world pos - mouse world pos

        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();

    }



    private Vector3 GetMouseAsWorldPoint()

    {

        // Pixel coordinates of mouse (x,y)

        Vector3 mousePoint = Input.mousePosition;



        // z coordinate of game object on screen

        mousePoint.z = mZCoord;



        // Convert it to world points

        return Camera.main.ScreenToWorldPoint(mousePoint);

    }



    void OnMouseDrag()

    {  
        if(transform.position.x < 11){
            time+=Time.deltaTime;
        Vector3 joe = GetMouseAsWorldPoint() + mOffset;
        transform.position = new Vector3(joe.x, 0, joe.z);}
        
    }

}
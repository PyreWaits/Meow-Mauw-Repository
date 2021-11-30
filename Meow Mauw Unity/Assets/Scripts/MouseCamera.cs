using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCamera : MonoBehaviour
{
    //holds turning
    public Vector2 turn;

    
    void Update()
    {
        //Gets input of mouse and only translates y axis cause I couldn't figure out something better
        turn.x+=Input.GetAxis("Mouse X");
        turn.y+=Input.GetAxis("Mouse Y");
        transform.localRotation= Quaternion.Euler(-turn.y*3,0,0);
        

        
    }
}

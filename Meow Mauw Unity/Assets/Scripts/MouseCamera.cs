using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCamera : MonoBehaviour
{
    public Vector2 turn;

    // Update is called once per frame
    void Update()
    {
        turn.x+=Input.GetAxis("Mouse X");
        turn.y+=Input.GetAxis("Mouse Y");
        transform.localRotation= Quaternion.Euler(-turn.y*3,0,0);
        

        
    }
}

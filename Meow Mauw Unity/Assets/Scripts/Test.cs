using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
[SerializeField]float moveSpeed = 5f;
public Vector2 turn;


    // This whole thing needs a lot of work. It's a placeholder rn
    void Update()
    {
        MovePlayer();

    }

    //Turns and moves the player doesn't work good cause it's using transform
    void MovePlayer()
    {
        float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float zValue = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        float yValue = Input.GetAxis("Jump") * Time.deltaTime * 20;
        transform.Translate(xValue, yValue, zValue);
        turn.x+=Input.GetAxis("Mouse X");
        turn.y+=Input.GetAxis("Mouse Y");
        transform.localRotation= Quaternion.Euler(0,turn.x*3,0);
    }
}

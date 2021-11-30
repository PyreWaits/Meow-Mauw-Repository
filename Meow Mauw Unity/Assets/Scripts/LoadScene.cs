using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Needed to lead scene
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    //changable string for levels
    [SerializeField]string level;
   //When player enters trigger area
    void OnTriggerEnter(Collider other) 
    {
        //Checks if gameobject is tagged player
        if(other.gameObject.tag =="Player")
        {
        //kinda obvious
        SceneManager.LoadScene(level);     
        }
    }
    
}

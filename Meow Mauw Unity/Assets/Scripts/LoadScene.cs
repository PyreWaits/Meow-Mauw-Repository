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
            if(gameObject.tag=="FallDesert"){
                Variables.Capes=0;
                Items.scoreCapes=0;
            }
              if(gameObject.tag=="FallRuins"){
                Variables.SunGlasses=0;
                Items.scoreSunglasses=0;
            }
        //kinda obvious
        Cursor.visible=true;
        Cursor.lockState=CursorLockMode.None;
        SceneManager.LoadScene(level);     
        }
        

    }
    
    
}

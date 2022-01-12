using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collected : MonoBehaviour
{
       public bool Loading = true;

    
    // Start is called before the first frame update
    void Start()
    {
        
        
        if(Loading==true){
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            gameObject.SetActive(false);
        }
        
    }
         public void OnTriggerEnter(Collider other) {
         //Checks for player tag
        if(other.gameObject.tag=="Player"){
            gameObject.SetActive(false);
            Loading=false;
            
        }
         }

    // Update is called once per frame

}

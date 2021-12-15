using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GateDesert : MonoBehaviour
{
    //used for the desert gate
    public int crownsNeeded=1;
    //When enough crowns are collected gate opens when approachng
    void OnTriggerEnter(Collider other) {     
        if (other.gameObject.tag=="Player"&&Variables.Crowns>=crownsNeeded){
            Destroy(gameObject);
            
        }
       
    
    } 
    



}

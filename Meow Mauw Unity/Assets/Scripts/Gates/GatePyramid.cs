using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GatePyramid : MonoBehaviour
{
    //used for the pyramid gate
    public int sceptersNeeded=1;
    //When enough scepters are collected gate opens when approachng
    void OnTriggerEnter(Collider other) {     
        if (other.gameObject.tag=="Player"&&Variables.Scepters>=sceptersNeeded){
            Destroy(gameObject);
            
        }
       
    
    } 
    



}

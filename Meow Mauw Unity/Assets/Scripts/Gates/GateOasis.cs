using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GateOasis : MonoBehaviour
{
    //used for the Oasis gate
    public int sunGlassesNeeded=1;
    //When enough sunglasses are collected gate opens when approachng
    void OnTriggerEnter(Collider other) {     
        if (other.gameObject.tag=="Player"&&Variables.SunGlasses>=sunGlassesNeeded){
            Destroy(gameObject);
            
        }
       
    
    } 
    



}

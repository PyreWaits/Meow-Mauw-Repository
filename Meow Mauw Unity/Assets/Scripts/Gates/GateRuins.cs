using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GateRuins : MonoBehaviour
{
    //used for the ruins gate
    public int capesNeeded=1;
    //When enough capes are collected gate opens when approachng
    void OnTriggerEnter(Collider other) {     
        if (other.gameObject.tag=="Player"&&Variables.Capes>=capesNeeded){
            Destroy(gameObject);
            
        }
       
    
    } 
    



}

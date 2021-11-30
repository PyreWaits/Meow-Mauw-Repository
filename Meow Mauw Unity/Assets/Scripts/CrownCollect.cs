using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Used for collecting crowns and adding to the crown variable
public class CrownCollect : MonoBehaviour
{
    //On entering area with script add to crowns and destroy script object
     public void OnTriggerEnter(Collider other) {
         //Checks for player tag
        if(other.gameObject.tag=="Player"){
            Variables.Crowns++;
            Destroy(gameObject);
        }

    }

}

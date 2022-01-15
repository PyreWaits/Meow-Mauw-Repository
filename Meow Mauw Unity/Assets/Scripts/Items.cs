using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Items : MonoBehaviour
{

 

 
    public Text scoreText;
    static public int scoreCrowns;
    static public int scoreCapes;
    static public int scoreSunglasses;
    

 
    void Start () {
        scoreText = GetComponent<Text>(); 
        //scoreCapesText = GetComponent<Text>();  // if you want to reference it by code - tag it if you have several texts
        //scoreSunglassesText= GetComponent<Text>(); 
    }
 
    void Update () {
        scoreText.text =(scoreCrowns+"/ 1 Crowns\n"+scoreCapes+"/ 10 Capes \n"+scoreSunglasses+"/ 3 Shades");  // make it a string to output to the Text object
        //scoreCapesText.text = scoreCapes.ToString(scoreCapes+"/ 20 Capes");  // make it a string to output to the Text object
        //scoreSunglassesText.text = scoreSunglasses.ToString(scoreSunglasses+"/ 3 Sunglasses");  // make it a string to output to the Text object
    }
}

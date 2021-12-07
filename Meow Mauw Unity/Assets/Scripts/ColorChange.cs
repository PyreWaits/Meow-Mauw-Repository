using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    MeshRenderer colorMesh;
    [SerializeField][Range(0f,1f)] float lerpTime;
    [SerializeField] Color[] myColors;
    int color=0;
    float t=0f;
    int len;
    void Start() {
        colorMesh=GetComponent<MeshRenderer>();
        len= myColors.Length;
    }
void Update(){
    colorMesh.material.color=Color.Lerp(colorMesh.material.color,myColors[color],lerpTime);
    t=Mathf.Lerp(t,1f,lerpTime*Time.deltaTime);
    if(t>9f){
        t=0f;
        color++;
        color=(color>=len)? 0 : color;
    }
}


}

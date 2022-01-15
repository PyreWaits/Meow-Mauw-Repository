using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string levelToLoad;
public void OnPointerClick()
    {
        //invokes the sceneChange function
        Invoke("sceneChange",1);


    }
    void sceneChange()
    {

        //changes scene
        SceneManager.LoadScene(levelToLoad);
    }
}

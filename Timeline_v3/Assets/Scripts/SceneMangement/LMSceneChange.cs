using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class LMSceneChange : MonoBehaviour
{
public void Scene1() {  
        SceneManager.LoadScene("MainMenu");  
    }  
    public void exitgame() {  
        Debug.Log("exitgame");  
        Application.Quit();  
    }   
}

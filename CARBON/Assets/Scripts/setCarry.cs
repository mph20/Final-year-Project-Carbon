using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class setCarry : MonoBehaviour
{
    public void LoadScene(string sceneName){
        PlayerPrefs.SetInt("playerlives",5);
        PlayerPrefs.SetString("currnode","start");
       SceneManager.LoadScene(sceneName);

   }

   public void ExitGame(){
       //Debug.Log ("Game Exited");
       Application.Quit();
   }
}

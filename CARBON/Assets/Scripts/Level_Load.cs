using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Load : MonoBehaviour
{

    void reset(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void main_menu(){
        SceneManager.LoadScene("MainMenu");
    }
    void cutscene(){
        SceneManager.LoadScene("Cutscene");
    }
    void overworld(){
        SceneManager.LoadScene("overworld");
    }
    void lvl1_1(){
        SceneManager.LoadScene("Level_1.1");
    }
    void lvl1_2(){
        SceneManager.LoadScene("Level_1.2");
    }
    void lvl1_3(){
        SceneManager.LoadScene("Level_1.3");
    }
    void lvl2(){
        SceneManager.LoadScene("Level_2");
    }
    void lvl3(){
        SceneManager.LoadScene("Level_3");
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneToOvw : MonoBehaviour
{
    void Start()
    {
        SceneManager.LoadScene("overworld");
    }

}

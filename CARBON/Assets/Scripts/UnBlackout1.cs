using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnBlackout1 : MonoBehaviour
{
    public Image image;
    public float fadeRate = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if(image.color.a > 0f){
        image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a- (fadeRate *Time.deltaTime));
        }  
    }
}

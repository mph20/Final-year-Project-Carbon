using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthandarmor : MonoBehaviour
{
    public int health;
    public int numhearts;
    public Image[] hearts;
    public Sprite fullheart;
    public Sprite emptyheart;

    public int armor;
    public int numarmor;
    public Image[] armors;
    public Sprite fullarmor;
    public Sprite emptyarmor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health>numhearts){
            health=numhearts;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if(i<health){
                hearts[i].sprite=fullheart;
            }
            else{
                hearts[i].sprite=emptyheart;
            }
            if(i<numhearts){
                hearts[i].enabled=true;
            }
            else{
                hearts[i].enabled=false;
            }
        }

        if(armor>numarmor){
            armor=numarmor;
        }
        for (int i = 0; i < armors.Length; i++)
        {
            if(i<armor){
                armors[i].sprite=fullarmor;
            }
            else{
                armors[i].sprite=emptyarmor;
            }
            if(i<numarmor){
                armors[i].enabled=true;
            }
            else{
                armors[i].enabled=false;
            }
        }
    }
    private void Hit() {
        if (armor != 0)       
            armor -= 1;
        else
            health -= 1;
    }

    void OnCollisionEnter2D(Collision2D col) {

        if(col.collider.tag == "EBullet"){

            Hit();
        }
        
    }
}

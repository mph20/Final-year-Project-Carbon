using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    public AudioSource audioSrc;
    public GameObject muzzelFlash;
    
    public float bulletForce = 20f;

    void Update()
    {
         if(Input.GetKeyDown("x")){
            Shoot();
            audioSrc.Play();
            
         }
    }

    void Shoot(){
        GameObject effect = Instantiate(muzzelFlash, firePoint.position, firePoint.rotation);
        Destroy(effect, 0.1f);
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);

    }
}

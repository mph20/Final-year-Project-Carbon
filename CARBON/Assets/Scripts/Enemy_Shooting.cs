using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Shooting : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    public AudioSource audioSrc;
    public GameObject muzzelFlash;
    public float startTimeBtwShots = 1;
    private float timeBtwShots;
    
    public float bulletForce = 20f;

    void Start(){

        timeBtwShots = 0f;
    }

    void Update()
    {
         if(gameObject.GetComponent<Basic_Enemy>().playerInSight){

             if(timeBtwShots <= 0){
            Shoot();
            audioSrc.Play();
            timeBtwShots = startTimeBtwShots;
             }
             else{
                 timeBtwShots -= Time.deltaTime;
             }
            
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

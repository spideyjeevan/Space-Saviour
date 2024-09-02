using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class bullet : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    [SerializeField] private Animator explosionEffect;
    [SerializeField] private float bulletRange = 5;


    //score text to increase score per hit
    [SerializeField] private scoreManager scoreManagerScript;



    private AudioSource audiosource;
    [SerializeField] private AudioClip explosionSFX;


    private void Awake()
    {
        audiosource = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
        scoreManagerScript = GameObject.FindGameObjectWithTag("score").GetComponent<scoreManager>();
    }



    void Update()
    {
        //moving the bullet up and destroy when it reaches to 5
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        
        if (transform.position.y > bulletRange)
        {
            Destroy(gameObject);
        }
    }

     void OnCollisionEnter2D(Collision2D collision)
     {
        //when bullet collide with enemy, it should get destroy,
        //destroy bullet and instantiate the explosion effect
        if (collision.gameObject.CompareTag("enemy"))
        {
            audiosource.PlayOneShot(explosionSFX);
            scoreManagerScript.addScore(1);
            Destroy(collision.gameObject);
            //Destroy(gameObject);
            Instantiate(explosionEffect, collision.transform.position, collision.transform.rotation);            
        }
     }
}

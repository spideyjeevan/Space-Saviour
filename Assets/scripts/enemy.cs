using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject explosion;

    //Health
    private health healthScript;



    //explosion
    private AudioSource audiosource;
    [SerializeField] private AudioClip explosionSFX;







    void Awake()
    {
        audiosource = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
        healthScript = GameObject.FindGameObjectWithTag("Player").GetComponent<health>();
    }
    private void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        //if the enemy object move more then -2.7, it will destroy
        /*if (transform.position.y < -3f && healthScript.alive)
        {
            Destroy(gameObject);
            healthScript.damage(10);
            //Instantiate(explosion, transform.position, transform.rotation);

        }*/
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        //if the enemy collide the player then it will destroy
        if(collision.gameObject.tag == "Player" && healthScript.alive)
        {
            audiosource.PlayOneShot(explosionSFX);
            Destroy(gameObject);
            healthScript.damage(10);
            collision.gameObject.GetComponent<health>().damage(10);
            Instantiate(explosion, transform.position, transform.rotation);
        }

        if(collision.gameObject.tag == "spaceship" && healthScript.alive)
        {
            Destroy(gameObject);
            healthScript.damage(10);
            Instantiate(explosion, transform.position, transform.rotation);
            audiosource.PlayOneShot(explosionSFX);
        }
    }


    private void destroyExplosion()
    {
        Destroy(gameObject);
    }

}

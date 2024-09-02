using System.Collections;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    //player Movement using rigidbody
    private Rigidbody2D rb;
    [SerializeField] private float speed;


    //shooting bullets
    [SerializeField] private GameObject bullets;

    //accessing health script
    private health healthScript;


    //ui panel
    [SerializeField] private GameObject UIpanel;
    


    

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        healthScript = GetComponent<health>();
        
    }


    void Start()
    {
        StartCoroutine(spawingBullets()); //spawning the bullets using coroutine
        
    }

    void Update()
    {
            // Input from the player
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            // Player movement
            //Vector2 move = new Vector2(h, v);
            //transform.Translate(move * Time.deltaTime * speed);

            HandleTouchInput();
            // Preventing overlapping or going off the screen
            clamping();
    }

    void HandleTouchInput()
    {
        if (Input.touchCount > 0 && healthScript.alive)
        {
            Touch touch = Input.GetTouch(0);

            // Convert touch position to world position
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            // Move player towards touch position
            transform.position = Vector2.MoveTowards(transform.position, touchPosition, speed * Time.deltaTime);
            Time.timeScale = 1;
        }
        
    }
    void clamping()
    {
        if (transform.position.y < -2.7f)
        {
            transform.position = new Vector3(transform.position.x, -2.7f, transform.position.z);
        }
        if (transform.position.y > 4)
        {
            transform.position = new Vector3(transform.position.x, 4, transform.position.z);
        }

        float xpos = Mathf.Clamp(transform.position.x, -2.22f, 2.22f);
        transform.position = new Vector3(xpos, transform.position.y, transform.position.z);
    }

    IEnumerator spawingBullets()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            Instantiate(bullets, transform.position, transform.rotation);
        }
    }
}

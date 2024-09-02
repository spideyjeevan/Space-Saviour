using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infinityScrolling : MonoBehaviour
{
    [SerializeField] private float ScrollSpeed;
    private Renderer backgroundImage;
    void Start()
    {
        backgroundImage = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 offset = new Vector3(0, ScrollSpeed * Time.time, 0);
        backgroundImage.material.mainTextureOffset = offset; 
        
    }
}

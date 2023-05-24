using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinataHit : MonoBehaviour
{
    [SerializeField] CandySpawner spawner;
    
    private AudioSource audioSource;
    private Rigidbody rb;
    private bool moving=false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.velocity.magnitude > 7 && !moving) {
            spawner.spawn();
            moving = true;
            audioSource.Play();
        }
        if (rb.velocity.magnitude<3.0f)
        {
            moving = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinataHit : MonoBehaviour
{
    [SerializeField] CandySpawner spawner;
    [SerializeField] Logger debug;
    private AudioSource audioSource;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.angularVelocity.magnitude > 10) {
            spawner.spawn();
            rb.angularVelocity = Vector3.zero;
            audioSource.PlayOneShot(audioSource.clip);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinataHit : MonoBehaviour
{
    [SerializeField] CandySpawner spawner;
    [SerializeField] Logger debug;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        debug.LogInfo(rb.angularVelocity.ToString());
        debug.LogInfo(rb.velocity.ToString());
        if(rb.angularVelocity.magnitude > 10) {
            spawner.spawn();
            rb.angularVelocity = Vector3.zero;
        }
    }
}

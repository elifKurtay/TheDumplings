using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject target;

    private Rigidbody rb;

    private Rigidbody targetRb;
    private Transform targetTransform;
    private float velocityThreshold = 1.0f;
    //private float followTime = 2.0f;
    private bool follow = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        targetTransform = target.GetComponent<Transform>();
        targetRb = target.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (follow) {
            rb.MovePosition(target.transform.position);
        }

        // if target is moved, follow it
        Vector3 vel = targetRb.velocity;
        // Debug.Log(vel);
        if (Mathf.Max(vel.x, vel.y, vel.z) > velocityThreshold) {
            follow = true;
        }

        // stop following after some time
        // Invoke("StopFollowing", followTime);
    }

    private void StopFollowing() {
        follow = false;
    }
}

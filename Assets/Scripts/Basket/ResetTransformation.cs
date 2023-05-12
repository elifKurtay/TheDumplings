using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTransformation : MonoBehaviour
{
    public Transform spawner;

    private Rigidbody rigidBody;

    public void Awake() {
        rigidBody = GetComponent<Rigidbody>();
    }

    public void reset() {
        rigidBody.velocity = Vector3.zero;
        rigidBody.angularVelocity = Vector3.zero;
        transform.position = spawner.position;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;

public class ResetPosition : MonoBehaviour
{
    public GameObject target;

    private Rigidbody targetRb;
    private Transform targetTransform;
    // private Vector3 initialPosition;
    // private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        // initialPosition = this.transform.position;
        targetRb = target.GetComponent<Rigidbody>();   
        targetTransform = target.GetComponent<Transform>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // protected void OnDisable() {
        // this.transform.position = initialPosition;
        // this.transform.rotation = target.transform.rotation;
        // rb.velocity = Vector3.zero;
    //     base.OnDisable();
    // }

    public void ResetPos() {
        this.transform.position = targetTransform.position;
        this.transform.rotation = targetTransform.rotation;

        targetRb.velocity = Vector3.zero;
        targetRb.angularVelocity = Vector3.zero;
    }
}

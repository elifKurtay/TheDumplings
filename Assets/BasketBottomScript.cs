using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketBottomScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider someObject)
    {
        if (someObject.CompareTag("Candy"))
        {
            Rigidbody body = someObject.gameObject.transform.GetComponent<Rigidbody>();
            body.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
        }
    }

    private void OnTriggerExit(Collider someObject)
    {
        if (someObject.CompareTag("Candy"))
        {
            Rigidbody body = someObject.gameObject.transform.GetComponent<Rigidbody>();
            body.constraints = RigidbodyConstraints.None;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
